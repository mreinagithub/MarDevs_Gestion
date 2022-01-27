using System;
using System.Text;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Core
{
	public class ParametroAccion
	{
		public ParametroAccion()
		{
		}
		public ParametroAccion(Type tipo, object valor)
		{
			_tipo = tipo.FullName;
			_valor = valor.ToString();
		}

		private string _tipo;
		private string _valor;

		[XmlAttribute]
		public string Tipo
		{
			get { return _tipo; }
			set { _tipo = value; }
		}
		[XmlAttribute]
		public string Valor
		{
			get { return _valor; }
			set { _valor = value; }
		}


	}
}
