using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Core
{
    public class LayoutColumna
    {
        protected string m_Nombre = String.Empty;
        protected int m_Posicion = 0;
        protected bool m_Visible;
        protected int m_Ancho = 0;
        protected int m_Orden;
        protected bool m_EsGroupBy;

        [XmlAttribute]
        public virtual bool EsGroupBy
        {
            get { return m_EsGroupBy; }
            set { m_EsGroupBy = value; }
        }
        [XmlAttribute]
        public virtual int Orden
        {
            get { return m_Orden; }
            set { m_Orden = value; }
        }
        [XmlAttribute]
        public virtual string Nombre
        {
            get { return m_Nombre; }
            set { m_Nombre = value; }
        }
        [XmlAttribute]
        public virtual int Posicion
        {
            get { return m_Posicion; }
            set { m_Posicion = value; }
        }
        [XmlAttribute]
        public virtual bool Visible
        {
            get { return m_Visible; }
            set { m_Visible = value; }
        }
        [XmlAttribute]
        public virtual int Ancho
        {
            get { return m_Ancho; }
            set { m_Ancho = value; }
        }

		public override string ToString()
		{
			return m_Nombre;
		}


	
    }
}
