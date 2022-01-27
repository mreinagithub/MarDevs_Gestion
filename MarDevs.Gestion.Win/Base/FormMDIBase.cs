using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MarDevs.Gestion.Win
{
	/// <summary>
	/// Descripción breve de FormMDIBase.
	/// </summary>
	public partial class FormMDIBase : System.Windows.Forms.Form
	{
		public FormMDIBase()
		{
			// Necesario para admitir el Diseñador de Windows Forms
			InitializeComponent();
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			this.Load += new EventHandler(FormMDIBase_Load);
			this.Shown += new EventHandler(FormMDIBase_Shown);
		}
		protected virtual void FormMDIBase_Load(object sender, EventArgs e)
		{
			if (DesignMode) { return; }
			try
			{
				InicializarFormulario();
			}
			catch (Exception ex)
			{
				_excepcionEnLoad = ex;
			}
		}
		protected virtual void FormMDIBase_Shown(object sender, EventArgs e)
		{
			if (_excepcionEnLoad != null)
			{
				string tempTexto = "Al tratar de abrir el formulario se produjo el siguiente error: " + Environment.NewLine
					+ Environment.NewLine
					+ _excepcionEnLoad.Message + Environment.NewLine
					+ Environment.NewLine
					+ "El formulario no puede abrirse. ";

				Mensaje.Error(tempTexto, _excepcionEnLoad);
				this.Close();
			}
		}
		protected virtual void InicializarFormulario()
		{
			//NADA, PARA QUE LO SOBREESCRIBAN LOS HEREDEROS.
		}

		#region   Eventos 

		private FormInvalidadoEventHandler _FormInvalidado;
		public event FormInvalidadoEventHandler FormInvalidado 
		{
			add { _FormInvalidado += value; }
			remove { _FormInvalidado -= value; }
		}

		protected virtual void OnFormInvalidado(FormInvalidadoEventArgs e)
		{
			if (_FormInvalidado != null) 
			{
				// Invocar los delegados
				_FormInvalidado(this, e);
			}
		}


		private EventHandler _ActualizarStatusBarText;
		public event EventHandler ActualizarStatusBarText
		{
			add { _ActualizarStatusBarText += value; }
			remove { _ActualizarStatusBarText -= value; }

		}
		
		protected virtual void OnActualizarStatusBarText(EventArgs e)
		{
			if (_ActualizarStatusBarText != null) 
			{
				// Invocar los delegados
				_ActualizarStatusBarText(this, e);
			}
		}

		#endregion
		
		protected Exception _excepcionEnLoad;
		private string _key = String.Empty;
		private string _statusBarText = String.Empty;
		private string _descripcion = String.Empty;

		public Exception ExcepcionEnLoad
		{
			get { return _excepcionEnLoad; }
		}
		public string Descripcion
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		public string Key
		{
			get { return this._key; }
			set { this._key = value;}
		}
		public virtual string StatusBarText
		{
			get 
			{ 
				return this._statusBarText; 
			}
		}
        public virtual bool PermitirMultiplesInstancias
        {
            get { return true; }
        }


	}
}
