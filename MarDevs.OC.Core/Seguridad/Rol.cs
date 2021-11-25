using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MarDevs.OC.Core
{
    [Serializable]
	[ClassDescriptor("MarDevs.OC.Win.FormRol, OC",
    Agregar = true, Eliminar = true,
    PrivilegioAgregar = PRV.ADMINISTRAR_ROL,
    PrivilegioEliminar = PRV.ADMINISTRAR_ROL)]
    public class Rol : Persistente<int?>, IAuditable
    {
        protected Rol()
        {
        }

        #region VARIABLES PRIVADAS

        private string m_Nombre = String.Empty;
        private bool m_Editable = true;
        private IList<RolPrivilegio> m_Privilegios = new List<RolPrivilegio>();
        private IList<Usuario> m_Usuarios = new List<Usuario>();

        #endregion

        #region PROPIEDADES

        [Requerido]
        [GridDescriptor("Nombre", Width = 250)]
        public virtual string Nombre
        {
            get { return m_Nombre; }
            set
            {
                if (m_Editable)
                    m_Nombre = value;
            }
        }
        public virtual bool Editable
        {
            get { return this.m_Editable; }
        }
        [GridDescriptor("Creado El")]
        public virtual DateTime CreadoEl { get; set; }

        [GridDescriptor("Creado Por")]
        public virtual UsuarioLight CreadoPor { get; set; }

        [Browsable(false)]
        public virtual IList<RolPrivilegio> Privilegios
        {
            get
            {
                if (!this._coleccionesInicializadas)
                    this.InicializarColecciones();
                return m_Privilegios;
            }
        }
        [Browsable(false)]
        public virtual IList<Usuario> Usuarios
        {
            get
            {
                if (!_coleccionesInicializadas)
                    this.InicializarColecciones();
                return this.m_Usuarios;
                //return new ReadOnlyCollection<Usuario>(m_Usuarios);
            }
        }

        #endregion

        #region METODOS

        public override void InicializarColecciones()
        {
            using (DL dl = DL.ObtenerSesion())
            {
                dl.InicializarColeccion(this, this.m_Privilegios);
                dl.InicializarColeccion(this, this.m_Usuarios);
                _coleccionesInicializadas = true;
            }
        }
        public override string ToString()
        {
            return m_Nombre;
        }
        public virtual Alcances TienePrivilegio(Privilegio prv)
        {
            foreach (RolPrivilegio item in this.Privilegios)
            {
                if (item.Privilegio.Equals(prv))
                    return item.Alcance;
            }
            return Alcances.Denegado;

        }
        public virtual void AgregarPrivilegio(Privilegio privilegio, Alcances alcance)
        {
            RolPrivilegio prv = new RolPrivilegio();
            prv.Privilegio = privilegio;
            prv.Alcance = alcance;
            this.m_Privilegios.Add(prv);
        }
        public virtual void QuitarPrivilegio(Privilegio privilegio)
        {
            RolPrivilegio rolprv = null;
            foreach (RolPrivilegio item in this.m_Privilegios)
            {
                if (item.Privilegio.Equals(privilegio))
                {
                    rolprv = item;
                    break;
                }
            }
            if (rolprv != null)
            {
                this.m_Privilegios.Remove(rolprv);
            }
        }
        public virtual void QuitarTodosLosPrivilegios()
        {
            this.m_Privilegios.Clear();
        }

        #endregion

        public static Rol Leer(int Id)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                return dl.Leer<Rol>(Id);
            }
        }
        public static Rol Crear()
        {
            Rol rol = new Rol();
            rol.CreadoPor = UsuarioLight.Crear(ConfigBL.ticket.Usuario);
            rol.CreadoEl = ConfigBL.FechaYHoraActual;
            return rol;
        }
        public static IList<Rol> Listar()
        {
            using (DL dl = DL.ObtenerSesion())
            {
                return dl.Listar<Rol>();
            }
        }
        public static IList<Rol> Buscar(string texto)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                return dl.SessionLinq<Rol>().Where(r => r.Nombre.Contains(texto)).ToList(); 
            }
        }
    }
}