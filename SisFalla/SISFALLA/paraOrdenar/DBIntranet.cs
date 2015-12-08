using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.BLL;
using CNDC.UtilesComunes;
using CNDC.Pistas;
namespace SISFALLA
{
    class DBIntranet
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        
        public DBIntranet()
        {
            Initialize(13);
        }

        private void Initialize(int num)
        {
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();

            cmd.CommandText = @"SELECT
                                    P_DEF_CONEXION.USUARIO,
                                    P_DEF_CONEXION.PASSWORD,
                                    P_DEF_CONEXION.TIPO_SERVICIO AS BASE,
                                    P_DEF_SERVIDOR.NOMBRE_SERVIDOR,
                                    P_DEF_SERVIDOR.DIRECCION
                                    FROM
                                    P_DEF_CONEXION,P_DEF_SERVIDOR
                                    where P_DEF_CONEXION.COD_SERVIDOR = P_DEF_SERVIDOR.COD_SERVIDOR AND P_DEF_CONEXION.COD_CONEXION = 13";
            cmd.Parameters.Add("COD_CONEXION", num);
            DataTable tabla = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                server = tabla.Rows[0]["NOMBRE_SERVIDOR"].ToString();
                database = tabla.Rows[0]["BASE"].ToString();
                uid = tabla.Rows[0]["USUARIO"].ToString();
                password = Codifica.DecodeFrom64(tabla.Rows[0]["PASSWORD"].ToString());
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                connection = new MySqlConnection(connectionString);
            }
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("No se puede conectar con el servidor.  Contacte al Administrador");
                        break;

                    case 1045:
                        MessageBox.Show("Invalido Usuario/Password, Favor verificar los datos");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool existe(RegistroPublica regexiste)
        {
            bool val = false;

            string query = @"SELECT * from " + regexiste.tabla + " where {0}=?{0} and {1}=?{1} and {2}=?{2}";
            query = string.Format(query,
                    "idsubmenu",
                    "archivo",
                    "fechadoc");
            if (this.OpenConnection() == true)
            {
                MySqlDataReader dr;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("?idsubmenu", regexiste.idCategoria);
                cmd.Parameters.AddWithValue("?archivo", regexiste.archivo);
                cmd.Parameters.AddWithValue("?fechadoc", regexiste.fechadoc);
                cmd.Prepare();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    val = true;
                }
                this.CloseConnection();
            }
            return val;
        }
        public void Guardar(RegistroPublica registro)
        {
            string query = string.Empty;
            try
            {
                if (existe(registro))
                {
                    query = "UPDATE " + registro.tabla + " SET {1}=?{1},{4}=date_format( sysdate( ) , '%H:%i:%s' ),{3}=?{3},{6}=?{6},{7}=?{7} WHERE {0}=?{0} AND {2}=?{2} AND {5}=?{5}";
                }
                else
                {
                    query = "INSERT INTO " + registro.tabla + " ({0},{1},{2},{3},{4},{5},{6},{7}) VALUES (?{0},?{1},?{2},?{3},date_format( sysdate( ) , '%H:%i:%s' ),?{5},?{6},?{7})";
                }
                query = string.Format(query,
                        "idsubmenu",
                        "titulo",
                        "archivo",
                        "fecha",
                        "hora",
                        "fechadoc",
                        "anio",
                        "num"
                        );
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("?idsubmenu", registro.idCategoria);
                    cmd.Parameters.AddWithValue("?titulo", registro.titulo);
                    cmd.Parameters.AddWithValue("?archivo", registro.archivo);
                    cmd.Parameters.AddWithValue("?fecha", registro.fecha);
                    cmd.Parameters.AddWithValue("?fechadoc", registro.fechadoc);
                    cmd.Parameters.AddWithValue("?anio", String.Format("{0:yyyy}", registro.fechadoc));
                    cmd.Parameters.AddWithValue("?num", registro.num);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("DBIntranet : " + ex.Message);
                PistaMgr.Instance.Error("DBIntranet", ex);
            }
        }

        public void Update()
        {
            string query = "UPDATE archivos SET  WHERE ";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        
        public void Delete()
        {
            string query = "DELETE FROM archivos WHERE ";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }


    }
}
