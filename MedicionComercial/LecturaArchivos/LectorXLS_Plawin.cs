using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC;

namespace LecturaArchivos
{
    public class LectorXLS_Plawin : ILector
    {
        public override ResultadoLectura Leer(string archivo, ParametrosLectura param)
        {
            ResultadoLectura resultado = new ResultadoLectura();
            int hoja = 1;
            int filaInicio = 2;
            DataTable tabla = new CreadorTablaLectura().CrearTabla();
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(archivo, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(hoja);

            bool continuar = true;
            while (continuar)
            {
                if ((xlWorkSheet.Rows.Cells[filaInicio, 1] as Excel.Range).Value2 == null)
                {
                    continuar = false;
                }
                else
                {
                    DateTime f1 = new DateTime(1900, 1, 1);
                    DateTime fecha = f1.AddDays(-2 + (double)(xlWorkSheet.Rows.Cells[filaInicio, 1] as Excel.Range).Value2
                       + (double)(xlWorkSheet.Rows.Cells[filaInicio, 2] as Excel.Range).Value2);
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
                            string valorStr = (xlWorkSheet.Rows.Cells[filaInicio, numColumna + 1] as Excel.Range).Value2.ToString();
                            row["Valor"] = double.Parse(valorStr);
                            tabla.Rows.Add(row);

                            reg.AdicionarItem(r.FkCodMagnitudElec, (double)row["Valor"]);
                            reg.AdicionarRow(row);
                        }
                    }
                    filaInicio++;
                }
            }

            DestructorObjetosExcel.ReleaseObject(xlWorkSheet);

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            DestructorObjetosExcel.ReleaseObject(xlWorkBook);
            DestructorObjetosExcel.ReleaseObject(xlApp);
            resultado.Tabla = tabla;
            return resultado;
        }
    }
}
