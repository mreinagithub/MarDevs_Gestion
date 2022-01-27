namespace MarDevs.Gestion.Win
{
	partial class FormImprimirFormulario
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
			this.textoCopias = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.comboImpresoras = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.labelCopias = new Infragistics.Win.Misc.UltraLabel();
			this.btnImprimir = new Infragistics.Win.Misc.UltraButton();
			this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
			((System.ComponentModel.ISupportInitialize)(this.comboImpresoras)).BeginInit();
			this.SuspendLayout();
			// 
			// textoCopias
			// 
			appearance1.TextHAlignAsString = "Right";
			this.textoCopias.Appearance = appearance1;
			this.textoCopias.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
			this.textoCopias.InputMask = "n";
			this.textoCopias.Location = new System.Drawing.Point(122, 66);
			this.textoCopias.Name = "textoCopias";
			this.textoCopias.Nullable = false;
			this.textoCopias.PromptChar = ' ';
			this.textoCopias.Size = new System.Drawing.Size(47, 20);
			this.textoCopias.SpinButtonDisplayStyle = Infragistics.Win.SpinButtonDisplayStyle.OnRight;
			this.textoCopias.TabIndex = 3;
			this.textoCopias.Text = "1";
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.AutoSize = true;
			this.ultraLabel1.Location = new System.Drawing.Point(12, 12);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(304, 14);
			this.ultraLabel1.TabIndex = 0;
			this.ultraLabel1.Text = "Por favor, seleccione una impresora y confirme la impresión";
			// 
			// comboImpresoras
			// 
			this.comboImpresoras.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.comboImpresoras.Location = new System.Drawing.Point(12, 35);
			this.comboImpresoras.Name = "comboImpresoras";
			this.comboImpresoras.Size = new System.Drawing.Size(370, 21);
			this.comboImpresoras.TabIndex = 1;
			// 
			// labelCopias
			// 
			this.labelCopias.AutoSize = true;
			this.labelCopias.Location = new System.Drawing.Point(12, 72);
			this.labelCopias.Name = "labelCopias";
			this.labelCopias.Size = new System.Drawing.Size(104, 14);
			this.labelCopias.TabIndex = 2;
			this.labelCopias.Text = "Cantidad de copias:";
			// 
			// btnImprimir
			// 
			this.btnImprimir.Location = new System.Drawing.Point(226, 105);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(75, 23);
			this.btnImprimir.TabIndex = 5;
			this.btnImprimir.Text = "Imprimir";
			this.btnImprimir.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(307, 105);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 6;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// FormImprimirFormulario
			// 
			this.AcceptButton = this.btnImprimir;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(392, 141);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnImprimir);
			this.Controls.Add(this.textoCopias);
			this.Controls.Add(this.ultraLabel1);
			this.Controls.Add(this.comboImpresoras);
			this.Controls.Add(this.labelCopias);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormImprimirFormulario";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Impresión de formulario";
			this.Load += new System.EventHandler(this.FormImprimirFormulario_Load);
			((System.ComponentModel.ISupportInitialize)(this.comboImpresoras)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel labelCopias;
		private Infragistics.Win.Misc.UltraButton btnImprimir;
		private Infragistics.Win.Misc.UltraButton btnCancelar;
		public Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit textoCopias;
		public Infragistics.Win.UltraWinEditors.UltraComboEditor comboImpresoras;
	}
}