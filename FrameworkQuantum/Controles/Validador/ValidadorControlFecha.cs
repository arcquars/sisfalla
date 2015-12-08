using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controles
{
    public class ValidadorControlFecha : IValidadorControl
    {
        private string _formato;

        public ValidadorControlFecha(string formato)
        {
            _formato = formato;
        }

        public bool IsValido(string valor)
        {
            bool rtn = false;
            int dd = 0;
            int mm = 0;
            int yy = 0;
            int hh = 0;
            int mi = 0;
            int ss = 0;
            if (GetParte(valor, "dd", out  dd) && GetParte(valor, "mm", out mm) && GetParte(valor, "yyyy", out yy))
            {
                try
                {
                    DateTime dt = new DateTime(yy, mm, dd);
                    rtn = true;
                }
                catch (Exception e)
                {
                    rtn = false;
                }
            }

            return rtn;
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

        private bool GetParte(string s, string parte, out int result)
        {
            bool rtn = false;
            result = 0;
            if (_formato.Contains(parte))
            {
                int pos = _formato.IndexOf(parte);
                int len = parte.Length;
                string substr = s.Substring(pos, len);
                rtn = int.TryParse(substr, out result);
            }
            return rtn;
        }

    }
}
