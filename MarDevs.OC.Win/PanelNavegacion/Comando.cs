using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using MarDevs.OC.Core;
using System.Linq;

namespace MarDevs.OC.Win
{
    public enum TipoComando
    {
        AbrirMDI = 1,
        AbrirForm = 2,
        AbrirModal = 3,
        Exec = 4,
        Metodo =5
    }
	public class Comando
	{
		private string _key;
		private string _nombre;
		private string _imagen;
        private TipoComando _accion = TipoComando.AbrirMDI;
		private string _target;
		private ArrayList _parametros = new ArrayList();
		private int _privilegio;
		private Alcances _alcance = Alcances.Total;
        private String _descripcion;

		[XmlAttribute(AttributeName = "descripcion")]
        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

		[XmlAttribute( AttributeName="key")]
		public string Key
		{
			get { return _key; }
			set { _key = value; }
		}
		[XmlAttribute(AttributeName = "nombre")]
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
		[XmlAttribute(AttributeName = "accion")]
        public TipoComando Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }
		[XmlAttribute(AttributeName = "target")]
		public string Target
		{
			get { return _target; }
			set { _target = value; }
		}
		[XmlAttribute(AttributeName = "privilegio")]
		public int Privilegio
		{
			get { return _privilegio; }
			set { _privilegio = value; }
		}
		[XmlAttribute(AttributeName = "alcance")]
		public Alcances Alcance
		{
			get { return _alcance; }
			set { _alcance = value; }
		}
		[XmlElement(Type = typeof(ParametroComando), ElementName = "parametro")]
		public ArrayList Parametros
		{
			get { return _parametros; }
		}
        public static object[] ConvertirParametros(IList parametros)
        {
            Type tipoParam = null;
            ArrayList resultado = new ArrayList();
            object valor = null;
            foreach (ParametroComando param in parametros)
            {
				//Tipos básicos
                tipoParam = Type.GetType(param.Tipo);
				//Tipos del ensamblado				
				tipoParam = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
							let type = assembly.GetType(param.Tipo)
							where type != null				
							select type).FirstOrDefault();

				if (tipoParam == null)
					throw new ExcepcionNegocios("No se encontró el tipo de parámetro a inicializar.");

                if (tipoParam.IsEnum)
                {
                    valor = Enum.Parse(tipoParam, param.Valor, true);
                }
                else if (tipoParam.Equals(typeof(Guid)))
                {
                    valor = new Guid(param.Valor);
                }
                else
                {
                    valor = Convert.ChangeType(param.Valor, tipoParam);
                }
                resultado.Add(valor);
            }
            return resultado.ToArray();
        }
	}
}
