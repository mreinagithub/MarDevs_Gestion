using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarDevs.OC.Core
{
	public class Ticket
	{
		private Ticket()
		{}

		private Usuario _Usuario;
		private DateTime _FechaCreacion;		
		private bool _Impersonado = false;
		private Dictionary<int, Alcances> _privilegios = null;

		public int UsuarioID
		{	
			get { return _Usuario.Id.Value; }
		}		
		public string UsuarioLogon
		{
			get { return this._Usuario.Logon; }
		}
		public string UsuarioPass
		{
			get { return this._Usuario.Password; }
		}
		public DateTime FechaCreacion
		{
			get { return _FechaCreacion; }
			set { _FechaCreacion = value; }
		}
		public Usuario Usuario
		{
			get {return _Usuario;}
		}
		public bool Impersonado
		{
			get { return _Impersonado; }
			set { _Impersonado = value; }
		}		
        public IList<Rol> Roles
		{
			get { return _Usuario.Roles; }
		}
        public static Ticket Crear(Usuario usuario)
        {
            Ticket tk = new Ticket();
            tk._Usuario = usuario;
            tk.FechaCreacion = DateTime.Now;            
            return tk;
        }
		public Alcances TienePrivilegio(int privilegio)
		{
			if (_privilegios == null)
				InicializarPrivilegios();
			if (_privilegios.ContainsKey(privilegio))
				return _privilegios[privilegio];
			else
				return Alcances.Denegado;
		}
		public bool VerificarPrivilegio(int privilegio)
		{
			return (TienePrivilegio(privilegio) > Alcances.Denegado);
		}
		private void InicializarPrivilegios()
		{
			_privilegios = new Dictionary<int, Alcances>();

            string hql = String.Format("select p.Privilegio.Id, MAX(p.Alcance) from Usuario u join u.Roles r join r.Privilegios p where u.Id = {0} group by p.Privilegio.Id order by p.Privilegio.Id", _Usuario.Id);
            Dictionary<string, object> criterios = new Dictionary<string, object>();
			IList lista;
			using (DL dl = DL.ObtenerSesion())
			{
				lista = dl.Listar(hql);
			}

			foreach (object[] obj in lista)
				_privilegios.Add((int)obj[0], (Alcances)obj[1]);
		}
		public Boolean VerificarPrincipalSeguridad(PrincipalSeguridad principal)
		{
			return Usuario.VerificarPrincipalSeguridad(ConfigBL.ticket.Usuario, principal);
		}
	}
}
