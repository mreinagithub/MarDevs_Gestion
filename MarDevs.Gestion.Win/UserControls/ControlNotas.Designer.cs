namespace MarDevs.Gestion.Win
{
	partial class ControlNotas
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

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			this.botonEliminarNota = new Infragistics.Win.Misc.UltraButton();
			this.botonAgregarNota = new Infragistics.Win.Misc.UltraButton();
			this.grillaNotas = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelEntidad = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.grillaNotas)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// botonEliminarNota
			// 
            appearance1.Image = global::MarDevs.Gestion.Win.Properties.Resources.ImagenPrivilegioDenegado;
			this.botonEliminarNota.Appearance = appearance1;
			this.botonEliminarNota.Location = new System.Drawing.Point(126, 3);
			this.botonEliminarNota.Name = "botonEliminarNota";
			this.botonEliminarNota.Size = new System.Drawing.Size(117, 27);
			this.botonEliminarNota.TabIndex = 5;
			this.botonEliminarNota.Text = "Eliminar Nota";
			this.botonEliminarNota.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonEliminarNota.Click += new System.EventHandler(this.botonEliminarNota_Click);
			// 
			// botonAgregarNota
			// 
			appearance2.Image = global::MarDevs.Gestion.Win.Properties.Resources.ImagenAgregar;
			this.botonAgregarNota.Appearance = appearance2;
			this.botonAgregarNota.Location = new System.Drawing.Point(3, 3);
			this.botonAgregarNota.Name = "botonAgregarNota";
			this.botonAgregarNota.Size = new System.Drawing.Size(117, 27);
			this.botonAgregarNota.TabIndex = 3;
			this.botonAgregarNota.Text = "Agregar Nota";
			this.botonAgregarNota.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonAgregarNota.Click += new System.EventHandler(this.botonAgregarNota_Click);
			// 
			// grillaNotas
			// 
			appearance3.BackColor = System.Drawing.Color.White;
			this.grillaNotas.DisplayLayout.Appearance = appearance3;
			this.grillaNotas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
			ultraGridBand1.AddButtonCaption = "DummyBand 1";
			this.grillaNotas.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
			this.grillaNotas.DisplayLayout.MaxBandDepth = 1;
			this.grillaNotas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.grillaNotas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
			this.grillaNotas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			this.grillaNotas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
			appearance4.BackColor = System.Drawing.Color.Transparent;
			this.grillaNotas.DisplayLayout.Override.CardAreaAppearance = appearance4;
			this.grillaNotas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.grillaNotas.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
			appearance5.TextHAlignAsString = "Left";
			this.grillaNotas.DisplayLayout.Override.HeaderAppearance = appearance5;
			this.grillaNotas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
			appearance6.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			appearance6.TextVAlignAsString = "Middle";
			this.grillaNotas.DisplayLayout.Override.RowAppearance = appearance6;
			appearance7.BackColor = System.Drawing.SystemColors.Window;
			appearance7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grillaNotas.DisplayLayout.Override.RowPreviewAppearance = appearance7;
			this.grillaNotas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance8.BackColor = System.Drawing.SystemColors.Highlight;
			appearance8.BorderColor = System.Drawing.Color.Black;
			appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grillaNotas.DisplayLayout.Override.SelectedRowAppearance = appearance8;
			this.grillaNotas.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaNotas.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaNotas.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			this.grillaNotas.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
			this.grillaNotas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.grillaNotas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.grillaNotas.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
			this.grillaNotas.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.grillaNotas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grillaNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grillaNotas.Location = new System.Drawing.Point(0, 33);
			this.grillaNotas.Name = "grillaNotas";
			this.grillaNotas.Size = new System.Drawing.Size(447, 270);
			this.grillaNotas.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.botonEliminarNota);
			this.panel1.Controls.Add(this.botonAgregarNota);
			this.panel1.Controls.Add(this.labelEntidad);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(447, 33);
			this.panel1.TabIndex = 6;
			// 
			// labelEntidad
			// 
			this.labelEntidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance9.FontData.BoldAsString = "True";
			appearance9.FontData.SizeInPoints = 11F;
			appearance9.TextHAlignAsString = "Right";
			appearance9.TextVAlignAsString = "Middle";
			this.labelEntidad.Appearance = appearance9;
			this.labelEntidad.Location = new System.Drawing.Point(249, 4);
			this.labelEntidad.Name = "labelEntidad";
			this.labelEntidad.Size = new System.Drawing.Size(195, 23);
			this.labelEntidad.TabIndex = 6;
			this.labelEntidad.Text = "ultraLabel1";
			// 
			// ControlNotas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.grillaNotas);
			this.Controls.Add(this.panel1);
			this.Name = "ControlNotas";
			this.Size = new System.Drawing.Size(447, 303);
			((System.ComponentModel.ISupportInitialize)(this.grillaNotas)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.Misc.UltraButton botonEliminarNota;
		private Infragistics.Win.Misc.UltraButton botonAgregarNota;
		private Infragistics.Win.UltraWinGrid.UltraGrid grillaNotas;
		private System.Windows.Forms.Panel panel1;
		private Infragistics.Win.Misc.UltraLabel labelEntidad;
	}
}
