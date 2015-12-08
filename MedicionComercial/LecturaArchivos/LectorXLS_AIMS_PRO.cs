using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC;
using System.Globalization;

namespace LecturaArchivos
{
    public class LectorXLS_AIMS_PRO : ILector
    {
        private static Dictionary<string, int> _meses;
        static LectorXLS_AIMS_PRO()
        {
            _meses = new Dictionary<string, int>();
            _meses["ENE"] = 1;
            _meses["FEB"] = 2;
            _meses["MAR"] = 3;
            _meses["ABR"] = 4;
            _meses["MAY"] = 5;
            _meses["JUN"] = 6;
            _meses["JUL"] = 7;
            _meses["AGO"] = 8;
            _meses["SEP"] = 9;
            _meses["OCT"] = 10;
            _meses["NOV"] = 11;
            _meses["DIC"] = 12;
            _meses["JAN"] = 1;
            _meses["FEB"] = 2;
            _meses["MAR"] = 3;
            _meses["APR"] = 4;
            _meses["MAY"] = 5;
            _meses["JUN"] = 6;
            _meses["JUL"] = 7;
            _meses["AUG"] = 8;
            _meses["SEP"] = 9;
            _meses["OCT"] = 10;
            _meses["NOV"] = 11;
            _meses["DEC"] = 12;
            _meses["ENERO"] = 1;
            _meses["FEBRERO"] = 2;
            _meses["MARZO"] = 3;
            _meses["ABRIL"] = 4;
            _meses["MAYO"] = 5;
            _meses["JUNIO"] = 6;
            _meses["JULIO"] = 7;
            _meses["AGOSTO"] = 8;
            _meses["SEPTIEMBRE"] = 9;
            _meses["OCTUBRE"] = 10;
            _meses["NOVIEMBRE"] = 11;
            _meses["DICIEMBRE"] = 12;
            _meses["JANUARY"] = 1;
            _meses["FEBRUARY"] = 2;
            _meses["MARCH"] = 3;
            _meses["APRIL"] = 4;
            _meses["MAY"] = 5;
            _meses["JUNE"] = 6;
            _meses["JULY"] = 7;
            _meses["AUGUST"] = 8;
            _meses["SEPTEMBER"] = 9;
            _meses["OCTOBER"] = 10;
            _meses["NOVEMBER"] = 11;
            _meses["DECEMBER"] = 12;
            _meses["01"] = 1;
            _meses["02"] = 2;
            _meses["03"] = 3;
            _meses["04"] = 4;
            _meses["05"] = 5;
            _meses["06"] = 6;
            _meses["07"] = 7;
            _meses["08"] = 8;
            _meses["09"] = 9;
            _meses["10"] = 10;
            _meses["11"] = 11;
            _meses["12"] = 12;
        }

        public override ResultadoLectura Leer(string archivo, ParametrosLectura param)
        {
            ResultadoLectura resultado = new ResultadoLectura();
            int hoja = 2;
            int filaInicio = 2;
            DataTable tabla = new CreadorTablaLectura().CrearTabla();
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(archivo, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
            while (hoja <= xlWorkBook.Worksheets.Count)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(hoja);
                hoja++;
                string vhoja = xlWorkSheet.Name.Trim();
                //string hora = DoubleToHora((double)(xlWorkSheet.Rows.Cells[2, 1] as Excel.Range).Value2);
                DateTime fecha = GetFecha(vhoja);
                bool continuar = true;
                int filaActual = filaInicio;
                while (continuar)
                {
                    if ((xlWorkSheet.Rows.Cells[filaActual, 1] as Excel.Range).Value2 == null)
                    {
                        continuar = false;
                    }
                    else
                    {
                        DateTime f1 = new DateTime(1900, 1, 1);
                        f1 = f1.AddDays(-2 + (double)(xlWorkSheet.Rows.Cells[filaActual, 1] as Excel.Range).Value2);
                        TimeSpan hora = f1.TimeOfDay;
                        RegistroLectura reg = RegistroLectura.GetRegistroLectura(fecha, hora, false);
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
                                row["Valor"] = (double)(xlWorkSheet.Rows.Cells[filaActual, numColumna + 1] as Excel.Range).Value2;
                                tabla.Rows.Add(row);

                                reg.AdicionarItem(r.FkCodMagnitudElec, (double)row["Valor"]);
                                reg.AdicionarRow(row);
                            }
                        }
                        filaActual++;
                    }
                }

                DestructorObjetosExcel.ReleaseObject(xlWorkSheet);
            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            DestructorObjetosExcel.ReleaseObject(xlWorkBook);
            DestructorObjetosExcel.ReleaseObject(xlApp);
            resultado.Tabla = tabla;
            
            return resultado;
        }

        private static DateTime GetFecha(string vhoja)
        {
            DateTime resultado = DateTime.Now.Date;
            if (vhoja.Contains("_"))
            {
                vhoja = vhoja.Replace(" ", string.Empty);
                string[] datos = vhoja.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                string vdia = datos[0];
                string vmes = datos[1].ToUpper();
                string vano = datos[2];
                int vnumes = _meses[vmes];
                resultado = new DateTime(int.Parse(vano), vnumes, int.Parse(vdia));
            }
            else
            {
                for (int j = DateTime.Now.Year - 1; j <= DateTime.Now.Year; j++)
                {
                    DateTime f = new DateTime(j, 1, 1);
                    for (int i = 0; i < 366; i++)
                    {
                        string fe = f.ToString("D", DateTimeFormatInfo.CurrentInfo);
                        if (fe.Contains(vhoja))
                        {
                            resultado = f;
                            j = DateTime.Now.Year + 1;
                            break;
                        }
                        f = f.AddDays(1);
                    }
                }
            }
            return resultado;
        }
    }
}
