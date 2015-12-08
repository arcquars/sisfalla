using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CNDC.UtilesComunes
{
    public class Serializador
    {
        public static byte[] Serializar(object obj)
        {
            byte[] resultado = null;
            try
            {
                MemoryStream stream = new MemoryStream();
                (new BinaryFormatter()).Serialize(stream, obj);
                resultado = stream.ToArray();
            }
            catch (Exception e)
            {
                Pistas.PistaMgr.Instance.Error("CNDC.UtilesComunes.Serializador", e);
                
            }
            return resultado;
        }

        public static T DeSerializar<T>(byte[] b)
        {
            T resultado = default(T);
            try
            {
                MemoryStream stream = new MemoryStream(b);
                resultado = (T)(new BinaryFormatter()).Deserialize(stream);
            }
            catch (Exception e)
            {
                Pistas.PistaMgr.Instance.Error("CNDC.UtilesComunes.Serializador", e);
            }
            return resultado;
        }
    }
}
