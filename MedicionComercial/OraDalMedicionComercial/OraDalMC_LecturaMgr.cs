using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.BLL;
using ExpresionesLib;

namespace MC
{
    public class OraDalMC_LecturaMgr : OraDalBaseMgr, IMC_LecturaMgr
    {
        public bool Guardar(MC_Lectura obj)
        {
            bool resultado = true;
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkCodLectura = GetIdAutoNum("SEC_PK_COD_LECTURA");
                sql = "INSERT INTO F_MC_LECTURA (PK_COD_LECTURA,FK_COD_PUNTO_MEDICION,COD_RPTO_MED_FTO,FECHA_LECTURA,NOMBRE_ARCHIVO,SEC_LOG)" +
                "VALUES(:PK_COD_LECTURA,:FK_COD_PUNTO_MEDICION,:COD_RPTO_MED_FTO,:FECHA_LECTURA,:NOMBRE_ARCHIVO,:SEC_LOG)";
            }
            else
            {
                sql = "UPDATE F_MC_LECTURA SET " +
                "PK_COD_LECTURA=:PK_COD_LECTURA ," +
                "FK_COD_PUNTO_MEDICION=:FK_COD_PUNTO_MEDICION ," +
                "COD_RPTO_MED_FTO=:COD_RPTO_MED_FTO ," +
                "FECHA_LECTURA=:FECHA_LECTURA ," +
                "NOMBRE_ARCHIVO=:NOMBRE_ARCHIVO ," +
                "SEC_LOG=:SEC_LOG  WHERE ";
            }

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_Lectura.C_PK_COD_LECTURA, OracleDbType.Int64, obj.PkCodLectura, ParameterDirection.Input);
            cmd.Parameters.Add(MC_Lectura.C_FK_COD_PUNTO_MEDICION, OracleDbType.Int64, obj.FkCodPtoMed, ParameterDirection.Input);
            cmd.Parameters.Add(MC_Lectura.C_COD_RPTO_MED_FTO, OracleDbType.Int64, obj.CodRPtoMedFto, ParameterDirection.Input);
            cmd.Parameters.Add(MC_Lectura.C_FECHA_LECTURA, OracleDbType.Date, obj.FechaLectura, ParameterDirection.Input);
            cmd.Parameters.Add(MC_Lectura.C_NOMBRE_ARCHIVO, OracleDbType.Varchar2, obj.NombreArchivo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_Lectura.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, ParameterDirection.Input);

