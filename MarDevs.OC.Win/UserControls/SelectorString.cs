
namespace MarDevs.OC.Win
{
	public class SelectorString : SelectorBase
	{
		private System.ComponentModel.IContainer components = null;

		public SelectorString()
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
			this.SuspendLayout();
			// 
			// comboQueBuscar
			// 
			this.comboQueBuscar.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
			this.comboQueBuscar.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
			this.comboQueBuscar.Name = "comboQueBuscar";
			// 
			// selectorString
			// 
			this.Name = "selectorString";
			this.ResumeLayout(false);

		}
		#endregion
		public virtual void Inicializar()
		{
		}
		public new virtual string Value
		{
			get{return this.comboQueBuscar.Value as string;}
				
		}
	}
}

