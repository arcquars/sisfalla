using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SISFALLA.Bbi
{
    class Contacto
    {
        static DataTable tablaContactos = new DataTable("Contactos");
        static Contacto()
        {
            CrearTablaContactos();
        }

        public static DataTable GetTabla()
        {
            return tablaContactos;
        }

        private static void CrearTablaContactos()
        {
            DataColumn colCodigo = new DataColumn("CodigoContacto", typeof(string));
            DataColumn colNombre = new DataColumn("Nombre", typeof(string));
            DataColumn colCargo = new DataColumn("Cargo", typeof(string));
            DataColumn colEmail = new DataColumn("Email", typeof(string));
            tablaContactos.Columns.Add(colCodigo);
            tablaContactos.Columns.Add(colNombre);
            tablaContactos.Columns.Add(colCargo);
            tablaContactos.Columns.Add(colEmail);

            AdicionarContacto("COBEE", "Gonzalo Terceros","Supervisor","gterceros@cobee.com");
            AdicionarContacto("COBEE", "Gonzalo Terceros A.", "Supervisor", "gterceros@cobee.com");
            
        }

        private static void AdicionarContacto(string cod, string nombre,string cargo,string email)
        {
            DataRow row = tablaContactos.NewRow();
            row["CodigoContacto"] = cod;
            row["Nombre"] = nombre;
            row["Cargo"] = cargo;
            row["Email"] = email;
            tablaContactos.Rows.Add(row);
        }
    }
}
