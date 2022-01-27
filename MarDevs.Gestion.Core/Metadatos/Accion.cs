using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Core
{
	[Serializable]
	[XmlRoot(ElementName="Accion")]
	public class Accion
    {
		protected Accion()
		{
		}
		public Accion(string entidad, string key, string nombre, bool comenzarGrupoEnPopup, int privilegioRequerido, string formAsociado)
        {
            _entidad = entidad;
            _key = key;
            _nombre = nombre;
            _comenzarGrupoEnPopup = comenzarGrupoEnPopup;
            _privilegioRequerido = privilegioRequerido;
            _formAsociado = formAsociado;
        }
        public Accion(string entidad, string key, string nombre, bool comenzarGrupoEnPopup,String propiedadAEvaluar, int privilegioRequerido, string formAsociado)
            : this(entidad,key,nombre,comenzarGrupoEnPopup,privilegioRequerido,formAsociado)
        {
            _AttrUsuario = propiedadAEvaluar;
        }

		#region VARIABLES DE INSTANCIA
		
		private string _entidad;
		private string _key;
		private string _nombre;
		private string _descripcion;
		private int _privilegioRequerido = PRV.Ninguno;
		private TipoAccion _tipo = TipoAccion.AbrirForm;
		private string _formAsociado;
		private object _paramForm;
		private bool _comenzarGrupoEnPopup;
        private string _rutaGrupoEnPopup = null;
        private string _AttrUsuario;
		private bool _validaParaMultiplesInstancias = true;
		private string _imagen = String.Empty;
		private List<CondicionAccion> _condiciones = new List<CondicionAccion>();
		private List<ParametroAccion> _parametros = new List<ParametroAccion>();

		#endregion

        #region Propiedades

        public String AttrUsuario
        {
            get { return _AttrUsuario; }
            set { _AttrUsuario = value; }
        }

		[XmlAttribute]
		public string Entidad
        {
            get { return _entidad; }
            set { _entidad = value; }
        }
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
		[XmlAttribute]
		public int PrivilegioRequerido
        {
            get { return _privilegioRequerido; }
            set { _privilegioRequerido = value; }
        }
		[XmlAttribute]
		public TipoAccion Tipo
		{
			get { return _tipo; }
			set { _tipo = value; }
		}
		[XmlAttribute]
		public string FormAsociado
        {
            get { return _formAsociado; }
            set { _formAsociado = value; }
        }
		[XmlElement]
		public object ParamForm
        {
            get { return _paramForm; }
            set { _paramForm = value; }
        }
		[XmlAttribute]
		public string MetodoMasivo { get; set; }
		[XmlAttribute]
		public bool ComenzarGrupoEnPopup
        {
            get { return _comenzarGrupoEnPopup; }
            set { _comenzarGrupoEnPopup = value; }
        }
		[XmlAttribute]
        public string RutaGrupoEnPopup
		{
            get { return _rutaGrupoEnPopup; }
            set { _rutaGrupoEnPopup = value; }
		}
		[XmlAttribute]
		public bool ValidaParaMultiplesInstancias
		{
			get { return _validaParaMultiplesInstancias; }
			set { _validaParaMultiplesInstancias = value; }
		}
		[XmlAttribute]
		public string Imagen
		{
			get { return _imagen; }
			set { _imagen = value; }
		}
		//[XmlElement(Type = typeof(CondicionAccion), ElementName = "Condicion")]
		[XmlArray("Condiciones")]
		[XmlArrayItem("Condicion", typeof(CondicionAccion))]
		public List<CondicionAccion> Condiciones
        {
            get { return _condiciones; }
            set { _condiciones = value; }
        }
		[XmlArray("Parametros")]
		[XmlArrayItem("Param", typeof(ParametroAccion))]
		public List<ParametroAccion> Parametros
		{
			get { return _parametros; }
			set { _parametros = value; }
		}

        #endregion Propiedades

        public void AgregarCondicionSimple(string propiedad, OperadorAccion operador, object valor)
        {
            CondicionAccion cond = new CondicionAccion();
            cond.Propiedad = propiedad;
            cond.Operador = operador;
            cond.Valores.Add(valor);
			cond.Valor = valor != null ? valor.ToString() : "null";
            this.Condiciones.Add(cond);
        }
		public static Accion Crear(string entidad, string key, string nombre, bool comenzarGrupoEnPopup, int privilegioRequerido, string formAsociado)
		{
			Accion accion = new Accion(entidad, key, nombre, comenzarGrupoEnPopup, privilegioRequerido, formAsociado);
			return accion;
		}
		public static Accion Crear(string entidad, string key, string nombre, bool comenzarGrupoEnPopup, int privilegioRequerido, string formAsociado, string propiedad, OperadorAccion operador, object valor)
		{
			Accion accion = new Accion(entidad, key, nombre, comenzarGrupoEnPopup, privilegioRequerido, formAsociado);
			accion.AgregarCondicionSimple(propiedad, operador, valor);
			return accion;
		}
        public static Accion Crear(string entidad, string key, string nombre, bool comenzarGrupoEnPopup,String propiedadAEvaluar, int privilegioRequerido, string formAsociado, string propiedad, OperadorAccion operador, object valor)
        {
            Accion accion = new Accion(entidad, key, nombre, comenzarGrupoEnPopup, propiedadAEvaluar, privilegioRequerido, formAsociado);
            accion.AgregarCondicionSimple(propiedad, operador, valor);
            return accion;
        }
	}
}
