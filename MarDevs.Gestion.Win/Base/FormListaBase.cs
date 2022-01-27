using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MarDevs.Gestion.Core;
using Infragistics.Win.SupportDialogs.FilterUIProvider;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using SelectType = Infragistics.Win.UltraWinGrid.SelectType;

namespace MarDevs.Gestion.Win
{
	public partial class FormListaBase : FormMDIBase
	{
		public FormListaBase()
		{
			InitializeComponent();
		}

		public static FilterTool _filtrosTexto = null;

		#region MIEMBROS PRIVADOS

		protected string _TextoComandoAbrirElemento = "Abrir...";
		protected string _TextoComandoAgregarElemento = "Nuevo...";
		protected string _TextoComandoEliminarElemento = "Eliminar...";
		protected bool _PermitirAbrirElementos = true;
		protected bool _PermitirAgregarElementos;
		protected bool _PermitirEliminarElementos;
		protected bool _PermitirMultiSelect = true;
		protected bool _PermitirPersonalizarColumnas = true;
		protected bool _GuardadoHabilitado = false;
		protected int _FilaActiva = 0;
		protected int _cantidadMaximaEntidadesMostrar = 1;
		protected Type TipoEntidad { get; set; }
		protected UltraGridRow _ultimaFilaClickeada;
		protected FormPersonalizarGrilla _formPersonalizarGrilla = null;
		protected List<Accion> _acciones = new List<Accion>();

		#endregion

		#region PROPIEDADES

		public virtual bool DebeActualizarAlActivar
		{
			get { return true; }
		}
		public virtual bool PermitirAbrirElementos
		{
			get { return _PermitirAbrirElementos; }
			set
			{
				this.ultraToolbarsManager1.Tools["AbrirElemento"].SharedProps.Visible = value;
				_PermitirAbrirElementos = value;
			}
		}
		public virtual bool PermitirAgregarElementos
		{
			get { return _PermitirAgregarElementos; }
			set
			{
				this.ultraToolbarsManager1.Tools["AgregarElemento"].SharedProps.Visible = value;
				_PermitirAgregarElementos = value;
			}
		}
		public virtual bool PermitirEliminarElementos
		{
			get { return _PermitirEliminarElementos; }
			set
			{
				this.ultraToolbarsManager1.Tools["EliminarElemento"].SharedProps.Visible = value;
				_PermitirEliminarElementos = value;
			}
		}
		public virtual bool PermitirPersonalizarColumnas
		{
			get { return _PermitirPersonalizarColumnas; }
			set
			{
				_PermitirPersonalizarColumnas = value;
				if (value == false)
				{
					this.ultraGrid1.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;
					this.ultraToolbarsManager1.Tools["PersonalizarVista"].SharedProps.Visible = false;
					this.ultraToolbarsManager1.Tools["RestaurarVistaPredeterminada"].SharedProps.Visible = false;
				}

			}
		}
		protected object ObjetoActivoEnGrilla
		{
			get
			{
				if (this.ultraGrid1.ActiveRow != null &&
					!this.ultraGrid1.ActiveRow.IsGroupByRow)
				{
					return this.ultraGrid1.ActiveRow.ListObject;
				}
				else
				{
					return null;
				}
			}
		}
		/// <summary>
		/// Devuelve las entidades seleccionadas. Si la fila activa de la grilla no está seleccionada
		/// devuelve sólo el objeto activo. Si no hay filas seleccionadas o activas, devuelve una lista vacía.
		/// </summary>
		protected virtual ArrayList ElementosSeleccionados
		{
			get
			{
				ArrayList seleccionados = new ArrayList();

				if (this.ultraGrid1.Selected.Rows.Count == 0)
				{
					return seleccionados;
				}

				if (this.ultraGrid1.ActiveRow != null && !this.ultraGrid1.ActiveRow.Selected)
				{
					seleccionados.Add(this.ultraGrid1.ActiveRow.ListObject);
					return seleccionados;
				}
				foreach (UltraGridRow r in this.ultraGrid1.Selected.Rows)
				{
					if (r.ListObject != null && !r.IsFilteredOut)
					{
						seleccionados.Add(r.ListObject);
					}
				}
				return seleccionados;
			}
		}
		/// <summary>
		/// Devuelve el texto que el formulario principal debe mostrar en el panel izquierdo del status bar.
		/// </summary>
		public override string StatusBarText
		{
			get
			{
				if (ultraGrid1.Rows == null)
				{
					return String.Empty;
				}
				int visibles = ultraGrid1.Rows.FilteredInNonGroupByRowCount;

				int filtradas = 0;
				UltraGridRow[] filasFiltradas = ultraGrid1.Rows.GetFilteredOutNonGroupByRows();
				if (filasFiltradas != null)
				{
					filtradas = filasFiltradas.Length;
				}

				return String.Format("{0} elementos visibles en esta carpeta (más {1} elementos filtrados)", visibles, filtradas);
			}
		}
		/// <summary>
		/// Indica si el usuario podrá seleccionar mas de una fila simultáneamente.
		/// </summary>
		public virtual bool PermitirMultiSelect
		{
			get { return _PermitirMultiSelect; }
			set
			{
				_PermitirMultiSelect = value;
				this.ultraToolbarsManager1.Tools["SeleccionarTodo"].SharedProps.Visible = value;
			}
		}
		public string TextoComandoAbrirElemento
		{
			get { return this._TextoComandoAbrirElemento; }
			set
			{
				_TextoComandoAbrirElemento = value;
				this.ultraToolbarsManager1.Tools["AbrirElemento"].SharedProps.Caption = value;
			}
		}
		public string TextoComandoAgregarElemento
		{
			get
			{
				return this._TextoComandoAgregarElemento;
			}
			set
			{
				_TextoComandoAgregarElemento = value;
				this.ultraToolbarsManager1.Tools["AgregarElemento"].SharedProps.Caption = value;
			}
		}
		public string TextoComandoEliminarElemento
		{
			get { return _TextoComandoEliminarElemento; }
			set
			{
				_TextoComandoEliminarElemento = value;
				this.ultraToolbarsManager1.Tools["EliminarElemento"].SharedProps.Caption = value;
			}
		}
		/// <summary>
		/// Indica la cantidad máxima de entidades seleccionadas que se mostrarán sin mostrar el
		/// cartel de advertencia.
		/// </summary>
		public int CantidadMaximaEntidadesMostrar
		{
			get { return _cantidadMaximaEntidadesMostrar; }
			set { _cantidadMaximaEntidadesMostrar = value; }
		}

