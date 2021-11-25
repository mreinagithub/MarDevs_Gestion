namespace MarDevs.OC.Win
{
	partial class FormAuditoria
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
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Log", -1);
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Detalle");
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			this.txtCreadoEl = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.txtCreadoPor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.grillaBitacora = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.bindingSourceLog = new System.Windows.Forms.BindingSource(this.components);
			this.UltraLabel34 = new Infragistics.Win.Misc.UltraLabel();
			this.UltraLabel33 = new Infragistics.Win.Misc.UltraLabel();
			this.btnCerrar = new Infragistics.Win.Misc.UltraButton();
			((System.ComponentModel.ISupportInitialize)(this.txtCreadoEl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreadoPor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceLog)).BeginInit();
			this.SuspendLayout();
			// 
			// txtCreadoEl
			// 
			this.txtCreadoEl.Location = new System.Drawing.Point(73, 12);
			this.txtCreadoEl.Name = "txtCreadoEl";
			this.txtCreadoEl.ReadOnly = true;
			this.txtCreadoEl.Size = new System.Drawing.Size(117, 21);
			this.txtCreadoEl.TabIndex = 6;
			// 
			// txtCreadoPor
			// 
			this.txtCreadoPor.Location = new System.Drawing.Point(227, 12);
			this.txtCreadoPor.Name = "txtCreadoPor";
			this.txtCreadoPor.ReadOnly = true;
			this.txtCreadoPor.Size = new System.Drawing.Size(160, 21);
			this.txtCreadoPor.TabIndex = 8;
			// 
			// grillaBitacora
			// 
			this.grillaBitacora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grillaBitacora.DataSource = this.bindingSourceLog;
			appearance1.BackColor = System.Drawing.Color.White;
			this.grillaBitacora.DisplayLayout.Appearance = appearance1;
			this.grillaBitacora.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
			ultraGridBand1.AddButtonCaption = "DummyBand 1";
			ultraGridColumn1.Format = "dd/MM/yyyy HH:mm:ss";
			ultraGridColumn1.Header.VisiblePosition = 0;
			ultraGridColumn1.Width = 116;
			ultraGridColumn2.Header.VisiblePosition = 1;
			ultraGridColumn2.Width = 76;
			ultraGridColumn3.Header.VisiblePosition = 2;
			ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
			this.grillaBitacora.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
			this.grillaBitacora.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.grillaBitacora.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.grillaBitacora.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			this.grillaBitacora.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
			appearance2.BackColor = System.Drawing.Color.Transparent;
			this.grillaBitacora.DisplayLayout.Override.CardAreaAppearance = appearance2;
			this.grillaBitacora.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.grillaBitacora.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
			appearance3.TextHAlignAsString = "Left";
			this.grillaBitacora.DisplayLayout.Override.HeaderAppearance = appearance3;
			this.grillaBitacora.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			appearance4.BorderColor = System.Drawing.Color.LightGray;
			appearance4.TextVAlignAsString = "Middle";
			this.grillaBitacora.DisplayLayout.Override.RowAppearance = appearance4;
			this.grillaBitacora.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance5.BackColor = System.Drawing.SystemColors.Highlight;
			appearance5.BorderColor = System.Drawing.Color.Black;
			appearance5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.grillaBitacora.DisplayLayout.Override.SelectedRowAppearance = appearance5;
			this.grillaBitacora.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaBitacora.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaBitacora.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			this.grillaBitacora.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
			this.grillaBitacora.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.grillaBitacora.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.grillaBitacora.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
			this.grillaBitacora.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.grillaBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grillaBitacora.Location = new System.Drawing.Point(11, 40);
			this.grillaBitacora.Name = "grillaBitacora";
			this.grillaBitacora.Size = new System.Drawing.Size(540, 296);
			this.grillaBitacora.TabIndex = 9;
			this.grillaBitacora.Text = "Log de Cambios";
			// 
			// bindingSourceLog
			// 
			this.bindingSourceLog.DataSource = typeof(MarDevs.OC.Core.Log);
			// 
			// UltraLabel34
			// 
			appearance6.TextVAlignAsString = "Middle";
			this.UltraLabel34.Appearance = appearance6;
			this.UltraLabel34.BackColorInternal = System.Drawing.Color.Transparent;
			this.UltraLabel34.Location = new System.Drawing.Point(11, 15);
			this.UltraLabel34.Name = "UltraLabel34";
			this.UltraLabel34.Size = new System.Drawing.Size(56, 14);
			this.UltraLabel34.TabIndex = 5;
			this.UltraLabel34.Text = "Creado el:";
			// 
			// UltraLabel33
			// 
			appearance7.TextVAlignAsString = "Middle";
			this.UltraLabel33.Appearance = appearance7;
			this.UltraLabel33.BackColorInternal = System.Drawing.Color.Transparent;
			this.UltraLabel33.Location = new System.Drawing.Point(196, 15);
			this.UltraLabel33.Name = "UltraLabel33";
			this.UltraLabel33.Size = new System.Drawing.Size(24, 14);
			this.UltraLabel33.TabIndex = 7;
			this.UltraLabel33.Text = "por:";
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCerrar.Location = new System.Drawing.Point(476, 342);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(75, 23);
			this.btnCerrar.TabIndex = 10;
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// FormAuditoria
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCerrar;
			this.ClientSize = new System.Drawing.Size(563, 367);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.txtCreadoEl);
			this.Controls.Add(this.txtCreadoPor);
			this.Controls.Add(this.grillaBitacora);
			this.Controls.Add(this.UltraLabel34);
			this.Controls.Add(this.UltraLabel33);
			this.Name = "FormAuditoria";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Auditoría";
			this.Load += new System.EventHandler(this.FormAuditoria_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtCreadoEl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreadoPor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceLog)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected Infragistics.Win.UltraWinEditors.UltraTextEditor txtCreadoEl;
		protected Infragistics.Win.UltraWinEditors.UltraTextEditor txtCreadoPor;
		protected Infragistics.Win.UltraWinGrid.UltraGrid grillaBitacora;
		protected Infragistics.Win.Misc.UltraLabel UltraLabel34;
		protected Infragistics.Win.Misc.UltraLabel UltraLabel33;
		private Infragistics.Win.Misc.UltraButton btnCerrar;
		protected System.Windows.Forms.BindingSource bindingSourceLog;
	}
}