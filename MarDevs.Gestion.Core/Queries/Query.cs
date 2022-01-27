using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MarDevs.Gestion.Core;
using System.Xml;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Core
{
    [Serializable]
	public class Query
    {
        #region VARIABLES PRIVADAS
        private string _key = String.Empty;
        private string _nombre = String.Empty;
        private string _descripcion = String.Empty;
        private Filtro _filtro = new Filtro();
        private string _entidad = String.Empty;
        private bool _esParaBusquedaRapida;
        private string _ordenarPor = String.Empty;
        private string[] _FetchJoins = null;
        private string[] _columnas;
        private bool _esDefaultView = false;

        #endregion

        #region PROPIEDADES

        [XmlAttribute]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        [XmlAttribute]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        [XmlAttribute]
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        [XmlElement(Type = typeof(Filtro), ElementName = "Filtro")]
        public Filtro Filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }
        [XmlAttribute]
        public string Entidad
        {
            get { return _entidad; }
            set { _entidad = value; }
        }
        [XmlAttribute]
        public bool EsDefaultView
        {
            get { return _esDefaultView; }
            set { _esDefaultView = value; }
        }
        [XmlAttribute]
        public bool EsParaBusquedaRapida
        {
            get { return _esParaBusquedaRapida; }
            set { _esParaBusquedaRapida = value; }
        }
        [XmlAttribute]
        public string OrdenarPor
        {
            get { return _ordenarPor; }
            set { _ordenarPor = value; }
        }
        [XmlArrayItem("Entidad", Type = typeof(String))]
        public string[] FetchJoins
        {
            get { return _FetchJoins; }
            set { _FetchJoins = value; }
        }
        [XmlArrayItem("Columna", Type = typeof(String))]
        public string[] Columnas
        {
            get { return _columnas; }
            set { _columnas = value; }
        }
        
        #endregion

		public Query()
		{
		}


    }
}
