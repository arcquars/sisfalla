﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MC;
using System.Data;
using System.IO;

namespace LecturaArchivos
{
    public class LectorPRN_PCMAP_v431 : ILector
    {
        public override ResultadoLectura Leer(string archivo, ParametrosLectura param)
        {
            ResultadoLectura resultado = new ResultadoLectura();
            DataTable tabla = new CreadorTablaLectura().CrearTabla();
            StreamReader reader = new StreamReader(archivo);

            for (int i = 0; i < 13; i++)
            {
                reader.ReadLine();
            }

            DateTime? fecha = null;

            while (!reader.EndOfStream)
            {
                string linea = reader.ReadLine();
                fecha = Procesar(param, tabla, fecha, linea, resultado);
            }

            reader.Close();
            resultado.Tabla = tabla;
            return resultado;
        }

        private DateTime? Procesar(ParametrosLectura param, DataTable tabla, DateTime? fecha, string linea,ResultadoLectura resultado)
        {
            try
            {
                string[] datos = linea.Split(',');
                UtilitarioLectura.LimpiarComillas(datos);
                if (datos.Length > 5 && !string.IsNullOrEmpty(datos[0].Trim()))
                {
                    if (fecha == null)
                    {
                        fecha = DateTime.ParseExact(datos[0], "M/d/yy", System.Threading.Thread.CurrentThread.CurrentCulture);
                    }
                    TimeSpan hora = TimeSpan.Parse(datos[0].Substring(datos[0].Length - 5));
                    RegistroLectura reg = RegistroLectura.GetRegistroLectura(fecha.Value, hora);
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
            return fecha;
        }
    }
}
