using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.DAL;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.BLL;

namespace DifusionInformacion
{
    class OraDalSpectrumMgr
    {
        private ConnexionOracleMgr conexion;


        public OraDalSpectrumMgr(string connectionString)
        {
            conexion = new ConnexionOracleMgr(connectionString);
            conexion.AsegurarConexion();
        }
        public void FinalizarConexion()
        {
            if (conexion != null && conexion.EstadoConexion == ConnectionState.Open)
            {
                conexion.FinalizarConexion();
                conexion.Dispose();
                conexion = null;
            }
        }
        internal void Guardar(List<double> datos,DateTime fechaDatos, string configEtiqueta)
        {
            string query = string.Empty;
            try
            {

                BorrarDatosDia(fechaDatos, configEtiqueta);

                query = "INSERT INTO SPECTRUM.DATOS_GRAFICO ({0},{1},{2},{3},{4},{5}) VALUES (1,:{1},:{2},:{3},:{4},:{5})";

                query = string.Format(query,
                        "ID",
                        "FECHA",
                        "VALOR",
                        "FECHA_SNG",
                        "INTERVALO",
                        "TYPE"
                        );
                if (conexion.EstadoConexion == ConnectionState.Open && datos.Count > 0)
                {
                    OracleCommand cmd = conexion.CrearCommand();
                    int intervalo = 1;
                    foreach (double valorDato in datos)
                    {
                        cmd.CommandText = query;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("FECHA", OracleDbType.Date, fechaDatos.Date.AddHours(intervalo), ParameterDirection.Input);
                        cmd.Parameters.Add("VALOR", OracleDbType.Double, valorDato, ParameterDirection.Input);
                        cmd.Parameters.Add("FECHA_SNG", OracleDbType.Date, fechaDatos.Date, ParameterDirection.Input);
                        cmd.Parameters.Add("INTERVALO", OracleDbType.Long, intervalo, ParameterDirection.Input);
                        cmd.Parameters.Add("TYPE", OracleDbType.Varchar2, configEtiqueta, ParameterDirection.Input);
                        cmd.BindByName = true;
                        conexion.Actualizar(cmd);
                        intervalo++;
                    }
                }
            }
            catch (Exception ex)
            {
                //return new detallePublicado(fechaDatos.Date.ToString(), "Local Intranet", "Fallo : " + ex.Message);
            }
        }

        private void BorrarDatosDia(DateTime fechaDatos, string configEtiqueta)
        {
            string query = string.Empty;
            try
            {
                    query = "DELETE FROM SPECTRUM.DATOS_GRAFICO WHERE {0} = :{0} AND {1} = :{1}";

                    query = string.Format(query,
                            "FECHA_SNG",
                            "TYPE"
                            );
                    if (conexion.EstadoConexion == ConnectionState.Open)
                    {

                        OracleCommand cmd = conexion.CrearCommand();
                        cmd.CommandText = query;
                        cmd.Parameters.Add("FECHA_SNG", OracleDbType.Date, fechaDatos.Date, ParameterDirection.Input);
                        cmd.Parameters.Add("TYPE", OracleDbType.Varchar2, configEtiqueta, ParameterDirection.Input);
                        cmd.BindByName = true;

                        conexion.Actualizar(cmd);
                    }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string GetCadConexionSpectrum()
        {
            string resultado = string.Empty;
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = @"SELECT
            B.CADENA_CONEXION AS CADENA_CONEXION
            FROM
            P_DEF_SERVIDOR A
            INNER JOIN P_DEF_CONEXION B ON B.COD_SERVIDOR = A.COD_SERVIDOR
            WHERE
            A.NOMBRE_SERVIDOR LIKE '%spectrum%'
            ";

            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = tabla.Rows[0][0].ToString();
            }
            return resultado;
        }



    }
}
