using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Oracle.DataAccess.Client;

namespace CargarAnalisisFAlla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Cargar( )
        {
            string archivo = @"D:\Envios\0130-14_analisis.pdf";
            string nombreArchivo = Path.GetFileName(archivo);
            
            string sql = string.Empty;
            
                sql = @"INSERT
                        INTO f_gf_doc_analisis
                          (
                            pk_cod_falla,
                            archivo,
                            nombre_doc_analisis                          
                          )
                          VALUES
                          (
                            :pk_cod_falla,
                            :archivo,
                            :nombre_doc_analisis                            
                          )";
           

            byte[] b = File.ReadAllBytes(archivo);
            string connsql = "USER ID=quantum;DATA SOURCE=//192.168.2.13:1521/orcl.cndc.bo;PASSWORD=quantum;PERSIST SECURITY INFO=true;";
            OracleConnection cn = new OracleConnection(connsql );
            try
            {// cn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString ());

                int i = 0 ;
            }
            
            OracleCommand cmd = cn.CreateCommand ();
            cmd.CommandText = sql;
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, 140130, ParameterDirection.Input);
            cmd.Parameters.Add("archivo", OracleDbType.Blob, b, ParameterDirection.Input);
            cmd.Parameters.Add("nombre_doc_analisis", OracleDbType.Varchar2, "0130-14_analisis.pdf", ParameterDirection.Input);
            try 
	{	        
	///	cmd.ExecuteNonQuery();
	}
	catch (Exception e)
	{
		
		Console.WriteLine(e.ToString ());
        int i = 0;
	}
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
