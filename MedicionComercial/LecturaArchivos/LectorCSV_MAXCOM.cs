using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using MC;

namespace LecturaArchivos
{
    public class LectorCSV_MAXCOM : ILector
    {
        public override ResultadoLectura Leer(string archivo, ParametrosLectura param)
        {
            ResultadoLectura resultado = new ResultadoLectura();
            DataTable tabla = new CreadorTablaLectura().CrearTabla();
            StreamReader reader = new StreamReader(archivo);
            for (int i = 0; i < 1; i++)
            {
                reader.ReadLine();
            }

            while (!reader.EndOfStream)
            {
                string linea = reader.ReadLine();
                Procesar(param, tabla, linea, resultado);
            }

            reader.Close();
            resultado.Tabla = tabla;
            return resultado;
        }

        private void Procesar(ParametrosLectura param, DataTable tabla, string linea,ResultadoLectura resultado)
        {
            try
            {
                string[] datos = linea.Split(',');
                UtilitarioLectura.LimpiarComillas(datos);
                if (datos.Length > 5)
                {
                    DateTime fecha = GetFecha(datos[0]);
                    TimeSpan hora = TimeSpan.Parse(datos[1]);
                    RegistroLectura reg = RegistroLectura.GetRegistroLectura(fecha, hora);
                    resultado.Registros.Add(reg);
                    foreach (MC_RPuntoMedicionFormatoDetalle r in param.DetalleMagElec)
                    {
                        int numColumna = r.GetNumColumna();
                        if (numColumna >= 0)
                        {
                            DataRow row = tabla.NewRow();
                            row["Fecha"] = reg.Fecha.Date;//fecha.Date;
                            row["Hora"] = reg.Hora;//hora;
                            row["Canal"] = r.Canal;
                            row["CodInfCanal"] = r.FkCodMagnitudElec;
                            double? valor = GetDouble(datos[numColumna]);
                            if (valor == null)
                            {
                                row["Valor"] = System.DBNull.Value;
                            }
                            else
                            {
                                row["Valor"] = valor.Value;
                            }
                            tabla.Rows.Add(row);

                            reg.AdicionarItem(r.FkCodMagnitudElec, valor);
                            reg.AdicionarRow(row);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private DateTime GetFecha(string p)
        {
            DateTime resultado = DateTime.Now.Date;
            string[] formatosFecha = new string[] { "MM/dd/yy", "MM/dd/yyyy" };

            foreach (string f in formatosFecha)
            {
                try
                {
                    resultado = DateTime.ParseExact(p, f, System.Threading.Thread.CurrentThread.CurrentCulture);
                    break;
                }
                catch
                {
                }
            }

            return resultado;
        }
    }
}
