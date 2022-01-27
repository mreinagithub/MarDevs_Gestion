using System;
using System.Windows.Forms;

namespace MarDevs.Gestion.Win
{
	public partial class FormPreferencias : Form
	{
		public FormPreferencias()
		{
			InitializeComponent();
		}
		private void FormPreferencias_Load(object sender, EventArgs e)
		{
			try
			{

				this.checkUsarMultiFormulario.Checked = MarDevs.Gestion.Win.Properties.Settings.Default.MultiVentana;

			}
			catch (Exception ex)
			{
				
				Mensaje.Error("No se pudo abrir el formulario", ex);
				this.Close();
			}
		}
		private void cancelarButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void aceptarButton_Click(object sender, EventArgs e)
		{
			try
			{
				MarDevs.Gestion.Win.Properties.Settings.Default.MultiVentana = checkUsarMultiFormulario.Checked;
				MarDevs.Gestion.Win.Properties.Settings.Default.Save();
			}
			catch (Exception ex)
			{
				Mensaje.Error("No se pudieron guardar las preferencias", ex);
			}
			finally
			{
				this.Close();
			}
		}

	}
}