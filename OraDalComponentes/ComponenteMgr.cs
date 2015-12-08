using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using ModeloComponentes;
using CNDC.DAL;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.Pistas;


namespace OraDalComponentes
{
    public class ComponenteMgr : OraDalBaseMgr, IComponenteMgr
    {
        #region Singleton

        private static ComponenteMgr _instancia;
        static ComponenteMgr()
        {
            _instancia = new ComponenteMgr();
        }


        public static ComponenteMgr Instancia
        {
            get { return _instancia; }
        }

        #endregion Singleton
        public ComponenteMgr(ConnexionOracleMgr c)
            : base(c)
        {
        }
        public ComponenteMgr()
        {
        }

        // Implementacion interface
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(Componente.NOMBRE_TABLA);
            return tabla;
        }




        public bool IdUniversalExiste(string idUniversal)
        {
            bool rtn = false;
            string sql = string.Empty;
            sql = " select count(*) cnt from f_ac_componente where codigo_componente = :idUniversal";

            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("idUniversal", OracleDbType.Varchar2, idUniversal, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                decimal cnt = (decimal)tabla.Rows[0]["cnt"];
                if (cnt == 0)
                {
                    rtn = false;
                }
                else
                {
                    rtn = true;
                }
            }

            return rtn;

        }
        public DataTable GetComponenteCompleto()
        {
            return GetComponenteCompleto(DateTime.Now.Date);
        }
        public DataTable GetNodos()
        {

            string sql = "select pk_cod_nodo, sigla_nodo || '-'||descripcion_nodo valor from f_ac_nodo";

            OracleCommand cmd = CrearCommand(sql);
            return EjecutarCmd(cmd);

        }

        public DataTable GetComponentesAbm()
        {
            string sql = @"SELECT PK_CMP,
                            ID_COMP,
                            COD_COMP,
                            TIPO_COMP,
                            SIGLA,
                            PK_AGENTE,
                            COD_AGENTE,
                            DESCRIPCION,
                            FECHA_INI,
                            FECHA_BAJA,
                            PK_COD_NODO_ORIGEN,
                            PK_COD_NODO_DESTINO,
                            NODO_ORIGEN,
                            NODO_DESTINO
                            FROM V_GF_ABM_COMPONENTES
                             order by tipo_comp
                            ";



            OracleCommand cmd = CrearCommand(sql);
            return EjecutarCmd(cmd);
        }

