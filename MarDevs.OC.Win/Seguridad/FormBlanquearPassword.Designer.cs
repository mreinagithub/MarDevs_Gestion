namespace MarDevs.OC.Win
{
	partial class FormBlanquearPassword
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
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			this.BotonCancelar = new Infragistics.Win.Misc.UltraButton();
			this.BotonAceptar = new Infragistics.Win.Misc.UltraButton();
			this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPasswordNuevo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPasswordNuevo2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.lblInfo = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordNuevo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordNuevo2)).BeginInit();
			this.SuspendLayout();
			// 
			// BotonCancelar
			// 
			this.BotonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BotonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BotonCancelar.Location = new System.Drawing.Point(257, 109);
			this.BotonCancelar.Name = "BotonCancelar";
			this.BotonCancelar.Size = new System.Drawing.Size(80, 24);
			this.BotonCancelar.TabIndex = 15;
			this.BotonCancelar.Text = "Cancelar";
			this.BotonCancelar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			// 
			// BotonAceptar
			// 
			this.BotonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BotonAceptar.Location = new System.Drawing.Point(167, 109);
			this.BotonAceptar.Name = "BotonAceptar";
			this.BotonAceptar.Size = new System.Drawing.Size(82, 24);
			this.BotonAceptar.TabIndex = 14;
			this.BotonAceptar.Text = "Aceptar";
			this.BotonAceptar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.BotonAceptar.Click += new System.EventHandler(this.BotonAceptar_Click);
			// 
			// UltraLabel3
			// 
			this.UltraLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance3.TextVAlignAsString = "Middle";
			this.UltraLabel3.Appearance = appearance3;
			this.UltraLabel3.AutoSize = true;
			this.UltraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
			this.UltraLabel3.Location = new System.Drawing.Point(12, 42);
			this.UltraLabel3.Name = "UltraLabel3";
			this.UltraLabel3.Size = new System.Drawing.Size(100, 14);
			this.UltraLabel3.TabIndex = 10;
			this.UltraLabel3.Text = "Contraseña nueva:";
			// 
			// txtPasswordNuevo
			// 
			this.txtPasswordNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPasswordNuevo.Location = new System.Drawing.Point(169, 39);
			this.txtPasswordNuevo.Name = "txtPasswordNuevo";
			this.txtPasswordNuevo.PasswordChar = '*';
			this.txtPasswordNuevo.Size = new System.Drawing.Size(168, 21);
			this.txtPasswordNuevo.TabIndex = 11;
			// 
			// UltraLabel2
			// 
			this.UltraLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance4.TextVAlignAsString = "Middle";
			this.UltraLabel2.Appearance = appearance4;
			this.UltraLabel2.AutoSize = true;
			this.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
			this.UltraLabel2.Location = new System.Drawing.Point(12, 70);
			this.UltraLabel2.Name = "UltraLabel2";
			this.UltraLabel2.Size = new System.Drawing.Size(150, 14);
			this.UltraLabel2.TabIndex = 12;
			this.UltraLabel2.Text = "Confirmar contraseña nueva:";
			// 
			// txtPasswordNuevo2
			// 
			this.txtPasswordNuevo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPasswordNuevo2.Location = new System.Drawing.Point(169, 67);
			this.txtPasswordNuevo2.Name = "txtPasswordNuevo2";
			this.txtPasswordNuevo2.PasswordChar = '*';
			this.txtPasswordNuevo2.Size = new System.Drawing.Size(168, 21);
			this.txtPasswordNuevo2.TabIndex = 13;
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(12, 12);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(83, 14);
			this.lblInfo.TabIndex = 16;
			this.lblInfo.Text = "DESCRIPCION";
			// 
			// FormBlanquearPassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(343, 145);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.BotonCancelar);
			this.Controls.Add(this.BotonAceptar);
			this.Controls.Add(this.UltraLabel3);
			this.Controls.Add(this.txtPasswordNuevo);
			this.Controls.Add(this.UltraLabel2);
			this.Controls.Add(this.txtPasswordNuevo2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormBlanquearPassword";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Blanquear contraseña";
			this.Load += new System.EventHandler(this.FormBlanquearPassword_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordNuevo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordNuevo2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal Infragistics.Win.Misc.UltraButton BotonCancelar;
		internal Infragistics.Win.Misc.UltraButton BotonAceptar;
		internal Infragistics.Win.Misc.UltraLabel UltraLabel3;
		internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtPasswordNuevo;
		internal Infragistics.Win.Misc.UltraLabel UltraLabel2;
		internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtPasswordNuevo2;
		private Infragistics.Win.Misc.UltraLabel lblInfo;
	}
}