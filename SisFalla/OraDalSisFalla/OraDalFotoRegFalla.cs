using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.Sincronizacion;
using System.Data;
using CNDC.BLL;
using ModeloSisFalla;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using BLL;

namespace OraDalSisFalla
{
    public class OraDalFotoRegFalla : OraDalBaseMgr, IMgrLocal, IProveedorDatosSincronizacion
    {
        public OraDalFotoRegFalla()
        {
        }

        public OraDalFotoRegFalla(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Insertar(List<DataRow> rows)
        {
            string sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20})" +
            "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18},:{19},:{20})";

            InsertUpdate(rows, sql);

            string sqlDelete = "DELETE FROM {0} WHERE {1}=:{1} AND {2}=:{2}";
            sql = string.Format(sqlDelete, RegFalla.NOMBRE_TABLA, RegFalla.C_PK_COD_FALLA, RegFalla.C_SEC_LOG);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = rows.Count;
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_PK_COD_FALLA, OracleDbType.Int32, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_SEC_LOG, OracleDbType.Int64, rows));

            
            Actualizar(cmd);

            foreach (DataRow r in rows)
            {
                int pkCodFalla = ObjetoDeNegocio.GetValor<int>(r[FotoRegFalla.C_PK_COD_FALLA]);
                if (ModeloMgr.Instancia.RegFallaMgr.EstaInvolucrado(pkCodFalla,Sesion.Instancia.EmpresaActual.PkCodPersona))
                {
                    MensajeEmergente msg = new MensajeEmergente();
                    msg.Cabecera = "Se ha eliminado el registro de Falla: " + RegFalla.FormatearCodFalla(r[FotoRegFalla.C_PK_COD_FALLA].ToString());
                    msg.Detalle = (string)r[FotoRegFalla.C_DESCRIPCION_CORTA_FALLA];
                    MensajeEmergenteMgr.Intancia.AdicionarMensaje(msg);
                }
            }
        }

        public void Actualizar(List<DataRow> rows)
        {
            
        }

        void InsertUpdate(List<DataRow> rows, string sql)
        {
            sql = string.Format(sql,
                FotoRegFalla.NOMBRE_TABLA,
                FotoRegFalla.C_PK_COD_FALLA,
                FotoRegFalla.C_FEC_INICIO,
                FotoRegFalla.C_PK_COD_COMPONENTE,
                FotoRegFalla.C_D_COD_CAUSA,
                FotoRegFalla.C_DESCRIPCION_CORTA_FALLA,
                FotoRegFalla.C_D_COD_ESTADO,
                FotoRegFalla.C_SEC_LOG,
                FotoRegFalla.C_GESTION,
                FotoRegFalla.C_D_COD_ORIGEN,
                FotoRegFalla.C_D_COD_TIPO_DESCONEXION,
                FotoRegFalla.C_FK_LOGIN_OPERADOR,
                FotoRegFalla.C_SINC_VER,
                FotoRegFalla.C_DESCRIPCION_FALLA,
                FotoRegFalla.C_FK_COD_SUPERVISOR,
                FotoRegFalla.C_FK_COD_OPERADOR,
                FotoRegFalla.C_D_COD_PROBLEMA_GEN,
                FotoRegFalla.C_D_COD_COLAPSO,
                FotoRegFalla.C_FECHA_ELIMINADO,
                FotoRegFalla.C_COMENTARIO,
                FotoRegFalla.C_SQ_VAL);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = rows.Count;
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_PK_COD_FALLA, OracleDbType.Int32, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_FEC_INICIO, OracleDbType.Date, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_PK_COD_COMPONENTE, OracleDbType.Int32, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_D_COD_CAUSA, OracleDbType.Int64, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_DESCRIPCION_CORTA_FALLA, OracleDbType.Varchar2, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_D_COD_ESTADO, OracleDbType.Varchar2, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_SEC_LOG, OracleDbType.Decimal, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_GESTION, OracleDbType.Int16, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_D_COD_ORIGEN, OracleDbType.Int64, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_D_COD_TIPO_DESCONEXION, OracleDbType.Int64, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_FK_LOGIN_OPERADOR, OracleDbType.Varchar2, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_SINC_VER, OracleDbType.Decimal, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_DESCRIPCION_FALLA, OracleDbType.Varchar2, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_FK_COD_SUPERVISOR, OracleDbType.Int64, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_FK_COD_OPERADOR, OracleDbType.Int64, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_D_COD_PROBLEMA_GEN, OracleDbType.Int64, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_D_COD_COLAPSO, OracleDbType.Int64, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_FECHA_ELIMINADO, OracleDbType.Date, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_COMENTARIO, OracleDbType.Varchar2, rows));
            cmd.Parameters.Add(CrearParametroEntrada(FotoRegFalla.C_SQ_VAL, OracleDbType.Int64, rows));

            Actualizar(cmd);
        }

        public string NombreTabla
        {
            get { return FotoRegFalla.NOMBRE_TABLA; }
        }

        public DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial)
        {
            PistaMgr.Instance.Debug("OraDalSisFalla.OraDalFotoRegFalla.GetDatos()", "obteniendo datos");
            DataTable resultado = null;
            string sql = @"SELECT a.*
            FROM FOTO_F_GF_REGFALLA a
            WHERE a.SQ_VAL > :SQ_VAL ";
            /*@"SELECT a.*
            FROM FOTO_F_GF_REGFALLA a
            WHERE a.SQ_VAL > :SQ_VAL 
            AND a.PK_COD_FALLA IN 
            (SELECT b.PK_COD_FALLA
            FROM f_gf_notificacion b
            WHERE b.pk_cod_persona=:pk_cod_persona)";*/

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("SQ_VAL", OracleDbType.Int64, versionCliente, System.Data.ParameterDirection.Input);
            //cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, pkCodPersona, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            resultado = EjecutarCmd(cmd);
            PistaMgr.Instance.Debug("OraDalSisFalla.OraDalFotoRegFalla.GetDatos()", string.Format("Retornando {0} Registros", resultado.Rows.Count));
            return resultado;
        }

        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            string sql = "SELECT COUNT(*) FROM foto_f_gf_regfalla WHERE pk_cod_falla=:pk_cod_falla";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, (int)row["pk_cod_falla"], ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            decimal cantidad = (decimal)tabla.Rows[0][0];
            resultado = cantidad > 0;
            return resultado;
        }
    }
}
