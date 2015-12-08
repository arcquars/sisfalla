using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace CNDC.BLL
{
    [Serializable]
    public class DefDominio : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "P_DEF_DOMINIOS";

        public const string C_COD_DOMINIO = "COD_DOMINIO";
        public const string C_DESCRIPCION = "DESCRIPCION_DOMINIO";
        public const string C_D_COD_TIPO = "D_COD_TIPO";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_ORDEN = "ORDEN";
        public const string C_COD_DOMINIO_PADRE = "COD_DOMINIO_PADRE";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_DESCRIPCION2 = "DESCRIPCION_DOMINIO_2";
        public const string C_AUX1_DOM = "AUX1_DOM";
        public const string C_AUX2_DOM = "AUX2_DOM";
        public const string C_FEC_INICIO_DOM = "FEC_INICIO_DOM";
        public const string C_FEC_FIN_DOM = "FEC_FIN_DOM";
        public const string C_COMENTARIO_DOM = "COMENTARIO_DOM";

        public const string C_DESCRIPCION_DOMINIO = "DESCRIPCION_DOMINIO";
        public const string C_D_COD_TIPO_DOMINIO = "D_COD_TIPO_DOMINIO"; 
        

        public long CodDominio { get; set; }
        public string Descripcion { get; set; }
        public string DCodTipo { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public short Orden { get; set; }
        public long CodDominioPadre { get; set; }
        public long SincVer { get; set; }
        public string Descripcion2 { get; set; }
        public string Aux1_dom { get; set; }
        public string Aux2_dom { get; set; }
        public DateTime Fec_inicio_dom { get; set; }
        public DateTime Fec_fin_dom { get; set; }
        public string Comentario_dom { get; set; }

        public DefDominio() { }

        public DefDominio(DataRow dataRow)
        {
            CodDominio = GetValor<long>(dataRow[C_COD_DOMINIO]);
            Descripcion = GetValor<string>(dataRow[C_DESCRIPCION]);
            DCodTipo = GetValor<string>(dataRow[C_D_COD_TIPO]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            Orden = GetValor<short>(dataRow[C_ORDEN]);
            CodDominioPadre = GetValor<long>(dataRow[C_COD_DOMINIO_PADRE]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            Descripcion2 = GetValor<string>(dataRow[C_DESCRIPCION2]);
            Aux1_dom = GetValor<string>(dataRow[C_AUX1_DOM]);
            Aux2_dom = GetValor<string>(dataRow[C_AUX2_DOM]);
            Fec_inicio_dom = GetValor<DateTime>(dataRow[C_FEC_INICIO_DOM]);
            Fec_fin_dom = GetValor<DateTime>(dataRow[C_FEC_FIN_DOM]);
            Comentario_dom = GetValor<string>(dataRow[C_COMENTARIO_DOM]);
        }
        public void llenarDominio(DataRow dataRow)
        {
            CodDominio = Parse<long>(dataRow[C_COD_DOMINIO].ToString());
            Descripcion = dataRow[C_DESCRIPCION].ToString();
            DCodTipo = dataRow[C_D_COD_TIPO].ToString();
            DCodEstado = dataRow[C_D_COD_ESTADO].ToString();
            SecLog = Parse<long>(dataRow[C_SEC_LOG].ToString());
            Orden = Parse<short>(dataRow[C_ORDEN].ToString());
            CodDominioPadre = Parse<long>(dataRow[C_COD_DOMINIO_PADRE].ToString());
            SincVer = Parse<long>(dataRow[C_SINC_VER].ToString());
            Descripcion2 = dataRow[C_DESCRIPCION2].ToString();
            Aux1_dom = dataRow[C_AUX1_DOM].ToString();
            Aux2_dom = dataRow[C_AUX2_DOM].ToString();
            Fec_inicio_dom = GetDateTime(dataRow[C_FEC_INICIO_DOM].ToString());
            Fec_fin_dom = GetDateTime(dataRow[C_FEC_FIN_DOM].ToString());
            Comentario_dom = dataRow[C_COMENTARIO_DOM].ToString();
        }

        public override void Leer(DataRow dataRow)
        {
            CodDominio = Parse<long>(dataRow[C_COD_DOMINIO].ToString());
            Descripcion = dataRow[C_DESCRIPCION].ToString();
            DCodTipo = dataRow[C_D_COD_TIPO].ToString();
            DCodEstado = dataRow[C_D_COD_ESTADO].ToString();
            SecLog = Parse<long>(dataRow[C_SEC_LOG].ToString());
            Orden = Parse<short>(dataRow[C_ORDEN].ToString());
            CodDominioPadre = Parse<long>(dataRow[C_COD_DOMINIO_PADRE].ToString());
            SincVer = Parse<long>(dataRow[C_SINC_VER].ToString());
            Descripcion2 = dataRow[C_DESCRIPCION2].ToString();
            Aux1_dom = dataRow[C_AUX1_DOM].ToString();
            Aux2_dom = dataRow[C_AUX2_DOM].ToString();
            Fec_inicio_dom = GetDateTime(dataRow[C_FEC_INICIO_DOM].ToString());
            Fec_fin_dom = GetDateTime(dataRow[C_FEC_FIN_DOM].ToString());
            Comentario_dom = dataRow[C_COMENTARIO_DOM].ToString();
        }
        public void Llenar(DataRow dataRow)
        {
            dataRow[C_COD_DOMINIO] = CodDominio;
            dataRow[C_DESCRIPCION] = Descripcion;
            dataRow[C_D_COD_TIPO] = DCodTipo;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_ORDEN] = Orden;
            dataRow[C_COD_DOMINIO_PADRE] = CodDominioPadre;
            dataRow[C_SINC_VER] = SincVer;
            dataRow[C_DESCRIPCION2] = Descripcion2;
            dataRow[C_AUX1_DOM] = Aux1_dom;
            dataRow[C_AUX2_DOM] = Aux2_dom;
            dataRow[C_FEC_INICIO_DOM] = Fec_inicio_dom;
            dataRow[C_FEC_FIN_DOM] = Fec_fin_dom;
            dataRow[C_COMENTARIO_DOM] = Comentario_dom;
        }

        public string Descripciones
        {
            get
            {
                if (string.IsNullOrEmpty(Descripcion2))
                {
                    return Descripcion;
                }

                return Descripcion2 + "-" + Descripcion;
            }
        }
    }

    public interface IDefDominioMgr
    {
        BindingList<DefDominio> GetListaDominio(string dominio);
        DataTable GetDominio(string dominio);
        DataTable GetTipoComponente(string tipoComponente);
        DataTable GetTabla();
        DataTable GetCategorias();
        DataTable GetRegistros(long codOrigen,long codTdesconex, long codcausa);
        void Guardar(DefDominio obj);
        void Borrar(DefDominio obj);
        bool Existe(DataRow row, DataTable tablaLocal);
    }
}
