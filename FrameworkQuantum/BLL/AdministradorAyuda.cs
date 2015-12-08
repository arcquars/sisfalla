using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.PluginComunicacionBase;
using CNDC.Pistas;

namespace CNDC.BLL
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
            if (ProveedorAyuda != null)
            {
                string tabla = nombreCampo.Substring(0, nombreCampo.LastIndexOf('.'));
                string campo = nombreCampo.Substring(nombreCampo.LastIndexOf('.') + 1);
                Asegurar(tabla, campo);
                if (_dicAyuda.ContainsKey(tabla) && _dicAyuda[tabla].ContainsKey(campo))
                {
                    result = _dicAyuda[tabla][campo];
                }
            }
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
                    Dictionary<string, string> comentarios = ProveedorAyuda.ObtenerAyudaPorNombreTabla(tabla);
                    foreach (var ayuda in comentarios)
                    {
                        columnComments.Add(ayuda.Key, ayuda.Value);
                    }
                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.Error("CNDC.BLL", ex);
                }
            }
        }
    }
}
