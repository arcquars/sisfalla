using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SISFALLA
{
    public class RegistroServidor
    {
        public long idCategoria { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string nombre_servidor { get; set; }
        public string direccion_servidor { get; set; }
        public string descripcion_categoria { get; set; }
        public string formato_nombre { get; set; }
        public string carpetaOrigen { get; set; }
        public string dirIntranet { get; set; }
        public string carpetaDestino { get; set; }
        public string tablaIntranet { get; set; }
        public long codIntranet { get; set; }
        public string nombreIntranet { get; set; }
        
        public RegistroServidor()
        {

        }
        public void llenaRegistro(DataRow row) 
        {
            idCategoria = (long)row[0];
            usuario = row[1].ToString();
            password = row[2].ToString();
            nombre_servidor = row[3].ToString();
            direccion_servidor = row[4].ToString();
            descripcion_categoria = row[5].ToString();
            formato_nombre = row[6].ToString();
            carpetaOrigen = row[7].ToString();
            dirIntranet = row[8].ToString();
            carpetaDestino = row[9].ToString();
            tablaIntranet = row[10].ToString();
            codIntranet = (long)row[11];
            nombreIntranet = row[12].ToString();
            
        }
    }
}
