using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Core
{
    [Serializable]
	public class Condicion
    {
        private string _propiedad;
        private Operador _operador;
        private object[] _valores = null;

		[XmlAttribute]
		public string Propiedad
        {
            get { return _propiedad; }
            set { _propiedad = value; }
        }
        [XmlIgnore]
		public Operador Operador
        {
            get { return _operador; }
            set { _operador = value; }
        }
		[XmlArray("Valores")]
		[XmlElement(DataType = "string", Type=typeof(string))]
		[XmlElement(DataType = "int", Type = typeof(int))]
		public object[] Valores
        {
            get { return _valores; }
			set { _valores = value; }
        }

    }
}
