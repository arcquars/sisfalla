using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controles
{
    public class ValidadorControlFechaParte : IValidadorControl
    {
        private string _formato;
       public  string separators = "/ : -";

        public ValidadorControlFechaParte(string formato)
        {
            _formato = formato;
        }

        public bool IsValido(string valor)
        {
            if (m_pos == 0)
            {
                return true;
            }

            string vv = _formato.Substring(m_pos - 1, 1);
            if (separators.IndexOf(vv) >= 0)
            {
                return false;

            }
           string val = valor;
           string parte = string.Empty;
           string formato =  GetParte(valor, out parte, m_pos );
           foreach (char item in separators.ToCharArray ())
           {
               parte.Replace(item, '0');
            }
           int valorInt = -1;
           bool valid = true ;
            if (int.TryParse (parte, out valorInt ))
            {
                switch (formato )
                {
                    case "dd":
                        if ((valorInt > 31)|| (valorInt <= 0))
                        {
                            valid = false;
                        }

                        break;
                        case "mm":
                        if ((valorInt > 13) || (valorInt <= 0))
                        {
                            valid = false;
                        }
                        break;
                        case "yyyy":
                        if (valorInt > DateTime.Now.Year || valorInt <= 2000)
                        {
                            valid = false;
                        }
                        break;
                }
            }
          
            
            return valid;
        }

        private int Pos(int pos, int direccion)
        {
            return 0;

        }
        private string GetParte(string valor, out string  sbvalor, int pos)
        {

            string primero = _formato.Substring(pos);
            
           
            int pos_ultimo = primero.IndexOfAny(separators.ToCharArray());
            if (pos_ultimo == -1)
            {
                pos_ultimo = primero.Length;
            }

            pos_ultimo += pos;

            string ultimo = _formato.Substring(0, pos);
            int pos_primero = ultimo.LastIndexOfAny(separators.ToCharArray());
            string ff = _formato.Substring(pos_primero+1, pos_ultimo - pos_primero -1);
            sbvalor = valor.Substring(pos_primero + 1, pos_ultimo - pos_primero - 1);
            return ff;
        }

        private int m_pos;
        public int Posicion
        {
            get
            {
                return m_pos;
            }
            set
            {
                m_pos = value;
            }
        }
    }
}