using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CNDC.Pistas;

namespace SISFALLA
{
    class ActualizadorDelActualizador
    {
        public static void Actualizar()
        {
            string pathSisFalla = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string archivosDePrograma = GetFolderArchivosDePrograma();
            string dirAppInstalacion = Path.Combine(Path.Combine(archivosDePrograma, "CNDC"), "ActualizadorSisFallaV2");
            string exeActualizadorIns = Path.Combine(dirAppInstalacion, "ActualizadorSisFallaV2.exe");
            string exeActualizadorDoc = Path.Combine(pathSisFalla, "ActualizadorSisFallaV2.exe");

            if (File.Exists(exeActualizadorDoc))
            {
                try
                {
                    File.Copy(exeActualizadorDoc, exeActualizadorIns, true);
                    File.Delete(exeActualizadorDoc);
                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.Error("ActualizActualizadr", ex);
                }
            }
        }

        private static string GetFolderArchivosDePrograma()
        {
            return Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") ?? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        }
    }
}
