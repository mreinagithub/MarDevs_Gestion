using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MarDevs.Gestion.Core;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinMaskedEdit;
using Infragistics.Win.UltraWinToolbars;

namespace MarDevs.Gestion.Win
{
	public partial class FormParametro : Form
	{
        public FormParametro()
        {
            InitializeComponent();
            this.ultraToolbarsManager1.ToolClick += new ToolClickEventHandler(ultraToolbarsManager1_ToolClick);
        }
        protected Flags _flags;
        protected string _tituloFormulario = String.Empty;
        protected bool _soloLectura = false;
		protected bool _fueGuardado = false;
		protected ArrayList _controlesAExcluirProcesamientoSoloLectura = new ArrayList();
		protected static string STR_CONFIRMACION_AL_SALIR = "Se han producido cambios." + Environment.NewLine + "¿Desea guardarlos?";

		#region   Eventos

		private ObjetoGuardadoEventHandler _objetoGuardadoEventHandler;
		public event ObjetoGuardadoEventHandler ObjetoGuardado
		{
			add { _objetoGuardadoEventHandler += value; }
			remove { _objetoGuardadoEventHandler -= value; }
		}
		protected virtual void OnObjetoGuardado(ObjetoGuardadoEventArgs e)
		{
			if (_objetoGuardadoEventHandler != null)
			{
				// Invocar los delegados
				_objetoGuardadoEventHandler(this, e);
			}
		}

		#endregion

		#region PROPIEDADES
		
		protected virtual bool SoloLectura
		{
			get { return this._soloLectura; }
			set
			{
				this._soloLectura = value;
				this.ultraToolbarsManager1.Tools["Guardar"].SharedProps.Enabled = !value;
				this.ultraToolbarsManager1.Tools["GuardarYCerrar"].SharedProps.Enabled = !value;
				this.ultraToolbarsManager1.Tools["GuardarYNuevo"].SharedProps.Enabled = !value;
				this.EstablecerSoloLecturaEnControles(this, value);
			}
		}
		public virtual bool FueGuardado
		{
			get { return _fueGuardado; }
		}

		#endregion

        protected virtual void FormParametro_Load(object sender, System.EventArgs e)
		{
			if (this.DesignMode) { return; }

			try
			{
                CargarFlags();				
				SetearValores();
			}
			catch (Exception ex)
			{
				Mensaje.Error("Se ha producido un error al intentar abrir el formulario.", ex);
                this.FormClosing -= FormParametro_FormClosing;
				this.Close();
			}
		}		

