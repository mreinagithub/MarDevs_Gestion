using System;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{
	public class SelectorPeriodo2 : SelectorBase
	{
		private System.ComponentModel.IContainer components = null;

		public SelectorPeriodo2()
		{
			// Llamada necesaria para el Diseñador de Windows Forms.
			InitializeComponent();
			this.comboQueBuscar.SelectionChanged+=new EventHandler(comboQueBuscar_SelectionChanged);
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
            this.SuspendLayout();
            // 
            // comboQueBuscar
            // 
            this.comboQueBuscar.SortStyle = Infragistics.Win.ValueListSortStyle.None;
            // 
            // selectorPeriodo
            // 
            this.Name = "selectorPeriodo";
            this.ResumeLayout(false);

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
			this.comboQueBuscar.SelectedItem.DisplayText = String.Format("Otro...({0})",periodo.ToShortDateString());
			this.comboQueBuscar.Refresh();
		}
		private void comboQueBuscar_SelectionChanged(object sender, EventArgs e)
		{
			if (this.comboQueBuscar.SelectedIndex == this.comboQueBuscar.Items.Count -1)
			{
				this.SeleccionarPeriodoPersonalizado();
			}
		}
		public new Periodo Value
		{
			get { return this.comboQueBuscar.Value as Periodo;}
		}
	}
}

