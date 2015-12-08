using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;

namespace Exportador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cndcButton1_Click(object sender, EventArgs e)
        {
            
             openFileDialog1.InitialDirectory = "c:\\" ;
             openFileDialog1.Filter = "txt files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 1 ;
            openFileDialog1.RestoreDirectory = true ;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
           Codificar (openFileDialog1.FileName );
            }
        }
   
        private void Codificar(string FileName)
        {
            string archivo = FileName;
            FileStream fs = new FileStream(archivo, FileMode.Open);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, b.Length);
            fs.Close();

            b = CodificarArchivo.codificar(b);
            b = GZip.Comprimir(b);

            FileStream fs1 = new FileStream(archivo + ".gz", FileMode.Create);
            fs1.Write(b, 0, b.Length);
            fs1.Close();
            if (File.Exists(archivo))
            {
                File.Delete(archivo);
            }
        }
 
    }

    public class CodificarArchivo
    {
        public static byte[] codificar(byte[] plainFile)
        {
            string sKey = "quantume";
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform encryptor = DES.CreateEncryptor();
            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            csEncrypt.Write(plainFile, 0, plainFile.Length);
            csEncrypt.FlushFinalBlock();
            return msEncrypt.ToArray();
        }

        public static byte[] decodificar(byte[] encryptedFile)
        {
            string sKey = "quantume";
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform decryptor = DES.CreateDecryptor();
            MemoryStream msDecrypt = new MemoryStream(encryptedFile);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            byte[] fromEncrypt = new byte[encryptedFile.Length];
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
            return fromEncrypt;
        }

        static void EncryptFile(string sInputFilename, string sOutputFilename)
        {
            string sKey = "12345678";
            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            fsInput.Close();
            fsEncrypted.Close();
        }

        static void DecryptFile(string sInputFilename, string sOutputFilename)
        {
            string sKey = "12345678";
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);
            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
            fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();
        }
    }

    public class GZip
    {
        public static byte[] Comprimir(byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gZipStream.Write(data, 0, data.Length);
                    gZipStream.Close();
                }
                return memoryStream.ToArray();
            }
        }

        public static byte[] DesComprimir(byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(data, 0, data.Length);
                memoryStream.Position = 0;
                using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress, true))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        byte[] buffer = new byte[64];
                        int read = -1;
                        read = gZipStream.Read(buffer, 0, buffer.Length);
                        while (read > 0)
                        {
                            stream.Write(buffer, 0, read);
                            read = gZipStream.Read(buffer, 0, buffer.Length);
                        }
                        gZipStream.Close();
                        return stream.ToArray();
                    }
                }
            }
        }
    }
}
