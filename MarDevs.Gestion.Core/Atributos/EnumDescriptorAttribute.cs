using System;

namespace MarDevs.Gestion.Core
{
	/// <summary>
	/// Descripción breve de EnumDescriptorAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class EnumDescriptorAttribute: System.Attribute
	{
        public EnumDescriptorAttribute(string descripcion) : this (descripcion, "")
        {}
		public EnumDescriptorAttribute(string descripcion, string imagen)
		{
			_descripcion = descripcion;
			_imagen = imagen;
		}
		private string _descripcion = String.Empty;
		private string _imagen = String.Empty;

		public string Descripcion
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}

		public string Imagen
		{
			get { return _imagen; }
			set { _imagen = value; }
		}
	}
}
