using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.UtilesComunes;
using CNDC.BLL;
using CNDC.Sincronizacion;
using CNDC.Pistas;
using System.IO.Compression;
using System.IO;
using System.Globalization;

namespace WcfDalSisFalla
{
    public class WcfClienteSinc : IMgrServidor
    {

        public DataTable GetSincronizacionInformesFalla()
        {
            Console.WriteLine("WcfClienteSinc ccc 1:: ");
            DataTable resultado = null;
            try {
                byte[] b = WcfServicioMgr.Instancia.Servicio.GetInformesFallaSincronizacion(Sesion.Instancia.TokenSession);
                PistaMgr.Instance.EscribirLog("WcfClienteSinc", "GetInformesFallaSincronizacion:" + b.Length.ToString(), TipoPista.Debug);
                resultado = Serializador.DeSerializar<DataTable>(b);
            }
            catch (Exception e)
            {
                PistaMgr.Instance.Error("GetSincronizacionInformesFalla upb ", e);
            }

            return resultado;
        }
        public DataTable GetRegistrosSincronizacion(string nombreTabla, decimal version, long pkCodEmpresa)
        {
            Console.WriteLine("WcfClienteSinc ccc 2:: ");
            DataTable resultado = null;
            try
            {
                byte[] b = WcfServicioMgr.Instancia.Servicio.GetRegistrosSincronizacion(Sesion.Instancia.TokenSession, nombreTabla, version, pkCodEmpresa);
                b = GZip.DesComprimir(b);
                resultado = Serializador.DeSerializar<DataTable>(b);
            }
            catch (Exception e)
            {
                PistaMgr.Instance.Error("GetRegistrosSincronizacion upb ", e);
            }
            
            return resultado;
        }
        public Dictionary<string, decimal> TablesColumns()
        {
            Console.WriteLine("WcfClienteSinc ccc 3:: ");
            Dictionary<string, decimal> resultado = null;
            try
            {
                byte[] b = WcfServicioMgr.Instancia.Servicio.TablesColumns (Sesion.Instancia.TokenSession);
                resultado = Serializador.DeSerializar<Dictionary<string, decimal>>(b);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfDalSisFalla TablesColumns", ex);
                resultado = new Dictionary<string, decimal>();
            }
            return resultado;
        }

        public Dictionary<string, decimal> GetMaxSincVer()
        {
            Console.WriteLine("WcfClienteSinc ccc 4:: ");
            Dictionary<string, decimal> resultado = null;
            try
            {
                Console.WriteLine("4eeeeeeeeeeee:: ");
                byte[] b = WcfServicioMgr.Instancia.Servicio.GetMaxSincVer(Sesion.Instancia.TokenSession);
                Console.WriteLine("5eeeeeeeeeeee:: ");
                resultado = Serializador.DeSerializar<Dictionary<string, decimal>>(b);
                Console.WriteLine("6eeeeeeeeeeee:: "+resultado.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("3eeeeeeeeeeee:: ");
                PistaMgr.Instance.Error("WcfDalSisFalla GetMaxSincVer", ex);
                resultado = new Dictionary<string, decimal>();
            }
            return resultado;
        }

        public bool Subir(DataSet ds, string modulo)
        {
            Console.WriteLine("WcfClienteSinc ccc 5:: ");
            bool resultado = false;

            try
            {
                byte[] b = Serializador.Serializar(ds);
                b = GZip.Comprimir(b);
                resultado = WcfServicioMgr.Instancia.Servicio.Subir(Sesion.Instancia.TokenSession, b, modulo);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfDalSisFalla Subir", ex);
            }
            return resultado;
        }

        public void ConfirmarSinc(string nombreTabla, DataTable registros)
        {
            Console.WriteLine("WcfClienteSinc ccc 6:: ");
            try
            {
                byte[] b = Serializador.Serializar(registros);
                b = GZip.Comprimir(b);
                WcfServicioMgr.Instancia.Servicio.ConfirmarSinc(Sesion.Instancia.TokenSession, Sesion.Instancia.EmpresaActual.PkCodPersona, nombreTabla, b);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfDalSisFalla ConfirmarSinc", ex);
            }
        }

        static CultureInfo _cultura;
        const string FORMATO_FECHA = "dd/MM/yyyy HH:mm";
        public DateTime? GetFechaHoraServ()
        {
            Console.WriteLine("WcfClienteSinc ccc 7:: ");
            DateTime? resultado = null;
            string strFechaHora = string.Empty;
            try
            {
                strFechaHora = WcfServicioMgr.Instancia.Servicio.GetStrFechaHora(Sesion.Instancia.TokenSession);
                AsegurarCultura();
                resultado = DateTime.Parse(strFechaHora, _cultura);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfDalSisFalla GetFechaHoraServ", new Exception("Fecha:" + strFechaHora +" :: ", ex));
            }
            return resultado;
        }

        private void AsegurarCultura()
        {
            Console.WriteLine("WcfClienteSinc ccc 8:: ");
            _cultura = new CultureInfo("es-BO", true);
            _cultura.DateTimeFormat.ShortDatePattern = FORMATO_FECHA;
            _cultura.DateTimeFormat.LongDatePattern = FORMATO_FECHA;

        }
    }
}
