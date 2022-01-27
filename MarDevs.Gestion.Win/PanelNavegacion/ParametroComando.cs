using System;
using System.Text;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Win
{
	public class ParametroComando
	{
		public ParametroComando()
		{
		}
		public ParametroComando(Type tipo, object valor)
		{
			_tipo = tipo.FullName;
			_valor = valor.ToString();
		}

		private string _tipo;
		private string _valor;

		[XmlAttribute (AttributeName="tipo")]
		public string Tipo
		{
			get { return _tipo; }
			set { _tipo = value; }
		}
		[XmlAttribute(AttributeName = "valor")]
		public string Valor
		{
			get { return _valor; }
			set { _valor = value; }
		}


	}
}
