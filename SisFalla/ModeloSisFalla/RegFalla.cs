using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Data;
using CNDC.BLL;
using CNDC.Dominios;
using System.ComponentModel;

namespace ModeloSisFalla
{
	[Serializable]
	public class RegFalla : ObjetoDeNegocio, IRegFalla
	{
		public const string NOMBRE_TABLA = "F_GF_REGFALLA";

		public const string C_PK_COD_FALLA = "PK_COD_FALLA";
		public const string C_GESTION = "GESTION";
		public const string C_FEC_INICIO = "FEC_INICIO";
		public const string C_PK_COD_COMPONENTE = "PK_COD_COMPONENTE";
		public const string C_D_COD_CAUSA = "D_COD_CAUSA";
		public const string C_DESCRIPCION = "DESCRIPCION_CORTA_FALLA";
		public const string C_D_COD_ESTADO = "D_COD_ESTADO";
		public const string C_SEC_LOG = "SEC_LOG";
		public const string C_D_COD_ORIGEN = "D_COD_ORIGEN";
		public const string C_D_COD_TIPO_DESCONEXION = "D_COD_TIPO_DESCONEXION";
		public const string C_DESCRIPCION_FALLA = "DESCRIPCION_FALLA";
		public const string C_FK_COD_SUPERVISOR = "FK_COD_SUPERVISOR";
		public const string C_FK_COD_OPERADOR = "FK_COD_OPERADOR";
		public const string C_SINC_VER = "SINC_VER";
		public const string C_D_COD_PROBLEMA_GEN = "D_COD_PROBLEMA_GEN";
		public const string C_D_COD_COLAPSO = "D_COD_COLAPSO";

		public RegFalla()
		{

		}
		public RegFalla(DataRow dataRow)
		{
			CodFalla = int.Parse(dataRow[C_PK_COD_FALLA].ToString());
			Gestion = GetValor<short>(dataRow[C_GESTION]);
			FecInicio = GetValor<DateTime>(dataRow[C_FEC_INICIO]);
			CodComponente = (decimal)dataRow[C_PK_COD_COMPONENTE];
			CodCausa = GetValor<long>(dataRow[C_D_COD_CAUSA]);
			Descripcion = GetValor<string>(dataRow[C_DESCRIPCION], string.Empty);
			CodEstado = dataRow[C_D_COD_ESTADO].ToString();
			SecLog = GetValor<decimal>(dataRow[C_SEC_LOG]);
			CodOrigen = GetValor<long>(dataRow[C_D_COD_ORIGEN]);
			CodTipoDesconexion = GetValor<long>(dataRow[C_D_COD_TIPO_DESCONEXION]);
			Fk_cod_operador = GetValor<long>(dataRow[C_FK_COD_OPERADOR]);
			Fk_cod_supervisor = GetValor<long>(dataRow[C_FK_COD_SUPERVISOR]);
			DescripcionFalla = GetValor<string>(dataRow[C_DESCRIPCION_FALLA], string.Empty);
			SincVer = GetValor<long>(dataRow[C_SINC_VER]);
			CodProblemasGen = GetValor<long>(dataRow[C_D_COD_PROBLEMA_GEN]);
			CodColapso = GetValor<long>(dataRow[C_D_COD_COLAPSO]);
		}


		public void llenarRegFalla(DataRow dataRow,int a)
		{
			CodFalla = Parse<int>(dataRow[C_PK_COD_FALLA].ToString());
			Gestion = Parse<short>(dataRow[C_GESTION].ToString());
			FecInicio =  GetDateTime(dataRow[C_FEC_INICIO].ToString());
			CodComponente = Parse<decimal>(dataRow[C_PK_COD_COMPONENTE].ToString());
			CodCausa = Parse<long>(dataRow[C_D_COD_CAUSA].ToString());
			Descripcion = dataRow[C_DESCRIPCION].ToString();
			CodEstado = dataRow[C_D_COD_ESTADO].ToString();
			SecLog = Parse<decimal>(dataRow[C_SEC_LOG].ToString());
			CodOrigen = Parse<long>(dataRow[C_D_COD_ORIGEN].ToString());
			CodTipoDesconexion = Parse<long>(dataRow[C_D_COD_TIPO_DESCONEXION].ToString());
			Fk_cod_operador = Parse<long>(dataRow[C_FK_COD_OPERADOR].ToString());
			Fk_cod_supervisor = Parse<long>(dataRow[C_FK_COD_SUPERVISOR].ToString());
			DescripcionFalla = dataRow[C_DESCRIPCION_FALLA].ToString();
			SincVer = Parse<long>(dataRow[C_SINC_VER].ToString());
			CodProblemasGen = Parse<long>(dataRow[C_D_COD_PROBLEMA_GEN].ToString());
			CodColapso = Parse<long>(dataRow[C_D_COD_COLAPSO].ToString());
		}

		 

