using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using MC;
using CNDC.Pistas;

namespace LecturaArchivos
{
    public class LectorCSV_ION_SETUP_v2 : ILector
    {
        public override ResultadoLectura Leer(string archivo, ParametrosLectura param)
        {
            ResultadoLectura resultado = new ResultadoLectura();
            DataTable tabla = new CreadorTablaLectura().CrearTabla();
            StreamReader reader = new StreamReader(archivo);
            try
            {
                for (int i = 0; i < 1; i++)
                {
                    reader.ReadLine();
                }

                while (!reader.EndOfStream)
                {
                    string linea = reader.ReadLine().Trim();
                    try
                    {                        
                        Procesar(param, tabla, linea,resultado);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("LecturaArchivos", ex);
            }
            finally
            {
                reader.Close();
            }

            resultado.Tabla = tabla;
            return resultado;
        }

        private void Procesar(ParametrosLectura param, DataTable tabla, string linea, ResultadoLectura resultado)
        {
            if (string.IsNullOrEmpty(linea))
            {
                return;
            }

            string[] datos = linea.Split(',');
            UtilitarioLectura.LimpiarComillas(datos);
            DateTime fecha = GetFecha(datos[0]);
            TimeSpan hora = fecha.TimeOfDay;

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

        private DateTime GetFecha(string p)
        {
            DateTime resultado = DateTime.Now.Date;
            string[] formatosFecha = new string[] { "dd/MM/yyyy HH:mm", "d/M/yyyy H:mm:ss.fff tt", "dd/MM/yyyy HH:mm:ss.fff", "dd/MM/yyyy H:mm:ssfff" };

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