            try
            {
                cmd.ExecuteNonQuery();
                obj.EsNuevo = false;
            }
            catch (Exception exception)
            {
                PistaMgr.Instance.Error("DALSisFalla", exception);
                resultado = false;
            }
            finally
            {
                DisposeCommand(cmd);
            }
            return resultado;
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(MC_Lectura.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MC_Lectura> GetLista()
        {
            BindingList<MC_Lectura> resultado = new BindingList<MC_Lectura>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_Lectura(row));
            }
            return resultado;
        }

        public static Array GetArray(DataTable tabla, string campo)
        {
            object[] resultado = new object[tabla.Rows.Count];
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (tabla.Rows[i].Table.Columns.Contains(campo))
                {
                    resultado[i] = tabla.Rows[i][campo];
                }
                else
                {
                    resultado[i] = null;
                }
            }
            return resultado;
        }

        public static Array GetArray(int cantidad, object valor)
        {
            object[] resultado = new object[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                resultado[i] = valor;
            }
            return resultado;
        }

        public List<RegistroLectura> GetRegistrosDesdeFecha(long codPuntoMedicion, DateTime fecha)
        {
            List<RegistroLectura> resultado = new List<RegistroLectura>();
            Dictionary<DateTime, Dictionary<long, RegistroLectura>> _dicRegistros = new Dictionary<DateTime, Dictionary<long, RegistroLectura>>();
            string sql =
            @"SELECT d.*, i.HORA_INTERVALO
            FROM f_mc_lectura_detalle d, P_MC_INTERVALO_DETALLE i
            WHERE d.pk_fecha>=:fecha
            AND d.fk_cod_punto_medicion     =:cod_punto_medicion
            AND d.pk_cod_intervalo=i.PK_COD_INTERVALO
            ORDER BY d.pk_fecha, d.pk_cod_intervalo";
            OracleCommand cmd = base.CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("fecha", OracleDbType.Date, fecha, ParameterDirection.Input);
            cmd.Parameters.Add("cod_punto_medicion", OracleDbType.Int64, codPuntoMedicion, ParameterDirection.Input);
            DataTable tabla = base.EjecutarCmd(cmd);
            foreach (DataRow r in tabla.Rows)
            {
                DateTime fechaLectura = (DateTime)r["PK_FECHA"];
                long codIntervalo = (long)r["PK_COD_INTERVALO"];
                fechaLectura = fechaLectura.Date;
                if (!_dicRegistros.ContainsKey(fechaLectura))
                {
                    _dicRegistros[fechaLectura] = new Dictionary<long, RegistroLectura>();
                }
                if (!_dicRegistros[fechaLectura].ContainsKey(codIntervalo))
                {
                    _dicRegistros[fechaLectura][codIntervalo] = new RegistroLectura();
                    _dicRegistros[fechaLectura][codIntervalo].Fecha = (DateTime)r["PK_FECHA"];
                    _dicRegistros[fechaLectura][codIntervalo].Hora = (string)r["HORA_INTERVALO"];
                }
                _dicRegistros[fechaLectura][codIntervalo].AdicionarItem((long)r["PK_COD_MAGNITUD_ELEC"], new double?((double)r["VALOR"]));
            }
            foreach (Dictionary<long, RegistroLectura> item in _dicRegistros.Values)
            {
                foreach (RegistroLectura registro in item.Values)
                {
                    resultado.Add(registro);
                }
            }
            return resultado;
        }

        public RegistroLectura GetUltimoRegistroBD(long codPuntoMedicion)
        {
            RegistroLectura resultado = null;
            string sql =
            @"SELECT * FROM(SELECT d.*, i.hora_intervalo
            FROM f_mc_lectura_detalle d, p_mc_intervalo_detalle i
            WHERE d.pk_cod_lectura IN (SELECT l.pk_cod_lectura FROM f_mc_lectura l WHERE fk_cod_punto_medicion=:cod_punto_medicion)
            AND d.pk_cod_intervalo=i.pk_cod_intervalo            
            ORDER BY d.pk_fecha DESC)
            WHERE rownum<2";
            OracleCommand cmd = base.CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("cod_punto_medicion", OracleDbType.Int64, codPuntoMedicion, ParameterDirection.Input);
            DataTable tabla = base.EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new RegistroLectura
                {
                    Fecha = (DateTime)tabla.Rows[0]["PK_FECHA"],
                    Hora = (string)tabla.Rows[0]["HORA_INTERVALO"]
                };
            }
            return resultado;
        }

        public void Guardar(ResumenLecturaMedidor resumen, ResultadoLectura res, ParametrosLectura parametros)
        {
            MC_Lectura lectura = new MC_Lectura
            {
                EsNuevo = true,
                CodRPtoMedFto = resumen.PkCodFormato,
                NombreArchivo = resumen.ArchivoLectura,
                FkCodPtoMed = resumen.PkCodPuntoMedicion,
                FechaLectura = DateTime.Now
            };

            if (this.Guardar(lectura))
            {
                string sql = @"INSERT INTO F_MC_LECTURA_DETALLE
                (PK_FECHA, PK_COD_INTERVALO, VALOR, ESTADO, SEC_LOG, D_COD_ORIGEN,
                PK_COD_MAGNITUD_ELEC, PK_COD_LECTURA,fk_cod_punto_medicion)
                VALUES(:PK_FECHA, :PK_COD_INTERVALO, :VALOR, :ESTADO, :SEC_LOG, :D_COD_ORIGEN,
                :PK_COD_MAGNITUD_ELEC, :PK_COD_LECTURA,:fk_cod_punto_medicion)";
                OracleCommand cmd = base.CrearCommand();
                cmd.CommandText = sql;
                cmd.ArrayBindCount = res.Tabla.Rows.Count;
                cmd.Parameters.Add("PK_FECHA", OracleDbType.Date, GetArray(res.Tabla, "Fecha"), ParameterDirection.Input);
                cmd.Parameters.Add("PK_COD_INTERVALO", OracleDbType.Int64, GetArray(res.Tabla, "CodIntervalo"), ParameterDirection.Input);
                cmd.Parameters.Add("VALOR", OracleDbType.Decimal, GetArray(res.Tabla, "Valor"), ParameterDirection.Input);
                cmd.Parameters.Add("ESTADO", OracleDbType.Int64, GetArray(res.Tabla.Rows.Count, 1), ParameterDirection.Input);
                cmd.Parameters.Add("SEC_LOG", OracleDbType.Int64, GetArray(res.Tabla.Rows.Count, lectura.SecLog), ParameterDirection.Input);
                cmd.Parameters.Add("D_COD_ORIGEN", OracleDbType.Int64, GetArray(res.Tabla.Rows.Count, 1), ParameterDirection.Input);
                cmd.Parameters.Add("PK_COD_MAGNITUD_ELEC", OracleDbType.Int64, GetArray(res.Tabla, "CodInfCanal"), ParameterDirection.Input);
                cmd.Parameters.Add("PK_COD_LECTURA", OracleDbType.Int64, GetArray(res.Tabla.Rows.Count, lectura.PkCodLectura), ParameterDirection.Input);
                cmd.Parameters.Add("fk_cod_punto_medicion", OracleDbType.Int64, GetArray(res.Tabla.Rows.Count, resumen.PkCodPuntoMedicion), ParameterDirection.Input);
                cmd.BindByName = true;
                base.Actualizar(cmd);
            }
        }


        public string CalcularDatosLectura(long codPuntoMedicion, DateTime desde, DateTime hasta)
        {
            string resultado = "OK";
            List<MC_FormulaPuntoMedicion> formulas = MC_FormulaPuntoMedicionMgr.Instancia.GetFormulasPorCodPuntoMed(codPuntoMedicion, desde, hasta);
            if (formulas.Count == 0)
            {
                resultado = "Fórmula no definida.";
            }
            else
            {
                List<MC_IntervaloDetalle> intervalos = MC_IntervaloDetalleMgr.Instancia.GetLista(desde, hasta);
                List<EvaluadorExpresion> evaluadores = new List<EvaluadorExpresion>();
                MC_Lectura lectura = new MC_Lectura();
                lectura.EsNuevo = true;
                lectura.FechaLectura = DateTime.Now.Date;
                lectura.FkCodPtoMed = codPuntoMedicion;
                MC_LecturaMgr.Instancia.Guardar(lectura);
                foreach (MC_FormulaPuntoMedicion f in formulas)
                {
                    evaluadores.Add(new EvaluadorExpresion(f.Formula));
                }

                ProveedorDatosLectura proveedorDatos = new ProveedorDatosLectura(desde, hasta);
                Dictionary<string, List<object>> detalle = new Dictionary<string, List<object>>();
                detalle["FkCodPuntoMedicion"] = new List<object>();
                detalle["PkCodIntervalo"] = new List<object>();
                detalle["PkCodMagnitudElec"] = new List<object>();
                detalle["Valor"] = new List<object>();
                detalle["PkCodLectura"] = new List<object>();
                detalle["PkFecha"] = new List<object>();
                detalle["Estado"] = new List<object>();
                detalle["SecLog"] = new List<object>();
                detalle["DCodOrigen"] = new List<object>();
                
                for (DateTime fecha = desde; fecha <= hasta; fecha = fecha.AddDays(1))
                {
                    proveedorDatos.SetFecha(fecha);
                    foreach (var i in intervalos)
                    {
                        proveedorDatos.SetIntervalo(i.PkCodIntervalo);
                        for (int idx = 0; idx < formulas.Count; idx++)
                        {
                            double r = evaluadores[idx].Evaluar(proveedorDatos);

                            detalle["FkCodPuntoMedicion"].Add(codPuntoMedicion);
                            detalle["PkCodIntervalo"].Add(i.PkCodIntervalo);
                            detalle["PkCodMagnitudElec"].Add(formulas[idx].FkCodMagnitudElec);
                            detalle["Valor"].Add(r);
                            detalle["PkCodLectura"].Add(lectura.PkCodLectura);
                            detalle["PkFecha"].Add(fecha);
                            detalle["Estado"].Add(1);
                            detalle["SecLog"].Add(lectura.SecLog);
                            detalle["DCodOrigen"].Add(2);
                        }
                    }
                }

                string sql = @"INSERT INTO F_MC_LECTURA_DETALLE
                (PK_FECHA, PK_COD_INTERVALO, VALOR, ESTADO, SEC_LOG, D_COD_ORIGEN,
                PK_COD_MAGNITUD_ELEC, PK_COD_LECTURA,fk_cod_punto_medicion)
                VALUES(:PK_FECHA, :PK_COD_INTERVALO, :VALOR, :ESTADO, :SEC_LOG, :D_COD_ORIGEN,
                :PK_COD_MAGNITUD_ELEC, :PK_COD_LECTURA,:fk_cod_punto_medicion)";
                OracleCommand cmd = base.CrearCommand();
                cmd.CommandText = sql;
                cmd.ArrayBindCount = detalle["SecLog"].Count;
                cmd.Parameters.Add("PK_FECHA", OracleDbType.Date, detalle["PkFecha"].ToArray(), ParameterDirection.Input);
                cmd.Parameters.Add("PK_COD_INTERVALO", OracleDbType.Int64, detalle["PkCodIntervalo"].ToArray(), ParameterDirection.Input);
                cmd.Parameters.Add("VALOR", OracleDbType.Decimal, detalle["Valor"].ToArray(), ParameterDirection.Input);
                cmd.Parameters.Add("ESTADO", OracleDbType.Int64, detalle["Estado"].ToArray(), ParameterDirection.Input);
                cmd.Parameters.Add("SEC_LOG", OracleDbType.Int64, detalle["SecLog"].ToArray(), ParameterDirection.Input);
                cmd.Parameters.Add("D_COD_ORIGEN", OracleDbType.Int64, detalle["DCodOrigen"].ToArray(), ParameterDirection.Input);
                cmd.Parameters.Add("PK_COD_MAGNITUD_ELEC", OracleDbType.Int64, detalle["PkCodMagnitudElec"].ToArray(), ParameterDirection.Input);
                cmd.Parameters.Add("PK_COD_LECTURA", OracleDbType.Int64, detalle["PkCodLectura"].ToArray(), ParameterDirection.Input);
                cmd.Parameters.Add("fk_cod_punto_medicion", OracleDbType.Int64, detalle["FkCodPuntoMedicion"].ToArray(), ParameterDirection.Input);
                cmd.BindByName = true;
                base.Actualizar(cmd);

            }
            return resultado;
        }
    }
}