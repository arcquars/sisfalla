using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CNDC.UtilesComunes
{
    public class ClipboardMgr
    {
        #region Singleton
        private static ClipboardMgr _instancia;
        public static ClipboardMgr Instancia
        {
            get { return _instancia; }
        }

        static ClipboardMgr()
        {
            _instancia = new ClipboardMgr();
        }

        private ClipboardMgr()
        {
        }
        #endregion Singleton

        public decimal[][] GetDatos(string datos)
        {
            decimal[][] resultado = null;
            int cantidadFilas = 0, cantidadColumnas = 0;
            string msg = DatosAPegarSonValidos(datos, ref cantidadFilas, ref cantidadColumnas);
            resultado = new decimal[cantidadFilas][];
            if (string.IsNullOrEmpty(msg))
            {
                string[] lineas = datos.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] d = lineas[i].Split('\t');
                    resultado[i] = new decimal[cantidadColumnas];
                    for (int j = 0; j < d.Length; j++)
                    {
                        resultado[i][j] = decimal.Parse(d[j]);
                    }
                }
            }
            else
            {
                throw new FormatException(msg);
            }
            return resultado;
        }

        private string DatosAPegarSonValidos(string datos,ref int cantidadFilas, ref int cantidadColumnas)
        {
            string resultado = string.Empty;
            string[] lineas = datos.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            cantidadFilas = lineas.Length;
            cantidadColumnas = 0;
            foreach (string linea in lineas)
            {
                string[] d = linea.Split('\t');
                bool validarDatos = true;
                if (cantidadColumnas == 0)
                {
                    cantidadColumnas = d.Length;
                }
                else if (cantidadColumnas == d.Length)
                {
                    
                }
                else
                {
                    resultado = "Datos inconsistentes.";
                    validarDatos = false;
                    break;
                }

                if (validarDatos)
                {
                    foreach (var item in d)
                    {
                        try
                        {
                            decimal.Parse(item);
                        }
                        catch (Exception)
                        {
                            resultado = "Datos no numéricos.";
                            break;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(resultado))
            {
                cantidadFilas = 0;
                cantidadColumnas = 0;
            }

            return resultado;
        }

        public void Copiar(DataTable tabla, int fila, int columna, decimal[][] datosNum)
        {
            for (int i = 0; i < datosNum.Length; i++)
            {
                for (int j = 0; j < datosNum[i].Length; j++)
                {
                    tabla.Rows[i + fila][j + columna] = datosNum[i][j];
                }
            }
        }
    }
}
