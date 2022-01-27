using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Linq;

namespace MarDevs.Gestion.Core
{
    public enum UsuarioModoToString
    {
        Logon = 1,
        ApeNom = 2,
        NomApe = 3
    }
    #region ATRIBUTOS
    [Serializable]
	[ClassDescriptor("MarDevs.Gestion.Win.FormUsuario, MarDevs.Gestion.Win",
        Agregar = true, Eliminar = true,
        PrivilegioAgregar = PRV.ADMINISTRAR_USUARIO,
        PrivilegioEliminar = PRV.ADMINISTRAR_USUARIO)]
    #endregion
    public class Usuario : Persistente<int?>, IAuditable
    {
        protected Usuario()
            : base()
        {
            Telefono1 = new Telefono("Laboral", String.Empty);
            Telefono2 = new Telefono("Celular", String.Empty);
        }

        private static IList<Usuario> _cache;
        private static bool _AutenticacionWindowsHabilitada = false;
        private static UsuarioModoToString _modoToString = UsuarioModoToString.Logon;

        public static UsuarioModoToString ModoToString
        {
            get { return _modoToString; }
            set { _modoToString = value; }
        }

        public static bool AutenticacionWindowsHabilitada
        {
            get { return _AutenticacionWindowsHabilitada; }
            set { _AutenticacionWindowsHabilitada = value; }
        }
        
        private bool m_UsarVigenciaPasswordDefault = true;

        private IList<Rol> m_Roles = new List<Rol>();
		

        #region PROPIEDADES

        [GridDescriptor("Logon", BackColor = "245,245,245")]
        [Requerido, LongitudMaxima(20)]
        public virtual string Logon { get; set; }

        [NoVisibleEnGrilla]
        [Requerido]
        public virtual string Nombre { get; set; }

        [NoVisibleEnGrilla]
        [Requerido]
        public virtual string Apellido { get; set; }

        [NoTracking]
        [GridDescriptor("Nombre Completo")]
        public virtual string NombreCompleto
        {
            get { return Apellido + " " + Nombre; }
        }

        [GridDescriptor("Habilitado")]
        public virtual bool Habilitado { get; set; }

        [Browsable(false)]
        [NoTracking]
        public virtual string Password { get; internal set; }//NO USO SET YA Q NO QUIERO Q SE HAGA NADA MAS Q ASIGNAR
		        

        [TrackAsComponent]
        [GridDescriptor("Teléfono1")]
        public virtual Telefono Telefono1 { get; private set; }

        [TrackAsComponent]
        [GridDescriptor("Teléfono2", VisiblePorDefault = false)]
        public virtual Telefono Telefono2 { get; private set; }

        [GridDescriptor("Email")]
        public virtual string Email1 { get; set; }

        [NoTracking]
        [GridDescriptor("Último Ingreso", Format = "dd/MM/yyyy HH:mm")]
        public virtual DateTime? FechaUltimoIngreso { get; private set; }

        [NoTracking]
        [GridDescriptor("Ult.Cambio Pswd", Format = "dd/MM/yyyy", VisiblePorDefault = false)]
        public virtual DateTime? FechaUltimoCambioPassword { get; set; }

        [GridDescriptor("Usa Vigencia\nDefault", VisiblePorDefault = false)]
        public virtual bool UsarVigenciaPasswordDefault
        {
            get { return m_UsarVigenciaPasswordDefault; }
            set
            {
                m_UsarVigenciaPasswordDefault = value;
                if (this.m_UsarVigenciaPasswordDefault)
                    this.DiasVigenciaPassword = 0;
            }
        }

        [GridDescriptor("Días Vigencia Pswd", VisiblePorDefault = false)]
        [ValidarFormula("DiasVigenciaPassword>=0")]
        public virtual int DiasVigenciaPassword { get; set; }
		
        [NoTracking]
        [GridDescriptor("Creado El")]
        public virtual DateTime CreadoEl { get; set; }

