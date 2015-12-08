using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CNDC.BaseForms;
using CNDC.Pistas;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.IO;
using MenuQuantum;
using Oracle.DataAccess.Client;
using CNDC.BLL;
using System.Reflection;

namespace Reportes
{
    public partial class FormReporteBase : BaseForm, IFuncionalidad
    {
        private int _imagen = 2;
        private DataSet _ds; 
        private IProveedorDatos _provDatos;
        protected ReportDocument _docRpt;
        public FormReporteBase()
        {
            InitializeComponent();
        }

        private CrystalReportViewer GetCrystalReportViewer()
        {
            return _crViewer;
        }

        protected void AdicionarBoton(ToolStripButton btn)
        {
            _toolStrip.Items.Add(btn);
        }

        public bool CargarReporte(string rep, DataSet ds , bool blanco)
        {
            bool rtn = true;
            try
            {
                string rutaRep = Application.StartupPath + @"\Reportes\" + rep + @".rpt";
                string directorioEjecucion = Path.GetDirectoryName(Application.ExecutablePath);
                
                if (File.Exists(rutaRep))
                {
                    _docRpt = new ReportDocument();
                    _docRpt.Load(rutaRep);
                    if (ds != null)
                    {
                        _docRpt.SetDataSource(ds);
                    }

                    GetCrystalReportViewer().ReportSource = _docRpt;
                    GetCrystalReportViewer().EnableDrillDown = true;
                    GetCrystalReportViewer().ShowExportButton = true;
                    GetCrystalReportViewer().ShowGroupTreeButton = true;

                    //switch (_provDatos.GetTipoPanel())
                    //{
                    //    case TipoPanel.Ninguno:
                    //        GetCrystalReportViewer().ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                    //        break;
                    //    case TipoPanel.Parametros:
                    //        GetCrystalReportViewer().ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.ParameterPanel;
                    //        break;
                    //    case TipoPanel.Grupos:
                    //        GetCrystalReportViewer().ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree;
                    //        break;
                    //}

                    GetCrystalReportViewer().Refresh();
                    if (ds != null)
                    {
                        ds.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("RPT : El archivo '" + rutaRep.ToString() + "'  NO existe, favor copiarlo a la carpeta de Reportes ");
                    rtn = false;
                }
            }
            catch (Exception ex)
            {
                rtn = false;
                PistaMgr.Instance.Error("RepSisFalla", ex);
            }


            return rtn;
        }
        public  bool CargarReporte(string rep, DataSet ds)
        {
            bool rtn = true;
            try
            {
                string rutaRep = Application.StartupPath + @"\Reportes\" + rep + @".rpt";
                string directorioEjecucion = Path.GetDirectoryName(Application.ExecutablePath);
                CopiadorReportes.Instancia.Copiar(Path.Combine(directorioEjecucion, "Reportes"), _provDatos.GetResourceManager());

                if (File.Exists(rutaRep))
                {
                    _docRpt = new ReportDocument();
                    _docRpt.Load(rutaRep);
                    _docRpt.SetDataSource(ds);

                    GetCrystalReportViewer().ReportSource = _docRpt;
                    GetCrystalReportViewer().EnableDrillDown = true;
                    GetCrystalReportViewer().ShowExportButton = true;
                    GetCrystalReportViewer().ShowGroupTreeButton = true;

                    switch (_provDatos.GetTipoPanel())
                    {
                        case TipoPanel.Ninguno:
                            GetCrystalReportViewer().ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                            break;
                        case TipoPanel.Parametros:
                            GetCrystalReportViewer().ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.ParameterPanel;
                            break;
                        case TipoPanel.Grupos:
                            GetCrystalReportViewer().ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree;
                            break;
                    }

                    GetCrystalReportViewer().Refresh();
                    ds.Dispose();
                }
                else
                {
                    MessageBox.Show("RPT : El archivo '" + rutaRep.ToString() + "'  NO existe, favor copiarlo a la carpeta de Reportes ");
                    rtn = false;
                }
            }
            catch (Exception ex )
            {
                rtn = false;
                PistaMgr.Instance.Error("RepSisFalla", ex);             
            }

         
            return rtn ;
        }

        private void _btnExportarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreArchivo = string.Empty;
                SaveFileDialog sfDialog = new SaveFileDialog();
                sfDialog.InitialDirectory = "c:";
                sfDialog.Title = "Guardar Reporte PDF como";
                sfDialog.Filter = "Archivos PDF|*.pdf|Todos Archivos|*.*";
                sfDialog.FileName = "";
                if (sfDialog.ShowDialog() != DialogResult.Cancel)
                {
                    nombreArchivo = sfDialog.FileName;
                    ExportarPDF(nombreArchivo);
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("RepSisFalla", ex);
            }
        }

