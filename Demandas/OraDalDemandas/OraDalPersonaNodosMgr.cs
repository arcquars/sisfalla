using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using ModeloDemandas;
using CNDC.Pistas;

namespace OraDalDemandas
{
    public class OraDalPersonaNodosMgr : OraDalBaseMgr, IPersonaNodosMgr
    {
        #region Singleton
        private static OraDalPersonaNodosMgr _instancia;
        static OraDalPersonaNodosMgr()
        {
            _instancia = new OraDalPersonaNodosMgr();
        }
        public static OraDalPersonaNodosMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalPersonaNodosMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return PersonaNodos.NOMBRE_TABLA;
            }
        }

        public void Guardar(PersonaNodos obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demandas", obj.GetEstadoString());
                obj.PkPersonaNodo = GetIdAutoNum("SQ_F_DM_PERSONA_NODO");
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, PersonaNodos.NOMBRE_TABLA, PersonaNodos.C_PK_PERSONA_NODO,
            PersonaNodos.C_FK_PERSONA,
            PersonaNodos.C_FK_NODO_REAL,
            PersonaNodos.C_SEC_LOG,
            PersonaNodos.C_FK_NODO_PROYECTO,
            PersonaNodos.C_PK_PERSONA_NODO_PADRE);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(PersonaNodos.C_PK_PERSONA_NODO, OracleDbType.Int64, obj.PkPersonaNodo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(PersonaNodos.C_FK_PERSONA, OracleDbType.Int64, obj.FkPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(PersonaNodos.C_FK_NODO_REAL, OracleDbType.Int64, obj.FkNodoReal, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(PersonaNodos.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(PersonaNodos.C_FK_NODO_PROYECTO, OracleDbType.Int64, obj.FkNodoProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(PersonaNodos.C_PK_PERSONA_NODO_PADRE, OracleDbType.Int64, obj.PkPersonaNodoPadre, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(PersonaNodos.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<PersonaNodos> GetLista()
        {
            BindingList<PersonaNodos> resultado = new BindingList<PersonaNodos>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new PersonaNodos(row));
            }
            return resultado;
        }

        public void EliminarDatos(long pkPersona)
        {
            string sql = "DELETE FROM {0} WHERE {1}={2} ";
            sql = string.Format(sql, PersonaNodos.NOMBRE_TABLA, PersonaNodos.C_FK_PERSONA, pkPersona);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }



        public List<PersonaNodos> GetPersonaNodosDemanda(long pkPersona)
        {
            List<PersonaNodos> lista = new List<PersonaNodos>();
            string sql = @"select np.* from F_DM_R_PERSONA_NODO np, F_DM_NODO_DEMANDA n
                           where np.pk_persona_nodo_padre = 0 and np.FK_NODO_PROYECTO =n.PK_NODO_DEMANDA and np.fk_persona={0}";
            sql = string.Format(sql, pkPersona);
            DataTable tabla = EjecutarSql(sql);
            PersonaNodos np = null;
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    np = new PersonaNodos(row);
                    lista.Add(np);
                }
            }
            return lista;
        }

        public PersonaNodos GetPersonaNodoRealPadre(long pkPersona, long pkNodo)
        {
            PersonaNodos res = null;
            string sql = @"select np.* from F_DM_R_PERSONA_NODO np 
                        where np.pk_persona_nodo_padre = 0 and np.fk_nodo_proyecto=0  and np.fk_persona={0} and np.fk_nodo_real={1}";
            sql = string.Format(sql,pkPersona, pkNodo);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new PersonaNodos(row);
            }
            return res;
        }

        public PersonaNodos GetPersonaNodoProyectoPadre(long pkPersona, long pkNodo)
        {
            PersonaNodos res = null;
            string sql = @"select np.* from F_DM_R_PERSONA_NODO np 
                        where np.pk_persona_nodo_padre = 0 and np.fk_nodo_proyecto <> 0 and np.fk_nodo_real = 0 and np.fk_persona={0} and np.fk_nodo_proyecto={1}";
            sql = string.Format(sql, pkPersona, pkNodo);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new PersonaNodos(row);
            }
            return res;
        }

        public PersonaNodos GetPersonaNodoProyectoHijo(long pkPersona, long pkNodo)
        {
            PersonaNodos res = null;
            string sql = @"select np.* from F_DM_R_PERSONA_NODO np 
                        where np.pk_persona_nodo_padre <> 0 and np.fk_nodo_proyecto <> 0 and np.fk_nodo_real = 0 and np.fk_persona={0} and np.fk_nodo_proyecto={1}";
            sql = string.Format(sql, pkPersona, pkNodo);
            DataTable tabla = EjecutarSql(sql);
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new PersonaNodos(row);
            }
            return res;
        }

        public void EliminarRegistroHijo(long pkPersona, long pkNodoConexion, long pkNodoDemanda)
        {
            PersonaNodos personaNodoHijo = OraDalPersonaNodosMgr.Instancia.GetPersonaNodoProyectoHijo(pkPersona, pkNodoConexion);
            string sql = "delete from {0} where {1}={2} ";
            sql = string.Format(sql, NombreTabla, PersonaNodos.C_PK_PERSONA_NODO, personaNodoHijo.PkPersonaNodo);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
            if (res)
            {
                if (personaNodoHijo != null)
                {
                    // eliminar los nodos salida
                    DemandaSalidaMaestro salidaMaestro = OraDalDemandaSalidaMaestroMgr.Instancia.GetDemandaSalidaDeNodoDemanda(personaNodoHijo.PkPersonaNodo, pkNodoDemanda);
                    if (salidaMaestro != null)
                    {
                        OraDalDemandaSalidaDetalleMgr.Instancia.EliminarRegistroDetalle(salidaMaestro.PkDemandaSalidaMaestro, pkNodoConexion);
                    }

                    //eliminar tablas series 
                    OraDalDatosDemandaNodoMgr.Instancia.EliminarTablaDatosPersonaNodo(personaNodoHijo.PkPersonaNodo);

                    //eliminar tablas identificadores
                    OraDalDemandaNodoIdentificadorSemanaMgr.Instancia.EliminarDatos(personaNodoHijo.PkPersonaNodo);

                    // eliminar datos: bloque
                    OraDalDatosDemandaNodoBLoqueMgr.Instancia.EliminarDatos(personaNodoHijo.PkPersonaNodo);

                }
            }
        }

        public bool EliminarRegistroPadre(long pkPersona, long pkNodo)
        {
            string sql = "delete from {0} where {1}={2} and {3}={4} and {5}=0";
            sql = string.Format(sql, NombreTabla, PersonaNodos.C_FK_PERSONA, pkPersona, PersonaNodos.C_FK_NODO_PROYECTO, pkNodo, PersonaNodos.C_PK_PERSONA_NODO_PADRE);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
           
            return res;
        }

        public DataTable GetPersonaNodo(long pkPersona)
        {
            string sql = "select * from {0} where {1}={2}";
            sql = string.Format(sql, PersonaNodos.NOMBRE_TABLA, PersonaNodos.C_FK_PERSONA, pkPersona);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }
    }
}
