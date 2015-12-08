using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace CNDC.UtilesComunes
{
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