        public bool ExportarPDF(string nombreArchivo)
        {
            bool resultado = false;
            try
            {
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();

                CrDiskFileDestinationOptions.DiskFileName = nombreArchivo;
                CrExportOptions = _docRpt.ExportOptions;
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
                _docRpt.Export();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exportar : " + ex.Message);
                PistaMgr.Instance.Error("Reportes.ExportarPDF", ex);
            }
            return resultado;
        }

        private void _btnExportarXls_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreArchivo = string.Empty;
                SaveFileDialog sfDialog = new SaveFileDialog();
                sfDialog.InitialDirectory = "c:\\";
                sfDialog.Title = "Guardar Reporte XLS como";
                sfDialog.Filter = "Archivos XLS|*.xls|Todos Archivos|*.*";
                sfDialog.FileName = "";
                if (sfDialog.ShowDialog() != DialogResult.Cancel)
                {
                    nombreArchivo = sfDialog.FileName;
                    // Declarar variables y obtener las opciones de exportación.
                    ExportOptions exportOpts = new ExportOptions();
                    ExcelFormatOptions excelFormatOpts = new ExcelFormatOptions();
                    DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
                    exportOpts = _docRpt.ExportOptions;

                    // Establecer las opciones de formato de Excel.
                    excelFormatOpts.ExcelUseConstantColumnWidth = false;
                    exportOpts.ExportFormatType = ExportFormatType.Excel;
                    exportOpts.FormatOptions = excelFormatOpts;

                    // Establecer las opciones de archivo de disco y de exportación.
                    exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
                    diskOpts.DiskFileName = nombreArchivo;
                    exportOpts.DestinationOptions = diskOpts;

                    _docRpt.Export();
                    AbrirArchivo(sfDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exportar : " + ex.Message);
                PistaMgr.Instance.Error("Reportes.ExportarXLS", ex);
            }
        }

        private void _btnExportarCSV_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreArchivo = string.Empty;
                SaveFileDialog sfDialog = new SaveFileDialog();
                sfDialog.InitialDirectory = "c:\\";
                sfDialog.Title = "Guardar Reporte XLS como";
                sfDialog.Filter = "Archivos XLS|*.xls|Todos Archivos|*.*";
                sfDialog.FileName = "";
                if (sfDialog.ShowDialog() != DialogResult.Cancel)
                {
                    nombreArchivo = sfDialog.FileName;
                    // Declarar variables y obtener las opciones de exportación.
                    ExportOptions exportOpts = new ExportOptions();
                    //ExcelFormatOptions excelFormatOpts = new ExcelFormatOptions();
                    ExcelDataOnlyFormatOptions excelFormatOpts = new ExcelDataOnlyFormatOptions();
                    DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
                    exportOpts = _docRpt.ExportOptions;

                    // Establecer las opciones de formato de Excel.
                    excelFormatOpts.ExcelAreaType = AreaSectionKind.WholeReport;
                    excelFormatOpts.ExcelConstantColumnWidth = 180.0;
                    excelFormatOpts.ExportObjectFormatting = true;
                    excelFormatOpts.ExcelUseConstantColumnWidth = false;
                    excelFormatOpts.ExportPageHeaderAndPageFooter = true;
                    excelFormatOpts.MaintainColumnAlignment = false;
                    excelFormatOpts.MaintainRelativeObjectPosition = true;

                    exportOpts.ExportFormatType = ExportFormatType.ExcelRecord;
                    exportOpts.ExportFormatOptions = excelFormatOpts;
                    //exportOpts.FormatOptions = excelFormatOpts;

                    /*
                    CharacterSeparatedValuesFormatOptions csvOptions = new CharacterSeparatedValuesFormatOptions();
                    csvOptions.SeparatorText = ",";
                    csvOptions.Delimiter = "\'";
                    
                    exportOpts.ExportFormatType = ExportFormatType.CharacterSeparatedValues;
                    exportOpts.ExportFormatOptions = csvOptions;
                    */

                    // Establecer las opciones de archivo de disco y de exportación.
                    exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
                    diskOpts.DiskFileName = nombreArchivo;
                    exportOpts.DestinationOptions = diskOpts;

                    _docRpt.Export();
                    AbrirArchivo(sfDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exportar : " + ex.Message);
                PistaMgr.Instance.Error("Reportes.ExportarXLS", ex);
            }
        }

        protected void AbrirArchivo(string ruta)
        {
            try
            {
                System.Diagnostics.Process.Start(ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Abrir Archivo : " + ex.Message);
                PistaMgr.Instance.Error("Reportes", ex);
            }
        }

        private void _ImprimirDirecto_Click(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Printing.PrinterSettings oPS = new System.Drawing.Printing.PrinterSettings();
                _docRpt.PrintOptions.PrinterName = oPS.PrinterName;
                _docRpt.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("Reportes", ex);
                MessageBox.Show("Error al imprimir directamente. Se inicia la impresión estándar");
                GetCrystalReportViewer().PrintReport();
            }
        }

