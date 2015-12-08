using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloSisFalla;
using System.Data;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using CNDC.BLL;
using CNDC.Sincronizacion;
using CNDC.Pistas;

namespace OraDalSisFalla
{
    public class ComponenteMgr : OraDalBaseMgr, IComponenteMgr, IMgrLocal
    {
        public ComponenteMgr()
        {
        }
        public ComponenteMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public DataTable GetTabla()
        {
            return GetTabla("F_AC_COMPONENTE");
        }

        public DataTable GetComponenteCompleto()
        {
            return GetComponenteCompleto(DateTime.Now.Date);
        }

        public DataTable GetComponenteCompleto(DateTime fecha)
        {
            string sql = @"SELECT  c.pk_cod_componente,
  c.nombre_componente,
  c.descripcion_componente desc_comp,
  c.d_tipo_componente,
  e.descripcion_tipo tipo_comp,
  c.propietario,
  p.sigla
  || ' - '
  || p. nom_persona nom_cod_agente,
  o.pk_cod_nodo AS pk_cod_nodo_origen,
  d.pk_cod_nodo AS pk_cod_nodo_destino,
  o.sigla_nodo nodo_origen ,
  d.sigla_nodo nodo_destino
  FROM f_ac_componente c ,
  (SELECT n.PK_COD_COMPONENTE ,
  n.PK_COD_NODO ,
  n.D_COD_TIPO_RELACION ,
  n.FECHA_INGRESO ,
  n.FECHA_SALIDA,
  m.sigla_nodo
 FROM f_ac_rcomponente_nodo n,
  f_ac_nodo m
  WHERE d_cod_tipo_relacion = 3602
  AND n.pk_cod_nodo = m.pk_cod_nodo
  and :fecha between m.fecha_ingreso and nvl (m.fecha_salida, :fecha +1)
  ) o,
  (SELECT n.PK_COD_COMPONENTE ,
  n.PK_COD_NODO ,
  n.D_COD_TIPO_RELACION ,
  n.FECHA_INGRESO ,
  n.FECHA_SALIDA,
  m.sigla_nodo
  FROM f_ac_rcomponente_nodo n,
  f_ac_nodo m
  WHERE d_cod_tipo_relacion = 3603
  AND n.pk_cod_nodo = m.pk_cod_nodo
  and :fecha between m.fecha_ingreso and nvl (m.fecha_salida, :fecha +1)
  ) d ,
  p_ac_tipocomponente e ,
  f_ap_persona p
  WHERE c.pk_cod_componente = o.pk_cod_componente
  AND c.pk_cod_componente = d.pk_cod_componente (+)
  AND :fecha BETWEEN c.fecha_ingreso AND NVL(c.fecha_salida, :fecha + 1)
  AND :fecha BETWEEN o.fecha_ingreso AND NVL(o.fecha_salida, :fecha + 1)
  AND :fecha BETWEEN NVL(d.fecha_ingreso , :fecha -1 )AND NVL(d.fecha_salida, :fecha + 1)
  AND c.d_tipo_componente= e.PK_COD_TIPO_COMPONENTE
  AND p.pk_cod_persona = c.propietario ";

            //OJO. En la consulta se usan las constantes 3602 y 3603, esto para hacer referencia al tipo de relacion con el nodo(origen o destino).
            //Estos valores(3602 y 3603) puenden cambiar en la BD de produccion.


//                @"select c.pk_cod_componente,c.nombre_componente, c.descripcion_componente desc_comp,c.d_tipo_componente,d.descripcion_dominio tipo_comp,
//c.propietario, p.sigla || ' - ' || p. nom_persona nom_cod_agente,o.pk_cod_nodo as pk_cod_nodo_origen, d.pk_cod_nodo as pk_cod_nodo_destino,
//ori.sigla_nodo nodo_origen , des.sigla_nodo nodo_destino
//from f_ac_componente c, p_def_dominios d,f_ap_persona p, f_ac_rcomponente_nodo o,f_ac_rcomponente_nodo d, f_ac_nodo ori, f_ac_nodo des
//where c.d_tipo_componente = d.cod_dominio
//AND p.pk_cod_persona = c.propietario 
//and c.pk_cod_componente=o.pk_cod_componente and o.d_cod_tipo_relacion=3602
//and :fecha between o.fecha_ingreso and NVL(o.fecha_salida, sysdate + 1)
//and c.pk_cod_componente=d.pk_cod_componente(+) and d.d_cod_tipo_relacion=3603
//and :fecha between d.fecha_ingreso and NVL(d.fecha_salida, sysdate + 1)
//and o.pk_cod_nodo=ori.pk_cod_nodo
//and d.pk_cod_nodo=des.pk_cod_nodo(+)";
//            @"SELECT pk_cod_componente, nombre_componente, a.descripcion_componente desc_comp, a.d_tipo_componente, b.descripcion_dominio tipo_comp, 
//            propietario, p.sigla || ' - ' || p. nom_persona nom_cod_agente, pk_cod_nodo_origen , pk_cod_nodo_destino, ori.sigla_nodo nodo_origen , 
//            des.sigla_nodo nodo_destino
//            FROM f_ac_componente a , p_def_dominios b , f_ap_persona p, f_ac_nodo ori, f_ac_nodo des
//            WHERE a.d_tipo_componente = b.cod_dominio
//            AND b.d_cod_tipo ='D_TIPO_COMPONENTE' 
//            AND p.pk_cod_persona = a.propietario 
//            AND ori.pk_cod_nodo = a.pk_cod_nodo_origen and a.pk_cod_nodo_destino = des.pk_cod_nodo(+)
//            AND :fecha BETWEEN a.fecha_ingreso and NVL(a.fecha_salida,sysdate + 1)";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("fecha", OracleDbType.Date, fecha, ParameterDirection.Input);

            return EjecutarCmd(cmd);
        }