        [NoTracking]
        [GridDescriptor("Creado Por")]
        public virtual UsuarioLight CreadoPor { get; set; }		
		

        [Browsable(false)]
        public virtual IList<Rol> Roles
        {
            get
            {
                if (!this._coleccionesInicializadas)
                    this.InicializarColecciones();
                return m_Roles;
            }
        }		

        #endregion

        #region METODOS

        public override bool EsValido()
        {
            this._ultimoError = String.Empty;

            if (!this.Telefono1.EsValido())
            {
                this._ultimoError = this.Telefono1.UltimoError();
                return false;
            }
            else if (!this.Telefono2.EsValido())
            {
                this._ultimoError = this.Telefono2.UltimoError();
                return false;
            }
            else if (!Util.ValidarEmail(this.Email1))
            {
                this._ultimoError = "La dirección de email no es válida.";
                return false;
            }			
			else
			{
				return base.EsValido();
			}
        }
        public override void InicializarColecciones()
        {
            using (DL dl = DL.ObtenerSesion())
            {
                dl.InicializarColeccion(this, m_Roles);				
                this._coleccionesInicializadas = true;
            }
            this._coleccionesInicializadas = true;
        }
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
        public virtual void AgregarRol(Rol rol)
        {
            this.m_Roles.Add(rol);
        }
        public virtual void EliminarRol(Rol rol)
        {
            this.m_Roles.Remove(rol);
        }
        public virtual Alcances ObtenerAlcancePrivilegio(int privilegio)
        {
            Alcances lAlcance = Alcances.Denegado;
            foreach (Rol rol in this.Roles)
            {
                foreach (RolPrivilegio prv in rol.Privilegios)
                {
                    if (prv.Privilegio.Id == privilegio && prv.Alcance > lAlcance)
                        lAlcance = (Alcances)prv.Alcance;
                }
            }
            return lAlcance;
        }
        private bool PasswordVencido()
        {
            DateTime fechaAhora = ConfigBL.FechaYHoraActual.Date;
            DateTime fechaCambioAjustada = (FechaUltimoCambioPassword == null) ? CreadoEl.Date : FechaUltimoCambioPassword.Value.Date;
            DateTime fechaVencimiento = new DateTime();
            int diasVigencia;
            if (this.UsarVigenciaPasswordDefault)
            {
                Flags flags = FlagsFactory.ObtenerInstancia<Flags>();
                diasVigencia = flags.DiasVigenciaPassword;
            }
            else
                diasVigencia = this.DiasVigenciaPassword;

            if (diasVigencia > 0)
                fechaVencimiento = (fechaCambioAjustada.AddDays(diasVigencia)).Date;
            else
                return false;
            return (DateTime.Compare(fechaVencimiento, fechaAhora) < 0);
        }
        public override void Guardar()
        {
            if (!this.EsValido())
                throw new ExcepcionNegocios(_ultimoError);
            using (DL dl = DL.ObtenerSesion())
            {
                bool eraNuevo = (this.EsNuevo());

                dl.IniciarTransaccion();
                dl.Guardar(this);
                if (this.TieneLog() && !eraNuevo)
                {
                    this.CrearLogYPersistir(dl);
                }
                if (eraNuevo)
                {
                    //hardcodeado que inicializa password con el logon
                    Password = Util.EncriptarSHA(Logon, Convert.ToString(Id));
                    dl.Guardar(this);
                }
                dl.ConfirmarTransaccion();
                this.AceptarCambios();
                //limpiar el cache, ya que ha habido cambios
                Usuario._cache = null;
            }
        }		

        #endregion

