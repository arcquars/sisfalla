using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServicioActualizacion
{
    [ServiceContract]
    public interface IServActualizacion
    {
        [OperationContract]
        Archivo[] GetVersiones(string modulo);       

        [OperationContract]
        byte[] GetArchivo(string modulo, string archivo);
    }

    [DataContract]
    public class Archivo
    {
        private string _nombre;
        private float _version;

        [DataMember]
        public float Version
        {
            get { return _version; }
            set { _version = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    }
}
