using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CNDC.UtilesComunes
{
    public class UtilesExtraFecha
    {
        static DateTime _fechaInicio;
        static DateTime _fechaFinal;
        static DateTime _fechaPublicable;
        public UtilesExtraFecha()
        {

        }
        public static void SetFechaInicio(DateTime fecha)
        {
            _fechaInicio=fecha;
        }
        public static DateTime GetFechaInicio()
        {
            return _fechaInicio;
        }
        public static void SetFechaFinal(DateTime fecha)
        {
            _fechaFinal = fecha;
        }
        public static DateTime GetFechaFinal()
        {
            return _fechaFinal;
        }
        public static void SetFechas(DateTime Inicio,DateTime Final,DateTime fechaPub)
        {
            _fechaInicio = Inicio;
            _fechaFinal = Final;
            _fechaPublicable = fechaPub;
        }
        public static DateTime GetFechaPublicable()
        {
            return _fechaPublicable;
        }
        public static string FormatearDiaFinal(string s)
        {
            return s.Replace("#DIAFINAL#", _fechaFinal.Day.ToString("D2"));
        }
        public static string FormatearMesFinal(string s)
        {
            return s.Replace("#MESFINAL#", _fechaFinal.Month.ToString("D2"));
        }
        public static string FormatearAnioCortoFinal(string s)
        {
            return s.Replace("#ANIOFINAL#", _fechaFinal.Year.ToString().Substring(2, 2));
        }
        public static string FormatearAnioLargoFinal(string s)
        {
            return s.Replace("#ANIOFINAL4D#", _fechaFinal.Year.ToString());
        }
        public static string FormatearAnioLargo(string s)
        {
            return s.Replace("#ANIO4D#",_fechaInicio.Year.ToString());
        }
        public static string FormatearAnioCorto(string s)
        {
            return s.Replace("#ANIO#",_fechaInicio.Year.ToString().Substring(2,2));
        }
        public static string FormatearMes(string s)
        {
            return s.Replace("#MES#", _fechaInicio.Month.ToString("D2"));
        }
        public static string FormatearDia(string s) 
        {
            return s.Replace("#DIA#", _fechaInicio.Day.ToString("D2"));
        }
        public static string FormatearRutaArchivo(string s)
        {
            try
            {
                if (!string.IsNullOrEmpty(s))
                {
                    return FormatearAnioLargoFinal(FormatearAnioCortoFinal(FormatearMesFinal(FormatearDiaFinal(FormatearAnioLargo(FormatearAnioCorto(FormatearMes(FormatearDia(s))))))));
                }
                else
                {
                    return "Formato del archivo vacio, favor verificar configuracion...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Formatear Ruta : "+ ex.Message);
                return string.Empty;
            }
            
        }
        public static string GetArchivoDeCarpeta(string ruta, string archivo)
        {
            try
            {
                string[] files = Directory.GetFiles(FormatearRutaArchivo(ruta),  FormatearRutaArchivo(archivo));
                string resultado = string.Empty;
                for (int i = 0; i < files.Length; i++)
                {
                    resultado = files[i];
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Archivo origen : "+ ex.Message);
                return string.Empty;   
            }
        }
        public static string GetDatosZipPredespacho(string ruta)
        {
            try
            {
                string[] files = Directory.GetFiles(FormatearRutaArchivo(ruta), "*.zip");
                for (int i = 0; i < files.Length; i++)
                {
                    if (Path.GetFileNameWithoutExtension(files[i]).Length == 8)
                        return files[i];
                        //return Path.GetFileNameWithoutExtension(files[i]);
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copiando archivo ZIP: "+ ex.Message);
                return "";            
            }

        }
        public static string ComprimirCarpeta(string ruta)
        {
            try
            {
                string[] files = Directory.GetFiles(ruta, "*.*");
                for (int i = 0; i < files.Length; i++)
                {
                    if (Path.GetFileNameWithoutExtension(files[i]).Length == 8)
                        return Path.GetFileNameWithoutExtension(files[i]);
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copiando archivo ZIP: " + ex.Message);
                return "";
            }

        }
    }
}