        public DataTable GetComponenteCompleto(DateTime fecha)
        {
            string sql = @"SELECT  c.pk_cod_componente, c.nombre_componente,
                            c.descripcion_componente desc_comp, c.d_tipo_componente,
                            e.descripcion_tipo tipo_comp, c.propietario,
                            p.sigla || ' - ' || p. nom_persona nom_cod_agente,
                            o.pk_cod_nodo AS pk_cod_nodo_origen, d.pk_cod_nodo AS pk_cod_nodo_destino,
                            o.sigla_nodo nodo_origen, d.sigla_nodo nodo_destino,
                            c.fecha_ingreso, c.fecha_salida, codigo_componente
                            FROM  f_ac_componente c ,
                            (SELECT n.PK_COD_COMPONENTE, n.PK_COD_NODO ,
                            n.D_COD_TIPO_RELACION , n.FECHA_INGRESO ,
                            n.FECHA_SALIDA, m.sigla_nodo
                            FROM f_ac_rcomponente_nodo n, f_ac_nodo m
                            WHERE d_cod_tipo_relacion = 3602
                            AND n.pk_cod_nodo = m.pk_cod_nodo
                            AND :fecha between m.fecha_ingreso and nvl (m.fecha_salida, :fecha +1)
                            ) o,
                            (SELECT n.PK_COD_COMPONENTE , n.PK_COD_NODO ,
                            n.D_COD_TIPO_RELACION , n.FECHA_INGRESO ,
                            n.FECHA_SALIDA, m.sigla_nodo
                            FROM  f_ac_rcomponente_nodo n, f_ac_nodo m
                            WHERE d_cod_tipo_relacion = 3603
                            AND n.pk_cod_nodo = m.pk_cod_nodo
                            AND :fecha between m.fecha_ingreso and nvl (m.fecha_salida, :fecha +1)
                            ) d ,
                            p_ac_tipocomponente e ,
                            f_ap_persona p
                            WHERE c.pk_cod_componente = o.pk_cod_componente
                            AND c.pk_cod_componente = d.pk_cod_componente (+)
                            AND :fecha BETWEEN o.fecha_ingreso AND NVL(o.fecha_salida, :fecha + 1)
                            AND :fecha BETWEEN NVL(d.fecha_ingreso , :fecha -1 )AND NVL(d.fecha_salida, :fecha + 1)
                            AND c.d_tipo_componente= e.PK_COD_TIPO_COMPONENTE
                            AND p.pk_cod_persona = c.propietario ";

            //OJO. En la consulta se usan las constantes 3602 y 3603, esto para hacer referencia al tipo de relacion con el nodo(origen o destino).
            //Estos valores(3602 y 3603) puenden cambiar en la BD de produccion.

            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("fecha", OracleDbType.Date, fecha, ParameterDirection.Input);
            return EjecutarCmd(cmd);
        }
        public Componente GetComponente(decimal pkCodComponente)
        {
            Componente resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            "Select * From F_AC_COMPONENTE where PK_COD_COMPONENTE=:PK_COD_COMPONENTE AND D_COD_ESTADO = 'VI'";// AND FECHA_SALIDA is null";
            cmd.Parameters.Add("PK_COD_COMPONENTE", pkCodComponente);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            DataRow row = null;
            if (tabla.Rows.Count > 0)
            {
                row = tabla.Rows[0];
                resultado = new Componente(row);
            }
            return resultado;
        }

