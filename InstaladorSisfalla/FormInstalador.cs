using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;

namespace InstaladorSisfalla
{
    public partial class FormInstalador : Form
    {
      public bool IsUserAdministrator()
      {
          bool isAdmin;
          try
          {
              WindowsIdentity user = WindowsIdentity.GetCurrent();
              WindowsPrincipal principal = new WindowsPrincipal(user);
              isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
          }
          catch (UnauthorizedAccessException ex)
          {   
              isAdmin = false;
          }
          catch (Exception ex)
          {
              isAdmin = false;
          }
          return isAdmin;
}


        public FormInstalador()
        {
            InitializeComponent();
            if (!IsUserAdministrator())
            {
                MessageBox.Show("Este programa se debe ejecutar como administrador");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
