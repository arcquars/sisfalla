using System;
using System.Collections.Generic;
using System.Text;

namespace CNDC.ExceptionHandlerLib
{
    public interface IMessageViewer
    {
        void Show(string msg);
        void Show(string msg, Exception ex);
    }
}
