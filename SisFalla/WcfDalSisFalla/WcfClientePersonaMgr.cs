using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloSisFalla;
using System.Data;
using CNDC.UtilesComunes;
using CNDC.BLL;

namespace WcfDalSisFalla
{
    public class WcfClientePersonaMgr : IPersonaMgr
    {
        public void Guardar(Persona p)
        {
        }

        public DataTable GetTabla()
        {
            byte[] b = WcfServicioMgr.Instancia.Servicio.GetTabla(Sesion.Instancia.TokenSession, "F_AP_PERSONA");
            DataTable resultado = Serializador.DeSerializar<DataTable>(b);
            return resultado;
        }

        public DataTable GetAgentes()//TODO retornar agentes
        {
            byte[] b = WcfServicioMgr.Instancia.Servicio.GetTabla(Sesion.Instancia.TokenSession, "F_AP_PERSONA");
            DataTable resultado = Serializador.DeSerializar<DataTable>(b);
            return resultado;
        }


        public System.ComponentModel.BindingList<Persona> GetListaAgentes()
        {
            throw new NotImplementedException();
        }


        public DataTable GetAgentes(long codPersona)
        {
            throw new NotImplementedException();
        }


        public Persona GetAgente(long IdPersona)
        {
            throw new NotImplementedException();
        }


        public Persona GetPersona(long IdPersona)
        {
            throw new NotImplementedException();
        }


        public Persona GetPorPkCodPersona(long p)
        {
            throw new NotImplementedException();
        }
    }
}
