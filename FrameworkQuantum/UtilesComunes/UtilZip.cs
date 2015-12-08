using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Windows.Forms;

namespace CNDC.UtilesComunes
{
    public class UtilZip
    {

        public static void ComprimirArchivoFuente(string archivo)
        {
            if (File.Exists(archivo))
                UtilZip.CreaArchivoZip(archivo ,Path.Combine(Path.GetDirectoryName(archivo), Path.GetFileNameWithoutExtension(archivo) + ".zip"));
        }
        public static void CreaArchivoZip(string file, string zip_name)
        {

            if (!File.Exists(zip_name))
                File.Delete(zip_name);
                //string[] filenames = Directory.GetFiles(directorio);
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zip_name)))
                {
                    s.SetLevel(9); // 0 - store only to 9 - means best compression
                    byte[] buffer = new byte[2048];

                    ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);
                    using (FileStream fs = File.OpenRead(file))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }

                    s.Finish();
                    s.Close();
                }
            
        }
        public static string GetTemporarDirectorio(string categoria)
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), categoria + Path.GetRandomFileName());
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }
            return tempDirectory;
        }

        public static void copiarArchivoParaComprimir(string directorio, string zip_name)
        {
            if (Directory.Exists(directorio))
            {
                File.Copy(zip_name, Path.Combine(directorio, Path.GetFileName(zip_name)), true);
            }
        }

        public static void ComprimirArchivosGenerados(string origen, string categoria)
        {
        if (Directory.Exists(origen))
	    {
		 string dirtmp = GetTemporarDirectorio(categoria);
            string[] filenames = Directory.GetFiles(origen);
            foreach (string file in filenames)
            {
                copiarArchivoParaComprimir(dirtmp,file);
            }
            CreaZipDirectorio(dirtmp,dirtmp);
		 
        }
        }
        
        public static void CreaZipDirectorio(string directorio, string zip_name)
        {
            string[] filenames = Directory.GetFiles(directorio);
            using (ZipOutputStream s = new ZipOutputStream(File.Create(zip_name + ".zip")))
            {
                s.SetLevel(9); // 0 - store only to 9 - means best compression
                byte[] buffer = new byte[2048];
                foreach (string file in filenames)
                {
                    ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);
                    using (FileStream fs = File.OpenRead(file))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }
                s.Finish();
                s.Close();
            }
        }
        public static void BorrarDirectorio(string directorio,string categoria)
        {
            if (Directory.Exists(@directorio))
            {
                try
                {
                    ComprimirArchivosGenerados(directorio,categoria);
                    Directory.Delete(@directorio, true);
                }

                catch (IOException e)
                {
                    MessageBox.Show("Borrar Directorio : " + e.Message);
                }
            }

        }
        public static void BorrarArchivosDirectorio(string directorio)
        {
            if (Directory.Exists(@directorio))
            {
                try
                {
                    string[] files = Directory.GetFiles(directorio, "*.xls");
                    for (int i = 0; i < files.Length; i++)
                    {
                        File.Delete(files[i]);
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show("Borrar Archivos .xls : " + e.Message);
                }
            }

        }
    }
}
