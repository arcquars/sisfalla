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
    public class MC_RPuntoMedicionFormato : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_RPTO_MED_FTO";

        public const string C_PK_COD_RPTO_MED_FTO = "PK_COD_RPTO_MED_FTO";
        public const string C_FK_COD_PUNTO_MEDICION = "FK_COD_PUNTO_MEDICION";
        public const string C_FK_COD_MEDIDOR = "FK_COD_MEDIDOR";
        public const string C_FK_COD_FORMATO = "FK_COD_FORMATO";
        public const string C_NOMBRE_ARCHIVO = "NOMBRE_ARCHIVO";
        public const string C_PRIORIDAD_LECTURA = "PRIORIDAD_LECTURA";
        public const string C_CONTIENE_FIN_INTERVALO = "CONTIENE_FIN_INTERVALO";
        public const string C_FECHA_INICIO = "FECHA_INICIO";
        public const string C_FECHA_FIN = "FECHA_FIN";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkCodRptoMedFto { get; set; }
        public long FkCodPuntoMedicion { get; set; }
        public long FkCodMedidor { get; set; }
        public long FkCodFormato { get; set; }
        public string NombreArchivo { get; set; }
        public short PrioridadLectura { get; set; }
        public short ContieneFinIntervalo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }

        public MC_RPuntoMedicionFormato() { }

        public MC_RPuntoMedicionFormato(DataRow dataRow)
        {
            PkCodRptoMedFto = GetValor<long>(dataRow[C_PK_COD_RPTO_MED_FTO]);
            FkCodPuntoMedicion = GetValor<long>(dataRow[C_FK_COD_PUNTO_MEDICION]);
            FkCodMedidor = GetValor<long>(dataRow[C_FK_COD_MEDIDOR]);
            FkCodFormato = GetValor<long>(dataRow[C_FK_COD_FORMATO]);
            NombreArchivo = GetValor<string>(dataRow[C_NOMBRE_ARCHIVO]);
            PrioridadLectura = GetValor<short>(dataRow[C_PRIORIDAD_LECTURA]);
            ContieneFinIntervalo = GetValor<short>(dataRow[C_CONTIENE_FIN_INTERVALO]);
            FechaInicio = GetValor<DateTime>(dataRow[C_FECHA_INICIO]);
            FechaFin = GetValor<DateTime>(dataRow[C_FECHA_FIN]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_RPTO_MED_FTO] = PkCodRptoMedFto;
            dataRow[C_FK_COD_PUNTO_MEDICION] = FkCodPuntoMedicion;
            dataRow[C_FK_COD_MEDIDOR] = FkCodMedidor;
            dataRow[C_FK_COD_FORMATO] = FkCodFormato;
            dataRow[C_NOMBRE_ARCHIVO] = NombreArchivo;
            dataRow[C_PRIORIDAD_LECTURA] = PrioridadLectura;
            dataRow[C_CONTIENE_FIN_INTERVALO] = ContieneFinIntervalo;
            dataRow[C_FECHA_INICIO] = FechaInicio;
            dataRow[C_FECHA_FIN] = FechaFin;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
        }

        public MC_RPuntoMedicionFormatoDetalle GetNuevoRMedidorCanal()
        {
            MC_RPuntoMedicionFormatoDetalle resultado = new MC_RPuntoMedicionFormatoDetalle();
            resultado.FkCodRPtoMedFto = this.PkCodRptoMedFto;
            resultado.EsNuevo = true;
            resultado.DCodEstado = "1";
            resultado.Kc = 1;
            resultado.Kct = 1;
            resultado.Kpt = 1;
            return resultado;
        }
    }

    public interface IMC_RPtoMedFtoMgr
    {
        void Guardar(MC_RPuntoMedicionFormato obj);
        DataTable GetTabla();
        BindingList<MC_RPuntoMedicionFormato> GetLista();
    }
}