using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CNDC.BLL;
using CNDC.DAL;
using ModeloComponentes;
using Oracle.DataAccess.Client;
using CNDC.Pistas;


namespace OraDalComponentes
{
    public class NodoMgr : OraDalBaseMgr, INodoMgr
    {
        #region Singleton

        private static NodoMgr _instancia;
        static NodoMgr()
        {
            _instancia = new NodoMgr();
        }


        public static NodoMgr Instancia
        {
            get { return _instancia; }
        }

        #endregion Singleton


        public NodoMgr()
        {
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(Nodo.NOMBRE_TABLA);
            return tabla;
        }

        public DataTable GetNodoCompleto()
        {
            string sql =
            @"SELECT a.PK_COD_NODO, a.PK_NIVEL_TENSION, a.D_COD_AREA, b.DESCRIPCION_TIPO AS DESCRIPCION_DOMINIO, a.SIGLA_NODO, a.NOMBRE_NODO, a.DESCRIPCION_NODO,a.D_COD_ESTADO,
                a.SEC_LOG, a.SINC_VER, a.FECHA_INGRESO ,a.FECHA_SALIDA
                FROM F_AC_NODO a , P_AC_TIPOCOMPONENTE b
                WHERE a.D_COD_AREA = b.PK_COD_TIPO_COMPONENTE";
            return EjecutarSql(sql);
        }

