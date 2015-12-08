using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CNDC.UtilesComunes
{
    public class UtilesArchivo
    {
        public static string GetFileName(string path)
        {
            string rtn = string.Empty;

            FileInfo fionfo = new FileInfo(path);
            if (fionfo.Exists)
            {
                rtn = fionfo.Name;
            }

            return rtn;
        }
    }
}
