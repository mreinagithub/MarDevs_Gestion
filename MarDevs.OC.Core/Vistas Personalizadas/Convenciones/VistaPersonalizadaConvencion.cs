using System.Data;
using System.Text;

namespace MarDevs.OC.Core
{
	public class VistaPersonalizadaConvencion
	{
		public virtual string ObtenerConvencionesEntidad(){ return string.Empty; }
		public string ObtenerConvenciones()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(ObtenerConvencionesEntidad());
			sb.AppendLine();
			sb.AppendLine("VARIABLES");
			sb.AppendLine("- Se puede usar las variables '$usuarioId' o '$usuarioLogon' para referenciarse al usuario logueado.");
			sb.AppendLine("- Es sensible de mayúsculas y minúsculas.");

			sb.AppendLine();
			sb.AppendLine("PARAMETROS");
			sb.AppendLine("- Para utilizar los parámetros en la consulta principal usar el id del parámetro antecedido por @.");
			sb.AppendLine("- Para buscar de entre un conjunto de propiedades/columnas definifas en el parámetro utilice el id del parámetro antecedido por #");
			sb.AppendLine("- Es sensible de mayúsculas y minúsculas.");
			sb.AppendLine("- Si se usa el parámetro periodo siempre se debe referenciar a la propiedad/columna a través del uso de la variale '#'. Ejemplo: WHERE/AND/OR '#periodo BETWEEN @periodo'");
			sb.AppendLine("- Ejemplos de utilización de variables:");
			sb.AppendLine("		> Usar '#texto LIKE @texto' para parámetros de tipo Texto.");
			sb.AppendLine("		> Usar '#periodo BETWEEN @periodo' para prámetros de tipo Periodo.");

			return sb.ToString();
		}

		public string DeterminarCumplimientoConvencionesSQL(string consulta, DataTable dt)
		{
			string sql = consulta.ToUpper();
			StringBuilder sb = new StringBuilder();
			if (!dt.Columns.Contains("Id"))
				sb.AppendLine(" - No se encontró la columna Id. No se podrán realizar acciones sobre la grilla ni obtener las notas.");
			if (!dt.Columns.Contains("ColorFila"))
				sb.AppendLine(" - No se encontró la columna ColorFila. No pintarán las filas.");
			if (!dt.Columns.Contains("ColorTexto"))
				sb.AppendLine(" - No se encontró la columna ColorTexto. No cambiará el color del texto.");
			if (!dt.Columns.Contains("ToolTip"))
				sb.AppendLine(" - No se encontró la columna ToolTip. No se agregán notas sobre las filas.");

			sb.Append(DeterminarCumplimientoConvencionesSQLEntidad(sql, dt));

			return sb.ToString();
		}
		public virtual string DeterminarCumplimientoConvencionesSQLEntidad(string consulta, DataTable dt) { return string.Empty; }

		public string DeterminarCumplimientoConvencionesHQL(string consulta)
		{
			string sql = consulta.ToUpper();
			StringBuilder sb = new StringBuilder();

			sb.Append(DeterminarCumplimientoConvencionesHQLEntidad(sql));

			return sb.ToString();
		}
		public virtual string DeterminarCumplimientoConvencionesHQLEntidad(string consulta) { return string.Empty; }
	}
}