        public Componente GetComponente(decimal pkCodComponente)
        {
            Componente resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            "select * from F_AC_COMPONENTE where PK_COD_COMPONENTE=:PK_COD_COMPONENTE";// AND FECHA_SALIDA is null";
            cmd.Parameters.Add("PK_COD_COMPONENTE", pkCodComponente);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new Componente(tabla.Rows[0]);
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql =
            @"INSERT INTO f_ac_componente 
            (pk_cod_componente,nombre_componente,descripcion_componente,d_tipo_componente,
             fecha_ingreso,fecha_salida,propietario,pk_cod_nodo_origen,d_cod_estado,sec_log,
             codigo_componente,pk_cod_nodo_destino,sinc_ver
            ) 
            VALUES 
            (:pk_cod_componente,:nombre_componente,:descripcion_componente,:d_tipo_componente,
             :fecha_ingreso,:fecha_salida,:propietario,:pk_cod_nodo_origen,:d_cod_estado,:sec_log,
             :codigo_componente,:pk_cod_nodo_destino,:sinc_ver
            )";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql =
            @"UPDATE f_ac_componente SET
            nombre_componente=:nombre_componente,
            descripcion_componente=:descripcion_componente,
            d_tipo_componente=:d_tipo_componente,
            fecha_ingreso=:fecha_ingreso,
            fecha_salida=:fecha_salida,
            propietario=:propietario,
            pk_cod_nodo_origen=:pk_cod_nodo_origen,
            d_cod_estado=:d_cod_estado,
            sec_log=:sec_log,
            codigo_componente=:codigo_componente,
            pk_cod_nodo_destino=:pk_cod_nodo_destino,
            sinc_ver=:sinc_ver
            WHERE 
            pk_cod_componente=:pk_cod_componente";
            InsertUpdate(rows, sql);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add("pk_cod_componente", OracleDbType.Decimal, GetArray(tabla, "pk_cod_componente"), ParameterDirection.Input);
            cmd.Parameters.Add("nombre_componente", OracleDbType.Varchar2, GetArray(tabla, "nombre_componente"), ParameterDirection.Input);
            cmd.Parameters.Add("descripcion_componente", OracleDbType.Varchar2, GetArray(tabla, "descripcion_componente"), ParameterDirection.Input);
            cmd.Parameters.Add("d_tipo_componente", OracleDbType.Varchar2, GetArray(tabla, "d_tipo_componente"), ParameterDirection.Input);
            cmd.Parameters.Add("fecha_ingreso", OracleDbType.Date, GetArray(tabla, "fecha_ingreso"), ParameterDirection.Input);
            cmd.Parameters.Add("fecha_salida", OracleDbType.Date, GetArray(tabla, "fecha_salida"), ParameterDirection.Input);
            cmd.Parameters.Add("propietario", OracleDbType.Int64, GetArray(tabla, "propietario"), ParameterDirection.Input);
            cmd.Parameters.Add("pk_cod_nodo_origen", OracleDbType.Int64, GetArray(tabla, "pk_cod_nodo_origen"), ParameterDirection.Input);
            cmd.Parameters.Add("d_cod_estado", OracleDbType.Varchar2, GetArray(tabla, "d_cod_estado"), ParameterDirection.Input);
            cmd.Parameters.Add("sec_log", OracleDbType.Int64, GetArray(tabla, "sec_log"), ParameterDirection.Input);
            cmd.Parameters.Add("codigo_componente", OracleDbType.Varchar2, GetArray(tabla, "codigo_componente"), ParameterDirection.Input);
            cmd.Parameters.Add("pk_cod_nodo_destino", OracleDbType.Decimal, GetArray(tabla, "pk_cod_nodo_destino"), ParameterDirection.Input);
            cmd.Parameters.Add("sinc_ver", OracleDbType.Int64, GetArray(tabla, "sinc_ver"), ParameterDirection.Input);

            Actualizar(cmd);
        }

        public override string NombreTabla
        {
            get { return Componente.NOMBRE_TABLA; }
        }

        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            string sql =
            @"SELECT COUNT(pk_cod_componente) from f_ac_componente
            WHERE pk_cod_componente=:pk_cod_componente";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;

            cmd.Parameters.Add("pk_cod_componente", OracleDbType.Decimal, (decimal)row["pk_cod_componente"], ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = ((decimal)tabla.Rows[0][0]) > 0;
            }
            return resultado;
        }
    }
}