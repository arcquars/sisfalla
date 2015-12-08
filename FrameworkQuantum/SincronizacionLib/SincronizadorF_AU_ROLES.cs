using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using System.Data;
using Oracle.DataAccess.Client;

namespace CNDC.Sincronizacion
{
    public class SincronizadorF_AU_ROLES : OraDalBaseMgr, IMgrLocal
    {
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT COUNT( * )
            FROM F_AU_ROLES
            WHERE NUM_ROL=:NUM_ROL";
            cmd.BindByName = true;
            cmd.Parameters.Add("NUM_ROL", row["NUM_ROL"]);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = @"INSERT INTO F_AU_ROLES(num_rol,nombre_corto,descripcion,jerarquia,d_cod_estado,sec_log,sinc_ver)
            VALUES(:num_rol,:nombre_corto,:descripcion,:jerarquia,:d_cod_estado,:sec_log,:sinc_ver)";
            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = @"UPDATE f_au_roles SET 
            nombre_corto=:nombre_corto,
            descripcion=:descripcion,
            jerarquia=:jerarquia,
            d_cod_estado=:d_cod_estado,
            sec_log=:sec_log,
            sinc_ver=:sinc_ver
            WHERE num_rol=:num_rol";
            InsertUpdate(rows, sql);
        }

        public override string NombreTabla
        {
            get { return "F_AU_ROLES"; }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(CrearParametroEntrada("num_rol", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("nombre_corto", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("descripcion", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("jerarquia", OracleDbType.Int16, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("D_COD_ESTADO", OracleDbType.Varchar2, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SEC_LOG", OracleDbType.Int64, tabla));
            cmd.Parameters.Add(CrearParametroEntrada("SINC_VER", OracleDbType.Int64, tabla));


            Actualizar(cmd);
        }
    }
}
