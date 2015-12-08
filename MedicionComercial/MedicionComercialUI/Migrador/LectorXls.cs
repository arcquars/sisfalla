using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ExcelLib
{
    public class LectorXls
    {
        public DataTable Leer(string archivo, int hoja, int filaInicio, int colInicio, int filaFin, int colFin)
        {
            DataTable resultado = new DataTable();
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(archivo, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(hoja);

            for (int j = colInicio; j <= colFin; j++)
            {
                Type t = null;
                if ((xlWorkSheet.Rows.Cells[filaInicio, j] as Excel.Range).Value2 == null)
                {
                    t = typeof(string);
                }
                else
                {
                    t = (xlWorkSheet.Rows.Cells[filaInicio, j] as Excel.Range).Value2.GetType();
                }

                DataColumn c = new DataColumn("col" + j, t);
                resultado.Columns.Add(c);
            }

            for (int i = filaInicio; i <= filaFin; i++)
            {
                DataRow r = resultado.NewRow();
                int idx = 0;
                for (int j = colInicio; j <= colFin; j++)
                {
                    r[idx] = (xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2 == null ? DBNull.Value : (xlWorkSheet.Rows.Cells[i, j] as Excel.Range).Value2;
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
    }
}
