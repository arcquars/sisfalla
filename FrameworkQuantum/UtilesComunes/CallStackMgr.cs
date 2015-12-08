using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace CNDC.UtilesComunes
{
    public class CallStackMgr
    {
        public static string GetPilaLlamadas()
        {
            StringBuilder resultado = new StringBuilder(1024);
            StackTrace stackTrace = new StackTrace(true);
            StackFrame[] stackFrames = stackTrace.GetFrames();

            bool codigoExterno = false;
            for (int i = 1; i < stackFrames.Length; i++)
            {
                StackFrame stackFrame = stackFrames[i];
                if (stackFrame.GetFileLineNumber() > 0)
                {
                    codigoExterno = false;
                    resultado.AppendFormat("{0} {1} linea: {2} {3}", stackFrame.GetFileName(),
                        GetInfoMetodo(stackFrame.GetMethod()), stackFrame.GetFileLineNumber(), Environment.NewLine);
                }
                else if (!codigoExterno)
                {
                    codigoExterno = true;
                    resultado.AppendLine("<Codigo Externo>");
                }
            }
            
            return resultado.ToString();
        }

        private static string GetInfoMetodo(MethodBase metodo)
        {
            StringBuilder sb = new StringBuilder(64);
            foreach (var p in metodo.GetParameters())
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                sb.AppendFormat("{0} {1}", p.ParameterType.Name, p.Name);
            }
            return string.Format("{0}({1})", metodo.Name, sb.ToString());
            //return string.Format("{0}.{1}({2})", metodo.DeclaringType.FullName, metodo.Name, sb.ToString());
        }
    }
}
