using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WcfServicioSISFALLA
{
    public class LogWcfServicioSisFalla
    {
        public static void GuardarLog(string msg)
        {
            try
            {
                StreamWriter w = new StreamWriter("c:\\WCFSISFALLA\\demo.txt", true);
                w.WriteLine(msg);
                w.Flush();
                w.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}