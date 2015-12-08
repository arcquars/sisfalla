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
    public class RelesOperados : ObjetoDeNegocio, IReleOperado
    {
        public const string NOMBRE_TABLA = "F_GF_RELES_OPER";

        public const string C_PK_COD_FALLA = "PK_COD_FALLA";
        public const string PK_ORIGEN_INFORME = "PK_ORIGEN_INFORME";
        public const string C_PK_D_COD_TIPOINFORME = "PK_D_COD_TIPOINFORME";
        public const string C_PK_COD_COMPONENTE = "PK_COD_COMPONENTE";
        public const string C_FEC_APERTURA = "FEC_APERTURA";
        public const string C_TIPO_RELE = "TIPO_RELE";
        public const string C_FUNCION = "FUNCION_RELE";
        public const string C_TIEMPO = "TIEMPO_RELE";
        public const string C_ZONA = "ZONA_RELE";
        public const string C_DIS = "DISTANCIA_RELE";
        public const string C_NUMERO = "NUMERO_RELE";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_SEC_RELE_OPER_FUNC = "SEC_RELE_OPER_FUNC";

        public long PkCodFalla { get; set; }
        public long PkOrigenFalla { get; set; }
        public long PkDCodTipoinforme { get; set; }
        public long PkCodComponente { get; set; }
        public DateTime FecApertura { get; set; }
        public string TipoRele { get; set; }
        public string Funcion { get; set; }
        public double Tiempo { get; set; }
        public double Zona { get; set; }
        public double Distancia { get; set; }
        public double Numero { get; set; }
        public long SincVer { get; set; }
        public long SecReleOperFunc { get; set; }

        public RelesOperados() { }

        public RelesOperados(DataRow dataRow)
        {
            PkCodFalla = GetValor<long>(dataRow[C_PK_COD_FALLA]);
            PkOrigenFalla = GetValor<long>(dataRow[PK_ORIGEN_INFORME]);
            PkDCodTipoinforme = GetValor<long>(dataRow[C_PK_D_COD_TIPOINFORME]);
            PkCodComponente = GetValor<long>(dataRow[C_PK_COD_COMPONENTE]);
            FecApertura = GetValor<DateTime>(dataRow[C_FEC_APERTURA]);
            TipoRele = GetValor<string>(dataRow[C_TIPO_RELE]);
            Funcion = GetValor<string>(dataRow[C_FUNCION]);
            Tiempo = GetValor<int>(dataRow[C_TIEMPO]);
            Zona = GetValor<int>(dataRow[C_ZONA]);
            Distancia = GetValor<double>(dataRow[C_DIS]);
            Numero = GetValor<double>(dataRow[C_NUMERO]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            SecReleOperFunc = GetValor<long>(dataRow[C_SEC_RELE_OPER_FUNC]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_FALLA] = PkCodFalla;
            dataRow[PK_ORIGEN_INFORME] = PkOrigenFalla;
            dataRow[C_PK_D_COD_TIPOINFORME] = PkDCodTipoinforme;
            dataRow[C_PK_COD_COMPONENTE] = PkCodComponente;
            dataRow[C_FEC_APERTURA] = FecApertura;
            dataRow[C_TIPO_RELE] = TipoRele;
            dataRow[C_FUNCION] = Funcion;
            dataRow[C_TIEMPO] = Tiempo;
            dataRow[C_ZONA] = Zona;
            dataRow[C_DIS] = Distancia;
            dataRow[C_NUMERO] = Numero;
            dataRow[C_SINC_VER] = SincVer;
            dataRow[C_SEC_RELE_OPER_FUNC] = SecReleOperFunc;
        }
    }

    public interface IReleOperado
    {
        double Distancia { get; set; }
        string Funcion { get; set; }
        double Tiempo { get; set; }
        string TipoRele { get; set; }
        double Zona { get; set; }
    }

    public interface IRelesOperadosMgr
    {
        void Guardar(RelesOperados obj);
        DataTable GetTabla();
        BindingList<RelesOperados> GetLista();
        BindingList<RelesOperados> GetLista(OperacionInterruptores opInterruptor);
        DataTable GetTablaRelesOperador(OperacionInterruptores interruptorSeleccionado);
        void Borrar(RelesOperados item);
        long GetValorSecReleOperFunc(RelesOperados item);
    }
}