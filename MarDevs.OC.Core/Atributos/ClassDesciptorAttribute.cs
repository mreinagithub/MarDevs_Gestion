using System;
using System.Collections.Generic;
using System.Text;

namespace MarDevs.OC.Core
{
	[AttributeUsage(AttributeTargets.All)]
	public class ClassDescriptorAttribute: System.Attribute
	{
		public ClassDescriptorAttribute(string formulario)
		{
			_tipoFormulario = formulario;
		}
		
		private string _tipoFormulario;
		private bool _eliminar = true;
		private bool _agregar = true;

		/// <summary>
		/// Clase del formulario que se utilizará para mostrar instancias de esta clase.
		/// </summary>
		public string TipoFormulario
		{
			get { return _tipoFormulario; }
			set { _tipoFormulario = value; }
		}

		/// <summary>
		/// Indica si se pueden eliminar instancias de esta clase.
		/// </summary>
		public bool Eliminar
		{
			get { return _eliminar; }
			set { _eliminar = value; }
		}

		/// <summary>
		/// Indica si se pueden agregar nuevas instancias de esta clase.
		/// </summary>
		public bool Agregar
		{
			get { return _agregar; }
			set { _agregar = value; }
		}

		private int _privilegioVer;

		public int PrivilegioVer
		{
			get { return _privilegioVer; }
			set { _privilegioVer = value; }
		}
		private int _privilegioModificar;

		public int PrivilegioModificar
		{
			get { return _privilegioModificar; }
			set { _privilegioModificar = value; }
		}
		private int _privilegioAgregar;

		public int PrivilegioAgregar
		{
			get { return _privilegioAgregar; }
			set { _privilegioAgregar = value; }
		}
		private int _privilegioEliminar;

		public int PrivilegioEliminar
		{
			get { return _privilegioEliminar; }
			set { _privilegioEliminar = value; }
		}




	}
}
