namespace MarDevs.Gestion.Win
{
	partial class FormFormulario
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("Seleccionar");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            this.lblTipo = new Infragistics.Win.Misc.UltraLabel();
            this.lblFechaModif = new Infragistics.Win.Misc.UltraLabel();
            this.lblCopias = new Infragistics.Win.Misc.UltraLabel();
            this.lblRutaFormulario = new Infragistics.Win.Misc.UltraLabel();
            this.btnAceptar = new Infragistics.Win.Misc.UltraButton();
            this.btnCancelar = new Infragistics.Win.Misc.UltraButton();
            this.txtTipo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtBuscarFormulario = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtCopias = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.txtFechaModificacion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnExportar = new Infragistics.Win.Misc.UltraButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblLongitudContenido = new Infragistics.Win.Misc.UltraLabel();
            this.txtLongContenido = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtDescripcion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarFormulario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaModificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLongContenido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTipo
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lblTipo.Appearance = appearance1;
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTipo.Location = new System.Drawing.Point(7, 18);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(29, 14);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblFechaModif
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaModif.Appearance = appearance2;
            this.lblFechaModif.AutoSize = true;
            this.lblFechaModif.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblFechaModif.Location = new System.Drawing.Point(7, 102);
            this.lblFechaModif.Name = "lblFechaModif";
            this.lblFechaModif.Size = new System.Drawing.Size(121, 14);
            this.lblFechaModif.TabIndex = 1;
            this.lblFechaModif.Text = "Fecha de Modificación:";
            // 
            // lblCopias
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.lblCopias.Appearance = appearance3;
            this.lblCopias.AutoSize = true;
            this.lblCopias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCopias.Location = new System.Drawing.Point(7, 176);
            this.lblCopias.Name = "lblCopias";
            this.lblCopias.Size = new System.Drawing.Size(107, 14);
            this.lblCopias.TabIndex = 2;
            this.lblCopias.Text = "Cantidad de Copias:";
            // 
            // lblRutaFormulario
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblRutaFormulario.Appearance = appearance4;
            this.lblRutaFormulario.AutoSize = true;
            this.lblRutaFormulario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblRutaFormulario.Location = new System.Drawing.Point(7, 127);
            this.lblRutaFormulario.Name = "lblRutaFormulario";
            this.lblRutaFormulario.Size = new System.Drawing.Size(45, 14);
            this.lblRutaFormulario.TabIndex = 3;
            this.lblRutaFormulario.Text = "Archivo:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.Appearance = appearance5;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(284, 190);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Appearance = appearance6;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(365, 190);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtTipo
            // 
            appearance7.BackColor = System.Drawing.Color.White;
            this.txtTipo.Appearance = appearance7;
            this.txtTipo.BackColor = System.Drawing.Color.White;
            this.txtTipo.Location = new System.Drawing.Point(134, 15);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(186, 21);
            this.txtTipo.TabIndex = 6;
            this.txtTipo.TabStop = false;
            // 
            // txtBuscarFormulario
            // 
            appearance8.BackColor = System.Drawing.Color.White;
            this.txtBuscarFormulario.Appearance = appearance8;
            this.txtBuscarFormulario.BackColor = System.Drawing.Color.White;
            editorButton1.Key = "Seleccionar";
            editorButton1.Text = "...";
            this.txtBuscarFormulario.ButtonsRight.Add(editorButton1);
            this.txtBuscarFormulario.Location = new System.Drawing.Point(7, 146);
            this.txtBuscarFormulario.Name = "txtBuscarFormulario";
            this.txtBuscarFormulario.ReadOnly = true;
            this.txtBuscarFormulario.Size = new System.Drawing.Size(352, 21);
            this.txtBuscarFormulario.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtCopias
            // 
            this.txtCopias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.TextHAlignAsString = "Right";
            this.txtCopias.Appearance = appearance9;
            this.txtCopias.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtCopias.InputMask = "n";
            this.txtCopias.Location = new System.Drawing.Point(134, 173);
            this.txtCopias.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtCopias.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCopias.Name = "txtCopias";
            this.txtCopias.Nullable = false;
            this.txtCopias.PromptChar = ' ';
            this.txtCopias.Size = new System.Drawing.Size(58, 20);
            this.txtCopias.SpinButtonDisplayStyle = Infragistics.Win.SpinButtonDisplayStyle.OnRight;
            this.txtCopias.TabIndex = 2;
            this.txtCopias.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.txtCopias.Text = "1";
            // 
            // txtFechaModificacion
            // 
            appearance10.BackColor = System.Drawing.Color.White;
            this.txtFechaModificacion.Appearance = appearance10;
            this.txtFechaModificacion.BackColor = System.Drawing.Color.White;
            this.txtFechaModificacion.Location = new System.Drawing.Point(134, 99);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.ReadOnly = true;
            this.txtFechaModificacion.Size = new System.Drawing.Size(186, 21);
            this.txtFechaModificacion.TabIndex = 7;
            this.txtFechaModificacion.TabStop = false;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance11.BackColor = System.Drawing.Color.Transparent;
            this.btnExportar.Appearance = appearance11;
            this.btnExportar.Location = new System.Drawing.Point(365, 145);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblLongitudContenido
            // 
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.lblLongitudContenido.Appearance = appearance12;
            this.lblLongitudContenido.AutoSize = true;
            this.lblLongitudContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblLongitudContenido.Location = new System.Drawing.Point(7, 75);
            this.lblLongitudContenido.Name = "lblLongitudContenido";
            this.lblLongitudContenido.Size = new System.Drawing.Size(122, 14);
            this.lblLongitudContenido.TabIndex = 8;
            this.lblLongitudContenido.Text = "Tamaño del Contenido:";
            // 
            // txtLongContenido
            // 
            appearance13.BackColor = System.Drawing.Color.White;
            this.txtLongContenido.Appearance = appearance13;
            this.txtLongContenido.BackColor = System.Drawing.Color.White;
            this.txtLongContenido.Location = new System.Drawing.Point(134, 72);
            this.txtLongContenido.Name = "txtLongContenido";
            this.txtLongContenido.ReadOnly = true;
            this.txtLongContenido.Size = new System.Drawing.Size(186, 21);
            this.txtLongContenido.TabIndex = 9;
            this.txtLongContenido.TabStop = false;
            // 
            // txtDescripcion
            // 
            appearance14.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Appearance = appearance14;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(134, 42);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(186, 21);
            this.txtDescripcion.TabIndex = 11;
            this.txtDescripcion.TabStop = false;
            // 
            // ultraLabel1
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance15;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ultraLabel1.Location = new System.Drawing.Point(7, 45);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(67, 14);
            this.ultraLabel1.TabIndex = 10;
            this.ultraLabel1.Text = "Descripción:";
            // 
            // FormFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(443, 225);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.txtLongContenido);
            this.Controls.Add(this.lblLongitudContenido);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.txtFechaModificacion);
            this.Controls.Add(this.txtCopias);
            this.Controls.Add(this.txtBuscarFormulario);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblRutaFormulario);
            this.Controls.Add(this.lblCopias);
            this.Controls.Add(this.lblFechaModif);
            this.Controls.Add(this.lblTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFormulario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario";
            this.Load += new System.EventHandler(this.FormFormulario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarFormulario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaModificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLongContenido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraLabel lblTipo;
		private Infragistics.Win.Misc.UltraLabel lblFechaModif;
		private Infragistics.Win.Misc.UltraLabel lblCopias;
		private Infragistics.Win.Misc.UltraLabel lblRutaFormulario;
		private Infragistics.Win.Misc.UltraButton btnAceptar;
		private Infragistics.Win.Misc.UltraButton btnCancelar;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTipo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBuscarFormulario;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFechaModificacion;
		private Infragistics.Win.Misc.UltraButton btnExportar;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit txtCopias;
		private Infragistics.Win.Misc.UltraLabel lblLongitudContenido;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLongContenido;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDescripcion;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
	}
}