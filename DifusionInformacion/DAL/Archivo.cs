using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;


namespace DifusionInformacion
{
    class Archivo
    {
        public long codCategoria { get; set; }
        public string tituloArchivo { get; set; }
        public string nombreArchivo { get; set; }
        public string extensionArchivo { get; set; }
        public string archivoGenerado { get; set; }
        public string extensionArchivoGenerado { get; set; }
        public string hojaContenido { get; set; }
        public string rangoHoja { get; set; }
        
        public bool generarZIP { get; set; }
        public bool generado { get; set; }
        public bool renombrado { get; set; }
        public bool publicarIntranetEstadistica { get; set; }
        public bool publicarWebPublica { get; set; }
        public bool publicarWebPrivada { get; set; }
        public bool publicarIntranet { get; set; }
        public bool publicarInfocndc { get; set; }

        public long numeroCategoriaWebPub { get; set; }
        public long numeroCategoriaWebPri { get; set; }
        public long numeroCategoriaIntranet { get; set; }
        public long numeroCategoriaIntranetEstadistica { get; set; }
        public string tablaIntranet { get; set; }
        public string tablaIntranetEstadistica { get; set; }
        public string tablaWebPublica { get; set; }
        public string tablaWebPrivada { get; set; }

        public Archivo(DataRow dataRow)
        { Leer(dataRow); }

        private void Leer(DataRow dataRow)
        {
            codCategoria = ObjetoDeNegocio.GetValor<long>(dataRow["COD_CATEGORIA"]);
            tituloArchivo = ObjetoDeNegocio.GetValor<string>(dataRow["TITULO"]);
            nombreArchivo = ObjetoDeNegocio.GetValor<string>(dataRow["NOMBRE_ORIGEN_FORMATO"]);
            extensionArchivo = ObjetoDeNegocio.GetValor<string>(dataRow["NOMBRE_ORIGEN_EXT"]);
            archivoGenerado = ObjetoDeNegocio.GetValor<string>(dataRow["ARCHIVO_FORMATO"]);
            extensionArchivoGenerado = ObjetoDeNegocio.GetValor<string>(dataRow["ARCHIVO_FORMATO_EXT"]);
            hojaContenido = ObjetoDeNegocio.GetValor<string>(dataRow["NOMBRE_HOJA"]);
            rangoHoja = ObjetoDeNegocio.GetValor<string>(dataRow["RANGO_HOJA"]);
            generarZIP = UtilPublicar.EsVerdadero(ObjetoDeNegocio.GetValor<long>(dataRow["ARCHIVO_FORMATO_ZIP"]));
            renombrado = UtilPublicar.EsVerdadero(ObjetoDeNegocio.GetValor<long>(dataRow["ARCHIVO_RENOMBRADO"]));
            
            generado = UtilPublicar.EsVerdadero(ObjetoDeNegocio.GetValor<long>(dataRow["ARCHIVO_GENERADO"]));

            publicarWebPublica = UtilPublicar.EsVerdadero(ObjetoDeNegocio.GetValor<long>(dataRow["DESTINO_AREA_PUB_WEB"]));
            publicarWebPrivada = UtilPublicar.EsVerdadero(ObjetoDeNegocio.GetValor<long>(dataRow["DESTINO_AREA_PRI_WEB"]));
            publicarIntranet = UtilPublicar.EsVerdadero(ObjetoDeNegocio.GetValor<long>(dataRow["DESTINO_INTRANET"]));
            publicarIntranetEstadistica = UtilPublicar.EsVerdadero(ObjetoDeNegocio.GetValor<long>(dataRow["DESTINO_INTRANET_ESTADISTICA"]));
            publicarInfocndc = UtilPublicar.EsVerdadero(ObjetoDeNegocio.GetValor<long>(dataRow["DESTINO_INFOCNDC"]));

            numeroCategoriaWebPub = ObjetoDeNegocio.GetValor<long>(dataRow["COD_CATEGORIA_WEB_PUB"]);
            numeroCategoriaWebPri = ObjetoDeNegocio.GetValor<long>(dataRow["COD_CATEGORIA_WEB_PRI"]);
            numeroCategoriaIntranet = ObjetoDeNegocio.GetValor<long>(dataRow["COD_CATEGORIA_INTRANET"]);
            numeroCategoriaIntranetEstadistica = ObjetoDeNegocio.GetValor<long>(dataRow["COD_CATEGORIA_INTRANET_ESTAD"]);
            tablaIntranet = ObjetoDeNegocio.GetValor<string>(dataRow["TABLA_INTRANET"]);
            tablaIntranetEstadistica = ObjetoDeNegocio.GetValor<string>(dataRow["TABLA_INTRANET_ESTAD"]);
            tablaWebPublica = ObjetoDeNegocio.GetValor<string>(dataRow["TABLA_WEB_PUB"]);
            tablaWebPrivada = ObjetoDeNegocio.GetValor<string>(dataRow["TABLA_WEB_PRI"]);

            /*
            archivo = dataRow["archivo"].ToString();
            archivo_zip = dataRow["archivo_zip"].ToString();
            fecha = dataRow["fecha"].ToString();
            hora = dataRow["hora"].ToString();
            fechadoc = dataRow["fechadoc"].ToString();
            anio = (int)dataRow["anio"];
            num = (int)dataRow["num"];*/
            /*
            codCategoria = GetValor<int>(dataRow["COD_CATEGORIA"]);
            
            PkOrigenInforme = GetValor<long>(dataRow[C_PK_ORIGEN_INFORME]);
            PkDCodTipoinforme = GetValor<long>(dataRow[C_PK_D_COD_TIPOINFORME]);
            CodComponenteFallado = GetValor<long>(dataRow[C_COD_COMPONENTE_FALLADO]);
            FecInicio = GetValor<DateTime>(dataRow[C_FEC_INICIO]);
            FecFinal = GetValor<DateTime>(dataRow[C_FEC_FINAL]);
            Descripcion = GetValor<string>(dataRow[C_DESCRIPCION]);
            ProcRestitucion = GetValor<string>(dataRow[C_RESTITUCION]);
            InformacionAdicional = GetValor<string>(dataRow[C_INFORMACION_ADICIONAL]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
             * */
        }
        

    }
}
