using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Core
{
	public class CondicionAccion
    {
        private string _propiedad = String.Empty;
        private OperadorAccion _operador = OperadorAccion.Igual;
		private ArrayList _valores = new ArrayList();
		private string _valor = String.Empty;

        [XmlAttribute]
		public string Propiedad
        {
            get { return _propiedad; }
            set { _propiedad = value; }
        }
		[XmlAttribute]
		public OperadorAccion Operador
        {
            get { return _operador; }
            set { _operador = value; }
        }
		[XmlIgnore]
		public ArrayList Valores
        {
            get { return _valores; }
        }
		[XmlAttribute]
		public string Valor
		{
			get { return _valor; }
			set { _valor = value; }
		}





    }
}
