using System;
using System.Collections;
using System.Collections.Generic;

namespace MarDevs.Gestion.Core
{
    public static class QueryHelper
    {
        private static  Hashtable _operadorToPeriodo = null;
        private static Dictionary<Operador, string> _operadorToHql = null;

        static QueryHelper()
        {
			_operadorToHql = new Dictionary<Operador, string>();
			_operadorToHql.Add(Operador.EsNulo, " IS NULL ");
			_operadorToHql.Add(Operador.NoEsNulo, " IS NOT NULL ");
			_operadorToHql.Add(Operador.Igual, " = ");
			_operadorToHql.Add(Operador.MayorIgual, " >= ");
            _operadorToHql.Add(Operador.MayorQue, " > ");
            _operadorToHql.Add(Operador.Menor, " < ");
            _operadorToHql.Add(Operador.MenorIgual, " <= ");
            _operadorToHql.Add(Operador.Contiene, " LIKE ");
			_operadorToHql.Add(Operador.Distinto, " <> ");
			_operadorToHql.Add(Operador.En, " IN ");
			_operadorToHql.Add(Operador.NoEn, " NOT IN ");
        }

        public static string ArmarHQL(Query vista)
        {
            string hql = String.Format("from {0} as entidad", vista.Entidad);
            //left join fetch
            if (vista.FetchJoins != null)
            {
                foreach (string entidad in vista.FetchJoins)
                {
                    hql += String.Format(" left join fetch {0} ", entidad);
                }
                hql = hql.Replace("[entidad]", "entidad");
            }
            string where = ProcesarFiltro(vista.Filtro);
			if (where.Length > 0)
			{
				//where = ReemplazarParametros(vista, where);
				hql += " WHERE " + where;
			}
            hql = ReemplazarTokens(hql);
            hql = hql.Replace("[entidad]", "entidad");
            return hql;
        }
        private static string ProcesarFiltroOld(Filtro filtro)
        {
            string where = String.Empty;
            //procesar condiciones del filtroPorPrivilegio
            foreach (Condicion cond in filtro.Condiciones)
            {
                where += String.Format("( {0} )", ProcesarCondicion(cond));
                if (filtro.Condiciones.IndexOf(cond) < filtro.Condiciones.Count - 1)
                {
                    where += " " + filtro.OperadorLogico.ToString() + " ";
                }
            }
			//si hay condiciones en el filtroPorPrivilegio hay que unirlas con el operador logico
			if (filtro.Condiciones.Count > 0)
			{
				where += " " + filtro.OperadorLogico.ToString() + " ";
			}
            foreach (Filtro subFiltro in filtro.Filtros)
            {
                where += string.Format("( {0} )", ProcesarFiltro(subFiltro));
				if (filtro.Filtros.IndexOf(subFiltro) < filtro.Filtros.Count - 1)
				{
					where += " " + filtro.OperadorLogico.ToString() + " ";
				}
            }
			return where;
        }
		public static string ProcesarFiltro(Filtro filtro)
		{
			//fusionar las colecciones para simplificar la logica
			ArrayList condiciones = new ArrayList();
			condiciones.AddRange(filtro.Condiciones);
			
            foreach (Filtro item in filtro.Filtros)
			{
				if (!item.EsFiltroVacio())
				{
					condiciones.Add(item);
				}
			}

			string where = String.Empty;
			//procesar condiciones del filtroPorPrivilegio
			
            foreach (object parte in condiciones)
			{
				if (parte is Condicion)
				{
					where += String.Format("( {0} )", ProcesarCondicion(parte as Condicion));
				}
				else if (parte is Filtro && !(parte as Filtro).EsFiltroVacio())
				{
					where += string.Format("( {0} )", ProcesarFiltro(parte as Filtro));
				}
				if (condiciones.IndexOf(parte) < condiciones.Count - 1)
				{
					where += " " + filtro.OperadorLogico.ToString() + " ";
				}
			}
			return where;
		}
		private static string ProcesarCondicion(Condicion cond)
        {

            string condicion = String.Format("[entidad].{0}", cond.Propiedad);
            switch (cond.Operador)
            {
				case Operador.EsNulo:
				case Operador.NoEsNulo:
					condicion += ProcesarOperadorSimple(cond.Operador, null);                    
					break;
                case Operador.Igual:
                case Operador.MayorIgual:
                case Operador.MayorQue:
                case Operador.Menor:
                case Operador.MenorIgual:
                case Operador.Contiene:
				case Operador.Distinto:
                    if (cond.Valores != null && cond.Valores.Length>1) 
                    {
                        condicion = ProcesarCondicionMultiple(cond.Operador, cond.Valores, condicion);
                    }
                    else
                    {
                        condicion += ProcesarOperadorSimple(cond.Operador, cond.Valores[0]);                    
                    }
                    break;
				case Operador.En:
				case Operador.NoEn:
					condicion += ProcesarOperadoresIn(cond.Operador, cond.Valores);
					break;
                default:
                    throw new ArgumentException("OPERADOR NO IMPLEMENTADO AUN");
            }
            return condicion;
        }

