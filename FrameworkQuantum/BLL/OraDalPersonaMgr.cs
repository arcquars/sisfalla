using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using System.ComponentModel;
using CNDC.Pistas;

namespace CNDC.BLL
{
    public class OraDalPersonaMgr : OraDalBaseMgr, IPersonaMgr
    {
        #region Singleton
        private static OraDalPersonaMgr _instancia;
        bool _esNuevo = true;
        static OraDalPersonaMgr()
        {
            _instancia = new OraDalPersonaMgr();
        }
        public static OraDalPersonaMgr Instancia
        {
            get { return _instancia; }
        }

        public OraDalPersonaMgr()
        {

        }

        public OraDalPersonaMgr(ConnexionOracleMgr c)
            : base(c)
        {

        }
        #endregion Singleton
        public const string NOMBRE_TABLA = "F_AP_PERSONA";
        public void Guardar(Persona obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkCodPersona = GetIdAutoNum("SQV_F_AP_PERSONA");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10})";
                _esNuevo = true;
            }
            else
            {
                _esNuevo = false;
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6} ," +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, NOMBRE_TABLA, Persona.C_PK_COD_PERSONA,
            Persona.C_NOM_PERSONA,
            Persona.C_SIGLA,
            Persona.C_D_COD_TIPO_PERSONA,
            Persona.C_DIRECCION,
            Persona.C_TELEFONO,
            Persona.C_IDENTIFICACION,
            Persona.C_D_COD_ESTADO,
            Persona.C_SEC_LOG,
            Persona.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(Persona.C_PK_COD_PERSONA, OracleDbType.Int64, obj.PkCodPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_NOM_PERSONA, OracleDbType.Varchar2, obj.Nombre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_SIGLA, OracleDbType.Varchar2, obj.Sigla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_D_COD_TIPO_PERSONA, OracleDbType.Int64, obj.DCodTipoPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_DIRECCION, OracleDbType.Varchar2, obj.Direccion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_TELEFONO, OracleDbType.Varchar2, obj.Telefono, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_IDENTIFICACION, OracleDbType.Varchar2, obj.Identificacion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);
            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
            if (_esNuevo)
            {
                GuardarRPersonaRolSIN(obj.PkCodPersona);
            }
        }

        private void GuardarRPersonaRolSIN(long pkPersona)
        {
            OracleCommand cmd = CrearCommand();
            string sql = "INSERT INTO {0} ({1},{2},{3}) VALUES(:{1},:{2},:{3})";
            sql = string.Format(sql, "F_AP_RPERSONA_ROLSIN",
               "PK_COD_PERSONA",
               "PK_COD_ROL",
               "D_COD_ESTADO");
            cmd = CrearCommand();
            cmd.CommandText = sql;
            //cmd.BindByName = true;
            cmd.Parameters.Add("PK_COD_PERSONA",pkPersona);
            cmd.Parameters.Add("PK_COD_ROL",  4);
            cmd.Parameters.Add("D_COD_ESTADO", "1");
            bool res = Actualizar(cmd);
        }
                  

        public override string NombreTabla
        { get { return NOMBRE_TABLA; } }

        public DataTable GetTabla()
        {
            return GetTabla(NOMBRE_TABLA);
        }

        public Persona GetPersona(long IdPersona)
        {
            Persona resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT Sigla || ' - ' || NOM_PERSONA NOM_COD_AGENTE, PK_COD_PERSONA, NOM_PERSONA, SIGLA, D_COD_TIPO_PERSONA, DIRECCION, TELEFONO, IDENTIFICACION, D_COD_ESTADO, SEC_LOG, SINC_VER
            FROM F_AP_PERSONA
            WHERE D_COD_TIPO_PERSONA=:D_COD_TIPO_PERSONA
            AND PK_COD_PERSONA  =:P_PK_COD_PERSONA
            ORDER BY sigla";
            cmd.Parameters.Add("D_COD_TIPO_PERSONA", 18);
            cmd.Parameters.Add("P_PK_COD_PERSONA", IdPersona);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new Persona(tabla.Rows[0]);
            }
            return resultado;
        }

        public Persona GetAgente(long IdPersona)
        {
            Persona resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT Sigla || ' - ' || NOM_PERSONA NOM_COD_AGENTE, PK_COD_PERSONA, NOM_PERSONA, SIGLA, D_COD_TIPO_PERSONA, DIRECCION, TELEFONO, IDENTIFICACION, D_COD_ESTADO, SEC_LOG, SINC_VER
            FROM F_AP_PERSONA
            WHERE D_COD_TIPO_PERSONA=:D_COD_TIPO_PERSONA
            AND PK_COD_PERSONA  =:P_PK_COD_PERSONA
            ORDER BY sigla";
            cmd.Parameters.Add("D_COD_TIPO_PERSONA", 19);
            cmd.Parameters.Add("P_PK_COD_PERSONA", IdPersona);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new Persona(tabla.Rows[0]);
            }
            return resultado;
        }

        public DataTable GetAgentes()
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT a.Sigla || ' - ' || a.NOM_PERSONA NOM_COD_AGENTE, a.PK_COD_PERSONA, 
            a.NOM_PERSONA, a.SIGLA, a.D_COD_TIPO_PERSONA, a.DIRECCION, a.TELEFONO, a.IDENTIFICACION,
            a.D_COD_ESTADO, a.SEC_LOG, a.SINC_VER 
            FROM F_AP_PERSONA a,F_AP_RPERSONA_ROLSIN b 
            WHERE
            a.D_COD_TIPO_PERSONA=:D_COD_TIPO_PERSONA 
            AND b.PK_COD_PERSONA=a.PK_COD_PERSONA AND
            b.PK_COD_ROL=2 
            ORDER BY a.Sigla";
            cmd.Parameters.Add("D_COD_TIPO_PERSONA", 19);
            DataTable tabla = EjecutarCmd(cmd);
            return tabla;
        }

        public DataTable GetAgentes(long codPersona)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT Sigla || ' - ' || NOM_PERSONA NOM_COD_AGENTE, PK_COD_PERSONA, NOM_PERSONA, SIGLA, D_COD_TIPO_PERSONA, DIRECCION, TELEFONO, IDENTIFICACION, D_COD_ESTADO, SEC_LOG, SINC_VER
            FROM F_AP_PERSONA
            WHERE D_COD_TIPO_PERSONA=:D_COD_TIPO_PERSONA
            AND PK_COD_PERSONA=:PK_COD_PERSONA 
            ORDER BY sigla";
            cmd.Parameters.Add("D_COD_TIPO_PERSONA", 19);
            cmd.Parameters.Add("PK_COD_PERSONA", codPersona);
            DataTable tabla = EjecutarCmd(cmd);
            return tabla;
        }

        public BindingList<Persona> GetListaAgentes()
        {
            BindingList<Persona> resultado = new BindingList<Persona>();
            DataTable tablaAgentes = GetAgentes();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new Persona(row));
            }
            return resultado;
        }

        public Persona GetPorPkCodPersona(long pkcodPersona)
        {
            Persona resultado = null;
            string sql = "SELECT Sigla || ' - ' || NOM_PERSONA NOM_COD_AGENTE, PK_COD_PERSONA, NOM_PERSONA, SIGLA, D_COD_TIPO_PERSONA, DIRECCION, TELEFONO, IDENTIFICACION, D_COD_ESTADO, SEC_LOG, SINC_VER from {0} where {1}=:{1}";
            sql = string.Format(sql, NOMBRE_TABLA, Persona.C_PK_COD_PERSONA);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;

            cmd.Parameters.Add(Persona.C_PK_COD_PERSONA, pkcodPersona);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new Persona(tabla.Rows[0]);
            }
            return resultado;
        }

        public DataTable GetEntidadResponsableProyectos()
        {
            string sql = @" select p.* from f_ap_persona p, p_def_cat_dominios d 
                            where p.d_cod_tipo_persona= d.cod_cat_dominio and d.cod_cat_dominio=19 
                            and p.pk_cod_persona in (select r.pk_cod_persona from f_ap_rpersona_rolsin r
                            where r.pk_cod_rol=4)";

            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }


        public DataTable GetEntidadResponsable()
        {
            string sql = @"select p.PK_COD_PERSONA, p.NOM_PERSONA as ENTIDAD_O_AGENTE, p.SIGLA, p.DIRECCION, p.TELEFONO from f_ap_persona p, p_def_cat_dominios d 
                            where p.d_cod_tipo_persona= d.cod_cat_dominio and d.cod_cat_dominio=19 
                            and p.pk_cod_persona in (select r.pk_cod_persona from f_ap_rpersona_rolsin r
                            where r.pk_cod_rol=4) ";
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public DataTable GetEntidadResponsableDemandas()
        {
//            string sql = @"select p.PK_COD_PERSONA, p.NOM_PERSONA as EMPRESA, p.SIGLA, p.DIRECCION, p.TELEFONO from f_ap_persona p, p_def_cat_dominios d 
//                            where p.d_cod_tipo_persona= d.cod_cat_dominio and d.cod_cat_dominio=19 
//                            and p.pk_cod_persona in (select r.pk_cod_persona from f_ap_rpersona_rolsin r
//                            where r.pk_cod_rol=5) order by p.PK_COD_PERSONA";
            string sql = @"select p.PK_COD_PERSONA, p.NOM_PERSONA as EMPRESA, p.SIGLA , ta.descripcion_dominio as TIPO_AGENTE
                            from f_ap_persona p, F_DM_R_PERSONA_TIPO pt ,  p_def_dominios ta

                            where  pt.d_cod_tipo_persona=ta.cod_dominio 
                            and pt.fk_personsa= p.pk_cod_persona
                            and p.pk_cod_persona in (select r.pk_cod_persona from f_ap_rpersona_rolsin r
                            where r.pk_cod_rol=5)
                            and p.pk_cod_persona in ( select p.PK_COD_PERSONA from f_ap_persona p, p_def_cat_dominios d 
                                                        where p.d_cod_tipo_persona= d.cod_cat_dominio and d.cod_cat_dominio=19 )
                            order by p.PK_COD_PERSONA";
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public DataTable GetTablaAgentesDemandas()
        {
            string sql = @"select p.PK_COD_PERSONA, p.NOM_PERSONA as ENTIDAD_O_AGENTE, p.SIGLA, p.DIRECCION, p.TELEFONO from f_ap_persona p, p_def_cat_dominios d 
                            where p.d_cod_tipo_persona= d.cod_cat_dominio and d.cod_cat_dominio=19 
                            and p.pk_cod_persona in (select r.pk_cod_persona from f_ap_rpersona_rolsin r
                            where r.pk_cod_rol=5) ";
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public DataTable GetTablaAgentesDeTipoDemandas(int codDominioTipoAgente)
        {
            string sql = @"select p.PK_COD_PERSONA, p.NOM_PERSONA as EMPRESA, p.SIGLA from f_ap_persona p  
                            WHERE p.pk_cod_persona in (select pt.FK_PERSONSA from F_DM_R_PERSONA_TIPO pt where pt.d_cod_tipo_persona={0}) ";
            sql = string.Format(sql,codDominioTipoAgente);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public DataTable GetListaAgentesDeTipoDemandas(int codDominioTipoAgente)
        {
            string sql = @"select p.PK_COD_PERSONA, p.NOM_PERSONA, p.SIGLA from f_ap_persona p  
                            WHERE p.pk_cod_persona in (select pt.FK_PERSONSA from F_DM_R_PERSONA_TIPO pt where pt.d_cod_tipo_persona={0}) ";
            sql = string.Format(sql, codDominioTipoAgente);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public void GuardarPersonaDemanda(Persona obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkCodPersona = GetIdAutoNum("sec_f_ap_persona");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10})";
                _esNuevo = true;
            }
            else
            {
                _esNuevo = false;
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6} ," +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, NOMBRE_TABLA, Persona.C_PK_COD_PERSONA,
            Persona.C_NOM_PERSONA,
            Persona.C_SIGLA,
            Persona.C_D_COD_TIPO_PERSONA,
            Persona.C_DIRECCION,
            Persona.C_TELEFONO,
            Persona.C_IDENTIFICACION,
            Persona.C_D_COD_ESTADO,
            Persona.C_SEC_LOG,
            Persona.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(Persona.C_PK_COD_PERSONA, OracleDbType.Int64, obj.PkCodPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_NOM_PERSONA, OracleDbType.Varchar2, obj.Nombre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_SIGLA, OracleDbType.Varchar2, obj.Sigla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_D_COD_TIPO_PERSONA, OracleDbType.Int64, obj.DCodTipoPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_DIRECCION, OracleDbType.Varchar2, obj.Direccion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_TELEFONO, OracleDbType.Varchar2, obj.Telefono, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_IDENTIFICACION, OracleDbType.Varchar2, obj.Identificacion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Persona.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);
            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
            if (_esNuevo)
            {
                GuardarRPersonaRolSINDemanda(obj.PkCodPersona);
            }
        }

        public void GuardarRPersonaRolSINProyectos(long pkPersona)
        {
            OracleCommand cmd = CrearCommand();
            string sql = "INSERT INTO {0} ({1},{2},{3}) VALUES(:{1},:{2},:{3})";
            sql = string.Format(sql, "F_AP_RPERSONA_ROLSIN",
               "PK_COD_PERSONA",
               "PK_COD_ROL",
               "D_COD_ESTADO");
            cmd = CrearCommand();
            cmd.CommandText = sql;
            //cmd.BindByName = true;
            cmd.Parameters.Add("PK_COD_PERSONA", pkPersona);
            cmd.Parameters.Add("PK_COD_ROL", 4);
            cmd.Parameters.Add("D_COD_ESTADO", "1");
            bool res = Actualizar(cmd);
        }

        public void GuardarRPersonaRolSINDemanda(long pkPersona)
        {
            OracleCommand cmd = CrearCommand();
            string sql = "INSERT INTO {0} ({1},{2},{3}) VALUES(:{1},:{2},:{3})";
            sql = string.Format(sql, "F_AP_RPERSONA_ROLSIN",
               "PK_COD_PERSONA",
               "PK_COD_ROL",
               "D_COD_ESTADO");
            cmd = CrearCommand();
            cmd.CommandText = sql;
            //cmd.BindByName = true;
            cmd.Parameters.Add("PK_COD_PERSONA", pkPersona);
            cmd.Parameters.Add("PK_COD_ROL", 5);
            cmd.Parameters.Add("D_COD_ESTADO", "1");
            bool res = Actualizar(cmd);
        }

        public bool ExistePersonaConEsteCampoYDato(string campo,string nombre, long pkPersona)
        {
            bool res = false;
            string sql = string.Empty;
            sql = "select * from F_AP_PERSONA where upper({0})= upper('{1}') and {2}=19 ";
            sql= string.Format(sql, campo,nombre, Persona.C_D_COD_TIPO_PERSONA);
            if (pkPersona > 0)
            {
                sql = sql + " and {0}<>{1}";
                sql = string.Format(sql,Persona.C_PK_COD_PERSONA,pkPersona);
            }

            DataTable tabla= EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                res = true;
            }
            return res;
        }

        public void EliminarAgenteDeSisDemanda(long pkPersona)
        {
            string sql = "DELETE FROM F_AP_RPERSONA_ROLSIN WHERE {0}={1} AND {2}={3}";
            sql = string.Format(sql, "PK_COD_PERSONA", pkPersona, "PK_COD_ROL",5);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public DataTable GetAgentesRegistrados()
        {
            string sql = "select p.PK_COD_PERSONA, p.NOM_PERSONA as EMPRESA, p.SIGLA, p.DIRECCION, p.TELEFONO from {0}  p where {1}={2} order by p.NOM_PERSONA";
            sql = string.Format(sql, NOMBRE_TABLA, Persona.C_D_COD_TIPO_PERSONA, 19, Persona.C_PK_COD_PERSONA);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public bool ExisteEsteRegistroParaSisProyectos(long pkPersona)
        {
            bool res = false;
            string sql = "select * FROM F_AP_RPERSONA_ROLSIN WHERE {0}={1} AND {2}={3}";
            sql = string.Format(sql, "PK_COD_PERSONA", pkPersona, "PK_COD_ROL", 4);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                res = true;
            }
            return res;
        }


        public void EliminarAgenteDeSisProyectos(long pkPersona)
        {
            string sql = "DELETE FROM F_AP_RPERSONA_ROLSIN WHERE {0}={1} AND {2}={3}";
            sql = string.Format(sql, "PK_COD_PERSONA", pkPersona, "PK_COD_ROL",4);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

    }
}
