using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using CNDC.Dominios;

namespace ModeloSisFalla
{
    [Serializable]
    public class InformeFalla : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_GF_INFORMEFALLA";

        public const string C_PK_COD_FALLA = "PK_COD_FALLA";
        public const string C_PK_ORIGEN_INFORME = "PK_ORIGEN_INFORME";
        public const string C_PK_D_COD_TIPOINFORME = "PK_D_COD_TIPOINFORME";
        public const string C_COD_COMPONENTE_FALLADO = "COD_COMPONENTE_FALLADO";
        public const string C_FEC_INICIO = "FEC_INICIO";
        public const string C_FEC_FINAL = "FEC_FINAL";
        public const string C_DESCRIPCION = "DESCRIPCION_INFORME";
        public const string C_RESTITUCION = "RESTITUCION";
        public const string C_INFORMACION_ADICIONAL = "INFORMACION_ADICIONAL";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_D_COD_ORIGEN = "D_COD_ORIGEN";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_OPERACION_PROTECCIONES = "OPERACION_PROTECCIONES";
        public const string C_D_COD_TIPO_DESCONEXION = "D_COD_TIPO_DESCONEXION";
        public const string C_D_COD_CAUSA = "D_COD_CAUSA";
        public const string C_COD_PERSONA = "COD_PERSONA";
        public const string C_COD_ESTADO_INF = "D_COD_ESTADO_INF";
        public const string C_NUM_FALLA_AGENTE = "NUM_FALLA_AGENTE";
        public const string C_FEC_REGISTRO = "FECHA_REGISTRO";
        public const string C_ELABORADO_POR = "ELABORADO_POR";        
        public int PkCodFalla { get; set; }
        public long PkOrigenInforme { get; set; }
        public long PkDCodTipoinforme { get; set; }
        public long CodComponenteFallado { get; set; }
        public DateTime FecInicio { get; set; }
        public DateTime FecFinal { get; set; }
        public string Descripcion { get; set; }
        public string ProcRestitucion { get; set; }
        public string InformacionAdicional { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public long DCodOrigen { get; set; }
        public long SincVer { get; set; }
        public string OperacionProtecciones { get; set; }
        public long DCodTipoDesconexion { get; set; }
        public long DCodCausa { get; set; }
        public long CodPersona { get; set; }
        public long CodEstadoInf { get; set; }
        public string NumFallaAgente { get; set; }
        public string ElaboradoPor { get; set; }
        public DateTime FecRegistro { get; set; }
   

        public InformeFalla() { FecInicio = DateTime.Now; }

        public InformeFalla(DataRow dataRow)
        { Leer(dataRow); }

        public InformeFalla(RegFalla regFalla)
        {
            EsNuevo = true;
            CodEstadoInf = (long)D_COD_ESTADO_INF.EN_ELABORACION;
            PkCodFalla = regFalla.CodFalla;
            FecInicio = regFalla.FecInicio;

            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                Descripcion = regFalla.DescripcionFalla;
            }
            
            CodComponenteFallado = (long)regFalla.CodComponente;
            DCodOrigen = regFalla.CodOrigen;
            DCodTipoDesconexion = regFalla.CodTipoDesconexion;
            DCodCausa = regFalla.CodCausa;
            CodPersona = (long)Sesion.Instancia.UsuarioActual.PkCodUsuario;
        }

