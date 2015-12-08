using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace QuantumUI
{
    class ActiveDirectoryAuthentication
    {
        public static bool ValidUserInDomanin(string username, string password)
        {
            bool isValid = false;
            string server = CNDC.Config.Config.Intance.Read("Configuracion/LDAPAuthentication/Server", "general", "address", ""); ;
            string DomainName = "CNDC";
            string Username = string.Empty;
            if (username.IndexOf("\\") > 0)
            {
                Username = username.Substring(username.IndexOf("\\")+1 );
                DomainName = username.Substring(0, username.IndexOf("\\")  );
            }


            int hToken = 2;
            bool ret = WinAPI.LogonUser(Username, DomainName, password, WinAPI.LOGON32_LOGON_NETWORK,
            WinAPI.LOGON32_PROVIDER_DEFAULT,
            out hToken);

            if (ret == true)
            {
                isValid = true;
                WinAPI.CloseHandle(hToken);
            }
            else
            {
                isValid = false ;
            }

            return isValid;
        }
    }
}
