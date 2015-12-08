using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNDC.BaseForms
{
    public class AdministradorAyuda
    {
        #region Singleton
        private static AdministradorAyuda _intance;
        public static AdministradorAyuda Instance
        {
            get
            {
                if (_intance == null)
                {
                    _intance = new AdministradorAyuda();
                }
                return _intance;
            }
        }

        private AdministradorAyuda()
        { 
        }
        #endregion Singleton

        Dictionary<string, Dictionary<string, string>> _dicAyuda = new Dictionary<string, Dictionary<string, string>>();
        public IProveedorAyuda ProveedorAyuda { get; set; }
        public string ObtenerPorNombreCampo(string nombreCampo)
        {
            string result = string.Empty;
            string tabla = nombreCampo.Substring(0, nombreCampo.LastIndexOf('.'));
            string campo = nombreCampo.Substring(nombreCampo.LastIndexOf('.') + 1);
            Asegurar(tabla, campo);
            result = _dicAyuda[tabla][campo];
            return result;
        }

        private void Asegurar(string tabla, string campo)
        {
            if (!_dicAyuda.ContainsKey(tabla))
            {
                try
                {
                    Dictionary<string, string> columnComments = new Dictionary<string, string>();
                    _dicAyuda.Add(tabla, columnComments);
                    string[][] arregloAyuda = ProveedorAyuda.ObtenerAyudaPorNombreTabla(tabla);
                    foreach (var ayuda in arregloAyuda)
                    {
                        columnComments.Add(ayuda[0], ayuda[1]);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
