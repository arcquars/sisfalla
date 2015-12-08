using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WF_ControlesTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cndcLabelCombo1.ComboBox.Items.Add("a");
            cndcLabelCombo1.ComboBox.Items.Add("b");
            cndcLabelCombo1.ComboBox.Items.Add("c");
            cndcLabelCombo1.ComboBox.Items.Add("d");
        }
    }
}
