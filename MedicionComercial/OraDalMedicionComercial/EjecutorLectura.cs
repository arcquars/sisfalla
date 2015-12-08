using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using CNDC.Pistas;
using CNDC.UtilesComunes;
using BLL;
using CNDC.BLL;
using Ionic.Zip;
using System.Threading;

namespace MC
{
    public class EjecutorLectura : IDisposable
    {
        Dictionary<long, ILector> _lectores = new Dictionary<long, ILector>();
        FileSystemWatcher _watcher;
        Dictionary<string, DateTime> _archivos;
        DataTable _tablaResumenes;
        int _cantidadProcesados;
        public event EventHandler<ArchivoProcesadoEventArgs> ArchivoProcesado;
        DataTable _tablaPuntosMedicion;
        
        public int CantidadProcesados
        {
            get { return _cantidadProcesados; }
        }

        public void Iniciar()
        {
            if (_watcher == null)
            {
                CargarLectores();
                _cantidadProcesados = 0;
                string directorioLectura = P_GF_ParametrosMgr.Instancia.GetString("MC", "DIR_LECTURA");
                _watcher = new FileSystemWatcher(directorioLectura);
                _watcher.Created += new FileSystemEventHandler(_watcher_Created);
                _archivos = new Dictionary<string, DateTime>();
                _tablaResumenes = new TablaResumenLecturaMedidor();
                _watcher.EnableRaisingEvents = true;
            }
        }

        public DataTable TablaResumen
        {
            get { return _tablaResumenes; } 
        }

        void _watcher_Created(object sender, FileSystemEventArgs e)
        {
            Thread hilo = new Thread(new ParameterizedThreadStart(Procesar));
            hilo.Start(e.FullPath);
        }

        private void Procesar(object obj)
        {
            string fullPath = (string)obj;
            FileInfo fInfo = new FileInfo(fullPath);
            if (fInfo.Attributes == FileAttributes.Archive)
            {
                bool procesar = true;
                if (_archivos.ContainsKey(fullPath))
                {
                    procesar = (DateTime.Now - _archivos[fullPath]).TotalSeconds > 3;
                }

                if (procesar)
                {
                    if (fInfo.Extension.ToLower() == ".zip")
                    {
                        ProcesarZip(fullPath);
                    }
                    else
                    {
                        ProcesarArchivo(fullPath);
                    }
                }
            }
        }

        private void ProcesarZip(string archivoZip)
        {
            string directorioDestino = GetTempDirectory();
            Descompresor descompresor = new Descompresor();
            descompresor.DescompresionFinalizada += new EventHandler(descompresor_DescompresionFinalizada);
            descompresor.Descomprimir(archivoZip, directorioDestino);
        }

        void descompresor_DescompresionFinalizada(object sender, EventArgs e)
        {
            Descompresor d = sender as Descompresor;
            string[] archivos = Directory.GetFiles(d.Destino);
            foreach (string a in archivos)
            {
                ProcesarArchivo(a);
            }
        }

        private void ProcesarArchivo(string archivo)
        {
            MC_RPuntoMedicionFormato formato = null;
            ResumenLecturaMedidor resumen = null;
            GetFormatoLectura(archivo, out resumen, out formato);

            if (formato != null)
            {
                resumen.PkCodFormato = formato.FkCodFormato;
                resumen.ArchivoLectura = Path.GetFileName(archivo);
                if (_lectores.ContainsKey(resumen.PkCodFormato))
                {
                    ParametrosLectura parametros = new ParametrosLectura();
                    parametros.DetalleMagElec = OraDalMC_RPuntoMedicionFormatoDetalleMgr.Instancia.GetListaDefMagElec(formato.PkCodRptoMedFto);

                    try
                    {
                        ResultadoLectura res = _lectores[resumen.PkCodFormato].Leer(archivo, parametros);
                        AplicarMultiplicadores(res, parametros);
                        ValidadorLecturaMgr.Instancia.AplicarValidaciones(resumen, res, parametros, TipoValidador.Consistencia);
                        if (ValidadorLecturaMgr.Instancia.AplicarValidaciones(resumen, res, parametros, TipoValidador.Cargado))
                        {
                            Guardar(resumen, res, parametros);
                        }
                        resumen.RegistrosArchivo = res.Registros.Count;
                        if (res.Registros.Count > 0)
                        {
                            resumen.FechaHoraPrimerRegistro = res.Registros[0].Fecha.ToString("dd/MMM/yyyy") + " " + res.Registros[0].Hora;
                            resumen.FechaHoraUltimoRegistro = res.Registros[res.Registros.Count - 1].Fecha.ToString("dd/MMM/yyyy") + " " + res.Registros[res.Registros.Count - 1].Hora;
                        }
                        OnArchivoProcesado(resumen);
                    }
                    catch (Exception ex)
                    {
                        PistaMgr.Instance.Error("MC", ex);
                    }

                    _cantidadProcesados++;
                }
            }
        }

        private void Guardar(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros)
        {
            MC_LecturaDetalle.EliminarMarcadosParaBorrar(resumen, res, parametros);
            MC_LecturaDetalle.EliminarDuplicados(resumen, res, parametros);
            MC_LecturaDetalle.EliminarFueraDeIntervalo(resumen, res, parametros);
            MC_LecturaMgr.Instancia.Guardar(resumen, res, parametros);
        }

