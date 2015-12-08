using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;

namespace CNDC.Pistas
{
    public class RegistradorArchLocal : IRegistradorPista
    {
        #region Singleton
        private static RegistradorArchLocal _instancia;
        public static RegistradorArchLocal Instancia
        {
            get { return _instancia; }
        }

        static RegistradorArchLocal()
        {
            _instancia = new RegistradorArchLocal();
        }
        #endregion Singleton

        StreamWriter _writer;
        private RegistradorArchLocal()
        {
            IniciarStream();
        }

        private void IniciarStream()
        {
            if (_writer != null)
            {
                _writer.Close();
                _writer = null;
            }

            bool bandera = true;
            while (bandera)
            {
                try
                {
                    _writer = new StreamWriter(GetNombreArchivo(), true);
                    bandera = false;
                }
                catch (Exception e)
                {
                    _contador++;
                }
            }
        }

        public bool Registrar(Pista e)
        {
            bool resultado = true;
            _writer.WriteLine(e.ToString());
            _writer.Flush();
            return resultado;
        }

        int _contador = 0;


        public string _carpetaLog = string.Empty;
        public string GetCarpetaLog
        {
            get
            {
                return _carpetaLog;
            }

        }


        private string getCarpetaLog()
        {
            string directorioLog = ConfigurationManager.AppSettings["DirLog"];
            _carpetaLog = directorioLog;
            if (string.IsNullOrEmpty(directorioLog))
            {
                directorioLog = "c:\\WCFSISFALLA";
                _carpetaLog = "c:\\WCFSISFALLA";
            }
            return directorioLog;


        }



        private string GetNombreArchivo()
        {
            //string personal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //string personal = "c:\\WCFSISFALLA";

            string directorioLog = getCarpetaLog();

            string directorioPistas = Path.Combine(directorioLog, "Logs");
            
            if (!Directory.Exists(directorioPistas))
            {
                Directory.CreateDirectory(directorioPistas);
            }
            if (string.IsNullOrEmpty(NombreArchivo))
            {
                return string.Format("{0}\\Log{1}{2}.log", directorioPistas, DateTime.Now.ToString("yyyyMMMdd"), GetContador());
            }
            else
            {
                return string.Format("{0}\\{1}{2}{3}.log", directorioPistas, NombreArchivo, DateTime.Now.ToString("yyyyMMMdd"), GetContador());
            }
        }

        private string GetContador()
        {
            if (_contador == 0)
            {
                return string.Empty;
            }
            else
            {
                return "-" + _contador;
            }
        }

        private string _NombreArchivo = null;
        public string NombreArchivo
        {
            get { return _NombreArchivo; }
            set
            {
                _NombreArchivo = value;
                IniciarStream();
            }
        }
    }
}
