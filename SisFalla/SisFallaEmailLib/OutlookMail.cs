using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisFallaEmailLib
{
    public class OutlookMail
    {
        private Microsoft.Office.Interop.Outlook.Application oApp;
        private Microsoft.Office.Interop.Outlook._NameSpace oNameSpace;
        private Microsoft.Office.Interop.Outlook.MAPIFolder oOutboxFolder;
        private string _cuenta;
        public OutlookMail()
        {
            
        }

        public bool IniciarSesion(string cuenta, string contrasena)
        {
            bool resultado = true;
            _cuenta = cuenta;
            try
            {
                //Return a reference to the MAPI layer
                oApp = new Microsoft.Office.Interop.Outlook.Application();
                oNameSpace = oApp.GetNamespace("MAPI");

                /***********************************************************************
                    * Logs on the user
                    * Profile: Set to null if using the currently logged on user, or set 
                    *    to an empty string ("") if you wish to use the default Outlook Profile. 
                    * Password: Set to null if  using the currently logged on user, or set 
                    *    to an empty string ("") if you wish to use the default Outlook Profile
                    *    password. 
                    * ShowDialog: Set to True to display the Outlook Profile dialog box. 
                    * NewSession: Set to True to start a new session. Set to False to 
                    *    use the current session. 
                    ***********************************************************************/
                oNameSpace.Logon(_cuenta, contrasena, false, true);

                //gets defaultfolder for my Outlook Outbox
                oOutboxFolder = oNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderOutbox);
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// Adds an email to MS Outlook Outbox
        /// </summary>
        /// <param name="toValue">Email address of recipient</param>
        /// <param name="asunto">Email subject</param>
        /// <param name="cuerpo">Email body</param>
        public void addToOutBox(string toValue, string asunto, string cuerpo, List<string> archivosAdjuntos)
        {
            //creates a new MailItem object
            Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            oMailItem.To = toValue;
            oMailItem.Subject = asunto;
            oMailItem.HTMLBody = cuerpo;
            
            foreach (string adjunto in archivosAdjuntos)
            {
                oMailItem.Attachments.Add(adjunto);
            }
            //oMailItem.SaveSentMessageFolder = oOutboxFolder;

            Microsoft.Office.Interop.Outlook.Accounts accounts = oApp.Session.Accounts;

            foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
            {
                string address = account.SmtpAddress;
                if (address == _cuenta)
                {
                    oMailItem.SendUsingAccount = account;
                }
            }

            //uncomment this to also save this in your draft
            //oMailItem.Save();

            //adds it to the outbox
            oMailItem.Send();
        }
    }
}
