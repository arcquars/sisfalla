using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace GeneradorEnumsDominio
{
    class GeneradorEnum
    {
        Dictionary<string, Dictionary<string, long>> valores = new Dictionary<string, Dictionary<string, long>>();

        public void CargarDatos(DataTable tabla)
        {
            string codTipo = string.Empty;
            foreach (DataRow row in tabla.Rows)
            {
                codTipo = (string)row["D_COD_TIPO"];
                Asegurar(codTipo);
                valores[codTipo][(string)row["DESCRIPCION_DOMINIO"]] = (long)row["COD_DOMINIO"];
            }
        }

        private void Asegurar(string codTipo)
        {
            if (!valores.ContainsKey(codTipo))
            {
                valores[codTipo] = new Dictionary<string, long>();
            }
        }

        public void CrearEnums(string espacioDeNombre, string nombreArchivo)
        {
            StreamWriter w = new StreamWriter(nombreArchivo);
            w.WriteLine("using System;");
            w.WriteLine("using System.Collections.Generic;");
            w.WriteLine("using System.Text;");
            w.WriteLine("");
            w.WriteLine("//Codigo generado por Utilitario CNDC");
            w.WriteLine("namespace "+espacioDeNombre);
            w.WriteLine("{");
            w.WriteLine("");

            w.WriteLine("public class Dominios");
            w.WriteLine("{");
            foreach (var item in valores.Keys)
            {
                w.WriteLine("public const string " + item.Trim().Replace(' ', '_') + " = \"" + item + "\";");
            }
            w.WriteLine("}");
            w.WriteLine("");

            foreach (var item in valores)
            {
                w.WriteLine("public enum " + item.Key.Trim().Replace(' ', '_'));
                w.WriteLine("{");
                foreach (var valEnum in item.Value)
                {
                    w.WriteLine(valEnum.Key.Trim().Replace(' ', '_') + " = " + valEnum.Value + ",");
                }
                w.WriteLine("}");
                w.WriteLine("");
            }

            w.WriteLine("}");

            w.Flush();
            w.Close();
        }
    }
}
