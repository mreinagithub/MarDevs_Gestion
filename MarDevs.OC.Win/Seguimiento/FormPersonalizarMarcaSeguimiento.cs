using System;
using System.Windows.Forms;
using System.Collections;
using MarDevs.OC.Core;

namespace MarDevs.OC.Win
{
	public partial class FormPersonalizarMarcaSeguimiento : Form
	{
		public FormPersonalizarMarcaSeguimiento(IList lista, bool activarAviso)
		{
			_lista = lista;
			_activarAviso = activarAviso;

			InitializeComponent();

			this.chkAviso.CheckedChanged += new EventHandler(chkAviso_CheckedChanged);
			this.txtFechaSeguimiento.ValueChanged += new EventHandler(txtFechaSeguimiento_ValueChanged);
		}

		private IList _lista = new ArrayList();
		private bool _activarAviso;

		private void FormPersonalizarMarcaSeguimiento_Load(object sender, EventArgs e)
		{
			try
			{
				UtilP.CargarComboDesdeEnum(this.cmbImagen, typeof(ImagenSeguimiento));
				this.cmbImagen.Value = ImagenSeguimiento.ImagenSeguimiento;
				this.txtFechaSeguimiento.DateTime = ConfigBL.FechaActual;
				this.txtFechaAviso.Value = ConfigBL.FechaActual.AddMinutes(570);
				this.chkAviso.Checked = _activarAviso;
				this.txtFechaAviso.Enabled = _activarAviso;
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
				this.Close();
			}
		}
		private void txtFechaSeguimiento_ValueChanged(object sender, EventArgs e)
		{
			this.txtFechaAviso.Value = this.txtFechaSeguimiento.DateTime.Date.AddHours(18);
		}
		private void chkAviso_CheckedChanged(object sender, EventArgs e)
		{
			this.txtFechaAviso.Enabled = this.chkAviso.Checked;
		}

		protected void CrearMarcas()
		{
			if (_lista == null || _lista.Count == 0) { return; }
			if (_lista[0] is MarcaSeguimiento)
			{
				MarcaSeguimiento.ModificarMarcas(_lista, this.txtFechaSeguimiento.DateTime, (ImagenSeguimiento)this.cmbImagen.Value, this.txtComentarios.Text, this.chkAviso.Checked, this.txtFechaAviso.Value);
			}
			else //es una entidad comun.
			{
				MarcaSeguimiento.CrearMarcasDesdeEntidades(_lista, this.txtFechaSeguimiento.DateTime, (ImagenSeguimiento)this.cmbImagen.Value, this.txtComentarios.Text, this.chkAviso.Checked, this.txtFechaAviso.Value);
			}
		}


		private void aceptarButton_Click(object sender, EventArgs e)
		{
			CrearMarcas();
		}

	}
}
