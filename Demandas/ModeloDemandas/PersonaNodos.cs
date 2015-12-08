using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloDemandas
{
    [Serializable]
    public class PersonaNodos : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_DM_R_PERSONA_NODO";

        public const string C_PK_PERSONA_NODO = "PK_PERSONA_NODO";
        public const string C_FK_PERSONA = "FK_PERSONA";
        public const string C_FK_NODO_REAL = "FK_NODO_REAL";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FK_NODO_PROYECTO = "FK_NODO_PROYECTO";
        public const string C_PK_PERSONA_NODO_PADRE = "PK_PERSONA_NODO_PADRE";

        public long PkPersonaNodo { get; set; }
        public long FkPersona { get; set; }
        public long FkNodoReal { get; set; }
        public long SecLog { get; set; }
        public long FkNodoProyecto { get; set; }
        public long PkPersonaNodoPadre { get; set; }

        public PersonaNodos() { }

        public PersonaNodos(DataRow dataRow)
        {
            PkPersonaNodo = GetValor<long>(dataRow[C_PK_PERSONA_NODO]);
            FkPersona = GetValor<long>(dataRow[C_FK_PERSONA]);
            FkNodoReal = GetValor<long>(dataRow[C_FK_NODO_REAL]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FkNodoProyecto = GetValor<long>(dataRow[C_FK_NODO_PROYECTO]);
            PkPersonaNodoPadre = GetValor<long>(dataRow[C_PK_PERSONA_NODO_PADRE]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_PERSONA_NODO] = PkPersonaNodo;
            dataRow[C_FK_PERSONA] = FkPersona;
            dataRow[C_FK_NODO_REAL] = FkNodoReal;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FK_NODO_PROYECTO] = FkNodoProyecto;
            dataRow[C_PK_PERSONA_NODO_PADRE] = PkPersonaNodoPadre;
        }

        public override void Leer(DataRow dataRow)
        {
            PkPersonaNodo = GetValor<long>(dataRow[C_PK_PERSONA_NODO]);
            FkPersona = GetValor<long>(dataRow[C_FK_PERSONA]);
            FkNodoReal = GetValor<long>(dataRow[C_FK_NODO_REAL]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FkNodoProyecto = GetValor<long>(dataRow[C_FK_NODO_PROYECTO]);
            PkPersonaNodoPadre = GetValor<long>(dataRow[C_PK_PERSONA_NODO_PADRE]);
        }
    }

    public interface IPersonaNodosMgr
    {
        void Guardar(PersonaNodos obj);
        DataTable GetTabla();
        BindingList<PersonaNodos> GetLista();
    }
}
