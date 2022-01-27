using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;

namespace MarDevs.Gestion.Core
{
	/// <summary>
	/// Case base para representar entidades de negocios que se persisten en forma independiente.
	/// Deriva de NegocioBase
	/// </summary>
	[Serializable]
	public abstract class Persistente<TIPOID> : NegocioBase, IPersistente<TIPOID>
	{
		protected bool _coleccionesInicializadas = false;

		[Browsable(false)]
		[NoTracking]
        public virtual TIPOID Id { get; set; }

		/// <summary>
		/// Guarda los cambios realizados al entidad y sus objetos dependientes si es que están configurados
		/// en el archivo de mapping con Cascade. Adicionalmente, si el entidad tiene soporte de log,
		/// crea y persiste el mismo.
		/// </summary>
		public virtual void Guardar()
		{
			if (!this.EsValido())
				throw new ExcepcionNegocios(_ultimoError);
			try
			{
				using (DL dl = DL.ObtenerSesion())
				{
					dl.IniciarTransaccion();
					this.AntesDeGuardar(dl);
					if (this.TieneLog() && !this.EsNuevo())
					{
						this.CrearLogYPersistir(dl);
					}
					dl.Guardar(this);
					dl.ConfirmarTransaccion();
				}

				this.DespuesDeGuardar();
				this.AceptarCambios();
			}
			catch
			{
				throw;
			}
		}
		/// <summary>
		/// Metodo para q sobreescriban los herederos para, por ejemplo, rutinas de validación, 
		/// se recibe una instancia de DL donde ya se ha iniciado la transacción a la base de datos.
		/// </summary>
		/// <param name="dl"></param>
		public virtual void AntesDeGuardar(DL dl)
		{
			//metodo vacio para q lo sobreescriban los herederos
			//aqui tienen una oportunidad de hacer, por ejemplo, validaciones adicionales.
		}
		/// <summary>
		/// Metodo que se llama inmediatamente luego de Guardar y confirmar la transacción.
		/// </summary>
		public virtual void DespuesDeGuardar()
		{
			//nada, aqui los herederos pueden sobreescribir codigo.
		}
		/// <summary>
		/// Elimina el entidad de la base de datos. No realiza cambios en el entidad por lo que este se 
		/// puede seguir utilizando aunque en la mayoria de los casos no tendría sentido
		/// </summary>
		public virtual void Eliminar()
		{
			DL dl = DL.ObtenerSesion();
			try
			{
				dl.IniciarTransaccion();
				dl.Eliminar(this);
				dl.ConfirmarTransaccion();
				this.AceptarCambios();
			}
			catch
			{
				dl.DeshacerTransaccion();
				throw;
			}
			finally
			{
				dl.Dispose();
			}
		}
		public virtual void ResetearId()
		{
			Id = default(TIPOID);
		}
		/// <summary>
		/// Devuelve si el entidad ya está persistido en la base de datos o si se trata de una nueva instancia
		/// que todavía no se ha insertado en la base de datos subyacente
		/// </summary>
		/// <returns></returns>
		public virtual bool EsNuevo()
		{
            return Id == null || Id.Equals(default(TIPOID));
		}
		///// <summary>
		///// Devuelve el Id del entidad.
		///// </summary>
		///// <returns></returns>
        public virtual object ObtenerID()
        {
            return Id;
        }
		/// <summary>
		/// Es el tipo de entidad, un número entero q representa el código de entidad y es igual para todas las instancias.
		/// </summary>
		/// <returns></returns>
        public virtual string ObtenerTipo()
		{
            return this.GetType().Name;
		}
		/// <summary>
		/// Inicializa las colecciones del entidad que están definidas en el archivo de mapping con lazy=true
		/// leyéndolas de la base de datos.
		/// </summary>
		public virtual void InicializarColecciones()
		{
			//código a implementar por las clases derivadas.
		}
		/// <summary>
		/// Actualiza el entidad, leyéndolo nuevamente de la base de datos e inicializa las colecciones
		/// si ya estaban inicializadas o bien si el parámetro forzarInicializacionColecciones es true
		/// </summary>
		/// <param name="forzarInicializacionColecciones"></param>
		public virtual void Actualizar(bool forzarInicializacionColecciones)
		{
			if (!EsNuevo())
			{
				DL dl = DL.ObtenerSesion();
				dl.Actualizar(this);
				dl.Dispose();
				if (this._coleccionesInicializadas || forzarInicializacionColecciones)
				{
					this.InicializarColecciones();
				}
				this.AceptarCambios();
			}
		}
		/// <summary>
		/// Devuelve un ArrayList con el log que debe ser persistido de acuerdo
		/// a los cambios realizados sobre el entidad
		/// </summary>
		/// <returns></returns>
		protected virtual ArrayList CrearLog()
		{
			ArrayList lista = new ArrayList();

			if (!this.TieneLog() || !this.DebeCrearLogStandard())
			{
				return lista;
			}

			Log log = null;
			string logText;

			foreach (Cambio cambio in this.ObtenerDiferencias())
			{
				log = null;
				switch (cambio.Tipo)
				{
					case TipoCambio.Property:
						log = CrearLogProperty(cambio.NombreProperty, cambio.ValorAnterior, cambio.ValorNuevo);
						break;

					case TipoCambio.ElementoAgregado:
						logText = String.Format("{0}: se agregó '{1}'",
							cambio.NombreProperty,
							cambio.ValorNuevo);
						log = Log.Crear(this, logText);
						break;

					case TipoCambio.ElementoEliminado:
						logText = String.Format("{0}: se eliminó '{1}'",
							cambio.NombreProperty,
							cambio.ValorAnterior);
						log = Log.Crear(this, logText);
						break;

				}
				if (log != null)
				{
					lista.Add(log);
				}
			}
			return lista;

		}

