using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using CNDC.UtilesComunes;



namespace DifusionInformacion
{
    class UtilExcel
    {
        static Excel.Application xlApp;
        static Excel.Workbook xlWorkBook;
        static Excel.Worksheet xlWorkSheet;
        public UtilExcel()
        {

        }
        public static List<detallePublicado> GenerarXlsHojaPublica(Archivo archivo, string ruta)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            string archivoDetalle = Path.GetFileName(UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
            if (File.Exists(UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.nombreArchivo + archivo.extensionArchivo))))
            {
                AbrirArchivoXls(UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.nombreArchivo + archivo.extensionArchivo)));
                resultado.Add(GenerarHojaXls(archivo.hojaContenido, UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.archivoGenerado + archivo.extensionArchivo))));
                CerrarArchivo();
            }
            else
            {
                resultado.Add(new detallePublicado(archivoDetalle, "Local", "Falla : No se encuentra el archivo en la direccion Local"));
            }
            return resultado;
           
        }
        public static List<detallePublicado> GenerarHtmHojaPublica(Archivo archivo, string ruta)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            string archivoDetalle = Path.GetFileName(UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
            if (File.Exists(UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.nombreArchivo + archivo.extensionArchivo))))
            {
                
                AbrirArchivoXls(UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.nombreArchivo + archivo.extensionArchivo)));
                resultado = GenerarXlsHojaHtmZip(archivo.hojaContenido, UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.archivoGenerado + archivo.extensionArchivo)), archivo.rangoHoja);
                CerrarArchivo();
            }
            else
            {
                resultado.Add(new detallePublicado(archivoDetalle, "Local", "Falla : No se encuentra el archivo en la direccion Local " + Path.Combine(ruta, archivo.nombreArchivo + archivo.extensionArchivo)));
            }
            return resultado;
        }
        private static void copiarValoresHoja(string hoja)
        {
            try
            {
                //((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).Select();
                //((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).get_Range("A1").Select();
                ((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).Select();
                ((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).Cells.Copy(Missing.Value);
                //((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).UsedRange.Copy(Missing.Value);
                ((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).get_Range("A1").Select();
                ((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).Cells.PasteSpecial(Excel.XlPasteType.xlPasteValues,
                Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hoja Excel - " + hoja + " : " + ex.Message);
            }
    
        }
        private static detallePublicado GenerarHojaXls(string hoja, string archivoDestino)
        {
            
            try
            {
                copiarValoresHoja(hoja);
                ((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).Select();
                ((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).get_Range("A1").Select();
                ((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).Copy();

                ((Excel.Workbook)xlWorkBook.Application.ActiveWorkbook).SaveCopyAs(archivoDestino);
                
                return new detallePublicado(Path.GetFileName(archivoDestino), "Local", "OK");
            }
            catch (Exception ex)
            {
                return new detallePublicado(Path.GetFileName(archivoDestino), "Local", "Fallo : No se pudo Generar el archivo");
            }
            
        }
        private static List<detallePublicado> GenerarXlsHojaHtmZip(string hoja, string archivoDestino, string rango)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            //copiarValoresHoja(hoja);

            Excel.Range xlSourceRange = ((Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja]).get_Range("E1","F1");
            Excel.Hyperlink enlace = (Excel.Hyperlink)xlSourceRange.Hyperlinks.Add(xlSourceRange, Path.GetFileNameWithoutExtension(archivoDestino) + ".zip", Type.Missing, Type.Missing, "Descargar Archivo");

            ((Excel.Workbook)xlWorkBook.Application.ActiveWorkbook).PublishObjects.Add(Excel.XlSourceType.xlSourceRange,
            Path.Combine(Path.GetDirectoryName(archivoDestino), Path.GetFileNameWithoutExtension(archivoDestino) + ".htm"), hoja, rango,
            Excel.XlHtmlType.xlHtmlStatic, "1-10225", Type.Missing).Publish(true);
            if (File.Exists(Path.Combine(Path.GetDirectoryName(archivoDestino),Path.GetFileNameWithoutExtension(archivoDestino) + ".htm")))
            {
                resultado.Add(new detallePublicado( Path.GetFileNameWithoutExtension(archivoDestino) + ".htm","Local", "OK"));    
            }

            if (File.Exists(Path.Combine(Path.GetDirectoryName(archivoDestino), archivoDestino)))
            {
                UtilZip.CreaArchivoZip(Path.Combine(Path.GetDirectoryName(archivoDestino), archivoDestino), Path.Combine(Path.GetDirectoryName(archivoDestino), Path.GetFileNameWithoutExtension(archivoDestino) + ".zip"));
                if (File.Exists(Path.Combine(Path.GetDirectoryName(archivoDestino), Path.GetFileNameWithoutExtension(archivoDestino) + ".zip")))
                {
                    resultado.Add(new detallePublicado(Path.GetFileNameWithoutExtension(archivoDestino) + ".zip","Local","OK"));
                    //resultado.Add(new detallePublicado(Path.GetFileName(archivoDestino),"Local", "OK"));
                }
            }
            return resultado;
        }
        public static List<detallePublicado> ParsearHojaExcelCargaCurva(Archivo archivo, string ruta, List<ConfigCurvasAlerta> config)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            string archivoDetalle = Path.GetFileName(UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.archivoGenerado + archivo.extensionArchivoGenerado)));
            if (File.Exists(UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.archivoGenerado + archivo.extensionArchivo))))
            {
                AbrirArchivoXls(UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.archivoGenerado + archivo.extensionArchivo)));
                resultado.Add(ParsearValoresDeHoja(archivo.hojaContenido, UtilesExtraFecha.FormatearRutaArchivo(Path.Combine(ruta, archivo.archivoGenerado + archivo.extensionArchivo)), config));
                CerrarArchivo();
            }
            else
            {
                resultado.Add(new detallePublicado(archivoDetalle, "Local", "Falla : No se encuentra el archivo en la direccion Local"));
            }
            return resultado;

        }
        private static detallePublicado ParsearValoresDeHoja(string hoja, string archivoDestino, List<ConfigCurvasAlerta> config)
        {
            try
            {
                //OraDalSpectrumMgr mgr = new OraDalSpectrumMgr("USER ID=spectrum;DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.2.13)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME = orcl.cndc.bo)));PASSWORD=spectrum;PERSIST SECURITY INFO=true;");
                OraDalSpectrumMgr mgr = new OraDalSpectrumMgr(UtilPublicar.GetCadConexSpectrum());
                foreach (var item in config)
                {
                    mgr.Guardar(GetValores(GetFilaPorEtiqueta(item.NombreHoja, item.EtiquetaOrigen,item.ColumnaBuscar)),UtilesExtraFecha.GetFechaPublicable(), item.EtiquetaDestino);
                }
                mgr.FinalizarConexion();
                return new detallePublicado(Path.GetFileName(archivoDestino), "Carga Datos", "OK");
            }
            catch (Exception ex)
            {
                return new detallePublicado(Path.GetFileName(archivoDestino), "Carga Datos", "Fallo GetValores: No se pudo procesar el archivo");
            }
        }

        private void GuardarValores(List<double> list, ConfigCurvasAlerta item)
        {
            try
            {
                SpectumMgr(list, item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SpectumMgr(List<double> datos, ConfigCurvasAlerta config)
        {
            //OraDalSpectrumMgr mgr = new OraDalSpectrumMgr("USER ID=QUANTUM;DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.2.13)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=quantum)));PASSWORD=quantum;PERSIST SECURITY INFO=true;");
            //mgr.Guardar(datos,UtilesExtraFecha.GetFechaPublicable(),config.EtiquetaDestino);
        }

        private static List<double> GetValores(Array array)
        {
            List<double> resultado = new List<double>();
            if (array != null)
            {
                double aux;
                foreach (var item in array)
                {
                    if (item != null)
                    {
                        if (double.TryParse(item.ToString(), out aux))
                        {
                            resultado.Add(Math.Round(aux, 2));
                        }
                        else
                        {
                            resultado.Add(Math.Round(0.0, 2));
                        }
                    }
                    else
                    {
                        resultado.Add(Math.Round(0.0, 2));
                    }
                }
            }
            return resultado;
        }

        private static Array GetFilaPorEtiqueta(string hoja, string contenidoCelda, int columna)
        {
            Array reg = null;
            Excel.Worksheet hojaTrabajo = (Excel.Worksheet)xlWorkBook.Application.ActiveWorkbook.Sheets[hoja];
            hojaTrabajo.Select();
            Excel.Range rangoEncontrado = hojaTrabajo.Cells.Find(contenidoCelda, Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
            Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false, Type.Missing, Type.Missing);
            if (rangoEncontrado != null)
            {
                int lastUsedRow = rangoEncontrado.Row;
                int lastUsedColumn = rangoEncontrado.Column;
                if (rangoEncontrado.Column == columna)
                {
                    Excel.Range rng = (Excel.Range)hojaTrabajo.get_Range(hojaTrabajo.Cells[lastUsedRow, lastUsedColumn + 1], hojaTrabajo.Cells[lastUsedRow, lastUsedColumn + 24]);

                    reg = (Array)rng.Cells.Value2;
                }
            }
            return reg;
        }

        private static void CerrarArchivo()
        {
            xlWorkBook.Close(false, Type.Missing, Type.Missing);
            xlApp.Workbooks.Close();
            xlApp.Quit();
            if (xlWorkSheet != null)
            {
                ReleaseObject(xlWorkSheet);
                xlWorkSheet = null;
            }
            if (xlWorkBook != null)
            {
                ReleaseObject(xlWorkBook);
                xlWorkBook = null;
            }

            if (xlApp != null)
            {
                ReleaseObject(xlApp);
                xlApp = null;
            }
        }

        private static void AbrirArchivoXls(string nombreArchivo)
        {
            try
            {
                if (xlApp == null)
                {
                    xlApp = new Excel.Application();
                }
                    xlWorkBook = xlApp.Workbooks.Open(nombreArchivo, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
                    xlApp.Visible = false;
                    xlApp.DisplayAlerts = false;
                    xlApp.UserControl = false;
                    
                
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        private static void ReleaseObject(object obj)
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
                if (obj != null)
                {
                    GC.WaitForPendingFinalizers();
                    GC.SuppressFinalize(obj);
                    GC.Collect();
                }
            }
        }
    }

}
