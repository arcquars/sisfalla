using CNDC.BLL;
using ModeloSisFalla;
using OraDalSisFalla;

namespace WcfServicioSISFALLA
{
    public class WcfServRegFallaMgr : IWcfObjetoNegocioMgr
    {
        public void Guardar(ObjetoDeNegocio obj)
        {
            new OraDalRegFallaMgr().Guardar(obj as RegFalla);
        }
    }
}