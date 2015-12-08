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
    public class DatoTecnicoTransformador : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_DATO_TEC_TRANFORMADOR";

        public const string C_PK_DATO_TEC_TRANFORMADOR = "PK_DATO_TEC_TRANFORMADOR";
        public const string C_FK_COD_PROYECTO = "FK_COD_PROYECTO";
        public const string C_D_COD_TIPO_TRANSFORMADOR = "D_COD_TIPO_TRANSFORMADOR";
        public const string C_NIVEL_DE_TENSION_LADO_AT = "NIVEL_DE_TENSION_LADO_AT";
        public const string C_NIVEL_DE_TENSION_LADO_BT = "NIVEL_DE_TENSION_LADO_BT";
        public const string C_NIVEL_DE_TENSION_TERCIARIO = "NIVEL_DE_TENSION_TERCIARIO";
        public const string C_CAPACIDAD = "CAPACIDAD";
        public const string C_R1_RESISTENCIA_BASE_PPOPIA = "R1_RESISTENCIA_BASE_PPOPIA";
        public const string C_X1_REACTANCIA_BASE_PROPIA = "X1_REACTANCIA_BASE_PROPIA";
        public const string C_PASO_TAP = "PASO_TAP";
        public const string C_TAP_MINIMO = "TAP_MINIMO";
        public const string C_TAP_MAXIMO = "TAP_MAXIMO";
        public const string C_GRUPO_CONEXION = "GRUPO_CONEXION";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_NODO_AT = "NODO_AT";
        public const string C_NODO_BT = "NODO_BT";
        public const string C_NODO_TERCIARIO = "NODO_TERCIARIO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkDatoTecTranformador { get; set; }
        public long FkCodProyecto { get; set; }
        public long DCodTipoTransformador { get; set; }
        public double NivelDeTensionLadoAt { get; set; }
        public double NivelDeTensionLadoBt { get; set; }
        public double NivelDeTensionTerciario { get; set; }
        public double Capacidad { get; set; }
        public double R1ResistenciaBasePpopia { get; set; }
        public double X1ReactanciaBasePropia { get; set; }
        public double PasoTap { get; set; }
        public double TapMinimo { get; set; }
        public double TapMaximo { get; set; }
        public string GrupoConexion { get; set; }
        public string NodoAT { get; set; }
        public string NodoBT { get; set; }
        public string NodoTerciario { get; set; }
        public string Observaciones { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public DatoTecnicoTransformador() { }

        public DatoTecnicoTransformador(DataRow dataRow)
        {
            PkDatoTecTranformador = GetValor<long>(dataRow[C_PK_DATO_TEC_TRANFORMADOR]);
            FkCodProyecto = GetValor<long>(dataRow[C_FK_COD_PROYECTO]);
            DCodTipoTransformador = GetValor<long>(dataRow[C_D_COD_TIPO_TRANSFORMADOR]);
            NivelDeTensionLadoAt = GetValor<double>(dataRow[C_NIVEL_DE_TENSION_LADO_AT]);
            NivelDeTensionLadoBt = GetValor<double>(dataRow[C_NIVEL_DE_TENSION_LADO_BT]);
            NivelDeTensionTerciario = GetValor<double>(dataRow[C_NIVEL_DE_TENSION_TERCIARIO]);
            Capacidad = GetValor<double>(dataRow[C_CAPACIDAD]);
            R1ResistenciaBasePpopia = GetValor<double>(dataRow[C_R1_RESISTENCIA_BASE_PPOPIA]);
            X1ReactanciaBasePropia = GetValor<double>(dataRow[C_X1_REACTANCIA_BASE_PROPIA]);
            PasoTap = GetValor<double>(dataRow[C_PASO_TAP]);
            TapMinimo = GetValor<double>(dataRow[C_TAP_MINIMO]);
            TapMaximo = GetValor<double>(dataRow[C_TAP_MAXIMO]);
            GrupoConexion = GetValor<string>(dataRow[C_GRUPO_CONEXION]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            NodoAT = GetValor<string>(dataRow[C_NODO_AT]);
            NodoBT = GetValor<string>(dataRow[C_NODO_BT]);
            NodoTerciario = GetValor<string>(dataRow[C_NODO_TERCIARIO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATO_TEC_TRANFORMADOR] = PkDatoTecTranformador;
            dataRow[C_FK_COD_PROYECTO] = FkCodProyecto;
            dataRow[C_D_COD_TIPO_TRANSFORMADOR] = DCodTipoTransformador;
            dataRow[C_NIVEL_DE_TENSION_LADO_AT] = NivelDeTensionLadoAt;
            dataRow[C_NIVEL_DE_TENSION_LADO_BT] = NivelDeTensionLadoBt;
            dataRow[C_NIVEL_DE_TENSION_TERCIARIO] = NivelDeTensionTerciario;
            dataRow[C_CAPACIDAD] = Capacidad;
            dataRow[C_R1_RESISTENCIA_BASE_PPOPIA] = R1ResistenciaBasePpopia;
            dataRow[C_X1_REACTANCIA_BASE_PROPIA] = X1ReactanciaBasePropia;
            dataRow[C_PASO_TAP] = PasoTap;
            dataRow[C_TAP_MINIMO] = TapMinimo;
            dataRow[C_TAP_MAXIMO] = TapMaximo;
            dataRow[C_GRUPO_CONEXION] = GrupoConexion;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_NODO_AT] = NodoAT;
            dataRow[C_NODO_BT] = NodoBT;
            dataRow[C_NODO_TERCIARIO] = NodoTerciario;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatoTecTranformador = GetValor<long>(dataRow[C_PK_DATO_TEC_TRANFORMADOR]);
            FkCodProyecto = GetValor<long>(dataRow[C_FK_COD_PROYECTO]);
            DCodTipoTransformador = GetValor<long>(dataRow[C_D_COD_TIPO_TRANSFORMADOR]);
            NivelDeTensionLadoAt = GetValor<double>(dataRow[C_NIVEL_DE_TENSION_LADO_AT]);
            NivelDeTensionLadoBt = GetValor<double>(dataRow[C_NIVEL_DE_TENSION_LADO_BT]);
            NivelDeTensionTerciario = GetValor<double>(dataRow[C_NIVEL_DE_TENSION_TERCIARIO]);
            Capacidad = GetValor<double>(dataRow[C_CAPACIDAD]);
            R1ResistenciaBasePpopia = GetValor<double>(dataRow[C_R1_RESISTENCIA_BASE_PPOPIA]);
            X1ReactanciaBasePropia = GetValor<double>(dataRow[C_X1_REACTANCIA_BASE_PROPIA]);
            PasoTap = GetValor<double>(dataRow[C_PASO_TAP]);
            TapMinimo = GetValor<double>(dataRow[C_TAP_MINIMO]);
            TapMaximo = GetValor<double>(dataRow[C_TAP_MAXIMO]);
            GrupoConexion = GetValor<string>(dataRow[C_GRUPO_CONEXION]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            NodoAT = GetValor<string>(dataRow[C_NODO_AT]);
            NodoBT = GetValor<string>(dataRow[C_NODO_BT]);
            NodoTerciario = GetValor<string>(dataRow[C_NODO_TERCIARIO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface IDatoTecnicoTransformadorMgr
    {
        void Guardar(DatoTecnicoTransformador obj);
        DataTable GetTabla();
        BindingList<DatoTecnicoTransformador> GetLista();
    }
}
