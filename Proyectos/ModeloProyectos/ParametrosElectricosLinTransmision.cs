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
    public class ParametrosElectricosLinTransmision : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_PARAM_ELEC_LIN_TRANS";

        public const string C_PK_PARAM_ELEC_LIN_TRANS = "PK_PARAM_ELEC_LIN_TRANS";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_FK_DATO_TEC_LIN_TRANSMISION = "FK_DATO_TEC_LIN_TRANSMISION";
        public const string C_FK_LOC_PROY_TRANSMISION = "FK_LOC_PROY_TRANSMISION";
        public const string C_LONGITUD_LINEA = "LONGITUD_LINEA";
        public const string C_RESISTENCIA = "RESISTENCIA";
        public const string C_REACTANCIA = "REACTANCIA";
        public const string C_SUSCEPTANCIA = "SUSCEPTANCIA";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkParamElecLinTrans { get; set; }
        public long FkProyecto { get; set; }
        public long FkDatoTecLinTransmision { get; set; }
        public long FkLocProyTransmision { get; set; }
        public double LongitudLinea { get; set; }
        public double Resistencia { get; set; }
        public double Reactancia { get; set; }
        public double Susceptancia { get; set; }
        public long SecLog { get; set; }

        public ParametrosElectricosLinTransmision() { }

        public ParametrosElectricosLinTransmision(DataRow dataRow)
        {
            PkParamElecLinTrans = GetValor<long>(dataRow[C_PK_PARAM_ELEC_LIN_TRANS]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            FkDatoTecLinTransmision = GetValor<long>(dataRow[C_FK_DATO_TEC_LIN_TRANSMISION]);
            FkLocProyTransmision = GetValor<long>(dataRow[C_FK_LOC_PROY_TRANSMISION]);
            LongitudLinea = GetValor<double>(dataRow[C_LONGITUD_LINEA]);
            Resistencia = GetValor<double>(dataRow[C_RESISTENCIA]);
            Reactancia = GetValor<double>(dataRow[C_REACTANCIA]);
            Susceptancia = GetValor<double>(dataRow[C_SUSCEPTANCIA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_PARAM_ELEC_LIN_TRANS] = PkParamElecLinTrans;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_FK_DATO_TEC_LIN_TRANSMISION] = FkDatoTecLinTransmision;
            dataRow[C_FK_LOC_PROY_TRANSMISION] = FkLocProyTransmision;
            dataRow[C_LONGITUD_LINEA] = LongitudLinea;
            dataRow[C_RESISTENCIA] = Resistencia;
            dataRow[C_REACTANCIA] = Reactancia;
            dataRow[C_SUSCEPTANCIA] = Susceptancia;
            dataRow[C_SEC_LOG] = SecLog;
        }
    }

    public interface IParametrosElectricosLinTransmisionMgr
    {
        void Guardar(ParametrosElectricosLinTransmision obj);
        DataTable GetTabla();
        BindingList<ParametrosElectricosLinTransmision> GetLista();
    }
}
