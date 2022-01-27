using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MarDevs.Gestion.Core;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.Collections;
using Infragistics.Win.UltraWinToolbars;

namespace MarDevs.Gestion.Win
{
	public partial class ControlSeguimiento : UserControl
	{
		public ControlSeguimiento()
		{
			InitializeComponent();

			this.Load += new EventHandler(ControlSeguimiento_Load);
			this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(ultraGrid1_InitializeLayout);
			this.ultraGrid1.InitializeRow += new InitializeRowEventHandler(ultraGrid1_InitializeRow);
			this.ultraGrid1.DoubleClickRow += new DoubleClickRowEventHandler(ultraGrid1_DoubleClickRow);
			this.ultraToolbarsManager1.ToolClick += new ToolClickEventHandler(ultraToolbarsManager1_ToolClick);

			MarcaSeguimiento.MarcaSeguimientoModificada += new MarcaSeguimientoModificadaEventHandler(MarcaSeguimiento_MarcaSeguimientoModificada);
		}

		private void AbrirEntidad()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;

				if (this.ultraGrid1.ActiveRow != null && this.ultraGrid1.ActiveRow.ListObject is MarcaSeguimiento)
				{
					MarcaSeguimiento marca = this.ultraGrid1.ActiveRow.ListObject as MarcaSeguimiento;
                    IPersistente entidad = marca.LeerEntidad();
					if (entidad != null)
						App.MostrarEntidad(entidad);
				}
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

		private List<MarcaSeguimiento> _lista = new List<MarcaSeguimiento>();
		protected IList ElementosSeleccionados
		{
			get
			{
				ArrayList seleccionados = new ArrayList();

				if (this.ultraGrid1.Selected.Rows.Count == 0)
				{
					return seleccionados;
				}
				if (this.ultraGrid1.ActiveRow != null && !this.ultraGrid1.ActiveRow.Selected && this.ultraGrid1.ActiveRow.ListObject is MarcaSeguimiento)
				{
					seleccionados.Add(this.ultraGrid1.ActiveRow.ListObject);
					return seleccionados;
				}
				foreach (UltraGridRow r in this.ultraGrid1.Selected.Rows)
				{
					if ((r.ListObject is MarcaSeguimiento) && !r.IsFilteredOut)
					{
						seleccionados.Add(r.ListObject);
					}
				}
				return seleccionados;
			}
		}