        public DataTable GetComponenteCompleto(long codPropietario)
        {
            DataTable resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"Select a.PK_COD_COMPONENTE, a.NOMBRE_COMPONENTE, a.DESCRIPCION_COMPONENTE, a.D_TIPO_COMPONENTE, b.DESCRIPCION_TIPO as TIPO_COMPONENTE,
a.FECHA_INGRESO,a.FECHA_SALIDA,a.PROPIETARIO, p.Sigla || ' - ' || p. NOM_PERSONA NOM_COD_AGENTE,a.D_COD_ESTADO, a.PK_COD_NODO_ORIGEN ,
a.PK_COD_NODO_DESTINO,a.CODIGO_COMPONENTE,a.SEC_LOG,a.SINC_VER
From F_AC_COMPONENTE a , P_AC_TIPOCOMPONENTE b , F_AP_PERSONA p
Where a.D_TIPO_COMPONENTE = b.PK_COD_TIPO_COMPONENTE

AND p.PK_COD_PERSONA = a.PROPIETARIO
AND a.D_COD_ESTADO = 'VI'
AND a.PROPIETARIO=:PROPIETARIO";
            cmd.Parameters.Add("PROPIETARIO", OracleDbType.Int64, codPropietario, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }



        public DataTable GetComponentePorTipo(long tipoComponente)
        {
            return GetComponentePorTipo(tipoComponente, DateTime.Now.Date);
        }
        public DataTable GetComponentePorTipo(long tipoComponente, DateTime fecha)
        {
            DataTable resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT  c.pk_cod_componente, c.nombre_componente,
c.descripcion_componente desc_comp, c.d_tipo_componente, c.propietario,
p.sigla || ' - ' || p. nom_persona nom_cod_agente,
o.pk_cod_nodo AS pk_cod_nodo_origen, d.pk_cod_nodo AS pk_cod_nodo_destino,
o.sigla_nodo nodo_origen, d.sigla_nodo nodo_destino,
c.fecha_ingreso, c.fecha_salida, c.codigo_componente
FROM  f_ac_componente c ,
(SELECT n.PK_COD_COMPONENTE, n.PK_COD_NODO ,
n.D_COD_TIPO_RELACION , n.FECHA_INGRESO ,
n.FECHA_SALIDA, m.sigla_nodo
FROM f_ac_rcomponente_nodo n, f_ac_nodo m
WHERE d_cod_tipo_relacion = 3602
AND n.pk_cod_nodo = m.pk_cod_nodo
AND :fecha between m.fecha_ingreso and nvl (m.fecha_salida, :fecha +1)
) o,
(SELECT n.PK_COD_COMPONENTE , n.PK_COD_NODO ,
n.D_COD_TIPO_RELACION , n.FECHA_INGRESO ,
n.FECHA_SALIDA, m.sigla_nodo
FROM  f_ac_rcomponente_nodo n, f_ac_nodo m
WHERE d_cod_tipo_relacion = 3603
AND n.pk_cod_nodo = m.pk_cod_nodo
AND :fecha between m.fecha_ingreso and nvl (m.fecha_salida, :fecha +1)
) d,
f_ap_persona p
WHERE c.pk_cod_componente = o.pk_cod_componente
AND c.pk_cod_componente = d.pk_cod_componente (+)
AND :fecha BETWEEN o.fecha_ingreso AND NVL(o.fecha_salida, :fecha + 1)
AND :fecha BETWEEN NVL(d.fecha_ingreso , :fecha -1 )AND NVL(d.fecha_salida, :fecha + 1)
AND p.pk_cod_persona = c.propietario
And c.d_tipo_componente =:d_tipo_componente ";
            cmd.Parameters.Add("D_TIPO_COMPONENTE", OracleDbType.Int64, tipoComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("fecha", OracleDbType.Date, fecha, ParameterDirection.Input);
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }


        public DataTable PerteneceSTI(decimal pkCodComponente)
        {

            DataTable _registros = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = @"SELECT * FROM f_ac_componente_sti WHERE pk_cod_componente=:pk_cod_componente";
            cmd.Parameters.Add("pk_cod_componente", pkCodComponente);
            cmd.BindByName = true;
            _registros = EjecutarCmd(cmd);
            return _registros;
        }

        public void GuardarComponente(Componente regComponente)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (regComponente.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Componente", "Nombre Componente=" + regComponente.NombreComponente);
                regComponente.SecLog = (long)p.PK_SecLog;
                regComponente.PkCodComponente = GetIdAutoNum("SEC_F_AC_COMPONENTE") + 10000;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9})";

            }
            else
            {
                sql = "UPDATE {0} SET {2}=:{2} ,{3}=:{3} ,{4}=:{4} ,{5}=:{5} ,{6}=:{6} ," +
                "{7}=:{7} ,{8}=:{8} ,{9}=:{9}  WHERE " +
                "{1}=:{1}";



            }
            sql = string.Format(sql, Componente.NOMBRE_TABLA, Componente.C_PK_COD_COMPONENTE, Componente.C_NOMBRE_COMPONENTE,
            Componente.C_DESCRIPCION, Componente.C_D_TIPO_COMPONENTE, Componente.C_FECHA_INGRESO,
            Componente.C_PROPIETARIO, Componente.C_SEC_LOG, Componente.C_CODIGO_COMPONENTE,
            Componente.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(Componente.C_PK_COD_COMPONENTE, OracleDbType.Int32, regComponente.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Componente.C_NOMBRE_COMPONENTE, OracleDbType.Varchar2, regComponente.NombreComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Componente.C_DESCRIPCION, OracleDbType.Varchar2, regComponente.Descripcion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Componente.C_D_TIPO_COMPONENTE, OracleDbType.Int64, regComponente.DTipoComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Componente.C_FECHA_INGRESO, OracleDbType.Date, regComponente.FechaIngreso, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Componente.C_PROPIETARIO, OracleDbType.Int64, regComponente.Propietario, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Componente.C_SEC_LOG, OracleDbType.Int64, regComponente.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Componente.C_CODIGO_COMPONENTE, OracleDbType.Varchar2, regComponente.CodigoComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Componente.C_SINC_VER, OracleDbType.Int64, regComponente.SincVer, System.Data.ParameterDirection.Input);
            // cmd.Parameters.Add(Componente.C_D_EQUIVALENCIA, OracleDbType.Int64, regComponente.DEquivalencia, System.Data.ParameterDirection.Input);
            if (Actualizar(cmd))
            {
                regComponente.EsNuevo = false;
            }
        }

