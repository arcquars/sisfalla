using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using CNDC.UtilesComunes;

namespace MC
{
    [Serializable]
    public class MC_Lectura : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_LECTURA";

        public const string C_PK_COD_LECTURA = "PK_COD_LECTURA";
        public const string C_FK_COD_PUNTO_MEDICION = "FK_COD_PUNTO_MEDICION";
        public const string C_COD_RPTO_MED_FTO = "COD_RPTO_MED_FTO";
        public const string C_FECHA_LECTURA = "FECHA_LECTURA";
        public const string C_NOMBRE_ARCHIVO = "NOMBRE_ARCHIVO";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkCodLectura { get; set; }
        public long FkCodPtoMed { get; set; }
        public long CodRPtoMedFto { get; set; }
        public DateTime FechaLectura { get; set; }
        public string NombreArchivo { get; set; }
        public long SecLog { get; set; }

        public MC_Lectura() { }

        public MC_Lectura(DataRow dataRow)
        {
            PkCodLectura = GetValor<long>(dataRow[C_PK_COD_LECTURA]);
            FkCodPtoMed = GetValor<long>(dataRow[C_FK_COD_PUNTO_MEDICION]);
            CodRPtoMedFto = GetValor<long>(dataRow[C_COD_RPTO_MED_FTO]);
            FechaLectura = GetValor<DateTime>(dataRow[C_FECHA_LECTURA]);
            NombreArchivo = GetValor<string>(dataRow[C_NOMBRE_ARCHIVO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_LECTURA] = PkCodLectura;
            dataRow[C_FK_COD_PUNTO_MEDICION] = FkCodPtoMed;
            dataRow[C_COD_RPTO_MED_FTO] = CodRPtoMedFto;
            dataRow[C_FECHA_LECTURA] = FechaLectura;
            dataRow[C_NOMBRE_ARCHIVO] = NombreArchivo;
            dataRow[C_SEC_LOG] = SecLog;
        }
    }

    public interface IMC_LecturaMgr
    {
        bool Guardar(MC_Lectura obj);
        DataTable GetTabla();
        BindingList<MC_Lectura> GetLista();
        List<RegistroLectura> GetRegistrosDesdeFecha(long p, DateTime dateTime);
        RegistroLectura GetUltimoRegistroBD(long p);
        void Guardar(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros);

        string CalcularDatosLectura(long codPuntoMedicion, DateTime dateTime, DateTime dateTime_2);
    }

    public class MC_LecturaMgr
    {
        #region Singleton
        private static IMC_LecturaMgr _instancia;
        public static IMC_LecturaMgr Instancia
        {
            get { return _instancia; }
        }

        static MC_LecturaMgr()
        {
            _instancia = Instanciador.Instancia.IntanciarPlugin<IMC_LecturaMgr>();
        }

        private MC_LecturaMgr()
        {
        }
        #endregion Singleton
    }
}