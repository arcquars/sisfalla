using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.BLL;
using BLL;
using CNDC.Pistas;
using CNDC.UtilesComunes;


namespace CNDC.Sincronizacion
{
    public class SincronizadorCliente
    {
        //TODO Usar Transaccion
        #region Singleton
        private static SincronizadorCliente _instancia;
        static SincronizadorCliente()
        {
            _instancia = new SincronizadorCliente();
        }
        public static SincronizadorCliente Instancia
        {
            get { return _instancia; }
        }

        private SincronizadorCliente()
        {

        }
        #endregion Singleton

        Dictionary<string, IMgrLocal> _managersLocal = new Dictionary<string, IMgrLocal>();
        public IMgrServidor MgrServidor { get; set; }
        public event EventHandler<SincEventArgs> Sincronizando;
        private bool _error = false;

        private List<SincronizadorRegistroFallas> listaActualizar;
        public List<SincronizadorRegistroFallas> Actualizar{get;set;}


        private void ConfirmarSincronizador(Dictionary<string, decimal> Local, Dictionary<string, decimal> Servidor)
        {
            Console.WriteLine("1 sssssssssssss:::::::::::::::::::::::::::::::::::::::: ");
            foreach (KeyValuePair<string,  decimal> pair  in Local)
            { 
                if (Servidor.ContainsKey(pair.Key))
                {
                    if (pair.Value > Servidor[pair.Key])
                    {
                        PistaMgr.Instance.Error("SincronizadorCliente", string.Format("El valor de Sicronización de la Tabla: {0}; en cliente mayor que el del servidor| Cliente:{1} - Servidor {2}", pair.Key, pair.Value, Servidor[pair.Key]));
                    }
                  

                }
                else
                {
                    PistaMgr.Instance.Error("SincronizadorCliente", string.Format("Servidor no tiene la Tabla: {0}", pair.Key));
                }
            }
        }

        private bool ValidarEstructuraTablas( AyudanteSincronizacion ayudante )
        {
            Console.WriteLine("2 sssssssssssss:::::::::::::::::::::::::::::::::::::::: ");
            bool tf = true;
            Dictionary<string, decimal>  Local = ayudante.TablesColumns();
            Dictionary<string, decimal>  Servidor = MgrServidor.TablesColumns();
            
            foreach (KeyValuePair<string, decimal> pair in Local)
            {
                if (Servidor.ContainsKey(pair.Key))
                {
                    PistaMgr.Instance.Debug ("SincronizadorCliente", string.Format ("Tabla:{0} Local:{1} - Servidor {2}" , pair.Key  ,pair.Value ,  Servidor[pair.Key]));
                    if (pair.Value != Servidor[pair.Key])
                    {
                        tf = false;
                        PistaMgr.Instance.Error("SincronizadorCliente", string.Format("La cantidad de columnas de la Tabla: {0}; en cliente es diferente a la de servidor| Cliente:{1} - Servidor {2}", pair.Key, pair.Value, Servidor[pair.Key]));
                        }
                }
                else
                {
                    tf = false;
                    PistaMgr.Instance.Error("SincronizadorCliente", string.Format("Servidor no tiene la Tabla: {0}", pair.Key));
                }
            }
            return tf;
        }

        private int count = 0;
        public bool SincronizarDatos()
        {
            //ConfigurationManager.AppSettings["OffLine"] = "ss";
            Console.WriteLine("3 sssssssssssss:::::::::::::::::::::::::::::::::::::::: ");
            bool resultado = false;

            if (true)
            {
                try
                {
                    Pistas.PistaMgr.Instance.EscribirLog("Sincronizacion", "Inicio Sincronización" + DateTime.Now.ToString(), TipoPista.Debug);
                    resultado = SincronizarParametros();
                    Pistas.PistaMgr.Instance.EscribirLog("Sincronizacion", "SincronizarParametros " + DateTime.Now.ToString(), TipoPista.Debug);
                }
                catch (Exception e)
                {

                    Pistas.PistaMgr.Instance.EscribirLog("SincronizadorCliente", e, TipoPista.Error);
                }


                //if (count >=0)
                //{
                //    resultado = SincronizacionInformesDeFalla();
                //    Pistas.PistaMgr.Instance.EscribirLog("Sincronizacion", "SincronizacionInformesDeFalla " + DateTime.Now.ToString(), TipoPista.Debug);
                //}
                //count++;
            }
            else
            {
                Console.WriteLine("ccccccccccccccccccc");
            }
            return resultado;
        }
        
