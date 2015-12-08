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
    public class ProyectoMaestro : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_PROYECTO_MAESTRO";

        public const string C_PK_PROYECTO_MAESTRO = "PK_PROYECTO_MAESTRO";
        public const string C_D_TIPO_PROYECTO = "D_TIPO_PROYECTO";
        public const string C_NOMBRE = "NOMBRE";
        public const string C_CODIGO = "CODIGO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_ESTADO = "ESTADO";
        public const string C_D_TIPO_PROYECTO_PADRE = "D_TIPO_PROYECTO_PADRE";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";

        public long PkProyectoMaestro { get; set; }
        public long DTipoProyecto { get; set; }
        public long DTipoProyectoPadre { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public long SecLog { get; set; }
        public string Estado { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public ProyectoMaestro() { }

        public ProyectoMaestro(DataRow dataRow)
        {
            PkProyectoMaestro = GetValor<long>(dataRow[C_PK_PROYECTO_MAESTRO]);
            DTipoProyecto = GetValor<long>(dataRow[C_D_TIPO_PROYECTO]);
            DTipoProyectoPadre = GetValor<long>(dataRow[C_D_TIPO_PROYECTO_PADRE]);
            Nombre = GetValor<string>(dataRow[C_NOMBRE]);
            Codigo = GetValor<string>(dataRow[C_CODIGO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            Estado = GetValor<string>(dataRow[C_ESTADO]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public override void Leer(DataRow dataRow)
        {
            PkProyectoMaestro = GetValor<long>(dataRow[C_PK_PROYECTO_MAESTRO]);
            DTipoProyecto = GetValor<long>(dataRow[C_D_TIPO_PROYECTO]);
            DTipoProyectoPadre = GetValor<long>(dataRow[C_D_TIPO_PROYECTO_PADRE]);
            Nombre = GetValor<string>(dataRow[C_NOMBRE]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            Codigo = GetValor<string>(dataRow[C_CODIGO]);
            Estado = GetValor<string>(dataRow[C_ESTADO]);
            FechaDeRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_PROYECTO_MAESTRO] = PkProyectoMaestro;
            dataRow[C_D_TIPO_PROYECTO] = DTipoProyecto;
            dataRow[C_D_TIPO_PROYECTO_PADRE] = DTipoProyectoPadre;
            dataRow[C_NOMBRE] = Nombre;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_CODIGO] = Codigo;
            dataRow[C_ESTADO] = Estado;
            dataRow[C_FECHA_REGISTRO] = FechaDeRegistro;
        }

        public Proyecto CrearNuevoProyecto()
        {
            Proyecto resultado = new Proyecto();
            resultado.FkProyectoMaestro = this.PkProyectoMaestro;
            resultado.EsNuevo = true;
            return resultado;
        }
    }

    public interface IProyectoMaestroMgr
    {
        void Guardar(ProyectoMaestro obj);
        DataTable GetTabla();
        BindingList<ProyectoMaestro> GetLista();
    }

    public class GeneradorCodigoProyectoMaestro
    {
        #region Singleton
        private static GeneradorCodigoProyectoMaestro _instancia;
        public static GeneradorCodigoProyectoMaestro Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new GeneradorCodigoProyectoMaestro();
                }
                return _instancia;
            }
        }
        private GeneradorCodigoProyectoMaestro()
        { }
        #endregion
        public void AsignarCodigo(ProyectoMaestro proyectoMaestro, string prefijo)
        {
            if (string.IsNullOrEmpty(proyectoMaestro.Codigo))
            {
                string corr = "";
                DateTime fecha = Sesion.Instancia.FechaHoraServidor.Value.Date;
                string gestion = (fecha.Year % 100).ToString();
                
                if (gestion.Length == 1)
                {
                    gestion = "0" + gestion;
                }
                int correlativo =ModeloMgr.Instancia.IdMgr.GetID(prefijo + "-" + gestion);
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
                proyectoMaestro.Codigo = corr + prefijo + "-" + gestion;
            }
        }

    }
}
