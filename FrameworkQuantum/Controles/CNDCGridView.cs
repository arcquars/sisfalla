using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using BLL;

namespace Controles
{
    [ToolboxBitmap(typeof(CNDCGridView), "CNDCGridview")]
    public class CNDCGridView : DataGridView
    {
        public string TablaCampoBD { get; set; }
        public string NombreContenedor { get; set; }
        
        public CNDCGridView()
        {
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RowHeadersWidth = 25;            
            GridColor = Color.FromArgb(210, 232, 242);
            CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 251);
            RowTemplate.Height = 22;
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(114, 127, 178);
            CellBorderStyleChanged += new EventHandler(CNDCGridView_CellBorderStyleChanged);
            
        }

        void CNDCGridView_CellBorderStyleChanged(object sender, EventArgs e)
        {
            if (CellBorderStyle != DataGridViewCellBorderStyle.Single)
            {
                CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            }
        }

        public void AplicarEstilo()
        {
            CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
        }

        #region Para campos Numericos
        Type _tipoCeldaActual = null;
        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            base.OnEditingControlShowing(e);
            if (_tipoCeldaActual != null)
            {
                bool aplicar = false;
                List<Type> tiposNumericos = new List<Type>()
                { typeof(byte), typeof(short), typeof(int), typeof(long), 
                    typeof(float), typeof(double), typeof(decimal) 
                };

                foreach (Type t in tiposNumericos)
                {
                    if (_tipoCeldaActual.FullName == t.FullName)
                    {
                        aplicar = true;
                        break;
                    }
                }

                if (aplicar)
                {
                    string decimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    string groupSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator;
                    if (e.Control is TextBox)
                    {
                        (e.Control as TextBox).Text = (e.Control as TextBox).Text.Replace(groupSeparator, "");
                    }
                }
            }
        }

        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            _tipoCeldaActual = this.Columns[e.ColumnIndex].ValueType;
        }
        #endregion Para campos Numericos

        public void AsegurarColumnas()
        {
            AsegurarColumnas(true);
        }

        public void AsegurarColumnas(bool ultimaColRellena)
        {
            if (string.IsNullOrEmpty(NombreContenedor) || string.IsNullOrEmpty(this.Name))
            {
                return;
            }

            VisualizarColumnas(this, ColumnStyleManger.GetEstilos(NombreContenedor, this.Name),ultimaColRellena);
        }

        public static void VisualizarColumnas(DataGridView grid, List<EstiloColumna> columnas)
        {
            VisualizarColumnas(grid, columnas, true);
        }

        public static void VisualizarColumnas(DataGridView grid, List<EstiloColumna> columnas, bool ultimaColRellena)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].Visible = false;
            }

            int indice = 0;
            foreach (var item in columnas)
            {
                if (grid.Columns.Contains(item.NombreColumna))
                {
                    grid.Columns[item.NombreColumna].Visible = true;
                    grid.Columns[item.NombreColumna].DisplayIndex = indice;
                    
                    grid.Columns[item.NombreColumna].Width = item.Ancho;
                    grid.Columns[item.NombreColumna].HeaderText = item.TextoColumna;
                    grid.Columns[item.NombreColumna].DefaultCellStyle.Alignment = GetAligment(item.Alineacion);
                    if (!string.IsNullOrEmpty(item.Formato))
                    {
                        grid.Columns[item.NombreColumna].DefaultCellStyle.Format = item.Formato.Trim();
                    }
                    indice++;
                }
            }

            if (ultimaColRellena)
            {
               grid.Columns[columnas[columnas.Count - 1].NombreColumna].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private static DataGridViewContentAlignment GetAligment(AlineacionColumna alineacionColumna)
        {
            DataGridViewContentAlignment resultado = DataGridViewContentAlignment.MiddleLeft;
            switch (alineacionColumna)
            {
                case AlineacionColumna.Izq:
                    resultado = DataGridViewContentAlignment.MiddleLeft;
                    break;
                case AlineacionColumna.Der:
                    resultado = DataGridViewContentAlignment.MiddleRight;
                    break;
                case AlineacionColumna.Centro:
                    resultado = DataGridViewContentAlignment.MiddleCenter;
                    break;
            }
            return resultado;
        }
    }
}
