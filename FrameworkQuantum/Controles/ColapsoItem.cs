using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCLabelCombo), "ColapsoItem")]
    public partial class ColapsoItem : UserControl
    {

        private int _valor = -1;

            public int Valor {
            get {return _valor;}
            set {_valor = value ;}}

            public void SetDisable()
            {
                cndcCheckBox1.Checked = true;
                cndcCheckBox1.Checked = false ;
            }
        public ColapsoItem()
        {
            InitializeComponent();
          
        }
        public String Texto 
        {
            get {
                return label1.Text;
                
            }
        set {

            label1.Text = value;
      }
        }

        private void cndcCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            cndcRadioButton1.Enabled = cndcCheckBox1.Checked;
            cndcRadioButton2.Enabled = cndcCheckBox1.Checked;
            label1.Enabled = cndcCheckBox1.Checked;
            if ((!cndcRadioButton1.Checked ) && ( !cndcRadioButton2.Checked ))
            {
                cndcRadioButton1.Checked = true;

            }
        }
    }
}
