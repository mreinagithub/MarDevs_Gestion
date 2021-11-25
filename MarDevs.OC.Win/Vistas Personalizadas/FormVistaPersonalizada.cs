using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MarDevs.OC.Core;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using System.Drawing.Imaging;

namespace MarDevs.OC.Win
{
	public partial class FormVistaPersonalizada : Form
	{
		private VistaPersonalizada _vp;
		private bool _fueCerrado = false;
		Infragistics.Win.UltraWinEditors.UltraComboEditor cboColor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
		Infragistics.Win.UltraWinEditors.UltraComboEditor cboEnums = new Infragistics.Win.UltraWinEditors.UltraComboEditor();

		public FormVistaPersonalizada(VistaPersonalizada vp)
		{
			_vp = vp;			
			InitializeComponent();
		}

		private void FormVistaPersonalizada_Load(object sender, EventArgs e)
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				if (_vp.EsNuevo())
				{
					this.Text = "Nueva Vista Personalizada";
					this.ultraTabControl1.Tabs["Formatos"].Visible = (_vp.Formatos.Count > 0);
					this.botonAceptar.Enabled = false;					
				}
				else
				{
                    cboEntidad.ReadOnly = true;
					this.Text = "Vista Personalizada";
					this.ultraTabControl1.Tabs["Formatos"].Visible = _vp.TipoVista != TipoVistaPersonalizada.HQL;
					this.botonAceptar.Enabled = true;					
				}
				this.CargarCombos();
				CargarComboImagenCarpeta();

				// Binding
				this.bindingSourceVistaPersonalizada.DataSource = _vp;
				this.grillaPermisos.DataSource = _vp.Permisos;
				this.grillaFormatos.DataSource = _vp.Formatos;
				this.grillaParametros.DataSource = _vp.Parametros;
				this.grillaSummaries.DataSource = _vp.Summaries;
				this.grillaParametros.ActiveRow = null;

				this.comboTipoPermiso.SelectedIndex = 0;
				if (_vp.EsNuevo())
				{
					cboEntidad.SelectedIndex = 0;
					_vp.Entidad = cboEntidad.Value.ToString();
				}

				this.txtConsulta.ValueChanged += new EventHandler(txtConsulta_ValueChanged);
				this.cboEntidad.ValueChanged += new EventHandler(cboEntidad_ValueChanged);
				this.cboTipoVista.ValueChanged += new EventHandler(cboTipoVista_ValueChanged);

                this.ArmarStringConvenciones();
				_vp.CapturarSnapshot();

				BloquearControlesParaUsuarioLimitado();
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

		private void grillaPermisos_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			UtilP.OcultarColumnas(this.grillaPermisos);

			int i = 0;

			ValueList vlTipo = new ValueList();
			ValueListItem vli1 = new ValueListItem();
			vli1.DataValue = TipoPrincipalSeguridad.Rol;			
			vli1.DisplayText = "Rol";
			vli1.Appearance.Image = MarDevs.OC.Win.Properties.Resources.ImagenRol;

			vlTipo.ValueListItems.Add(vli1);
			ValueListItem vli2 = new ValueListItem();
			vli2.DataValue = TipoPrincipalSeguridad.Usuario;
			vli2.DisplayText = "Usuario";
			vli2.Appearance.Image = MarDevs.OC.Win.Properties.Resources.ImagenUsuario;
			vlTipo.ValueListItems.Add(vli2);

			UtilP.ConfigurarColumna(this.grillaPermisos, "Tipo", true, i++, "Tipo", 100, vlTipo);
			UtilP.ConfigurarColumna(this.grillaPermisos, "Descripcion", true, i++, "Usuario-Rol", 200);

			this.grillaPermisos.DisplayLayout.Bands[0].Columns["Descripcion"].SortIndicator = SortIndicator.Ascending;
		}
		private void grillaPermisos_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			PrincipalSeguridad ps = e.Row.ListObject as PrincipalSeguridad;

