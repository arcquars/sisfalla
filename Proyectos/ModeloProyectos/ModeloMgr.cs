using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;

namespace ModeloProyectos
{
    public class ModeloMgr
    {
        #region Singleton
        private static ModeloMgr _instancia;

        static ModeloMgr()
        {
            _instancia = new ModeloMgr();
        }

        public static ModeloMgr Instancia
        {
            get { return _instancia; }
        }

        private ModeloMgr()
        {
            Inicializar();
        }
        #endregion Singleton


        public IDefDominioMgr DefDominioMgr { get; set; }
        public IIdMgr IdMgr { get; set; }

        private void Inicializar()
        {

        }
    }
}
