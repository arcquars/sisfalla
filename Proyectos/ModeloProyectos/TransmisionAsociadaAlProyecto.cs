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
    public class TransmisionAsociadaAlProyecto : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_TRANS_ASOCIADA_AL_PROY";

        public const string C_PK_TRANS_ASOCIADA_AL_PROY = "PK_TRANS_ASOCIADA_AL_PROY";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_NODO_DE_CONEXION = "NODO_DE_CONEXION";
        public const string C_TENSION = "TENSION";
        public const string C_LONGITUD = "LONGITUD";
        public const string C_COSTO = "COSTO";
        public const string C_CAPACIDAD_CONEXION = "CAPACIDAD_CONEXION";
        public const string C_OBSERVACIONES = "OBSERVACIONES";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";
        public const string C_RESISTENCIA = "RESISTENCIA";
        public const string C_REACTANCIA = "REACTANCIA";
        public const string C_SUSCEPTANCIA = "SUSCEPTANCIA";

        public long PkTransAsociadaAlProy { get; set; }
        public long FkProyecto { get; set; }
        public string NodoDeConexion { get; set; }
        public double Tension { get; set; }
        public double Longitud { get; set; }
        public double Costo { get; set; }
        public double CapacidadConexion { get; set; }
        public string Observaciones { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public double Resistencia { get; set; }
        public double Reactancia { get; set; }
        public double Susceptancia { get; set; }
        public TransmisionAsociadaAlProyecto() { }

        public TransmisionAsociadaAlProyecto(DataRow dataRow)
        {
            PkTransAsociadaAlProy = GetValor<long>(dataRow[C_PK_TRANS_ASOCIADA_AL_PROY]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            NodoDeConexion = GetValor<string>(dataRow[C_NODO_DE_CONEXION]);
            Tension = GetValor<double>(dataRow[C_TENSION]);
            Longitud = GetValor<double>(dataRow[C_LONGITUD]);
            Costo = GetValor<double>(dataRow[C_COSTO]);
            CapacidadConexion = GetValor<double>(dataRow[C_CAPACIDAD_CONEXION]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            Resistencia = GetValor<double>(dataRow[C_RESISTENCIA]);
            Reactancia = GetValor<double>(dataRow[C_REACTANCIA]);
            Susceptancia = GetValor<double>(dataRow[C_SUSCEPTANCIA]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_TRANS_ASOCIADA_AL_PROY] = PkTransAsociadaAlProy;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_NODO_DE_CONEXION] = NodoDeConexion;
            dataRow[C_TENSION] = Tension;
            dataRow[C_LONGITUD] = Longitud;
            dataRow[C_COSTO] = Costo;
            dataRow[C_CAPACIDAD_CONEXION] = CapacidadConexion;
            dataRow[C_OBSERVACIONES] = Observaciones;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
            dataRow[C_RESISTENCIA] = Resistencia;
            dataRow[C_REACTANCIA] = Reactancia;
            dataRow[C_SUSCEPTANCIA] = Susceptancia;
        }

        public override void Leer(DataRow dataRow)
        {
            PkTransAsociadaAlProy = GetValor<long>(dataRow[C_PK_TRANS_ASOCIADA_AL_PROY]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            NodoDeConexion = GetValor<string>(dataRow[C_NODO_DE_CONEXION]);
            Tension = GetValor<double>(dataRow[C_TENSION]);
            Longitud = GetValor<double>(dataRow[C_LONGITUD]);
            Costo = GetValor<double>(dataRow[C_COSTO]);
            CapacidadConexion = GetValor<double>(dataRow[C_CAPACIDAD_CONEXION]);
            Observaciones = GetValor<string>(dataRow[C_OBSERVACIONES]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            Resistencia = GetValor<double>(dataRow[C_RESISTENCIA]);
            Reactancia = GetValor<double>(dataRow[C_REACTANCIA]);
            Susceptancia = GetValor<double>(dataRow[C_SUSCEPTANCIA]);
        }
    }

    public interface ITransmisionAsociadaAlProyectoMgr
    {
        void Guardar(TransmisionAsociadaAlProyecto obj);
        DataTable GetTabla();
        BindingList<TransmisionAsociadaAlProyecto> GetLista();
    }
}