        public bool IdUniversalExiste(string idUniversal)
        {
            bool rtn = false;
            string sql = string.Empty;


            sql = "select count(*) cnt  from f_ac_nodo where nombre_nodo = :idUniversal";

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

        public long GetPkCodNodo(string idUNodo)
        {
            long pk = -1;
            string nodo = idUNodo.Trim() ;

            string sql = string.Empty;



            sql = "select pk_cod_nodo  from f_ac_nodo where nombre_nodo = :idUniversal and sysdate between fecha_ingreso and nvl(fecha_salida, sysdate +1)";


            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("idUniversal", OracleDbType.Varchar2, nodo, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                pk = (long)tabla.Rows[0]["pk_cod_nodo"];


            }

            return pk;

        }

        public bool NodoConRelacion(string idUniversal, DateTime fechaIngreso, DateTime FechaSalida)
        {
            bool rtn = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"select count(*)c from f_ac_rcomponente_nodo
                    where pk_cod_nodo = (select pk_cod_nodo from f_ac_nodo
                    where nombre_nodo =:idUniversal)
                    AND :fingreso    >= fecha_ingreso
                    AND :fingreso   <= NVL (fecha_salida, :fingreso)
                    AND :fsalida      >= fecha_ingreso
                    AND :fsalida      <  NVL (fecha_salida, :fsalida +1 )";
            cmd.Parameters.Add("idUniversal", idUniversal);
            cmd.Parameters.Add("fingreso", fechaIngreso);
            cmd.Parameters.Add("fsalida", FechaSalida);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {

                decimal val = (decimal)tabla.Rows[0][0];
                if (val > 0)
                {
                    rtn = true;
                }


            }
            return rtn;
        }
        
        public bool NodoValidoEnRango(string idUniversal, DateTime fechaIngreso, DateTime FechaSalida)
        {
            bool rtn= false ;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT count(*) c
                    FROM f_ac_nodo
                    WHERE nombre_nodo =:idUniversal
                    AND :fingreso    >= fecha_ingreso
                    AND :fingreso   <= NVL (fecha_salida, :fingreso)
                    AND :fsalida      >= fecha_ingreso
                    AND :fsalida      <  NVL (fecha_salida, :fsalida+1)";
            cmd.Parameters.Add("idUniversal", idUniversal);
            cmd.Parameters.Add("fingreso", fechaIngreso);
            cmd.Parameters.Add("fsalida", FechaSalida);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {

                decimal val = (decimal)tabla.Rows[0][0];
                if (val > 0)
                {
                    rtn = true;
                }


            }
            return rtn;
        }
        
        public DataTable GetNodoPorFecha(DateTime fecha)
        {
            DataTable resultado;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"Select  b.pk_cod_componente, a.pk_cod_nodo, a.sigla_nodo, a.nombre_nodo, a.descripcion_nodo, b.fecha_ingreso, b.fecha_salida
                From F_AC_NODO a, F_AC_RCOMPONENTE_NODO b
                Where a.pk_cod_nodo=b.pk_cod_nodo
                And  :fecha between b.fecha_ingreso and nvl (b.fecha_salida, :fecha +1)";
            cmd.Parameters.Add("fecha", OracleDbType.Date, fecha, ParameterDirection.Input);
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }
        public DataTable GetNodoPorFecha(decimal pkcodcomponente, DateTime fecha)
        {
            DataTable resultado;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"Select  b.pk_cod_componente, a.pk_cod_nodo, a.sigla_nodo, a.nombre_nodo, a.descripcion_nodo, b.fecha_ingreso, b.fecha_salida
                From F_AC_NODO a, F_AC_RCOMPONENTE_NODO b
                Where a.pk_cod_nodo=b.pk_cod_nodo
                And   b.pk_cod_componente=:pkcodcomponente
                And  :fecha between b.fecha_ingreso and nvl (b.fecha_salida, :fecha +1)";
            cmd.Parameters.Add("pkcodcomponente", OracleDbType.Int64, pkcodcomponente, ParameterDirection.Input);
            cmd.Parameters.Add("fecha", OracleDbType.Date, fecha, ParameterDirection.Input);
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public Nodo GetNodo(long pkCodNodo)
        {
            Nodo resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            "select * from F_AC_NODO where PK_COD_NODO=:PK_COD_NODO"; // AND d_cod_estado = 'VI'";// AND FECHA_SALIDA is null";
            cmd.Parameters.Add("PK_COD_NODO", pkCodNodo);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new Nodo(tabla.Rows[0]);
            }
            return resultado;
        }

        public DataTable GetNodoCompleto(long pkCodNodo)
        {
            DataTable resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT a.PK_COD_NODO, a.PK_NIVEL_TENSION, a.D_COD_AREA,  a.SIGLA_NODO, a.NOMBRE_NODO
                    , a.DESCRIPCION_NODO,a.D_COD_ESTADO,a.SEC_LOG, a.SINC_VER, a.FECHA_INGRESO ,a.FECHA_SALIDA 
            FROM F_AC_NODO a  
            WHERE   A.PK_COD_NODO=:PK_COD_NODO";
            cmd.Parameters.Add("PK_COD_NODO", pkCodNodo);
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;

        }

        public void Insertar(List<DataRow> rows)
        {
            string sql =
            @"INSERT INTO F_AC_NODO
                    PK_COD_NODO, PK_NIVEL_TENSION, D_COD_AREA, SIGLA_NODO, NOMBRE_NODO, 
                    DESCRIPCION_NODO, D_COD_ESTADO,SEC_LOG, SINC_VER, FECHA_INGRESO, FECHA_SALIDA
                    VALUES
                    ( :PK_COD_NODO, :PK_NIVEL_TENSION, :D_COD_AREA, :SIGLA_NODO, :NOMBRE_NODO,
                    :DESCRIPCION_NODO, :D_COD_ESTADO, :SEC_LOG, :SINC_VER, :FECHA_INGRESO, :FECHA_SALIDA)";
            InsertUpdate(rows, sql);
        }
        public string GetIdUniversal(long pkCodNodo)
        {
            string rtn = string.Empty;
            DataTable table = GetNodoCompleto(pkCodNodo);

            ;
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                rtn = (string)row["nombre_nodo"];
            }
            return rtn;

        }
        public void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add("pk_cod_nodo", OracleDbType.Int64, GetArray(tabla, "pk_cod_nodo"), ParameterDirection.Input);
            cmd.Parameters.Add("pk_nivel_tension", OracleDbType.Int64, GetArray(tabla, "pk_nivel_tension"), ParameterDirection.Input);
            cmd.Parameters.Add("d_cod_area", OracleDbType.Int64, GetArray(tabla, "d_cod_area"), ParameterDirection.Input);
            cmd.Parameters.Add("sigla_nodo", OracleDbType.Varchar2, GetArray(tabla, "sigla_nodo"), ParameterDirection.Input);
            cmd.Parameters.Add("nombre_nodo", OracleDbType.Varchar2, GetArray(tabla, "nombre_nodo"), ParameterDirection.Input);
            cmd.Parameters.Add("descripcion_nodo", OracleDbType.Varchar2, GetArray(tabla, "descripcion_nodo"), ParameterDirection.Input);
            cmd.Parameters.Add("d_cod_estado", OracleDbType.Varchar2, GetArray(tabla, "d_cod_estado"), ParameterDirection.Input);
            cmd.Parameters.Add("sec_log", OracleDbType.Int64, GetArray(tabla, "sec_log"), ParameterDirection.Input);
            cmd.Parameters.Add("sinc_ver", OracleDbType.Int64, GetArray(tabla, "sinc_ver"), ParameterDirection.Input);
            cmd.Parameters.Add("fecha_ingreso", OracleDbType.Date, GetArray(tabla, "fecha_ingreso"), ParameterDirection.Input);
            cmd.Parameters.Add("fecha_salida", OracleDbType.Date, GetArray(tabla, "fecha_salida"), ParameterDirection.Input);
            Actualizar(cmd);
        }
        private long GetPkCodNodo()
        {
            long rtn = -1;
            string sql = "select SEC_F_AC_NODOS.nextval i from dual ";
            OracleCommand cmd = CrearCommand(sql);
            object o = cmd.ExecuteScalar();
            rtn = Convert.ToInt64((decimal)o);
            return rtn;
        }
        public bool Eliminar(ModeloComponentes.Componente c)
        {
            bool rtn = false;
            string sql = "delete from F_AC_NODO  WHERE PK_COD_NODO  = :PK_COD_NODO";
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_NODO", OracleDbType.Long, c.PkCodComponente, ParameterDirection.Input);
            Pista p = PistaMgr.Instance.Info("OraDAlComponentes", string.Format(" DelNodo PkCodNodo={0},SiglaNodo={1},NombreNodo={2} ,Descripcion_nodo={3}", c.PkCodComponente, c.CodigoComponente, c.NombreComponente, c.Descripcion));
            if (Actualizar(cmd))
            {
                rtn = true;
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
                idComponente = GetPkCodNodo();
                c.PkCodComponente = idComponente;

                if (c.TieneFechaSalida)
                {
                    sql = @" INSERT
                            INTO F_AC_NODO
                            (
                            PK_COD_NODO,
                            SIGLA_NODO,
                            NOMBRE_NODO,
                            DESCRIPCION_NODO,
                            FECHA_INGRESO,
                            FECHA_SALIDA,
                            SEC_LOG
                            )
                            VALUES
                            (
                            :PK_COD_NODO,
                            :SIGLA_NODO,
                            :NOMBRE_NODO,
                            :DESCRIPCION_NODO,
                            :FECHA_INGRESO,
                            :FECHA_SALIDA,
                            :SEC_LOG
                            )";
                                            }
                else
                {
                    sql = @" INSERT
                            INTO F_AC_NODO
                            (
                            PK_COD_NODO,
                            SIGLA_NODO,
                            NOMBRE_NODO,
                            DESCRIPCION_NODO,
                            FECHA_INGRESO,
                            SEC_LOG,
FECHA_SALIDA
                            )
                            VALUES
                            (
                            :PK_COD_NODO,
                            :SIGLA_NODO,
                            :NOMBRE_NODO,
                            :DESCRIPCION_NODO,
                            :FECHA_INGRESO,
                            :SEC_LOG,
NULL
                            )";

                }
                p = PistaMgr.Instance.Info("OraDAlComponentes", string.Format(" Insert PkCodNodo={0},SiglaNodo={1},NombreNodo={2} ,Descripcion_nodo={3}", c.PkCodComponente, c.CodigoComponente, c.NombreComponente, c.Descripcion));


            }
            else
            {
                if (c.TieneFechaSalida)
                {
                    sql = @" UPDATE F_AC_NODO
SET SIGLA_NODO =:SIGLA_NODO ,
NOMBRE_NODO=:NOMBRE_NODO,
DESCRIPCION_NODO=:DESCRIPCION_NODO,
FECHA_INGRESO=:FECHA_INGRESO,
FECHA_SALIDA=:FECHA_SALIDA,
SEC_LOG =:SEC_LOG
WHERE PK_COD_NODO  = :PK_COD_NODO";

                }
                else
                {
                    sql = @" UPDATE F_AC_NODO
SET SIGLA_NODO =:SIGLA_NODO ,
NOMBRE_NODO=:NOMBRE_NODO,
DESCRIPCION_NODO=:DESCRIPCION_NODO,
FECHA_INGRESO=:FECHA_INGRESO,
SEC_LOG =:SEC_LOG ,
FECHA_SALIDA= NULL
WHERE PK_COD_NODO  = :PK_COD_NODO";
                }
                p = PistaMgr.Instance.Info("OraDAlComponentes", string.Format(" Update PkCodNodo={0},SiglaNodo={1},NombreNodo={2} ,Descripcion_nodo={3}", c.PkCodComponente, c.CodigoComponente, c.NombreComponente, c.Descripcion));
            }



            cmd = CrearCommand();
            cmd.CommandText = sql;

            long SecLog = (long)p.PK_SecLog;

            cmd.Parameters.Add("PK_COD_NODO", OracleDbType.Long, c.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add("NOMBRE_NODO", OracleDbType.Varchar2, c.CodigoComponente, ParameterDirection.Input);
            cmd.Parameters.Add("DESCRIPCION_NODO", OracleDbType.Varchar2, c.Descripcion, ParameterDirection.Input);
            cmd.Parameters.Add("FECHA_INGRESO", OracleDbType.Date, c.FechaIngreso, ParameterDirection.Input);
            cmd.Parameters.Add("SIGLA_NODO", OracleDbType.Varchar2, c.NombreComponente, ParameterDirection.Input);

            cmd.Parameters.Add("SEC_LOG", OracleDbType.Int64, SecLog, ParameterDirection.Input);
            if (c.TieneFechaSalida)
            {
                cmd.Parameters.Add("FECHA_SALIDA", OracleDbType.Date, c.FechaSalida, ParameterDirection.Input);
            }
            cmd.BindByName = true;
            if (Actualizar(cmd))
            {
                c.EsNuevo = false;
                idComponente = (long)c.PkCodComponente;

            }



            return idComponente;


        }
    }
}
