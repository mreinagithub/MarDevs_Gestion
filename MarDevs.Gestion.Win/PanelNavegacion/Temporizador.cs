using System;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

using MarDevs.Gestion.Core;
using System.Collections.Generic;

namespace MarDevs.Gestion.Win
{
	public class Temporizador
	{
		private string _key;
		private string _nombre;
		private string _descripcion;
		private int _intervalo;
		private IList<Comando> _comandos = new List<Comando>();

		public string Key
		{
			get { return _key; }
			set { _key = value; }
		}
		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
		public int Intervalo	
		{
			get { return _intervalo; }
			set { _intervalo = value; }
		}
		public IList<Comando> Comandos
		{
			get { return _comandos; }
			set { _comandos = value; }
		}

	}
}