        public void Leer(DataRow dataRow)
        {
            PkCodFalla = GetValor<int>(dataRow[C_PK_COD_FALLA]);
            PkOrigenInforme = GetValor<long>(dataRow[C_PK_ORIGEN_INFORME]);
            PkDCodTipoinforme = GetValor<long>(dataRow[C_PK_D_COD_TIPOINFORME]);
            CodComponenteFallado = GetValor<long>(dataRow[C_COD_COMPONENTE_FALLADO]);
            FecInicio = GetValor<DateTime>(dataRow[C_FEC_INICIO]);
            FecFinal = GetValor<DateTime>(dataRow[C_FEC_FINAL]);
            Descripcion = GetValor<string>(dataRow[C_DESCRIPCION]);
            ProcRestitucion = GetValor<string>(dataRow[C_RESTITUCION]);
            InformacionAdicional = GetValor<string>(dataRow[C_INFORMACION_ADICIONAL]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            DCodOrigen = GetValor<long>(dataRow[C_D_COD_ORIGEN]);
            SincVer = GetValor<long>(dataRow[C_SINC_VER]);
            OperacionProtecciones = GetValor<string>(dataRow[C_OPERACION_PROTECCIONES]);
            DCodTipoDesconexion = GetValor<long>(dataRow[C_D_COD_TIPO_DESCONEXION]);
            DCodCausa = GetValor<long>(dataRow[C_D_COD_CAUSA]);
            CodPersona = GetValor<long>(dataRow[C_COD_PERSONA]);
            CodEstadoInf = GetValor<long>(dataRow[C_COD_ESTADO_INF]);
            NumFallaAgente = GetValor<string>(dataRow[C_NUM_FALLA_AGENTE]);
            FecRegistro = GetValor<DateTime>(dataRow[C_FEC_REGISTRO]);
            ElaboradoPor = GetValor<string>(dataRow[C_ELABORADO_POR]);
        }

        public static string GetTexto(long tipoInforme)
        {
            string txt = string.Empty;
            PK_D_COD_TIPOINFORME tipo = (PK_D_COD_TIPOINFORME)tipoInforme;
            switch (tipo)
            {
                case PK_D_COD_TIPOINFORME.PRELIMINAR:
                    txt = "PRELIMINAR";
                    break;
                case PK_D_COD_TIPOINFORME.FINAL:
                    txt = "FINAL";
                    break;
                case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                    txt = "RECTIFICATORIO";
                    break;
            }
            return txt;
        }

        public override bool Equals(object obj)
        {
            InformeFalla inf = (InformeFalla)obj;
            return (inf.PkCodFalla == PkCodFalla && inf.PkDCodTipoinforme == PkDCodTipoinforme && inf.PkOrigenInforme == PkOrigenInforme);
        }

        public RRegFallaComponente CrearNuevoRRegFallaComponente()
        {
            RRegFallaComponente nuevoCompCompr = new RRegFallaComponente();
            nuevoCompCompr.EsNuevo = true;
            nuevoCompCompr.PkCodFalla = PkCodFalla;
            nuevoCompCompr.PkDCodTipoinforme = PkDCodTipoinforme;
            nuevoCompCompr.PkOrigenInforme = PkOrigenInforme;
            RegFalla rF = ModeloMgr.Instancia.RegFallaMgr.GetFalla(this.PkCodFalla);
            nuevoCompCompr.FecApertura = rF.FecInicio;
            return nuevoCompCompr;
        }

        public OperacionInterruptores CrearNuevoOpInterruptor()
        {
            OperacionInterruptores resultado = new OperacionInterruptores();
            resultado.EsNuevo = true;
            resultado.PkCodFalla = this.PkCodFalla;
            resultado.PkDCodInforme = this.PkDCodTipoinforme;
            resultado.PkOrigenInforme = this.PkOrigenInforme;

            RegFalla rF = ModeloMgr.Instancia.RegFallaMgr.GetFalla(this.PkCodFalla);
            resultado.FechaApertura = rF.FecInicio;
            resultado.FechaCierre = rF.FecInicio;
            return resultado;
        }

        public OperacionAlimentador CrearNuevoOpAlimentador()
        {
            OperacionAlimentador resultado = new OperacionAlimentador();
            resultado.EsNuevo = true;
            resultado.PkCodFalla = this.PkCodFalla;
            resultado.PkDCodInforme = this.PkDCodTipoinforme;
            resultado.PkOrigenInforme = this.PkOrigenInforme;
            
            RegFalla rF = ModeloMgr.Instancia.RegFallaMgr.GetFalla(this.PkCodFalla);
            resultado.FechaApertura = rF.FecInicio;
            resultado.FechaCierre = rF.FecInicio;
            return resultado;
        }

        public DataSet GetDataSet()
        {
            DataSet resultado = new DataSet("Informe_Falla");
            DataTable informeFalla = ModeloMgr.Instancia.InformeFallaMgr.GetDatos(InformeFalla.NOMBRE_TABLA, PkCodFalla, PkDCodTipoinforme, PkOrigenInforme);
            DataTable opAlimentador = ModeloMgr.Instancia.InformeFallaMgr.GetDatos(OperacionAlimentador.NOMBRE_TABLA, PkCodFalla, PkDCodTipoinforme, PkOrigenInforme);
            DataTable opInterruptor = ModeloMgr.Instancia.InformeFallaMgr.GetDatos(OperacionInterruptores.NOMBRE_TABLA, PkCodFalla, PkDCodTipoinforme, PkOrigenInforme);
            DataTable relesOper = ModeloMgr.Instancia.InformeFallaMgr.GetDatos(RelesOperados.NOMBRE_TABLA, PkCodFalla, PkDCodTipoinforme, PkOrigenInforme);
            DataTable responsabilidad = ModeloMgr.Instancia.InformeFallaMgr.GetDatos(AsignacionResposabilidad.NOMBRE_TABLA, PkCodFalla, PkDCodTipoinforme, PkOrigenInforme);
            DataTable regFallaCompo = ModeloMgr.Instancia.InformeFallaMgr.GetDatos(RRegFallaComponente.NOMBRE_TABLA, PkCodFalla, PkDCodTipoinforme, PkOrigenInforme);
            DataTable tiempoDetalle = ModeloMgr.Instancia.InformeFallaMgr.GetDatos(TiempoDetalle.NOMBRE_TABLA, PkCodFalla, PkDCodTipoinforme, PkOrigenInforme);
            DataTable analisis = ModeloMgr.Instancia.InformeFallaMgr.GetDatos(AnalisisFalla.NOMBRE_TABLA , PkCodFalla, PkDCodTipoinforme, PkOrigenInforme);
          
            DataTable tablaColapso = ModeloMgr.Instancia.ColapsoMgr.GetDatos(PkCodFalla);            
            //informeFalla.Rows[0]["FECHA_REGISTRO"] = System.DateTime.Now ;
            resultado.Tables.Add(informeFalla);
            resultado.Tables.Add(opAlimentador);
            resultado.Tables.Add(opInterruptor);
            resultado.Tables.Add(relesOper);
            resultado.Tables.Add(responsabilidad);
            resultado.Tables.Add(regFallaCompo);
            resultado.Tables.Add(tiempoDetalle);
            resultado.Tables.Add(tablaColapso);
            resultado.Tables.Add(analisis);
            //@JLA 16/mayo/2014 
            
            //informeFalla.Rows[0]["d_cod_estado_inf"] = 3594;
            return resultado;
        }

        public void Revertir()
        {
            CodEstadoInf = (long)D_COD_ESTADO_INF.EN_ELABORACION;
            ModeloMgr.Instancia.InformeFallaMgr.Guardar(this);

            Operacion op = new Operacion();
            if ((PK_D_COD_TIPOINFORME)PkDCodTipoinforme == PK_D_COD_TIPOINFORME.PRELIMINAR)
            {
                op.RegistrarOperacion(DOMINIOS_OPERACION.CNDC_REVIERTE_INF_PRE_AGENTE, PkCodFalla, PkOrigenInforme);
            }
            else
            {
                op.RegistrarOperacion(DOMINIOS_OPERACION.CNDC_REVIERTE_INF_FIN_AGENTE, PkCodFalla, PkOrigenInforme);
            }
        }

        public InformeFalla GetInformeAnterior()
        {
            InformeFalla resultado = null;
            if (PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.FINAL)
            {
                resultado = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(PkCodFalla, PkOrigenInforme, (long)PK_D_COD_TIPOINFORME.PRELIMINAR);
            }
            else if (PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.RECTIFICATORIO)
            {
                resultado = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(PkCodFalla, PkOrigenInforme, (long)PK_D_COD_TIPOINFORME.FINAL);
            }

            return resultado;
        }

        public ResultadoCopiaInforme 
            CopiarDatosDeInformeAnterior()
        {
            ResultadoCopiaInforme resultado = ResultadoCopiaInforme.NoExisteOrigen;
            InformeFalla infAnterior = GetInformeAnterior();
            if (infAnterior != null)
            {
                resultado = Copiar(infAnterior.PkDCodTipoinforme, PkDCodTipoinforme);
                if (resultado == ResultadoCopiaInforme.OK)
                {
                    Descripcion = infAnterior.Descripcion;
                    DCodOrigen = infAnterior.DCodOrigen;
                    DCodTipoDesconexion = infAnterior.DCodTipoDesconexion;
                    DCodCausa = infAnterior.DCodCausa;
                    NumFallaAgente = infAnterior.NumFallaAgente;
                    ElaboradoPor = infAnterior.ElaboradoPor;
                    if (infAnterior.PkOrigenInforme == 7)
                    {
                        CopiarDocAnalisis(infAnterior);
                    }
                }
            }
            return resultado;
        }

        private ResultadoCopiaInforme Copiar(long tipoInformeOrigen, long tipoInformeDestino)
        {
            ResultadoCopiaInforme resultado = ModeloMgr.Instancia.InformeFallaMgr.CopiarInforme
            (PkCodFalla, PkOrigenInforme, tipoInformeOrigen,
            PkCodFalla, PkOrigenInforme, tipoInformeDestino);

            return resultado;
        }

        private void CopiarDocAnalisis(InformeFalla infAnterior)
        {
            ModeloMgr.Instancia.AnalisisMgr.Copiar(infAnterior.PkCodFalla, infAnterior.PkDCodTipoinforme, infAnterior.PkOrigenInforme);
        }

        public void PonerFechaHora()
        {
            ModeloMgr.Instancia.InformeFallaMgr.PonerFechaHora(this);
        }

        public static DOMINIOS_OPERACION GetTipoOperacionElab(PK_D_COD_TIPOINFORME _tipoInforme)
        {
            DOMINIOS_OPERACION resultado = DOMINIOS_OPERACION.NULL;

            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                switch (_tipoInforme)
                {
                    case PK_D_COD_TIPOINFORME.PRELIMINAR:
                        resultado = DOMINIOS_OPERACION.CNDC_ELABORA_PRELIMINAR;
                        break;
                    case PK_D_COD_TIPOINFORME.FINAL:
                        resultado = DOMINIOS_OPERACION.CNDC_ELABORA_FINAL;
                        break;
                    case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                        resultado = DOMINIOS_OPERACION.CNDC_ELABORA_RECTIFICATORIO;
                        break;
                }
            }
            else
            {
                switch (_tipoInforme)
                {
                    case PK_D_COD_TIPOINFORME.PRELIMINAR:
                        resultado = DOMINIOS_OPERACION.AGENTE_ELABORA_PRELIMINAR;
                        break;
                    case PK_D_COD_TIPOINFORME.FINAL:
                        resultado = DOMINIOS_OPERACION.AGENTE_ELABORA_FINAL;
                        break;
                    case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                        resultado = DOMINIOS_OPERACION.AGENTE_ELABORA_RECTIFICATORIO;
                        break;
                }
            }
            return resultado;
        }

