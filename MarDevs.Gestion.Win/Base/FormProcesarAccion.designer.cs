namespace MarDevs.Gestion.Win
{
    partial class FormProcesarAccion
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
			this.labelInfo = new Infragistics.Win.Misc.UltraLabel();
			this.panelCentral = new Infragistics.Win.Misc.UltraLabel();
			this.panelBotones = new Infragistics.Win.Misc.UltraLabel();
			this.tareaProgressBar = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
			this.aceptarButton = new Infragistics.Win.Misc.UltraButton();
			this.cancelarButton = new Infragistics.Win.Misc.UltraButton();
			this.SuspendLayout();
			// 
			// labelInfo
			// 
			appearance1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			appearance1.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
			appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance1.FontData.BoldAsString = "False";
			appearance1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			appearance1.TextVAlignAsString = "Middle";
			this.labelInfo.Appearance = appearance1;
			this.labelInfo.BackColorInternal = System.Drawing.Color.Transparent;
			this.labelInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelInfo.Location = new System.Drawing.Point(0, 0);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Padding = new System.Drawing.Size(8, 8);
			this.labelInfo.Size = new System.Drawing.Size(423, 56);
			this.labelInfo.TabIndex = 0;
			this.labelInfo.Text = "Información sobre la tarea que se va a realizar";
			// 
			// panelCentral
			// 
			this.panelCentral.BackColorInternal = System.Drawing.Color.Transparent;
			this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelCentral.Location = new System.Drawing.Point(0, 56);
			this.panelCentral.Name = "panelCentral";
			this.panelCentral.Size = new System.Drawing.Size(423, 104);
			this.panelCentral.TabIndex = 1;
			// 
			// panelBotones
			// 
			this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBotones.Location = new System.Drawing.Point(0, 160);
			this.panelBotones.Name = "panelBotones";
			this.panelBotones.Size = new System.Drawing.Size(423, 48);
			this.panelBotones.TabIndex = 2;
			// 
			// tareaProgressBar
			// 
			this.tareaProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tareaProgressBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.InsetSoft;
			this.tareaProgressBar.Location = new System.Drawing.Point(12, 172);
			this.tareaProgressBar.Name = "tareaProgressBar";
			this.tareaProgressBar.Size = new System.Drawing.Size(231, 24);
			this.tareaProgressBar.TabIndex = 5;
			this.tareaProgressBar.Text = "[Value]/[Maximum]";
			// 
			// aceptarButton
			// 
			this.aceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.aceptarButton.Location = new System.Drawing.Point(249, 172);
			this.aceptarButton.Name = "aceptarButton";
			this.aceptarButton.Size = new System.Drawing.Size(80, 24);
			this.aceptarButton.TabIndex = 6;
			this.aceptarButton.Text = "&Aceptar";
			this.aceptarButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
			// 
			// cancelarButton
			// 
			this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelarButton.CausesValidation = false;
			this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelarButton.Location = new System.Drawing.Point(335, 172);
			this.cancelarButton.Name = "cancelarButton";
			this.cancelarButton.Size = new System.Drawing.Size(80, 24);
			this.cancelarButton.TabIndex = 7;
			this.cancelarButton.Text = "Cancelar";
			this.cancelarButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
			// 
			// FormProcesarAccion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(423, 208);
			this.Controls.Add(this.cancelarButton);
			this.Controls.Add(this.aceptarButton);
			this.Controls.Add(this.tareaProgressBar);
			this.Controls.Add(this.panelCentral);
			this.Controls.Add(this.panelBotones);
			this.Controls.Add(this.labelInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(600, 450);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 200);
			this.Name = "FormProcesarAccion";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.FormProcesarAccion_Load);
			this.ResumeLayout(false);

        }

        #endregion

        protected Infragistics.Win.Misc.UltraLabel labelInfo;
		protected Infragistics.Win.Misc.UltraLabel panelCentral;
		protected Infragistics.Win.Misc.UltraLabel panelBotones;
		protected Infragistics.Win.UltraWinProgressBar.UltraProgressBar tareaProgressBar;
		protected Infragistics.Win.Misc.UltraButton aceptarButton;
		protected Infragistics.Win.Misc.UltraButton cancelarButton;


    }
}