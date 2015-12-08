using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloSisFalla;
using System.Data;
using Oracle.DataAccess.Client;
using CNDC.DAL;
using System.ComponentModel;
using CNDC.BLL;
using CNDC.Sincronizacion;

namespace OraDalSisFalla
{
    public class OraDalRContactoMgr : OraDalBaseMgr, IRContactoMgr, IMgrLocal
    {
        public OraDalRContactoMgr()
        {

        }
        public OraDalRContactoMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Guardar(RContacto p)
        {
        }
        public Persona GetPersona(long PK_COD_PERSONA)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @" SELECT SIGLA||' - ' || NOM_PERSONA  NOM_COD_AGENTE , PK_COD_PERSONA, NOM_PERSONA, 
            SIGLA, D_COD_TIPO_PERSONA, DIRECCION, TELEFONO, IDENTIFICACION, 
            D_COD_ESTADO, SEC_LOG, SINC_VER
            FROM F_AP_PERSONA
            WHERE pk_cod_persona = :ppk_cod_persona;";

            cmd.Parameters.Add("ppk_cod_persona", PK_COD_PERSONA);
            DataTable tabla = EjecutarCmd(cmd);
            Persona p = null;
            if (tabla.Rows.Count > 0)
            {
                p = new Persona(tabla.Rows[0]);
            }
            return p;
        }

        public DataTable GetRegistros(long codFalla, long codPersonaImplicado)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT
                P.SIGLA,
                C.PK_COD_EMPRESA,
                C.EMAIL
            FROM
            F_AP_PERSONA P
            inner JOIN F_AP_RCONTACTO C ON C.PK_COD_EMPRESA = P.PK_COD_PERSONA
            inner JOIN F_GF_NOTIFICACION N ON P.PK_COD_PERSONA = N.PK_COD_PERSONA
            WHERE
            N.PK_COD_FALLA = :COD_FALLA
            AND N.PK_COD_PERSONA!=:COD_PERSONA";

            cmd.Parameters.Add("COD_FALLA", codFalla);
            cmd.Parameters.Add("COD_PERSONA", codPersonaImplicado);

            DataTable tabla = EjecutarCmd(cmd);
            tabla.TableName = RegFalla.NOMBRE_TABLA;

            return tabla;
        }

        public List<string> GetEmails(long codFalla, long codPersonaImplicado)
        {
            List<string> resultado = new List<string>();
            DataTable tabla = GetRegistros(codFalla, codPersonaImplicado);
            foreach (DataRow r in tabla.Rows)
            {
                string strEmail = r["EMAIL"].ToString();
                resultado.Add(strEmail);
            }

            resultado = resultado.Distinct().ToList();

            return resultado;
        }

        public DataTable GetTabla()
        {
            OracleCommand cmd = CrearCommand();
            string sql=
            @"SELECT p.nom_persona, c.* 
            FROM f_ap_persona p, f_ap_rcontacto c 
            WHERE p.pk_cod_persona=c.pk_cod_contacto  
            AND c.D_COD_ESTADO='1'
            AND p.d_cod_tipo_persona=:D_COD_TIPO_PERSONA";
            cmd.CommandText = sql;
            cmd.Parameters.Add("D_COD_TIPO_PERSONA", OracleDbType.Int64, CNDC.Dominios.D_COD_TIPO_PERSONA.PERSONA_NATURAL, ParameterDirection.Input);
            cmd.BindByName = true;

            DataTable resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public BindingList<RContacto> GetLista()
        {
            BindingList<RContacto> resultado = new BindingList<RContacto>();
            DataTable tabla = GetTabla();
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new RContacto(row));
            }
            return resultado;
        }

        #region IMgrLocal

        public string NombreTabla
        {
            get { return RContacto.NOMBRE_TABLA; }
        }
        #endregion IMgrLocal


        public void Insertar(List<DataRow> tabla)
        {
        }

        public void Actualizar(List<DataRow> tabla)
        {
        }

        public List<string> GetEmailsDeContactos(BindingList<Persona> agentesNotificar)
        {
            string codsPersonas = string.Empty;
            foreach (var p in agentesNotificar)
            {
                if (codsPersonas != string.Empty)
                {
                    codsPersonas += ",";
                }
                codsPersonas += p.PkCodPersona;
            }

            List<string> resultado = GetEmailsDeContactos(codsPersonas);
            return resultado;
        }

        public List<string> GetEmailsDeContactos(string codPersonasSeparadosPorComa)
        {
            List<string> resultado = new List<string>();
            string sql =
            @"SELECT co.email FROM f_ap_rcontacto co
            WHERE co.d_cod_estado='1' AND co.pk_cod_empresa IN";

            sql = string.Format("{0}({1})", sql, codPersonasSeparadosPorComa);
            DataTable tabla = EjecutarSql(sql);
            foreach (DataRow r in tabla.Rows)
            {
                string email = ObjetoDeNegocio.GetValor<string>(r[0]);
                if (!string.IsNullOrEmpty(email))
                {
                    resultado.Add(email);
                }
            }

            resultado = resultado.Distinct().ToList();
            return resultado;
        }

    }
}
