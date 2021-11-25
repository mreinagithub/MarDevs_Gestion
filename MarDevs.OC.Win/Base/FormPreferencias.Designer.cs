namespace MarDevs.OC.Win
{
	partial class FormPreferencias
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPreferencias));
			Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
			this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.checkUsarMultiFormulario = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
			this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
			this.cancelarButton = new Infragistics.Win.Misc.UltraButton();
			this.aceptarButton = new Infragistics.Win.Misc.UltraButton();
			this.ultraTabPageControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
			this.ultraTabControl1.SuspendLayout();
			this.ultraTabSharedControlsPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraTabPageControl1
			// 
			this.ultraTabPageControl1.Controls.Add(this.ultraLabel1);
			this.ultraTabPageControl1.Controls.Add(this.checkUsarMultiFormulario);
			this.ultraTabPageControl1.Controls.Add(this.cancelarButton);
			this.ultraTabPageControl1.Controls.Add(this.aceptarButton);
			this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
			this.ultraTabPageControl1.Name = "ultraTabPageControl1";
			this.ultraTabPageControl1.Size = new System.Drawing.Size(490, 218);
			// 
			// ultraLabel1
			// 
			appearance1.BackColor = System.Drawing.Color.Transparent;
			this.ultraLabel1.Appearance = appearance1;
			this.ultraLabel1.Location = new System.Drawing.Point(30, 45);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(456, 49);
			this.ultraLabel1.TabIndex = 1;
			this.ultraLabel1.Text = resources.GetString("ultraLabel1.Text");
			// 
			// checkUsarMultiFormulario
			// 
			this.checkUsarMultiFormulario.BackColor = System.Drawing.Color.Transparent;
			this.checkUsarMultiFormulario.Location = new System.Drawing.Point(30, 19);
			this.checkUsarMultiFormulario.Name = "checkUsarMultiFormulario";
			this.checkUsarMultiFormulario.Size = new System.Drawing.Size(280, 20);
			this.checkUsarMultiFormulario.TabIndex = 0;
			this.checkUsarMultiFormulario.Text = "Habilitar el uso de navegación avanzada";
			// 
			// ultraTabControl1
			// 
			this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
			this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
			this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.ultraTabControl1.Name = "ultraTabControl1";
			this.ultraTabControl1.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.cancelarButton,
            this.aceptarButton});
			this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
			this.ultraTabControl1.Size = new System.Drawing.Size(494, 244);
			this.ultraTabControl1.TabIndex = 0;
			ultraTab1.Key = "General";
			ultraTab1.TabPage = this.ultraTabPageControl1;
			ultraTab1.Text = "General";
			this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
			// 
			// ultraTabSharedControlsPage1
			// 
			this.ultraTabSharedControlsPage1.Controls.Add(this.cancelarButton);
			this.ultraTabSharedControlsPage1.Controls.Add(this.aceptarButton);
			this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
			this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
			this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(490, 218);
			// 
			// cancelarButton
			// 
			this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelarButton.Location = new System.Drawing.Point(407, 191);
			this.cancelarButton.Name = "cancelarButton";
			this.cancelarButton.Size = new System.Drawing.Size(80, 24);
			this.cancelarButton.TabIndex = 3;
			this.cancelarButton.Text = "Cancelar";
			this.cancelarButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
			// 
			// aceptarButton
			// 
			this.aceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.aceptarButton.Location = new System.Drawing.Point(321, 191);
			this.aceptarButton.Name = "aceptarButton";
			this.aceptarButton.Size = new System.Drawing.Size(80, 24);
			this.aceptarButton.TabIndex = 2;
			this.aceptarButton.Text = "Aceptar";
			this.aceptarButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
			// 
			// FormPreferencias
			// 
			this.AcceptButton = this.aceptarButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelarButton;
			this.ClientSize = new System.Drawing.Size(494, 244);
			this.Controls.Add(this.ultraTabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPreferencias";
			this.Text = "Preferencias";
			this.Load += new System.EventHandler(this.FormPreferencias_Load);
			this.ultraTabPageControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
			this.ultraTabControl1.ResumeLayout(false);
			this.ultraTabSharedControlsPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkUsarMultiFormulario;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		protected Infragistics.Win.Misc.UltraButton cancelarButton;
		protected Infragistics.Win.Misc.UltraButton aceptarButton;
	}
}