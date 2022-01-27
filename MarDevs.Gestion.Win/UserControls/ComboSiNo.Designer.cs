namespace MarDevs.Gestion.Win
{
    partial class ComboSiNo
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.cboSiNo = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cboSiNo)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSiNo
            // 
            this.cboSiNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSiNo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboSiNo.Location = new System.Drawing.Point(105, 0);
            this.cboSiNo.Name = "cboSiNo";
            this.cboSiNo.Size = new System.Drawing.Size(45, 21);
            this.cboSiNo.TabIndex = 27;
            // 
            // ultraLabel1
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance2;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(3, 4);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(32, 14);
            this.ultraLabel1.TabIndex = 26;
            this.ultraLabel1.Text = "Label";
            this.ultraLabel1.WrapText = false;
            // 
            // ComboSiNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cboSiNo);
            this.Controls.Add(this.ultraLabel1);
            this.Name = "ComboSiNo";
            this.Size = new System.Drawing.Size(150, 21);
            this.Load += new System.EventHandler(this.ComboSiNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSiNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cboSiNo;

    }
}
