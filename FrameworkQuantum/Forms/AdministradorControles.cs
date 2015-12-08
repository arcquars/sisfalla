using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms ;
using OraDalQuantum;
namespace ModeloQuantum
{
  
   public class AdministradorControles
    {
        #region Singleton
        private static AdministradorControles _intance;
        public static AdministradorControles Instance
        {
            get
            {
                if (_intance == null)
                {
                    _intance = new AdministradorControles();
                }
                return _intance;
            }
        }

        private AdministradorControles()
        { 
        }
        #endregion Singleton
        public void DefinirConfiguracionControl(string form, Control control, string tablaCampoDb)
        {
            OraDalComponenteConfigurador.Instance.GetConfiguracionControl(form, control, tablaCampoDb);
        }
    }
}
