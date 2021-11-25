using System;
using System.Collections.Generic;

namespace MarDevs.OC.Core
{
	[Serializable]
	public class UsuarioLight : NegocioBase
	{
		#region PROPIEDADES

        public virtual int? Id { get; private set; }
        public virtual string Logon { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string NombreCompleto
        {
            get { return this.Apellido + ", " + this.Nombre; }
        }        

		#endregion

		public override string ToString()
		{
			switch (Usuario.ModoToString)
			{
				case UsuarioModoToString.Logon:
					return Logon;
				case UsuarioModoToString.ApeNom:
					return String.Format("{0} {1}", Apellido, Nombre);
				case UsuarioModoToString.NomApe:
					return String.Format("{0} {1}", Nombre, Apellido);
				default:
                    return Logon;
			}
		}
		public override bool Equals(object obj)
		{
			UsuarioLight otro = obj as UsuarioLight;
			if (otro == null) { return false; }
			return (Id != null && Id.Equals(otro.Id));
		}
		public static UsuarioLight Crear(Usuario usuario)
		{
			if (usuario == null)
				return null;
			UsuarioLight ul = new UsuarioLight();
			ul.Id = usuario.Id.Value;
			ul.Logon = usuario.Logon;
			ul.Apellido = usuario.Apellido;
			ul.Nombre = usuario.Nombre;			
			return ul;
		}
		public static IList<UsuarioLight> Listar()
		{
			using (DL dl = DL.ObtenerSesion())
			{
				return dl.Listar<UsuarioLight>();
			}
		}
		public static UsuarioLight Leer(int id)
		{
			using (DL dl = DL.ObtenerSesion())
			{
				UsuarioLight obj = dl.Leer(typeof(UsuarioLight), id) as UsuarioLight;
				return obj;
			}
		}
	}
}