        public DOMINIOS_OPERACION GetTipoOpeParaGuardar()
        {
            DOMINIOS_OPERACION tipo_opn = DOMINIOS_OPERACION.NULL;
            PK_D_COD_TIPOINFORME tipoInforme = (PK_D_COD_TIPOINFORME)PkDCodTipoinforme;
            switch ((D_COD_ESTADO_INF)CodEstadoInf)
            {
                case D_COD_ESTADO_INF.EN_ELABORACION:
                    if (Sesion.Instancia.RolSIN == "CNDC")
                    {
                        switch (tipoInforme)
                        {
                            case PK_D_COD_TIPOINFORME.PRELIMINAR:
                                tipo_opn = DOMINIOS_OPERACION.CNDC_ELABORA_PRELIMINAR;
                                break;
                            case PK_D_COD_TIPOINFORME.FINAL:
                                tipo_opn = DOMINIOS_OPERACION.CNDC_ELABORA_FINAL;
                                break;
                            case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                                tipo_opn = DOMINIOS_OPERACION.CNDC_ELABORA_RECTIFICATORIO;
                                break;
                        }
                    }
                    else
                    {
                        switch (tipoInforme)
                        {
                            case PK_D_COD_TIPOINFORME.PRELIMINAR:
                                tipo_opn = DOMINIOS_OPERACION.AGENTE_ELABORA_PRELIMINAR;
                                break;
                            case PK_D_COD_TIPOINFORME.FINAL:
                                tipo_opn = DOMINIOS_OPERACION.AGENTE_ELABORA_FINAL;
                                break;
                            case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                                break;

                        }
                    }
                    break;
                case D_COD_ESTADO_INF.ELABORADO:
                    if (Sesion.Instancia.RolSIN == "CNDC")
                    {
                        switch (tipoInforme)
                        {
                            case PK_D_COD_TIPOINFORME.PRELIMINAR:
                                tipo_opn = DOMINIOS_OPERACION.CNDC_TERMINA_PRELIMINAR;
                                break;
                            case PK_D_COD_TIPOINFORME.FINAL:
                                tipo_opn = DOMINIOS_OPERACION.CNDC_TERMINA_FINAL;
                                break;
                            case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                                tipo_opn = DOMINIOS_OPERACION.CNDC_TERMINA_RECTIFICATORIO;
                                break;
                        }
                    }

                    break;
                case D_COD_ESTADO_INF.ENVIADO:
                    if (Sesion.Instancia.RolSIN == "CNDC")
                    {
                        switch (tipoInforme)
                        {
                            case PK_D_COD_TIPOINFORME.PRELIMINAR:
                                tipo_opn = DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR;
                                break;
                            case PK_D_COD_TIPOINFORME.FINAL:
                                tipo_opn = DOMINIOS_OPERACION.CNDC_ENVIA_FINAL;
                                break;
                            case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                                tipo_opn = DOMINIOS_OPERACION.CNDC_ENVIA_RECTIFICATORIO;
                                break;
                        }
                    }
                    else
                    {
                        switch (tipoInforme)
                        {
                            case PK_D_COD_TIPOINFORME.PRELIMINAR:
                                tipo_opn = DOMINIOS_OPERACION.AGENTE_ENVIA_PRELIMINAR;
                                break;
                            case PK_D_COD_TIPOINFORME.FINAL:
                                tipo_opn = DOMINIOS_OPERACION.AGENTE_ENVIA_FINAL;
                                break;
                            case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                                break;
                        }
                    }
                    break;
            }
            return tipo_opn;
        }

