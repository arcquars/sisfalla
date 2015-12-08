using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using CNDC.Pistas;
using Oracle.DataAccess.Client;
using ModeloDemandas;

namespace OraDalDemandas
{
    public class OraDalPersonaTipoAgenteMgr : OraDalBaseMgr, IPersonaTipoAgenteMgr
    {
        #region Singleton
        private static OraDalPersonaTipoAgenteMgr _instancia;
        static OraDalPersonaTipoAgenteMgr()
        {
            _instancia = new OraDalPersonaTipoAgenteMgr();
        }
        public static OraDalPersonaTipoAgenteMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalPersonaTipoAgenteMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return PersonaTipoAgente.NOMBRE_TABLA;
            }
        }

        public void Guardar(PersonaTipoAgente obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demandas", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkPersonaTipo = GetIdAutoNum("SQ_F_DM_PERSONA_TIPO");
                sql = "INSERT INTO {0} ({1},{2},{3},{4})" +
                "VALUES(:{1},:{2},:{3},:{4})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, PersonaTipoAgente.NOMBRE_TABLA, PersonaTipoAgente.C_PK_PERSONA_TIPO,
            PersonaTipoAgente.C_D_COD_TIPO_PERSONA,
            PersonaTipoAgente.C_FK_PERSONSA,
            PersonaTipoAgente.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(PersonaTipoAgente.C_PK_PERSONA_TIPO, OracleDbType.Long, obj.PkPersonaTipo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(PersonaTipoAgente.C_D_COD_TIPO_PERSONA, OracleDbType.Long, obj.DCodTipoPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(PersonaTipoAgente.C_FK_PERSONSA, OracleDbType.Long, obj.FkPersonsa, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(PersonaTipoAgente.C_SEC_LOG, OracleDbType.Long, obj.SecLog, System.Data.ParameterDirection.Input);
            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;

            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(PersonaTipoAgente.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<PersonaTipoAgente> GetLista()
        {
            BindingList<PersonaTipoAgente> resultado = new BindingList<PersonaTipoAgente>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new PersonaTipoAgente(row));
            }
            return resultado;
        }

        public PersonaTipoAgente GetPorIdPersona(long pkPersona)
        {
            PersonaTipoAgente res = null;
            string sql = "SELECT * FROM {0} WHERE {1}={2}";
            sql = string.Format(sql, PersonaTipoAgente.NOMBRE_TABLA, PersonaTipoAgente.C_FK_PERSONSA, pkPersona);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                res = new PersonaTipoAgente();
                res.EsNuevo = false;
                long pkPersonaTipo=(long)tabla.Rows[0][0];
                res = OraDalPersonaTipoAgenteMgr.Instancia.GetPorId<PersonaTipoAgente>(pkPersonaTipo,PersonaTipoAgente.C_PK_PERSONA_TIPO);
            }
            return res;
        }

        public bool ExisteRegistro(long pkPersona)
        {
            bool res = false;
            string sql = "SELECT * FROM F_AP_RPERSONA_ROLSIN WHERE PK_COD_PERSONA={0} and PK_COD_ROL=5";
            sql = string.Format(sql, pkPersona);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                res = true;
            }
            return res;
        }

        public void EliminarRegistro(long pkPersona)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2} ";
            sql = string.Format(sql, PersonaTipoAgente.NOMBRE_TABLA, PersonaTipoAgente.C_FK_PERSONSA,pkPersona);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
