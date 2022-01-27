using System;
using System.Data;
using System.Configuration;
using System.Xml;
using System.IO;

namespace MarDevs.Gestion.Core
{

	/// <summary>
	/// Descripción breve de AppSettings
	/// </summary>
	public class UserSettings
	{
		public UserSettings()
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
				XmlElement raiz = _document.CreateElement("settings");
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
				//crearla si no existe
				if (!Directory.Exists(_settingsPath))
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
		private string _archivo = @".\settings.xml";

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
				string xpath = String.Format("setting[@key=\"{0}\"]", key);
				XmlElement nodo = _document.DocumentElement.SelectSingleNode(xpath) as XmlElement;
				if (nodo != null)
				{
					return nodo.GetAttribute("valor");
				}
				else
				{
					if (UserSettings.CrearAutomaticamente)
					{
						nodo = _document.CreateNode(XmlNodeType.Element, "setting", String.Empty) as XmlElement;

						XmlAttribute attr;

						attr = _document.CreateAttribute("key");
						attr.Value = key;
						nodo.Attributes.Append(attr);

						attr = _document.CreateAttribute("valor");
						attr.Value = String.Empty;
						nodo.Attributes.Append(attr);

						_document.DocumentElement.AppendChild(nodo);

						return nodo.GetAttribute("valor");
					}
					else
					{
						throw new ArgumentException(String.Format("Clave {0} no existe.", key));
					}
				}
			}
			set
			{
				string xpath = String.Format("setting[@key=\"{0}\"]", key);
				XmlElement nodo = _document.DocumentElement.SelectSingleNode(xpath) as XmlElement;
				if (nodo != null)
				{
					XmlAttribute attr = _document.CreateAttribute("valor");
					attr.Value = value;
					nodo.Attributes.Append(attr);
				}
				else
				{
					if (UserSettings.CrearAutomaticamente)
					{
						nodo = _document.CreateNode(XmlNodeType.Element, "setting", String.Empty) as XmlElement;

						XmlAttribute attr;
						
						attr = _document.CreateAttribute("key");
						attr.Value = key;
						nodo.Attributes.Append(attr);

						attr = _document.CreateAttribute("valor");
						attr.Value = value;
						nodo.Attributes.Append(attr);

						_document.DocumentElement.AppendChild(nodo);
					}
					else
					{
						throw new ArgumentException(String.Format("Clave {0} no encontrada.", key));
					}
				}
			}

		}

		public int GetInt(string key)
		{
			string valor = this[key];

			int numero = 0;
			Int32.TryParse(valor, out numero);
			return numero;
		}
		public bool GetBoolean(string key)
		{
			string cadena = this[key];

			bool valor = false;
			Boolean.TryParse(cadena, out valor);
			return valor;
		}

	}
}
