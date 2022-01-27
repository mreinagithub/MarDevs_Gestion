using System;
using System.Collections;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Core
{
    public class LayoutGrilla
    {
        protected bool m_PanelAgrupacion;
        protected LayoutColumna[] m_Columnas;
        protected string[] m_ColumnasOrdenadas;

        [XmlAttribute]
        public virtual bool PanelAgrupacion
        {
            get { return m_PanelAgrupacion; }
            set { m_PanelAgrupacion = value; }
        }
        public virtual LayoutColumna[] Columnas
        {
            get { return m_Columnas; }
            set { m_Columnas = value; }
        }
        public string[] ColumnasOrdenadas
        {
            get { return m_ColumnasOrdenadas; }
            set { m_ColumnasOrdenadas = value; }
        }

    }
}
