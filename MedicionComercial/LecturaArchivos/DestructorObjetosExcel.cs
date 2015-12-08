using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LecturaArchivos
{
    public class DestructorObjetosExcel
    {
        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
