using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;

namespace ModeloSisFalla
{
    public class ModeloMgr
    {
        #region Singleton
        private static ModeloMgr _instancia;

        static ModeloMgr()
        {
            _instancia = new ModeloMgr();
        }

        public static ModeloMgr Instancia
        {
            get { return _instancia; }
        }

        private ModeloMgr()
        {
            Inicializar();
        }
        #endregion Singleton

        public IRegFallaMgr RegFallaMgr { get; set; }
        public IPersonaMgr PersonaMgr { get; set; }
        public IDefDominioMgr DefDominioMgr { get; set; }
        public IComponenteMgr ComponenteMgr { get; set; }
        public IRContactoMgr RContactoMgr { get; set; }
        public IInformeFallaMgr InformeFallaMgr { get; set; }
        public IRRegFallaComponenteMgr RRegFallaComponenteMgr { get; set; }
        public ITiempoDetalleMgr TiempoDetalleMgr { get; set; }
        public IAsignacionResposabilidadMgr AsignacionResposabilidadMgr { get; set; }
        public IOperacionInterruptoresMgr OperacionInterruptoresMgr { get; set; }
        public IRelesOperadosMgr RelesOperadosMgr { get; set; }
        public IOperacionAlimentadorMgr OperacionAlimentadorMgr { get; set; }
        public INotificacionMgr NotificacionMgr { get; set; }
        public IP_GF_CorreosMgr P_GF_CorreosMgr { get; set; }
        public IColapsoMgr ColapsoMgr { get; set; }
        public iOperacion OperacionMgr { get; set; }
        public IAnalisisFallaMgr AnalisisMgr { get; set; }
        public IRegOperacionMgr RegOperacionMgr { get; set; }
        public I_P_GF_ConfiguracionMgr P_GF_ConfiguracionMgr { get; set; }
        public iCambioContrasenaMgr CambioContrasenaMgr { get; set; }

        
        private void Inicializar()
        { 
        }
    }
}
