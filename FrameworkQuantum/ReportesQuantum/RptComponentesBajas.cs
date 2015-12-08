using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.Dominios;
using System.Windows.Forms;

namespace ReportesQuantum
{
    public class RptComponentesBajas : ProveedorDatosBase
    {
        private DateTime _fechaVigencia;
        public RptComponentesBajas()
        {
            _fechaVigencia = GetUltimaFecha();
        }

        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
                            p.NOM_PERSONA AS NOM_EMPRESA,
                            p.SIGLA,
                            c.CODIGO_COMPONENTE,
                            c.DESCRIPCION_COMPONENTE AS DESCRIPCION,
                            c.NOMBRE_COMPONENTE AS NOMBRE_PORAGENTE,
                            e.DESCRIPCION_TIPO AS TIPO_COMPONENTE,
                            :fecha as FECHA_VIGENCIA

                  FROM f_ac_componente c ,
                  (SELECT n.PK_COD_COMPONENTE ,
                  n.PK_COD_NODO ,
                  n.D_COD_TIPO_RELACION ,
                  n.FECHA_INGRESO ,
                  n.FECHA_SALIDA,
                  m.sigla_nodo
                 FROM f_ac_rcomponente_nodo n,
                  f_ac_nodo m
                  WHERE d_cod_tipo_relacion = 3602
                  AND n.pk_cod_nodo = m.pk_cod_nodo
                  and :fecha between m.fecha_ingreso and nvl (m.fecha_salida, :fecha+1)
                  ) o,
                  (SELECT n.PK_COD_COMPONENTE ,
                  n.PK_COD_NODO ,
                  n.D_COD_TIPO_RELACION ,
                  n.FECHA_INGRESO ,
                  n.FECHA_SALIDA,
                  m.sigla_nodo
                  FROM f_ac_rcomponente_nodo n,
                  f_ac_nodo m
                  WHERE d_cod_tipo_relacion = 3603
                  AND n.pk_cod_nodo = m.pk_cod_nodo
                  and :fecha between m.fecha_ingreso and nvl (m.fecha_salida, :fecha+1)
                  ) d ,
                  P_AC_TIPOCOMPONENTE e ,
                  f_ap_persona p
                  WHERE c.pk_cod_componente = o.pk_cod_componente
                  AND c.pk_cod_componente = d.pk_cod_componente (+)
                  AND :fecha BETWEEN o.fecha_ingreso AND NVL(o.fecha_salida, :fecha+ 1)

                      AND c.d_tipo_componente= e.PK_COD_TIPO_COMPONENTE
                  AND p.pk_cod_persona = c.propietario
                  and o.fecha_salida = :fecha
                  order by 1";

            OracleCommand cmd = CrearComando(sql);
            cmd.CommandText = sql;
            cmd.Parameters.Add("fecha", OracleDbType.Date, _fechaVigencia, ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable tablaDetalleDominio = null;
            tablaDetalleDominio =  EjecutarComando(cmd, "ComponentesAgente");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override TipoPanel GetTipoPanel()
        {
            return TipoPanel.Parametros;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }

        public override bool PuedeConfigurarParametros()
        {
            return true;
        }
        private DataTable GenerarFechas()
        {
            string sql =
         @"SELECT to_char(a.fecha_v,'dd/MM/yyyy') as FECHA_VIGENCIA, to_char(a.fecha_v,'dd/MM/yyyy') as FECHA_VALOR
            from
            (select distinct (FECHA_SALIDA) as fecha_v from f_ac_componente
              where not FECHA_SALIDA is null
              order by 1 DESC
            ) a";

            OracleCommand cmd = CrearComando(sql);
            cmd.CommandText = sql;
            cmd.BindByName = true;
            DataTable tablaDetalleDominio = null;
            tablaDetalleDominio = EjecutarComando(cmd, "FechasDisponibles");
            return tablaDetalleDominio;
   
        }

        private DateTime GetUltimaFecha()
        {
            DataTable resultado = null;
            string fechaMaxima = string.Empty;
            string sql =
            @"SELECT to_char(a.fecha_v,'dd/MM/yyyy') as FECHA_MAX
            from
            (select max(FECHA_SALIDA) as fecha_v from f_ac_componente
              where not FECHA_SALIDA is null
            ) a";
            OracleCommand cmd = CrearComando(sql);
            cmd.CommandText = sql;
            cmd.BindByName = true;
            resultado = EjecutarComando(cmd, "UltimaFecha");
            if (resultado.Rows.Count > 0)
            {
                return Convert.ToDateTime(resultado.Rows[0]["FECHA_MAX"]);
            }
            else
            {
                return DateTime.Now.Date;
            }
        }
        public override bool ConfigurarParametros()
        {
            bool resultado = false;
            DialogResult dr = new DialogResult();
            FormParametroFecha frmNuevo = new FormParametroFecha();
            
            frmNuevo.SetFechaVigencia(GenerarFechas());
            dr = frmNuevo.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _fechaVigencia = frmNuevo.GetfechaVigencia().Date;
                resultado = true;
            }
            
            return resultado;
        }
    }
}
