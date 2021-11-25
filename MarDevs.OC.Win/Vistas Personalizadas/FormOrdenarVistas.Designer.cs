namespace MarDevs.OC.Win
{
	partial class FormOrdenarVistas
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrdenarVistas));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.btnSubir = new Infragistics.Win.Misc.UltraButton();
            this.botonGuardaryCerrar = new Infragistics.Win.Misc.UltraButton();
            this.btnBajar = new Infragistics.Win.Misc.UltraButton();
            this.listVistas = new System.Windows.Forms.ListBox();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.cboEntidad = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnGuardar = new Infragistics.Win.Misc.UltraButton();
            this.btnCerrar = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboEntidad)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubir
            // 
            this.btnSubir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            this.btnSubir.Appearance = appearance3;
            this.btnSubir.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSubir.Location = new System.Drawing.Point(398, 40);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(27, 36);
            this.btnSubir.TabIndex = 2;
            this.btnSubir.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSubir.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // botonGuardaryCerrar
            // 
            this.botonGuardaryCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botonGuardaryCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.botonGuardaryCerrar.Location = new System.Drawing.Point(184, 383);
            this.botonGuardaryCerrar.Name = "botonGuardaryCerrar";
            this.botonGuardaryCerrar.Size = new System.Drawing.Size(101, 23);
            this.botonGuardaryCerrar.TabIndex = 4;
            this.botonGuardaryCerrar.Text = "Guardar y Cerrar";
            this.botonGuardaryCerrar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.botonGuardaryCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.botonGuardaryCerrar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // btnBajar
            // 
            this.btnBajar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            this.btnBajar.Appearance = appearance4;
            this.btnBajar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnBajar.Location = new System.Drawing.Point(398, 82);
            this.btnBajar.Name = "btnBajar";
            this.btnBajar.Size = new System.Drawing.Size(27, 36);
            this.btnBajar.TabIndex = 3;
            this.btnBajar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBajar.Click += new System.EventHandler(this.btnBajar_Click);
            // 
            // listVistas
            // 
            this.listVistas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listVistas.FormattingEnabled = true;
            this.listVistas.Location = new System.Drawing.Point(12, 40);
            this.listVistas.Name = "listVistas";
            this.listVistas.Size = new System.Drawing.Size(380, 329);
            this.listVistas.TabIndex = 1;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(12, 11);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(46, 14);
            this.ultraLabel1.TabIndex = 4;
            this.ultraLabel1.Text = "Entidad:";
            // 
            // cboEntidad
            // 
            this.cboEntidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEntidad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboEntidad.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboEntidad.Location = new System.Drawing.Point(64, 8);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(328, 21);
            this.cboEntidad.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cboEntidad.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnGuardar.Location = new System.Drawing.Point(77, 383);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(101, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnGuardar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnCerrar.Location = new System.Drawing.Point(291, 383);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(101, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormOrdenarVistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(429, 418);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboEntidad);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.listVistas);
            this.Controls.Add(this.btnBajar);
            this.Controls.Add(this.botonGuardaryCerrar);
            this.Controls.Add(this.btnSubir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOrdenarVistas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenar Vistas";
            this.Load += new System.EventHandler(this.FormOrdenarVistas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboEntidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraButton btnSubir;
		private Infragistics.Win.Misc.UltraButton botonGuardaryCerrar;
		private Infragistics.Win.Misc.UltraButton btnBajar;
		private System.Windows.Forms.ListBox listVistas;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cboEntidad;
		private Infragistics.Win.Misc.UltraButton btnGuardar;
		private Infragistics.Win.Misc.UltraButton btnCerrar;
	}
}