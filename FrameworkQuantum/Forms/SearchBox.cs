using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CNDC.BaseForms
{
    public partial class SearchBox : UserControl
    {
        #region Fields

        private BindingSource bs;
        private ContextMenu contextMenu1;
        private DataGridView dgv;

        #endregion Fields

        #region Constructors

        public SearchBox()
        {
            InitializeComponent();
            this.contextMenu1 = new ContextMenu();
            this.pictureBox1.ContextMenu = this.contextMenu1;
            this.BackColor = this.textBox1.BackColor;
            this.textBox1.BackColor = Color.LightBlue;
            this.textBox1.LostFocus += new EventHandler(this.TextoLostFocus);
        }

        #endregion Constructors

        #region Methods

        public void LoadData(string[] Lista)
        {
            this.contextMenu1.MenuItems.Clear();
            MenuItem item = this.contextMenu1.MenuItems.Add("Todos", new EventHandler(this.todos_Click));
            item.Tag = ("TODOS");
            item.Checked = (false);
            string[] strArray = Lista;
            for (int i = 0; i < strArray.Length; i = (int)(i + 1))
            {
                string s = strArray[i];
                this.LoadItem(s, s);
            }
        }

        public void LoadData(DataGridView dg, BindingSource bss)
        {
            this.dgv = dg;
            this.bs = bss;
            this.contextMenu1.MenuItems.Clear();
            MenuItem item = this.contextMenu1.MenuItems.Add("Todos", new EventHandler(this.todos_Click));
            item.Tag = ("TODOS");
            item.Checked = (false);
            foreach (DataGridViewColumn column in this.dgv.Columns)
            {
                if (column.Visible && (column.ValueType.FullName == "System.String"))
                {
                    this.LoadItem(column.HeaderText, column.Name);
                }
            }
        }

        private void DoFilter()
        {
            string str = this.textBox1.Text.Trim();
            string expression = string.Concat((string[])new string[] { " like  '%", str, "%' or  " });
            string str2 = "";
            foreach (MenuItem item in this.contextMenu1.MenuItems)
            {
                if (item.Checked && (((string)item.Tag) != "TODOS"))
                {
                    str2 = string.Concat(new string[] { str2, (string)item.Tag, expression });
                }
            }
            if (str2.Length > 4)
            {
                str2 = str2.Substring(0, str2.Length - 5);
            }
            if (this.bs != null)
            {
                this.bs.Filter = (str2);
            }
        }

        private string GetColumnName(string header)
        {
            foreach (DataGridViewColumn column in this.dgv.Columns)
            {
                if (header == column.HeaderText)
                {
                    return column.Name;
                }
            }
            return "";
        }

        private void items_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            item.Checked = (!item.Checked);
            this.DoFilter();
        }

        private void LoadItem(string s, string tag)
        {
            MenuItem item = this.contextMenu1.MenuItems.Add(s, new EventHandler(this.items_Click));
            item.Tag = (tag);
            item.Checked = (false);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.contextMenu1.Show(this.pictureBox1, new Point(0, 20));
        }

        private void TextoLostFocus(object sender, EventArgs e)
        {
            this.DoFilter();
        }

        private void todos_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            item.Checked = (!item.Checked);
            foreach (MenuItem item2 in this.contextMenu1.MenuItems)
            {
                string str = (string)((string)item2.Tag);
                if (str != "TODOS")
                {
                    item2.Checked = (item.Checked);
                }
            }
            this.DoFilter();
        }

        #endregion Methods
    }
}