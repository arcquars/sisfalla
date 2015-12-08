using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CNDC.BLL
{
    public class Modulo : ObjetoDeNegocio
    {
        public long PkCodModulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CodEstado { get; set; }
        public long SecLog { get; set; }
        public string DllPlugin { get; set; }
        public string Clase { get; set; }

        public Modulo(DataRow r)
        {
            PkCodModulo = (int)GetValor<long>(r["pk_cod_modulo"]);
            Nombre = GetValor<string>(r["nombre"]);
            Descripcion = GetValor<string>(r["descripcion"]);
            CodEstado = GetValor<string>(r["d_cod_estado"]);
            SecLog = GetValor<long>(r["sec_log"]);
            DllPlugin = GetValor<string>(r["dll_plugin"]);
            Clase = GetValor<string>(r["clase"]);
        }
    }
}
