namespace MarDevs.Gestion.Win
{
    partial class TelefonoUserControl
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            this.comboTipo = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtNumero = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.comboTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero)).BeginInit();
            this.SuspendLayout();
            // 
            // comboTipo
            // 
            this.comboTipo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.comboTipo.Location = new System.Drawing.Point(0, 0);
            this.comboTipo.Margin = new System.Windows.Forms.Padding(0);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(108, 21);
            this.comboTipo.TabIndex = 0;
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            editorButton1.Text = "...";
            this.txtNumero.ButtonsRight.Add(editorButton1);
            this.txtNumero.Location = new System.Drawing.Point(118, 0);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(0);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(190, 21);
            this.txtNumero.TabIndex = 1;
            // 
            // TelefonoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.comboTipo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TelefonoUserControl";
            this.Size = new System.Drawing.Size(308, 21);
            ((System.ComponentModel.ISupportInitialize)(this.comboTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Infragistics.Win.UltraWinEditors.UltraComboEditor comboTipo;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtNumero;

    }
}
