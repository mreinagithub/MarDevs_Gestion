
namespace MarDevs.OC.Win
{
	public class SelectorCombo : SelectorBase
	{
		private System.ComponentModel.IContainer components = null;

		public SelectorCombo()
		{
			// Llamada necesaria para el Diseñador de Windows Forms.
			InitializeComponent();			
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
			((System.ComponentModel.ISupportInitialize)(this.comboQueBuscar)).BeginInit();
			this.SuspendLayout();
			// 
			// comboQueBuscar
			// 
			this.comboQueBuscar.SortStyle = Infragistics.Win.ValueListSortStyle.None;
			// 
			// selectorCombo
			// 
			this.Name = "selectorCombo";
			((System.ComponentModel.ISupportInitialize)(this.comboQueBuscar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
		public virtual void Inicializar()
		{
		}				
		public new object Value
		{
			get { return this.comboQueBuscar.Value == null ? "" : this.comboQueBuscar.Value; }
			set { this.comboQueBuscar.Value = value; }
		}
	}
}