		#endregion

		#region METODOS

		/// <summary>
		/// Exporta a Excel la grilla creando un archivo temporal y lo muestra con el programa
		/// predeterminado del sistema operativo. Excel, OpenOffice, etc.
		/// </summary>
		protected virtual void Exportar()
		{
			bool exito = true;
			string archivo = String.Empty;
			string carpeta = String.Empty;
			try
			{
				archivo = String.Format("tmp{0}.xls", new Random().Next(9999).ToString().PadLeft(4, Char.Parse("0")));
				archivo = Path.Combine(UtilP.CarpetaTemporal(), archivo);
				this.ultraGridExcelExporter1.Export(ultraGrid1, archivo);
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
		public ButtonTool CrearToolButtonEnPopup(string pPopup, string pKey, string pCaption, bool pComenzarGrupo, Image pImagen)
		{
			return CrearToolButtonEnPopup(pPopup, pKey, pCaption, pComenzarGrupo, pImagen, null);
		}
		public ButtonTool CrearToolButtonEnPopup(string pPopup, string pKey, string pCaption, bool pComenzarGrupo, Image pImagen, object tag)
		{
			if (!this.ultraToolbarsManager1.Tools.Exists(pKey) && this.ultraToolbarsManager1.Tools.Exists(pPopup))
			{
				ButtonTool t = new ButtonTool(pKey);
				t.SharedProps.Caption = pCaption;
				t.SharedProps.Tag = tag;
				if (pImagen != null) { t.SharedProps.AppearancesSmall.Appearance.Image = pImagen; }
				this.ultraToolbarsManager1.Tools.Add(t);
				PopupMenuTool lPopup = (PopupMenuTool)this.ultraToolbarsManager1.Tools[pPopup];
				lPopup.Tools.AddTool(pKey);
				lPopup.Tools[pKey].InstanceProps.IsFirstInGroup = pComenzarGrupo;
				return t;
			}
			return null;
		}
		public void AsociarToolButtonEnPopup(string popupKey, string toolKkey, bool comenzarGrupo)
		{
			if (this.ultraToolbarsManager1.Tools.Exists(toolKkey) && this.ultraToolbarsManager1.Tools.Exists(popupKey))
			{
				PopupMenuTool lPopup = (PopupMenuTool)this.ultraToolbarsManager1.Tools[popupKey];
				lPopup.Tools.AddTool(toolKkey);
				lPopup.Tools[toolKkey].InstanceProps.IsFirstInGroup = comenzarGrupo;
			}
		}
		public virtual void AbrirElemento(object elemento)
		{
		}
		public virtual void AbrirElementos(IList elementos)
		{
		}
		/// <summary>
		/// Implementación base para Persistente, o sea, si la elemento deriva de Persistente,
		/// no es necesario hacer override del método ya que será llamado casteando a Persistente.
		/// </summary>
		/// <param name="elemento">La entidad a eliminar de la base de datos.</param>
		/// <returns></returns>
		public virtual bool EliminarElemento(object elemento)
		{
			try
			{
				if (elemento is IPersistente)
				{
					((IPersistente)elemento).Eliminar();
					return true;
				}
			}
			catch (ExcepcionEliminacion ex1)
			{
				Mensaje.Advertencia(ex1.Message);
			}
			catch (Exception ex)
			{
				Mensaje.Error(ex.Message, ex);
			}
			return false;
		}
		/// <summary>
		/// Este método es llamado cuando desde el menu de acciones se elige el tool Nuevo,
		/// los herederos deben hacer override de este método para crear una instancia de la entidad
		/// y mostrar el formulario que la edita.
		/// </summary>
		public virtual void AgregarElemento()
		{
		}
		public virtual void ActualizarListaDesdeOrigen()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				SuspenderGuardadoLayout();
				RetenerPosicionGrilla();
				object datos = RecuperarDatos();
				if (datos != null)
				{
					ultraGrid1.DataSource = datos;
					ultraGrid1.Rows.Refresh(RefreshRow.FireInitializeRow);
				}
				RestaurarPosicionGrilla();
				NotificarActualizacionStatusBarText();
			}
			catch (Exception ex)
			{
				Mensaje.Error(ex.Message, ex);
			}
			finally
			{
				HabilitarGuardadoLayout();
				this.Cursor = Cursors.Default;
			}
		}
		/// <summary>
		/// Este método es responsable de recuperar los datos de la lista de la base de datos. 
		/// Es llamado por ActualizarListaDesdeOrigen(). Para que funcione debe hacerse override
		/// desde cada heredero ya que de lo contrario tirará una excepción indicando que el método
		/// no ha sido implementado.
		/// </summary>
		/// <returns></returns>
		protected virtual object RecuperarDatos()
		{
			throw new NotImplementedException("RecuperarDatos() no ha sido implementado");
		}
		/// <summary>
		/// Este método se utiliza para inicializar la grilla luego de establecer la propiedad DataSource
		/// de la misma. Aquí se configuran las distintas columnas, el orden, look & feel de la grilla y 
		/// todo código de inicialización que no se ingrese vía diseñador. Este método es llamado
		/// cada vez que se produce el evento InitializeLayout de la grilla.
		/// </summary>
		protected virtual void InicializarGrilla()
		{
			//nada para inicializar por los herederos
		}
		/// <summary>
		/// Permite que los formularios herederos inicialicen tools, por ejemplo crear nuevos tools en el
		/// PopupAcciones. Es llamado durante el evento load de FormListaBase. A quienes hagan override
		/// de este método, deben llamar a la base para que se ejecute correctamente la inicialización de
		/// tools.
		/// </summary>
		protected virtual void InicializarToolbar()
		{
		}