        private void _btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AsegurarImagen()
        {
            if (Parametros.ExiteParametro("imagen"))
            {
                _imagen = int.Parse(Parametros.GetParametro("imagen"));
            }
        }

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            try
            {
                AsegurarImagen();
                string assembly = Parametros.DiccionarioParametros["ASM_PROV_DATOS"];
                string clase = Parametros.DiccionarioParametros["CLASE_PROV_DATOS"];
                _provDatos = InstanciarProveedorDatos(assembly, clase);
                _provDatos.SetParametrosFuncionalidad(Parametros);
                _provDatos.SetParametroExtra(Parametros.ParametroExtra);
                _btnParametros.Visible = _provDatos.PuedeConfigurarParametros();
                RefrescarReporte();
               
                if (Parametros.ParametroExtra == null || Parametros.ParametroExtra.ModoVisible)
                {
                    Show();
                }
                else
                {
                    ExportarPDF(Parametros.ParametroExtra.NombreArchivoExportar);
                }
            }
            catch (Exception e)
            {
                PistaMgr.Instance.Error("Reportes", e);
                MessageBox.Show(e.ToString(), this.Text);
            }
            

        }

        private IProveedorDatos InstanciarProveedorDatos(string assembly, string clase)
        {
            Assembly asm = Assembly.LoadFile(System.IO.Path.Combine(Application.StartupPath, assembly));
            PistaMgr.Instance.Debug("MenuQuantum", "Instanciando Clase " + clase);
            IProveedorDatos resultado = (IProveedorDatos)asm.CreateInstance(clase);
            return resultado;
        }

        private bool GenerarReporte(string rep, string tit, int codReporte, string parametro)
        {
            bool resultado = true;
            string strSql = string.Empty;
            _ds = new DataSet();
            
            try
            {
                strSql = @"SELECT
                        '{0}' AS COD_REPORTE,
                        '{1}' AS ARCHIVO,
                        '' AS MENSAJE,
                        '{2}' AS TITULO_REPORTE,
                        P_IMAGENES_SISTEMA.ID AS COD_LOGO,
                        P_IMAGENES_SISTEMA.ARCHIVO AS ARCHIVO_LOGO
                        FROM P_IMAGENES_SISTEMA
                        WHERE P_IMAGENES_SISTEMA.ID = {3}";
                strSql = string.Format(strSql, codReporte, rep, tit, _imagen);
                OracleCommand cmd = CrearComando(strSql);
                DataTable tabla = EjecutarComando(cmd, "Superior");
                if(tabla.Rows.Count > 0)
                {
                    _ds.Tables.Add(tabla);
                    List<DataTable> tablas = _provDatos.GetDatos();
                    foreach (DataTable t in tablas)
                    {
                        _ds.Tables.Add(t);
                    }
                    
                    //_ds.WriteXmlSchema(@"c:\\DataSet1.xsd");
                    CargarReporte(rep, _ds);
                    CargarBotonesAdicionales();
                }
            }
            catch(Exception exc) 
            {
                PistaMgr.Instance.Error("Reportes", exc);
                resultado = false;
            }

            return resultado;
        }

        private void CargarBotonesAdicionales()
        {
            foreach (ToolStripButton b in _provDatos.GetBotonesAdicionales())
            {
                AdicionarBoton(b);
            }
        }

        private DataTable EjecutarComando(OracleCommand cmd, string nombreTabla)
        {
            DataTable resultado = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            resultado.TableName = nombreTabla;
            return resultado;
        }

        private OracleCommand CrearComando(string sql)
        {
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            return cmd;
        }

        private void _btnParametros_Click(object sender, EventArgs e)
        {
            if (_provDatos.ConfigurarParametros())
            {
                RefrescarReporte();
            }

        }

        private void RefrescarReporte()
        {
            GenerarReporte(Parametros.DiccionarioParametros["REPORTE"], Parametros.DiccionarioParametros["TITULO"],
                int.Parse(Parametros.DiccionarioParametros["CODREPORTE"]),
                Parametros.DiccionarioParametros["PARAM"]);

            Refresh();
        }
    }

    public interface IProveedorDatos
    {
        List<DataTable> GetDatos();
        TipoPanel GetTipoPanel();
        System.Resources.ResourceManager GetResourceManager();
        List<ToolStripButton> GetBotonesAdicionales();
        void SetParametroExtra(ParametroExtra p);
        void SetParametrosFuncionalidad(ParametrosFuncionalidad p);
        bool PuedeConfigurarParametros();
        bool ConfigurarParametros();
    }    

    public enum TipoPanel
    {
        Ninguno,
        Parametros,
        Grupos
    }
}
