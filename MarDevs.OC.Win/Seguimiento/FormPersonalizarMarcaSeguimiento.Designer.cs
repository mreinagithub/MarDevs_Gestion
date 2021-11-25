namespace MarDevs.OC.Win
{
	partial class FormPersonalizarMarcaSeguimiento
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPersonalizarMarcaSeguimiento));
			this.cmbImagen = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.txtComentarios = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.chkAviso = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.txtFechaAviso = new MarDevs.OC.Win.FechaHoraUserControl();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.txtFechaSeguimiento = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.tareaProgressBar = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
			this.cancelarButton = new Infragistics.Win.Misc.UltraButton();
			this.aceptarButton = new Infragistics.Win.Misc.UltraButton();
			this.lblInfo = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.cmbImagen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtComentarios)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkAviso)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFechaSeguimiento)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbImagen
			// 
			this.cmbImagen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbImagen.Location = new System.Drawing.Point(286, 32);
			this.cmbImagen.Name = "cmbImagen";
			this.cmbImagen.Size = new System.Drawing.Size(218, 21);
			this.cmbImagen.TabIndex = 8;
			// 
			// txtComentarios
			// 
			this.txtComentarios.Location = new System.Drawing.Point(132, 59);
			this.txtComentarios.Multiline = true;
			this.txtComentarios.Name = "txtComentarios";
			this.txtComentarios.Size = new System.Drawing.Size(372, 50);
			this.txtComentarios.TabIndex = 9;
			// 
			// chkAviso
			// 
			this.chkAviso.Location = new System.Drawing.Point(45, 127);
			this.chkAviso.Name = "chkAviso";
			this.chkAviso.Size = new System.Drawing.Size(81, 20);
			this.chkAviso.TabIndex = 10;
			this.chkAviso.Text = "Aviso";
			// 
			// txtFechaAviso
			// 
			this.txtFechaAviso.BackColor = System.Drawing.Color.Transparent;
			this.txtFechaAviso.IntervaloComboHora = 30;
			this.txtFechaAviso.Location = new System.Drawing.Point(132, 127);
			this.txtFechaAviso.Name = "txtFechaAviso";
			this.txtFechaAviso.Size = new System.Drawing.Size(372, 21);
			this.txtFechaAviso.TabIndex = 11;
			this.txtFechaAviso.Value = null;
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.AutoSize = true;
			this.ultraLabel1.Location = new System.Drawing.Point(7, 36);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(119, 14);
			this.ultraLabel1.TabIndex = 6;
			this.ultraLabel1.Text = "Fecha de seguimiento:";
			// 
			// txtFechaSeguimiento
			// 
			this.txtFechaSeguimiento.Location = new System.Drawing.Point(132, 32);
			this.txtFechaSeguimiento.Name = "txtFechaSeguimiento";
			this.txtFechaSeguimiento.Nullable = false;
			this.txtFechaSeguimiento.Size = new System.Drawing.Size(148, 21);
			this.txtFechaSeguimiento.TabIndex = 7;
			// 
			// tareaProgressBar
			// 
			this.tareaProgressBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.InsetSoft;
			this.tareaProgressBar.Location = new System.Drawing.Point(12, 167);
			this.tareaProgressBar.Name = "tareaProgressBar";
			this.tareaProgressBar.Size = new System.Drawing.Size(320, 24);
			this.tareaProgressBar.TabIndex = 12;
			this.tareaProgressBar.Text = "[Value]/[Maximum]";
			// 
			// cancelarButton
			// 
			this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelarButton.Location = new System.Drawing.Point(424, 167);
			this.cancelarButton.Name = "cancelarButton";
			this.cancelarButton.Size = new System.Drawing.Size(80, 24);
			this.cancelarButton.TabIndex = 14;
			this.cancelarButton.Text = "Cancelar";
			this.cancelarButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			// 
			// aceptarButton
			// 
			this.aceptarButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.aceptarButton.Location = new System.Drawing.Point(338, 167);
			this.aceptarButton.Name = "aceptarButton";
			this.aceptarButton.Size = new System.Drawing.Size(80, 24);
			this.aceptarButton.TabIndex = 13;
			this.aceptarButton.Text = "Aceptar";
			this.aceptarButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
			// 
			// lblInfo
			// 
			appearance1.FontData.BoldAsString = "True";
			this.lblInfo.Appearance = appearance1;
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(7, 8);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(455, 14);
			this.lblInfo.TabIndex = 15;
			this.lblInfo.Text = "La marca de seguimiento es personal y solo podrá ser vista por el usuario que la " +
    "crea.";
			// 
			// FormPersonalizarMarcaSeguimiento
			// 
			this.AcceptButton = this.aceptarButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelarButton;
			this.ClientSize = new System.Drawing.Size(511, 200);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.tareaProgressBar);
			this.Controls.Add(this.cancelarButton);
			this.Controls.Add(this.aceptarButton);
			this.Controls.Add(this.cmbImagen);
			this.Controls.Add(this.txtComentarios);
			this.Controls.Add(this.chkAviso);
			this.Controls.Add(this.txtFechaAviso);
			this.Controls.Add(this.ultraLabel1);
			this.Controls.Add(this.txtFechaSeguimiento);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPersonalizarMarcaSeguimiento";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Personalizar Marca de Seguimiento";
			this.Load += new System.EventHandler(this.FormPersonalizarMarcaSeguimiento_Load);
			((System.ComponentModel.ISupportInitialize)(this.cmbImagen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtComentarios)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkAviso)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFechaSeguimiento)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbImagen;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtComentarios;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAviso;
		private MarDevs.OC.Win.FechaHoraUserControl txtFechaAviso;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtFechaSeguimiento;
		protected Infragistics.Win.UltraWinProgressBar.UltraProgressBar tareaProgressBar;
		protected Infragistics.Win.Misc.UltraButton cancelarButton;
		protected Infragistics.Win.Misc.UltraButton aceptarButton;
		private Infragistics.Win.Misc.UltraLabel lblInfo;
	}
}