		public void RetenerPosicionGrilla()
		{
			if (ultraGrid1.ActiveRow != null && !ultraGrid1.ActiveRow.IsFilterRow)
			{
				_FilaActiva = ultraGrid1.ActiveRow.Index;
			}
		}
		public void RestaurarPosicionGrilla()
		{
			RestaurarPosicionGrilla(true);
		}
		public void RestaurarPosicionGrilla(bool seleccionarActiva)
		{
			if (ultraGrid1.Rows != null)
			{
				if (_FilaActiva >= 0 && _FilaActiva < this.ultraGrid1.Rows.Count)
				{
					this.ultraGrid1.Rows[_FilaActiva].Activate();
					if (seleccionarActiva)
					{
						this.ultraGrid1.ActiveRow.Selected = true;
					}
				}
				else
				{
					if (this.ultraGrid1.Rows.Count > 0)
					{
						this.ultraGrid1.Rows[this.ultraGrid1.Rows.Count - 1].Activate();
						if (seleccionarActiva)
						{
							this.ultraGrid1.ActiveRow.Selected = true;
						}
					}
				}
			}
		}
		protected void PosicionarseEnPrimerFila()
		{
			if (this.ultraGrid1.Rows != null && this.ultraGrid1.Rows.Count > 0)
			{
				this.ultraGrid1.Selected.Rows.Clear();
				this.ultraGrid1.Rows[0].Selected = true;
			}

		}
		protected void AutoAjustarColumnas()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.SuspenderGuardadoLayout();
				foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
				{
					//para evitar que acceda a las Property's que son colecciones
					if (!col.IsChaptered && col.IsVisibleInLayout && !col.LockedWidth)
					{
						col.PerformAutoResize(PerformAutoSizeType.AllRowsInBand);
					}
				}
				this.HabilitarGuardadoLayout();
				this.GuardarLayout();
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private bool ProcesarAccion(string accion)
		{
			bool resultado = true;
			this.Cursor = Cursors.WaitCursor;
			try
			{
				this.RetenerPosicionGrilla();
				//this.ultraGrid1.BeginUpdate();
				switch (accion)
				{
					case "Actualizar":
						this.ActualizarListaDesdeOrigen();
						this.NotificarActualizacionStatusBarText();
						break;

					case "AutoAjustarColumnas":
						this.AutoAjustarColumnas();
						break;

					case "AbrirElemento":
						UltraGridRow r = ultraGrid1.ActiveRow;
						if (r != null && !r.IsGroupByRow && !r.Selected && r.ListObject != null)
						{
							AbrirElemento(r.ListObject);
						}
						else if (ultraGrid1.Selected.Rows.Count == 1)
						{
							if (ultraGrid1.Selected.Rows[0].ListObject != null)
							{
								AbrirElemento(ultraGrid1.Selected.Rows[0].ListObject);
							}
						}
						else if (ultraGrid1.Selected.Rows.Count > 1)
						{
							IList lista = new ArrayList();
							foreach (UltraGridRow row in ultraGrid1.Selected.Rows)
							{
								if (row.ListObject != null)
								{
									lista.Add(row.ListObject);
								}
							}
							AbrirElementos(lista);
						}
						break;

					case "AgregarElemento":

						this.AgregarElemento();
						break;

					case "EliminarElemento":

						object obj = this.ObjetoActivoEnGrilla;
						if (PermitirEliminarElementos && obj != null && Mensaje.Pregunta("Está seguro que desea eliminar el elemento seleccionado?") == DialogResult.Yes && this.EliminarElemento(obj) == true)
						{
							//this.WorkArroundDeleteUltimaFila();
							//this.bindingSource1.Remove(obj); en desuso
							if ((this.ultraGrid1.DataSource as IList) != null)
								(this.ultraGrid1.DataSource as IList).Remove(obj);
							else if (obj is System.Data.DataRowView)
								(obj as System.Data.DataRowView).Delete();
							this.ultraGrid1.Rows.Refresh(RefreshRow.ReloadData);
						}
						break;

					case "VistaPrevia":
						this.ultraGrid1.PrintPreview();
						break;

					case "Exportar":
						this.Exportar();
						break;

					case "Imprimir":
						this.ultraGrid1.Print();
						break;
				}
				this.RestaurarPosicionGrilla();
			}
			catch (ExcepcionEliminacion exe)
			{
				Mensaje.Advertencia(exe.Message);
			}
			catch (ExcepcionNegocios exn)
			{
				Mensaje.Advertencia(exn.Message);
			}
			catch (Exception ex)
			{
				Mensaje.Error(ex.Message, ex);
			}

			this.Cursor = Cursors.Default;
			return resultado;
		}
		protected void NotificarActualizacionStatusBarText()
		{
			this.OnActualizarStatusBarText(new EventArgs());
		}
		public void WorkArroundDeleteUltimaFila()
		{
			if (this.ultraGrid1.ActiveRow != null && this.ultraGrid1.ActiveRow.ListIndex == this.ultraGrid1.Rows.Count - 1 && this.ultraGrid1.Rows.Count > 1)
			{
				this.ultraGrid1.Rows[this.ultraGrid1.ActiveRow.Index - 1].Activate();
			}
		}
		protected void GuardarLayout()
		{
			if (!this._GuardadoHabilitado)
			{
				return;
			}

			try
			{
				string archivo = ObtenerNombreArchivoLayout();
				LayoutGrilla layout = UtilP.CrearLayoutGrilla(this.ultraGrid1);
				UtilP.SerializarLayoutGrilla(layout, archivo);
			}
			catch
			{
			}

		}
		/// <summary>
		/// Guarda el estado de los paneles dockeados con el ultraDockManager1 si es que hay paneles para guardar
		/// utiliza el mecanismo de guardado interno del ultraDockManager
		/// </summary>
		protected void GuardarDocking()
		{
			try
			{
				//guardar la configuracion de docking si es que hay controles dockeados
				if (ultraDockManager1.ControlPanes.Count > 0)
				{
					string carpeta = UtilP.CarpetaConfiguracion();
					if (!Directory.Exists(carpeta))
					{
						Directory.CreateDirectory(carpeta);
					}
					ultraDockManager1.SaveAsXML(ObtenerNombreArchivoDockManager());
				}
			}
			catch
			{
				//Mensaje.Advertencia(String.Format("No se pudo guardar la configuración de paneles.\n{0}", ex.ToString()));
			}
		}