        private void OnArchivoProcesado(ResumenLecturaMedidor resumen)
        {
            if (ArchivoProcesado != null)
            {
                ArchivoProcesado(this, new ArchivoProcesadoEventArgs(resumen));
            }
        }

        private void GetFormatoLectura(string archivo, out ResumenLecturaMedidor resumenLectura, out MC_RPuntoMedicionFormato formato)
        {
            resumenLectura = null;
            formato = null;
            AsegurarTablaPuntosMedicion();
            foreach (DataRow row in _tablaPuntosMedicion.Rows)
            {
                if (formato == null)
                {
                    resumenLectura = (ResumenLecturaMedidor)_tablaResumenes.NewRow();
                    resumenLectura.LeerDatosMedidor(row);
                    DataTable formatosAsociados = OraDalMC_RPtoMedFtoMgr.Instancia.GetFormatos(resumenLectura.PkCodPuntoMedicion);
                    foreach (DataRow rf in formatosAsociados.Rows)
                    {
                        string nombreArchivoPrototipo = ObjetoDeNegocio.GetValor<string>(rf["NOMBRE_ARCHIVO"]);
                        nombreArchivoPrototipo = nombreArchivoPrototipo.ToLower();
                        string a = Path.GetFileName(archivo.ToLower());

                        if (a == nombreArchivoPrototipo)
                        {
                            formato = new MC_RPuntoMedicionFormato(rf);
                            break;
                        }
                        else if (nombreArchivoPrototipo.IndexOf('[') >= 0)
                        {
                            if (TienenMismoPatron(nombreArchivoPrototipo, a))
                            {
                                formato = new MC_RPuntoMedicionFormato(rf);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void AsegurarTablaPuntosMedicion()
        {
            if (_tablaPuntosMedicion == null)
            {
                _tablaPuntosMedicion = OraDalMC_PuntoMedicionMgr.Instancia.GetParaLectura(DateTime.Now.Date, DateTime.Now.Date, TipoPuntoMedicion.Real);//podria ser error
            }
        }

        private bool TienenMismoPatron(string nombreArchivoPrototipo, string a)
        {
            bool resultado = false;
            int idx1 = nombreArchivoPrototipo.IndexOf('[');
            int idx2 = nombreArchivoPrototipo.IndexOf(']');
            string inicio = nombreArchivoPrototipo.Substring(0, idx1);
            string fin = nombreArchivoPrototipo.Substring(idx2 + 1);
            resultado = a.StartsWith(inicio) && a.EndsWith(fin);
            return resultado;
        }

        public string GetTempDirectory()
        {
            string path = Path.GetRandomFileName();
            DirectoryInfo dInfo = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), path));
            return dInfo.FullName;
        }

        private void CargarLectores()
        {
            DataTable tablaFormatos = OraDalMC_FormatoLecturaMgr.Instancia.GetTabla();
            foreach (DataRow r in tablaFormatos.Rows)
            {
                _lectores[(long)r["pk_cod_fto"]] = Instanciador.Instancia.CrearInstancia<ILector>((string)r["dll_lector"], (string)r["clase_lector"]);
            }
        }

        private List<DateTime> GetListaFechas(DateTime desde, DateTime hasta)
        {
            List<DateTime> resultado = new List<DateTime>();
            for (DateTime i = desde; i <= hasta; i = i.AddDays(1))
            {
                resultado.Add(i);
            }
            return resultado;
        }

        private void AplicarMultiplicadores(ResultadoLectura res, ParametrosLectura parametros)
        {
            foreach (DataRow r in res.Tabla.Rows)
            {
                MC_RPuntoMedicionFormatoDetalle rmc = GetRMedidorCanal(parametros.DetalleMagElec, (long)r["CodInfCanal"]);
                r["Valor"] = (double)r["Valor"] * rmc.Kc * rmc.Kct * rmc.Kpt;
            }
        }

        private MC_RPuntoMedicionFormatoDetalle GetRMedidorCanal(List<MC_RPuntoMedicionFormatoDetalle> lista, long codInfCanal)
        {
            MC_RPuntoMedicionFormatoDetalle resultado = null;
            foreach (MC_RPuntoMedicionFormatoDetalle rmc in lista)
            {
                if (rmc.FkCodMagnitudElec == codInfCanal)
                {
                    resultado = rmc;
                    break;
                }
            }
            return resultado;
        }

        public void Dispose()
        {
            _watcher.EnableRaisingEvents = false;
            _watcher = null;
        }
    }

    public class ResultadoPreparacionLectura
    {
        public List<ResumenLecturaMedidor> ListaResumenLectura { get; set; }
        public int ArchivosEsperados { get; set; }
        public int ArchivosEncontrados { get; set; }
    }

    public class ArchivoProcesadoEventArgs:EventArgs
    {
        private ResumenLecturaMedidor _resumen;
        public ArchivoProcesadoEventArgs(ResumenLecturaMedidor r)
        {
            _resumen = r;
        }

        public ResumenLecturaMedidor Resumen
        { get { return _resumen; } }
    }
}