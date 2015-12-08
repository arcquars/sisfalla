using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using CNDC.BLL;

namespace Reportes
{
    class CopiadorReportes
    {
        #region Singleton
        private static CopiadorReportes _instancia;

        public static CopiadorReportes Instancia
        {
            get { return _instancia; }
        }

        private CopiadorReportes()
        {
        }

        static CopiadorReportes()
        {
            _instancia = new CopiadorReportes();
        }
        #endregion Singleton

        List<System.Resources.ResourceManager> _listaCopiados = new List<System.Resources.ResourceManager>();

        public void Copiar(string carpeta, System.Resources.ResourceManager rMgr)
        {
            if (_listaCopiados.Contains(rMgr))
            {
                return;
            }
            else
            {
                _listaCopiados.Add(rMgr);
            }

            List<string> listaReportes = GetListaReportes();
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }

            System.Resources.ResourceSet r = rMgr.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true);

            foreach (string nombreReporte in listaReportes)
            {
                string archivoReporte = Path.Combine(carpeta, nombreReporte + ".rpt");
                byte[] bytesReporte = (byte[])r.GetObject(nombreReporte);
                if (bytesReporte != null)
                {
                    if (File.Exists(archivoReporte))
                    {
                        File.Delete(archivoReporte);
                    }
                    File.WriteAllBytes(archivoReporte, bytesReporte);
                }
            }
        }

        private List<string> GetListaReportes()
        {
            List<string> resultado = new List<string>();
            string sql =
            @"SELECT NVL(parametro,' ') as parametro
            FROM f_au_opciones";
            DataTable tablaReportes = Sesion.Instancia.Conexion.EjecutarSql(sql);

            foreach (DataRow r in tablaReportes.Rows)
            {
                string dato = (string)r["parametro"];
                string reporte = GetReporte(dato);
                if (!string.IsNullOrEmpty(reporte))
                {
                    resultado.Add(reporte);
                }
            }
            return resultado;
        }

        private string GetReporte(string dato)
        {
            string resultado = string.Empty;
            Dictionary<string, string> dicParametros = GetDiccionario(dato);
            if (dicParametros.ContainsKey("REPORTE"))
            {
                resultado = dicParametros["REPORTE"];
            }
            return resultado;
        }

        private Dictionary<string, string> GetDiccionario(string p)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            string[] parametros = p.Split('|');
            foreach (var param in parametros)
            {
                string[] datos = param.Split('=');
                if (datos.Length == 2)
                {
                    resultado[datos[0].ToUpper().Trim()] = datos[1].Trim();
                }
            }
            return resultado;

        }
    }
}