		/// <summary>
		/// Obtiene el nombre y path completo del archivo de layout
		/// </summary>
		/// <returns></returns>
		protected virtual string ObtenerNombreArchivoLayout()
		{
			string archivo = Path.Combine(CarpetaConfiguracion(), this.Key + ".xml");
			return archivo;
		}
		protected virtual string ObtenerNombreArchivoDockManager()
		{
			return Path.Combine(CarpetaConfiguracion(), this.Key + "_DockManagerSettings.xml");
		}
		protected virtual void CargarLayout()
		{
			this.SuspenderGuardadoLayout();
			UltraGridBand banda = this.ultraGrid1.DisplayLayout.Bands[0];
			try
			{
				string archivo = ObtenerNombreArchivoLayout();
				if (!File.Exists(archivo))
				{
					return;
				}
				LayoutGrilla layout = UtilP.DeserializarLayoutGrilla(archivo);
				ultraGrid1.DisplayLayout.ViewStyleBand = (layout.PanelAgrupacion) ? ViewStyleBand.OutlookGroupBy : ViewStyleBand.Horizontal;
				UltraGridColumn columna = null;
				banda.SortedColumns.Clear();
				foreach (LayoutColumna lcol in layout.Columnas)
				{
					if (banda.Columns.Exists(lcol.Nombre))
					{
						columna = banda.Columns[lcol.Nombre];
						if (columna.ExcludeFromColumnChooser != ExcludeFromColumnChooser.True)
						{
							columna.Hidden = !lcol.Visible;
							columna.Header.VisiblePosition = lcol.Posicion;
							columna.Width = lcol.Ancho;
							if (lcol.EsGroupBy || lcol.Orden > 0)
							{
								banda.SortedColumns.Add(lcol.Nombre, (lcol.Orden == 2), lcol.EsGroupBy);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Mensaje.Error(ex.Message, ex);
			}
			finally
			{
				this.HabilitarGuardadoLayout();
			}
		}
		protected void HabilitarGuardadoLayout()
		{
			this._GuardadoHabilitado = true;
		}
		protected void SuspenderGuardadoLayout()
		{
			this._GuardadoHabilitado = false;
		}
		protected void RestaurarVistaPredeterminada()
		{
			if (_PermitirPersonalizarColumnas == false)
			{
				return;
			}
			try
			{
				string archivo = ObtenerNombreArchivoLayout();
				if (File.Exists(archivo))
				{
					File.Delete(archivo);
				}
				ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Clear();
				this.InicializarGrilla();
				string archivoDocking = ObtenerNombreArchivoDockManager();
				if (File.Exists(archivoDocking))
				{
					File.Delete(archivoDocking);
				}
			}
			catch (Exception ex)
			{
				Mensaje.Advertencia(ex.ToString());
			}

		}
		protected void EstablecerTextoFiltroGrilla()
		{
			//guardar los filtros activos
			ArrayList filtros = new ArrayList();
			this.labelFiltro.Text = String.Empty;

			//bool primerFiltro = true;
			foreach (ColumnFilter c in this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters)
			{
				foreach (FilterCondition fc in c.FilterConditions)
				{
					filtros.Add(fc);
					break;
					//if (fc.CompareValue != null && !(fc.CompareValue is DBNull))
					//{
					//	//this.labelFiltro.Text += ((primerFiltro) ? "Filtros aplicados: " : (c.LogicalOperator == FilterLogicalOperator.And ? " Y " : " O ")) + fc.Column.Key + " " + DescripcionComparisionOperator(fc.ComparisionOperator) + " " + this.TextoFiltroColumna(fc.CompareValue);
					//	primerFiltro = false;
					//}
				}
			}
			this.panel1.Visible = (this.labelFiltro.Text.Length > 0);
			this.ultraToolbarsManager1.Tools["RemoverFiltros"].SharedProps.Visible = (filtros.Count > 0);
		}
		protected string DescripcionComparisionOperator(FilterComparisionOperator op)
		{
			switch (op)
			{
				case FilterComparisionOperator.Equals:
					return "=";
				case FilterComparisionOperator.GreaterThan:
					return ">";
				case FilterComparisionOperator.GreaterThanOrEqualTo:
					return ">=";
				case FilterComparisionOperator.LessThan:
					return "<";
				case FilterComparisionOperator.LessThanOrEqualTo:
					return "<=";
				case FilterComparisionOperator.Like:
					return " Como ";
				case FilterComparisionOperator.NotEquals:
					return "<>";
				case FilterComparisionOperator.Contains:
					return "Contiene";
				case FilterComparisionOperator.DoesNotContain:
					return "No contiene";
				case FilterComparisionOperator.DoesNotEndWith:
					return "No termina en";
				case FilterComparisionOperator.DoesNotStartWith:
					return "No comienza por";
				case FilterComparisionOperator.EndsWith:
					return "Termina en";
				case FilterComparisionOperator.StartsWith:
					return "Comienza por";

				default:
					return String.Empty;
			}
		}
		protected string TextoFiltroColumna(object valor)
		{
			if (valor is DBNull)
			{
				return "DBNULL";
			}
			if (valor is DateTime)
			{
				return String.Format("'{0:dd/MM/yyyy HH:mm}'", (DateTime)valor);
			}
			return String.Format("'{0}'", valor);
		}
		protected virtual void ConfigurarImpresion(CancelablePrintEventArgs e)
		{
			e.DefaultLogicalPageLayoutInfo.FitWidthToPages = 1;
			e.PrintDocument.DefaultPageSettings.Landscape = true;
			e.PrintLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			e.PrintLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
			e.PrintLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;

			//encabezado
			e.DefaultLogicalPageLayoutInfo.PageHeader = this.Text + Environment.NewLine + this.labelFiltro.Text;
			e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40;
			//e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14;

			//pie de pagina

			e.DefaultLogicalPageLayoutInfo.PageFooter = String.Format("{0} - Impreso el {1} por el usuario {2}",
			UtilP.NombreProducto(),
			DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
			ConfigBL.ticket.UsuarioLogon);

			e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

		}
		protected virtual string CarpetaConfiguracion()
		{
			return UtilP.CarpetaConfiguracion();
		}
		/// <summary>
		/// Fuerza que se dispare nuevamente el evento InitializeRow
		/// </summary>
		protected void RefrescarGrilla()
		{
			ultraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.FireInitializeRow);
		}

		private void RemoverFiltros()
		{
			this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
			this.EstablecerTextoFiltroGrilla();
			this.NotificarActualizacionStatusBarText();
		}
		/// <summary>
		/// Copia las filas seleccionadas al portapapeles de Windows
		/// </summary>
		protected virtual void CopiarSeleccion()
		{
			try
			{

				if (ultraGrid1.Selected.Rows.Count == 0)
				{
					return;
				}

				System.Text.StringBuilder sbCSV = new System.Text.StringBuilder();

				//armar una lista ordenada por posicion, solo de las columnas visibles
				SortedList listaColumnas = new SortedList();
				foreach (UltraGridColumn c in ultraGrid1.DisplayLayout.Bands[0].Columns)
				{
					if ((!c.IsChaptered) && c.IsVisibleInLayout)
					{
						listaColumnas.Add(c.Header.VisiblePosition, c);
					}
				}
				//copiar fila de titulos
				UltraGridColumn col;
				foreach (DictionaryEntry de in listaColumnas)
				{
					col = de.Value as UltraGridColumn;
					if (col == null) { continue; }
					sbCSV.Append(col.Header.Caption.Replace(Environment.NewLine, " ") + "	").Replace("\n", " ");
				}
				sbCSV.Append(Environment.NewLine);

				#region COPIAR LAS FILAS SELECCIONADAS

				foreach (UltraGridRow r in ultraGrid1.Selected.Rows)
				{
					if (r.IsGroupByRow || !r.Selected) { continue; }

					UltraGridCell celda;
					foreach (DictionaryEntry de in listaColumnas)
					{
						celda = r.Cells[de.Value as UltraGridColumn];
						if (celda == null) { continue; }

						if ((!celda.Column.IsChaptered) && celda.Column.IsVisibleInLayout)
						{
							if (celda.Value != null)
							{
								switch (celda.Value.GetType().ToString())
								{
									case "System.Boolean":
										sbCSV.Append((((bool)celda.Value) ? "Verdadero" : "Falso") + "	");
										break;

									case "System.DateTime":

										DateTime fecha = (DateTime)celda.Value;
										if (fecha == DateTime.MinValue)
										{
											sbCSV.Append(String.Empty + "	");
										}
										else
										{
											sbCSV.Append(((DateTime)celda.Value).ToString(celda.Column.Format) + "	");
										}
										break;

									default:
										sbCSV.Append(celda.Text + "	");
										break;
								}
							}
							else
							{
								sbCSV.Append("	");
							}
						}
					}
					sbCSV.Append(Environment.NewLine);
				}

				#endregion

				Clipboard.SetDataObject(sbCSV.ToString());
			}
			catch (Exception ex)
			{
				Mensaje.Error("Se ha producido un error al intentar copiar las filas seleccionadas al portapapeles.", ex);
			}

		}
		protected virtual void SeleccionarTodo()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				ultraGrid1.BeginUpdate();
				RetenerPosicionGrilla();
				ultraGrid1.Selected.Rows.Clear();
				foreach (UltraGridRow row in ultraGrid1.Rows.GetFilteredInNonGroupByRows())
				{
					row.Selected = true;
				}
			}
			finally
			{
				RestaurarPosicionGrilla(false);
				ultraGrid1.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}


		#endregion

		#region CONTROLADORES DE EVENTOS

		protected override void InicializarFormulario()
		{
			base.InicializarFormulario();
			InicializarToolbar();

			//configurar componente de filtrado
			this.ultraGrid1.DisplayLayout.Override.FilterUIProvider = this.ultraGridFilterUIProvider1;
			this.ultraGridFilterUIProvider1.ViewStyle = Infragistics.Win.SupportDialogs.FilterUIProvider.FilterUIProviderViewStyle.Office2007;
			this.ultraGridFilterUIProvider1.AfterMenuPopulate += ultraGridFilterUIProvider1_AfterMenuPopulate;

			//es critico cargar el layout del dockmanager luego de crear los tools en el menu Ver
			//si se hace al revez, los tools por alguna extraña razón desaparecen
			//si existen controles dockeados, cargar la configuracion y fallar silencioso
			if (ultraDockManager1.ControlPanes.Count > 0)
			{
				try
				{
					ultraDockManager1.LoadFromXML(ObtenerNombreArchivoDockManager());
					//asegurarnos que estan correctos los paneles luego de cargar de xml.
					VerificarPaneles();
					//cargar los tools de los paneles
					int muleto = Convert.ToInt32(Shortcut.Ctrl0);
					foreach (DockableControlPane pane in ultraDockManager1.ControlPanes)
					{
						ButtonTool tool = CrearToolButtonEnPopup("PopupVer", pane.Control.Name, pane.Text, false, UtilP.TraerRecurso("ImagenPanel") as Image, pane.Control);
						tool.SharedProps.Shortcut = (Shortcut)muleto++;
					}
				}
				catch
				{
				}
			}
		}
		protected virtual void VerificarPaneles()
		{
			//nada, para q lo utilicen los herederos.
		}
		protected virtual void FormListaBase_FormClosed(object sender, FormClosedEventArgs e)
		{
			GuardarDocking();
		}
		protected virtual void FormListaBase_Deactivate(object sender, EventArgs e)
		{
			GuardarDocking();
		}

		protected void UltraGrid1_BeforeColumnChooserDisplayed(object sender, BeforeColumnChooserDisplayedEventArgs e)
		{
			if (_PermitirPersonalizarColumnas == true)
			{
				try
				{
					if (_formPersonalizarGrilla == null)
					{
						_formPersonalizarGrilla = new FormPersonalizarGrilla(ultraGrid1);
					}
					_formPersonalizarGrilla.Show();
				}
				catch (Exception ex)
				{
					Mensaje.Error("Al intentar abrir el selector de columnas se ha producido un error.", ex);
				}
				finally
				{
					e.Cancel = true;
				}
			}
		}
		protected virtual void UltraGrid1_InitializeRow(object sender, InitializeRowEventArgs e)
		{
			//foreach (UltraGridCell cell in e.Row.Cells)
			//{
			//    if (cell.Column.DataType.Name == "DateTime" && cell.Value is DateTime)
			//    {
			//        if (((DateTime)cell.Value) == DateTime.MinValue)
			//        {
			//            cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
			//        }
			//        else
			//        {
			//            cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
			//        }
			//    }
			//}
		}
		private void UltraGrid1_InitializeGroupByRow(object sender, Infragistics.Win.UltraWinGrid.InitializeGroupByRowEventArgs e)
		{
			//			e.Row.ExpandAll();
		}
		private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			if (this.DesignMode)
			{
				return;
			}
			this.SuspenderGuardadoLayout();

			this.InicializarGrilla();

			//ALMACENAR EL LAYOUT PARA RECUPERARLO LUEGO AL RESTABLECER VISTA PREDETERMINADA
			//if (_layoutPredeterminado == null)
			//{
			//    _layoutPredeterminado = this.ultraGrid1.DisplayLayout.Clone(PropertyCategories.All);
			//}

			if (this._PermitirPersonalizarColumnas)
			{
				this.CargarLayout();
			}
			//PERMITIR SINGLE O MULTI SELECT
			if (this._PermitirMultiSelect == true)
				this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
			else
				this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single;

			this.EstablecerTextoFiltroGrilla();

			this.HabilitarGuardadoLayout();
		}

		private void UltraGrid1_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
		{
			if (this.ultraGrid1.Selected.Rows.Count > 0)
			{
				this.ultraGrid1.ActiveRow = this.ultraGrid1.Selected.Rows[this.ultraGrid1.Selected.Rows.Count - 1];
			}
		}
		private void UltraGrid1_BeforePrint(object sender, Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
		{
			this.printDialog1.Document = e.PrintDocument;
			if (this.printDialog1.ShowDialog() != DialogResult.OK)
			{
				e.Cancel = true;
			}
		}
		private void UltraGrid1_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
		{
			e.DisplayPromptMsg = false;
			if (this.PermitirEliminarElementos == false)
			{
				e.Cancel = true;
				return;
			}
			if (ProcesarAccion("EliminarElemento") == false)
			{
				e.Cancel = true;
				return;
			}
			e.Cancel = true;
		}
		private void UltraGrid1_AfterRowFilterChanged(object sender, AfterRowFilterChangedEventArgs e)
		{
			this.NotificarActualizacionStatusBarText();
			this.EstablecerTextoFiltroGrilla();
			//nuevo
			this.ultraGrid1.Selected.Rows.Clear();
		}
		private void UltraGrid1_AfterRowInsert(object sender, RowEventArgs e)
		{
			this.NotificarActualizacionStatusBarText();
		}
		private void UltraGrid1_AfterRowsDeleted(object sender, EventArgs e)
		{
			this.NotificarActualizacionStatusBarText();
		}
		private void UltraGrid1_AfterSortChange(object sender, BandEventArgs e)
		{
			this.GuardarLayout();
		}
		private void UltraGrid1_AfterColPosChanged(object sender, AfterColPosChangedEventArgs e)
		{
			this.GuardarLayout();
		}
		private void UltraGrid1_AfterGroupPosChanged(object sender, AfterGroupPosChangedEventArgs e)
		{
			this.GuardarLayout();
		}
		private void UltraGrid1_AfterColRegionSize(object sender, ColScrollRegionEventArgs e)
		{
			//			this.GuardarLayout();
		}
		private void UltraGrid1_InitializePrint(object sender, CancelablePrintEventArgs e)
		{
			this.ConfigurarImpresion(e);
		}
		private void UltraGrid1_InitializePrintPreview(object sender, CancelablePrintPreviewEventArgs e)
		{
			this.ConfigurarImpresion(e);

		}

		private void ultraGridFilterUIProvider1_AfterMenuPopulate(object sender, AfterMenuPopulateEventArgs e)
		{
			// AGREGAR FILTROS DE TEXTO EN SUBCLASES DE NegocioBase
			if (e.ColumnFilter.Column.DataType.IsSubclassOf(typeof(MarDevs.Gestion.Core.NegocioBase)) && _filtrosTexto != null && e.MenuItems.Contains(_filtrosTexto) == false)
			{
				e.MenuItems.Insert(1, _filtrosTexto);
			}
			// AGREGAR FILTROS DE TEXTO EN COLUMNAS QUE USAN VALUELIST
			if (e.ColumnFilter.Column.ValueList != null && _filtrosTexto != null && e.MenuItems.Contains(_filtrosTexto) == false)
			{
				e.MenuItems.Insert(1, _filtrosTexto);
			}
			//ELIMINAR FILTROS NUMERICOS EN COLUMNAS QUE USAN VALUELIST
			if (e.ColumnFilter.Column.ValueList != null)
			{
				foreach (FilterTool t in e.MenuItems)
				{
					if (t.Id == "Number Filters")
					{
						e.MenuItems.Remove(t);
						break;
					}
				}
			}
		}

		protected virtual void UltraToolbarsManager1_BeforeToolDropdown(object sender, BeforeToolDropdownEventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (e.Tool.Key.Equals("PopupVer"))
				{
					ButtonTool bt = null;
					//status del check panel de agrupacion
					StateButtonTool t = this.ultraToolbarsManager1.Tools["VerPanelDeAgrupacion"] as StateButtonTool;
					if (t != null)
					{
						t.Checked = (this.ultraGrid1.DisplayLayout.ViewStyleBand == ViewStyleBand.OutlookGroupBy);
					}
					bt = this.ultraToolbarsManager1.Tools["ContraerTodo"] as ButtonTool;
					if (bt != null)
					{
						bt.SharedProps.Enabled = (this.ultraGrid1.DisplayLayout.ViewStyleBand == ViewStyleBand.OutlookGroupBy);
					}
					bt = this.ultraToolbarsManager1.Tools["ExpandirTodo"] as ButtonTool;
					if (bt != null)
					{
						bt.SharedProps.Enabled = (this.ultraGrid1.DisplayLayout.ViewStyleBand == ViewStyleBand.OutlookGroupBy);
					}
				}
				if (e.Tool.Key.Equals("PopupAcciones"))
				{
					IList<Accion> accionesPermitidas = ServicioMD.Instancia.EvaluarAccionesEntidad(_acciones, this.ElementosSeleccionados);
					ServicioUI.Instancia.HabilitarAcciones(this.ultraToolbarsManager1, accionesPermitidas);
				}
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		private void ultraGridExcelExporter1_CellExported(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs e)
		{
			string tipo = String.Empty;
			if (e.Value != null) { tipo = e.Value.GetType().FullName; }
			switch (tipo)
			{
				case "System.DateTime":
				case "System.Decimal":
				case "System.Int32":
					if (e.GridColumn.Format != null)
					{
						e.CurrentWorksheet.Rows[e.CurrentRowIndex].Cells[e.CurrentColumnIndex].CellFormat.FormatString = e.GridColumn.Format.ToLower();
					}
					break;
			}

		}
		private void ultraGridExcelExporter1_CellExporting(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.CellExportingEventArgs e)
		{
			if (e.Value != null && e.Value.GetType().FullName == "System.DateTime" && ((DateTime)e.Value) == DateTime.MinValue)
			{
				e.Cancel = true;
			}
		}
		private void ultraGridExcelExporter1_HeaderCellExporting(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.HeaderCellExportingEventArgs e)
		{
		}

		#region GESTION DEL DOBLE CLIC, ENTER, DELETE Y TOOLCLIC

		private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
		{
			if (e.RowArea == RowArea.Cell)
			{
				ProcesarAccion("AbrirElemento");
			}
		}
		private void UltraGrid1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Infragistics.Win.UIElement aUIElement;
			aUIElement = ultraGrid1.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));

			if (aUIElement != null)
			{
				this._ultimaFilaClickeada = (UltraGridRow)aUIElement.GetContext(typeof(UltraGridRow));

				if (this._ultimaFilaClickeada != null)
				{
					if (e.Button == MouseButtons.Right)
					{
						this._ultimaFilaClickeada.Activate();
						//						this.UltimaFilaClickeada.Selected = true;
					}
				}
			}

		}
		private void UltraGrid1_MouseMove(object sender, MouseEventArgs e)
		{
			if (this._ultimaFilaClickeada != null && e.Button == MouseButtons.Left)
			{
				this.ultraGrid1.DoDragDrop(1, DragDropEffects.None);
			}

		}
		private void UltraGrid1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			switch ((Keys)e.KeyChar)
			{
				case Keys.Enter:

					ProcesarAccion("AbrirElemento");
					break;

				case Keys.Delete:

					ProcesarAccion("EliminarElemento");
					break;
			}
		}
		protected virtual void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			//SI EN EL TAG HAY UNA ACCION, LA PROCESAMOS
			Accion accion = e.Tool.SharedProps.Tag as Accion;
			if (accion != null) { ProcesarAccion(accion); }

