using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using CNDC.Dominios;
using ModeloSisFalla;

namespace SISFALLA
{
    public interface IProveedorTablaRegFalla
    {
        DataTable GetTablaRegFalla();
    }

    public class ProveedorPorEstado : IProveedorTablaRegFalla
    {
        D_COD_ESTADO_INF? _filtroEstadoInforme = null;
        private string _nombre;
        public ProveedorPorEstado(string nombre, D_COD_ESTADO_INF? f)
        {
            _nombre = nombre;
            _filtroEstadoInforme = f;
        }

        public DataTable GetTablaRegFalla()
        {
            DataTable resultado = ModeloMgr.Instancia.RegFallaMgr.GetTablaFallas(_filtroEstadoInforme);
            return resultado;
        }

        public override string ToString()
        {
            return _nombre;
        }
    }

    public class ProveedorPorNotif : IProveedorTablaRegFalla
    {
        public DataTable GetTablaRegFalla()
        {
            DataTable resultado = ModeloMgr.Instancia.RegFallaMgr.GetTablaFallasSinInformes();
            return resultado;
        }

        public override string ToString()
        {
            return "Notificaciones";
        }
    }
}
