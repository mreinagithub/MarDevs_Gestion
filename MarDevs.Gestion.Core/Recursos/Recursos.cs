using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace MarDevs.Gestion.Core
{
	public class Recursos
	{
		public static Dictionary<String, ResourceManager> RecursosEnsamblados = new Dictionary<string, ResourceManager>();

		public static object TraerRecursoEnsamblado(String key)
		{
			if (String.IsNullOrEmpty(key))
			{
				return null;
			}
			String[] nombreparseado = key.Split(',');
			String recursoNombre = String.Empty;
			String recursoDll = String.Empty;
			
			object recurso = null;
			
			if (nombreparseado.Length == 2)
			{
				recursoNombre = nombreparseado[0].Trim();
				recursoDll = nombreparseado[1].Trim();
				if (RecursosEnsamblados.ContainsKey(recursoDll))
				{
					recurso = RecursosEnsamblados[recursoDll].GetObject(recursoNombre);
					return recurso;
				}
			}
			else if (nombreparseado.Length == 1)
			{
				//si solo puso el nombre busco el primer recurso que coincida
				recursoNombre = nombreparseado[0];
				foreach (KeyValuePair<string, ResourceManager> rm in RecursosEnsamblados)
				{
					recurso = rm.Value.GetObject(nombreparseado[0]);
					if (recurso != null)
					{
						return recurso;
					}
				}
			}
			return null;
		}
		public static void AgregarEnsamblado(System.Reflection.Assembly ass, String archivoRecursos)
		{
			if (archivoRecursos != String.Empty)
			{
				try
				{
					System.Resources.ResourceManager res = new System.Resources.ResourceManager(archivoRecursos, ass);
					if (!RecursosEnsamblados.ContainsKey(archivoRecursos))
					{
						RecursosEnsamblados.Add(archivoRecursos, res);
					}
						
				}
				catch (Exception ex)
				{
					throw new Exception("No se puedo cargar el recurso", ex);
				}
			}
			else
			{

			}

		}
	}
}
