namespace MarDevs.OC.Win
{
    partial class FechaHoraUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.dtFecha = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.comboHora = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			((System.ComponentModel.ISupportInitialize)(this.dtFecha)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboHora)).BeginInit();
			this.SuspendLayout();
			// 
			// dtFecha
			// 
			this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dtFecha.Location = new System.Drawing.Point(0, 0);
			this.dtFecha.Name = "dtFecha";
			this.dtFecha.Size = new System.Drawing.Size(130, 21);
			this.dtFecha.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
			this.dtFecha.TabIndex = 0;
			this.dtFecha.Value = null;
			// 
			// comboHora
			// 
			this.comboHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboHora.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
			this.comboHora.Enabled = false;
			this.comboHora.Location = new System.Drawing.Point(134, 0);
			this.comboHora.MaxLength = 5;
			this.comboHora.Name = "comboHora";
			this.comboHora.Size = new System.Drawing.Size(67, 21);
			this.comboHora.TabIndex = 1;
			// 
			// FechaHoraUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.comboHora);
			this.Controls.Add(this.dtFecha);
			this.Name = "FechaHoraUserControl";
			this.Size = new System.Drawing.Size(209, 21);
			((System.ComponentModel.ISupportInitialize)(this.dtFecha)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboHora)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor comboHora;
        public Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtFecha;
    }
}
