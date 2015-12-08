using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace CNDCZedGraphLib
{
    public partial class CtrlZG : UserControl
    {
        public CtrlZG()
        {
            InitializeComponent();

            Configurar();
        }

        private void Configurar()
        {
            _zg.IsShowHScrollBar = true;
            _zg.IsShowVScrollBar = true;
            _zg.IsAutoScrollRange = true;
            _zg.IsScrollY2 = true;
            _zg.GraphPane.XAxis.MajorGrid.IsVisible = true;
            _zg.GraphPane.YAxis.MajorGrid.IsVisible = true;
        }

        public string Titulo
        {
            get { return _zg.GraphPane.Title.Text; }
            set { _zg.GraphPane.Title.Text = value; }
        }

        public string TituloX
        {
            get { return _zg.GraphPane.XAxis.Title.Text; }
            set { _zg.GraphPane.XAxis.Title.Text = value; }
        }

        public string TituloY
        {
            get { return _zg.GraphPane.YAxis.Title.Text; }
            set { _zg.GraphPane.YAxis.Title.Text = value; }
        }

        public void SetPuntos(List<PuntoZG> puntos, string leyenda)
        {
            PointPairList list = new PointPairList();
            double maximoY = 0;
            double maximoX = 0;
            foreach (PuntoZG p in puntos)
            {
                list.Add(p.X, p.Y);
                if (p.Y > maximoY)
                {
                    maximoY = p.Y;
                }

                if (p.X > maximoX)
                {
                    maximoX = p.X;
                }
            }
            LineItem myCurve = _zg.GraphPane.AddCurve(leyenda, list, Color.Blue, SymbolType.Diamond);
            myCurve.Symbol.Fill = new Fill(Color.White);

            _zg.GraphPane.YAxis.Scale.Min = 0;
            _zg.GraphPane.YAxis.Scale.Max = maximoY + maximoY * .1;

            _zg.GraphPane.XAxis.Scale.Min = 0;
            _zg.GraphPane.XAxis.Scale.Max = maximoX + maximoX * .1;

            _zg.AxisChange();
            _zg.Invalidate();
        }

        public void Limpiar()
        {
            _zg.GraphPane.CurveList.Clear();
        }
    }

    public class PuntoZG
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
