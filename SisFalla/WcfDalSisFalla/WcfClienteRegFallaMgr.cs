using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloSisFalla;
using CNDC.UtilesComunes;
using System.Data;
using CNDC.BLL;

namespace WcfDalSisFalla
{
    public class WcfClienteRegFallaMgr : IRegFallaMgr
    {
        public void Guardar(RegFalla regFalla)
        {
            
        }

        public DataTable GetTabla()
        {
            byte[] b = WcfServicioMgr.Instancia.Servicio.GetTabla(Sesion.Instancia.TokenSession, "F_GF_REGFALLA");
            DataTable resultado = Serializador.DeSerializar<DataTable>(b);
            return resultado;
        }
        public DataTable GetGestiones()
        {
            throw new NotImplementedException();
        }

        public DataTable GetAgentesInvolucrados()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRegistrosXGestion(int Gestion)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRegistros(string codigo)
        {
            throw new NotImplementedException();
        }

        public bool Existe(DataRow row, DataTable tablaLocal)
        {
            return true;
        }

        public int GetSiguienteNumFalla()
        {
            throw new NotImplementedException();
        }

        public bool ExisteNumeroFalla(int codigo)
        {
            throw new NotImplementedException();
        }
        public DataTable GetTablaFallas(long pk_cod_pesona, CNDC.Dominios.D_COD_ESTADO_INF? filtroEstadoInforme)
        {
            throw new NotImplementedException();
        }

        public RegFalla GetFalla(int numFalla)
        {
            throw new NotImplementedException();
        }

        public void GuardarCodColapso(int numFalla, CNDC.Dominios.D_COD_COLAPSO codColapso)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(int numFalla, string motivo)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTablaFallas(CNDC.Dominios.D_COD_ESTADO_INF? _filtroEstadoInforme)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTablaFallasSinInformes()
        {
            throw new NotImplementedException();
        }

        public System.ComponentModel.BindingList<Persona> GetAgentesNotificados(int p)
        {
            throw new NotImplementedException();
        }

        public System.ComponentModel.BindingList<Persona> GetAgentesSinNotificar(int p)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAgentesInvolucrados(int p)
        {
            throw new NotImplementedException();
        }


        public bool EstaInvolucrado(int pkCodFalla, long pkCodPersona)
        {
            throw new NotImplementedException();
        }
        public void IncrementarSincVer(int pkCodFalla)
        { throw new NotImplementedException(); 
        }
    }
}
