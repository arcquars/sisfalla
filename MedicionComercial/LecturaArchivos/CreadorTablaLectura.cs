using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LecturaArchivos
{
    class CreadorTablaLectura
    {
        public DataTable CrearTabla()
        {
            DataTable resultado = new DataTable();
            DataColumn colFecha = new DataColumn("Fecha", typeof(DateTime));
            DataColumn colHora = new DataColumn("Hora", typeof(string));
            DataColumn colInfCanal = new DataColumn("CodInfCanal", typeof(long));
            DataColumn colIntervalo = new DataColumn("CodIntervalo", typeof(long));
            DataColumn colCanal = new DataColumn("Canal", typeof(int));
            DataColumn colValor = new DataColumn("Valor", typeof(double));
            resultado.Columns.Add(colFecha);
            resultado.Columns.Add(colHora);
            resultado.Columns.Add(colInfCanal);
            resultado.Columns.Add(colIntervalo);
            resultado.Columns.Add(colCanal);
            resultado.Columns.Add(colValor);

            return resultado;
        }
    }
}
