using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuQuantum
{
    public interface IFuncionalidad
    {
        ParametrosFuncionalidad Parametros { get; set; }
        void Ejecutar();
    }

    public class ParametrosFuncionalidad
    {
        public Dictionary<string, string> DiccionarioParametros { get; set; }
        public ParametroExtra ParametroExtra { get; set; }

        public ParametrosFuncionalidad()
        {
        }

        public ParametrosFuncionalidad(string parametros)
        {
            if (parametros == null)
            {
                parametros = string.Empty;
            }
            DiccionarioParametros = GetDiccionario(parametros);
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

        public bool ExiteParametro(string parametro)
        {
            return (DiccionarioParametros.ContainsKey(parametro.ToUpper().Trim()));
        }

        public string GetParametro(string parametro)
        {
            return (DiccionarioParametros[parametro.ToUpper().Trim()].ToUpper().Trim());
        }
    }

    public class ParametroExtra : EventArgs
    {
        public bool ModoVisible { get; set; }
        public string NombreArchivoExportar { get; set; }

        public ParametroExtra()
        {
            ModoVisible = true;
        }
    }
}
