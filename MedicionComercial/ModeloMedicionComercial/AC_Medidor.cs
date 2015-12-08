using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace MC
{
    [Serializable]
    public class AC_Medidor : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_AC_MEDIDOR";

        public const string C_PK_COD_MEDIDOR = "PK_COD_MEDIDOR";
        public const string C_MARCA = "MARCA_MED";
        public const string C_MODELO = "MODELO_MED";
        public const string C_PRECISION = "PRECISION_MED";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_PRIME_NOINS = "PRIME_NOINS_MED";
        public const string C_MEDIDOR_REEMPLAZADO = "MEDIDOR_REEMPLAZADO_MED";
        public const string C_PRIORIDAD = "PRIORIDAD_MED";
        public const string C_REAL_VIRTUAL = "REAL_VIRTUAL_MED";
        public const string C_FK_COD_PROPIETARIO = "FK_COD_PROPIETARIO_MED";
        public const string C_NOMBRE = "NOMBRE_MED";
        public const string C_DESCRIPCION = "DESCRIPCION_MED";
        public const string C_FECHA_INGRESO = "FECHA_INGRESO_MED";
        public const string C_FECHA_SALIDA = "FECHA_SALIDA_MED";

        public long PkCodMedidor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Precision { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public string PrimeNoins { get; set; }
        public decimal MedidorReemplazado { get; set; }
        public decimal Prioridad { get; set; }
        public short RealVirtual { get; set; }
        public long FkCodPropietario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }

        public AC_Medidor() { }

        public AC_Medidor(DataRow dataRow)
        {
            PkCodMedidor = GetValor<long>(dataRow[C_PK_COD_MEDIDOR]);
            Marca = GetValor<string>(dataRow[C_MARCA]);
            Modelo = GetValor<string>(dataRow[C_MODELO]);
            Precision = GetValor<decimal>(dataRow[C_PRECISION]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            PrimeNoins = GetValor<string>(dataRow[C_PRIME_NOINS]);
            MedidorReemplazado = GetValor<decimal>(dataRow[C_MEDIDOR_REEMPLAZADO]);
            Prioridad = GetValor<decimal>(dataRow[C_PRIORIDAD]);
            RealVirtual = GetValor<short>(dataRow[C_REAL_VIRTUAL]);
            FkCodPropietario = GetValor<long>(dataRow[C_FK_COD_PROPIETARIO]);
            Nombre = GetValor<string>(dataRow[C_NOMBRE]);
            Descripcion = GetValor<string>(dataRow[C_DESCRIPCION]);
            FechaIngreso = GetValor<DateTime>(dataRow[C_FECHA_INGRESO]);
            FechaSalida = GetValor<DateTime>(dataRow[C_FECHA_SALIDA]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_MEDIDOR] = PkCodMedidor;
            dataRow[C_MARCA] = Marca;
            dataRow[C_MODELO] = Modelo;
            dataRow[C_PRECISION] = Precision;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_PRIME_NOINS] = PrimeNoins;
            dataRow[C_MEDIDOR_REEMPLAZADO] = MedidorReemplazado;
            dataRow[C_PRIORIDAD] = Prioridad;
            dataRow[C_REAL_VIRTUAL] = RealVirtual;
            dataRow[C_FK_COD_PROPIETARIO] = FkCodPropietario;
            dataRow[C_NOMBRE] = Nombre;
            dataRow[C_DESCRIPCION] = Descripcion;
            dataRow[C_FECHA_INGRESO] = FechaIngreso;
            dataRow[C_FECHA_SALIDA] = FechaSalida;
        }
    }

    public interface IAC_MedidorMgr
    {
        void Guardar(AC_Medidor obj);
        DataTable GetTabla();
        BindingList<AC_Medidor> GetLista();
    }
}