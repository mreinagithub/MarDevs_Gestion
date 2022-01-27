using System;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MarDevs.Gestion.Core
{
	/// <summary>
	/// Clase base para representar entidades de negocio
	/// </summary>
    [Serializable]
    public abstract class NegocioBase :INotifyPropertyChanged
	{
        protected NegocioBase()
        {
        }
        
        #region VARIABLES PRIVADAS

        protected string _ultimoError = String.Empty;
        //protected bool _hayCambios = false;
        //protected bool _traceSuspendido = false;
        [NonSerialized]
		[NoTracking]
		protected object _snapshot;

        #endregion

        [Browsable(false)]
        [NoTracking]
        public virtual object Yo
		{
			get { return this; }
		}

		public virtual string UltimoError()
		{
			return _ultimoError;
		}
		public virtual bool EsValido()
		{
			_ultimoError = String.Empty;
			bool valido = Validador.EsValido(this);
			if (!valido) { _ultimoError = Validador.Errores; }
			return valido;
		}
        public virtual string ID()
        {
            throw new NotImplementedException();
        }
		public virtual T Copiar<T>() where T : class
		{
			return Util.CopiarObjeto(this) as T;
		}
		public virtual object Copiar()
		{
			return Util.CopiarObjeto(this);
		}

        #region TRACKING DE CAMBIOS

        public virtual void CapturarSnapshot()
        {
            _snapshot = Util.CopiarObjeto(this);
        }
        public virtual bool HayCambios()
        {
			ArrayList diferencias = ObtenerDiferencias();
			return (diferencias.Count > 0);
        }
        public virtual void AceptarCambios()
        {
            _snapshot = null;
        }
        protected ArrayList ObtenerDiferencias()
        {
            return Util.ObtenerDiferenciasObjetos(this, _snapshot);
        }
		public void DeshacerCambios()
		{
			RestaurarEstado();
			_snapshot = null;
		}
		protected void RestaurarEstado()
		{
			Util.RestaurarEstado(this, _snapshot);
		}

        #endregion

		#region Miembros de INotifyPropertyChanged

        [field: NonSerialized] 
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
		#endregion
	}
}