        private long GetPkCodComponente()
        {
            long rtn = -1;
            string sql = "select sec_f_ac_componente.nextval i from dual ";
            OracleCommand cmd = CrearCommand(sql);
            object o = cmd.ExecuteScalar();
            rtn = Convert.ToInt64((decimal)o);
            return rtn;
        }



        public DataTable GetTipoComponentes()
        {
            string sql = "select pk_cod_tipo_componente,descripcion_tipo, sigla from p_ac_tipocomponente";
            return EjecutarSql(sql);
        }

        public bool ActualizarNodo(ModeloComponentes.Componente c, long pkCodNodo, long TipoRelacion)
        {
            bool rtn = false;
            Pista p = PistaMgr.Instance.Info("Componente", " ACTUALIZAR: Nombre Componente=" + c.NombreComponente);
            c.SecLog = (long)p.PK_SecLog;
            
            string sql = @" 
                UPDATE
                  f_ac_rcomponente_nodo
                SET
                 fecha_ingreso = :fecha_ingreso
                , fecha_salida  = :fecha_salida
                , sec_log       = :sec_log
                WHERE
                  pk_cod_componente     = :pk_cod_componente
                AND pk_cod_nodo         = :pk_cod_nodo
                AND d_cod_tipo_relacion = :d_cod_tipo_relacion
                ";
 

             OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("PK_COD_COMPONENTE", OracleDbType.Long, c.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add("PK_COD_NODO", OracleDbType.Long, pkCodNodo, ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_TIPO_RELACION", OracleDbType.Long, TipoRelacion, ParameterDirection.Input);
            cmd.Parameters.Add("FECHA_INGRESO", OracleDbType.Date, c.FechaIngreso, ParameterDirection.Input);
            if (c.TieneFechaSalida)
            {
                cmd.Parameters.Add("FECHA_SALIDA", OracleDbType.Date, c.FechaSalida, ParameterDirection.Input);
            }
            else
            {
                cmd.Parameters.Add("FECHA_SALIDA", OracleDbType.Date, DBNull.Value, ParameterDirection.Input);
            }

            cmd.Parameters.Add("SEC_LOG", OracleDbType.Long, c.SecLog, ParameterDirection.Input);
         rtn =    Actualizar(cmd);

            return rtn;
        }

        public bool InsertarNodo(ModeloComponentes.Componente c, long pkCodNodo, long TipoRelacion)
        {
            bool rtn = false;
            string sql = @"  INSERT
            INTO F_AC_RCOMPONENTE_NODO
            (
            PK_COD_COMPONENTE,
            PK_COD_NODO,
            D_COD_TIPO_RELACION,
            FECHA_INGRESO      )
            VALUES
            (
            :PK_COD_COMPONENTE,
            :PK_COD_NODO,
            :D_COD_TIPO_RELACION,
            :FECHA_INGRESO
            )";

            string campo = string.Empty;
            if (TipoRelacion == 3602)  // origen
            {
                campo = "PK_COD_NODO_ORIGEN";
            }
            else
            {
                campo = "PK_COD_NODO_DESTINO";
            }

            string sql2 = string.Format(" update F_AC_COMPONENTE SET {0} = :ppknodo  WHERE PK_COD_COMPONENTE = :PPK_COD_COMPONENTE   and FECHA_INGRESO =:PFECHA_INGRESO", campo);
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("PK_COD_COMPONENTE", OracleDbType.Long, c.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add("PK_COD_NODO", OracleDbType.Long, pkCodNodo, ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_TIPO_RELACION", OracleDbType.Long, TipoRelacion, ParameterDirection.Input);
            cmd.Parameters.Add("FECHA_INGRESO", OracleDbType.Date, c.FechaIngreso, ParameterDirection.Input);
            if (Actualizar(cmd))
            {
                OracleCommand cmd2 = CrearCommand(sql2);
                cmd2.Parameters.Add("PPK_COD_COMPONENTE", OracleDbType.Long, c.PkCodComponente, ParameterDirection.Input);
                cmd2.Parameters.Add("ppknodo", OracleDbType.Long, pkCodNodo, ParameterDirection.Input);
                cmd2.Parameters.Add("PFECHA_INGRESO", OracleDbType.Date, c.FechaIngreso, ParameterDirection.Input);
                if (Actualizar(cmd2))
                {
                    rtn = true;
                }
            }
            return rtn;
        }

        public long Guardar(ModeloComponentes.Componente c)
        {
            long idComponente = -1;
            OracleCommand cmd = null;
            string sql = string.Empty;
            string sqlNodoOrigen = string.Empty;
            string sqlNodoDestino = string.Empty;
            Pista p = null;
            if (c.EsNuevo)
            {
                idComponente = GetPkCodComponente();
                c.PkCodComponente = idComponente;

                if (c.TieneFechaSalida)
                {
                    sql = @" INSERT
                        INTO F_AC_COMPONENTE
                        (PK_COD_COMPONENTE,
                        NOMBRE_COMPONENTE,
                        DESCRIPCION_COMPONENTE,
                        FECHA_INGRESO,
                        FECHA_SALIDA,
                        PROPIETARIO,
                        CODIGO_COMPONENTE,
                        D_TIPO_COMPONENTE,
                        SEC_LOG,
                        D_COD_ESTADO
                        )
                        VALUES
                        (:PK_COD_COMPONENTE,
                        :NOMBRE_COMPONENTE,
                        :DESCRIPCION_COMPONENTE,
                        :FECHA_INGRESO,
                        :FECHA_SALIDA,
                        :PROPIETARIO,
                        :CODIGO_COMPONENTE,
                        :D_TIPO_COMPONENTE,
                        :SEC_LOG
                        ,'VI'
                        )";
                }
                else
                {
                    sql = @" INSERT
                                INTO F_AC_COMPONENTE
                                (PK_COD_COMPONENTE,
                                NOMBRE_COMPONENTE,
                                DESCRIPCION_COMPONENTE,
                                FECHA_INGRESO,
                                PROPIETARIO,
                                CODIGO_COMPONENTE,
                                D_TIPO_COMPONENTE,
                                SEC_LOG,
                                D_COD_ESTADO
                                )
                                VALUES
                                (:PK_COD_COMPONENTE,
                                :NOMBRE_COMPONENTE,
                                :DESCRIPCION_COMPONENTE,
                                :FECHA_INGRESO,
                                :PROPIETARIO,
                                :CODIGO_COMPONENTE,
                                :D_TIPO_COMPONENTE,
                                :SEC_LOG,
                                'VI'
                                )";
                }
                p = PistaMgr.Instance.Info("OraDAlComponentes", string.Format(" Insert PkComponente={0},NOMBRE_COMPONENTE={1},CODIGO_COMPONENTE={2} ,Descripcion_nodo={3}", c.PkCodComponente, c.CodigoComponente, c.NombreComponente, c.Descripcion));
            }
            else
            {
                if (c.TieneFechaSalida)
                {
                    sql = @" UPDATE F_AC_COMPONENTE
SET NOMBRE_COMPONENTE    = :NOMBRE_COMPONENTE ,
DESCRIPCION_COMPONENTE = :DESCRIPCION_COMPONENTE ,
FECHA_INGRESO          = :FECHA_INGRESO ,
FECHA_SALIDA           = :FECHA_SALIDA ,
PROPIETARIO            = :PROPIETARIO ,
CODIGO_COMPONENTE      = :CODIGO_COMPONENTE ,
D_TIPO_COMPONENTE =:D_TIPO_COMPONENTE,
SEC_LOG =:SEC_LOG
WHERE PK_COD_COMPONENTE  = :PK_COD_COMPONENTE";

                }
                else
                {
                    sql = @" UPDATE F_AC_COMPONENTE
SET NOMBRE_COMPONENTE    = :NOMBRE_COMPONENTE ,
DESCRIPCION_COMPONENTE = :DESCRIPCION_COMPONENTE ,
FECHA_INGRESO          = :FECHA_INGRESO ,
PROPIETARIO            = :PROPIETARIO ,
CODIGO_COMPONENTE      = :CODIGO_COMPONENTE ,
D_TIPO_COMPONENTE = :D_TIPO_COMPONENTE,
SEC_LOG =:SEC_LOG,
fecha_salida=null
WHERE PK_COD_COMPONENTE  = :PK_COD_COMPONENTE";
                }
                p = PistaMgr.Instance.Info("OraDAlComponentes", string.Format(" Update PkComponente={0},NOMBRE_COMPONENTE={1},CODIGO_COMPONENTE={2} ,Descripcion_nodo={3}", c.PkCodComponente, c.CodigoComponente, c.NombreComponente, c.Descripcion));
            }

            cmd = CrearCommand(sql);
            long SecLog = (long)p.PK_SecLog;
            cmd.Parameters.Add("PK_COD_COMPONENTE", OracleDbType.Long, c.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add("NOMBRE_COMPONENTE", OracleDbType.Varchar2, c.NombreComponente, ParameterDirection.Input);
            cmd.Parameters.Add("DESCRIPCION_COMPONENTE", OracleDbType.Varchar2, c.Descripcion, ParameterDirection.Input);
            cmd.Parameters.Add("FECHA_INGRESO", OracleDbType.Date, c.FechaIngreso, ParameterDirection.Input);
            cmd.Parameters.Add("PROPIETARIO", OracleDbType.Long, c.Propietario, ParameterDirection.Input);
            cmd.Parameters.Add("CODIGO_COMPONENTE", OracleDbType.Varchar2, c.CodigoComponente, ParameterDirection.Input);
            cmd.Parameters.Add("D_TIPO_COMPONENTE", OracleDbType.Long, c.DTipoComponente, ParameterDirection.Input);
            cmd.Parameters.Add("SEC_LOG", OracleDbType.Int64, SecLog, ParameterDirection.Input);
            if (c.TieneFechaSalida)
            {
                cmd.Parameters.Add("FECHA_SALIDA", OracleDbType.Date, c.FechaSalida, ParameterDirection.Input);
            }
            if (Actualizar(cmd))
            {
                c.EsNuevo = false;
                idComponente = (long)c.PkCodComponente;
            }
            return idComponente;
        }

        public bool Eliminar(ModeloComponentes.Componente c)
        {
            bool rtn = false;
            string sql = "delete from F_AC_COMPONENTE  WHERE PK_COD_COMPONENTE  = :PK_COD_COMPONENTE";
            Pista p = PistaMgr.Instance.Info("OraDAlComponentes", string.Format(" DelCmp PkComponente={0},NOMBRE_COMPONENTE={1},CODIGO_COMPONENTE={2} ,Descripcion_nodo={3}", c.PkCodComponente, c.CodigoComponente, c.NombreComponente, c.Descripcion));
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("PK_COD_COMPONENTE", OracleDbType.Long, c.PkCodComponente, ParameterDirection.Input);
            if (Actualizar(cmd))
            {
                rtn = true;
            }
            return rtn;
        }
    }
}