			//SI EN EL TAG HAY UN CONTROL, SIGNIFICA QUE ES UN PANEL DOCKEABLE
			else if (e.Tool.SharedProps.Tag is Control)
			{
				MostrarDockableControlPane(e.Tool.SharedProps.Tag as Control);
				return;
			}

			switch (e.Tool.Key)
			{
				case "Buscar":

					FormBuscar formBuscar = new FormBuscar(ultraGrid1);
					formBuscar.ShowDialog();
					break;

				case "VerPanelDeAgrupacion":

					Infragistics.Win.UltraWinToolbars.StateButtonTool t = (Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool;
					if (t.Checked == true)
					{
						this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
					}
					else
					{
						this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
					}
					if (this.ultraGrid1.ActiveRow != null)
					{
						this.ultraGrid1.ActiveRow.Selected = true;
					}
					this.GuardarLayout();
					break;

				case "AutoAjustarColumnas":

					this.AutoAjustarColumnas();
					break;

				case "ExpandirTodo":

					this.ultraGrid1.Rows.ExpandAll(true);
					break;

				case "ContraerTodo":

					this.ultraGrid1.Rows.CollapseAll(true);
					break;

				case "RestaurarVistaPredeterminada":

					this.RestaurarVistaPredeterminada();
					break;

				case "RemoverFiltros":
					this.RemoverFiltros();
					break;

				case "Copiar":
					this.CopiarSeleccion();
					break;

				case "SeleccionarTodo":

					this.SeleccionarTodo();
					break;

				case "PersonalizarVista":
					ultraGrid1.ShowColumnChooser(true);
					break;

				default:

					ProcesarAccion(e.Tool.Key);
					break;
			}
		}

