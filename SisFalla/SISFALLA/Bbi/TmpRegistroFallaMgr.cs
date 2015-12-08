using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SISFALLA.Bbi
{
    public class TmpRegistroFallaMgr
    {
        #region Singleton
        private static TmpRegistroFallaMgr _instance;
        public static TmpRegistroFallaMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TmpRegistroFallaMgr();
                }
                return _instance;
            }
        }

        private TmpRegistroFallaMgr()
        {
            Initialize();
        }
        #endregion Singlton

        #region Fields
        DataTable _tabla;
        #endregion Fields

        private void Initialize()
        {
            _tabla = new DataTable("RegistroFallas");
            DataColumn colCodigo = new DataColumn("CodigoFalla", typeof(string));
            DataColumn colFecha = new DataColumn("FechaHora", typeof(DateTime));
            DataColumn colComponente = new DataColumn("Componente", typeof(string));
            DataColumn colDescripcion = new DataColumn("Descripcion", typeof(string));
            DataColumn colOtrosDestinatarios = new DataColumn("OtrosDestinatarios", typeof(string));
            _tabla.Columns.Add(colCodigo);
            _tabla.Columns.Add(colFecha);
            _tabla.Columns.Add(colComponente);
            _tabla.Columns.Add(colDescripcion);
            _tabla.Columns.Add(colOtrosDestinatarios);
        }

        public DataTable GetTabla()
        {
            return _tabla;
        }

        
    }
}