		private void ControlSeguimiento_Load(object sender, EventArgs e)
		{
			if (DesignMode) { return; }
			try
			{
				App.CrearToolsSeguimiento(this.ultraToolbarsManager1.Tools["PopupAcciones"] as PopupMenuTool, false);

				//cargar combo
				ComboBoxTool combo = this.ultraToolbarsManager1.Tools["OrganizarPor"] as ComboBoxTool;
				if (combo != null)
				{
					combo.ValueList.ValueListItems.Add("FechaSeguimiento", "Vencimiento");
					combo.ValueList.ValueListItems.Add("EntidadTipo", "Tipo de Entidad");
					combo.ValueList.ValueListItems.Add("Imagen", "Marca");

					combo.Value = "FechaSeguimiento";

					combo.ToolValueChanged += new ToolEventHandler(combo_ToolValueChanged);
				}

				this.ultraGrid1.DataSource = _lista;
				Actualizar();
				this.ultraGrid1.Rows.ExpandAll(true);
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private void combo_ToolValueChanged(object sender, ToolEventArgs e)
		{
			ComboBoxTool combo = this.ultraToolbarsManager1.Tools["OrganizarPor"] as ComboBoxTool;
			if (combo != null)
			{
				string columna = (combo.Value != null) ? combo.Value.ToString() : String.Empty;
				UltraGridBand banda = this.ultraGrid1.DisplayLayout.Bands[0];
				if (banda.Columns.Exists(columna))
				{
					banda.SortedColumns.Clear();
					banda.SortedColumns.Add(columna, true, true);
					this.ultraGrid1.Rows.ExpandAll(true);
				}
			}
		}
		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			this.ultraGrid1.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
			this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
			this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
			this.ultraGrid1.DisplayLayout.Override.GroupByRowDescriptionMask = "[value]";

			UtilP.OcultarColumnas(this.ultraGrid1);
			UltraGridColumn col;
			col = UtilP.ConfigurarColumna(ultraGrid1, "Imagen", true, 0, "S", 15);
			col.ValueList = UtilP.CargarValueListDesdeEnum(typeof(ImagenSeguimiento));
			col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
			col.LockedWidth = true;
			col.Header.Fixed = true;
			col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			col.Header.ToolTipText = "Marca de seguimiento";

			ValueList vlAviso = new ValueList();
			ValueListItem vlItem = vlAviso.ValueListItems.Add(true, String.Empty);
			vlItem.Appearance.Image = MarDevs.Gestion.Win.Properties.Resources.ImagenAviso;
			vlAviso.ValueListItems.Add(false, String.Empty);

			col = UtilP.ConfigurarColumna(ultraGrid1, "Aviso", true, 1, "A", 15);
			col.ValueList = vlAviso;
			col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
			col.LockedWidth = true;
			col.Header.Fixed = true;
			col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			col.Header.ToolTipText = "Aviso";

			UtilP.ConfigurarColumna(ultraGrid1, "EntidadDescripcion", true, 2, "Descripción", 200);
			UtilP.ConfigurarColumna(ultraGrid1, "Comentarios", true, 3, "Comentarios", 200);

			col = UtilP.ConfigurarColumna(ultraGrid1, "EntidadTipo", true, 2, "T", 15);
            col.ValueList = UtilP.CargarValueListDesdeEnum(typeof(TipoEntidad));
			col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
			col.LockedWidth = true;
			col.Header.Fixed = true;
			col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			col.Header.ToolTipText = "Tipo de Entidad";

			UltraGridBand banda = this.ultraGrid1.DisplayLayout.Bands[0];
			banda.Columns["FechaSeguimiento"].GroupByMode = GroupByMode.OutlookDate;
			banda.SortedColumns.Add("FechaSeguimiento", true, true);
		}
		private void ultraGrid1_InitializeRow(object sender, InitializeRowEventArgs e)
		{
			MarcaSeguimiento marca = e.Row.ListObject as MarcaSeguimiento;
			if (marca != null)
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat("Tipo de entidad: {0}", e.Row.Cells["EntidadTipo"].Text);
				sb.AppendLine();
				sb.AppendFormat("Asunto: {0}", marca.EntidadDescripcion);
				sb.AppendLine();
				if (!String.IsNullOrEmpty(marca.Comentarios))
				{
					sb.AppendFormat("Comentarios: {0}", marca.Comentarios);
					sb.AppendLine();
				}
				sb.AppendFormat("Fecha de seguimiento: {0:dd/MM/yyyy}", marca.FechaSeguimiento);
				sb.AppendLine();
				if (marca.Aviso && marca.FechaAviso != null)
				{
					sb.AppendFormat("Fecha de aviso: {0:dd/MM/yyyy HH:mm}", marca.FechaAviso);
					sb.AppendLine();
				}
				e.Row.ToolTipText = sb.ToString();
			}
			else
			{
				e.Row.ToolTipText = String.Empty;
			}
		}
		private void ultraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
		{
			if (e.RowArea == RowArea.Cell)
			{
				AbrirEntidad();
			}
		}
		private void ultraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Abrir":
					AbrirEntidad();
					break;
				case "ExpandirTodo":
					this.ultraGrid1.Rows.ExpandAll(true);
					break;
				case "ContraerTodo":
					this.ultraGrid1.Rows.CollapseAll(true);
					break;
				case "SeguimientoHoy":
					CrearMarcasSeguimiento(ConfigBL.FechaActual);
					break;
				case "SeguimientoMañana":
					CrearMarcasSeguimiento(ConfigBL.FechaActual.AddDays(1));
					break;
				case "SeguimientoEstaSemana":
					CrearMarcasSeguimiento(Periodo.SemanaActual().Hasta.Date.AddDays(-2));
					break;
				case "SeguimientoSemanaProxima":
					CrearMarcasSeguimiento(Periodo.SemanaProxima().Hasta.Date.AddDays(-2));
					break;
				case "SeguimientoPersonalizar":
					PersonalizarSeguimiento(false);
					break;
				case "SeguimientoAviso":
					PersonalizarSeguimiento(true);
					break;
				case "SeguimientoBorrarMarca":
					BorrarMarcasSeguimiento();
					break;

			}
		}
		private void MarcaSeguimiento_MarcaSeguimientoModificada(object sender, EventArgs e)
		{
			Actualizar();
		}

		public void Actualizar()
		{
			try
			{
				List<string> grupos = new List<string>();
				foreach (UltraGridRow row in this.ultraGrid1.Rows)
				{
					if (row.IsGroupByRow && row.IsExpanded)
					{
						grupos.Add(row.Description);
					}
				}
				IList<MarcaSeguimiento> lista = MarcaSeguimiento.BuscarUsuarioLogueado();
				_lista.Clear();
				foreach (MarcaSeguimiento marca in lista)
				{
					_lista.Add(marca);
				}
				this.ultraGrid1.Rows.Refresh(RefreshRow.ReloadData);
				//restaurar apertura de grupos
				foreach (UltraGridRow row in this.ultraGrid1.Rows)
				{
					if (row.IsGroupByRow && !row.IsExpanded && grupos.Contains(row.Description))
					{
						row.ExpandAll();
					}
				}
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}

		}
		private void CrearMarcasSeguimiento(DateTime fecha)
		{
			try
			{
				MarcaSeguimiento.ModificarMarcas(this.ElementosSeleccionados, fecha, ImagenSeguimiento.ImagenSeguimiento, null, false, null);

			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private void PersonalizarSeguimiento(bool activarAviso)
		{
			try
			{
				FormPersonalizarMarcaSeguimiento form = new FormPersonalizarMarcaSeguimiento(this.ElementosSeleccionados, activarAviso);
				form.ShowDialog();
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private void BorrarMarcasSeguimiento()
		{
			try
			{
				MarcaSeguimiento.BorrarMarcas(this.ElementosSeleccionados);
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}

	}
}