		protected virtual void MostrarDockableControlPane(Control control)
		{
			ultraDockManager1.ControlPanes[control].Show();
			ultraDockManager1.ControlPanes[control].Activate();
		}
		protected virtual void ProcesarAccion(Accion accion)
		{
			try
			{
				switch (accion.Tipo)
				{
					case TipoAccion.AbrirForm:
						DialogResult resultado = ServicioUI.Instancia.ProcesarAccion(accion, ElementosSeleccionados);
						if (resultado != DialogResult.OK)
						{
							return;
						}
						break;
					case TipoAccion.EjecutarMetodo:
						MemberInfo[] miembros = this.GetType().GetMember(accion.FormAsociado);
						if (miembros.Length == 0)
						{
							throw new Exception("No se encuentra el metodo " + accion.FormAsociado);
						}
						MethodInfo info = miembros[0] as MethodInfo;
						if (info != null)
						{
							object resu = info.Invoke(this, null);
							if (!(resu is Boolean))
							{
								return;
							}
							if ((bool)resu == false)
							{
								return;
							}
						}
						break;
				}

			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
			ActualizarListaDesdeOrigen();
			ultraGrid1.Rows.Refresh(RefreshRow.FireInitializeRow);

		}

		#endregion

		private void btnActualizarDatos_Click(object sender, EventArgs e)
		{
			ActualizarListaDesdeOrigen();
		}

		#endregion

		private void btnRestablecerParametros_Click(object sender, EventArgs e)
		{
			RestablecerParametros();
		}

		protected virtual void RestablecerParametros()
		{
			//nada, a implementar por herederos
		}

	}
}
