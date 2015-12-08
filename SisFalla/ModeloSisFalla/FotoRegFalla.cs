using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloSisFalla
{
    [Serializable]
    public class FotoRegFalla : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "FOTO_F_GF_REGFALLA";

        public const string C_PK_COD_FALLA = "PK_COD_FALLA";
        public const string C_FEC_INICIO = "FEC_INICIO";
        public const string C_PK_COD_COMPONENTE = "PK_COD_COMPONENTE";
        public const string C_D_COD_CAUSA = "D_COD_CAUSA";
        public const string C_DESCRIPCION_CORTA_FALLA = "DESCRIPCION_CORTA_FALLA";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_GESTION = "GESTION";
        public const string C_D_COD_ORIGEN = "D_COD_ORIGEN";
        public const string C_D_COD_TIPO_DESCONEXION = "D_COD_TIPO_DESCONEXION";
        public const string C_FK_LOGIN_OPERADOR = "FK_LOGIN_OPERADOR";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_DESCRIPCION_FALLA = "DESCRIPCION_FALLA";
        public const string C_FK_COD_SUPERVISOR = "FK_COD_SUPERVISOR";
        public const string C_FK_COD_OPERADOR = "FK_COD_OPERADOR";
        public const string C_D_COD_PROBLEMA_GEN = "D_COD_PROBLEMA_GEN";
        public const string C_D_COD_COLAPSO = "D_COD_COLAPSO";
        public const string C_FECHA_ELIMINADO = "FECHA_ELIMINADO";
        public const string C_COMENTARIO = "COMENTARIO";
        public const string C_SQ_VAL = "SQ_VAL";

        public int PkCodFalla { get; set; }
        public DateTime FecInicio { get; set; }
        public decimal PkCodComponente { get; set; }
        public long DCodCausa { get; set; }
        public string DescripcionCortaFalla { get; set; }
        public string DCodEstado { get; set; }
        public decimal SecLog { get; set; }
        public short Gestion { get; set; }
        public long DCodOrigen { get; set; }
        public long DCodTipoDesconexion { get; set; }
        public string FkLoginOperador { get; set; }
        public long SincVer { get; set; }
        public string DescripcionFalla { get; set; }
        public long FkCodSupervisor { get; set; }
        public long FkCodOperador { get; set; }
        public long DCodProblemaGen { get; set; }
        public long DCodColapso { get; set; }
        public DateTime FechaEliminado { get; set; }
        public string Comentario { get; set; }
        public long SqVal { get; set; }

        public FotoRegFalla() { }

        public FotoRegFalla(DataRow dataRow)
        {
            PkCodFalla = GetValor<int>(dataRow[C_PK_COD_FALLA]);
            FecInicio = GetValor<DateTime>(dataRow[C_FEC_INICIO]);
            PkCodComponente = GetValor<decimal>(dataRow[C_PK_COD_COMPONENTE]);
            DCodCausa = GetValor<long>(dataRow[C_D_COD_CAUSA]);
            DescripcionCortaFalla = GetValor<string>(dataRow[C_DESCRIPCION_CORTA_FALLA]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<decimal>(dataRow[C_SEC_LOG]);
            Gestion = GetValor<short>(dataRow[C_GESTION]);
            DCodOrigen = GetValor<long>(dataRow[C_D_COD_ORIGEN]);
            DCodTipoDesconexion = GetValor<long>(dataRow[C_D_COD_TIPO_DESCONEXION]);
            FkLoginOperador = GetValor<string>(dataRow[C_FK_LOGIN_OPERADOR]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            DescripcionFalla = GetValor<string>(dataRow[C_DESCRIPCION_FALLA]);
            FkCodSupervisor = GetValor<long>(dataRow[C_FK_COD_SUPERVISOR]);
            FkCodOperador = GetValor<long>(dataRow[C_FK_COD_OPERADOR]);
            DCodProblemaGen = GetValor<long>(dataRow[C_D_COD_PROBLEMA_GEN]);
            DCodColapso = GetValor<long>(dataRow[C_D_COD_COLAPSO]);
            FechaEliminado = GetValor<DateTime>(dataRow[C_FECHA_ELIMINADO]);
            Comentario = GetValor<string>(dataRow[C_COMENTARIO]);
            SqVal = GetValor<long>(dataRow[C_SQ_VAL]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_FALLA] = PkCodFalla;
            dataRow[C_FEC_INICIO] = FecInicio;
            dataRow[C_PK_COD_COMPONENTE] = PkCodComponente;
            dataRow[C_D_COD_CAUSA] = DCodCausa;
            dataRow[C_DESCRIPCION_CORTA_FALLA] = DescripcionCortaFalla;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_GESTION] = Gestion;
            dataRow[C_D_COD_ORIGEN] = DCodOrigen;
            dataRow[C_D_COD_TIPO_DESCONEXION] = DCodTipoDesconexion;
            dataRow[C_FK_LOGIN_OPERADOR] = FkLoginOperador;
            dataRow[C_SINC_VER] = SincVer;
            dataRow[C_DESCRIPCION_FALLA] = DescripcionFalla;
            dataRow[C_FK_COD_SUPERVISOR] = FkCodSupervisor;
            dataRow[C_FK_COD_OPERADOR] = FkCodOperador;
            dataRow[C_D_COD_PROBLEMA_GEN] = DCodProblemaGen;
            dataRow[C_D_COD_COLAPSO] = DCodColapso;
            dataRow[C_FECHA_ELIMINADO] = FechaEliminado;
            dataRow[C_COMENTARIO] = Comentario;
            dataRow[C_SQ_VAL] = SqVal;
        }
    }

    public interface IFotoRegFallaMgr
    {
        void Guardar(FotoRegFalla obj);
        DataTable GetTabla();
        BindingList<FotoRegFalla> GetLista();
    }
}