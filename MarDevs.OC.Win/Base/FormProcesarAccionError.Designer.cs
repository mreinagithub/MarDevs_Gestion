namespace MarDevs.OC.Win
{
    partial class FormProcesarAccionError
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
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcesarAccionError));
			this.grillaErrores = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.BtnDetalle = new Infragistics.Win.Misc.UltraButton();
			this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
			this.textError = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.btnExportar = new Infragistics.Win.Misc.UltraButton();
			((System.ComponentModel.ISupportInitialize)(this.grillaErrores)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textError)).BeginInit();
			this.SuspendLayout();
			// 
			// grillaErrores
			// 
			appearance1.BackColor = System.Drawing.SystemColors.Window;
			this.grillaErrores.DisplayLayout.Appearance = appearance1;
			this.grillaErrores.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
			this.grillaErrores.DisplayLayout.MaxBandDepth = 1;
			this.grillaErrores.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.grillaErrores.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.grillaErrores.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			this.grillaErrores.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.grillaErrores.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
			appearance2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.grillaErrores.DisplayLayout.Override.RowAppearance = appearance2;
			this.grillaErrores.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			this.grillaErrores.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaErrores.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaErrores.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
			this.grillaErrores.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.grillaErrores.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.grillaErrores.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.grillaErrores.Dock = System.Windows.Forms.DockStyle.Top;
			this.grillaErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grillaErrores.Location = new System.Drawing.Point(0, 0);
			this.grillaErrores.Name = "grillaErrores";
			this.grillaErrores.Size = new System.Drawing.Size(494, 115);
			this.grillaErrores.TabIndex = 0;
			this.grillaErrores.AfterRowActivate += new System.EventHandler(this.grillaErrores_AfterRowActivate);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 115);
			this.splitter1.MaximumSize = new System.Drawing.Size(0, 150);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(494, 3);
			this.splitter1.TabIndex = 9;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.AutoScrollMargin = new System.Drawing.Size(10, 10);
			this.panel1.Controls.Add(this.btnExportar);
			this.panel1.Controls.Add(this.BtnDetalle);
			this.panel1.Controls.Add(this.ultraButton1);
			this.panel1.Controls.Add(this.textError);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 118);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(494, 100);
			this.panel1.TabIndex = 10;
			// 
			// BtnDetalle
			// 
			this.BtnDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnDetalle.Location = new System.Drawing.Point(326, 73);
			this.BtnDetalle.Name = "BtnDetalle";
			this.BtnDetalle.Size = new System.Drawing.Size(75, 23);
			this.BtnDetalle.TabIndex = 2;
			this.BtnDetalle.Text = "Detalle";
			this.BtnDetalle.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.BtnDetalle.Click += new System.EventHandler(this.ultraButton2_Click);
			// 
			// ultraButton1
			// 
			this.ultraButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ultraButton1.Location = new System.Drawing.Point(407, 73);
			this.ultraButton1.Name = "ultraButton1";
			this.ultraButton1.Size = new System.Drawing.Size(75, 23);
			this.ultraButton1.TabIndex = 3;
			this.ultraButton1.Text = "Cerrar";
			this.ultraButton1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
			// 
			// textError
			// 
			this.textError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textError.Location = new System.Drawing.Point(6, 5);
			this.textError.Multiline = true;
			this.textError.Name = "textError";
			this.textError.ReadOnly = true;
			this.textError.Size = new System.Drawing.Size(482, 62);
			this.textError.TabIndex = 0;
			// 
			// btnExportar
			// 
			this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			appearance3.Image = global::MarDevs.OC.Win.Properties.Resources.EXCEL_1;
			this.btnExportar.Appearance = appearance3;
			this.btnExportar.Location = new System.Drawing.Point(245, 73);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(75, 23);
			this.btnExportar.TabIndex = 1;
			this.btnExportar.Text = "Exportar";
			this.btnExportar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
			// 
			// FormProcesarAccionError
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 218);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.grillaErrores);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormProcesarAccionError";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Se han producido errores al procesar ";
			this.Load += new System.EventHandler(this.FormProcesarAccionError_Load);
			this.Resize += new System.EventHandler(this.FormProcesarAccionError_Resize);
			((System.ComponentModel.ISupportInitialize)(this.grillaErrores)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.textError)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid grillaErrores;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor textError;
        private Infragistics.Win.Misc.UltraButton BtnDetalle;
		private Infragistics.Win.Misc.UltraButton btnExportar;


    }
}