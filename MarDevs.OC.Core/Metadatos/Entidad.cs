using System;
using System.Collections.Generic;
using System.Text;

namespace MarDevs.OC.Core
{
	public class Entidad
	{
		private string _key;
		private string _nombre;
		private string _clase;
		private int _prvCrear;
		private int _prvModificar;
		private int _prvEliminar;
		private int _prvAsignar;

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
		public string Clase
		{
			get { return _clase; }
			set { _clase = value; }
		}
		public int PrvCrear
		{
			get { return _prvCrear; }
			set { _prvCrear = value; }
		}
		public int PrvModificar
		{
			get { return _prvModificar; }
			set { _prvModificar = value; }
		}
		public int PrvEliminar
		{
			get { return _prvEliminar; }
			set { _prvEliminar = value; }
		}
		public int PrvAsignar
		{
			get { return _prvAsignar; }
			set { _prvAsignar = value; }
		}


	
	}
}
