using System;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Win
{
    public class GrupoMenu
    {
        private string _key = String.Empty;
        private string _nombre = String.Empty;
		private string _imagen = String.Empty;
		private bool _bold = false;
		private bool _expandido;
		private ArrayList _grupos = new ArrayList();
		private ArrayList _opciones = new ArrayList();

		[XmlAttribute(AttributeName = "key")]
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
		[XmlAttribute (AttributeName="bold")]
		public bool Bold
		{
			get { return _bold; }
			set { _bold = value; }
		}
		[XmlAttribute(AttributeName = "expandido")]
		public bool Expandido
		{
			get { return _expandido; }
			set { _expandido = value; }
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

		public static GrupoMenu ObtenerGrupo(GrupoMenu grupoPadre, string RutaCompleta)
		{
			return GrupoMenu.ObtenerGrupo(grupoPadre, RutaCompleta, false);
		}
		public static GrupoMenu ObtenerGrupo(GrupoMenu grupoPadre, string RutaCompleta, bool CrearSiNoExiste)
		{			
			GrupoMenu grupoHijo = new GrupoMenu();
			String[] path = RutaCompleta.Split('\\');
			string carpetaKey = grupoPadre.Key;
			foreach (string carpetaNombre in path)
			{
				carpetaKey += "_" + carpetaNombre.Replace(" ", "").Trim();
				bool existe = false;
				foreach (GrupoMenu subGrupo in grupoPadre.Grupos)
				{

					if (subGrupo.Key == carpetaKey)
					{
						existe = true;
						grupoHijo = subGrupo;
						break;
					}
				}
				if (!existe)
				{
					if (CrearSiNoExiste)
					{
						grupoHijo = new GrupoMenu();
						grupoHijo.Key = carpetaKey;
						grupoHijo.Nombre = carpetaNombre.Trim();
						grupoHijo.Imagen = "ImagenCarpeta";
					}
					else
					{
						return null;
					}

					grupoPadre.Grupos.Add(grupoHijo);
				}
				grupoPadre = grupoHijo;
			}
			return grupoHijo;
		}
    }
}