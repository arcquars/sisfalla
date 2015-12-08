using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  System.Data ;
using CNDC.Dominios;

namespace ModeloSisFalla
{
    public class Operacion
    {
        public long idOperacion ;
        public string nombreOperacion;
        public string descripcionOperacion;
        public long estadoAnterior;
        public long estadoSiguiente;
        public string funcionValidacion;
        public long usuarioaValidar;


        public Operacion()
        {
            idOperacion = -1;
            nombreOperacion = string.Empty ;
            descripcionOperacion = string.Empty ;
            estadoAnterior = -1;
            estadoSiguiente = -1;
            funcionValidacion = string.Empty ;
            usuarioaValidar = -1;
        }

        public long GetSecLog()
        {
            long rtn = -1;
            if (ModeloMgr.Instancia.OperacionMgr == null)
            { 
                
            }
            rtn = ModeloMgr.Instancia.OperacionMgr.GetSecLog();


            return rtn;
        }

        public void LoadFromDataRow(DataRow row)
        {           
            if (row["ID_OPERACION"] != DBNull.Value)
            {
                idOperacion = (long)row["ID_OPERACION"];
            }
            if (row["NOMBRE_OPERACION"] != DBNull.Value)
            {
                nombreOperacion = (string)row["NOMBRE_OPERACION"];
            }
            if (row["DESCRIPCION_OPERACION"] != DBNull.Value)
            {
                descripcionOperacion = (string)row["DESCRIPCION_OPERACION"];
            }
            if (row["ESTADOANTERIOR_OPERACION"] != DBNull.Value)
            {
                estadoAnterior = (long)row["ESTADOANTERIOR_OPERACION"];
            }

            if (row["ESTADOSIGUIENTE_OPERACION"] != DBNull.Value)
            {
                estadoSiguiente = (long)row["ESTADOSIGUIENTE_OPERACION"];
            }
            if (row["FUNCIONVALIDACION_OPERACION"] != DBNull.Value)
            {
                funcionValidacion = (string)row["FUNCIONVALIDACION_OPERACION"];
            }
            if (row["USUARIO_A_VALIDAR_OPERACION"] != DBNull.Value)
            {
                usuarioaValidar = (long)row["USUARIO_A_VALIDAR_OPERACION"];
            }
        }
        public bool OperacionValida(DOMINIOS_OPERACION Id_Operacion, long Pk_Cod_Falla, long Pk_Cod_Persona)
        {
            bool rtn = false;
            rtn = ModeloMgr.Instancia.OperacionMgr.OperacionValida(Id_Operacion, Pk_Cod_Falla, Pk_Cod_Persona);
            return rtn;

        }
        public bool RegistrarOperacion(DOMINIOS_OPERACION Id_Operacion, long Pk_Cod_Falla, long Pk_Cod_Persona)
        {
            bool rtn = false;
            long seclog = GetSecLog () ;
            rtn = ModeloMgr.Instancia.OperacionMgr.registrarOperacion(Id_Operacion, Pk_Cod_Falla, Pk_Cod_Persona, seclog);
            
            return rtn;
        }
        public bool RegistrarOperacionPublicacion(DOMINIOS_OPERACION_PUBLICACION Id_Operacion, string detalle, long categoria, DateTime fecha, string motivo)
        {
            bool rtn = false;
            long seclog = GetSecLog();
            rtn = ModeloMgr.Instancia.OperacionMgr.registrarOperacionPublicacion(Id_Operacion, fecha, detalle, categoria, seclog, motivo);

            return rtn;
        }
        public int ExisteRegistro(DOMINIOS_OPERACION Id_Operacion, int Pk_Cod_Falla, int Pk_Cod_Persona)
        {
            int rtn = -1;
            rtn = ModeloMgr.Instancia.OperacionMgr.ExisteRegistro(Id_Operacion, Pk_Cod_Falla, Pk_Cod_Persona);
            return rtn;
        }
    }
    
    public interface iOperacion
    {
        long GetSecLog();
        bool registrarOperacion(DOMINIOS_OPERACION Id_Operacion, long Pk_Cod_Falla, long Pk_Cod_Persona, long Sec_Log);
        bool registrarOperacionPublicacion(DOMINIOS_OPERACION_PUBLICACION Id_Operacion, DateTime fecha, string detalle, long categoria, long Sec_Log, string motivo);
        bool getOperacion(Operacion operacion, long Pk_Cod_Operacion);
        bool OperacionValida(DOMINIOS_OPERACION Id_Operacion, long Pk_Cod_Falla, long Pk_Cod_Persona);
        int ExisteRegistro(DOMINIOS_OPERACION Id_Operacion, long Pk_Cod_Falla, long Pk_Cod_Persona);
    }

}
