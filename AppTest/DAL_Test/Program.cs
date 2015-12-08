using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using CNDC.DAL;
using System.Data;

namespace DAL_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnexionOracleMgr.Instancia.AsegurarConexion();
            OracleCommand cmd = ConnexionOracleMgr.Instancia.CrearCommand();
            string comment = CommentMgr.Instance.GetMessage("IVANMENSAJES", "CODIGO");
            Console.WriteLine(comment);
            Console.WriteLine();
            cmd.CommandText = "SELECT * FROM MENU";
            OracleDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", r[0], r[1], r[2], r[3]);
            }
            r.Close();
            r.Dispose();
            Console.ReadKey();
        }
    }
}
