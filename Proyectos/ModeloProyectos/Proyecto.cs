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
    public class Proyecto : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_PROYECTO";

        public const string C_PK_PROYECTO = "PK_PROYECTO";
        public const string C_FK_PROYECTO_MAESTRO = "FK_PROYECTO_MAESTRO";
        public const string C_D_COD_ETAPA = "D_COD_ETAPA";
        public const string C_D_COD_PERSONA = "D_COD_PERSONA";
        public const string C_DESCRIPCION = "DESCRIPCION";
        public const string C_ESQUEMA = "ESQUEMA";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_CODIGO = "CODIGO";
        public const string C_ESTADO = "ESTADO";
        public const string C_NOMBRE_ESQUEMA = "NOMBRE_ESQUEMA";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkProyecto { get; set; }
        public long FkProyectoMaestro { get; set; }
        public long DCodEtapa { get; set; }
        public long DCodPersona { get; set; }
        public string Descripcion { get; set; }
        public Byte[] Esquema { get; set; }
        public long SecLog { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public string NombreEsquema { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public Proyecto() { }

        public Proyecto(DataRow dataRow)
        {
            PkProyecto = GetValor<long>(dataRow[C_PK_PROYECTO]);
            FkProyectoMaestro = GetValor<long>(dataRow[C_FK_PROYECTO_MAESTRO]);
            DCodEtapa = GetValor<long>(dataRow[C_D_COD_ETAPA]);
            DCodPersona = GetValor<long>(dataRow[C_D_COD_PERSONA]);
            Descripcion = GetValor<string>(dataRow[C_DESCRIPCION]);
            Esquema = GetValor<Byte[]>(dataRow[C_ESQUEMA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            Codigo = GetValor<string>(dataRow[C_CODIGO]);
            Estado = GetValor<string>(dataRow[C_ESTADO]);
            NombreEsquema = GetValor<string>(dataRow[C_NOMBRE_ESQUEMA]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_PROYECTO] = PkProyecto;
            dataRow[C_FK_PROYECTO_MAESTRO] = FkProyectoMaestro;
            dataRow[C_D_COD_ETAPA] = DCodEtapa;
            dataRow[C_D_COD_PERSONA] = DCodPersona;
            dataRow[C_DESCRIPCION] = Descripcion;
            dataRow[C_ESQUEMA] = Esquema;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_CODIGO] = Codigo;
            dataRow[C_ESTADO] = Estado;
            dataRow[C_NOMBRE_ESQUEMA] = NombreEsquema;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkProyecto = GetValor<long>(dataRow[C_PK_PROYECTO]);
            FkProyectoMaestro = GetValor<long>(dataRow[C_FK_PROYECTO_MAESTRO]);
            DCodEtapa = GetValor<long>(dataRow[C_D_COD_ETAPA]);
            DCodPersona = GetValor<long>(dataRow[C_D_COD_PERSONA]);
            Descripcion = GetValor<string>(dataRow[C_DESCRIPCION]);
            Esquema = GetValor<Byte[]>(dataRow[C_ESQUEMA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            Codigo = GetValor<string>(dataRow[C_CODIGO]);
            Estado = GetValor<string>(dataRow[C_ESTADO]);
            NombreEsquema = GetValor<string>(dataRow[C_NOMBRE_ESQUEMA]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface IProyectoMgr
    {
        void Guardar(Proyecto obj);
        DataTable GetTabla();
        BindingList<Proyecto> GetLista();
    }

    public class GeneradorCodigoProyecto
    {
        #region Singleton
        private static GeneradorCodigoProyecto _instancia;
        public static GeneradorCodigoProyecto Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new GeneradorCodigoProyecto();
                }
                return _instancia;
            }
        }
        private GeneradorCodigoProyecto()
        { }
        #endregion
        public void AsignarCodigo(Proyecto proyecto, string prefijoEtapa, string prefijoTipoProy)
        {
            if (string.IsNullOrEmpty(proyecto.Codigo))
            {
                string corr = "";
                DateTime fecha = Sesion.Instancia.FechaHoraServidor.Value.Date;
                string gestion = (fecha.Year % 100).ToString();

                if (gestion.Length == 1)
                {
                    gestion = "0" + gestion;
                }
                int correlativo = ModeloMgr.Instancia.IdMgr.GetID(prefijoTipoProy +"-"+ prefijoEtapa + "-" + gestion);
                if (correlativo < 10)
                {
                    corr = "0000" + correlativo;
                }
                else
                {
                    if (correlativo <= 99 && correlativo >= 10)
                    {
                        corr = "000" + correlativo.ToString();
                    }
                    else
                    {
                        if (correlativo <= 999 && correlativo >= 100)
                        {
                            corr = "00" + correlativo.ToString();
                        }
                        else
                        {
                            if (correlativo <= 9999 && correlativo >= 1000)
                            {
                                corr = "00" + correlativo.ToString();
                            }
                            else
                            {
                                if (correlativo <= 99999 && correlativo >= 10000)
                                {
                                    corr = "0" + correlativo.ToString();
                                }
                                else
                                {
                                    if (correlativo <= 999999 && correlativo >= 100000)
                                    {
                                        corr = correlativo.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                proyecto.Codigo = corr + prefijoTipoProy + "-" + prefijoEtapa + "-" + gestion;
            }
        }

    }
}
