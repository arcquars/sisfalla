using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.UtilesComunes;
using System.Data;

namespace MC
{
    public class RegistroLectura
    {
        private string _hora;
        public DateTime Fecha { get; set; }
        private List<ItemRegistro> _items;
        private List<DataRow> _rowsItems;
        public bool MarcadoParaBorrar { get; set; }
        public RegistroLectura()
        {
            _items = new List<ItemRegistro>();
            _rowsItems = new List<DataRow>();
        }
        public string Hora
        {
            get { return _hora; }
            set
            {
                if (value == null)
                {
                    _hora = value;

                }
                else
                {
                    _hora = value.Substring(0, 5);
                }
            }
        }

        public List<DataRow> RowsItems
        { get { return _rowsItems; } }

        public static RegistroLectura GetRegistroLectura(DateTime fecha, TimeSpan hora, bool modificarFecha)
        {
            RegistroLectura reg = new RegistroLectura();
            reg.Fecha = fecha.Date.Add(hora);
            reg.Hora = hora.ToString();
            if (hora.TotalDays == 0)
            {
                if (modificarFecha)
                {
                    reg.Fecha = reg.Fecha.AddDays(-1);
                }
                reg.Hora = "24:00";
            }
            return reg;
        }
        public static RegistroLectura GetRegistroLectura(DateTime fecha, TimeSpan hora)
        {
            return GetRegistroLectura(fecha, hora, true);
        }

        public void AdicionarItem(ItemRegistro item)
        {
            _items.Add(item);
        }

        public void AdicionarItem(long codInfCanal, double? valor)
        {
            ItemRegistro item = new ItemRegistro();
            item.CodMagnitud = codInfCanal;
            item.Valor = valor == null ? valor : Math.Round(valor.Value, 4);
            AdicionarItem(item);
        }

        public void AdicionarRow(DataRow r)
        {
            if (!_rowsItems.Contains(r))
            {
                _rowsItems.Add(r);
            }
        }

        public bool Igual(RegistroLectura registroLectura)
        {
            bool resultado = true;
            if (registroLectura._items.Count == _items.Count)
            {
                var metodo = new Comparison<ItemRegistro>((x, y) => { return (int)(x.CodMagnitud - y.CodMagnitud); });
                this._items.Sort(metodo);
                registroLectura._items.Sort(metodo);
                for (int i = 0; i < _items.Count; i++)
                {
                    if (_items[i].CodMagnitud != registroLectura._items[i].CodMagnitud || _items[i].Valor != registroLectura._items[i].Valor)
                    {
                        resultado = false;
                        break;
                    }
                }
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }
    }    

    public class ItemRegistro
    {
        public long CodMagnitud { get; set; }
        public double? Valor { get; set; }
    }
}
