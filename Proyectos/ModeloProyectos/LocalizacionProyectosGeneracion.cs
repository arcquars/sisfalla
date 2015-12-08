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
    public class LocalizacionProyectosGeneracion : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_LOCAL_PROYS_GENERACION";

        public const string C_PK_LOCAL_PROY_GENERACION = "PK_LOCAL_PROY_GENERACION";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_LOCALIDAD = "LOCALIDAD";
        public const string C_PROVINCIA = "PROVINCIA";
        public const string C_D_COD_DEPARTAMENTO = "D_COD_DEPARTAMENTO";
        public const string C_LATITUD = "LATITUD";
        public const string C_ALTITUD = "ALTITUD";
        public const string C_LONGITUD = "LONGITUD";
        public const string C_UNIDAD_MEDIDA = "UNIDAD_MEDIDA";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_LATITUD_UTM = "LATITUD_UTM";
        public const string C_LONGITUD_UTM = "LONGITUD_UTM";

        public long PkLocalProyGeneracion { get; set; }
        public long FkProyecto { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public long DCodDepartamento { get; set; }
        public string Latitud { get; set; }
        public int Altitud { get; set; }
        public string Longitud { get; set; }
        public string UnidadMedida { get; set; }
        public long SecLog { get; set; }
        public double LatitudUtm { get; set; }
        public double LongitudUtm { get; set; }

        public LocalizacionProyectosGeneracion() { }

        public LocalizacionProyectosGeneracion(DataRow dataRow)
        {
            PkLocalProyGeneracion = GetValor<long>(dataRow[C_PK_LOCAL_PROY_GENERACION]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            Localidad = GetValor<string>(dataRow[C_LOCALIDAD]);
            Provincia = GetValor<string>(dataRow[C_PROVINCIA]);
            DCodDepartamento = GetValor<long>(dataRow[C_D_COD_DEPARTAMENTO]);
            Latitud = GetValor<string>(dataRow[C_LATITUD]);
            Longitud = GetValor<string>(dataRow[C_LONGITUD]);
            UnidadMedida = GetValor<string>(dataRow[C_UNIDAD_MEDIDA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            Altitud = GetValor<int>(dataRow[C_ALTITUD]);
            LatitudUtm = GetValor<double>(dataRow[C_LATITUD_UTM]);
            LongitudUtm = GetValor<double>(dataRow[C_LONGITUD_UTM]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_LOCAL_PROY_GENERACION] = PkLocalProyGeneracion;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_LOCALIDAD] = Localidad;
            dataRow[C_PROVINCIA] = Provincia;
            dataRow[C_D_COD_DEPARTAMENTO] = DCodDepartamento;
            dataRow[C_LATITUD] = Latitud;
            dataRow[C_ALTITUD] = Altitud;
            dataRow[C_LONGITUD] = Longitud;
            dataRow[C_UNIDAD_MEDIDA] = UnidadMedida;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_LATITUD_UTM] = LatitudUtm;
            dataRow[C_LONGITUD_UTM] = LongitudUtm;
        }

        public override void Leer(DataRow dataRow)
        {
            PkLocalProyGeneracion = GetValor<long>(dataRow[C_PK_LOCAL_PROY_GENERACION]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            Localidad = GetValor<string>(dataRow[C_LOCALIDAD]);
            Provincia = GetValor<string>(dataRow[C_PROVINCIA]);
            DCodDepartamento = GetValor<long>(dataRow[C_D_COD_DEPARTAMENTO]);
            Latitud = GetValor<string>(dataRow[C_LATITUD]);
            Altitud = GetValor<int>(dataRow[C_ALTITUD]);
            Longitud = GetValor<string>(dataRow[C_LONGITUD]);
            UnidadMedida = GetValor<string>(dataRow[C_UNIDAD_MEDIDA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            LatitudUtm = GetValor<double>(dataRow[C_LATITUD_UTM]);
            LongitudUtm = GetValor<double>(dataRow[C_LONGITUD_UTM]);
        }
    }

    public interface ILocalizacionProyectosGeneracionMgr
    {
        void Guardar(LocalizacionProyectosGeneracion obj);
        DataTable GetTabla();
        BindingList<LocalizacionProyectosGeneracion> GetLista();
    }
}
