using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.Dominios;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CNDC.BaseForms;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using MenuQuantum;
using ModeloSisFalla;
using CNDC.BLL;
using Reportes;

namespace repSisfalla
{
    public partial class PantallaReporte 
    {
        private OracleCommand cmd;
        private DataSet ds = new DataSet();
        public PantallaReporte()
        {
        }

        private void agregarConsulta(string sql)
        {
            cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
        }

        private void agregarParametro(string param1, string valor1)
        {
            if (!string.IsNullOrEmpty(param1))
            {
                cmd.Parameters.Add(param1, OracleDbType.Varchar2, valor1, System.Data.ParameterDirection.Input);
            }
        }

        private void agregarTabla(string nomTabla)
        {
            OracleDataAdapter adap = new OracleDataAdapter(cmd);
            adap.Fill(ds, nomTabla);
        }

        private void agregarDataTabla(DataTable nomTabla)
        {
            ds.Tables.Add(nomTabla);
        }

        private bool GenerarReporte(string rep, string tit, int codReporte, string parametro, string numInforme, string tipoInfFallaParam, string agenteParam)
        {
            string strSql = string.Empty;
            string strSql2 = string.Empty;
            bool grupos = false;
            bool parametros = false;
            try
            {
                
                if (ds.Tables["Superior"].Rows.Count > 0)
                {
                    switch (codReporte)
                    {

                        case 106:
                        case 107:
                        case 108:
                        case 109:
                        case 110:
                        case 111:
                        case 112:
                        case 113:
                        case 114:
                        case 115:
                        case 116:

 
                            break;
                        case 122:
                            
                            break;
                        case 123:
                           
                            break;
                        case 124:
                            
                            break;
                        case 125:
                            
                            break;
                        case 126:

                            break;                        
                        case 128:
                            

                            break;
                        case 129:


                            break;
                        case 130:

                            break;
                        case 133:
                            

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Qry : " + ex.Message);
            }
            return true;
        }
    }
}