        private bool SincronizarParametros()
        {
            Console.WriteLine("4 sssssssssssss:::::::::::::::::::::::::::::::::::::::: ");
            bool resultado = false;
            try
            {
                MensajeEmergenteMgr.Intancia.LimpiarMensaje();
                if (Sesion.Instancia.ConfigConexion.TipoBD == CNDC.DAL.TipoBaseDatos.Centralizada)
                {
                    return false;
                }

                if (_error)
                {
                    return false;
                }

              
                PistaMgr.Instance.EscribirEnLocal("Sincronizador", "Iniciando Sincronizacion: " + DateTime.Now.ToString("HH:mm:ss"));
                AyudanteSincronizacion ayudante = new AyudanteSincronizacion(Sesion.Instancia.Conexion);
                //ValidarEstructuraTablas(ayudante);
                PistaMgr.Instance.EscribirEnLocal("Sincronizador", "Iniciando Sincronizacion: PASO1 " + DateTime.Now.ToString("HH:mm:ss"));
                Dictionary<string, decimal> sincVersionesLocal = ayudante.GetMaxSincVer();
                PistaMgr.Instance.EscribirEnLocal("Sincronizador", "Iniciando Sincronizacion: PASO2 " + DateTime.Now.ToString("HH:mm:ss"));
                Console.WriteLine("0eeeeeeeeeeee:: ");
                Dictionary<string, decimal> sincVersionesServidor = MgrServidor.GetMaxSincVer();
                Console.WriteLine("1eeeeeeeeeeee:: ");
                Console.WriteLine("2eeeeeeeeeeee:: "+sincVersionesLocal.Count);
                PistaMgr.Instance.EscribirEnLocal("Sincronizador", "Iniciando Sincronizacion: PASO3 " + DateTime.Now.ToString("HH:mm:ss"));
                int contadorTablasSincronizadas = 0;
                Dictionary<IProveedorConfirmacionSinc, DataTable> dicProveedoresConfirmacion = new Dictionary<IProveedorConfirmacionSinc, DataTable>();
                int c = 0;

                if (sincVersionesServidor == null || sincVersionesServidor.Count == 0)
                {
                    _error = true;
                }

                try
                {
                    PistaMgr.Instance.EscribirEnLocal("Sincronizador", "Iniciando Sincronizacion: PASO4 " + DateTime.Now.ToString("HH:mm:ss"));
                    ConfirmarSincronizador(sincVersionesLocal, sincVersionesServidor);

                    foreach (var kv in sincVersionesServidor)
                    {
                        if (sincVersionesLocal.ContainsKey(kv.Key))
                        {
                            c++;
                            PistaMgr.Instance.Debug("Sincronizador", kv.Key + " " + kv.Value);
                            Console.WriteLine(c.ToString());
                            if (_managersLocal.ContainsKey(kv.Key) && sincVersionesLocal.ContainsKey(kv.Key))
                            {
                                IMgrLocal mgrLocal = _managersLocal[kv.Key];
                                decimal maxSincVersion = sincVersionesLocal[mgrLocal.NombreTabla];
                                if (maxSincVersion < kv.Value)
                                {
                                    PistaMgr.Instance.Debug("Sincronizador", string.Format("Nombre Tabla:{0}", mgrLocal.NombreTabla));
                                    DataTable tabla = MgrServidor.GetRegistrosSincronizacion(mgrLocal.NombreTabla, maxSincVersion, Sesion.Instancia.EmpresaActual.PkCodPersona);
                                    List<DataRow> rowsNuevos = new List<DataRow>();
                                    List<DataRow> rowsAntiguos = new List<DataRow>();
                                    foreach (DataRow row in tabla.Rows)
                                    {
                                        if (mgrLocal.Existe(mgrLocal.NombreTabla, row))
                                        {
                                            rowsAntiguos.Add(row);
                                        }
                                        else
                                        {
                                            rowsNuevos.Add(row);
                                        }
                                        resultado = true;
                                    }

                                    if (rowsNuevos.Count > 0)
                                    {
                                        mgrLocal.Insertar(rowsNuevos);
                                    }

                                    if (rowsAntiguos.Count > 0)
                                    {
                                        mgrLocal.Actualizar(rowsAntiguos);
                                    }

                                    if (mgrLocal is IProveedorConfirmacionSinc)
                                    {
                                        dicProveedoresConfirmacion.Add(mgrLocal as IProveedorConfirmacionSinc, tabla);
                                    }

                                    PistaMgr.Instance.Debug("Sincronizador", string.Format("{0}, NumRegistros={1}", mgrLocal.NombreTabla, tabla.Rows.Count));



                                }
                            }

                            contadorTablasSincronizadas++;
                            OnSincronizando(contadorTablasSincronizadas, sincVersionesServidor.Count, "Sincronizando Parámetros...");
                        }
                    }
                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.Error("Sincronizador", ex);
                }

                foreach (KeyValuePair<IProveedorConfirmacionSinc, DataTable> kv in dicProveedoresConfirmacion)
                {
                    DataTable tabla = kv.Key.GetTablaConfirmacionSinc(kv.Value);
                    if (tabla.Rows.Count > 0)
                    {
                        MgrServidor.ConfirmarSinc((kv.Key as IMgrLocal).NombreTabla, tabla);
                    }
                }
                PistaMgr.Instance.EscribirEnLocal("Sincronizador", "Finalizando Sincronizacion: " + DateTime.Now.ToString("HH:mm:ss"));
            }
            catch (Exception ex2 ) 
            {
                PistaMgr.Instance.Error("Sincronizador", ex2);
               
            }

          

            //resultado = resultado && SincronizacionInformesDeFalla();
            return resultado;
        }

