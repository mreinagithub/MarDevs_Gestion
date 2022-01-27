namespace MarDevs.Gestion.Win
{
	partial class FormPropiedadesCarpeta
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelDescripcion = new Infragistics.Win.Misc.UltraLabel();
			this.botonAceptar = new Infragistics.Win.Misc.UltraButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelDescripcion);
			this.groupBox1.Location = new System.Drawing.Point(12, 30);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(359, 224);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Descripción";
			// 
			// labelDescripcion
			// 
			this.labelDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labelDescripcion.Location = new System.Drawing.Point(6, 19);
			this.labelDescripcion.Name = "labelDescripcion";
			this.labelDescripcion.Padding = new System.Drawing.Size(0, 5);
			this.labelDescripcion.Size = new System.Drawing.Size(347, 199);
			this.labelDescripcion.TabIndex = 1;
			this.labelDescripcion.Text = "No hay descripción para esta carpeta";
			// 
			// botonAceptar
			// 
			this.botonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonAceptar.Location = new System.Drawing.Point(291, 260);
			this.botonAceptar.Name = "botonAceptar";
			this.botonAceptar.Size = new System.Drawing.Size(80, 24);
			this.botonAceptar.TabIndex = 1;
			this.botonAceptar.Text = "Aceptar";
			this.botonAceptar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
			// 
			// FormPropiedadesCarpeta
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(383, 290);
			this.Controls.Add(this.botonAceptar);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPropiedadesCarpeta";
			this.Text = "Propiedades";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		protected Infragistics.Win.Misc.UltraButton botonAceptar;
		public Infragistics.Win.Misc.UltraLabel labelDescripcion;
	}
}