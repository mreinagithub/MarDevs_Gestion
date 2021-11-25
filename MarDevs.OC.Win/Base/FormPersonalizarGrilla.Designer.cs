namespace MarDevs.OC.Win
{
	partial class FormPersonalizarGrilla
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
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
			this.ultraGridColumnChooser1 = new Infragistics.Win.UltraWinGrid.UltraGridColumnChooser();
			this.botonOrdenarAsc = new Infragistics.Win.Misc.UltraButton();
			this.SuspendLayout();
			// 
			// ultraButton1
			// 
			this.ultraButton1.AcceptsFocus = false;
			this.ultraButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			appearance1.Image = global::MarDevs.OC.Win.Properties.Resources.sort_descending;
			this.ultraButton1.Appearance = appearance1;
			this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
			this.ultraButton1.Location = new System.Drawing.Point(227, 0);
			this.ultraButton1.Name = "ultraButton1";
			this.ultraButton1.ShowFocusRect = false;
			this.ultraButton1.Size = new System.Drawing.Size(23, 23);
			this.ultraButton1.TabIndex = 1;
			this.ultraButton1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.ultraButton1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.ultraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
			// 
			// ultraGridColumnChooser1
			// 
			this.ultraGridColumnChooser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ultraGridColumnChooser1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
			this.ultraGridColumnChooser1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			this.ultraGridColumnChooser1.DisplayLayout.MaxColScrollRegions = 1;
			this.ultraGridColumnChooser1.DisplayLayout.MaxRowScrollRegions = 1;
			this.ultraGridColumnChooser1.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			this.ultraGridColumnChooser1.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
			this.ultraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
			this.ultraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
			this.ultraGridColumnChooser1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.ultraGridColumnChooser1.DisplayLayout.Override.CellPadding = 2;
			this.ultraGridColumnChooser1.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never;
			this.ultraGridColumnChooser1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
			this.ultraGridColumnChooser1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			this.ultraGridColumnChooser1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
			this.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.ultraGridColumnChooser1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
			this.ultraGridColumnChooser1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.ultraGridColumnChooser1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.ultraGridColumnChooser1.Location = new System.Drawing.Point(7, 26);
			this.ultraGridColumnChooser1.Name = "ultraGridColumnChooser1";
			this.ultraGridColumnChooser1.Size = new System.Drawing.Size(246, 355);
			this.ultraGridColumnChooser1.StyleSetName = "";
			this.ultraGridColumnChooser1.TabIndex = 2;
			this.ultraGridColumnChooser1.Text = "ultraGridColumnChooser1";
			// 
			// botonOrdenarAsc
			// 
			this.botonOrdenarAsc.AcceptsFocus = false;
			this.botonOrdenarAsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			appearance2.Image = global::MarDevs.OC.Win.Properties.Resources.sort_ascending;
			this.botonOrdenarAsc.Appearance = appearance2;
			this.botonOrdenarAsc.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
			this.botonOrdenarAsc.Location = new System.Drawing.Point(201, 0);
			this.botonOrdenarAsc.Name = "botonOrdenarAsc";
			this.botonOrdenarAsc.Size = new System.Drawing.Size(23, 23);
			this.botonOrdenarAsc.TabIndex = 3;
			this.botonOrdenarAsc.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.botonOrdenarAsc.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonOrdenarAsc.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.botonOrdenarAsc.Click += new System.EventHandler(this.botonOrdenarAsc_Click);
			// 
			// FormPersonalizarGrilla
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(257, 393);
			this.Controls.Add(this.botonOrdenarAsc);
			this.Controls.Add(this.ultraGridColumnChooser1);
			this.Controls.Add(this.ultraButton1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "FormPersonalizarGrilla";
			this.ShowInTaskbar = false;
			this.Text = "Personalizar Vista";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPersonalizarGrilla_FormClosing);
			this.Load += new System.EventHandler(this.FormPersonalizarGrilla_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.UltraWinGrid.UltraGridColumnChooser ultraGridColumnChooser1;
		private Infragistics.Win.Misc.UltraButton botonOrdenarAsc;

	}
}