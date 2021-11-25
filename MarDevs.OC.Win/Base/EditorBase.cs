using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;
using MarDevs.OC.Core;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinMaskedEdit;
using Infragistics.Win.Misc;
using System.Diagnostics;
using System.IO;

namespace MarDevs.OC.Win
{
	public partial class EditorBase: Form
	{
        protected EditorBase() : this(null) { }
        protected EditorBase(IPersistente obj)
		{
			InitializeComponent();

			this._obj = obj;

			this.Closing += new CancelEventHandler(EditorBase_Closing);
            this.ultraToolbarsManager1.BeforeToolDropdown += new BeforeToolDropdownEventHandler(ultraToolbarsManager1_BeforeToolDropdown);
			this.ultraToolbarsManager1.ToolClick += new ToolClickEventHandler(ultraToolbarsManager1_ToolClick);
            this.grillaBitacora.DoubleClickRow += new DoubleClickRowEventHandler(grillaBitacora_DoubleClickRow);
            this.ultraTabControl1.ActiveTabChanged += new ActiveTabChangedEventHandler(ultraTabControl1_ActiveTabChanged);

			this._controlesAExcluirProcesamientoSoloLectura.Add(this.txtCreadoEl);
			this._controlesAExcluirProcesamientoSoloLectura.Add(this.txtCreadoPor);
		}

		protected IPersistente _obj;
        protected string _tituloFormulario = String.Empty;
        protected string _tituloNuevaEntidad = "Nueva Entidad";
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
		protected virtual bool CalculadoraVisible
		{
			get { return this.ultraToolbarsManager1.Tools["Calculadora"].SharedProps.Visible; }
			set { this.ultraToolbarsManager1.Tools["Calculadora"].SharedProps.Visible = value; }
		}
        protected virtual bool ImprimirVisible
        {
            get { return this.ultraToolbarsManager1.Tools["Imprimir"].SharedProps.Visible; }
            set { this.ultraToolbarsManager1.Tools["Imprimir"].SharedProps.Visible = value; }
        }
		protected virtual bool GuardarYNuevoVisible
		{
			get { return this.ultraToolbarsManager1.Tools["GuardarYNuevo"].SharedProps.Visible; }
			set { this.ultraToolbarsManager1.Tools["GuardarYNuevo"].SharedProps.Visible = value; }
		}
        public virtual IPersistente obj
		{
			get { return this._obj; }
		}
		public virtual string TituloNuevaEntidad
		{
			get { return _tituloNuevaEntidad; }
			set { _tituloNuevaEntidad = value; }
		}
		public virtual bool FueGuardado
		{
			get { return _fueGuardado; }
		}

		#endregion
		
		protected virtual void EditorBase_Load(object sender, System.EventArgs e)
		{
			if (this.DesignMode) { return; }

			try
			{
				if (_obj == null)
				{
					throw new ArgumentNullException("La entidad a editar no puede ser nula.");
				}

				this.editorUltraTabControl.VisibleTabs["Auditoria"].VisibleIndex = this.editorUltraTabControl.Tabs.Count - 1;
				this.CalculadoraVisible = false;
                this.ImprimirVisible = true;
                this._controlesAExcluirProcesamientoSoloLectura.Add(this.btnExportarLog);
				this.BindearLog();

				_obj.Actualizar(true);
				//CAPTURAR EL ESTADO DEL OBJETO INTERNAMENTE PARA PODER DESHACER CAMBIOS O DETECTARLOS
				_obj.CapturarSnapshot();
				//establecer el título del formulario
				this.Text = _obj.EsNuevo()? TituloNuevaEntidad : _obj.ToString();

				//con este método los herederos insertan en este punto lógica adicional de inicialización.
				InicializarFormulario();

			}
            catch (ExcepcionNegocios nEx)
            {
                Mensaje.Advertencia(nEx.Message);
                this.Close();
            }
			catch (Exception ex)
			{
				Mensaje.Error("Se ha producido un error al intentar abrir el formulario.", ex);
				this.Close();
			}
		}
        protected virtual void ultraToolbarsManager1_BeforeToolDropdown(object sender, BeforeToolDropdownEventArgs e)
        {
        }
        protected virtual void ultraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Guardar":
					this.GuardarCambios();
                    break;
                case "GuardarYNuevo":
                    if (this.GuardarCambios())
                    {
                        this.CrearElemento();
                    }
                    break;
                case "GuardarYCerrar":
                    if (this.GuardarCambios())
                    {
                        this.Close();
                    }
                    break;
                case "Cerrar":
                    this.Close();
                    break;
                case "Imprimir":
                    this.Imprimir();
                    break;

