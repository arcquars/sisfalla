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
    public class ProveedorPorAgente : IProveedorTablaRegFalla
    {
        private string _nombre;
        private long _pk_cod_persona; 
        public ProveedorPorAgente(string nombre  , long pk_cod_persona)
        {
            _nombre = nombre;
            _pk_cod_persona = pk_cod_persona;
           
     
        }

        public DataTable GetTablaRegFalla()
        {
            DataTable resultado = ModeloMgr.Instancia.RegFallaMgr.GetTablaFallas(_pk_cod_persona, null);
            return resultado;
        }

        public override string ToString()
        {
            return _nombre;
        }
    }
    public class ProveedorPorEstado :IProveedorTablaRegFalla
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
        private string _nombre;

        public ProveedorPorNotif(string nombre)
        {
            _nombre = nombre;
        }
        public DataTable GetTablaRegFalla( )
        {
        
            DataTable resultado = ModeloMgr.Instancia.RegFallaMgr.GetTablaFallasSinInformes();
            return resultado;
        }

        public override string ToString()
        {
            return _nombre ;
        }
    }

    public class ActualizadorTablaRegFalla
    {
        public static void Actualizar(DataTable origen, DataTable destino)
        {
            if (origen.Rows.Count != destino.Rows.Count)
            {
                foreach (DataRow r in origen.Rows)
                {
                    DataRow rowAActualizar = null;
                    foreach (DataRow r1 in destino.Rows)
                    {
                        if ((int)r[RegFalla.C_PK_COD_FALLA] == (int)r1[RegFalla.C_PK_COD_FALLA])
                        {
                            rowAActualizar = r1;
                            break;
                        }
                    }

                    if (rowAActualizar == null)
                    {
                        rowAActualizar = destino.NewRow();
                        destino.Rows.Add(rowAActualizar);
                    }

                    foreach (DataColumn col in origen.Columns)
                    {
                        rowAActualizar[col.ColumnName] = r[col.ColumnName];
                    }
                }

                for (int i = destino.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow rd = destino.Rows[i];
                    bool encontrado = false;
                    foreach (DataRow ro in origen.Rows)
                    {
                        if ((int)rd[RegFalla.C_PK_COD_FALLA] == (int)ro[RegFalla.C_PK_COD_FALLA])
                        {
                            encontrado = true;
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        destino.Rows.Remove(rd);
                    }
                }
            }
        }
    }
}
