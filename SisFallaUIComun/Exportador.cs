using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using ModeloSisFalla;
using System.Windows.Forms;
using CNDC.BLL;
using CNDC.Sincronizacion;
using OraDalSisFalla;
using CNDC.Pistas;
using System.IO;
using CNDC.UtilesComunes;

namespace SISFALLA
{
    public class Exportardor
    {

        public static  string EnsureExportFolder()
        {

            string _sisfallaWorking = "Informes  CNDC Sisfalla V2";
            string _fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _sisfallaWorking);

            if (!Directory.Exists(_fullPath))
            {
                try
                {
                    Directory.CreateDirectory(_fullPath);
                }
                catch (Exception e)
                {
                    PistaMgr.Instance.Error("SISFALLA", e);
                    _fullPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }

            }
            return _fullPath;
        }

        public bool ExportarNotificacion(RegFalla regFalla)
        {
            bool resultado = ExportarNotificacion(regFalla, "NOTIFICACIONFALLA_" + RegFalla.FormatearCodFalla(regFalla.CodFalla.ToString()) + ".xml");
            return resultado;
        }

        public bool ExportarInforme(InformeFalla infFalla, DataSet ds ,  string path)
        {
            string archivo  =  "INFORMEFALLA_" + RegFalla.FormatearCodFalla(infFalla.PkCodFalla.ToString()) + "_" + CNDC.BLL.Sesion.Instancia.EmpresaActual.Sigla + "_" + InformeFalla.GetTexto(infFalla.PkDCodTipoinforme) + ".xml" ;
            bool resultado = ExportarInformeFalla(ds, infFalla,archivo,   path);
            return resultado;
        }

        private bool ExportarInformeFalla(DataSet ds, InformeFalla informe, string archivo, string path)
        {
            bool resultado = false;

            try
            {
                
                string fullPath = string.Empty;
                fullPath = Path.Combine(path, archivo);
                AdicionarTablasNotificacion(ds, informe);
                ds.DataSetName = "Informe_Falla";
                ds.WriteXml(fullPath);
                ComprimirArchivo(fullPath);
                resultado = true;
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("Exportador", ex);
            }
            return resultado;
        }

        private void AdicionarTablasNotificacion(DataSet ds, InformeFalla informe)
        {
            RegFalla falla = ModeloMgr.Instancia.RegFallaMgr.GetFalla(informe.PkCodFalla);
            DataTable regFalla = ModeloMgr.Instancia.RegFallaMgr.GetRegistros(falla.CodFalla.ToString());
            DataTable dominios = ModeloMgr.Instancia.DefDominioMgr.GetRegistros(falla.CodOrigen, falla.CodTipoDesconexion, falla.CodCausa);
            DataTable notificaciones = ModeloMgr.Instancia.NotificacionMgr.GetRegistros(falla.CodFalla.ToString());
            ds.Tables.Add(regFalla);
            ds.Tables.Add(dominios);
            ds.Tables.Add(notificaciones);
        }

        public void ExportarInformeFallaExistente(DataSet ds, string archivo)
        {
            try
            {
                ds.DataSetName = "Informe_Falla";
                ds.WriteXml(archivo);
                ComprimirArchivo(archivo);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("ExportarInformeFallaExistente()", ex);
            }
        }

        private bool ExportarNotificacion(RegFalla regFalla, string archivo)
        {
            bool rtn = false;
            try
            {
                string path = Path.Combine(Exportardor.EnsureExportFolder(), archivo);
                DataSet ds = ConsultarDatosNotificacion(regFalla);
                ds.DataSetName = "Notificacion_Falla";
                ds.WriteXml(path);
                ComprimirArchivo(path);
                rtn = true;
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("Exportador", ex);
            }
            return rtn;
        }

        private DataSet ConsultarDatosNotificacion(RegFalla falla)
        {
            DataSet resultado = new DataSet();
            DataTable regFalla = ModeloMgr.Instancia.RegFallaMgr.GetRegistros(falla.CodFalla.ToString());
            DataTable dominios = ModeloMgr.Instancia.DefDominioMgr.GetRegistros(falla.CodOrigen, falla.CodTipoDesconexion, falla.CodCausa);
            DataTable notificaciones = ModeloMgr.Instancia.NotificacionMgr.GetRegistros(falla.CodFalla.ToString());
            resultado.Tables.Add(regFalla);
            resultado.Tables.Add(dominios);
            resultado.Tables.Add(notificaciones);

            return resultado;
        }

        private void ComprimirArchivo(string archivo)
        {
            FileStream fs = new FileStream(archivo, FileMode.Open);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, b.Length);
            fs.Close();

            b = CodificarArchivo.codificar(b);
            b = GZip.Comprimir(b);

            using (FileStream fs1 = new FileStream(archivo + ".gz", FileMode.Create))
            {
                fs1.Write(b, 0, b.Length);
                fs1.Close();
            }
            if (File.Exists(archivo))
            {
                File.Delete(archivo);
            }
        }
    }
}