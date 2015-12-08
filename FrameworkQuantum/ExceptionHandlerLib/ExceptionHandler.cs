using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using CNDC.Pistas;

namespace CNDC.ExceptionHandlerLib
{
    public class ExceptionHandler
    {
        #region Singleton
        private static ExceptionHandler _intance;
        public static ExceptionHandler Instance
        {
            get
            {
                if (_intance == null)
                {
                    _intance = new ExceptionHandler();
                }
                return _intance;
            }
        }

        private ExceptionHandler()
        { 
        }
        #endregion Singleton

        public IMessageViewer MessageViewer { get; set; }

        public void Handle(string module, Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            string msgCode = "0000";

            if (exception is OracleException)
            {
                OracleException ex = (OracleException)exception;
                msgCode = "ORA-" + ex.Number;
            }
            else if (exception is ApplicationException)
            {
                msgCode = exception.GetType().Name;
            }

            string msg = MessageMgr.Instance.GetMessage(msgCode);
            MessageViewer.Show(msg, exception);
            PistaMgr.Instance.Error(module, exception);
        }
    }
}
