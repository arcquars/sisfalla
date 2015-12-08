using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCFSisFalla;



namespace WcfDalSisFalla
{
    public class WcfServicioMgr
    {
        #region Singleton
        private static WcfServicioMgr _instancia;
        public static WcfServicioMgr Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new WcfServicioMgr();
                    
                }
                return _instancia;
            }
        }

        private WcfServicioMgr()
        {
            Inicializar();
            
        }
        #endregion Singleton


        private void Inicializar()
        {
            //EndpointAddress epAddress = new EndpointAddress("http://192.168.2.170/WCFSISFALLA/Service1.svc");

            //BasicHttpBinding binding = new BasicHttpBinding();
            ////WSHttpBinding binding = new WSHttpBinding();
            //binding.MaxReceivedMessageSize = int.MaxValue;
            //binding.MaxBufferPoolSize = int.MaxValue;
            //binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
            //_servicio = new WCFServicioSisFalla.ServicioSISFALLAClient(binding, epAddress);

            _servicio = new ServicioSISFALLAClient("BasicHttpBinding_IServicioSISFALLA");
            
            
        }
        IServicioSISFALLA _servicio;
        public IServicioSISFALLA Servicio
        {
            get { return _servicio; }
        }

        public void CerrarSesion(string token)
        {
            try
            {
                _servicio.CerrarSesion(token);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
