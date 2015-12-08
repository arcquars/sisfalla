using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class MensajeEmergenteMgr
    {
        #region Singleton
        private static MensajeEmergenteMgr _instance;
        public static MensajeEmergenteMgr Intancia
        {
            get { return _instance; }
        }

        static MensajeEmergenteMgr()
        {
            _instance = new MensajeEmergenteMgr();
        }

        private MensajeEmergenteMgr()
        {
            _mensajes = new List<MensajeEmergente>();
        }
        #endregion Singleton

        private List<MensajeEmergente> _mensajes;
        public void AdicionarMensaje(MensajeEmergente m)
        {
            if (!_mensajes.Contains(m))
            {
                _mensajes.Add(m);
            }
        }

        public void EliminarMensaje(MensajeEmergente m)
        {
            if (_mensajes.Contains(m))
            {
                _mensajes.Remove(m);
            }
        }

        public List<MensajeEmergente> GetMensajes()
        {
            return _mensajes;
        }

        public void LimpiarMensaje()
        {
            _mensajes.Clear();
        }
    }
}
