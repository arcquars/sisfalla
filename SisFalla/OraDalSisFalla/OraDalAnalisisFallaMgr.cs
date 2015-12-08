using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloSisFalla;
using Oracle.DataAccess.Client;
using CNDC.BLL;
using System.Data;
using System.IO;
using CNDC.Pistas;
using CNDC.Sincronizacion;
using CNDC.DAL;

namespace OraDalSisFalla
{
    public class OraDalAnalisisFallaMgr : OraDalBaseMgr, IAnalisisFallaMgr, IMgrLocal,  IProveedorDatosSincronizacion
    {
        public OraDalAnalisisFallaMgr()
        {

        }
        public OraDalAnalisisFallaMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public string GetNombreArchivo(int numFalla, long codTipoInforme)
        {
            string resultado = string.Empty;
            string sql = @"SELECT nombre_doc_analisis FROM f_gf_doc_analisis
            WHERE pk_cod_falla=:pk_cod_falla AND pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, numFalla, ParameterDirection.Input);
            cmd.Parameters.Add("pk_d_cod_tipoinforme", OracleDbType.Int64, codTipoInforme, ParameterDirection.Input);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = ObjetoDeNegocio.GetValor<string>(tabla.Rows[0]["nombre_doc_analisis"]);
            }
            
            return resultado;
        }

        public byte[] GetArchivo(int numFalla, long codTipoInforme)
        {
            byte[] resultado = null;
            string sql = @"SELECT archivo FROM f_gf_doc_analisis
            WHERE pk_cod_falla=:pk_cod_falla AND pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, numFalla, ParameterDirection.Input);
            cmd.Parameters.Add("pk_d_cod_tipoinforme", OracleDbType.Int64, codTipoInforme, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = ObjetoDeNegocio.GetValor<byte[]>(tabla.Rows[0]["archivo"]);
            }
            return resultado;
        }

        public void Guardar(int numFalla, long codTipoInforme, long pkorigeninforme, string archivo)
        {
            string nombreArchivo = Path.GetFileName(archivo);
            bool existe = ExisteDocAnalisis(numFalla, codTipoInforme, pkorigeninforme);
            string sql = string.Empty;
            if (existe)
            {
                sql = @"UPDATE f_gf_doc_analisis
                    SET archivo             =:archivo,
                      nombre_doc_analisis   =:nombre_doc_analisis
                    WHERE pk_cod_falla      =:pk_cod_falla
                    AND pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme
                    AND pk_origen_informe   =:pk_origen_informe";
            }
            else
            {
                sql = @"INSERT
                        INTO f_gf_doc_analisis
                          (
                            pk_cod_falla,
                            archivo,
                            nombre_doc_analisis,
                            pk_d_cod_tipoinforme,
                            pk_origen_informe
                          )
                          VALUES
                          (
                            :pk_cod_falla,
                            :archivo,
                            :nombre_doc_analisis,
                            :pk_d_cod_tipoinforme,
                            :pk_origen_informe
                          )";
            }

            byte[] b = File.ReadAllBytes(archivo);
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, numFalla, ParameterDirection.Input);
            cmd.Parameters.Add("archivo", OracleDbType.Blob, b, ParameterDirection.Input);
            cmd.Parameters.Add("nombre_doc_analisis", OracleDbType.Varchar2, nombreArchivo, ParameterDirection.Input);
            cmd.Parameters.Add("pk_d_cod_tipoinforme", OracleDbType.Int64, codTipoInforme, ParameterDirection.Input);
            cmd.Parameters.Add("pk_origen_informe", OracleDbType.Int64, pkorigeninforme, ParameterDirection.Input);
            Actualizar(cmd);
        }

        private bool ExisteDocAnalisis(int numFalla, long codTipoInforme, long pkOrigenInforme)
        {
            bool resultado = false;
            string sql = @"SELECT count(*) FROM f_gf_doc_analisis
            WHERE pk_cod_falla=:pk_cod_falla AND pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme and pk_origen_informe= :pkorigeninforme";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, numFalla, ParameterDirection.Input);
            cmd.Parameters.Add("pk_d_cod_tipoinforme", OracleDbType.Int64, codTipoInforme, ParameterDirection.Input);
            cmd.Parameters.Add("pkorigeninforme", OracleDbType.Int64, pkOrigenInforme, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = ObjetoDeNegocio.GetValor<decimal>(tabla.Rows[0][0]) > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql =
            @"INSERT INTO f_gf_doc_analisis(pk_cod_falla,archivo,nombre_doc_analisis,sinc_ver,pk_d_cod_tipoinforme,PK_ORIGEN_INFORME) 
            VALUES(:pk_cod_falla,:archivo,:nombre_doc_analisis,:sinc_ver,:pk_d_cod_tipoinforme,:PK_ORIGEN_INFORME)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql =
            @"UPDATE f_gf_doc_analisis
            SET archivo=:archivo,
            nombre_doc_analisis=:nombre_doc_analisis,
            sinc_ver=:sinc_ver
            WHERE pk_cod_falla=:pk_cod_falla AND pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme and PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME";
            InsertUpdate(rows, sql);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = CrearCommand(sql);
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, GetArray(tabla, "PK_COD_FALLA"), ParameterDirection.Input);
            cmd.Parameters.Add("archivo", OracleDbType.Blob, GetArray(tabla, "ARCHIVO"), ParameterDirection.Input);
            cmd.Parameters.Add("nombre_doc_analisis", OracleDbType.Varchar2, GetArray(tabla, "NOMBRE_DOC_ANALISIS"), ParameterDirection.Input);
            cmd.Parameters.Add("sinc_ver", OracleDbType.Int64, GetArray(tabla, "SINC_VER"), ParameterDirection.Input);
            cmd.Parameters.Add("pk_d_cod_tipoinforme", OracleDbType.Int64, GetArray(tabla, "pk_d_cod_tipoinforme"), ParameterDirection.Input);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", OracleDbType.Int64, GetArray(tabla, "PK_ORIGEN_INFORME"), ParameterDirection.Input);
            
            Actualizar(cmd);
        }

        public string NombreTabla
        {
            get { return AnalisisFalla.NOMBRE_TABLA; }
        }

        public DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial)
        {
            DataTable resultado = null;
            string sql = string.Empty;
            if (parcial)
            {
                sql = @"SELECT a.*
                FROM f_gf_doc_analisis a
                WHERE a.sinc_ver > :sinc_ver 
                AND a.pk_cod_falla IN 
                (SELECT b.pk_cod_falla
                FROM f_gf_notificacion b
                WHERE b.pk_cod_persona=:pk_cod_persona AND b.d_cod_estado_notificacion <> 41)";
            }
            else
            {
                sql = @"SELECT a.*
                FROM f_gf_doc_analisis a
                WHERE a.sinc_ver > :sinc_ver ";
            }
            
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("sinc_ver", OracleDbType.Decimal, versionCliente, ParameterDirection.Input);
            if (parcial)
            {
                cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, pkCodPersona, ParameterDirection.Input);
            }
            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public AnalisisFalla GetAnalisis(int numFalla, long codTipoInforme , long pkCodOrigen)
        {
            AnalisisFalla resultado = null;
            string sql = @"SELECT * FROM f_gf_doc_analisis 
            WHERE pk_cod_falla=:pk_cod_falla AND pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme 
                and pk_origen_informe = :pkorigeninforme";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, numFalla, ParameterDirection.Input);
            cmd.Parameters.Add("pk_d_cod_tipoinforme", OracleDbType.Int64, codTipoInforme, ParameterDirection.Input);
            cmd.Parameters.Add("pkorigeninforme", OracleDbType.Int64, pkCodOrigen, ParameterDirection.Input);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new AnalisisFalla();
                resultado.PkCodFalla = numFalla;
                resultado.PkDCodTipoInforme = codTipoInforme;
                resultado.Causa = ObjetoDeNegocio.GetValor<string>(tabla.Rows[0]["causa"], string.Empty);
                resultado.Observaciones = ObjetoDeNegocio.GetValor<string>(tabla.Rows[0]["observaciones"], string.Empty);
                resultado.DesconexionComponente = ObjetoDeNegocio.GetValor<string>(tabla.Rows[0]["desconexion_componente"], string.Empty);
            }
            return resultado;
        }

        public void Guardar(AnalisisFalla analisis)
        {
            bool existe = ExisteDocAnalisis(analisis.PkCodFalla, analisis.PkDCodTipoInforme,analisis.PkOrigenInforme);
            string sql = string.Empty;
            if (existe)
            {
                sql = @"UPDATE f_gf_doc_analisis
                        SET causa               =:causa,
                          observaciones         =:observaciones,
                          desconexion_componente=:desconexion_componente
                        WHERE pk_cod_falla      =:pk_cod_falla
                        AND pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme
                        AND pk_origen_informe   =:pk_origen_informe";
            }
            else
            {
                sql = @"INSERT
                    INTO f_gf_doc_analisis
                      (
                        pk_cod_falla,
                        causa,
                        observaciones,
                        desconexion_componente,
                        pk_d_cod_tipoinforme,
                        pk_origen_informe
                      )
                      VALUES
                      (
                        :pk_cod_falla,
                        :causa,
                        :observaciones,
                        :desconexion_componente,
                        :pk_d_cod_tipoinforme,
                        :pk_origen_informe
                      )";
            }

            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, analisis.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add("causa", OracleDbType.Varchar2, analisis.Causa, ParameterDirection.Input);
            cmd.Parameters.Add("observaciones", OracleDbType.Varchar2, analisis.Observaciones, ParameterDirection.Input);
            cmd.Parameters.Add("desconexion_componente", OracleDbType.Varchar2, analisis.DesconexionComponente, ParameterDirection.Input);
            cmd.Parameters.Add("pk_d_cod_tipoinforme", OracleDbType.Int64, analisis.PkDCodTipoInforme, ParameterDirection.Input);
            cmd.Parameters.Add("pk_origen_informe", OracleDbType.Int64, analisis.PkOrigenInforme, ParameterDirection.Input);
            Actualizar(cmd);
        }

        public string DescargarInformeAnalisis(int pkCodFalla, long codTipoInforme)
        {
            string resultado = null;
            try
            {
                byte[] b = ModeloMgr.Instancia.AnalisisMgr.GetArchivo(pkCodFalla, codTipoInforme);
                string nombreDoc = ModeloMgr.Instancia.AnalisisMgr.GetNombreArchivo(pkCodFalla, codTipoInforme);
                nombreDoc = Path.Combine("C:\\WCFSISFALLA", nombreDoc);
                if (b != null)
                {
                    if (File.Exists(nombreDoc))
                    {
                        FileInfo fInfoA = new FileInfo(nombreDoc);
                        fInfoA.IsReadOnly = false;
                        File.Delete(nombreDoc);
                    }
                    File.WriteAllBytes(nombreDoc, b);
                    FileInfo fInfoB = new FileInfo(nombreDoc);
                    fInfoB.IsReadOnly = true;
                    resultado = nombreDoc;
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("OraDalAnalisisFallaMgr", ex);
            }
            return resultado;
        }

        public void Copiar(int numFalla, long codTipoInformeAnterior, long pkOrigenInforme)
        {
            string sql = @"INSERT INTO f_gf_doc_analisis(pk_cod_falla,
              archivo,
              sinc_ver,
              nombre_doc_analisis,
              causa,
              observaciones,
              desconexion_componente,
              pk_d_cod_tipoinforme,
            PK_ORIGEN_INFORME   )
            SELECT pk_cod_falla,
              archivo,
              sinc_ver,
              nombre_doc_analisis,
              causa,
              observaciones,
              desconexion_componente,
              pk_d_cod_tipoinforme+1,
            PK_ORIGEN_INFORME
            FROM f_gf_doc_analisis 
            WHERE pk_cod_falla=:pk_cod_falla AND pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme and PK_ORIGEN_INFORME =:PK_ORIGEN_INFORME";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, numFalla, ParameterDirection.Input);
            cmd.Parameters.Add("pk_d_cod_tipoinforme", OracleDbType.Int64, codTipoInformeAnterior, ParameterDirection.Input);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", OracleDbType.Int64, pkOrigenInforme, ParameterDirection.Input);
            Actualizar(cmd);
        }

    }
}
