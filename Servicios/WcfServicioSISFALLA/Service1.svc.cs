using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ModeloSisFalla;
using CNDC.UtilesComunes;
using OraDalSisFalla;
using System.IO;
using CNDC.Pistas;
using CNDC.DAL;
using System.Data;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using CNDC.Sincronizacion;
using CNDC.Dominios;
using System.ServiceModel.Channels;
using BLL;

namespace WcfServicioSISFALLA
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ServicioSISFALLA : IServicioSISFALLA, IDisposable
    {
        Contexto _contexto;
        ConnexionOracleMgr _conexion;
        string _token = string.Empty;
        private void AsegurarConexion(string token)
        {
            _token = token;
            if (_contexto == null)
            {
                _contexto = new Contexto(token);
            }

            if (_conexion == null)
            {
                _conexion = MgrConexiones.Instancia.GetConexion(token);
            }
        }


        



        public long IniciarSesion(string token)
        {
            long resultado = 0;
            PistaMgr.Instance.EscribirEnLocal("WcfServicioSISFALLA.IniciarSesion()", "Iniciando Session " + token);
            AsegurarConexion(token);
            string sql =
            @"select pk_cod_persona from f_ap_persona
            where pk_cod_persona in(Select pk_cod_usuario from f_au_usuarios where login=:login)";
            OracleCommand cmd = _conexion.CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("login", _contexto.Valores["Usuario"]);
            cmd.BindByName = true;
            DataTable tabla = _conexion.EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (long)tabla.Rows[0][0];
                PistaMgr.Instance.EscribirEnLocal("WcfServicioSISFALLA.IniciarSesion()", "Session Iniciada " + token + " pk_cod_persona=" + resultado);
            }
            else
            {
                PistaMgr.Instance.EscribirEnLocal("WcfServicioSISFALLA.IniciarSesion()", "Session No pudo iniciarse " + token);
            }
            return resultado;
        }

        public bool ValidarOperacion(long Id_Operacion, int Pk_Cod_Falla, long PkDCodTipoinforme, long Pk_Cod_Persona)
        {
            bool rtn = false;

            AsegurarMgrsLocal();
            Operacion opn = new Operacion();
            DOMINIOS_OPERACION id_op =  DOMINIOS_OPERACION.AGENTE_ENVIA_FINAL;
            if (PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR)
            {
                id_op =  DOMINIOS_OPERACION.AGENTE_ENVIA_PRELIMINAR;
            }
            else
            {
                id_op =  DOMINIOS_OPERACION.AGENTE_ENVIA_FINAL;
            }
            rtn = opn.OperacionValida(id_op, Pk_Cod_Falla, Pk_Cod_Persona);
            return rtn;
        }

        public byte[] GetTabla(string token, string nombreTabla)
        {
            AsegurarConexion(token);
            DataTable tabla = _conexion.GetTabla(nombreTabla);


            return Serializador.Serializar(tabla);
        }

        /*
         * @jjla: 26/Marzo/2014
         */
        public byte[] GetInformesFallaSincronizacion(string token)
        {
            AsegurarConexion(token);
            string pista = string.Format("GetInformesFallaSincronizacion(): {0} // {1}", GetIPCliente(), _conexion.CadenaConexion);
            PistaMgr.Instance.EscribirEnLocal(pista,"SISFALLA");
            AyudanteSincronizacion ayudanteSinc = new AyudanteSincronizacion(_conexion);
            DataTable tabla = ayudanteSinc.GetSincronizacionInformesFalla ();
            
            return Serializador.Serializar(tabla);
        }

        public byte[] GetRegistrosSincronizacion(string token, string nombreTabla, decimal versionCliente, long pkCodPersona)
        {
            byte[] resultado = null;
            AsegurarConexion(token);
            ProveedorDatosMgr proveedorMgr = new ProveedorDatosMgr(_conexion);
            ConfigurarProveedores(proveedorMgr);
            PistaMgr.Instance.EscribirEnLocal("WcfServicioSISFALLA.GetRegistrosSincronizacion()",
                string.Format("[{2} pk_cod_persona={3}] > NombreTabla:{0} {1}", nombreTabla, GetIPCliente(), token, pkCodPersona));
            try
            {
                DataTable tabla = proveedorMgr.GetDatos(nombreTabla, versionCliente, pkCodPersona);
                PistaMgr.Instance.Debug("WcfServicioSISFALLA.GetRegistrosSincronizacion()", "retornando datos Count=" + tabla.Rows.Count);
                resultado = Serializador.Serializar(tabla);
                resultado = GZip.Comprimir(resultado);
            }
            catch (Exception exc)
            {
                PistaMgr.Instance.Error("WcfServicioSISFALLA.GetRegistrosSincronizacion()", exc);
            }
            return resultado;
        }

        private void ConfigurarProveedores(ProveedorDatosMgr proveedor)
        {
            if (proveedor.CantidadProveedores == 0)
            {
                proveedor.AdicionarProveedor(RegFalla.NOMBRE_TABLA, new OraDalRegFallaMgr(_conexion));
                proveedor.AdicionarProveedor(Notificacion.NOMBRE_TABLA, new OraDalNotificacionMgr(_conexion));
                proveedor.AdicionarProveedor(InformeFalla.NOMBRE_TABLA, new OraDalInformeFallaMgr(_conexion));
                proveedor.AdicionarProveedor(RRegFallaComponente.NOMBRE_TABLA, new OraDalRRegFallaComponenteMgr(_conexion));
                proveedor.AdicionarProveedor(AsignacionResposabilidad.NOMBRE_TABLA, new OraDalAsignacionResposabilidadMgr(_conexion));
                proveedor.AdicionarProveedor(OperacionInterruptores.NOMBRE_TABLA, new OraDalOperacionInterruptoresMgr(_conexion));
                proveedor.AdicionarProveedor(OperacionAlimentador.NOMBRE_TABLA, new OraDalOperacionAlimentadorMgr(_conexion));
                proveedor.AdicionarProveedor(TiempoDetalle.NOMBRE_TABLA, new OraDalTiempoDetalleMgr(_conexion));
                proveedor.AdicionarProveedor(RelesOperados.NOMBRE_TABLA, new OraDalRelesOperadosMgr(_conexion));
                proveedor.AdicionarProveedor(FotoRegFalla.NOMBRE_TABLA, new OraDalFotoRegFalla(_conexion));
                proveedor.AdicionarProveedor(AnalisisFalla.NOMBRE_TABLA, new OraDalAnalisisFallaMgr(_conexion));
                proveedor.AdicionarProveedor(Colapso.NOMBRE_TABLA, new OraDalColapsoMgr(_conexion));
            }
        }

        public byte[] GetMaxSincVer(string token)
        {
            AsegurarConexion(token);
            PistaMgr.Instance.EscribirEnLocal("GetMaxSincVer(): " , GetIPCliente());
            AyudanteSincronizacion ayudanteSinc = new AyudanteSincronizacion(_conexion);
            Dictionary<string, decimal> tabla = ayudanteSinc.GetMaxSincVer();
            return Serializador.Serializar(tabla);
        }

        public byte[] TablesColumns(string token)
        {
            AsegurarConexion(token);
            PistaMgr.Instance.EscribirEnLocal("TablesColumns(): ", GetIPCliente());
            AyudanteSincronizacion ayudanteSinc = new AyudanteSincronizacion(_conexion);
            Dictionary<string, decimal> tabla = ayudanteSinc.TablesColumns();
            return Serializador.Serializar(tabla);
        }

        List<IMgrLocal> _managersLocal;
        public bool Subir(string token, byte[] dataSet, string modulo)
        {
            bool resultado = true;
            modulo = modulo.ToUpper();

            if (modulo == "SISFALLA")
            {
                PistaMgr.Instance.Debug("WcfServicioSISFALLA.Subir()", "Iniciando..." + GetIPCliente());
                AsegurarConexion(token);
                AsegurarMgrsLocal();

                try
                {
                    dataSet = GZip.DesComprimir(dataSet);
                    DataSet ds = Serializador.DeSerializar<DataSet>(dataSet);
                    foreach (var mgr in _managersLocal)
                    {
                        
                        if (ds.Tables.Contains(mgr.NombreTabla))
                        {
                            
                            
                            DataTable tabla = ds.Tables[mgr.NombreTabla];
                            PistaMgr.Instance.Debug("WcfServicioSISFALLA.Subir()", "mgr=" + mgr.NombreTabla + " Cant. Reg.:" + tabla.Rows.Count);
                            List<DataRow> rowsNuevos = new List<DataRow>();
                            List<DataRow> rowsAntiguos = new List<DataRow>();
                            
                            foreach (DataRow row in tabla.Rows)
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
                            }

                            if (rowsNuevos.Count > 0)
                            {
                                PistaMgr.Instance.Debug("WcfServicioSISFALLA.Subir()", mgr.NombreTabla + " nuevos: " + rowsNuevos.Count);
                                mgr.Insertar(rowsNuevos);
                            }
                            if (rowsAntiguos.Count > 0)
                            {
                                PistaMgr.Instance.Debug("WcfServicioSISFALLA.Subir()", mgr.NombreTabla + " antiguos: " + rowsAntiguos.Count);
                                mgr.Actualizar(rowsAntiguos);
                            }
                        }
                        else
                        {
                            PistaMgr.Instance.Debug("WcfServicioSISFALLA.Subir()", "DataSet NO contiene tabla" + mgr.NombreTabla);
                        }
                    }

                    DataTable tablaInforme = ds.Tables[InformeFalla.NOMBRE_TABLA];
                    InformeFalla informe = new InformeFalla(tablaInforme.Rows[0]);
                    DOMINIOS_OPERACION tipoOperacion = DOMINIOS_OPERACION.AGENTE_ENVIA_PRELIMINAR;

                    if (informe.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR)
                    {
                        tipoOperacion = DOMINIOS_OPERACION.AGENTE_ENVIA_PRELIMINAR;
                    }
                    else if (informe.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.FINAL)
                    {
                        tipoOperacion = DOMINIOS_OPERACION.AGENTE_ENVIA_FINAL;
                    }

                    Operacion opn = new Operacion();
                    opn.RegistrarOperacion(tipoOperacion, informe.PkCodFalla, informe.PkOrigenInforme);
                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.Error("WcfServicioSISFALLA.Subir()", ex);
                }

                PistaMgr.Instance.Debug("WcfServicioSISFALLA.Subir()", "Finalizando...");
            }

            return resultado;
        }

        private void AsegurarMgrsLocal()
        {
            if (_managersLocal == null)
            {
                _managersLocal = new List<IMgrLocal>();
                _managersLocal.Add(new OraDalRegFallaMgr(_conexion));
                _managersLocal.Add(new OraDalNotificacionMgr(_conexion));
                _managersLocal.Add(new OraDalInformeFallaMgr(_conexion));
                _managersLocal.Add(new OraDalOperacionAlimentadorMgr(_conexion));

                _managersLocal.Add(new OraDalOperacionInterruptoresMgr(_conexion));
                _managersLocal.Add(new OraDalRelesOperadosMgr(_conexion));
                _managersLocal.Add(new OraDalRRegFallaComponenteMgr(_conexion));
                _managersLocal.Add(new OraDalTiempoDetalleMgr(_conexion));
                _managersLocal.Add(new OraDalAsignacionResposabilidadMgr(_conexion));
            }
            ModeloMgr.Instancia.OperacionMgr = new OraDalSisFalla.OraDalOperacion(_conexion);
        }

        public bool ConfirmarSinc(string token, long codPersona, string nombreTabla, byte[] tabla)
        {
            bool resultado = false;
            try
            {
                AsegurarConexion(token);
                AsegurarMgrsLocal();
                if (nombreTabla == Notificacion.NOMBRE_TABLA)
                {
                    tabla = GZip.DesComprimir(tabla);
                    DataTable t = Serializador.DeSerializar<DataTable>(tabla);
                    int[] numsFalla = GetNumFalla(t);
                    OraDalNotificacionMgr notifMgr = new OraDalNotificacionMgr(_conexion);
                    notifMgr.ActualizarNotificaciones(codPersona, numsFalla, (long)D_COD_ESTADO_NOTIFICACION.RECIBIDO);
                    PistaMgr.Instance.Debug("WcfServicioSISFALLA.ConfirmarSinc()", "cant_fallas" + numsFalla.Length.ToString ());
                    
                    Operacion opn = new Operacion();
                    foreach (int numFalla in numsFalla)
                    {
                        opn.RegistrarOperacion(DOMINIOS_OPERACION.AGENTE_NOTIFICACION_RECIBIDA, numFalla, codPersona);
                    }
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfServicioSISFALLA.ConfirmarSinc()", ex);
            }
            return resultado;
        }

        private int[] GetNumFalla(DataTable t)
        {
            int[] resultado = new int[t.Rows.Count];
            for (int i = 0; i < resultado.Length; i++)
            {
                resultado[i] = (int)t.Rows[i][0];
            }
            return resultado;
        }

        public string GetStrFechaHora(string token)
        {
            string resultado = null;
            try
            {
                PistaMgr.Instance.EscribirEnLocal("GetStrFechaHora() ", GetIPCliente());
                AsegurarConexion(token);
                DateTime? fechaHora = _conexion.GetFechaHora();
                if (fechaHora != null)
                {
                    resultado = fechaHora.Value.ToString("dd/MM/yyyy HH:mm");
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfServicioSISFALLA.GetStrFechaHora()", ex);
            }
            PistaMgr.Instance.EscribirEnLocal("GetStrFechaHora() ::: ", resultado);
            return resultado;
        }

        private string GetIPCliente()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;
            return ip;
        }

        public void Dispose()
        {
            //if (_conexion != null)
            //{
            //    PistaMgr.Instance.EscribirEnLocal("WcfServicioSISFALLA.Dispose()", "Eliminando Conexion de Cliente: " + GetIPCliente());
            //    _conexion.Dispose();
            //}
            //MgrConexiones.Instancia.DisposeConexion(_token);
        }

        public byte[] GetTablaTest(string token, string nombreTabla)
        {
            DataTable tabla = null;
            PistaMgr.Instance.EscribirEnLocal("WcfServicioSISFALLA.GetTablaTest()", GetIPCliente() + " " + token + " " + nombreTabla);
            AsegurarConexion(token);
            tabla = _conexion.GetTabla(nombreTabla);
            byte[] b = Serializador.Serializar(tabla);
            b = GZip.Comprimir(b);
            return b;
        }

        public void CerrarSesion(string token)
        {
            _conexion = null;
            MgrConexiones.Instancia.DisposeConexion(token);
        }

        public byte[] GetInforme(string token,int codFalla, long origen, long tipo)
        {
            byte[] b = null;

            try
            {
                AsegurarConexion(token);
                ModeloMgr.Instancia.InformeFallaMgr = new OraDalInformeFallaMgr(_conexion);
                ModeloMgr.Instancia.ColapsoMgr = new OraDalColapsoMgr(_conexion);
                InformeFalla infFalla = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(codFalla, origen, tipo);
                if (infFalla != null)
                {
                    DataSet ds = infFalla.GetDataSet();
                    PistaMgr.Instance.EscribirEnLocal("WcfServicioSISFALLA.GetInforme()","TESTING");
                    foreach (DataTable  Table in ds.Tables)
                    {

                       
                        string ta = string.Empty;
                        string s = string.Empty;
                        foreach (DataRow    row in Table.Rows)
                        {
                            foreach (DataColumn col in Table.Columns)
                            {
                                if ((row[col].ToString().Length) > 150)
                                {
                                    s = string.Format("{0} : {1}", col.ColumnName, row[col].ToString().Substring(0, 150));
                                }
                                else
                                {
                                    s = string.Format("{0} : {1}", col.ColumnName, row[col].ToString());
                                }
                                ta += "\n" + s;
                            }
                        }
                        PistaMgr.Instance.EscribirEnLocal("table " + Table.TableName+ ta, "DWBUG");

                    }

                    b = Serializador.Serializar(ds);
                    b = GZip.Comprimir(b);
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfServicioSISFALLA.GetInforme()", ex);
            }
            return b;
        }

        public bool TestConexion()
        {
            return true;
        }

        public bool UpdateRegFallaFecInicio(string token, long codRegFalla, DateTime fecInicio)
        {
            return true;
        }
    }

    public class MgrConexiones : IDisposable
    {
        private static MgrConexiones _instancia;

        public static MgrConexiones Instancia
        { get { return _instancia; } }

        static MgrConexiones()
        {
            _instancia = new MgrConexiones();
        }

        private Dictionary<string, ConnexionOracleMgr> _conexiones;
        public MgrConexiones()
        {
            _conexiones = new Dictionary<string, ConnexionOracleMgr>();
        }

        public ConnexionOracleMgr GetConexion(string token)
        {
            ConnexionOracleMgr resultado = null;
            if (_conexiones.ContainsKey(token))
            {
                resultado = _conexiones[token];
            }
            else
            {
                Contexto _contexto = new Contexto(token);
                ConfigConexionMgr c = new ConfigConexionMgr();
                c.Inicializar(_contexto.Valores["Usuario"], _contexto.Valores["Contrasena"]);
                resultado = new ConnexionOracleMgr(c.CadenaConexion);
                _conexiones[token] = resultado;
            }
            return resultado;
        }

        public void Dispose()
        {
            foreach (ConnexionOracleMgr c in _conexiones.Values)
            {
                c.Dispose();
            }
            _conexiones.Clear();
        }

        public void DisposeConexion(string token)
        {
            if (_conexiones.ContainsKey(token))
            {
                ConnexionOracleMgr c = _conexiones[token];
                _conexiones.Remove(token);
                c.Dispose();
                c = null;
            }
        }
    }
}