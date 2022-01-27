namespace MarDevs.Gestion.Win
{
	partial class FormAvisoSeguimiento
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAvisoSeguimiento));
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.cmbPosponer = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.btnPosponer = new Infragistics.Win.Misc.UltraButton();
			this.btnDescartar = new Infragistics.Win.Misc.UltraButton();
			this.btnDescartarTodos = new Infragistics.Win.Misc.UltraButton();
			this.btnAbrir = new Infragistics.Win.Misc.UltraButton();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPosponer)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance1.BackColor = System.Drawing.Color.White;
			this.ultraGrid1.DisplayLayout.Appearance = appearance1;
			this.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
			ultraGridBand1.AddButtonCaption = "DummyBand 1";
			this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
			this.ultraGrid1.DisplayLayout.MaxBandDepth = 1;
			this.ultraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
			appearance2.BackColor = System.Drawing.Color.Transparent;
			this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
			this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.ultraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
			appearance3.TextHAlignAsString = "Left";
			this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance3;
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
			appearance4.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			appearance4.TextVAlignAsString = "Middle";
			this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance4;
			appearance5.BackColor = System.Drawing.SystemColors.Window;
			appearance5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.ultraGrid1.DisplayLayout.Override.RowPreviewAppearance = appearance5;
			this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance6.BackColor = System.Drawing.SystemColors.Highlight;
			appearance6.BorderColor = System.Drawing.Color.Black;
			appearance6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ultraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance6;
			this.ultraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.ultraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			this.ultraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
			this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.ultraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
			this.ultraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.ultraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ultraGrid1.Location = new System.Drawing.Point(8, 8);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(472, 237);
			this.ultraGrid1.TabIndex = 0;
			// 
			// cmbPosponer
			// 
			this.cmbPosponer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPosponer.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbPosponer.Location = new System.Drawing.Point(75, 284);
			this.cmbPosponer.Name = "cmbPosponer";
			this.cmbPosponer.Size = new System.Drawing.Size(324, 21);
			this.cmbPosponer.TabIndex = 3;
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ultraLabel1.AutoSize = true;
			this.ultraLabel1.Location = new System.Drawing.Point(12, 287);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(56, 14);
			this.ultraLabel1.TabIndex = 5;
			this.ultraLabel1.Text = "Posponer:";
			// 
			// btnPosponer
			// 
			this.btnPosponer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPosponer.Location = new System.Drawing.Point(405, 282);
			this.btnPosponer.Name = "btnPosponer";
			this.btnPosponer.Size = new System.Drawing.Size(75, 23);
			this.btnPosponer.TabIndex = 4;
			this.btnPosponer.Text = "Posponer";
			this.btnPosponer.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnPosponer.Click += new System.EventHandler(this.btnPosponer_Click);
			// 
			// btnDescartar
			// 
			this.btnDescartar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDescartar.Location = new System.Drawing.Point(405, 251);
			this.btnDescartar.Name = "btnDescartar";
			this.btnDescartar.Size = new System.Drawing.Size(75, 23);
			this.btnDescartar.TabIndex = 2;
			this.btnDescartar.Text = "Descartar";
			this.btnDescartar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnDescartar.Click += new System.EventHandler(this.btnDescartar_Click);
			// 
			// btnDescartarTodos
			// 
			this.btnDescartarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDescartarTodos.Location = new System.Drawing.Point(8, 251);
			this.btnDescartarTodos.Name = "btnDescartarTodos";
			this.btnDescartarTodos.Size = new System.Drawing.Size(99, 23);
			this.btnDescartarTodos.TabIndex = 1;
			this.btnDescartarTodos.Text = "Descartar Todo";
			this.btnDescartarTodos.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnDescartarTodos.Click += new System.EventHandler(this.btnDescartarTodos_Click);
			// 
			// btnAbrir
			// 
			this.btnAbrir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAbrir.Location = new System.Drawing.Point(324, 251);
			this.btnAbrir.Name = "btnAbrir";
			this.btnAbrir.Size = new System.Drawing.Size(75, 23);
			this.btnAbrir.TabIndex = 6;
			this.btnAbrir.Text = "Abrir";
			this.btnAbrir.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
			// 
			// FormAvisoSeguimiento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(485, 317);
			this.Controls.Add(this.btnAbrir);
			this.Controls.Add(this.btnDescartarTodos);
			this.Controls.Add(this.btnDescartar);
			this.Controls.Add(this.btnPosponer);
			this.Controls.Add(this.ultraLabel1);
			this.Controls.Add(this.cmbPosponer);
			this.Controls.Add(this.ultraGrid1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormAvisoSeguimiento";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Aviso";
			this.Load += new System.EventHandler(this.FormAvisoSeguimiento_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPosponer)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPosponer;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton btnPosponer;
		private Infragistics.Win.Misc.UltraButton btnDescartar;
		private Infragistics.Win.Misc.UltraButton btnDescartarTodos;
		private Infragistics.Win.Misc.UltraButton btnAbrir;
	}
}