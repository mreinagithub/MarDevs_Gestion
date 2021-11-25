using System;
using System.Data;
using System.Configuration;
using System.Xml;
using System.IO;

namespace MarDevs.OC.Core
{

	/// <summary>
	/// Descripción breve de AppSettings
	/// </summary>
	public class Settings
	{
		public Settings()
		{
			_document = new XmlDocument();
			_archivo = Path.Combine(_settingsPath, _archivo);
			if (File.Exists(_archivo))
			{
				_document.Load(_archivo);
			}
			else
			{
				_document = new XmlDocument();
				XmlElement raiz = _document.CreateElement("appSettings");
				_document.AppendChild(raiz);
				_document.Save(_archivo);
			}

		}

		private static string _settingsPath;
		private static bool _crearAutomaticamente = true;

		public static string SettingsPath
		{
			get { return _settingsPath; }
			set 
			{ 
				_settingsPath = value;
				//crearla si no existe y no esta vacia
				if (!String.IsNullOrEmpty(value) && !Directory.Exists(_settingsPath))
				{
					Directory.CreateDirectory(_settingsPath);
				}
			}
		}
		public static bool CrearAutomaticamente
		{
			get { return _crearAutomaticamente; }
			set { _crearAutomaticamente = value; }
		}

		private XmlDocument _document;
		private string _archivo = @".\appsettings.xml";

		public void Guardar()
		{
			if (_document != null)
			{
				_document.Save(_archivo);
			}
		}

		public string this[string key]
		{
			get
			{
				XmlNode nodo = _document.DocumentElement.SelectSingleNode(key);
				if (nodo != null)
				{
					String valor = (nodo as XmlElement).GetAttribute("valor");
					return valor;
				}
				else
				{
					if (Settings.CrearAutomaticamente)
					{
						nodo = _document.CreateNode(XmlNodeType.Element, key, String.Empty);
						nodo.InnerText = String.Empty;
						_document.DocumentElement.AppendChild(nodo);
						return nodo.Attributes[key].ToString();
					}
					else
					{
						throw new ArgumentException(String.Format("Clave {0} no existe.", key));
					}
				}
			}
			set
			{
				XmlNode nodo = _document.DocumentElement.SelectSingleNode(key);
				if (nodo != null)
				{
					//nodo.InnerText = value;
					XmlAttribute attr = _document.CreateAttribute("valor");
					attr.Value = value;
					nodo.Attributes.Append(attr);
				}
				else
				{
					if (Settings.CrearAutomaticamente)
					{
						nodo = _document.CreateNode(XmlNodeType.Element, key, String.Empty);
						nodo.InnerText = value;
						_document.DocumentElement.AppendChild(nodo);
					}
					else
					{
						throw new ArgumentException(String.Format("Clave {0} no encontrada.", key));
					}
				}
			}

		}

	}
}
