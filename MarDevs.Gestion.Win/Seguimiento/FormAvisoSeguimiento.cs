using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MarDevs.Gestion.Core;
using Infragistics.Win.UltraWinGrid;
using System.Collections;

namespace MarDevs.Gestion.Win
{
	public partial class FormAvisoSeguimiento : Form
	{
		private FormAvisoSeguimiento()
		{
			InitializeComponent();
			this.Activated += new EventHandler(FormAvisoSeguimiento_Activated);
			this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(ultraGrid1_InitializeLayout);
			this.ultraGrid1.DoubleClickRow += new DoubleClickRowEventHandler(ultraGrid1_DoubleClickRow);
		}

		private static FormAvisoSeguimiento _form = null;
		private static IList<MarcaSeguimiento> _lista = new List<MarcaSeguimiento>();
		
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


		public static void MostrarAvisos(IList<MarcaSeguimiento> lista)
		{
			if (lista == null || lista.Count == 0) { return; }
			if (_lista == null) { _lista = new List<MarcaSeguimiento>(); }
			
			//determinar si hay alertas q mostrar, comparando contra la lista vigente
			bool hayAlertasNuevas = false;
			foreach (MarcaSeguimiento item in lista)
			{
				if (_lista.Contains(item) == false)
				{
					hayAlertasNuevas = true;
					break;
				}
			}
			//reemplazar los items de la lista por los nuevos
			_lista.Clear();
			foreach (MarcaSeguimiento item in lista)
			{
				_lista.Add(item);
			}
			//si no está instanciado, instanciar un nuevo formulario
			if (_form == null)
			{
				_form = new FormAvisoSeguimiento();
				_form.FormClosed += new FormClosedEventHandler(_form_FormClosed);
			}
			//solo mostrarlo o traerlo al frente si efectivamente hay alertas nuevas q mostrar.
			if (hayAlertasNuevas)
			{
				Sound.Play("chimes.wav", PlaySoundFlags.SND_NOWAIT);
				_form.Show();
				if (_form.WindowState == FormWindowState.Minimized)
				{
					_form.WindowState = FormWindowState.Normal;
				}
				_form.Activate();
			}
		}

		private static void _form_FormClosed(object sender, FormClosedEventArgs e)
		{
			_form = null;
		}
		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
			this.ultraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;

			UtilP.OcultarColumnas(this.ultraGrid1);
			UltraGridColumn col;
			//crear columna para la marca de seguimiento
			col = UtilP.ConfigurarColumna(ultraGrid1, "Imagen", true, 0, "S", 15);
			col.ValueList = UtilP.CargarValueListDesdeEnum(typeof(ImagenSeguimiento));
			col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
			col.LockedWidth = true;
			col.Header.Fixed = true;
			col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			col.Header.ToolTipText = "Marca de seguimiento";

			col = UtilP.ConfigurarColumna(ultraGrid1, "EntidadTipo", true, 1, "T", 15);
			col.ValueList = UtilP.CargarValueListDesdeEnum(typeof(TipoEntidad));
			col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
			col.LockedWidth = true;
			col.Header.Fixed = true;
			col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			col.Header.ToolTipText = "Tipo de Entidad";


			UtilP.ConfigurarColumna(ultraGrid1, "EntidadDescripcion", true, 2, "Descripción", 300);
			UtilP.ConfigurarColumna(ultraGrid1, "FechaSeguimiento", true, 3, "Vencimiento", 80, "D");
		}
		private void ultraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
		{
			if (e.RowArea == RowArea.Cell)
			{
				AbrirEntidad();
			}
		}

		private void FormAvisoSeguimiento_Load(object sender, EventArgs e)
		{
			this.ultraGrid1.DataSource = _lista;
			if (this.ultraGrid1.Rows.Count > 0)
			{
				this.ultraGrid1.Rows[0].Selected = true;
			}

			this.cmbPosponer.Items.Add(5, "5 minutos");
			this.cmbPosponer.Items.Add(10, "10 minutos");
			this.cmbPosponer.Items.Add(15, "15 minutos");
			this.cmbPosponer.Items.Add(30, "30 minutos");
			this.cmbPosponer.Items.Add(60, "1 hora");
			this.cmbPosponer.Items.Add(120, "2 horas");
			this.cmbPosponer.Items.Add(240, "4 horas");
			this.cmbPosponer.Items.Add(480, "8 horas");
			this.cmbPosponer.Items.Add(1440, "1 día");
			this.cmbPosponer.Items.Add(2880, "2 días");
			this.cmbPosponer.Items.Add(4320, "3 días");
			this.cmbPosponer.Items.Add(5760, "4 días");
			this.cmbPosponer.Items.Add(10080, "1 semana");
			this.cmbPosponer.Items.Add(20160, "2 semanas");

			this.cmbPosponer.Value = 5;
		}
		private void FormAvisoSeguimiento_Activated(object sender, EventArgs e)
		{
			this.ultraGrid1.Rows.Refresh(RefreshRow.FireInitializeRow);
			if (this.ultraGrid1.Selected.Rows.Count == 0 && this.ultraGrid1.Rows != null && this.ultraGrid1.Rows.Count > 0)
			{
				this.ultraGrid1.Rows[0].Selected = true;
				this.ultraGrid1.Rows[0].Activate();
			}
			ActualizarTitulo();
		}

		private void btnPosponer_Click(object sender, EventArgs e)
		{
			try
			{
				IList lista = this.ElementosSeleccionados;
				int minutos = Convert.ToInt32(this.cmbPosponer.Value);
				DateTime fecha = ConfigBL.FechaYHoraActual.AddMinutes(minutos);
				MarcaSeguimiento.PosponerAvisos(lista, fecha);
				foreach (MarcaSeguimiento marca in lista)
				{
					if (_lista.Contains(marca))
					{
						_lista.Remove(marca);
					}
				}
				if (_lista.Count == 0)
				{
					this.Close();
				}
				else
				{
					this.ultraGrid1.Rows.Refresh(RefreshRow.FireInitializeRow);
					ActualizarTitulo();
				}
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private void btnDescartar_Click(object sender, EventArgs e)
		{
			try
			{
				IList lista = this.ElementosSeleccionados;
				MarcaSeguimiento.BorrarAvisos(lista);
				foreach (MarcaSeguimiento marca in lista)
				{
					if (_lista.Contains(marca))
					{
						_lista.Remove(marca);
					}
				}
				if (_lista.Count == 0)
				{
					this.Close();
				}
				else
				{
					this.ultraGrid1.Rows.Refresh(RefreshRow.FireInitializeRow);
					ActualizarTitulo();
				}
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private void btnDescartarTodos_Click(object sender, EventArgs e)
		{
			try
			{
				//convertir las marcas a un arraylist... ya q el metodo recibe IList y no IList generico.
				ArrayList lista = new ArrayList();
				foreach (MarcaSeguimiento marca in _lista)
				{
					lista.Add(marca);
				}
				MarcaSeguimiento.BorrarAvisos(lista);
				_lista.Clear();
				this.Close();
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}

		}
		private void btnAbrir_Click(object sender, EventArgs e)
		{
			AbrirEntidad();
		}

		private void AbrirEntidad()
		{
			try
			{
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
		}
		private void ActualizarTitulo()
		{
			if (_lista != null)
			{
				this.Text = String.Format("{0} - {1} Aviso{2}", App.NombreInstalacion, _lista.Count, (_lista.Count == 1) ? String.Empty : "s");
			}
			else
			{
				this.Text = String.Empty;
			}
		}


	}
}
