using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using ModeloSisFalla;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.DAL;
using CNDC.BLL;
using CNDC.Sincronizacion;

namespace OraDalSisFalla
{
    public class OraDalColapsoMgr : OraDalBaseMgr, IColapsoMgr, IMgrLocal, IProveedorDatosSincronizacion
    {
        public OraDalColapsoMgr()
        {

        }
        public OraDalColapsoMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Guardar(Colapso obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                sql = "INSERT INTO {0} ({1},{2})" +
                "VALUES(:{1},:{2})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{1}=:{1} ," +
                "{2}=:{2}  WHERE ";
            }

            sql = string.Format(sql, Colapso.NOMBRE_TABLA, Colapso.C_PK_COD_FALLA,
            Colapso.C_PK_D_COD_ZONA);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(Colapso.C_PK_COD_FALLA, OracleDbType.Int32, obj.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Colapso.C_PK_D_COD_ZONA, OracleDbType.Int64, obj.PkDCodZona, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(Colapso.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<Colapso> GetLista()
        {
            BindingList<Colapso> resultado = new BindingList<Colapso>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new Colapso(row));
            }
            return resultado;
        }


        public List<Colapso> GetLista(int numFalla)
        {
            List<Colapso> resultado = new List<Colapso>();
            string sql =
            @"SELECT * FROM F_GF_COLAPSO WHERE PK_COD_FALLA=:PK_COD_FALLA";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(Colapso.C_PK_COD_FALLA, OracleDbType.Int32, numFalla, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add(new Colapso(r));
            }
            return resultado;
        }


        public void Guardar(List<Colapso> listaColapso, int numFalla)
        {
            string sql =
            @"DELETE FROM F_GF_COLAPSO WHERE PK_COD_FALLA=:PK_COD_FALLA";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(Colapso.C_PK_COD_FALLA, OracleDbType.Int32, numFalla, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            Actualizar(cmd);

            foreach (var c in listaColapso)
            {
                c.PkCodFalla = numFalla;
                c.EsNuevo = true;
                Guardar(c);
            }
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = "INSERT INTO {0} ({1},{2},{3})" +
            "VALUES(:{1},:{2},:{3})";
            InsertUpdate(sql, rows);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = "UPDATE {0} SET " +
            "{2}=:{2} ," +
            "{3}=:{3}  WHERE {1}=:{1}";
            InsertUpdate(sql, rows);
        }

        public void InsertUpdate(string sql, List<DataRow> tabla)
        {
            sql = string.Format(sql, Colapso.NOMBRE_TABLA, Colapso.C_PK_COD_FALLA,
                  Colapso.C_PK_D_COD_ZONA, Colapso.C_SINC_VER);

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(Colapso.C_PK_COD_FALLA, OracleDbType.Int32, GetArray(tabla, Colapso.C_PK_COD_FALLA), ParameterDirection.Input);
            cmd.Parameters.Add(Colapso.C_PK_D_COD_ZONA, OracleDbType.Int64, GetArray(tabla, Colapso.C_PK_D_COD_ZONA), ParameterDirection.Input);
            cmd.Parameters.Add(Colapso.C_SINC_VER, OracleDbType.Int64, GetArray(tabla, Colapso.C_SINC_VER), ParameterDirection.Input);

            Actualizar(cmd);
        }

        public string NombreTabla
        {
            get { return Colapso.NOMBRE_TABLA; }
        }

        public DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial)
        {
            DataTable resultado = null;
            string sql = string.Empty;
            if (parcial)
            {
                sql = @"SELECT a.*
                FROM F_GF_COLAPSO a
                WHERE a.sinc_ver > :sinc_ver 
                AND a.pk_cod_falla IN 
                (SELECT b.pk_cod_falla
                FROM f_gf_notificacion b
                WHERE b.pk_cod_persona=:pk_cod_persona AND b.D_COD_ESTADO_NOTIFICACION <> 41)";
            }
            else
            {
                sql = @"SELECT a.*
                FROM F_GF_COLAPSO a
                WHERE a.sinc_ver > :sinc_ver ";
            }
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("sinc_ver", OracleDbType.Decimal, versionCliente, ParameterDirection.Input);
            if (parcial)
            {
                cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, pkCodPersona, ParameterDirection.Input);
            }
            cmd.BindByName = true;

            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public DataTable GetDatos(int pkCodFalla)
        {
            DataTable resultado = null;
            string sql = @"SELECT * FROM F_GF_COLAPSO
                WHERE pk_cod_falla=:pk_cod_falla";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int64, pkCodFalla, ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);
            resultado.TableName = "F_GF_COLAPSO";
            return resultado;
        }

        public override bool Existe(string nombreTabla, DataRow row)
        {
            string sql = @"DELETE FROM F_GF_COLAPSO WHERE pk_cod_falla=:pk_cod_falla";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, (int)row["pk_cod_falla"], System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            Actualizar(cmd);

            return false;
        }
    }
}
