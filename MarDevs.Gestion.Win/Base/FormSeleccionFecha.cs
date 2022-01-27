using System;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{

	public class FormSeleccionFecha : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		#region Variables del Diseñador

		private Infragistics.Win.Misc.UltraButton botonAceptar;
		internal Infragistics.Win.Misc.UltraLabel labelFecha;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtFecha;
		private Infragistics.Win.Misc.UltraButton botonCancelar;
		#endregion
		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormSeleccionFecha));
			this.labelFecha = new Infragistics.Win.Misc.UltraLabel();
			this.botonCancelar = new Infragistics.Win.Misc.UltraButton();
			this.botonAceptar = new Infragistics.Win.Misc.UltraButton();
			this.txtFecha = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			((System.ComponentModel.ISupportInitialize)(this.txtFecha)).BeginInit();
			this.SuspendLayout();
			// 
			// labelFecha
			// 
			this.labelFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.labelFecha.Appearance = appearance1;
			this.labelFecha.BackColor = System.Drawing.Color.Transparent;
			this.labelFecha.Location = new System.Drawing.Point(8, 40);
			this.labelFecha.Name = "labelFecha";
			this.labelFecha.Size = new System.Drawing.Size(208, 23);
			this.labelFecha.TabIndex = 87;
			this.labelFecha.Text = "(parametro) textoAyuda";
			// 
			// botonCancelar
			// 
			this.botonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.botonCancelar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonCancelar.Location = new System.Drawing.Point(216, 104);
			this.botonCancelar.Name = "botonCancelar";
			this.botonCancelar.Size = new System.Drawing.Size(88, 24);
			this.botonCancelar.TabIndex = 86;
			this.botonCancelar.Text = "Cancelar";
			this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
			// 
			// botonAceptar
			// 
			this.botonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.botonAceptar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonAceptar.Location = new System.Drawing.Point(120, 104);
			this.botonAceptar.Name = "botonAceptar";
			this.botonAceptar.Size = new System.Drawing.Size(88, 24);
			this.botonAceptar.TabIndex = 85;
			this.botonAceptar.Text = "Aceptar";
			this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
			// 
			// txtFecha
			// 
			this.txtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFecha.Location = new System.Drawing.Point(216, 40);
			this.txtFecha.Name = "txtFecha";
			this.txtFecha.Size = new System.Drawing.Size(88, 21);
			this.txtFecha.TabIndex = 88;
			// 
			// FormSeleccionFecha
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(314, 135);
			this.Controls.Add(this.txtFecha);
			this.Controls.Add(this.labelFecha);
			this.Controls.Add(this.botonCancelar);
			this.Controls.Add(this.botonAceptar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSeleccionFecha";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Seleccionar Fecha";
			this.Load += new System.EventHandler(this.FormSeleccionFecha_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtFecha)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Constructor(es) y Dispose
		public FormSeleccionFecha():this("Seleccione Fecha"){}
		public FormSeleccionFecha(string textoAyuda)
		{
			// Necesario para admitir el Diseñador de Windows Forms
			InitializeComponent();
		
			this.textoAyuda = textoAyuda.Trim() + ":";
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		private DateTime fecha = ConfigBL.FechaActual;
		private string textoAyuda = String.Empty;

		private void FormSeleccionFecha_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.labelFecha.Text = this.textoAyuda.Trim();
			}
			catch( Exception ex )
			{
				Mensaje.Error(ex.Message, ex);
				this.Close();
			}
		}

		public DateTime SeleccionarFecha()
		{
			this.ShowDialog();
			return this.fecha.Date;
		}

	
		private void botonAceptar_Click(object sender, System.EventArgs e)
		{
			fecha = (DateTime)this.txtFecha.Value;
			this.Close();
		}

		private void botonCancelar_Click(object sender, System.EventArgs e)
		{
			fecha = DateTime.MinValue;
			this.Close();
		}

	}
}