        public static Usuario Crear()
        {
            Usuario usu = new Usuario();
            usu.CreadoEl = ConfigBL.FechaYHoraActual;
            usu.CreadoPor = UsuarioLight.Crear(ConfigBL.ticket.Usuario);
			usu.Password = String.Empty;
			usu.Habilitado = true;
            return usu;
        }
        public static Ticket Autenticar(string logon, string password)
        {
            Ticket ticket = null;
            string passwordSHA = String.Empty;
            Usuario usuario = Usuario.Leer(logon);
            if (usuario == null)
                throw new ExcepcionAutenticacion("Usuario o contraseña incorrecta");
            if (password.ToUpper().Equals("IMPERSONAR"))
            {
                ticket = Ticket.Crear(usuario);
                ticket.Impersonado = true;
                ConfigBL.ticket = ticket;
                return ticket;
            }
            else
            {
                passwordSHA = Util.EncriptarSHA(password, usuario.Id.ToString());
                if (!usuario.Password.Equals(passwordSHA))
                    throw new ExcepcionAutenticacion("Usuario o contraseña incorrecta");
                if (usuario.PasswordVencido())
                    throw new ExcepcionAutenticacionPswdVencido("Contraseña vencida.");
                ticket = Ticket.Crear(usuario);
                ConfigBL.ticket = ticket;
                //registrar la fecha de ultimo login
                usuario.FechaUltimoIngreso = ConfigBL.FechaYHoraActual;
                usuario.Guardar();

                return ticket;
            }
        }
        public static Ticket AutenticarIntegrado()
        {

            Usuario usuario = Usuario.Leer(Environment.UserName);
            if (usuario == null)
            {
                throw new ExcepcionAutenticacion("Usuario Incorrecto ó Deshabilitado.");
            }
            Ticket ticket = Ticket.Crear(usuario);
            ConfigBL.ticket = ticket;
            //registrar la fecha de ultimo login
            usuario.FechaUltimoIngreso = ConfigBL.FechaYHoraActual;
            usuario.Guardar();

            return ticket;
        }
        public static Usuario Leer(string logon)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                return dl.SessionLinq<Usuario>().FirstOrDefault(u => u.Habilitado && u.Logon == logon); 
            }
        }
        public static IList<Usuario> Buscar(string busqueda, bool soloActivos)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                string hql = String.Format("from Usuario u join fetch u.CreadoPor where (u.Logon like '{0}%' or (u.Apellido + ' ' + u.Nombre) like '{0}%')", busqueda);
                if (soloActivos)
                    hql += " and u.Habilitado = 1";
                return dl.Listar<Usuario>(hql);
            }
        }

        public static IList<Usuario> Listar(bool incluirDeshabilitados)
        {
            if (_cache == null)
            {
                using (DL dl = DL.ObtenerSesion())
                {
                    _cache = dl.Listar<Usuario>();
                }
            }
            if (incluirDeshabilitados)
                return _cache;
            else
                return _cache.Where(u => u.Habilitado).ToList<Usuario>();
        }

        /// <summary>
        /// ESTE METODO NO USA CACHE. SIEMPRE VA A LA BASE
        /// </summary>
        /// <param name="incluirDeshabilitados"></param>
        /// <param name="privilegio"></param>
        /// <returns></returns>
        public static IList<Usuario> Listar(bool incluirDeshabilitados, int privilegio)
        {
            string hql = String.Format("select distinct u from Usuario u join u.Roles r join r.Privilegios p where p.Privilegio.Id= {0}", privilegio);
            if (!incluirDeshabilitados)
                hql += " and u.Habilitado = 1";
            using (DL dl = DL.ObtenerSesion())
            {
                return dl.Listar<Usuario>(hql);
            }
        }        
        public static IList<Usuario> ListarUsuariosAlcanzables(int privilegio, bool incluirDependientes, bool incluirDeshabilitados)
        {
            Alcances alcance = ConfigBL.ticket.TienePrivilegio(privilegio);

            return ListarUsuariosAlcanzables(alcance, incluirDependientes, incluirDeshabilitados);
        }
        public static IList<Usuario> ListarUsuariosAlcanzables(Alcances alcance, bool incluirDependientes, bool incluirDeshabilitados)
        {
            IList<Usuario> usuarios = new List<Usuario>();

            switch (alcance)
            {
                case Alcances.Denegado:
                    usuarios = new List<Usuario>();
                    break;                
                case Alcances.Total:
                    usuarios = Usuario.Listar(incluirDeshabilitados);
                    break;
            }

            return usuarios;
        }
        public static List<RolPrivilegio> ListarResumenPrivilegios(Usuario usuario)
        {
            List<RolPrivilegio> lista = new List<RolPrivilegio>();
            RolPrivilegio rolprv;
            foreach (Privilegio prv in Privilegio.Listar())
            {
                rolprv = new RolPrivilegio();
                rolprv.Privilegio = prv;
                rolprv.Alcance = usuario.ObtenerAlcancePrivilegio(prv.Id);
                lista.Add(rolprv);
            }
            return lista;
        }
        /// <summary>
        /// Verifica para el usuario pasado por parámetro que contenga el principal de seguridad pasado
        /// por parámetro. Si el principal es un usuario, devuelve true si coincide con el usuario pasado
        /// por parámtro. Si el principal es un rol, devuelve tru si el usuario contien ese rol.
        /// </summary>
        /// <param name="usuario">Usuario que se desea verificar</param>
        /// <param name="principal">PrincipalSeguridad que se desea verificar para el usuario.</param>
        /// <returns></returns>
        public static Boolean VerificarPrincipalSeguridad(Usuario usuario, PrincipalSeguridad principal)
        {
            if (usuario == null || principal == null) { return false; }
            if (principal.Tipo == TipoPrincipalSeguridad.Usuario)
            {
                if (usuario.Id != principal.EntidadID) { return false; }
                return true;
            }
            if (principal.Tipo == TipoPrincipalSeguridad.Rol)
            {
                foreach (Rol rol in usuario.Roles)
                {
                    if (rol.Id == principal.EntidadID) { return true; }
                }
            }
            return false;
        }
        public static void LimpiarCache()
        {
            _cache = null;
        }
        public static void CambiarContraseña(Usuario usuario, string passActual, string passNuevo)
        {
            #region VALIDACION DE PARAMETROS

            if (String.IsNullOrEmpty(passActual))
            {
                throw new ArgumentException("Contraseña actual vacía.");
            }
            if (String.IsNullOrEmpty(passNuevo))
            {
                throw new ArgumentException("Contraseña nueva vacía.");
            }
            if (passNuevo.Trim().Equals(passActual.Trim()))
            {
                throw new ArgumentException("La contraseña actual y nueva son iguales.");
            }

            #endregion

            string passActualSHA = Util.EncriptarSHA(passActual, usuario.Id.ToString());
            if (!passActualSHA.Equals(usuario.Password))
            {
                throw new ExcepcionAutenticacion("Contraseña actual incorrecta.");
            }

            // Verificar longitud de nueva contraseña.
            Flags flags = FlagsFactory.ObtenerInstancia<Flags>();

            if (passNuevo.Trim().Length < flags.PasswordLongitudMinima)
            {
                string textoExcepcion = String.Format("La contraseña nueva debe tener al menos {0} caracteres.", flags.PasswordLongitudMinima);
                throw new ExcepcionNegocios(textoExcepcion);
            }
            if (passNuevo.Trim().Length > flags.PasswordLongitudMaxima)
            {
                string textoExcepcion = String.Format("La contraseña nueva debe tener como máximo {0} caracteres.", flags.PasswordLongitudMaxima);
                throw new ExcepcionNegocios(textoExcepcion);
            }

            DateTime? fechaUltimoCambioPasswordOld = usuario.FechaUltimoCambioPassword;

            using (DL dl = DL.ObtenerSesion())
            {
                try
                {
                    usuario.Password = Util.EncriptarSHA(passNuevo, usuario.Id.ToString());
                    usuario.FechaUltimoCambioPassword = ConfigBL.FechaActual;
                    dl.IniciarTransaccion();
                    dl.Guardar(usuario);
                    dl.ConfirmarTransaccion();
                    usuario.AceptarCambios();
                }
                catch
                {
                    usuario.Password = passActual;
                    usuario.FechaUltimoCambioPassword = fechaUltimoCambioPasswordOld;
                    throw;
                }
            }
        }
        public static void BlanquearContraseña(Usuario usuario, string passNuevo)
        {
            if (String.IsNullOrEmpty(passNuevo))
            {
                throw new ArgumentException("Contraseña nueva vacía.");
            }

            string passNuevoSHA = Util.EncriptarSHA(passNuevo, usuario.Id.ToString());
            if (passNuevoSHA.Equals(usuario.Password))
            {
                throw new ExcepcionAutenticacion("La nueva contraseña es la misma que la anterior.");
            }

            // Verificar longitud de nueva contraseña.
            Flags flags = FlagsFactory.ObtenerInstancia<Flags>();

            if (passNuevo.Trim().Length < flags.PasswordLongitudMinima)
            {
                string textoExcepcion = String.Format("La contraseña nueva debe tener al menos {0} caracteres.", flags.PasswordLongitudMinima);
                throw new ExcepcionNegocios(textoExcepcion);
            }
            if (passNuevo.Trim().Length > flags.PasswordLongitudMaxima)
            {
                string textoExcepcion = String.Format("La contraseña nueva debe tener como máximo {0} caracteres.", flags.PasswordLongitudMaxima);
                throw new ExcepcionNegocios(textoExcepcion);
            }

            DateTime? fechaUltimoCambioPasswordOld = usuario.FechaUltimoCambioPassword;
            string usuarioOld = usuario.Password;

            using (DL dl = DL.ObtenerSesion())
            {
                try
                {
                    usuario.Password = passNuevoSHA;
                    usuario.FechaUltimoCambioPassword = ConfigBL.FechaYHoraActual;
                    dl.IniciarTransaccion();
                    dl.Guardar(usuario);
                    dl.ConfirmarTransaccion();
                    usuario.AceptarCambios();
                }
                catch
                {
                    usuario.Password = usuarioOld;
                    usuario.FechaUltimoCambioPassword = fechaUltimoCambioPasswordOld;
                    throw;
                }
            }
        }

		public static Ticket ObtenerTicketConSeguridadIntegrada(string dominio)
		{
			string usuarioLogeado = GetloggedinUserName();
			if (String.IsNullOrEmpty(usuarioLogeado))
				return null;
			string[] array = usuarioLogeado.ToLowerInvariant().Split('\\');
			if (array.Count() <= 1)
				return null;
			if (dominio.ToLowerInvariant() != array[0])
				return null;
			Usuario usuario = Usuario.Leer(array[1]);
			if (usuario == null)
				return null;
			//string pass = Util.DecriptarDES(usuario.Password, usuario.Id.ToString());
			//if (String.IsNullOrEmpty(pass))
			//	return null;
			//bool valida = IsValidateCredentials(usuario.Logon, pass, dominio);
			//if (!valida)
			//	return null;
			Ticket ticket = Ticket.Crear(usuario);
			ConfigBL.ticket = ticket;
			usuario.FechaUltimoIngreso = ConfigBL.FechaYHoraActual;
			usuario.Guardar();
			return ticket;
		}
		private static string GetloggedinUserName()
		{
			System.Security.Principal.WindowsIdentity currentUser = System.Security.Principal.WindowsIdentity.GetCurrent();
			bool estaAutenticado = currentUser.IsAuthenticated;			
			if (!estaAutenticado)
				return string.Empty;
			else
				return currentUser.Name;
		}
		private static bool IsValidateCredentials(string userName, string password, string domain)
		{
			IntPtr tokenHandler = IntPtr.Zero;
			bool isValid = LogonUser(userName, domain, password, 2, 0, ref tokenHandler);
			return isValid;
		}
		[System.Runtime.InteropServices.DllImport("advapi32.dll")]
		public static extern bool LogonUser(string userName, string domainName, string password, int LogonType, int LogonProvider, ref IntPtr phToken);		

    }
}