		public int CodFalla { get; set; }
		public short Gestion { get; set; }
		public DateTime FecInicio { get; set; }
		public decimal CodComponente { get; set; }
		public long CodCausa { get; set; }
		public string Descripcion { get; set; }
		public string CodEstado { get; set; }
		public decimal SecLog { get; set; }
		public long CodOrigen { get; set; }
		public long CodTipoDesconexion { get; set; }
		public long Fk_cod_operador { get; set; }
		public long SincVer { get; set; }
		public long Fk_cod_supervisor { get; set; }
		public string DescripcionFalla { get; set; }
		public long CodProblemasGen { get; set; }
		public long CodColapso { get; set; }

		public DateTime FecRegistro { get; set; }

		public int DeltaTiempoIngresoComponentes { get; set; }

		public static string FormatearCodFalla(string valor)
		{
			if (!valor.Contains("-") && valor.Length >= 4)
			{
				string gestion = valor.Substring(0, valor.Length - 4);
				if (gestion.Length == 1)
				{
					gestion = "0" + gestion;
				}
				valor = valor.Substring(valor.Length - 4) + "-" + gestion;
			}
			return valor;
		}

		public BindingList<Persona> GetAgentesNotificados()
		{
			return ModeloMgr.Instancia.RegFallaMgr.GetAgentesNotificados(this.CodFalla);
		}

		public BindingList<Persona> GetAgentesSinNotificar()
		{
			return ModeloMgr.Instancia.RegFallaMgr.GetAgentesSinNotificar(this.CodFalla);
		}

		public BindingList<Persona> GetAgentesInvolcrados()
		{
			BindingList<Persona> resultado = new BindingList<Persona>();
			DataTable tabla = ModeloMgr.Instancia.RegFallaMgr.GetAgentesInvolucrados(this.CodFalla);
			foreach (DataRow r in tabla.Rows)
			{
				resultado.Add(new Persona(r));
			}
			return resultado;
		}

		public List<string> GetDestinatarios(BindingList<Persona> agentesNotificar, string otrosDestinatarios)
		{
			List<string> resultado = ModeloMgr.Instancia.RContactoMgr.GetEmailsDeContactos(agentesNotificar);
			string[] arrayOtrosDestinatarios = otrosDestinatarios.Split(';');
			string strEmail = string.Empty;
			foreach (string otroDest in arrayOtrosDestinatarios)
			{
				strEmail = otroDest.Trim();
				if (!string.IsNullOrEmpty(strEmail))
				{
					resultado.Add(strEmail);
				}
			}

			return resultado;
		}
	}

	public interface IRegFalla
	{
		long CodCausa { get; set; }
		long CodColapso { get; set; }
		decimal CodComponente { get; set; }
		int CodFalla { get; set; }
		long CodOrigen { get; set; }
		long CodProblemasGen { get; set; }
		long CodTipoDesconexion { get; set; }
		string Descripcion { get; set; }
		string DescripcionFalla { get; set; }
		DateTime FecInicio { get; set; }
		long Fk_cod_operador { get; set; }
	}

	public interface IRegFallaMgr
	{
		void Guardar(RegFalla r);
		RegFalla GetFalla(int numFalla);
		DataTable GetTabla();
        DataTable GetRegistrosXGestion(int gestion);
        DataTable GetGestiones();
		DataTable GetRegistros(string codigo);
		DataTable GetAgentesInvolucrados();
        void  IncrementarSincVer(int pkCodFalla);
		bool Existe(DataRow row, DataTable tablaLocal);
        bool ExisteNumeroFalla(int codigo);
		int GetSiguienteNumFalla();
		void GuardarCodColapso(int numFalla, D_COD_COLAPSO codColapso);
		bool Borrar(int numFalla, string motivo);
		DataTable GetTablaFallas(D_COD_ESTADO_INF? _filtroEstadoInforme);
        //GetTablaFallas(D_COD_ESTADO_INF? _filtroEstadoInforme);
        DataTable GetTablaFallas(long  pk_cod_pesona, D_COD_ESTADO_INF? filtroEstadoInforme);
		DataTable GetTablaFallasSinInformes();
    
		BindingList<Persona> GetAgentesNotificados(int p);
		BindingList<Persona> GetAgentesSinNotificar(int p);

		DataTable GetAgentesInvolucrados(int p);

		bool EstaInvolucrado(int pkCodFalla, long pkCodPersona);
	}
}