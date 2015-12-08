using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using MC;

namespace LecturaArchivos
{
    public class LectorCSV_Jemread : ILector
    {
        public override ResultadoLectura Leer(string archivo, ParametrosLectura param)
        {
            ResultadoLectura resultado = new ResultadoLectura();
            DataTable tabla = new CreadorTablaLectura().CrearTabla();
            StreamReader reader = new StreamReader(archivo);

            for (int i = 0; i < 5; i++)
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

        private void Procesar(ParametrosLectura param, DataTable tabla, string linea, ResultadoLectura resultado)
        {
            try
            {
                string[] datos = linea.Split(',');
                UtilitarioLectura.LimpiarComillas(datos);
                if (datos.Length > 5 && !string.IsNullOrEmpty(datos[0].Trim()))
                {
                    DateTime fecha = DateTime.ParseExact(datos[2], "MM-dd-yy", System.Threading.Thread.CurrentThread.CurrentCulture);
                    TimeSpan hora = TimeSpan.Parse(datos[3]);
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
                int i = 0;
            }
        }
    }
}
