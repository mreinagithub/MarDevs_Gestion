using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MarDevs.OC.Core;

namespace MarDevs.OC.Win
{
	public partial class FormVistaPersonalizadaParametro : Form
	{
		public FormVistaPersonalizadaParametro(VistaPersonalizadaParametro parametro)
		{
			_vParametro = parametro;
			InitializeComponent();
		}
		public FormVistaPersonalizadaParametro(VistaPersonalizadaParametro parametro, bool esNuevo) : this(parametro)
		{ 
			_esNuevo = esNuevo;			
		}

		private bool _esNuevo = false;
		VistaPersonalizadaParametro _vParametro;
		private bool _fueCerrado = false;

		private void CargarCombos()
		{
			UtilP.CargarComboDesdeEnum(this.cboTipoParametro, typeof(TipoControl));			
		}
		private void CrearGrillaEtiquetas()
		{
			DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
			columna.Name = "Propiedad";
			columna.HeaderText = "Propiedad";
			columna.Width = 200;
			columna.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView1.Columns.Add(columna);
			columna = new DataGridViewTextBoxColumn();
			columna.Name = "Etiqueta";
			columna.HeaderText = "Etiqueta";
			columna.Width = 200;
			columna.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView1.Columns.Add(columna);
		}
		private void BindearValores()
		{
			if (_vParametro == null)
				return;

			this.ckParametroActivo.Checked = _vParametro.Activo;
			this.txtIdParametro.Text = _vParametro.IdParametro;
			this.cboTipoParametro.Value = _vParametro.TipoControl;
			BindearGrilla();
			this.txtPuntoX.Value = _vParametro.PuntoX;
			this.txtPuntoY.Value = _vParametro.PuntoY;
			this.txtAnchoControl.Value = _vParametro.Ancho;
			this.txtAnchoEtiqueta.Value = _vParametro.AnchoEtiqueta;
			this.txtAltoControl.Value = _vParametro.Alto;
			this.txtTabOrder.Value = _vParametro.Orden;
			this.txtConsulta.Text = _vParametro.ConsultaDatos;
			this.txtConsultaDefault.Text = _vParametro.ConsultaDefault;
		}
		private void BindearGrilla()
		{						
			string[] div = _vParametro.Etiqueta.Split(';');
			foreach (string str in div)
			{				
				if (String.IsNullOrEmpty(str))
					continue;				
				string[] ve = str.Split('|');
				if (ve.Count() == 1)
					dataGridView1.Rows.Add(ve);					
				else if (ve.Count() > 1)
				{
					dataGridView1.Rows.Add(ve);					
				}				
			}			
		}
		private void Subir()
		{
			DataGridViewSelectedRowCollection seleccion = this.dataGridView1.SelectedRows;
			if (seleccion == null || seleccion.Count > 1)
				return;
			if (seleccion.Count == 0)
				return;
			DataGridViewRow dgv = seleccion[0];
			if (dgv.Index <= 0)
				return;
			int indice = dgv.Index;
			this.dataGridView1.Rows.RemoveAt(indice);
			this.dataGridView1.Rows.Insert(indice - 1, dgv);
			this.dataGridView1.ClearSelection();
			this.dataGridView1.Rows[indice - 1].Selected = true;
		}
		private void Bajar()
		{
			DataGridViewSelectedRowCollection seleccion = this.dataGridView1.SelectedRows;
			if (seleccion == null || seleccion.Count > 1)
				return;
			if (seleccion.Count == 0)
				return;
			DataGridViewRow dgv = seleccion[0];
			if (dgv.Index >= this.dataGridView1.Rows.Count-2)
				return;
			int indice = dgv.Index;
			this.dataGridView1.Rows.RemoveAt(indice);
			this.dataGridView1.Rows.Insert(indice + 1, dgv);
			this.dataGridView1.ClearSelection();
			this.dataGridView1.Rows[indice + 1].Selected = true;
		}
		private void PasarValoresAObjeto()
		{
			_vParametro.Activo = this.ckParametroActivo.Checked;
			_vParametro.IdParametro = this.txtIdParametro.Text.Trim();
			_vParametro.TipoControl = (TipoControl)this.cboTipoParametro.Value;
			_vParametro.PuntoX = Convert.ToInt32(this.txtPuntoX.Value);
			_vParametro.PuntoY = Convert.ToInt32(this.txtPuntoY.Value);
			_vParametro.Ancho = Convert.ToInt32(this.txtAnchoControl.Value);
			_vParametro.AnchoEtiqueta = Convert.ToInt32(this.txtAnchoEtiqueta.Value);
			_vParametro.Alto = Convert.ToInt32(this.txtAltoControl.Value);
			_vParametro.Orden = Convert.ToInt32(this.txtTabOrder.Value);
			_vParametro.ConsultaDatos = this.txtConsulta.Text;
			_vParametro.ConsultaDefault = this.txtConsultaDefault.Text;

			//Armar etiquetas
			string etiquetaGuardar = string.Empty;
			foreach (DataGridViewRow dr in this.dataGridView1.Rows)
			{
				string adherirAEtiqueta = string.Empty;
				if (dr.Cells[0].Value != null)
					adherirAEtiqueta += dr.Cells[0].Value.ToString().Trim();

				if (dr.Cells[1].Value != null && dr.Cells[1].Value.ToString().Trim() != "")
					adherirAEtiqueta += (string.IsNullOrEmpty(adherirAEtiqueta) ? "" : "|") + dr.Cells[1].Value.ToString().Trim();
				if (!String.IsNullOrEmpty(adherirAEtiqueta))
					etiquetaGuardar += (String.IsNullOrEmpty(etiquetaGuardar) ? "" : ";") + adherirAEtiqueta;
				}
			_vParametro.Etiqueta = etiquetaGuardar;			
		}
		private void HabilitaciónDeConsultas()
		{
			this.txtConsulta.ReadOnly = true;
			this.txtConsultaDefault.ReadOnly = true;
			this.btnConsultarDatos.Enabled = false;
			this.btnConsultarDefault.Enabled = false;
			TipoControl? tipo = (TipoControl?)this.cboTipoParametro.Value;
			if (tipo != null)
			{
				switch (tipo)
				{
					case TipoControl.Check:
					case TipoControl.Periodo:
					case TipoControl.Label:
					case TipoControl.Boton:
						this.txtConsultaDefault.ReadOnly = false;
						break;
					case TipoControl.Fecha:
						this.txtConsultaDefault.ReadOnly = false;
						this.btnConsultarDefault.Enabled = true;
						break;
					case TipoControl.Combo:
						this.txtConsulta.ReadOnly = false;
						this.txtConsultaDefault.ReadOnly = false;
						this.btnConsultarDatos.Enabled = true;
						this.btnConsultarDefault.Enabled = true;
						break;						
				}
			}
			EstablecerTextoAyudaDefault();
		}
		private void EstablecerTextoAyudaDefault()
		{
			TipoControl? tipo = (TipoControl?)this.cboTipoParametro.Value;
			if (tipo != null)
			{
				switch (tipo)
				{
					case TipoControl.Check:
						this.lblAyudaDefault.Text = "(*) Use TRUE para tildar el check por default. Nada o FALSE por default está destildado.";
						break;
					case TipoControl.Periodo:
						this.lblAyudaDefault.Text = "(*) Use una de las siguientes opciones para el default: HOY, AYER, SEMANA ACTUAL, SEMANA ANTERIOR, MES ACTUAL o MES ANTERIOR. Nada establece por default en cualquier momento.";
						break;
					case TipoControl.Fecha:
						this.lblAyudaDefault.Text = "(*) Escriba un query para devolver un datetime valido como default.";
						break;
					case TipoControl.Combo:
						this.lblAyudaDefault.Text = "(*) Escriba un query para devolver un valor default.";
						break;
					case TipoControl.Label:
						this.lblAyudaDefault.Text = "(*) Escriba el texto que desea mostrar.";
						break;
					case TipoControl.Boton:
						this.lblAyudaDefault.Text = "(*) Escriba el nombre del método que deberá llamar (el mismo debe existir en el formulario correspondiente a la vista personalizada).";
						break;
					default:
						this.lblAyudaDefault.Text = "";
						break;
				}
			}
		}
		private void EjecutarConsulta(string texto)
		{
			using (DL dl = DL.ObtenerSesion())
			{						
				DataTable dt = dl.EjecutarSQL(texto);							
				Mensaje.Informacion(String.Format("Comandos completados exitosamente. Cantidad de registros devueltos: {0}", dt.Rows.Count.ToString()));				
			}
		}

