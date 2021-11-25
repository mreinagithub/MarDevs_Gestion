using System;
using MarDevs.OC.Core;

namespace MarDevs.OC.Win
{
	public class SelectorPeriodo : SelectorBase
	{
		private System.ComponentModel.IContainer components = null;

		public SelectorPeriodo()
		{
			// Llamada necesaria para el Diseñador de Windows Forms.
			InitializeComponent();
			this.comboQueBuscar.SelectionChanged+=new EventHandler(comboQueBuscar_SelectionChanged);
			this.comboQueBuscar.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(comboQueBuscar_EditorButtonClick);
		}

		private void comboQueBuscar_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
		{
			if (this.comboQueBuscar.SelectedIndex == this.comboQueBuscar.Items.Count - 1)
			{
				this.SeleccionarPeriodoPersonalizado();
			}
			else
			{
				this.comboQueBuscar.SelectedIndex = this.comboQueBuscar.Items.Count - 1;
			}
		}

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Código generado por el diseñador
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            ((System.ComponentModel.ISupportInitialize)(this.comboQueBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // comboQueBuscar
            // 
            editorButton1.Text = "...";
            this.comboQueBuscar.ButtonsRight.Add(editorButton1);
            this.comboQueBuscar.SortStyle = Infragistics.Win.ValueListSortStyle.None;
            // 
            // SelectorPeriodo
            // 
            this.Name = "SelectorPeriodo";
            this.Load += new System.EventHandler(this.SelectorPeriodo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboQueBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		public virtual void Inicializar()
		{
		}
		private void SeleccionarPeriodoPersonalizado()
		{
			Periodo periodo = this.comboQueBuscar.SelectedItem.DataValue as Periodo;
			FormSeleccionPeriodo formSelector = new FormSeleccionPeriodo(periodo);
			formSelector.ShowDialog();
			this.comboQueBuscar.SelectedItem.DisplayText = String.Format("{0}",periodo.ToShortDateString());
			this.comboQueBuscar.Refresh();
		}
		private void comboQueBuscar_SelectionChanged(object sender, EventArgs e)
		{
			if (this.comboQueBuscar.SelectedIndex == this.comboQueBuscar.Items.Count -1)
				this.SeleccionarPeriodoPersonalizado();
		}
        public new Periodo Value
        {
            get { return this.comboQueBuscar.Value as Periodo; }
            set { this.comboQueBuscar.Value = value; }
        }

        private void SelectorPeriodo_Load(object sender, EventArgs e)
        {
            this.comboQueBuscar.Items.Clear();
            this.comboQueBuscar.Items.Add(null, "[En cualquier momento]");
            this.comboQueBuscar.Items.Add(Periodo.Hoy(), Periodo.Hoy().Descripcion);
            this.comboQueBuscar.Items.Add(Periodo.Ayer(), Periodo.Ayer().Descripcion);
            this.comboQueBuscar.Items.Add(Periodo.SemanaActual(), Periodo.SemanaActual().Descripcion);
            this.comboQueBuscar.Items.Add(Periodo.SemanaAnterior(), Periodo.SemanaAnterior().Descripcion);
            this.comboQueBuscar.Items.Add(Periodo.MesActual(), Periodo.MesActual().Descripcion);
            this.comboQueBuscar.Items.Add(Periodo.MesAnterior(), Periodo.MesAnterior().Descripcion);
            this.comboQueBuscar.Items.Add(Periodo.Hoy(), "Otro...");
        }
	}
}

