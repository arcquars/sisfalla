using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace InstaladorSisfalla
{
    class Instalado
    {
        public static bool Installed(out   Dictionary<string, string> Dictionary, string Programa)
        {
            bool encontrado = false;

            //Declare the string to hold the list:

            //The registry key:
            string SoftwareKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            Dictionary = new Dictionary<string, string>();


            string DisplayName = string.Empty;

            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {

                //Let's go through the registry keys and get the info we need:
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            //If the key has value, continue, if not, skip it:
                            if (!(sk.GetValue("DisplayName") == null))
                            {
                                DisplayName = ((string)sk.GetValue("DisplayName")).ToUpper();

                                if (DisplayName.IndexOf(Programa.ToUpper()) >= 0)
                                {
                                    string[] valueNames = sk.GetValueNames();
                                    foreach (string s in valueNames)
                                    {
                                        if (sk.GetValue(s) != null)
                                        {
                                            
                                            Dictionary.Add(s,  sk.GetValue(s).ToString ());
                                        }
                                    }
                                    encontrado = true;
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //No, that exception is not getting away... :P/>
                        }
                    }
                }
            }

            return encontrado;
        }

    }
}
