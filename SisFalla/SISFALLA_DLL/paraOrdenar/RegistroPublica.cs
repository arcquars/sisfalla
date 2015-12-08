using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SISFALLA
{
    public class RegistroPublica
    {
        public long idCategoria { get; set; }
        public string titulo { get; set; }
        public string archivo { get; set; }
        public string archivo_zip { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string fechadoc { get; set; }
        public int anio { get; set; }
        public string tabla { get; set; }
        public int num { get; set; }
        public bool esnuevo { get; set; }
        public RegistroPublica()
        {

        }
        public void llenar(DataRow dataRow)
        {
            idCategoria = (long)dataRow["idCategoria"];
            titulo = dataRow["titulo"].ToString();
            archivo = dataRow["archivo"].ToString();
            archivo_zip = dataRow["archivo_zip"].ToString();
            fecha = dataRow["fecha"].ToString();
            hora = dataRow["hora"].ToString();
            fechadoc = dataRow["fechadoc"].ToString();
            anio = (int)dataRow["anio"];
            num = (int)dataRow["num"];
        }
    }
}
