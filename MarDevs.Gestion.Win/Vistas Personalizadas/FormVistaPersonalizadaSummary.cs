using System;
using System.Windows.Forms;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{
	public partial class FormVistaPersonalizadaSummary : Form
	{		
		public FormVistaPersonalizadaSummary(VistaPersonalizadaSummary summary)
		{
			_vSummary = summary;
			InitializeComponent();
		}		
		public FormVistaPersonalizadaSummary(VistaPersonalizadaSummary summary, bool esNuevo) : this(summary)
		{ 
			_esNuevo = esNuevo;			
		}

		private bool _esNuevo = false;
		VistaPersonalizadaSummary _vSummary;
		private bool _fueCerrado = false;

		private void FormVistaPersonalizadaSummary_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_fueCerrado)
				return;
			PasarValoresAObjeto();
			if (_vSummary.HayCambios())
			{
				if (Mensaje.Pregunta("Se han detectado cambios al summary, desea cerrar de todos modos?.\nSe perderán los cambios.") != DialogResult.Yes)
				{
					e.Cancel = true;
				}
				else
				{
					_vSummary.DeshacerCambios();
				}
			}
		}
		private void FormVistaPersonalizadaSummary_Load(object sender, EventArgs e)
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				CargarCombos();				
				BindearValores();

				_vSummary.CapturarSnapshot();
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
				this.Close();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}
		private void botonCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void botonAceptar_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(this.txtCampo.Text.Trim()))
			{
				Mensaje.Advertencia("El campo no puede estar vacío.");
				return;
			}
			PasarValoresAObjeto();
			if (_vSummary.Accion == AccionSummary.Formula && String.IsNullOrEmpty(_vSummary.Formula))
			{
				Mensaje.Advertencia("Debe especificar la fórmula a utilizar.");
				return;
			}


			_vSummary.AceptarCambios();
			if (!_vSummary.VistaPersonalizada.Summaries.Contains(_vSummary))
				_vSummary.VistaPersonalizada.Summaries.Add(_vSummary);
			_fueCerrado = true;
			this.Close();
		}

		private void CargarCombos()
		{
			UtilP.CargarComboDesdeEnum(this.cboAccion, typeof(AccionSummary));
			UtilP.CargarComboDesdeEnum(this.cboUbicacion, typeof(UbicacionSummary));
		}		
		private void BindearValores()
		{
			if (_vSummary == null)
				return;

			this.txtCampo.Text = _vSummary.Campo;
			this.cboAccion.Value = _vSummary.Accion;
			this.txtFormula.Value = _vSummary.Formula;
			this.txtDisplay.Value = _vSummary.Display;
			this.cboUbicacion.Value = _vSummary.Ubicacion;
		}
		private void PasarValoresAObjeto()
		{			
			_vSummary.Campo = this.txtCampo.Text.Trim();
			_vSummary.Accion = (AccionSummary)this.cboAccion.Value;
			_vSummary.Formula = this.txtFormula.Text.Trim();
			_vSummary.Display = this.txtDisplay.Text.Trim();
			_vSummary.Ubicacion = (UbicacionSummary)this.cboUbicacion.Value;
		}
		
	}
}
