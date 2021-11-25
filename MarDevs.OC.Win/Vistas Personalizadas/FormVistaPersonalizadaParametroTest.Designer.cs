namespace MarDevs.OC.Win
{
	partial class FormVistaPersonalizadaParametroTest
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnConsultar = new Infragistics.Win.Misc.UltraButton();
			this.contenedorParametros1 = new MarDevs.OC.Win.ContenedorParametros();
			this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
			this.SuspendLayout();
			// 
			// btnConsultar
			// 
			this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConsultar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
			this.btnConsultar.Location = new System.Drawing.Point(425, 9);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(75, 23);
			this.btnConsultar.TabIndex = 29;
			this.btnConsultar.Text = "Consultar";
			this.btnConsultar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnConsultar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			// 
			// contenedorParametros1
			// 
			this.contenedorParametros1.BackColor = System.Drawing.Color.Transparent;
			this.contenedorParametros1.Location = new System.Drawing.Point(12, 12);
			this.contenedorParametros1.Name = "contenedorParametros1";
			this.contenedorParametros1.Size = new System.Drawing.Size(407, 60);
			this.contenedorParametros1.TabIndex = 0;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
			this.btnCancelar.Location = new System.Drawing.Point(425, 38);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 30;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// FormVistaPersonalizadaParametroTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(512, 83);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnConsultar);
			this.Controls.Add(this.contenedorParametros1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormVistaPersonalizadaParametroTest";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Vista de parámetros";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVistaPersonalizadaParametroTest_FormClosing);
			this.Load += new System.EventHandler(this.FormVistaPersonalizadaParametroTest_Load);
			this.ResumeLayout(false);

		}

		#endregion

		public ContenedorParametros contenedorParametros1;
		public Infragistics.Win.Misc.UltraButton btnConsultar;
		public Infragistics.Win.Misc.UltraButton btnCancelar;

	}
}