        public static string Transform_codfalla(int codFalla)
        {
            string ccodfalla = codFalla.ToString ();
            string anno = ccodfalla.Substring(0, 2);
            string num = ccodfalla.Substring(2);

            return string.Format("{0}-{1}", num, anno);
//            cod_falla_varchar := to_char ( cod_falla) ;

//anno := substr (cod_falla_varchar ,1,2 );
//numero  := substr (cod_falla_varchar ,3,4 );

//cod_falla_varchar  := numero || '-'  || anno ;
//  return cod_falla_varchar   ;
 
        }
    }

    public interface IInformeFallaMgr
    {
        void Guardar(InformeFalla obj);
        DataTable GetTabla();
        int DeltaTiempoIngresoComponentesMinutos { get; }
        BindingList<InformeFalla> GetLista();
        DataRow GetDataRowInforme(int codFalla, long origen, long tipo);
        InformeFalla GetInforme(int codFalla, long origen, long tipo);
        DataTable GetInformesPorCodFalla(int codFalla);
        DataTable GetDatos(string nombreTabla, int pkCodFalla, long pkDCodTipoinforme, long pkOrigenInforme);
        void PonerFechaHora(InformeFalla infFalla);
        ResultadoCopiaInforme CopiarInforme(int codFallaA, long origenA, long tipoA, int codFallaB, long origenB, long tipoB);
        ResultadoCopiaInforme CopiarInformeIndividual(int codFallaA, long origenA, long tipoA, int codFallaB, long origenB, long tipoB);
        bool Bloquear(InformeFalla infFalla);
        void DesBloquear(InformeFalla infFalla);
        bool ModificarSupervisorInforme(InformeFalla infFalla, Persona p);
        
        DataRow GetBloqueador(InformeFalla informeFalla);

        bool UpdateElavoradoPor(long pkRegFalla, int tipoInf, long origenInforme, long codPersona, string nomPersona);
    }

    public enum ResultadoCopiaInforme : int
    {
        Error = 0,
        OK = 1,
        NoExisteOrigen = -10,
        YaExisteDestino = -20
    }


}