                case "Calculadora":
                    UtilP.MostrarCalculadora();
                    break;
            }
        }
        private void ultraTabControl1_ActiveTabChanged(object sender, ActiveTabChangedEventArgs e)
        {
			if (this.DesignMode) { return; }

            this.ultraToolbarsManager1.Tools["Guardar"].SharedProps.Enabled = (e.Tab.Key.Equals("Principal") && !this.SoloLectura);
            this.ultraToolbarsManager1.Tools["GuardarYCerrar"].SharedProps.Enabled = (e.Tab.Key.Equals("Principal") && !this.SoloLectura);
        }
        private void grillaBitacora_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (e.RowArea == RowArea.Cell)
            {
                MostrarLog();
            }
        }
        protected virtual void EditorBase_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ASEGURARSE DE SACAR EL FOCO DEL CONTROL ACTUAL PARA QUE GUARDE LOS CAMBIOS
            this.GetNextControl(this, true).Focus();

            if (_soloLectura == false && _obj.HayCambios())
            {
                AvisarQueHayCambiosYProcesarRespuesta(e);
            }
        }
        private void btnExportarLog_Click(object sender, EventArgs e)
        {
            ExportarLog();
        }

		/// <summary>
		/// Este método es llamado desde el EditorBase_Load. Poner aquí cualquier código de inicialización
		/// del formulario como establecer solo lectura, verificar privilegios, cargar combos, etc.
		/// </summary>
		protected virtual void InicializarFormulario()
		{
			//NADA, ES UN MÉTODO QUE IMPLEMENTARÁN LOS HEREDEROS.
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

        protected virtual void CrearElemento()
        {
            // En el ABM Base no hay logica de negocios para Crear Elemento
        }
        protected virtual bool GuardarCambios()
        {
            //ASEGURARSE DE SACAR EL FOCO DEL CONTROL ACTUAL PARA QUE GUARDE LOS CAMBIOS
            this.GetNextControl(this, true).Focus();

            try
            {
                _obj.Guardar();
                _obj.CapturarSnapshot();
				OnObjetoGuardado(new ObjetoGuardadoEventArgs(_obj));
				_fueGuardado = true;
				BindearLog();
				Mensaje.Informacion("Los cambios han sido guardados satisfactoriamente.");
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
        protected void AvisarQueHayCambiosYProcesarRespuesta(System.ComponentModel.CancelEventArgs e)
        {
            DialogResult ResultadoPregunta = Mensaje.Pregunta(EditorBase.STR_CONFIRMACION_AL_SALIR, MessageBoxButtons.YesNoCancel);
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
                    {
						//NUEVO - DESHACER LOS CAMBIOS EN EL OBJETO
						_obj.DeshacerCambios();
                        //_obj.Actualizar(true);
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

        protected void EstablecerSoloLecturaEnControles(Control control, bool valor)
        {
            if (this._controlesAExcluirProcesamientoSoloLectura.Contains(control))
            {
                return;
            }
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
            if (control is UltraNumericEditor)
            {
                (control as UltraNumericEditor).ReadOnly = valor;
                return;
            }
            foreach (Control c in control.Controls)
            {
                this.EstablecerSoloLecturaEnControles(c, valor);
            }
        }

		private void MostrarLog()
		{
			if ( this.grillaBitacora.ActiveRow != null)
			{
				Log log = this.grillaBitacora.ActiveRow.ListObject as Log;
				if (log != null)
				{
					FormLog f = new FormLog(log);
					f.ShowDialog();
				}
			}
		}
		protected void LimpiarBindings()
		{
			UtilP.LimpiarBingingsControl(this);
		}
		protected void BindearLog()
		{
			IAuditable auditable = _obj as IAuditable;
			if (auditable != null)
			{
				this.bindingSourceLog.DataSource = auditable.ObtenerLog();
				this.txtCreadoEl.Value = auditable.CreadoEl;
				this.txtCreadoPor.Value = (auditable.CreadoPor != null) ? auditable.CreadoPor.Logon : String.Empty;

				if (this.grillaBitacora.Rows.Count > 0)
				{
					this.grillaBitacora.Rows[0].Selected = true;
				}
			}
			else
			{
				this.editorUltraTabControl.Tabs["Auditoria"].Visible = false;
			}
		}
        protected virtual void ExportarLog()
        {
            bool exito = true;
            string archivo = String.Empty;
            string carpeta = String.Empty;
            try
            {
                archivo = String.Format("tmp{0}.xls", new Random().Next(9999).ToString().PadLeft(4, Char.Parse("0")));
                archivo = Path.Combine(UtilP.CarpetaTemporal(), archivo);
                this.ultraGridExcelExporter1.Export(this.grillaBitacora, archivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar crear el archivo de Excel "
                    + archivo + ". La Exportacin no pudo realizarse." + ex.ToString(),
                    "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                exito = false;
            }
            if (exito == true)
            {
                try
                {
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = archivo;
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.RedirectStandardOutput = false;
                    myProcess.Start();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al intentar abrir el archivo generado. Posiblemente no existan en el sistema aplicaciones para abrir archivos XLS.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        protected virtual T ObtenerObjetoSeleccionadoDesdeGrilla<T>(UltraGrid gr)
        {
            return (gr.ActiveRow != null ? (T)gr.ActiveRow.ListObject : default(T));
        }
    }
}



