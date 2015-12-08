using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloSisFalla;
using CNDC.BLL;
using CNDC.Sincronizacion;
using OraDalSisFalla;

namespace SISFALLA
{
    public class Inicializador
    {
        public static void Inicializar()
        {
            ModeloMgr.Instancia.RegFallaMgr = new OraDalSisFalla.OraDalRegFallaMgr();
            ModeloMgr.Instancia.PersonaMgr = CNDC.BLL.OraDalPersonaMgr.Instancia;//new WcfDalSisFalla.WcfClientePersonaMgr();
            ModeloMgr.Instancia.DefDominioMgr = new DefDominioMgr();
            ModeloMgr.Instancia.ComponenteMgr = new ComponenteMgr();
            ModeloMgr.Instancia.RContactoMgr = new OraDalRContactoMgr();
            ModeloMgr.Instancia.InformeFallaMgr = new OraDalSisFalla.OraDalInformeFallaMgr();
            ModeloMgr.Instancia.RRegFallaComponenteMgr = new OraDalSisFalla.OraDalRRegFallaComponenteMgr();
            ModeloMgr.Instancia.TiempoDetalleMgr = new OraDalSisFalla.OraDalTiempoDetalleMgr();
            ModeloMgr.Instancia.AsignacionResposabilidadMgr = new OraDalSisFalla.OraDalAsignacionResposabilidadMgr();
            ModeloMgr.Instancia.OperacionInterruptoresMgr = new OraDalSisFalla.OraDalOperacionInterruptoresMgr();
            ModeloMgr.Instancia.RelesOperadosMgr = new OraDalSisFalla.OraDalRelesOperadosMgr();
            ModeloMgr.Instancia.OperacionAlimentadorMgr = new OraDalSisFalla.OraDalOperacionAlimentadorMgr();
            ModeloMgr.Instancia.NotificacionMgr = new OraDalSisFalla.OraDalNotificacionMgr();
            ModeloMgr.Instancia.P_GF_CorreosMgr = new OraDalSisFalla.OraDalP_GF_CorreosMgr();
            ModeloMgr.Instancia.ColapsoMgr = new OraDalSisFalla.OraDalColapsoMgr();
            ModeloMgr.Instancia.OperacionMgr = new OraDalSisFalla.OraDalOperacion();
            ModeloMgr.Instancia.AnalisisMgr = new OraDalSisFalla.OraDalAnalisisFallaMgr();
            ModeloMgr.Instancia.P_GF_ConfiguracionMgr = new OraDalSisFalla.OraDalP_GF_ConfiguracionMgr();
            AdministradorAyuda.Instance.ProveedorAyuda = new OraDalSisFalla.OraDalProveedorAyuda();//new WcfDalSisFalla.WcfClienteProveerdorAyuda();
            
            SincronizadorCliente.Instancia.MgrServidor = new WcfDalSisFalla.WcfClienteSinc();
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.AsignacionResposabilidadMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.DefDominioMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.RegFallaMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.NotificacionMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.InformeFallaMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.OperacionAlimentadorMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.OperacionInterruptoresMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.RelesOperadosMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.RRegFallaComponenteMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.TiempoDetalleMgr as IMgrLocal);
            //SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.RContactoMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.AnalisisMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.ColapsoMgr as IMgrLocal);
            SincronizadorCliente.Instancia.AdicionarMgr(new P_DEF_MensajeSincMgr());
            SincronizadorCliente.Instancia.AdicionarMgr(new OraDalFotoRegFalla());
            SincronizadorCliente.Instancia.AdicionarMgr(new OraDalF_GF_Param_Edac());
            SincronizadorCliente.Instancia.AdicionarMgr(new OraDalF_GF_RComponenteEdac());
            SincronizadorCliente.Instancia.AdicionarMgr(new SincronizadorEstiloColumnas());
            SincronizadorCliente.Instancia.AdicionarMgr(new SincronizadorFormulariosGrillas());
            SincronizadorCliente.Instancia.AdicionarMgr(new SincronizadorUiControl());
            SincronizadorCliente.Instancia.AdicionarMgr(new SincronizadorImagenesSistema());
            SincronizadorCliente.Instancia.AdicionarMgr(new SincronizadorSincTablas());
            SincronizadorCliente.Instancia.AdicionarMgr(new SincronizadorF_AP_PERSONA());
            SincronizadorCliente.Instancia.AdicionarMgr(new SincronizadorF_AP_RCONTACTO());
            SincronizadorCliente.Instancia.AdicionarMgr(new SincronizadorF_AU_USUARIOS());
            SincronizadorCliente.Instancia.AdicionarMgr(new SincronizadorF_AP_RPERSONA_ROLSIN());
            SincronizadorCliente.Instancia.AdicionarMgr(ModeloMgr.Instancia.ComponenteMgr as IMgrLocal);
        }
    }
}
