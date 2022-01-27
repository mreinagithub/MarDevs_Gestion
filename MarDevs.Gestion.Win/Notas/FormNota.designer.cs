namespace MarDevs.Gestion.Win
{
    partial class FormNota
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNota));
			this.notaText = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.aceptarButton = new Infragistics.Win.Misc.UltraButton();
			this.cancelarButton = new Infragistics.Win.Misc.UltraButton();
			this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmbConfidencial = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.lblVisibilidad = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.notaText)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbConfidencial)).BeginInit();
			this.SuspendLayout();
			// 
			// notaText
			// 
			this.notaText.AcceptsReturn = true;
			this.notaText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.notaText.Location = new System.Drawing.Point(12, 13);
			this.notaText.MaxLength = 2048;
			this.notaText.Multiline = true;
			this.notaText.Name = "notaText";
			this.notaText.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
			this.notaText.Size = new System.Drawing.Size(448, 224);
			this.notaText.TabIndex = 0;
			// 
			// aceptarButton
			// 
			this.aceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.aceptarButton.Location = new System.Drawing.Point(294, 243);
			this.aceptarButton.Name = "aceptarButton";
			this.aceptarButton.Size = new System.Drawing.Size(80, 24);
			this.aceptarButton.TabIndex = 3;
			this.aceptarButton.Text = "Aceptar";
			this.aceptarButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
			// 
			// cancelarButton
			// 
			this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelarButton.Location = new System.Drawing.Point(380, 243);
			this.cancelarButton.Name = "cancelarButton";
			this.cancelarButton.Size = new System.Drawing.Size(80, 24);
			this.cancelarButton.TabIndex = 4;
			this.cancelarButton.Text = "Cancelar";
			this.cancelarButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
			// 
			// ultraStatusBar1
			// 
			this.ultraStatusBar1.Location = new System.Drawing.Point(0, 279);
			this.ultraStatusBar1.Name = "ultraStatusBar1";
			this.ultraStatusBar1.Size = new System.Drawing.Size(472, 23);
			this.ultraStatusBar1.TabIndex = 4;
			this.ultraStatusBar1.Text = "ultraStatusBar1";
			this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblVisibilidad);
			this.panel1.Controls.Add(this.cmbConfidencial);
			this.panel1.Controls.Add(this.notaText);
			this.panel1.Controls.Add(this.aceptarButton);
			this.panel1.Controls.Add(this.cancelarButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(472, 279);
			this.panel1.TabIndex = 5;
			// 
			// cmbConfidencial
			// 
			this.cmbConfidencial.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbConfidencial.Location = new System.Drawing.Point(77, 245);
			this.cmbConfidencial.Name = "cmbConfidencial";
			this.cmbConfidencial.Size = new System.Drawing.Size(200, 21);
			this.cmbConfidencial.TabIndex = 2;
			// 
			// ultraLabel1
			// 
			this.lblVisibilidad.AutoSize = true;
			this.lblVisibilidad.Location = new System.Drawing.Point(12, 248);
			this.lblVisibilidad.Name = "ultraLabel1";
			this.lblVisibilidad.Size = new System.Drawing.Size(59, 14);
			this.lblVisibilidad.TabIndex = 1;
			this.lblVisibilidad.Text = "Visibilidad:";
			// 
			// FormNota
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelarButton;
			this.ClientSize = new System.Drawing.Size(472, 302);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ultraStatusBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(800, 600);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 300);
			this.Name = "FormNota";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Nota";
			this.Load += new System.EventHandler(this.FormNota_Load);
			((System.ComponentModel.ISupportInitialize)(this.notaText)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbConfidencial)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private Infragistics.Win.UltraWinEditors.UltraTextEditor notaText;
        private Infragistics.Win.Misc.UltraButton aceptarButton;
        private Infragistics.Win.Misc.UltraButton cancelarButton;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private System.Windows.Forms.Panel panel1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbConfidencial;
		private Infragistics.Win.Misc.UltraLabel lblVisibilidad;
    }
}