			if (ps != null)
			{
				e.Row.Cells["Tipo"].Value = ps.Tipo;
				e.Row.Hidden = !(ps.Activo);
			}
		}
		private void grillaParametros_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			UtilP.ConfigurarGrillaDesdeType(grillaParametros, typeof(VistaPersonalizadaParametro));
		}
		private void grillaSummaries_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			UtilP.ConfigurarGrillaDesdeType(grillaSummaries, typeof(VistaPersonalizadaSummary));
		}
		private void grillaPermisos_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.grillaPermisos.ActiveRow == null)
			{ return; }
			try
			{
				if (e.KeyCode == Keys.Delete)
				{
					if (MessageBox.Show("Desea Borrar este Permiso", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						EliminarPermiso();
					}
					else
					{
						e.Handled = true;
					}
				}
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private void grillaFormatos_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			UtilP.ConfigurarGrillaDesdeType(grillaFormatos, typeof(VistaPersonalizadaFormatoColumna));

			this.grillaFormatos.DisplayLayout.Bands[0].Columns["Columna"].CellActivation = Activation.NoEdit;
			this.grillaFormatos.DisplayLayout.Bands[0].Columns["Columna"].CellClickAction = CellClickAction.CellSelect;
			this.grillaFormatos.DisplayLayout.Bands[0].Columns["Titulo"].Nullable = Infragistics.Win.UltraWinGrid.Nullable.EmptyString;
			this.grillaFormatos.DisplayLayout.Bands[0].Columns["Formato"].Nullable = Infragistics.Win.UltraWinGrid.Nullable.EmptyString;			
			this.grillaFormatos.DisplayLayout.Bands[0].Columns["ValueList"].EditorComponent = cboEnums;
			this.grillaFormatos.DisplayLayout.Bands[0].Columns["ValueList"].CellAppearance.TextHAlign = HAlign.Left;
			this.grillaFormatos.DisplayLayout.Bands[0].Columns["Ancho"].Nullable = Infragistics.Win.UltraWinGrid.Nullable.Disallow;			
			this.grillaFormatos.DisplayLayout.Bands[0].Columns["ForeColor"].EditorComponent = cboColor;
			this.grillaFormatos.DisplayLayout.Bands[0].Columns["ForeColor"].CellAppearance.TextHAlign = HAlign.Left;
			this.grillaFormatos.DisplayLayout.Bands[0].Columns["BackColor"].EditorComponent = cboColor;
			this.grillaFormatos.DisplayLayout.Bands[0].Columns["BackColor"].CellAppearance.TextHAlign = HAlign.Left;
		}		
		private void comboTipoPermiso_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				CargarComboPermisos();
			}
			catch (Exception ex)
			{
				Mensaje.Error("Error al cargar los permisos", ex);
			}
		}
		private void FormVistaPersonalizada_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_fueCerrado == true)
			{				
				return;
			}
			this.GetNextControl(this, true).Focus();
			if (_vp.HayCambios())
			{
				if (Mensaje.Pregunta("Se han detectado cambios. Confirma que desea cancelar?") != DialogResult.Yes)
				{
					e.Cancel = true;
					return; 
				}
				_vp.DeshacerCambios();
			}		
		}
		private void txtConsulta_ValueChanged(object sender, EventArgs e)
		{
			this.botonAceptar.Enabled = false;
		}
		private void cboEntidad_ValueChanged(object sender, EventArgs e)
		{
            ArmarStringConvenciones();
			this.botonAceptar.Enabled = false;
		}
		private void cboTipoVista_ValueChanged(object sender, EventArgs e)
		{
			this.botonAceptar.Enabled = false;
		}
		private void botonAceptar_Click(object sender, EventArgs e)
		{					
			try
			{
				Cursor = Cursors.WaitCursor;
				if (Validar() == false)
				{ return; }				
				using (DL dl = DL.ObtenerSesion())
				{
					dl.IniciarTransaccion(IsolationLevel.Serializable);									
					dl.Guardar(_vp);				
					dl.ConfirmarTransaccion();
				}
				_fueCerrado = true;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{				
				Mensaje.MostrarError(ex);
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
		private void btnEjecutarConsulta_Click(object sender, EventArgs e)
		{
			try
			{
				if (String.IsNullOrWhiteSpace(_vp.Texto))
					throw new ExcepcionNegocios("No existe texto de consulta.");
				Cursor = Cursors.WaitCursor;
			
				Dictionary<string, string[]> valoresParametros = new Dictionary<string, string[]>();
				if (_vp.Parametros.Count > 0)
			{
					FormVistaPersonalizadaParametroTest fTest = new FormVistaPersonalizadaParametroTest();
					fTest.contenedorParametros1.dibujarBotonesyLabels = false;
					fTest.contenedorParametros1.VistaPersonalizada = _vp;
					fTest.Width = fTest.contenedorParametros1.Width + 110;
					fTest.btnConsultar.Visible = true;
					fTest.btnCancelar.Visible = true;
					fTest._soloLectura = false;
					if (fTest.ShowDialog() == DialogResult.Cancel)
				return;
					valoresParametros = fTest.contenedorParametros1.Valores;
			}

				string resultado = _vp.EjecutarConsulta(valoresParametros);
				Mensaje.Informacion(resultado);
				this.grillaFormatos.DataBind();
				this.ultraTabControl1.Tabs["Formatos"].Visible = _vp.TipoVista == TipoVistaPersonalizada.SQL;
				this.botonAceptar.Enabled = true;
			}
			catch (ExcepcionNegocios negEx)
			{
				Mensaje.Advertencia(negEx.Message);
			}
			catch (Exception ex)
			{
				Mensaje.Error("Se produjo un error al intentar ejecutar la consulta.", ex);
			}
			finally
			{
				Cursor = Cursors.Default;
			}			
		}
		private void btnCopiarConsulta_Click(object sender, EventArgs e)
		{
			if (this.txtConsulta.Text.Length > 0)
			{
				this.txtConsulta.Focus();
				this.txtConsulta.SelectAll();
				this.txtConsulta.Copy();
			}
		}
		private void grillaFormatos_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				#region Controla teclado

				if (this.grillaFormatos.ActiveRow == null) { return; }
				if (this.grillaFormatos.ActiveCell != null && this.grillaFormatos.ActiveCell.IsInEditMode
					&& (Keys)e.KeyValue != Keys.Enter) { return; }
				switch ((Keys)e.KeyValue)
				{
					case Keys.Up:
						this.grillaFormatos.PerformAction(UltraGridAction.ExitEditMode, false, false);
						this.grillaFormatos.PerformAction(UltraGridAction.AboveCell, false, false);
						e.Handled = true;
						this.grillaFormatos.PerformAction(UltraGridAction.ActivateCell, false, false);						
						break;
					case Keys.Down:
						this.grillaFormatos.PerformAction(UltraGridAction.ExitEditMode, false, false);
						this.grillaFormatos.PerformAction(UltraGridAction.BelowCell, false, false);
						e.Handled = true;
						this.grillaFormatos.PerformAction(UltraGridAction.ActivateCell, false, false);						
						break;
					case Keys.Left:
						this.grillaFormatos.PerformAction(UltraGridAction.ExitEditMode, false, false);
						this.grillaFormatos.PerformAction(UltraGridAction.PrevCell, false, false);
						e.Handled = true;
						this.grillaFormatos.PerformAction(UltraGridAction.ActivateCell, false, false);						
						break;
					case Keys.Right:
						this.grillaFormatos.PerformAction(UltraGridAction.ExitEditMode, false, false);
						this.grillaFormatos.PerformAction(UltraGridAction.NextCell, false, false);
						e.Handled = true;
						this.grillaFormatos.PerformAction(UltraGridAction.ActivateCell, false, false);						
						break;
					case Keys.Enter:
						this.grillaFormatos.PerformAction(UltraGridAction.ExitEditMode, false, false);
						this.grillaFormatos.PerformAction(UltraGridAction.BelowCell, false, false);
						e.Handled = true;
						this.grillaFormatos.PerformAction(UltraGridAction.ActivateCell, false, false);
						break;
					default:
						if (this.grillaFormatos.ActiveCell != null && this.grillaFormatos.ActiveCell.IsInEditMode == false)
						{
							this.grillaFormatos.PerformAction(UltraGridAction.EnterEditMode, false, false);
						}
						e.Handled = false;						
						break;
				}

				#endregion
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}

		private void CargarCombos()
		{
			try
			{
				//Combo Entidades
				UtilP.CargarComboDesdeValueList(cboEntidad, App.vlVPEntidad);

				// Combo Tipos de Vista
				UtilP.CargarComboDesdeEnum(this.cboTipoVista, typeof(TipoVistaPersonalizada));

				//Combo Tipos de Permiso
				UtilP.CargarComboDesdeEnum(this.comboTipoPermiso, typeof(TipoPrincipalSeguridad));

				this.CargarComboColor();
				this.CargarComboEnums();
			}
			catch (Exception ex)
			{
				throw new Exception("Se produjo un error al cargar la pantalla", ex);
			}
		}
		private void CargarComboPermisos()
		{			
			this.comboPermiso.Items.Clear();
			this.comboPermiso.Text = String.Empty;
			this.comboPermiso.Items.Add(null, "[Seleccione...]");

			IList<PrincipalSeguridad> lista = PrincipalSeguridad.Listar((TipoPrincipalSeguridad)comboTipoPermiso.Value);
			foreach (PrincipalSeguridad item in lista)
			{
				if (item.Activo == true)
				{
					bool encontrado = false;
					foreach (PrincipalSeguridad prv in _vp.Permisos)
					{
						if (prv != null && prv.Equals(item))
						{
							encontrado = true;
							break;
						}
					}
					if (!encontrado)
					{
						comboPermiso.Items.Add(item);
					}
				}
			}			
			this.comboPermiso.SelectedIndex = 0;
		}
		private bool Validar()
		{
			if (cboEntidad.Value == null)
			{
				Mensaje.Advertencia("Debe indicar la entidad.");
				if (this.ultraTabControl1.SelectedTab != this.ultraTabControl1.Tabs["Principal"])
					this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["Principal"];
				this.cboEntidad.Select();
				return false;
			}			
			if (String.IsNullOrEmpty(_vp.Nombre))
			{
				Mensaje.Advertencia("Debe indicar el nombre de la vista.");
				if (this.ultraTabControl1.SelectedTab != this.ultraTabControl1.Tabs["Principal"])
					this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["Principal"];
				this.txtNombre.Select();
				return false;
			}
			if (String.IsNullOrEmpty(_vp.Texto))
			{
				Mensaje.Advertencia("Debe indicar el texto de la consulta.");
				if (this.ultraTabControl1.SelectedTab != this.ultraTabControl1.Tabs["Consulta"])
					this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["Consulta"];
				this.txtConsulta.Select();
				return false;
			}			
			return true;
		}
        private void botonAgregarPermiso_Click(object sender, EventArgs e)
        {
            AgregarPermiso();
        }
        private void comboPermiso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AgregarPermiso();
        }	
		private void AgregarPermiso()
		{
            try
            {
                PrincipalSeguridad permiso = this.comboPermiso.Value as PrincipalSeguridad;
                if (permiso == null) { return; }
                _vp.Permisos.Add(permiso);
                this.CargarComboPermisos();
                this.grillaPermisos.DataBind();
            }
            catch (Exception ex)
            {
                Mensaje.Error(ex.Message, ex);
            }
		}
		private void EliminarPermiso()
		{
			_vp.Permisos.Remove(this.grillaPermisos.ActiveRow.ListObject as PrincipalSeguridad);
			this.CargarComboPermisos();
			this.grillaPermisos.DataBind();
		}		
		private void CargarComboEnums()
		{
			var query = System.Reflection.Assembly.Load("MarDevs.OC.Core").GetTypes().Where(t => t.IsEnum);
			this.cboEnums.SortStyle = ValueListSortStyle.Ascending;
			this.cboEnums.LimitToList = false;
			this.cboEnums.DropDownStyle = DropDownStyle.DropDownList;
			foreach (Type t in query)
				cboEnums.Items.Add(string.Format("{0}, {1}", t.FullName, t.Namespace), t.Name);
		}
		private void CargarComboColor()
		{
			this.cboColor.SortStyle = ValueListSortStyle.Ascending;
			this.cboColor.LimitToList = true;	
			this.cboColor.DropDownStyle = DropDownStyle.DropDownList;
			foreach (System.Reflection.PropertyInfo p in typeof(Color).GetProperties())
			{
				Color c = new Color();
				if (p.PropertyType == typeof(Color))
				{
					Color col = (Color)p.GetValue(c, null);										
					ValueListItem vli = this.cboColor.Items.Add(col.ToArgb(), col.Name);
					Bitmap bmColores = new Bitmap(15, 15, PixelFormat.Format24bppRgb);
					using (Graphics g = Graphics.FromImage(bmColores))
					{
						if (col == Color.Transparent)
							g.FillRectangle(new SolidBrush(Color.White), 0, 0, 15, 15);
						else
							g.FillRectangle(new SolidBrush(col), 0, 0, 15, 15);
					}
					vli.Appearance.Image = bmColores;
				}								
			}
		}
		private void CargarComboImagenCarpeta()
		{
			System.Resources.ResourceSet temp = MarDevs.OC.Win.Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, false, false);
			this.cboImagenes.SortStyle = ValueListSortStyle.Ascending;
			this.cboImagenes.LimitToList = true;
			this.cboImagenes.DropDownStyle = DropDownStyle.DropDown;
			foreach (System.Collections.DictionaryEntry set in temp)
            {
				if (set.Value is System.Drawing.Bitmap)
		{
					ValueListItem vli = this.cboImagenes.Items.Add(set.Key.ToString());
					vli.Appearance.Image = set.Value;
		}
            }
			this.cboImagenes.Items.Add(null, "[Seleccione...]");
		}

		private void ArmarStringConvenciones()
                {
			this.txtConvencion.Text = _vp.ObtenerConvenciones();
        }

		private void BloquearControlesParaUsuarioLimitado()
		{
			if (ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS))
			{
				return;
			}
			if (ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS_LIMITADA))
			{
				this.cboEntidad.ReadOnly = true;
				this.cboTipoVista.ReadOnly = true;
				this.btnEjecutarConsulta.Enabled = false;
				this.txtConsulta.ReadOnly = true;
				this.btnCopiarConsulta.Enabled = false;
				this.ultraTabControl1.Tabs["Parametros"].Visible = false;
				this.ultraTabControl1.Tabs["Summaries"].Visible = false;
			}
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			if (_vp.Parametros == null || _vp.Parametros.Count <= 0)
				return;
			try
			{
				FormVistaPersonalizadaParametroTest fTest = new FormVistaPersonalizadaParametroTest();
				fTest.contenedorParametros1.VistaPersonalizada = _vp;
				fTest.Width = fTest.contenedorParametros1.Width + 20;
				fTest.btnConsultar.Visible = false;
				fTest.ShowDialog();
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private T ObtenerObjetoDesdeGrilla<T>(UltraGrid gr)
		{
			T obj = default(T);
			if (gr != null && gr.ActiveRow != null)
				obj = (T)gr.ActiveRow.ListObject;
			return obj;
		}

		#region Parametros

		private void btnNuevoParametro_Click(object sender, EventArgs e)
		{
			try
			{
				FormVistaPersonalizadaParametro fVpp = new FormVistaPersonalizadaParametro(VistaPersonalizadaParametro.Crear(_vp),true);
				fVpp.ShowDialog();
				this.grillaParametros.DataBind();
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private void btnEliminarParametro_Click(object sender, EventArgs e)
		{
			try
			{
				VistaPersonalizadaParametro vpp = ObtenerObjetoDesdeGrilla<VistaPersonalizadaParametro>(grillaParametros);
				if (vpp != null && DialogResult.Yes == Mensaje.Pregunta(String.Format("Confirma que desea eliminar el parámetro {0}?", vpp.IdParametro)))
				{
				_vp.Parametros.Remove(vpp);
				this.grillaParametros.DataBind();
			}
			}
			catch (Exception ex) { Mensaje.MostrarError(ex); }
		}
		private void grillaParametros_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
				AbrirParametro();
		}
		private void grillaParametros_DoubleClick(object sender, EventArgs e)
		{
			AbrirParametro();
		}
		private void AbrirParametro()
		{
			VistaPersonalizadaParametro vpp = ObtenerObjetoDesdeGrilla<VistaPersonalizadaParametro>(grillaParametros);
			if (vpp == null)
				return;
			FormVistaPersonalizadaParametro frmParametro = new FormVistaPersonalizadaParametro(vpp);
			frmParametro.ShowDialog();
			this.grillaParametros.Refresh();
		}

		#endregion

		#region Summary

		private void btnNuevoSummary_Click(object sender, EventArgs e)
		{
			try
			{
				FormVistaPersonalizadaSummary fVpp = new FormVistaPersonalizadaSummary(VistaPersonalizadaSummary.Crear(_vp), true);
				fVpp.ShowDialog();
				this.grillaSummaries.DataBind();
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private void grillaSummaries_DoubleClick(object sender, EventArgs e)
		{
			AbrirSummary();
		}
		private void grillaSummaries_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
				AbrirSummary();
		}
		private void AbrirSummary()
			{
			VistaPersonalizadaSummary vps = ObtenerObjetoDesdeGrilla<VistaPersonalizadaSummary>(grillaSummaries);
				if (vps == null)
					return;
			FormVistaPersonalizadaSummary frmSummary = new FormVistaPersonalizadaSummary(vps);
			frmSummary.ShowDialog();
			this.grillaSummaries.Refresh();
		}

		private void btnEliminarSummary_Click(object sender, EventArgs e)
		{			
			try
			{
				VistaPersonalizadaSummary vps = ObtenerObjetoDesdeGrilla<VistaPersonalizadaSummary>(grillaSummaries);
				if (vps != null && DialogResult.Yes == Mensaje.Pregunta("Confirma que desea eliminar el summary seleccionado?"))
				{
					_vp.Summaries.Remove(vps);
					this.grillaSummaries.DataBind();
				}							
			}
			catch (Exception ex) { Mensaje.MostrarError(ex); }
		}	
		#endregion
	}
}
