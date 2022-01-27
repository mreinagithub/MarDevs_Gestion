using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarDevs.Gestion.Core
{
    public delegate void MarcaSeguimientoModificadaEventHandler(object sender, EventArgs e);

    [Serializable]
    public class MarcaSeguimiento : Persistente<int?>, IAuditable
    {
        [NoVisibleEnGrilla]
        public virtual string EntidadTipo { get; set;}

        [NoVisibleEnGrilla]
        public virtual string EntidadId { get; set; }
        [GridDescriptor("S")]
        public virtual ImagenSeguimiento Imagen { get; set; }

        [GridDescriptor("Descripción", Width = 200)]
        public virtual string EntidadDescripcion { get; set; }

        [GridDescriptor("Seguimiento", Format = "dd/MM/yyyy")]
        public virtual DateTime FechaSeguimiento { get; set; }

        public virtual string Comentarios { get; set; }

        [NoVisibleEnGrilla]
        public virtual DateTime CreadoEl { get; set; }

        [NoVisibleEnGrilla]
        public virtual UsuarioLight CreadoPor { get; set; }

        [NoVisibleEnGrilla]
        public virtual bool Publica { get; set; }

        [NoVisibleEnGrilla]
        public virtual bool Aviso { get; set; }

        [NoVisibleEnGrilla]
        public virtual DateTime? FechaAviso { get; set; }

        public override string ToString()
        {
            return Comentarios;
        }
        public override bool TieneLog()
        {
            return false;
        }

        public static MarcaSeguimiento Crear(IPersistente entidad)
        {
            if (entidad == null || entidad.EsNuevo() || entidad.ObtenerID() == null)
                return null;
            return new MarcaSeguimiento
            {
                EntidadTipo = entidad.ObtenerTipo(),
                EntidadId = entidad.ObtenerID().ToString(),
                CreadoPor = UsuarioLight.Crear(ConfigBL.ticket.Usuario),
                CreadoEl = ConfigBL.FechaYHoraActual
            };
        }
        public static IList<MarcaSeguimiento> ListarPorEntidad(IPersistente entidad)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                return dl.SessionLinq<MarcaSeguimiento>()
                        .Where(ms => ms.EntidadTipo == entidad.ObtenerTipo()
                            && ms.EntidadId == entidad.ObtenerID().ToString())
                        .ToList<MarcaSeguimiento>(); 
            }
        }
        public static IList<MarcaSeguimiento> BuscarPorEntidadyUsuario(IPersistente entidad)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                return dl.SessionLinq<MarcaSeguimiento>()
                        .Where(ms => ms.EntidadTipo == entidad.ObtenerTipo()
                            && ms.EntidadId == entidad.ObtenerID().ToString()
                            && ms.CreadoPor.Id == ConfigBL.ticket.UsuarioID)
                        .ToList<MarcaSeguimiento>(); 
            }
        }
        public static Dictionary<string, MarcaSeguimiento> BuscarPorTipoEntidad(Type tipoEntidad)
        {
            Dictionary<string, MarcaSeguimiento> resultado = new Dictionary<string, MarcaSeguimiento>();
            using (DL dl = DL.ObtenerSesion())
            {
                string hql = String.Format("from MarcaSeguimiento m where m.EntidadTipo= '{0}' and m.CreadoPor.Id= {1}", tipoEntidad.Name, ConfigBL.ticket.Usuario.Id);
                dl.Listar<MarcaSeguimiento>(hql).ToList().ForEach(marca =>
                {
                    if (!resultado.ContainsKey(marca.EntidadId))
                        resultado.Add(marca.EntidadId, marca);
                });
                return resultado;
            }
        }
        public static void CrearMarcasDesdeEntidades(IList listaDeEntidades, DateTime fecha, ImagenSeguimiento imagen, string comentarios, bool aviso, DateTime? fechaAviso)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                dl.IniciarTransaccion();
                foreach (IPersistente entidad in listaDeEntidades)
                {
                    //solo creo si son entidades relacionadas, porque en la lista pueden venir directamente objetos MarcaSeguimiento.
                    MarcaSeguimiento marca = MarcaSeguimiento.Crear(entidad);
                    marca.FechaSeguimiento = fecha;
                    marca.Imagen = imagen;
                    marca.Comentarios = comentarios;
                    marca.Aviso = aviso;
                    marca.FechaAviso = (aviso) ? fechaAviso : null;

                    //eliminar si existe la marca para esa entidad
                    string sql = String.Format("DELETE FROM MarcaSeguimiento WHERE EntidadTipo='{0}' AND EntidadID='{1}' AND CreadoPor={2}", marca.EntidadTipo, marca.EntidadId, ConfigBL.ticket.Usuario.Id);
                    dl.EjecutarSQL(sql);
                    dl.Guardar(marca);
                }
                dl.ConfirmarTransaccion();
                OnMarcaSeguimientoModificada(new EventArgs());
            }
        }
        public static void ModificarMarcas(IList lista, DateTime fecha, ImagenSeguimiento imagen, string comentarios, bool aviso, DateTime? fechaAviso)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                dl.IniciarTransaccion();
                foreach (MarcaSeguimiento marca in lista)
                {
                    marca.FechaSeguimiento = fecha;
                    marca.Imagen = imagen;
                    marca.Comentarios = comentarios;
                    marca.Aviso = aviso;
                    marca.FechaAviso = (aviso == true) ? fechaAviso : null;
                    dl.Guardar(marca);
                }
                dl.ConfirmarTransaccion();
                OnMarcaSeguimientoModificada(new EventArgs());
            }
        }
        public static void BorrarMarcas(IList lista)
        {
            foreach (MarcaSeguimiento marca in lista)
            {
                try
                {
                    marca.Eliminar();
                }
                catch (Exception) // Lo consumo
                { }
            }
            OnMarcaSeguimientoModificada(new EventArgs());
        }
        public static void PosponerAvisos(IList lista, DateTime fecha)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                dl.IniciarTransaccion();
                foreach (MarcaSeguimiento marca in lista)
                {
                    marca.Aviso = true;
                    marca.FechaAviso = fecha;
                    dl.Guardar(marca);
                }
                dl.ConfirmarTransaccion();
                OnMarcaSeguimientoModificada(new EventArgs());
            }
        }
        public static void BorrarAvisos(IList lista)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                dl.IniciarTransaccion();
                foreach (MarcaSeguimiento marca in lista)
                {
                    marca.Aviso = false;
                    marca.FechaAviso = null;
                    dl.Guardar(marca);
                }
                dl.ConfirmarTransaccion();
                OnMarcaSeguimientoModificada(new EventArgs());
            }
        }

        public static IList<MarcaSeguimiento> BuscarUsuarioLogueado()
        {
            return BuscarUsuarioLogueado(false);
        }
        public static IList<MarcaSeguimiento> BuscarUsuarioLogueado(bool soloAvisos)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                IQueryable<MarcaSeguimiento> query = dl.SessionLinq<MarcaSeguimiento>().Where(ms => ms.CreadoPor.Id == ConfigBL.ticket.Usuario.Id);
                if(soloAvisos)
                    query = query.Where(ms => ms.FechaAviso <= ConfigBL.FechaYHoraActual);
                return query.ToList();
            }
        }
        private static MarcaSeguimientoModificadaEventHandler _marcaSeguimientoModificadaEventHandler;
        public static event MarcaSeguimientoModificadaEventHandler MarcaSeguimientoModificada
        {
            add { _marcaSeguimientoModificadaEventHandler += value; }
            remove { _marcaSeguimientoModificadaEventHandler -= value; }
        }
        protected static void OnMarcaSeguimientoModificada(EventArgs e)
        {
            if (_marcaSeguimientoModificadaEventHandler != null)
            {	// Invocar los delegados
                _marcaSeguimientoModificadaEventHandler(null, e);
            }
        }

        public IPersistente LeerEntidad()
        {
            IPersistente entidad = null;

			Type tipoEntidad = Type.GetType("MarDevs.Gestion.Core." + this.EntidadTipo);
            if (tipoEntidad != null)
            {
                using (DL dl = DL.ObtenerSesion())
                {
                    entidad = dl.Leer(tipoEntidad, Convert.ToInt32(this.EntidadId)) as IPersistente;
                }
            }
            return entidad;
        }
    }

    public enum ImagenSeguimiento
    {
        [EnumDescriptor("Seguimiento", "ImagenSeguimiento")]
        ImagenSeguimiento = 0,
        [EnumDescriptor("Bandera Roja", "ImagenBanderaRoja")]
        ImagenBanderaRoja = 1,
        [EnumDescriptor("Bandera Azul", "ImagenBanderaAzul")]
        ImagenBanderaAzul = 2,
        [EnumDescriptor("Bandera Verde", "ImagenBanderaVerde")]
        ImagenBanderaVerde = 3,
        [EnumDescriptor("Llamar", "ImagenTelefono")]
        ImagenLlamar = 4,
        [EnumDescriptor("Información", "ImagenResumen")]
        ImagenInformacion = 5,
    }
}