        /*
         /* @jla: 27/Marzo/2014  Método que sincroniza informes de Falla
         */
        public  bool  SincronizarInformesFalla()
        {
            Console.WriteLine("5 sssssssssssss:::::::::::::::::::::::::::::::::::::::: ");
            bool resultado = false;
            
            try
            {
                PistaMgr.Instance.Debug("SincronizacionInformesDeFalla", string.Format("Inicio Sincronizacion: {0}", DateTime.Now.ToString("HH:mm:ss")));

                AyudanteSincronizacion ayudante = new AyudanteSincronizacion(Sesion.Instancia.Conexion);
                //ValidarEstructuraTablas(ayudante);
                DataTable sincLocal = ayudante.GetSincronizacionInformesFalla();
                DataTable sincServer = MgrServidor.GetSincronizacionInformesFalla();

                PistaMgr.Instance.EscribirLog("SincronizacionInformesDeFalla", "SincronizadorRegistroFallas.GetLista(sincLocal) ", TipoPista.Debug);
                List<SincronizadorRegistroFallas> listaLocal = SincronizadorRegistroFallas.GetLista(sincLocal);
                PistaMgr.Instance.EscribirLog("SincronizacionInformesDeFalla", " SincronizadorRegistroFallas.GetLista(sincServer); " , TipoPista.Debug);
                List<SincronizadorRegistroFallas> listaServer = SincronizadorRegistroFallas.GetLista(sincServer);
                PistaMgr.Instance.EscribirLog("SincronizacionInformesDeFalla", "new List<SincronizadorRegistroFallas>() " , TipoPista.Debug);
                List<SincronizadorRegistroFallas> lFallas = new List<SincronizadorRegistroFallas>();
                
                OnSincronizando(0, 10, "Informes de falla");

                PistaMgr.Instance.EscribirLog("SincronizacionInformesDeFalla", "listaServer: " + listaServer.Count.ToString (), TipoPista.Debug);
                foreach (SincronizadorRegistroFallas item in listaServer)
                {
                    if (listaLocal.IndexOf(item) == -1)
                    {
                        PistaMgr.Instance.EscribirLog("SincronizacionInformesDeFalla", "Código de Falla: " + item.PkCodFalla.ToString(), TipoPista.Debug);
                        lFallas.Add(item);
                        resultado = true;
                    }
                }


                PistaMgr.Instance.Debug("SincronizacionInformesDeFalla", string.Format("Fin Sincronizacion: {0}", DateTime.Now.ToString("HH:mm:ss")));

                Actualizar = lFallas.OrderBy(o => o.PSincVer).ToList();
            }
            catch (Exception ex )
            {

                PistaMgr.Instance.Error("Sincronizador", ex);
            }

          
            return resultado;
        }
  
        public void OnSincronizando(int c, int t, string tx)
        {
            Console.WriteLine("6 sssssssssssss:::::::::::::::::::::::::::::::::::::::: ");
            if (Sincronizando != null)
            {
                Sincronizando(this, new SincEventArgs(c, t,tx));
            }
        }

        public void AdicionarMgr(IMgrLocal mgr)
        {
            if (mgr != null && !_managersLocal.ContainsKey(mgr.NombreTabla))
            {
                _managersLocal.Add(mgr.NombreTabla, mgr);
            }
        }
    }

    public class SincEventArgs : EventArgs
    {
        private int _actual;
        private int _total;
        private string _texto;
        public SincEventArgs(int actual, int total, string texto )
        {
            _actual = actual;
            _total = total;
            _texto = texto;
        }

        public int Actual { get { return _actual; } }
        public int Total { get { return _total; } }
        public string Texto { get { return _texto; } }
    }

    public interface IMgrLocal
    {
        void Insertar(List<DataRow> rows);
        void Actualizar(List<DataRow> rows);
        string NombreTabla { get; }
        bool Existe(string nombreTabla, DataRow row);
    }

    public interface IProveedorConfirmacionSinc
    {
        DataTable GetTablaConfirmacionSinc(DataTable tabla);
    }

    public interface IMgrServidor
    {
        Dictionary<string, decimal> GetMaxSincVer();

        Dictionary<string, decimal> TablesColumns();
        DataTable GetRegistrosSincronizacion(string nombreTabla, decimal maxSincVersion, long pkCodPersona);
        /*
         * jjla: 26 de Marzo de 2014
         * Nueva Clase para implementar mecanismo de sincronización, por informe de falla no por SINC_VER
         */
        DataTable GetSincronizacionInformesFalla();
        bool Subir(DataSet sd, string modulo);
        void ConfirmarSinc(string nombreTabla, DataTable registros);
        DateTime? GetFechaHoraServ();
    }
}