        private static string ProcesarCondicionMultiple(Operador operador, object[] Datos, String Entidad)
        {
            String _condicion = "(";
            String valor = String.Empty;

            foreach (object dato in Datos)
            {
                Condicion condicion = dato as Condicion;
                if (_condicion != "(")
                {
                    _condicion += " or ";
                }
                else
                {
                    _condicion += String.Format("");
                }
                _condicion += Entidad + " " + _operadorToHql[operador] + " " + dato;
                valor += _condicion + valor;
            }
            valor +=valor + ")";
            return _condicion;
        }
        private static string ProcesarOperadorDePeriodo(Operador operador)
        {
            if (!_operadorToPeriodo.ContainsKey(operador))
            {
                throw new ArgumentException(String.Format("El operador {0} no está mapeado a un período", operador));
            }
            Periodo periodo = _operadorToPeriodo[operador] as Periodo;
            return String.Format(" BETWEEN  '{0}' AND '{1}' ",
                periodo.Desde.ToString("dd/MM/yyyy HH:mm"),
                periodo.Hasta.ToString("dd/MM/yyyy HH:mm"));
        }
        private static string ProcesarOperadorSimple(Operador operador, object valor)
        {
			if (operador == Operador.EsNulo || operador == Operador.NoEsNulo)
			{
				return _operadorToHql[operador];
			}
			else
			{
				return _operadorToHql[operador] + " " + FormatearValor(valor);
			}
        }
		private static string ProcesarOperadoresIn(Operador operador, object[] valores)
		{
			//por ahora solo se soporta ArrayList para recibir la lista de valores
			if ( valores == null || valores.Length == 0)
			{
				throw new ArgumentException("Operadores de tipo IN requieren una lista de valores de al menos un elemento");
			}
			string resultado = _operadorToHql[operador] + " (";
			for (int i = 0; i < valores.Length; i++)
			{
				resultado += FormatearValor(valores[i]);
				if (i < valores.Length - 1)
				{
					resultado += ", ";
				}
			}
			resultado += ")";
			return resultado;
		}
		private static string ReemplazarTokens(string expresion)
        {
            //usuario logueado
            expresion = expresion.Replace("[usuario]", ConfigBL.ticket.Usuario.Id.ToString());
            //hoy
            expresion = expresion.Replace("[hoy]", "'" + ConfigBL.FechaActual.ToString("dd/MM/yyyy") + "'");

            return expresion;
        }
        private static string FormatearValor(object valor)
        {
            if (EsToken(valor))
            {
                return valor as string;
            }
            if (valor is string || valor is Guid)
            {
                return String.Format("'{0}'", valor);
            }
            if (valor is int || valor is decimal || valor is short)
            {
                return String.Format("{0}", valor);
            }
            if (valor is DateTime)
            {
                return String.Format("'{0}'", ((DateTime)valor).ToString("yyyyMMdd HH:mm"));
            }
			if (valor.GetType().IsEnum)
			{
				return String.Format("{0}", Convert.ToInt64(valor));
			}
			throw new Exception("TIPO DE PARAMETRO NO SOPORTADO, POR AHORA"); ;

        }
        private static bool EsToken(object valor)
        {
            List<string> tokens = new List<string>();
            tokens.Add("[usuario]");
            tokens.Add("[hoy]");

            return tokens.Contains(valor as string);
        }

    }
}
