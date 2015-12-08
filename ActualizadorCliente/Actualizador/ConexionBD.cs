using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace Actualizador
{
    class ConexionBD
    {
        private OracleConnection _conexion = null;
        public ConexionBD(string cadena)
        {
            _conexion = new OracleConnection(cadena);
        }

        private System.IO.StreamWriter log;

         

        public DataTable EjecutarCmd(OracleCommand cmd)
        {
            DataTable resultado = new DataTable();
            OracleDataAdapter adap = null;
            bool continuar = true;
            int contadorIntentos = 0;
            
             

            while (continuar && contadorIntentos < 3)
            {
                continuar = false;
                try
                {
                    if (_conexion.State != System.Data.ConnectionState.Open)
                    {
                        _conexion.Open();
                    }
                    cmd.Connection = _conexion;
                    adap = new OracleDataAdapter(cmd);
                    adap.Fill(resultado);
                    _conexion.Close();
                }
                catch (OracleException oex)
                {
                    int i = 0;
                }
                catch (Exception ex)
                {
                 
                }
                finally
                {
                 
                }
                contadorIntentos++;
            }
            return resultado;
        }

        public string EjecutarSql(string sql)
        {
            string resultado = string.Empty;
            try
            {
                if (_conexion.State != System.Data.ConnectionState.Open)
                {
                    _conexion.Open();
                }

                OracleCommand cmd = _conexion.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
                //file.WriteLine(ex.ToString ());

                //file.Close();

                resultado = ex.ToString();
            }

            return resultado;
        }
    }
}
