using System;
using System.Windows.Forms;
using MarDevs.OC.Core;
using Infragistics.Win.UltraWinGrid;

namespace MarDevs.OC.Win
{
	public partial class ControlNotas : UserControl
	{
		public ControlNotas()
		{
			InitializeComponent();

			grillaNotas.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(grillaNotas_InitializeLayout);
			grillaNotas.KeyPress += new KeyPressEventHandler(grillaNotas_KeyPress);
			grillaNotas.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(grillaNotas_DoubleClickRow);
			grillaNotas.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(grillaNotas_BeforeRowsDeleted);
		}

		private void grillaNotas_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
		{
			e.DisplayPromptMsg = false;
			if (_puedeEliminar)
			{
				this.EliminarNota();
			}
			e.Cancel = true;
		}
		private void grillaNotas_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
		{
			if (e.RowArea == RowArea.Cell || e.RowArea == RowArea.RowPreviewArea)
			{
				this.ModificarNota();
			}
		}
		private void grillaNotas_KeyPress(object sender, KeyPressEventArgs e)
		{
			switch ((Keys)e.KeyChar)
			{
				case Keys.Enter:
					this.ModificarNota();
					break;
			}
		}
		private void grillaNotas_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			UtilP.ConfigurarColumna(this.grillaNotas, "Texto", false);
			UtilP.ConfigurarColumna(this.grillaNotas, "Confidencial", false);

			int i = 0;
			UtilP.ConfigurarColumna(this.grillaNotas, "CreadoEl", true, i++, "Fecha", 80, "dd/MM/yyyy HH:mm");
			UtilP.ConfigurarColumna(this.grillaNotas, "CreadoPor", true, i++, "Creada Por", 80);

			UltraGridBand banda = this.grillaNotas.DisplayLayout.Bands[0];

			banda.Columns["CreadoEl"].Width = 100;
			banda.Columns["CreadoEl"].LockedWidth = true;
			banda.AutoPreviewEnabled = true;
			banda.AutoPreviewField = "Texto";
			banda.AutoPreviewMaxLines = 20;
			banda.Columns["CreadoEl"].SortIndicator = SortIndicator.Descending;
			banda.AutoPreviewIndentation = 5;
		}

		private IPersistente _entidad;
		private string _tipoEntidad;
		private object _entidadId;
		private string _referencia;
		private bool _puedeModificar = false;
		private bool _puedeEliminar = false;
		private bool _puedeAgregar = false;
		private bool _labelEntidadVisible = true;

		public IPersistente Entidad
		{
			get { return _entidad; }
			set
			{
				_entidad = value;
				_entidadId = null;
				_tipoEntidad = null;
				_referencia = null;
				if (_entidad != null)
				{
					grillaNotas.DataSource = Nota.ListarPorEntidad(_entidad);
					labelEntidad.Text = _entidad.ToString();
				}
				else
				{
					grillaNotas.DataSource = null;
					labelEntidad.Text = String.Empty;
				}
			}
		}
		public void EstablecerEntidad(string tipoEntidad, object entidadId, string referencia)
		{
			_tipoEntidad = tipoEntidad;
			_entidadId = entidadId;
			_referencia = referencia;
			_entidad = null;
			if (String.IsNullOrEmpty(_tipoEntidad) || _entidadId == null || String.IsNullOrEmpty(_referencia))
			{
				grillaNotas.DataSource = null;
				labelEntidad.Text = String.Empty;
			}
			else
			{
				grillaNotas.DataSource = Nota.ListarPorEntidad(_tipoEntidad, _entidadId);
				labelEntidad.Text = _referencia;
			}
		}
		public bool PuedeModificar
		{
			get { return _puedeModificar; }
			set { _puedeModificar = value; }
		}
		public bool PuedeEliminar
		{
			get { return _puedeEliminar; }
			set
			{
				_puedeEliminar = value;
				this.botonEliminarNota.Visible = _puedeEliminar;
			}
		}
		public bool PuedeAgregar
		{
			get { return _puedeAgregar; }
			set
			{
				_puedeAgregar = value;
				this.botonAgregarNota.Visible = _puedeAgregar;
			}
		}
		
		public bool LabelEntidadVisible
		{
			get { return _labelEntidadVisible; }
			set
			{
				_labelEntidadVisible = value;
				this.labelEntidad.Visible = value;
			}
		}

		private void botonAgregarNota_Click(object sender, EventArgs e)
		{
			AgregarNota();
		}
		private void botonEliminarNota_Click(object sender, EventArgs e)
		{
			if (_puedeEliminar)
			{
				EliminarNota();
			}
		}
		
		protected void AgregarNota()
		{
			this.LeerEntidad();
			if (_entidad == null)
			{
				return;
			}
			if (_entidad.EsNuevo())
			{
				Mensaje.Advertencia("No se pueden agregar notas a entidades que todavía no han sido guardados. Guarde primero los cambios.");
				return;
			}
			Nota nuevaNota = Nota.Crear(_entidad);
			nuevaNota.Texto = String.Empty;

			FormNota formNota = new FormNota(nuevaNota, true);
			if (formNota.ShowDialog() == DialogResult.OK) //la nota se guardó.
			{
				try
				{
					this.grillaNotas.DataSource = Nota.ListarPorEntidad(_entidad);
				}
				catch (Exception ex)
				{
					Mensaje.MostrarError(ex);
				}
			}
		}
		protected void EliminarNota()
		{
			if (this.grillaNotas.ActiveRow == null)
			{ 
				return; 
			}
			Nota nota = this.grillaNotas.ActiveRow.ListObject as Nota;
			if (nota == null)
			{
				return;
			}
			if (Mensaje.Pregunta("Esta seguro que desea eliminar la nota?") == DialogResult.Yes)
			{
				try
				{
					nota.Eliminar();
					this.grillaNotas.DataSource = Nota.ListarPorEntidad(_entidad);
				}
				catch (Exception ex)
				{
					Mensaje.Error("No se pudo eliminar la Nota.", ex);
				}
			}
		}
		private void ModificarNota()
		{
			try
			{
				if (this.grillaNotas.ActiveRow == null)
				{
					return;
				}
				Nota nota = this.grillaNotas.ActiveRow.ListObject as Nota;
				if (nota == null)
				{
					return;
				}
				FormNota fNota = new FormNota(nota, _puedeModificar);
				fNota.ShowDialog();
				this.grillaNotas.DataBind();

			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		
		public void LeerEntidad()
		{
			if (_entidad != null)
			{ return; }
			if (_tipoEntidad == "Unidad")
			{
				if (_entidadId is Int32?)
				{
					Int32? id = _entidadId as Int32?;
					if (id == null)
					{
						return;
					}
				}
			}
		}

	}
}
