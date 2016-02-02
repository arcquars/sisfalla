using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MenuQuantum;
using System.Windows.Forms;
using CNDC.Pistas;
using System.IO;
using System.Data;
using ModeloSisFalla;
using CNDC.Sincronizacion;
using CNDC.BLL;
using OraDalSisFalla;
using CNDC.UtilesComunes;
using CNDC.DAL;
using CNDC.Dominios;

namespace SISFALLA
{
    public class Importador : IFuncionalidad
    {
        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            try
            {
                string archivo = ObtenerArchivo();
                if (!string.IsNullOrEmpty(archivo))
                {
                    DataSet ds = new DataSet();
                    ContenidoArchivo contenido = CargarDataSet(archivo, ds);
                    if (contenido == ContenidoArchivo.Informe)
                    { DataTable informe =null ;
                        if (ds.Tables.IndexOf ("F_GF_INFORMEFALLA")>=0)
                        {
                            informe = ds.Tables["F_GF_INFORMEFALLA"];
                             if (informe.Rows.Count>0)
                             {
                                 ds.Tables["F_GF_INFORMEFALLA"].Rows[0]["D_COD_ESTADO_INF"] = D_COD_ESTADO_INF.ENVIADO ;
                             }
                        }
                      
                    }
                    Importar(ds, contenido);
                    if (System.IO.File.Exists(@archivo))
                    {
                        System.IO.File.Delete(@archivo);
                    }
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("SisFalla", ex);
            }
        }

