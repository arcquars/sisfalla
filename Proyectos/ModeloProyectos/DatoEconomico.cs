using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloProyectos
{
    [Serializable]
    public class DatoEconomico : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_ECONOMICO";

        public const string C_PK_DATO_ECONOMICO = "PK_DATO_ECONOMICO";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_TIEMPO_EJECUCION = "TIEMPO_EJECUCION";
        public const string C_VIDA_UTIL = "VIDA_UTIL";
        public const string C_ANIO_REF_INFORMACION = "ANIO_REF_INFORMACION";
        public const string C_FECHA_MIN_INGRESO_OPERACION = "FECHA_MIN_INGRESO_OPERACION";
        public const string C_COSTO_FIJO_OM = "COSTO_FIJO_OM";
        public const string C_COSTO_VARIABLE_OM = "COSTO_VARIABLE_OM";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";
        public const string C_SEC_LOG = "SEC_LOG";
        

        public long PkDatoEconomico { get; set; }
        public long FkProyecto { get; set; }
        public long TiempoEjecucion { get; set; }
        public long VidaUtil { get; set; }
        public long AnioRefInformacion { get; set; }
        public DateTime FechaMinIngresoOperacion { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public double CostoFijoOm { get; set; }
        public double CostoVariableOm { get; set; }
        public long SecLog { get; set; }

        public DatoEconomico() { }

        public DatoEconomico(DataRow dataRow)
        {
            PkDatoEconomico = GetValor<long>(dataRow[C_PK_DATO_ECONOMICO]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            TiempoEjecucion = GetValor<long>(dataRow[C_TIEMPO_EJECUCION]);
            VidaUtil = GetValor<long>(dataRow[C_VIDA_UTIL]);
            AnioRefInformacion = GetValor<long>(dataRow[C_ANIO_REF_INFORMACION]);
            FechaMinIngresoOperacion = GetValor<DateTime>(dataRow[C_FECHA_MIN_INGRESO_OPERACION]);
            CostoFijoOm = GetValor<double>(dataRow[C_COSTO_FIJO_OM]);
            CostoVariableOm = GetValor<double>(dataRow[C_COSTO_VARIABLE_OM]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_ECONOMICO] = PkDatoEconomico;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_TIEMPO_EJECUCION] = TiempoEjecucion;
            dataRow[C_VIDA_UTIL] = VidaUtil;
            dataRow[C_ANIO_REF_INFORMACION] = AnioRefInformacion;
            dataRow[C_FECHA_MIN_INGRESO_OPERACION] = FechaMinIngresoOperacion;
            dataRow[C_COSTO_FIJO_OM] = CostoFijoOm;
            dataRow[C_COSTO_VARIABLE_OM] = CostoVariableOm;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoEconomico = GetValor<long>(dataRow[C_PK_DATO_ECONOMICO]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            TiempoEjecucion = GetValor<long>(dataRow[C_TIEMPO_EJECUCION]);
            VidaUtil = GetValor<long>(dataRow[C_VIDA_UTIL]);
            AnioRefInformacion = GetValor<long>(dataRow[C_ANIO_REF_INFORMACION]);
            FechaMinIngresoOperacion = GetValor<DateTime>(dataRow[C_FECHA_MIN_INGRESO_OPERACION]);
            CostoFijoOm = GetValor<double>(dataRow[C_COSTO_FIJO_OM]);
            CostoVariableOm = GetValor<double>(dataRow[C_COSTO_VARIABLE_OM]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);            
        }
    }

    public interface IDatoEconomicoMgr
    {
        void Guardar(DatoEconomico obj);
        DataTable GetTabla();
        BindingList<DatoEconomico> GetLista();
    }
}
