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
            DataTable resultado = null;
            byte[] b = WcfServicioMgr.Instancia.Servicio.GetInformesFallaSincronizacion(Sesion.Instancia.TokenSession);
            PistaMgr.Instance.EscribirLog("WcfClienteSinc", "GetInformesFallaSincronizacion:" + b.Length.ToString(), TipoPista.Debug);
             resultado =   Serializador.DeSerializar<DataTable>(b);

            return resultado;
        }
        public DataTable GetRegistrosSincronizacion(string nombreTabla, decimal version, long pkCodEmpresa)
        {
            DataTable resultado = null;
            byte[] b = WcfServicioMgr.Instancia.Servicio.GetRegistrosSincronizacion(Sesion.Instancia.TokenSession, nombreTabla, version, pkCodEmpresa);
            b = GZip.DesComprimir(b);
            resultado = Serializador.DeSerializar<DataTable>(b);
            return resultado;
        }
        public Dictionary<string, decimal> TablesColumns()
        {
            Dictionary<string, decimal> resultado = null;
            try
            {
                byte[] b = WcfServicioMgr.Instancia.Servicio.TablesColumns (Sesion.Instancia.TokenSession);
                resultado = Serializador.DeSerializar<Dictionary<string, decimal>>(b);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfDalSisFalla", ex);
                resultado = new Dictionary<string, decimal>();
            }
            return resultado;
        }

        public Dictionary<string, decimal> GetMaxSincVer()
        {
            Dictionary<string, decimal> resultado = null;
            try
            {
                byte[] b = WcfServicioMgr.Instancia.Servicio.GetMaxSincVer(Sesion.Instancia.TokenSession);
                resultado = Serializador.DeSerializar<Dictionary<string, decimal>>(b);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfDalSisFalla", ex);
                resultado = new Dictionary<string, decimal>();
            }
            return resultado;
        }

        public bool Subir(DataSet ds, string modulo)
        {
            bool resultado = false;

            try
            {
                byte[] b = Serializador.Serializar(ds);
                b = GZip.Comprimir(b);
                resultado = WcfServicioMgr.Instancia.Servicio.Subir(Sesion.Instancia.TokenSession, b, modulo);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfDalSisFalla", ex);
            }
            return resultado;
        }

        public void ConfirmarSinc(string nombreTabla, DataTable registros)
        {
            try
            {
                byte[] b = Serializador.Serializar(registros);
                b = GZip.Comprimir(b);
                WcfServicioMgr.Instancia.Servicio.ConfirmarSinc(Sesion.Instancia.TokenSession, Sesion.Instancia.EmpresaActual.PkCodPersona, nombreTabla, b);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("WcfDalSisFalla", ex);
            }
        }

        static CultureInfo _cultura;
        const string FORMATO_FECHA = "dd/MM/yyyy HH:mm";
        public DateTime? GetFechaHoraServ()
        {
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
                PistaMgr.Instance.Error("WcfDalSisFalla", new Exception("Fecha:" + strFechaHora, ex));
            }
            return resultado;
        }

        private void AsegurarCultura()
        {
            _cultura = new CultureInfo("es-BO", true);
            _cultura.DateTimeFormat.ShortDatePattern = FORMATO_FECHA;
            _cultura.DateTimeFormat.LongDatePattern = FORMATO_FECHA;

        }
    }
}
