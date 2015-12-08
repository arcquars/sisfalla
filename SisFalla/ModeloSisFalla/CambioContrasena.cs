using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModeloSisFalla
{
    public class CambioContrasena
    {
        
        public string nuevaContrasena{ get; set; }

        
    }
    
   public  interface iCambioContrasenaMgr
    {
        void CambiarContrasena(string nuevaContrasena);
        string ObtenerNombreDeUsuario();
    }
    
}
