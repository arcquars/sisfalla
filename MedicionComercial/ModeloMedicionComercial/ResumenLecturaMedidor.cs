using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.BLL;

namespace MC
{
    public class TablaResumenLecturaMedidor : DataTable
    {
        public TablaResumenLecturaMedidor()
        {
            DataColumn Seleccionado = new DataColumn("Seleccionado", typeof(bool));
            DataColumn PkCodPuntoMedicion = new DataColumn("PkCodPuntoMedicion", typeof(long));
            DataColumn FkCodPropietario = new DataColumn("FkCodPropietario", typeof(long));
            DataColumn NombrePuntoMedicion = new DataColumn("NombrePuntoMedicion", typeof(string));
            DataColumn Descripcion = new DataColumn("Descripcion", typeof(string));

            DataColumn PkCodFormato = new DataColumn("PkCodFormato", typeof(long));
            DataColumn ArchivoLectura = new DataColumn("ArchivoLectura", typeof(string));
            DataColumn RegistrosArchivo = new DataColumn("RegistrosArchivo", typeof(int));
            DataColumn RegistrosCargados = new DataColumn("RegistrosCargados", typeof(int));
            DataColumn FechaHoraPrimerRegistro = new DataColumn("FechaHoraPrimerRegistro", typeof(string));
            DataColumn FechaHoraUltimoRegistro = new DataColumn("FechaHoraUltimoRegistro", typeof(string));

            base.Columns.Add(Seleccionado);
            base.Columns.Add(PkCodPuntoMedicion);
            base.Columns.Add(FkCodPropietario);
            base.Columns.Add(NombrePuntoMedicion);
            base.Columns.Add(Descripcion);

            base.Columns.Add(PkCodFormato);
            base.Columns.Add(ArchivoLectura);
            base.Columns.Add(RegistrosArchivo);
            base.Columns.Add(RegistrosCargados);
            base.Columns.Add(FechaHoraPrimerRegistro);
            base.Columns.Add(FechaHoraUltimoRegistro);

            foreach (IValidadorLectura v in ValidadorLecturaMgr.Instancia.GetValidadores())
            {
                DataColumn c = new DataColumn(v.Nombre, v.TipoDato);
                base.Columns.Add(c);
            }
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new ResumenLecturaMedidor(builder);
        }
    }

    public class ResumenLecturaMedidor : DataRow
    {
        public ResumenLecturaMedidor(DataRowBuilder b)
            : base(b)
        {
            Seleccionado = true;
            PkCodPuntoMedicion = 0;
            FkCodPropietario = 0;
            NombrePuntoMedicion = string.Empty;
            Descripcion = string.Empty;

            PkCodFormato = 0;
            ArchivoLectura = null;
            RegistrosArchivo = 0;
            RegistrosCargados = 0;
            FechaHoraPrimerRegistro = string.Empty;
            FechaHoraUltimoRegistro = string.Empty;
        }

        public void LeerDatosMedidor(DataRow rowMedidor)
        {
            Seleccionado = true;
            PkCodPuntoMedicion = ObjetoDeNegocio.GetValor<long>(rowMedidor["pk_cod_punto_medicion"]);
            FkCodPropietario = ObjetoDeNegocio.GetValor<long>(rowMedidor["fk_cod_propietario"]);
            NombrePuntoMedicion = ObjetoDeNegocio.GetValor<string>(rowMedidor["nombre"]);
            Descripcion = ObjetoDeNegocio.GetValor<string>(rowMedidor["descripcion"]);
        }

        public bool Seleccionado
        {
            get { return (bool)this["Seleccionado"]; }
            set { this["Seleccionado"] = value; }
        }
        public long PkCodPuntoMedicion
        {
            get { return (long)this["PkCodPuntoMedicion"]; }
            set { this["PkCodPuntoMedicion"] = value; }
        }
        public long FkCodPropietario
        {
            get { return (long)this["FkCodPropietario"]; }
            set { this["FkCodPropietario"] = value; }
        }
        public string NombrePuntoMedicion
        {
            get { return (string)this["NombrePuntoMedicion"]; }
            set { this["NombrePuntoMedicion"] = value; }
        }
        public string Descripcion
        {
            get { return (string)this["Descripcion"]; }
            set { this["Descripcion"] = value; }
        }

        public long PkCodFormato
        {
            get { return (long)this["PkCodFormato"]; }
            set { this["PkCodFormato"] = value; }
        }
        public string ArchivoLectura
        {
            get { return (string)this["ArchivoLectura"]; }
            set { this["ArchivoLectura"] = value; }
        }
        public int RegistrosArchivo
        {
            get { return (int)this["RegistrosArchivo"]; }
            set { this["RegistrosArchivo"] = value; }
        }
        public int RegistrosCargados
        {
            get { return (int)this["RegistrosCargados"]; }
            set { this["RegistrosCargados"] = value; }
        }
        public string FechaHoraPrimerRegistro
        {
            get { return (string)this["FechaHoraPrimerRegistro"]; }
            set { this["FechaHoraPrimerRegistro"] = value; }
        }
        public string FechaHoraUltimoRegistro
        {
            get { return (string)this["FechaHoraUltimoRegistro"]; }
            set { this["FechaHoraUltimoRegistro"] = value; }
        }
    }
}
