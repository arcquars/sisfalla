using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Configuration;
using CNDC.Pistas;

namespace CNDC.Config
{
    public class Config
    {
        #region Singleton
        private static Config _instance;
        public static Config Intance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Config();
                }
                return _instance;
            }
        }

        private Config()
        {
            string dirConfig = ConfigurationManager.AppSettings["ArchConfig"];
            if (string.IsNullOrEmpty(dirConfig))
            {
                DirectorioConfiguracion = "C:\\WCFSisFallaTmp";
            }
            else
            {
                DirectorioConfiguracion = dirConfig;
            }
            Console.WriteLine("ArchConfig = {0}", dirConfig);
        }
        #endregion Singleton

        private XmlDocument _xmlDoc;
        private string _configFileName;
        public string DirectorioConfiguracion { get; set; }

        private void AsegurarConfiguracion()
        {
            if (_xmlDoc == null)
            {
                _configFileName = Path.Combine(DirectorioConfiguracion, GetConfigFileName());
                PistaMgr.Instance.Debug("CNDC.Config", string.Format("_configFileName = {0}", _configFileName));
                Console.WriteLine("_configFileName = {0}", _configFileName);
                _xmlDoc = new XmlDocument();
                _xmlDoc.Load(_configFileName);
            }
        }

        private string GetConfigFileName()
        {
            return "SISFALLAConfig.xml";
        }

        public string Read(string section, string obj, string property, string defaultValue)
        {
            AsegurarConfiguracion();
            string result = defaultValue;
            XmlNode node = _xmlDoc.SelectSingleNode(section + "[@name='" + obj + "']/" + property);
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
            {
                result = node.InnerText;
            }

            Console.WriteLine("{0}-{1}-{2}={3}",section,obj,property,result);
            return result;
        }

        public string Read(string section, string property, string defaultValue)
        {
            AsegurarConfiguracion();
            string result = defaultValue;
            XmlNode node = _xmlDoc.SelectSingleNode(section + "/" + property);
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
            {
                result = node.InnerText;
            }
            return result;
        }

        public void Write(string section, string obj, string propertiy, string value)
        { 

        }
    }
}
