using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNDC.BLL
{
    public class Contexto
    {
        public Dictionary<string,string> Valores { get; set; }

        public Contexto(string contexto)
        {
            Valores = new Dictionary<string, string>();
            string[] datos = contexto.Split('|');
            foreach (string item in datos)
            {
                string[] par = item.Split('=');
                Valores[par[0]] = par[1];
            }
        }

        public Contexto()
        {
            Valores = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            string resultado = string.Empty;
            foreach (var item in Valores)
            {
                if (resultado != string.Empty)
                {
                    resultado += "|";
                }
                resultado += item.Key + "=" + item.Value;
            }
            return resultado;
        }
    }
}
