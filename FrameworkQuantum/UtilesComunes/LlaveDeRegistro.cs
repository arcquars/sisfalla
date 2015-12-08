using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace CNDC.UtilesComunes
{
    public class LlaveDeRegistro
    {
        public static string LeerValorDeRegistro(RegistryKey key, string subKey, string value)
        {
            string retValue = string.Empty;
            try
            {
                RegistryKey reg;
                reg = key.OpenSubKey(subKey);
                string stringValue = string.Empty;

                if (reg != null)
                {
                    retValue = reg.GetValue(value).ToString();
                }
            }
            catch (Exception e)
            { 
                //Logger.Error(e.ToString()); //TODO
            }

            return retValue;
        }

        public static void EscribirValorDeRegistro(RegistryKey key, string subKey, string valuename, string value)
        {
            RegistryKey reg;
            try
            {
                key.CreateSubKey(subKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                reg = key.OpenSubKey(subKey, true);
                string stringValue = string.Empty;

                if (reg != null)
                {
                    reg.SetValue(valuename, value);
                }
            }
            catch (Exception)
            {
                //Logger.Error(e.ToString());//TODO
            }
        }
    }
}
