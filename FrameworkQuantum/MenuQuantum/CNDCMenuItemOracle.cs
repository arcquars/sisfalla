using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MenuQuantum
{
    public partial class CNDCMenuItemOracle : ToolStripMenuItem
    {
        public string Ensamblado { get; set; }
        public string Clase { get; set; }
        public string Parametro { get; set; }
        public Decimal Icon { get; set; }

        public CNDCMenuItemOracle()
        {
            InitializeComponent();
        }

        public CNDCMenuItemOracle(string text, string ensamblado, string clase, string parametro, decimal icon, System.EventHandler onClick, Font font, bool SystemMenu)
            : base(text, null, onClick)
        {

            this.Font = font;
            this.Clase = clase;
            this.Parametro = parametro;
            this.Ensamblado = ensamblado;
            this.Icon = icon;

        }
    }

    public class NodoMenuPrincipal : TreeNode
    {
        public string Ensamblado { get; set; }
        public string Clase { get; set; }
        public string Parametro { get; set; }
        public Decimal Icon { get; set; }


        public NodoMenuPrincipal(string text, string ensamblado, string clase, string parametro, decimal icon, System.EventHandler onClick, Font font, bool SystemMenu)
        {
            Text = text;
            this.Clase = clase;
            this.Parametro = parametro;
            this.Ensamblado = ensamblado;
            this.Icon = icon;

        }
    }
}
