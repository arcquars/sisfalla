using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DifusionInformacion
{
    class WebDBManager
    {
        private MySqlConnection connection;


        public WebDBManager(string connectionString)
        {
                connection = new MySqlConnection(connectionString);
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
                        MessageBox.Show("No se pudo conectar con el servidor SitioWeb.  Contacte al Administrador");
                        break;
                    case 1042:
                        MessageBox.Show("No se pudo encontrar host/servidor SitioWeb.  Contacte al Administrador");
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
        public bool ServidorResponde()
        {
            try
            {
                if (this.OpenConnection())
                {
                    if (connection.Ping())
                    {
                        this.CloseConnection();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool existe(RegistroPublica regexiste)
        {
            bool val = false;
            string query = string.Empty;
            if (regexiste.esPublico)
            {
                query = @"SELECT * from " + regexiste.tabla + " where {0}=?{0} and {1}=?{1} and {2}=?{2}";
                query = string.Format(query,
                        "idsubcategoria",
                        "archivo",
                        "fechadoc");
            }
            else
            {
                query = @"SELECT * from " + regexiste.tabla + " where {0}=?{0} and {1}=?{1} and {2}=?{2} and {3}=?{3}";
                query = string.Format(query,
                        "idsubcategoria",
                        "archivo",
                        "archivo_zip",
                        "fechadoc");
            }
            if (this.OpenConnection() == true)
            {
                MySqlDataReader dr;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                
                cmd.Parameters.AddWithValue("?idsubcategoria", regexiste.idCategoria);
                cmd.Parameters.AddWithValue("?archivo", regexiste.archivo);
                cmd.Parameters.AddWithValue("?archivo_zip", regexiste.archivo_zip);
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
        public detallePublicado Guardar(RegistroPublica registro)
        {
            string query = string.Empty;
            try
            {
                if (existe(registro))
                {
                    if (registro.esPublico)
                    {
                        query = "UPDATE " + registro.tabla + " SET {1}=?{1},{5}=date_format( sysdate( ) , '%H:%i:%s' ),{4}=date_format( sysdate( ) , '%Y-%m-%d' ),{7}=?{7},{8}=?{8} WHERE {0}=?{0} AND {2}=?{2} AND {6}=?{6}";
                    }
                    else
                    {
                        query = "UPDATE " + registro.tabla + " SET {1}=?{1},{5}=date_format( sysdate( ) , '%H:%i:%s' ),{4}=date_format( sysdate( ) , '%Y-%m-%d' ),{7}=?{7},{8}=?{8} WHERE {0}=?{0} AND {2}=?{2} AND {3}=?{3} AND {6}=?{6}";
                    }
                    
                }
                else
                {
                    if (registro.esPublico)
                    {
                        query = "INSERT INTO " + registro.tabla + " ({0},{1},{2},{4},{5},{6},{7},{8}) VALUES (?{0},?{1},?{2},date_format( sysdate( ) , '%Y-%m-%d' ),date_format( sysdate( ) , '%H:%i:%s' ),?{6},?{7},?{8})";
                    }
                    else
                    {
                        query = "INSERT INTO " + registro.tabla + " ({0},{1},{2},{3},{4},{5},{6},{7},{8}) VALUES (?{0},?{1},?{2},?{3},date_format( sysdate( ) , '%Y-%m-%d' ),date_format( sysdate( ) , '%H:%i:%s' ),?{6},?{7},?{8})";
                    }
                    
                }
                query = string.Format(query,
                        "idsubcategoria",
                        "titulo",
                        "archivo",
                        "archivo_zip",
                        "fecha",
                        "hora",
                        "fechadoc",
                        "anio",
                        "num"
                        );
                if (this.OpenConnection() == true)
                {
                    if ((new IntranetDBManager(ConfigPublicacion.conexionIntranet)).ServidorResponde())
                    {
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("?idsubcategoria", registro.idCategoria);
                        cmd.Parameters.AddWithValue("?titulo", registro.titulo);
                        cmd.Parameters.AddWithValue("?archivo", registro.archivo);
                        cmd.Parameters.AddWithValue("?archivo_zip", registro.archivo_zip);

                        cmd.Parameters.AddWithValue("?fechadoc", registro.fechadoc);
                        cmd.Parameters.AddWithValue("?anio", String.Format("{0:yyyy}", registro.fechadoc));
                        cmd.Parameters.AddWithValue("?num", registro.num);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                        this.CloseConnection();
                        return new detallePublicado(registro.archivo, "Remoto Web", "OK, publicado satisfactoriamente");
                    }
                    else
                    {
                        return new detallePublicado(registro.archivo, "Remoto Web", "Fallo, No se publico completamente");
                    }
                }
                else
                {
                    return new detallePublicado(registro.archivo, "Remoto Web", "Fallo : Perdio Conexion");
                }
               
            }
            catch (Exception ex)
            {
                return new detallePublicado(registro.archivo, "Remoto Web", "Fallo : " + ex.Message);
                //MessageBox.Show("DBWeb : " + ex.Message);
                //PistaMgr.Instance.Error("DBWeb", ex);
            } 
        }

    }
}
