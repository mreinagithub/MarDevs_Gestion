using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Reflection;
using System.IO;

namespace MarDevs.OC.Win
{
	[Serializable]
	[XmlRoot("panelnavegacion", Namespace="urn:panel-navegacion")]
	public class PanelNavegacion
	{
		private ArrayList _paneles = new ArrayList();

		[XmlElement(Type=typeof(PanelNav), ElementName = "panel")]
		public ArrayList Paneles
		{
			get { return _paneles; }
			set { _paneles = value; }
		}

		public Comando ObtenerComando(string key)
		{
			foreach (PanelNav panel in _paneles)
			{
				foreach (GrupoMenu grupo in panel.Grupos)
				{
					foreach (Comando opcion in grupo.Opciones)
					{
						if (opcion.Key.Equals(key))
						{
							return opcion;
						}
					}
				}
			}
			return null;
		}
		public GrupoMenu ObtenerGrupo(string key)
		{
			foreach (PanelNav panel in _paneles)
			{
				foreach (GrupoMenu grupo in panel.Grupos)
				{
					if (grupo.Key.Equals(key))
					{
						return grupo;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// obtiene un objeto panel navegacion a partir del xml de un panel incrustado en el proyecto
		/// </summary>
		/// <param name="archivoRecursos">nombre del archivo en formato nombre, ensamblado</param>
		/// <returns></returns>
		public static PanelNavegacion ObtenerDesdeRecursoIncrustado(string archivoRecursos)
		{
			string[] partes = archivoRecursos.Split(',');
			if (partes.Length != 2)
			{
				throw new ArgumentException("No se pudo encontrar el archivo de recursos: " + archivoRecursos);
			}
			Assembly assembly = PanelNavegacion.BuscarEnsamblado(partes[1]);
			if (assembly == null)
			{
				throw new ArgumentException("No se pudo encontrar el ensamblado: " + partes[1]);
			}
			PanelNavegacion panel = null;
			string xml = String.Empty;
			foreach (string fileName in assembly.GetManifestResourceNames())
			{
				if (fileName.EndsWith(partes[0]))
				{
					xml = fileName;
					break;
				}
			}
			if (xml.Length > 0)
			{

				Stream stream = assembly.GetManifestResourceStream(xml);

				XmlSerializer mySerializer = new XmlSerializer(typeof(PanelNavegacion));
				panel = (PanelNavegacion)mySerializer.Deserialize(stream);
			}
			return panel;
		}
		private static Assembly BuscarEnsamblado(string nombreEnsamblado)
		{
			Assembly[] ensamblados = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in ensamblados)
			{
				string[] partesNombre = assembly.FullName.Split(',');
				if (partesNombre[0] == nombreEnsamblado.Trim())
				{
					return assembly;
				}
			}
			return null;
		}
	}
}