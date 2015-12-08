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
    public class MC_PuntoMedicion : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_PUNTO_MEDICION";

        public const string C_PK_COD_PUNTO_MEDICION = "PK_COD_PUNTO_MEDICION";
        public const string C_NOMBRE = "NOMBRE";
        public const string C_DESCRIPCION = "DESCRIPCION";
        public const string C_TIPO = "TIPO";
        public const string C_FK_COD_PROPIETARIO = "FK_COD_PROPIETARIO";
        public const string C_FECHA_INICIO = "FECHA_INICIO";
        public const string C_FECHA_FIN = "FECHA_FIN";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkCodPtoMedicion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Tipo { get; set; }
        public long FkCodPropietario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public long SecLog { get; set; }

        public MC_PuntoMedicion()
        {
            FechaSalida = null;
            Tipo = 1;
        }

        public MC_PuntoMedicion(DataRow dataRow)
        {
            PkCodPtoMedicion = GetValor<long>(dataRow[C_PK_COD_PUNTO_MEDICION]);
            Nombre = GetValor<string>(dataRow[C_NOMBRE]);
            Descripcion = GetValor<string>(dataRow[C_DESCRIPCION]);
            Tipo = GetValor<int>(dataRow[C_TIPO]);
            FkCodPropietario = GetValor<long>(dataRow[C_FK_COD_PROPIETARIO]);
            FechaIngreso = GetValor<DateTime>(dataRow[C_FECHA_INICIO]);
            FechaSalida = GetValor<DateTime?>(dataRow[C_FECHA_FIN]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_PUNTO_MEDICION] = PkCodPtoMedicion;
            dataRow[C_NOMBRE] = Nombre;
            dataRow[C_DESCRIPCION] = Descripcion;
            dataRow[C_TIPO] = Tipo;
            dataRow[C_FK_COD_PROPIETARIO] = FkCodPropietario;
            dataRow[C_FECHA_INICIO] = FechaIngreso;
            if (FechaSalida == null)
            {
                dataRow[C_FECHA_FIN] = System.DBNull.Value;
            }
            else
            {
                dataRow[C_FECHA_FIN] = FechaSalida;
            }
            dataRow[C_SEC_LOG] = SecLog;
        }

        public MC_FormulaPuntoMedicion GetNuevaFormula()
        {
            MC_FormulaPuntoMedicion resultado=new MC_FormulaPuntoMedicion();
            resultado.EsNuevo = true;
            resultado.FkCodPuntoMedicion = PkCodPtoMedicion;
            resultado.FechaInicio = DateTime.Now.Date;
            return resultado;
        }
    }

    public interface IMC_PuntoMedicionMgr
    {
        void Guardar(MC_PuntoMedicion obj);
        DataTable GetTabla();
        BindingList<MC_PuntoMedicion> GetLista();
    }

    public enum TipoPuntoMedicion
    {
        Real = 1,
        Virtual
    }
}