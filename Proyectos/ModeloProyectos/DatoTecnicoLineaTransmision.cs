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
    public class DatoTecnicoLineaTransmision : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_LIN_TRANSMISION";

        public const string C_PK_DATO_TEC_LIN_TRANSMISION = "PK_DATO_TEC_LIN_TRANSMISION";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_NIVEL_TENSION = "NIVEL_TENSION";
        public const string C_CAPACIDAD_TRANSMISION = "CAPACIDAD_TRANSMISION";
        public const string C_CALIBRE_TIPO_CONDUCTOR = "CALIBRE_TIPO_CONDUCTOR";
        public const string C_D_COD_TIPO_ESTRUCTURA_SOPORTE = "D_COD_TIPO_ESTRUCTURA_SOPORTE";
        public const string C_FK_LOC_PROY_TRANS_ORIGEN = "FK_LOC_PROY_TRANS_ORIGEN";
        public const string C_FK_LOC_PROY_TRANS_DESTINO = "FK_LOC_PROY_TRANS_DESTINO";
        public const string C_D_COD_CONF_BAHIA_ORIGEN = "D_COD_CONF_BAHIA_ORIGEN";
        public const string C_D_COD_CONF_BAHIA_DESTINO = "D_COD_CONF_BAHIA_DESTINO";
        public const string C_OBSERVACION = "OBSERVACION";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_LONGITUD_LINEA = "LONGITUD_LINEA";
        public const string C_RESISTENCIA = "RESISTENCIA";
        public const string C_REACTANCIA = "REACTANCIA";
        public const string C_SUSCEPTANCIA = "SUSCEPTANCIA";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";
        public const string C_NODO_ORIGEN = "NODO_ORIGEN";
        public const string C_NODO_DESTINO = "NODO_DESTINO";

        public long PkDatoTecLinTransmision { get; set; }
        public long FkProyecto { get; set; }
        public double NivelTension { get; set; }
        public double CapacidadTransmision { get; set; }
        public string CalibreTipoConductor { get; set; }
        public long DCodTipoEstructuraSoporte { get; set; }
        public long FkLocProyTransOrigen { get; set; }
        public long FkLocProyTransDestino { get; set; }
        public long DCodConfBahiaOrigen { get; set; }
        public long DCodConfBahiaDestino { get; set; }
        public string Observacion { get; set; }
        public long SecLog { get; set; }
        public double LongitudLinea { get; set; }
        public double Resistencia { get; set; }
        public double Reactancia { get; set; }
        public double Susceptancia { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NodoOrigen { get; set; }
        public string NodoDestino { get; set; }

        public DatoTecnicoLineaTransmision() { }

        public DatoTecnicoLineaTransmision(DataRow dataRow)
        {
            PkDatoTecLinTransmision = GetValor<long>(dataRow[C_PK_DATO_TEC_LIN_TRANSMISION]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            NivelTension = GetValor<double>(dataRow[C_NIVEL_TENSION]);
            CapacidadTransmision = GetValor<double>(dataRow[C_CAPACIDAD_TRANSMISION]);
            CalibreTipoConductor = GetValor<string>(dataRow[C_CALIBRE_TIPO_CONDUCTOR]);
            DCodTipoEstructuraSoporte = GetValor<long>(dataRow[C_D_COD_TIPO_ESTRUCTURA_SOPORTE]);
            FkLocProyTransOrigen = GetValor<long>(dataRow[C_FK_LOC_PROY_TRANS_ORIGEN]);
            FkLocProyTransDestino = GetValor<long>(dataRow[C_FK_LOC_PROY_TRANS_DESTINO]);
            DCodConfBahiaOrigen = GetValor<long>(dataRow[C_D_COD_CONF_BAHIA_ORIGEN]);
            DCodConfBahiaDestino = GetValor<long>(dataRow[C_D_COD_CONF_BAHIA_DESTINO]);
            Observacion = GetValor<string>(dataRow[C_OBSERVACION]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            LongitudLinea = GetValor<double>(dataRow[C_LONGITUD_LINEA]);
            Resistencia = GetValor<double>(dataRow[C_RESISTENCIA]);
            Reactancia = GetValor<double>(dataRow[C_REACTANCIA]);
            Susceptancia = GetValor<double>(dataRow[C_SUSCEPTANCIA]);
            FechaRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
            NodoOrigen = GetValor<string>(dataRow[C_NODO_ORIGEN]);
            NodoDestino = GetValor<string>(dataRow[C_NODO_DESTINO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_LIN_TRANSMISION] = PkDatoTecLinTransmision;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_NIVEL_TENSION] = NivelTension;
            dataRow[C_CAPACIDAD_TRANSMISION] = CapacidadTransmision;
            dataRow[C_CALIBRE_TIPO_CONDUCTOR] = CalibreTipoConductor;
            dataRow[C_D_COD_TIPO_ESTRUCTURA_SOPORTE] = DCodTipoEstructuraSoporte;
            dataRow[C_FK_LOC_PROY_TRANS_ORIGEN] = FkLocProyTransOrigen;
            dataRow[C_FK_LOC_PROY_TRANS_DESTINO] = FkLocProyTransDestino;
            dataRow[C_D_COD_CONF_BAHIA_ORIGEN] = DCodConfBahiaOrigen;
            dataRow[C_D_COD_CONF_BAHIA_DESTINO] = DCodConfBahiaDestino;
            dataRow[C_OBSERVACION] = Observacion;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_LONGITUD_LINEA] = LongitudLinea;
            dataRow[C_RESISTENCIA] = Resistencia;
            dataRow[C_REACTANCIA] = Reactancia;
            dataRow[C_SUSCEPTANCIA] = Susceptancia;
            dataRow[C_FECHA_REGISTRO] = FechaRegistro;
            dataRow[C_NODO_ORIGEN] = NodoOrigen;
            dataRow[C_NODO_DESTINO] = NodoDestino;
        }

        public override void  Leer(DataRow dataRow)
        {
            PkDatoTecLinTransmision = GetValor<long>(dataRow[C_PK_DATO_TEC_LIN_TRANSMISION]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            NivelTension = GetValor<double>(dataRow[C_NIVEL_TENSION]);
            CapacidadTransmision = GetValor<double>(dataRow[C_CAPACIDAD_TRANSMISION]);
            CalibreTipoConductor = GetValor<string>(dataRow[C_CALIBRE_TIPO_CONDUCTOR]);
            DCodTipoEstructuraSoporte = GetValor<long>(dataRow[C_D_COD_TIPO_ESTRUCTURA_SOPORTE]);
            FkLocProyTransOrigen = GetValor<long>(dataRow[C_FK_LOC_PROY_TRANS_ORIGEN]);
            FkLocProyTransDestino = GetValor<long>(dataRow[C_FK_LOC_PROY_TRANS_DESTINO]);
            DCodConfBahiaOrigen = GetValor<long>(dataRow[C_D_COD_CONF_BAHIA_ORIGEN]);
            DCodConfBahiaDestino = GetValor<long>(dataRow[C_D_COD_CONF_BAHIA_DESTINO]);
            Observacion = GetValor<string>(dataRow[C_OBSERVACION]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            LongitudLinea = GetValor<double>(dataRow[C_LONGITUD_LINEA]);
            Resistencia = GetValor<double>(dataRow[C_RESISTENCIA]);
            Reactancia = GetValor<double>(dataRow[C_REACTANCIA]);
            Susceptancia = GetValor<double>(dataRow[C_SUSCEPTANCIA]);
            FechaRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
            NodoOrigen = GetValor<string>(dataRow[C_NODO_ORIGEN]);
            NodoDestino = GetValor<string>(dataRow[C_NODO_DESTINO]);
        }
    }

    public interface IDatoTecnicoLineaTransmisionMgr
    {
        void Guardar(DatoTecnicoLineaTransmision obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoLineaTransmision> GetLista();
    }
}
