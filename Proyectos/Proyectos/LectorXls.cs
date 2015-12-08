using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.UtilesComunes;

namespace Proyectos
{
    class LectorXls
    {
        bool _resultado = true;
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public DataTable LeerSeries(DataTable tabla, string archivo, int hoja, int filaInicio, int colInicio, int filaFin, int colFin)
        {
            DataTable resultado = tabla;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(archivo, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(hoja);

            for (int i = filaInicio; i <= filaFin; i++)
            {
                DataRow r = resultado.NewRow();
                int idx = 2;
                for (int j = colInicio; j <= colFin; j++)
                {
                    r[idx] = (xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2;
                    idx++;
                }
                resultado.Rows.Add(r);
            }

            ReleaseObject(xlWorkSheet);

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            ReleaseObject(xlWorkBook);
            ReleaseObject(xlApp);
            
            return resultado;
        }

        public DataTable LeerSeries(int adicionarInicio, DataTable tabla, string archivo, int hoja, int filaInicio, int colInicio, int filaFin, int colFin, int anioIncio, int anioFin)
        {
            DataTable resultado = tabla;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            _resultado = true;
            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(archivo, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
            int filaFinn = filaInicio + (anioFin - anioIncio);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(hoja);
            if (adicionarInicio == 0)
            {
                for (int i = filaInicio; i <= filaFin; i++)
                {
                    DataRow r = resultado.NewRow();
                    r[1] = anioIncio;
                    int idx = 2;
                    for (int j = colInicio; j <= colFin; j++)
                    {
                        if ((xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2 == null || !Utiles.EsDecimalPositivoYCero((xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2.ToString()))
                        {
                            _resultado = false;
                            break;
                        }
                        else
                        {
                            r[idx] = (xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2;
                            idx++;
                        }
                    }
                    if (_resultado)
                    {
                        resultado.Rows.Add(r);
                        anioIncio++;
                    }
                    else
                    { break; }
                }
            }
            if (adicionarInicio == 1)
            {
                for (int i = filaFin; i >= filaInicio; i--)
                {
                    DataRow r = resultado.NewRow();
                    r[1] = anioFin;
                    int idx = 2;
                    for (int j = colInicio; j <= colFin; j++)
                    {
                        if ((xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2 != null || Utiles.EsDecimalPositivoYCero((xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2.ToString()))
                        {
                            r[idx] = (xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2;
                            idx++;
                        }
                        else
                        {
                            _resultado = false;
                            break;
                        }
                    }
                    if (_resultado)
                    {
                        resultado.Rows.InsertAt(r, 0);
                        anioFin--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            ReleaseObject(xlWorkSheet);

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            ReleaseObject(xlWorkBook);
            ReleaseObject(xlApp);

            return resultado;
        }


       internal DataTable LeerSeriesParaModificacionDatos(DataTable tabla, string archivo, int hoja, int filaInicio, int colInicio, int filaFin, int colFin, int anioIncio, int anioFin)
       {
           DataTable resultado = tabla;
           Excel.Application xlApp;
           Excel.Workbook xlWorkBook;
           Excel.Worksheet xlWorkSheet;

           xlApp = new Excel.ApplicationClass();
           xlWorkBook = xlApp.Workbooks.Open(archivo, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
           int cantidadFilas = filaInicio + (anioFin - anioIncio);
           xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(hoja);
           for (int i = filaInicio; i <=filaFin; i++)
           {
               int idx = 2;
               int indiceTabla = ObtenerNumFilaDataRow(resultado, anioIncio);
               if (indiceTabla == -1)
               {
                   break;
               }
               else
               {
                   DataRow r = resultado.Rows[indiceTabla];

                   for (int j = colInicio; j <= colFin; j++)
                   {
                       if ((xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2 == null || !Utiles.EsDecimalPositivoYCero((xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2.ToString()))
                       {
                           _resultado = false;
                           break;
                       }
                       else
                       {
                           r[idx] = (xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2;
                           idx++;
                       }
                   }
                   if (_resultado)
                   {
                       anioIncio++;
                   }
                   else
                   {
                       break;
                   }
               }
           }

           ReleaseObject(xlWorkSheet);

           xlWorkBook.Close(true, null, null);
           xlApp.Quit();

           ReleaseObject(xlWorkBook);
           ReleaseObject(xlApp);

           return resultado;
       }

       public bool GetResultado()
       {
           return _resultado;
       }

       private int ObtenerNumFilaDataRow(DataTable tabla, int anioIncio)
       {
           int j = 0;
           bool res = false;
           for(int i=0; i< tabla.Rows.Count ; i++)
           {
               DataRow row= tabla.Rows[i];
               if (int.Parse(row[1].ToString()) == anioIncio)
               {
                   res = true;
                   break;
               }
               j++;
           }

           if (!res)
           {
               j = -1;
           }
           return j;
       }

       public List<string> GetNombresHojas(string archivo)
       {
           List<string> resultado = new List<string>();
           Excel.Application xlApp;
           Excel.Workbook xlWorkBook;
           Excel.Worksheet xlWorkSheet;

           xlApp = new Excel.ApplicationClass();
           xlWorkBook = xlApp.Workbooks.Open(archivo, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
           for (int i = 1; i <= xlWorkBook.Worksheets.Count; i++)
           {
               xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[i];
               resultado.Add(xlWorkSheet.Name);
               ReleaseObject(xlWorkSheet);
           }


           xlWorkBook.Close(true, null, null);
           xlApp.Quit();

           ReleaseObject(xlWorkBook);
           ReleaseObject(xlApp);

           return resultado;
       }
    }
}
