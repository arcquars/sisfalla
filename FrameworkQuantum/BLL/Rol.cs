using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace CNDC.BLL
{
    public class Rol : ObjetoDeNegocio
    {
        private const string  C_NUM_ROL= "NUM_ROL";
        private const string C_NOMBRE_CORTO = "NOMBRE_CORTO";
        private const string C_DESCRIPCION = "DESCRIPCION";
        private const string C_JERARQUIA = "JERARQUIA";

        public long  Num_Rol{ get; set; }
        public string Descripcion { get; set; }
        public string NombreCorto { get; set; }
        public short Jerarquia { get; set; }
        public string CodEstado { get; set; }
        public long SecLog { get; set; }

        public Rol() { }
        public Rol(DataRow dataRow)
        {
            Num_Rol = (int)GetValor<long >(dataRow[C_NUM_ROL]);
            if (dataRow.Table.Columns.Contains(C_NOMBRE_CORTO))
            {
                NombreCorto = GetValor<string>(dataRow[C_NOMBRE_CORTO]);
            }
            else
            {
                NombreCorto = GetValor<string>(dataRow[C_DESCRIPCION]);
            }
            Descripcion = GetValor<string>(dataRow[C_DESCRIPCION]);
            Jerarquia = GetValor<short>(dataRow[C_JERARQUIA]);
            if (dataRow.Table.Columns.Contains("d_cod_estado"))
            {
                CodEstado = GetValor<string>(dataRow["d_cod_estado"]);
            }

            if (dataRow.Table.Columns.Contains("sec_log"))
            {
                SecLog = GetValor<long>(dataRow["sec_log"]);
            }
        }
        public override string ToString()
        {
            return Descripcion;
        }
    }

    public interface IRolMgr
    {
        void Guardar(Rol obj);
        DataTable GetTabla();
        BindingList<Rol> GetLista();
    }

    public enum Roles
    {
        INGENIERO_DE_COSTOS = 0,
        SUPERVISOR = 1,
        JEFE_DIVISION_CDC = 2,
        GERENTE_AREA = 3,
        OPERADOR = 4,
        AGENTE = 5,
        AUTORIDAD = 6,
        CONSULTA = 7,
        JEFE_DIVISION_AO = 8,
        ING_PROTECCIONES_AO = 9,
        ADM_QUANTUM = 10,
        ING_SIST_POTENCIA = 14,
        GERENTE_PLAN_DEL_SIN = 16,
        JEFE_DIV_EST_ELEC = 17,
        ESP_PLANIFICACION = 18,
        ESP_SISTEMAS_POT = 19,
        ASIST_PLANIFICACION = 20,
        JEFE_DIV_PLAN = 21,
        CONSULTA_PROYECTOS = 22,
        MC = 23,
        MC_DEV = 24,
        TR = 25,
        RED_DEV = 26,
        JEFE_DIV_TRANS_EC = 27,
        ROL_PROGRAMACION = 28,
        ROL_REDES = 29
    }
}
