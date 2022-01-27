using System;
using System.Windows.Forms;
using System.IO;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{
	public partial class FormFormulario : Form
	{
        Formulario _formulario;
		public FormFormulario(Formulario formulario)
        {
            _formulario = formulario;
			InitializeComponent();
			this.txtBuscarFormulario.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(txtBuscarFormulario_EditorButtonClick);
		}

		private void FormFormulario_Load(object sender, EventArgs e)
		{
			this.txtTipo.Text = _formulario.Tipo.ToString();
			this.txtDescripcion.Text = _formulario.Descripcion;
			this.txtFechaModificacion.Value = _formulario.FechaModificacion;
			this.txtCopias.Value = _formulario.Copias;
			if (_formulario.Contenido == null)
			{
				this.lblRutaFormulario.Text += " [El Formulario NO tiene Contenido]";
				this.txtLongContenido.Text = "0 Bytes";
			}
			else
			{
				this.lblRutaFormulario.Text += " [Formulario con Contenido]";
				this.txtLongContenido.Text = _formulario.Contenido.Length.ToString() + " Bytes";
			}
		}
		private void txtCopias_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsNumber(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
			{
				e.Handled = true;
			}
		}
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void btnAceptar_Click(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.CargarFormulario();
				this.Close();
			}
			catch (ExcepcionNegocios ex)
			{
				Mensaje.Advertencia(ex.Message);
			}
			catch (Exception ex)
			{
				Mensaje.Error("Se produjo el siguiente error al intentar cargar el formulario: ", ex);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		private void txtBuscarFormulario_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
		{
			try
			{
				this.openFileDialog1.Multiselect = false;
				this.openFileDialog1.Filter = "Archivos con unidades a importar (*.rdl)|*.rdl";
				this.openFileDialog1.FileName = string.Empty;
				this.openFileDialog1.ShowDialog();
				this.txtBuscarFormulario.Text = this.openFileDialog1.FileName;									
			}
			catch (Exception ex)
			{
				Mensaje.Error("Se ha producido un error al abrir el archivo seleccionado. ", ex);
			}
		}
		private void btnExportar_Click(object sender, EventArgs e)
		{
			this.Exportar();
		}

		private void CargarFormulario()
		{
			//Validación
			if (String.IsNullOrEmpty(this.txtBuscarFormulario.Text) && _formulario.Contenido == null)
				throw new ExcepcionNegocios("No hay Formulario cargado. Debe seleccionarlo antes de guardar.");
			if (String.IsNullOrEmpty(this.txtCopias.Text))
				throw new ExcepcionNegocios("Debe seleccionar la cantidad de copias a imprimir para el formulario.");
			if (Convert.ToInt32(this.txtCopias.Text) < 1)
				throw new ExcepcionNegocios("La cantidad de copias debe ser como mínimo 1.");
			// Si están todos los datos
			_formulario.FechaModificacion = ConfigBL.FechaYHoraActual;
			_formulario.Copias = Convert.ToInt32(this.txtCopias.Text);
			if (!string.IsNullOrEmpty(this.txtBuscarFormulario.Text))
				_formulario.Contenido = File.ReadAllBytes(this.txtBuscarFormulario.Text);
			_formulario.Guardar();
			Mensaje.Informacion("Se ha actualizado el formulario correctamente.");
		}
		private void Exportar()
		{
			try
			{
				if (_formulario.Contenido == null && string.IsNullOrEmpty(this.txtBuscarFormulario.Text))
				{
					Mensaje.Advertencia("No se encontró Formulario para Exportar.");
					return;
				}

				this.saveFileDialog1.Filter = "Archivo a exportar (*.rdl)|*.rdl";
				string nombreArchivo = "Formulario_" + _formulario.Tipo.ToString();
				this.saveFileDialog1.FileName = nombreArchivo;
				DialogResult resu = this.saveFileDialog1.ShowDialog();
				if (resu == DialogResult.OK)
				{
					Cursor.Current = Cursors.WaitCursor;
					FileStream fs = new FileStream(this.saveFileDialog1.FileName, FileMode.Create);
					if (!string.IsNullOrEmpty(this.txtBuscarFormulario.Text))
					{
						Byte[] temporal = File.ReadAllBytes(this.txtBuscarFormulario.Text);
						fs.Write(temporal, 0, temporal.Length);
					}
					else
					{
						fs.Write(_formulario.Contenido, 0, _formulario.Contenido.Length);
					}
					fs.Close();
					Mensaje.Informacion("Se ha exportado correctamente el Formulario.");
				}
			}
			catch (Exception ex)
			{
				Mensaje.Error("No se pudo exportar. Error: ", ex);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}
	}
}