        private void CargarFlags()
        {
            _flags = FlagsFactory.ObtenerInstancia<Flags>();
            FlagsFactory.CapturarSnapshot();
        }
        private void SetearValores()
        {
            bindingSourceFlags.DataSource = _flags;
        }
        protected virtual void ultraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Guardar":
					this.GuardarCambios();
                    break;
                case "GuardarYCerrar":
                    if (this.GuardarCambios())
                        this.Close();
                    break;
                case "Cerrar":
                    this.Close();
                    break;
                case "Imprimir":
                    this.Imprimir();
                    break;
            }
        }
		protected virtual void EstablecerPanelEstado(string texto, Color backColor)
        {
            statusBar.Panels["Estado"].Text = texto;
            statusBar.Panels["Estado"].Appearance.BackColor = backColor;
        }
        protected virtual void EstablecerPanelEstado(string texto)
        {
            statusBar.Panels["Estado"].Text = texto;
        }
        protected virtual bool GuardarCambios()
        {
            //ASEGURARSE DE SACAR EL FOCO DEL CONTROL ACTUAL PARA QUE GUARDE LOS CAMBIOS
            this.GetNextControl(this, true).Focus();

            try
            {
                FlagsFactory.Guardar();
				return true;
            }
            catch (ExcepcionNegocios exN)
            {
                Mensaje.Advertencia(exN.Message);
                return false;
            }
            catch (Exception ex)
            {
                Mensaje.ErrorAlGuardar(ex.Message, ex);
                return false;
            }
        }
        protected virtual void Imprimir()
        {
            UtilP.ImprimirForm(this, true, true);
        }
        protected void EstablecerSoloLecturaEnControles(Control control, bool valor)
        {
            if (this._controlesAExcluirProcesamientoSoloLectura.Contains(control))
            { return; }
            if (control is UltraTextEditor)
            {
                (control as UltraTextEditor).ReadOnly = valor;
                return;
            }
            if (control is UltraComboEditor)
            {
                (control as UltraComboEditor).ReadOnly = valor;
                return;
            }
			if (control is UltraCombo)
			{
				(control as UltraCombo).ReadOnly = valor;
				return;
			}
            if (control is UltraDateTimeEditor)
            {
                (control as UltraDateTimeEditor).ReadOnly = valor;
                return;
            }
            if (control is UltraMaskedEdit)
            {
                (control as UltraMaskedEdit).ReadOnly = valor;
                return;
            }
            if (control is UltraButton)
            {
                (control as UltraButton).Enabled = !valor;
                return;
            }
            if (control is UltraCheckEditor)
            {
                (control as UltraCheckEditor).Enabled = !valor;
                return;
            }
            foreach (Control c in control.Controls)
            {
                this.EstablecerSoloLecturaEnControles(c, valor);
            }
        }
		protected void LimpiarBindings()
		{
			UtilP.LimpiarBingingsControl(this);
		}

        private void txtLongitudMinPass_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(txtLongitudMinPass.Value) < 1 || Convert.ToInt32(txtLongitudMinPass.Value) > _flags.PasswordLongitudMaxima)
            {
                Mensaje.Advertencia("La longitud mínima no puede ser negativa o superior a la longitud máxima");
                txtLongitudMinPass.Value = _flags.PasswordLongitudMinima;
                return;
            }
            _flags.PasswordLongitudMinima = Convert.ToInt32(txtLongitudMinPass.Value);
        }

        private void txtLongitudMaxPass_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(txtLongitudMaxPass.Value) < 1 || Convert.ToInt32(txtLongitudMaxPass.Value) < _flags.PasswordLongitudMinima)
            {
                Mensaje.Advertencia("La longitud máxima no puede ser menor a uno o inferior a la longitud mínima");
                txtLongitudMinPass.Value = _flags.PasswordLongitudMinima;
                return;
            }
            _flags.PasswordLongitudMaxima = Convert.ToInt32(txtLongitudMaxPass.Value);
        }

        private void txtVigenciaPass_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(txtVigenciaPass.Value) < 0)
            {
                Mensaje.Advertencia("La vigencia de password debe ser de al menos 1 (un) día.");
                txtVigenciaPass.Value = _flags.DiasVigenciaPassword;
                return;
            }
            _flags.DiasVigenciaPassword = Convert.ToInt32(txtVigenciaPass.Value);
        }

        private void ckUpdaterHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtFrecuenciaUpdater.ReadOnly = !ckUpdaterHabilitado.Checked;
            txtURLUpdater.ReadOnly = !ckUpdaterHabilitado.Checked;
        }

        private void FormParametro_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.GetNextControl(this, true).Focus();
            if (!FlagsFactory.HayCambios()) return;

            DialogResult ResultadoPregunta = Mensaje.Pregunta("Se han producido cambios." + Environment.NewLine + "¿Desea guardarlos?", MessageBoxButtons.YesNoCancel);
            switch (ResultadoPregunta)
            {
                case DialogResult.Yes:
                    if (!this.GuardarCambios())
                    {
                        e.Cancel = true;
                    }
                    break;
                case DialogResult.No:
                    try
                    {   //NUEVO - DESHACER LOS CAMBIOS EN EL OBJETO
                        FlagsFactory.DeshacerCambios();
                    }
                    catch (Exception ex)
                    {
                        Mensaje.Error(ex.Message, ex);
                    }
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}