		private void FormVistaPersonalizadaParametro_Load(object sender, EventArgs e)
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				CargarCombos();
				CrearGrillaEtiquetas();
				BindearValores();

				_vParametro.CapturarSnapshot();
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
		private void FormVistaPersonalizadaParametro_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_fueCerrado)
				return;
			PasarValoresAObjeto();
			if(_vParametro.HayCambios())
			{
				if (Mensaje.Pregunta("Se han detectado cambios al parámetro, desea cerrar de todos modos?.\nSe perderán los cambios.") != DialogResult.Yes)
				{
					e.Cancel = true;					
				}
				else
				{
					_vParametro.DeshacerCambios();
				}
			}
		}
		private void btnSubir_Click(object sender, EventArgs e)
		{
			try { Subir(); }
			catch (Exception ex) { Mensaje.MostrarError(ex); }
		}
		private void btnBajar_Click(object sender, EventArgs e)
		{
			try { Bajar(); }
			catch (Exception ex) { Mensaje.MostrarError(ex); }
		}
		private void botonCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void botonAceptar_Click(object sender, EventArgs e)
		{
			if(String.IsNullOrEmpty(this.txtIdParametro.Text.Trim()))
			{
				Mensaje.Advertencia("El Id de parámetro no puede estar vacío.");
				return;
			}
			PasarValoresAObjeto();
			if (_vParametro.VistaPersonalizada.Parametros.Count(p => p.IdParametro == _vParametro.IdParametro) > (_esNuevo ? 0 : 1))
			{
				Mensaje.Advertencia("Ya existe otro parámetro con ese Id.");
				return;
			}	
			_vParametro.AceptarCambios();
			if (!_vParametro.VistaPersonalizada.Parametros.Contains(_vParametro))
				_vParametro.VistaPersonalizada.Parametros.Add(_vParametro);
			_fueCerrado = true;
			this.Close();
		}
		private void cboTipoParametro_ValueChanged(object sender, EventArgs e)
		{
			HabilitaciónDeConsultas();
		}
		private void btnConsultarDatos_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(this.txtConsulta.Text))
				return;

			try
			{
				this.Cursor = Cursors.WaitCursor;
				EjecutarConsulta(this.txtConsulta.Text);
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		private void btnConsultarDefault_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(this.txtConsultaDefault.Text))
				return;

			try
			{
				this.Cursor = Cursors.WaitCursor;
				EjecutarConsulta(this.txtConsultaDefault.Text);
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);				
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}


	}
}
