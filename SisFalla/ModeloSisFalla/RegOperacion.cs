using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModeloSisFalla
{
    public class RegOperacion
    {
    }

    public interface IRegOperacionMgr
    {
        void Registrar(DOM_OPERACION op, string rol, long pkCodPersona, string tipoObj, long codObj);
    }

    public enum DOM_OPERACION
    {
        EnviaNotif = 1,
        ElabInf,
        TerminaInf,
        EnviaInf,
        RevierteInf
    }
}
