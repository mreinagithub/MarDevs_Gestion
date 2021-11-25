using System;
using System.Collections.Generic;
using System.Drawing;
using MarDevs.OC.Core;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace MarDevs.OC.Win
{
	public partial class FormListaBaseSeguimiento : FormListaBase
	{
		protected Dictionary<string, MarcaSeguimiento> _marcasSeguimiento = null;

		public FormListaBaseSeguimiento()
		{
			InitializeComponent();

			MarcaSeguimiento.MarcaSeguimientoModificada += new MarcaSeguimientoModificadaEventHandler(MarcaSeguimiento_MarcaSeguimientoModificada);
		}

		private void MarcaSeguimiento_MarcaSeguimientoModificada(object sender, EventArgs e)
		{
			try
			{
				_marcasSeguimiento = MarcaSeguimiento.BuscarPorTipoEntidad(this.TipoEntidad);
				if (this.ultraGrid1.Rows != null)
					this.ultraGrid1.Rows.Refresh(RefreshRow.FireInitializeRow, true);
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		protected override void InicializarToolbar()
		{
			base.InicializarToolbar();
			App.CrearToolsSeguimiento((PopupMenuTool)ultraToolbarsManager1.Tools["PopupAcciones"], true);
		}
		protected override void InicializarGrilla()
		{
			base.InicializarGrilla();

			//crear columna para la marca de seguimiento
			this.ultraGrid1.DisplayLayout.UseFixedHeaders = true;
			this.ultraGrid1.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
			UltraGridColumn col;
			col = UtilP.ConfigurarColumna(ultraGrid1, "MarcaSeguimiento", true, 0, "S", 15);
			col.DataType = typeof(MarcaSeguimiento);
			col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
			col.LockedWidth = true;
			col.Header.Fixed = true;
			col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			col.Header.ToolTipText = "Fecha Segimiento";
			col.ColumnChooserCaption = "Fecha Seguimiento";
			col = UtilP.ConfigurarColumna(ultraGrid1, "FechaSeguimiento", false, 1, "Fecha\nSeguim.", 68);
			col.DataType = typeof(DateTime);
			col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
			col.LockedWidth = true;
			//col.Header.Fixed = true;
			//col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
		}
		public override void ActualizarListaDesdeOrigen()
		{
			//solo la primera vez recupero las marcas para la entidad, el resto de las veces ser recupera por el evento MarcaSeguimientoModificada.
			if (_marcasSeguimiento == null)
			{
				if (TipoEntidad == null)
					throw new Exception("NO SE HA DEFINIDO EL TIPO DE ENTIDAD. Debe establecer la variable TipoEntidad.");
				_marcasSeguimiento = MarcaSeguimiento.BuscarPorTipoEntidad(TipoEntidad);
			}
			base.ActualizarListaDesdeOrigen();
		}
		protected override void UltraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			try
			{
				base.UltraGrid1_InitializeRow(sender, e);
				//marca de seguimiento
				IPersistente entidad = e.Row.ListObject as IPersistente;
				if (entidad != null)
				{
					string id = entidad.ObtenerID().ToString();
					if (_marcasSeguimiento != null && _marcasSeguimiento.ContainsKey(id))
					{
						MarcaSeguimiento marca = _marcasSeguimiento[id];
						e.Row.Cells["MarcaSeguimiento"].Value = marca;
						e.Row.Cells["MarcaSeguimiento"].Appearance.Image = Recursos.TraerRecursoEnsamblado(marca.Imagen.ToString()) as Image;
						e.Row.Cells["MarcaSeguimiento"].ToolTipText = marca.Comentarios;
						e.Row.Cells["FechaSeguimiento"].Value = marca.FechaSeguimiento;
					}
					else
					{
						e.Row.Cells["MarcaSeguimiento"].Value = null;
						e.Row.Cells["MarcaSeguimiento"].Appearance.Image = null;
						e.Row.Cells["MarcaSeguimiento"].ToolTipText = String.Empty;
						e.Row.Cells["FechaSeguimiento"].Value = null;
					}
				}
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		protected override void UltraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
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
					CrearMarcasPersonalizadas(false);
					break;
				case "SeguimientoAviso":
					CrearMarcasPersonalizadas(true);
					break;
				case "SeguimientoBorrarMarca":
					BorrarMarcasSeguimiento();
					break;

				default:
					base.UltraToolbarsManager1_ToolClick(sender, e);
					break;
			}
		}

		protected virtual void CrearMarcasPersonalizadas(bool activarAviso)
		{
			FormPersonalizarMarcaSeguimiento form = new FormPersonalizarMarcaSeguimiento(this.ElementosSeleccionados, activarAviso);
			form.ShowDialog();
		}
		protected virtual void CrearMarcasSeguimiento(DateTime fecha)
		{
			MarcaSeguimiento.CrearMarcasDesdeEntidades(this.ElementosSeleccionados, fecha, ImagenSeguimiento.ImagenSeguimiento, null, false, null);
		}
		protected virtual void BorrarMarcasSeguimiento()
		{
			List<MarcaSeguimiento> lista = new List<MarcaSeguimiento>();
			foreach (UltraGridRow row in this.ultraGrid1.Selected.Rows)
			{
				MarcaSeguimiento marca = row.Cells["MarcaSeguimiento"].Value as MarcaSeguimiento;
				if (marca != null)
				{
					lista.Add(marca);
				}
			}
			MarcaSeguimiento.BorrarMarcas(lista);
		}
	}
}