        private string ObtenerArchivo()
        {
            string resultado = string.Empty;
            OpenFileDialog dialogoAbrirArch = new OpenFileDialog();
            string path = CNDC.BLL.Sesion.Instancia.ConfigConexion.PathDefault;
            if (path != "")
            {
                dialogoAbrirArch.InitialDirectory = path;
            }
            else
            {
                dialogoAbrirArch.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            dialogoAbrirArch.Title = "Importar Registro desde archivo Comprimido";
            dialogoAbrirArch.Filter = "Archivos GZ|*.gz|Todos Archivos|*.*";
            dialogoAbrirArch.FileName = string.Empty;
            if (dialogoAbrirArch.ShowDialog() == DialogResult.OK)
            {
                resultado = dialogoAbrirArch.FileName;
                System.IO.FileInfo fInfo = new System.IO.FileInfo(dialogoAbrirArch.FileName);
                CNDC.BLL.Sesion.Instancia.ConfigConexion.PathDefault = fInfo.DirectoryName;

            }
            return resultado;
        }

        private ContenidoArchivo CargarDataSet(string nombreArchivo, DataSet auxDataSet)
        {
            ContenidoArchivo resultado = ContenidoArchivo.Informe;
            string archivoEsquema = nombreArchivo + ".sch";
            string archivoDescomprimido = nombreArchivo.Substring(0, nombreArchivo.Length - 3);
            DescomprimirArchivo(nombreArchivo);
            
            if (nombreArchivo.Contains("INFORMEFALLA_"))
            {
                resultado = ContenidoArchivo.Informe;
                consultarDatosInfFalla().WriteXmlSchema(archivoEsquema);
            }
            else
            {
                resultado = ContenidoArchivo.Notificacion;
                consultarDatosNotificacion().WriteXmlSchema(archivoEsquema);
            }

            auxDataSet.ReadXmlSchema(archivoEsquema);
            auxDataSet.ReadXml(archivoDescomprimido);
            
            if (File.Exists(archivoEsquema))
            {
                File.Delete(archivoEsquema);
            }

            if (File.Exists(archivoDescomprimido))
            {
                File.Delete(archivoDescomprimido);
            }

            return resultado;
        }

        public bool Importar(DataSet dts, ContenidoArchivo contenido)
        {
            return Importar(dts, contenido, false);
        }

        public bool Importar(DataSet dts, ContenidoArchivo contenido, bool silencioso)
        {
            bool actualizar = true;
            bool mensaje = !silencioso;
            List<IMgrLocal> managersLocal = new List<IMgrLocal>();
            
            if (contenido == ContenidoArchivo.Notificacion)
            {
                managersLocal.Add(ModeloMgr.Instancia.DefDominioMgr as IMgrLocal);
                managersLocal.Add(ModeloMgr.Instancia.RegFallaMgr as IMgrLocal);
                managersLocal.Add(ModeloMgr.Instancia.NotificacionMgr as IMgrLocal);
            }
            else
            {
                managersLocal.Add(ModeloMgr.Instancia.InformeFallaMgr as IMgrLocal);
                managersLocal.Add(ModeloMgr.Instancia.OperacionAlimentadorMgr as IMgrLocal);
                managersLocal.Add(ModeloMgr.Instancia.OperacionInterruptoresMgr as IMgrLocal);
                managersLocal.Add(ModeloMgr.Instancia.RelesOperadosMgr as IMgrLocal);
                managersLocal.Add(ModeloMgr.Instancia.RRegFallaComponenteMgr as IMgrLocal);
                managersLocal.Add(ModeloMgr.Instancia.TiempoDetalleMgr as IMgrLocal);
                managersLocal.Add(ModeloMgr.Instancia.AsignacionResposabilidadMgr as IMgrLocal);
                managersLocal.Add(ModeloMgr.Instancia.ColapsoMgr as IMgrLocal);
                managersLocal.Add(ModeloMgr.Instancia.AnalisisMgr as IMgrLocal);
            }

            try
            {
                foreach (var mgr in managersLocal)
                {
                    if (mgr != null && dts.Tables.Contains(mgr.NombreTabla))
                    {
                        DataTable tabla = dts.Tables[mgr.NombreTabla];
                        List<DataRow> rowsNuevos = new List<DataRow>();
                        List<DataRow> rowsAntiguos = new List<DataRow>();

                        foreach (DataRow row in tabla.Rows)
                        {
                            if (actualizar)
                            {
                                bool esNuevo = !mgr.Existe(mgr.NombreTabla, row);
                                if (esNuevo)
                                {
                                    rowsNuevos.Add(row);
                                }
                                else
                                {
                                    rowsAntiguos.Add(row);
                                }

                                if (!esNuevo && mensaje)// && Sesion.Instancia.RolSIN == "CNDC")
                                {
                                    DialogResult r = MessageBox.Show("El registro ya fue actualizado, desea solaparlo, posible inconsistencia en registros", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                    if (r == DialogResult.No)
                                    {
                                        actualizar = false;
                                    }
                                    mensaje = false;
                                }
                            }
                        }

                        if (actualizar)
                        {
                            if (rowsNuevos.Count > 0)
                            {
                                mgr.Insertar(rowsNuevos);
                            }

                            if (rowsAntiguos.Count > 0)
                            {
                                mgr.Actualizar(rowsAntiguos);
                            }
                        }
                    }
                }

                if (actualizar)
                {
                    if (contenido == ContenidoArchivo.Informe && Sesion.Instancia.EmpresaActual.PkCodPersona == 7)
                    {
                        DataTable tablaInforme = dts.Tables[InformeFalla.NOMBRE_TABLA];
                        InformeFalla informe = new InformeFalla(tablaInforme.Rows[0]);
                        DOMINIOS_OPERACION tipoOperacion = DOMINIOS_OPERACION.AGENTE_ENVIA_PRELIMINAR;

                        if (informe.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR)
                        {
                            tipoOperacion = DOMINIOS_OPERACION.MANUAL_AGENTE_ENVIA_PRELIMINAR;
                        }
                        else if (informe.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.FINAL)
                        {
                            tipoOperacion = DOMINIOS_OPERACION.MANUAL_AGENTE_ENVIA_FINAL ;
                        }

                        Operacion opn = new Operacion();
                        opn.RegistrarOperacion(tipoOperacion, informe.PkCodFalla, informe.PkOrigenInforme);
                        
                    }

                    if (!silencioso)
                    {
                        MessageBox.Show("Concluida satisfactoriamente", "Importacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("ImportarXML()", ex);
            }
            return actualizar;
        }

        private DataSet consultarDatosNotificacion()
        {
            DataSet ds = new DataSet();
            DataTable regFalla = Sesion.Instancia.Conexion.GetEsquema(RegFalla.NOMBRE_TABLA);
            DataTable dominios = Sesion.Instancia.Conexion.GetEsquema(DefDominio.NOMBRE_TABLA);
            DataTable notificaciones = Sesion.Instancia.Conexion.GetEsquema(Notificacion.NOMBRE_TABLA);
            ds.Tables.Add(regFalla);
            ds.Tables.Add(dominios);
            ds.Tables.Add(notificaciones);
            return ds;
        }

        private DataSet consultarDatosInfFalla()
        {
            DataSet ds = new DataSet();

            DataTable regFalla = Sesion.Instancia.Conexion.GetEsquema(RegFalla.NOMBRE_TABLA);
            DataTable dominios = Sesion.Instancia.Conexion.GetEsquema(DefDominio.NOMBRE_TABLA);
            DataTable notificaciones = Sesion.Instancia.Conexion.GetEsquema(Notificacion.NOMBRE_TABLA);
            DataTable informeFalla = Sesion.Instancia.Conexion.GetEsquema(InformeFalla.NOMBRE_TABLA);
            DataTable opAlimentador = Sesion.Instancia.Conexion.GetEsquema(OperacionAlimentador.NOMBRE_TABLA);
            DataTable opInterruptor = Sesion.Instancia.Conexion.GetEsquema(OperacionInterruptores.NOMBRE_TABLA);
            DataTable relesOper = Sesion.Instancia.Conexion.GetEsquema(RelesOperados.NOMBRE_TABLA);
            DataTable responsabilidad = Sesion.Instancia.Conexion.GetEsquema(AsignacionResposabilidad.NOMBRE_TABLA);
            DataTable regFallaCompo = Sesion.Instancia.Conexion.GetEsquema(RRegFallaComponente.NOMBRE_TABLA);
            DataTable tiempoDetalle = Sesion.Instancia.Conexion.GetEsquema(TiempoDetalle.NOMBRE_TABLA);
            DataTable analisis =  Sesion.Instancia.Conexion.GetEsquema(AnalisisFalla.NOMBRE_TABLA );
            ds.Tables.Add(regFalla);
            ds.Tables.Add(dominios);
            ds.Tables.Add(notificaciones);
            ds.Tables.Add(informeFalla);
            ds.Tables.Add(opAlimentador);
            ds.Tables.Add(opInterruptor);
            ds.Tables.Add(relesOper);
            ds.Tables.Add(responsabilidad);
            ds.Tables.Add(regFallaCompo);
            ds.Tables.Add(tiempoDetalle);
            ds.Tables.Add(analisis);

            return ds;
        }

        public void DescomprimirArchivo(string archivo)
        {
            string archi = archivo.Substring(0, archivo.Length - 3);
            byte[] buffer = File.ReadAllBytes(archivo);
            byte[] bufferzip = GZip.DesComprimir(buffer);
            byte[] bufferdecodec = CodificarArchivo.decodificar(bufferzip);
            File.WriteAllBytes(archi, bufferdecodec);
        }
    }

    public enum ContenidoArchivo
    {
        Notificacion,
        Informe
    }
}