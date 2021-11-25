using System;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace MarDevs.OC.Win
{
    public class PanelNav
    {
        private string _key = String.Empty;
        private string _nombre = String.Empty;
		private string _imagen = String.Empty;
        private ArrayList _grupos = new ArrayList();
		private ArrayList _opciones = new ArrayList();

        [XmlAttribute (AttributeName="key")]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        [XmlAttribute (AttributeName = "nombre")]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
		[XmlAttribute(AttributeName = "imagen")]
		public string Imagen
		{
			get { return _imagen; }
			set { _imagen = value; }
		}

        [XmlElement(Type = typeof(GrupoMenu), ElementName = "grupo")]
        public ArrayList Grupos
        {
            get { return _grupos; }
        }

		[XmlElement(Type = typeof(Comando), ElementName = "opcion")]
		public ArrayList Opciones
		{
			get { return _opciones; }
		}
    }
}