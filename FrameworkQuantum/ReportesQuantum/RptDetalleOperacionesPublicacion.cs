using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reportes;
using System.Data;
using Oracle.DataAccess.Client;

namespace ReportesQuantum
{
    class RptDetalleOperacionesPublicacion : ProveedorDatosBase
    {
        public override List<DataTable> GetDatos()
        {
            List<DataTable> resultado = new List<DataTable>();

            string sql =
            @"SELECT
    P.DESCRIPCION_CATEGORIA AS CATEGORIA,
	A.COD_CATEGORIA AS CATEGORIA_PUBLICACION,
	TO_DATE(TO_CHAR(A .FECHA_OPERACION,'DD/MM/YYYY'),'DD/MM/YYYY') AS FECHADOC,
	MAX (B.FECHA_TRANSACCION) AS FECHA_PUBLICACION
FROM
	(
		SELECT DISTINCT
			F.FECHA_OPERACION,
			F.COD_CATEGORIA
		FROM
			F_DI_OPERACION F,
			P_DEF_CATPUBLICACION E
		WHERE
			F.COD_CATEGORIA = E .COD_CATEGORIA
		AND E .HORA_LIMITE IS NOT NULL
	) C,
	F_DI_OPERACION A,
	F_SEC_LOG B,
    P_DEF_CATPUBLICACION P
WHERE
	A .SEC_LOG = B.COD_SEC_LOG
AND A .COD_CATEGORIA = C.COD_CATEGORIA
AND A .FECHA_OPERACION = C.FECHA_OPERACION
AND A .COD_CATEGORIA = P.COD_CATEGORIA
GROUP BY
P.DESCRIPCION_CATEGORIA,
	A .COD_CATEGORIA,
	A .FECHA_OPERACION
ORDER BY
	2 DESC";

            OracleCommand cmd = CrearComando(sql);
            DataTable tabla1 = EjecutarComando(cmd, "DetallePlazos");
            resultado.Add(tabla1);

            sql =
            @"SELECT
case WHEN P.FECHA_PLAZO - P.FECHA_PUBLICACION < 0 then
abs(trunc(((P.FECHA_PLAZO - P.FECHA_PUBLICACION)*24),0)) || ':' || to_char(abs(trunc(mod(((P.FECHA_PLAZO - P.FECHA_PUBLICACION)*24*60),60),0)),'09')
end
AS FUERA_PLAZO,
case WHEN P.FECHA_PLAZO - P.FECHA_PUBLICACION < 0 then
abs(trunc((P.FECHA_PLAZO - P.FECHA_PUBLICACION)*24*60))
end
AS FUERA_PLAZO_MINUTOS
,P.*
FROM
(
SELECT
CASE 
WHEN D_CATEGORIA.FECHA_LIMITE = 1 then
to_date(to_char(F_DI_OPERACION.FECHA_OPERACION-1,'DD/MM/YYYY') || ' ' || D_CATEGORIA.HORA_LIMITE, 'DD/MM/YYYY hh24:mi:ss')
WHEN D_CATEGORIA.FECHA_LIMITE = 2 then
to_date(to_char(F_DI_OPERACION.FECHA_OPERACION,'DD/MM/YYYY') || ' ' || D_CATEGORIA.HORA_LIMITE, 'DD/MM/YYYY hh24:mi:ss')
WHEN D_CATEGORIA.FECHA_LIMITE = 3 then
to_date(to_char(F_DI_OPERACION.FECHA_OPERACION+1,'DD/MM/YYYY') || ' ' || D_CATEGORIA.HORA_LIMITE, 'DD/MM/YYYY hh24:mi:ss')
end
  AS FECHA_PLAZO,
D_SECLOG.FECHA_TRANSACCION AS FECHA_PUBLICACION,
F_DI_OPERACION.DETALLE AS NOMBRE_ARCHIVO,
TO_DATE(TO_CHAR(F_DI_OPERACION.FECHA_OPERACION,'DD/MM/YYYY'),'DD/MM/YYYY') AS FECHADOC,
F_DI_OPERACION.COD_CATEGORIA AS CATEGORIA_PUBLICACION,
D_CATEGORIA.DESCRIPCION_CATEGORIA AS NOMBRE_CATEGORIA,
D_SECLOG.FK_LOGIN AS USUARIO,
D_SECLOG.NOMBRE_PC,
D_SECLOG.IP_PC,
F_DI_OPERACION.MOTIVO_PUBLICACION
FROM
F_DI_OPERACION
INNER JOIN F_SEC_LOG D_SECLOG ON F_DI_OPERACION.SEC_LOG = D_SECLOG.COD_SEC_LOG
INNER JOIN P_DEF_CATPUBLICACION D_CATEGORIA ON D_CATEGORIA.COD_CATEGORIA = F_DI_OPERACION.COD_CATEGORIA

) P";

            cmd = CrearComando(sql);
            DataTable tabla2 = EjecutarComando(cmd, "DetallePublicados");
            resultado.Add(tabla2);
            return resultado;
        }

        public override TipoPanel GetTipoPanel()
        {
            return TipoPanel.Parametros;
        }

        public override System.Resources.ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }
}
