using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.BLL;

namespace BLL
{
    public class ColumnStyleManger 
    {
        public static List<EstiloColumna> GetEstilos(string formName, string gridName)
        {
            List<EstiloColumna> listaEstilos = new List<EstiloColumna>();

            OracleCommand command = Sesion.Instancia.Conexion.CrearCommand();

            command.CommandText = @"SELECT b.DGVCOLUMN, b.TEXTO_COLUMNA, nvl(b.FORMATO_COLUMNA,' '), b.ALINEACION_COLUMNA, b.ANCHO_COLUMNA,nvl( b.MULTILINEA_COLUMNA,0) ,a.DISLPLAYINDEX
                                        FROM P_GF_FORMULARIOSGRILLAS A, P_GF_ESTILOCOLUMNAS B
                                        WHERE a.dgvcolumn =b.dgvcolumn AND upper(a.form) = upper(:p_FormName) AND upper(a.datagridview) = upper(:p_gridName)
                                        ORDER BY DISLPLAYINDEX ";

            command.Parameters.Add (new OracleParameter ("p_FormName",OracleDbType.Varchar2 ,formName ,System.Data.ParameterDirection.Input ));
            command.Parameters.Add(new OracleParameter("p_gridName", OracleDbType.Varchar2, gridName, System.Data.ParameterDirection.Input));
            OracleDataReader odr = null;
            try
            {
                odr = command.ExecuteReader();
                EstiloColumna estilo;
                string alineacion = string.Empty;
                int multilinea = 0;
                while (odr.Read())
                {
                    estilo = new EstiloColumna();
                    estilo.NombreColumna = odr.GetString(0);
                    estilo.TextoColumna = odr.GetString(1);
                    estilo.Formato = odr.GetString(2);
                    alineacion = odr.GetString(3);
                    switch (alineacion)
                    {
                        case "LEFT":
                            estilo.Alineacion = AlineacionColumna.Izq;
                            break;
                        case "RIGHT":
                            estilo.Alineacion = AlineacionColumna.Der;
                            break;
                        case "CENTER":
                            estilo.Alineacion = AlineacionColumna.Centro;
                            break;
                    }

                    estilo.Ancho = (int)odr.GetDecimal(4);
                    multilinea = (int)odr.GetDecimal(5);
                    if (multilinea == 0)
                    {
                        estilo.MultiLinea = false;
                    }
                    else
                    {
                        estilo.MultiLinea = true;
                    }
                    listaEstilos.Add(estilo);
                }
            }
            catch (OracleException e)
            {
                PistaMgr.Instance.Error("SisFalla", e);
            }
            catch (Exception e)
            {
                PistaMgr.Instance.Error("SisFalla", e);
            }
            finally
            {
                if (odr != null)
                {
                    odr.Close();
                    odr.Dispose();
                }
                
                Sesion.Instancia.Conexion.DisposeCommand(command);
            }
            return listaEstilos;
        }
    }
}
