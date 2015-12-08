using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;


namespace CNDC.UtilesComunes
{
    public class Utiles
    {
        public static bool EsEntero(string Str)
        {
            bool Resultado = true;
            try
            {
                int.Parse(Str);
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public static bool EsEnteroPositivo(string Str)
        {
            bool Resultado = true;
            try
            {
                long n = long.Parse(Str);
                Resultado = n > 0;
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public static bool EsEnteroPositivoIncluyendoCero(string Str)
        {
            bool Resultado = true;
            try
            {
                long n = long.Parse(Str);
                Resultado = n > -1;
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public static bool EsFloat(string str)
        {
            bool Resultado = true;
            try
            {
                float.Parse(str);
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }
        public static bool EsFloatPositivo(string str)
        {
            bool Resultado = true;
            try
            {
                float numero = float.Parse(str);
                Resultado = numero > 0;
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public static bool EsFloatPositivoYCero(string str)
        {
            bool Resultado = true;
            try
            {
                float numero = float.Parse(str);
                Resultado = numero >= 0;
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }
        public static bool EsDouble(string str)
        {
            bool Resultado = true;
            try
            {
                double.Parse(str);
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public static bool EsDecimalPositivo(string str)
        {
            bool Resultado = true;
            try
            {
                decimal n = decimal.Parse(str);
                Resultado = n > 0;
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public static bool EsDecimalYCero(string str)
        {
            bool Resultado = true;
            try
            {
                decimal n = decimal.Parse(str);
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public static bool EsDecimalPositivoYCero(string str)
        {
            bool Resultado = true;
            try
            {
                decimal n = decimal.Parse(str);
                Resultado = n >= 0;
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public static int AEntero( string Str )
        {
            return  int.Parse( Str );
        }

        public static bool EsHoraValida( string StrHora )
        {
            bool Resultado = true;
            try
            {
                int horas = int.Parse( StrHora.Substring( 0 , 2 ) );
                int minutos = int.Parse( StrHora.Substring( 3 , 2 ) );
                if ( horas < 0 || horas > 23 )
                {
                    Resultado = false;
                }
                else if ( minutos < 0 || minutos > 59 )
                {
                    Resultado = false;
                }
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public static TimeSpan ATimeSpan( string StrHora )
        {
            int IdxPuntos = StrHora.IndexOf( ":" );
            int horas = int.Parse( StrHora.Substring( 0 , IdxPuntos ) );
            int minutos = int.Parse( StrHora.Substring( IdxPuntos + 1 ) );
            return new TimeSpan( horas , minutos , 0 );
        }
        public static TimeSpan GetTimeSpan( DateTime dateTime )
        {
            return new TimeSpan( dateTime.Hour , dateTime.Minute , 0 );
        }

        public static string GetHoraString( DateTime dateTime )
        {
            return ( dateTime.Hour > 9 ? dateTime.Hour.ToString( ) : "0" + dateTime.Hour.ToString( ) ) + ":" + ( dateTime.Minute > 9 ? dateTime.Minute.ToString( ) : "0" + dateTime.Minute.ToString( ) );       
        }

        public static string GetHoraString( TimeSpan dateTime )
        {
            return ( dateTime.Hours > 9 ? dateTime.Hours.ToString( ) : "0" + dateTime.Hours.ToString( ) ) + ":" + ( dateTime.Minutes > 9 ? dateTime.Minutes.ToString( ) : "0" + dateTime.Minutes.ToString( ) );
        }

        public static TimeSpan DoubleToTimeSpan( double doubleHora )
        {
            int horas = ( int )doubleHora;
            doubleHora -= horas;
            int minutos=(int)(doubleHora*60);
            return new TimeSpan( horas , minutos , 0 );
        }

        public static double TimeSpanToDouble( TimeSpan timeSpan )
        {
            return timeSpan.Hours + timeSpan.Minutes / 60.0;
        }

        public static double RedondearHora( double hora , TipoRedondeo Redondeo )
        {
            TimeSpan timeSpan = Utiles.DoubleToTimeSpan( hora );
            int Residuo = timeSpan.Minutes % 5;
            if ( Residuo != 0 )
            {
                switch ( Redondeo )
                {
                    case TipoRedondeo.RedondeoAlMenor:
                        timeSpan = timeSpan.Subtract( new TimeSpan( 0 , Residuo , 0 ) );
                        break;
                    case TipoRedondeo.RedondeoAlMayor:
                        timeSpan = timeSpan.Add( new TimeSpan( 0 , 5 - Residuo , 0 ) );
                        break;
                    case TipoRedondeo.RedondeoAlCercano:
                        if ( Residuo < 3 )
                        {
                            timeSpan = timeSpan.Subtract( new TimeSpan( 0 , Residuo , 0 ) );
                        }
                        else
                        {
                            timeSpan = timeSpan.Add( new TimeSpan( 0 , 5 - timeSpan.Minutes % 5 , 0 ) );
                            
                        }
                        break;
                }
            }
            return Utiles.TimeSpanToDouble( timeSpan );
        }
        public static bool ValidarFecha(string Fecha)
        {
            return Regex.IsMatch( Fecha , @"((\d{1,2}\/\d{1,2}\/)(\d{4}|\d{2}))");
        }        
        
         //public static string Mid(string param,int startIndex, int length)           
         //      {                           
         //         string result = param.Substring(startIndex, length);                     
         //         return result; 
         //      } 

        public static DateTime StrToDateTime( string p )
        {
            return DateTime.Parse(p);
        }

        public static string DateTimeToString(DateTime dateTime , FormatoFecha formatoFecha , SeparadorFecha separador)
        {
            string Resultado = string.Empty;

            switch ( formatoFecha )
            {
                case FormatoFecha.DDMMAAAA:
                    Resultado = "{0}/{1}/{2}";
                    break;
                case FormatoFecha.MMDDAAAA:
                    Resultado = "{1}/{0}/{2}";
                    break;
                case FormatoFecha.AAAAMMDD:
                    Resultado = "{2}/{1}/{0}";
                    break;
            }
            Resultado = string.Format( Resultado , A2Digitos(dateTime.Day) ,A2Digitos(dateTime.Month) , dateTime.Year );
            if ( separador== SeparadorFecha.Guion )
            {
                Resultado = Resultado.Replace( '/' , '-' );
            }
            return Resultado;
        }
        public static string A2Digitos( int valor )
        {
            string Resultado = valor.ToString( );
            if ( valor < 10 )
            {
                Resultado = "0" + Resultado;
            }
            return Resultado;
        }

        public static string DoubleToString( double Num )
        {
            string StrNum = Num.ToString( );
            return StrNum.Replace( ',' , '.' );
        }

        public static bool EsCadenaVacia(string p)
        {
            return string.IsNullOrEmpty(p);
        }
    }

    public enum TipoRedondeo
    {
        SinRedondeo ,
        RedondeoAlCercano ,
        RedondeoAlMenor ,
        RedondeoAlMayor
    }
    public enum FormatoFecha
    {
        DDMMAAAA,
        MMDDAAAA,
        AAAAMMDD
    }
    public enum SeparadorFecha
    { 
        Guion,
        Division
    }
}
