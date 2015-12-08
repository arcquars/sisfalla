using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;

namespace ReportesQuantum
{
    class RptDiccionarioDatos : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
            A.TABLE_NAME AS NOMBRE_TABLA, 
            A.COMMENTS AS TABLA_COMENTARIO , 
            E.CREATED AS DATE_CREATED,
            E.LAST_DDL_TIME AS DATE_CHANGED ,
            B.COLUMN_NAME AS NOMBRE_COLUMNA, 
            B.COMMENTS AS COLUMNA_COMENTARIO,
            D.DATA_TYPE AS TIPO_DATO,
            D.DATA_LENGTH AS MAXIMUM_LENGTH,
            D.DATA_SCALE AS DECIMAL_PLACES ,
            D.DATA_PRECISION AS PRECISION,
            '' AS CAMPO1,
            '' AS CAMPO2
            FROM
            USER_TAB_COMMENTS A
            , USER_COL_COMMENTS B
            , USER_TABLES C
            , USER_TAB_COLUMNS D
            , USER_OBJECTS E 
            WHERE
            (A.TABLE_NAME = C.TABLE_NAME) AND
            (C.TABLE_NAME = D.TABLE_NAME) AND
            (B.TABLE_NAME = D.TABLE_NAME) AND
            (B.COLUMN_NAME = D.COLUMN_NAME) AND
            (E.OBJECT_NAME =A.TABLE_NAME)
            AND (E.OBJECT_TYPE='TABLE') 
            AND (SUBSTR(A.TABLE_NAME,1,2) IN('F_', 'P_'))
            AND INSTR(A.TABLE_NAME,'BK')= 0
            ORDER BY
            A.TABLE_NAME ASC,
            D.COLUMN_ID";

            OracleCommand cmd = CrearComando(sql);
            DataTable tablaDetalleDominio = EjecutarComando(cmd, "DetalleDiccionario");
            resultado.Add(tablaDetalleDominio);

            return resultado;
        }

        public override TipoPanel GetTipoPanel()
        {
            return TipoPanel.Ninguno;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }
}