		/// <summary>
		/// Crea una entrada standard de log (instancia de Log) para la property, valores anterior y nuevo
		/// pasados por parámetro. Las clases derivadas pueden reemplazar este método para personalizar como
		/// se crea una entrada de log, e inclusive devolver null si no se quiere crear log para una property
		/// puntual.
		/// </summary>
		/// <param name="propiedad"></param>
		/// <param name="valorAnterior"></param>
		/// <param name="valorNuevo"></param>
		/// <returns></returns>
		protected virtual Log CrearLogProperty(string propiedad, object valorAnterior, object valorNuevo)
		{
			string msg = String.Empty;
			Log log = null;

			msg = Log.MensajeCambioStandard(propiedad, valorAnterior, valorNuevo);
			if (msg.Length > 0)
			{
				log = Log.Crear(this, msg);
			}
			return log;
		}
		/// <summary>
		/// Devuelve un ArrayList con el log que debe ser persistido de acuerdo
		/// a los cambios realizados sobre el entidad y persiste los cambios utilizando
		/// el DL pasado como parámetro. Comunmente se llamará a este método desde Guardar()
		/// </summary>
		/// <returns></returns>
		protected virtual void CrearLogYPersistir(DL dl)
		{
			foreach (Log log in this.CrearLog())
			{
				dl.Guardar(log);
			}
		}
		/// <summary>
		/// Devuelve un valor que indica si esta clase Persistente tiene o no log de cambios
		/// </summary>
		/// <returns></returns>
		public virtual bool TieneLog()
		{
			return true;
		}
		public virtual bool DebeCrearLogStandard()
		{
			return true;
		}
		/// <summary>
		/// Obtiene el log que este entidad Persistente tiene almacenado en la base de datos.
		/// </summary>
		/// <returns></returns>
		public virtual IList<Log> ObtenerLog()
		{
			if (!TieneLog())
			{
				throw new NotSupportedException(String.Format("La clase {0} no soporta logging", this.GetType().Name));
			}
			return Log.Listar(this);
		}
		/// <summary>
		/// Indica si este objeto tiene o no un Id generado en forma automática por DL (para las Guids)
		/// o por el motor de base de datos (para int autonuméricos). Es true por default.
		/// </summary>
		/// <returns></returns>
		public virtual bool IdAutogenerado()
		{
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || this.GetType() != obj.GetType()) { return false; }
			if (this == obj) { return true; }
			if (this.EsNuevo()) { return false; }
			return (this.Id.Equals(((IPersistente<TIPOID>)obj).Id));
		}
		public override int GetHashCode()
		{
			return (this.EsNuevo()) ? 0 : this.Id.GetHashCode();
		}
		public override void CapturarSnapshot()
		{
			if (!_coleccionesInicializadas)
			{
				InicializarColecciones();
			}
			base.CapturarSnapshot();
		}
    }
}
