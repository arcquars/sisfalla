using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.BLL;
using System.IO;

namespace MC
{
    public class OraDalMC_RPtoMedFtoMgr : OraDalBaseMgr, IMC_RPtoMedFtoMgr
    {
        #region Singleton
        private static OraDalMC_RPtoMedFtoMgr _instancia;
        static OraDalMC_RPtoMedFtoMgr()
        {
            _instancia = new OraDalMC_RPtoMedFtoMgr();
        }
        public static OraDalMC_RPtoMedFtoMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMC_RPtoMedFtoMgr()
        {

        }
        #endregion Singleton

        public void Guardar(MC_RPuntoMedicionFormato obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql = @"INSERT INTO F_MC_RPTO_MED_FTO
                  (
                    PK_COD_RPTO_MED_FTO,
                    FK_COD_PUNTO_MEDICION,
                    FK_COD_MEDIDOR,
                    FK_COD_FORMATO,
                    NOMBRE_ARCHIVO,
                    PRIORIDAD_LECTURA,
                    CONTIENE_FIN_INTERVALO,
                    FECHA_INICIO,
                    FECHA_FIN,
                    D_COD_ESTADO,
                    SEC_LOG
                  )
                  VALUES
                  (
                    :PK_COD_RPTO_MED_FTO,
                    :FK_COD_PUNTO_MEDICION,
                    :FK_COD_MEDIDOR,
                    :FK_COD_FORMATO,
                    :NOMBRE_ARCHIVO,
                    :PRIORIDAD_LECTURA,
                    :CONTIENE_FIN_INTERVALO,
                    :FECHA_INICIO,
                    :FECHA_FIN,
                    :D_COD_ESTADO,
                    :SEC_LOG
                  )";
            }
            else
            {
                sql = "UPDATE F_MC_RPTO_MED_FTO SET " +
                "PK_COD_RPTO_MED_FTO=:PK_COD_RPTO_MED_FTO ," +
                "FK_COD_PUNTO_MEDICION=:FK_COD_PUNTO_MEDICION ," +
                "FK_COD_MEDIDOR=:FK_COD_MEDIDOR ," +
                "FK_COD_FORMATO=:FK_COD_FORMATO ," +
                "NOMBRE_ARCHIVO=:NOMBRE_ARCHIVO ," +
                "PRIORIDAD_LECTURA=:PRIORIDAD_LECTURA ," +
                "CONTIENE_FIN_INTERVALO=:CONTIENE_FIN_INTERVALO ," +
                "FECHA_INICIO=:FECHA_INICIO ," +
                "FECHA_FIN=:FECHA_FIN ," +
                "D_COD_ESTADO=:D_COD_ESTADO ," +
                "SEC_LOG=:SEC_LOG  WHERE ";
            }

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_PK_COD_RPTO_MED_FTO, OracleDbType.Int64, obj.PkCodRptoMedFto, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_FK_COD_PUNTO_MEDICION, OracleDbType.Int64, obj.FkCodPuntoMedicion, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_FK_COD_MEDIDOR, OracleDbType.Int64, obj.FkCodMedidor, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_FK_COD_FORMATO, OracleDbType.Int64, obj.FkCodFormato, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_NOMBRE_ARCHIVO, OracleDbType.Varchar2, obj.NombreArchivo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_PRIORIDAD_LECTURA, OracleDbType.Int16, obj.PrioridadLectura, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_CONTIENE_FIN_INTERVALO, OracleDbType.Int16, obj.ContieneFinIntervalo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_FECHA_INICIO, OracleDbType.Date, obj.FechaInicio, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_FECHA_FIN, OracleDbType.Date, obj.FechaFin, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RPuntoMedicionFormato.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, ParameterDirection.Input);

            try
            {
                cmd.ExecuteNonQuery();
                obj.EsNuevo = false;
            }
            catch (Exception exception)
            {
                PistaMgr.Instance.Error("DALSisFalla", exception);
            }
            finally
            {
                DisposeCommand(cmd);
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(MC_RPuntoMedicionFormato.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MC_RPuntoMedicionFormato> GetLista()
        {
            BindingList<MC_RPuntoMedicionFormato> resultado = new BindingList<MC_RPuntoMedicionFormato>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_RPuntoMedicionFormato(row));
            }
            return resultado;
        }

        public DataTable GetFormatos(MC_PuntoMedicion puntoMedicion)
        {
            return GetFormatos(puntoMedicion.PkCodPtoMedicion);
        }

        public DataTable GetFormatos(long codPuntoMedicion)
        {
            string sql =
            @"SELECT r.*,m.nombre_med,f.descripcion_fto 
            FROM f_mc_rpto_med_fto r, p_mc_fto_lectura f, f_ac_medidor m
            WHERE r.fk_cod_punto_medicion=:cod_punto_medicion AND r.fk_cod_formato=f.pk_cod_fto
            AND r.fk_cod_medidor=m.pk_cod_medidor
            ORDER BY r.prioridad_lectura";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("cod_punto_medicion", OracleDbType.Int64, codPuntoMedicion, ParameterDirection.Input);
            DataTable resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public bool Existe(long codPuntoMedicion,long codMedidor, long codFormato)
        {
            bool resultado = false;
            string sql =
            @"SELECT COUNT(*) FROM f_mc_rpto_med_fto
            WHERE fk_cod_punto_medicion=:cod_punto_medicion AND fk_cod_formato=:cod_formato
            AND fk_cod_medidor=:cod_medidor";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("cod_punto_medicion", OracleDbType.Int64, codMedidor, ParameterDirection.Input);
            cmd.Parameters.Add("cod_medidor", OracleDbType.Int64, codMedidor, ParameterDirection.Input);
            cmd.Parameters.Add("cod_formato", OracleDbType.Int64, codFormato, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);

            decimal cantidad = (decimal)tabla.Rows[0][0];
            resultado = cantidad > 0;

            return resultado;
        }

        public string BuscarArchivo(string nombreArchivoPrototipo, string carpeta)
        {
            string resultado = string.Empty;
            nombreArchivoPrototipo = nombreArchivoPrototipo.ToLower();
            if (Directory.Exists(carpeta))
            {
                string[] archivos = Directory.GetFiles(carpeta);
                foreach (string arch in archivos)
                {
                    string a = Path.GetFileName(arch.ToLower());
                    if (a == nombreArchivoPrototipo)
                    {
                        resultado = Path.GetFileName(arch);
                        break;
                    }
                    else if (nombreArchivoPrototipo.IndexOf('[') >= 0)
                    {
                        if (TienenMismoPatron(nombreArchivoPrototipo, a))
                        {
                            resultado = Path.GetFileName(arch);
                            break;
                        }
                    }
                }
            }
            return resultado;
        }

        private bool TienenMismoPatron(string nombreArchivoPrototipo, string a)
        {
            bool resultado = false;
            int idx1 = nombreArchivoPrototipo.IndexOf('[');
            int idx2 = nombreArchivoPrototipo.IndexOf(']');
            string inicio = nombreArchivoPrototipo.Substring(0, idx1);
            string fin = nombreArchivoPrototipo.Substring(idx2 + 1);
            resultado = a.StartsWith(inicio) && a.EndsWith(fin);
            return resultado;
        }
    }
}