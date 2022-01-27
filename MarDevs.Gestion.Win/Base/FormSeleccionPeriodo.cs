using System;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{

	public class FormSeleccionPeriodo : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		#region Variables del Diseñador

		private Infragistics.Win.Misc.UltraButton botonAceptar;
		internal Infragistics.Win.Misc.UltraLabel labelFecha;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDesde;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtHasta;
		internal Infragistics.Win.Misc.UltraLabel ultraLabel1;
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
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeleccionPeriodo));
			this.labelFecha = new Infragistics.Win.Misc.UltraLabel();
			this.botonCancelar = new Infragistics.Win.Misc.UltraButton();
			this.botonAceptar = new Infragistics.Win.Misc.UltraButton();
			this.txtDesde = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.txtHasta = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.txtDesde)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHasta)).BeginInit();
			this.SuspendLayout();
			// 
			// labelFecha
			// 
			this.labelFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance1.TextVAlignAsString = "Middle";
			this.labelFecha.Appearance = appearance1;
			this.labelFecha.BackColorInternal = System.Drawing.Color.Transparent;
			this.labelFecha.Location = new System.Drawing.Point(120, 16);
			this.labelFecha.Name = "labelFecha";
			this.labelFecha.Size = new System.Drawing.Size(48, 23);
			this.labelFecha.TabIndex = 0;
			this.labelFecha.Text = "Desde:";
			// 
			// botonCancelar
			// 
			this.botonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.botonCancelar.Location = new System.Drawing.Point(200, 104);
			this.botonCancelar.Name = "botonCancelar";
			this.botonCancelar.Size = new System.Drawing.Size(88, 24);
			this.botonCancelar.TabIndex = 5;
			this.botonCancelar.Text = "Cancelar";
			this.botonCancelar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
			// 
			// botonAceptar
			// 
			this.botonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.botonAceptar.Location = new System.Drawing.Point(104, 104);
			this.botonAceptar.Name = "botonAceptar";
			this.botonAceptar.Size = new System.Drawing.Size(88, 24);
			this.botonAceptar.TabIndex = 4;
			this.botonAceptar.Text = "Aceptar";
			this.botonAceptar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
			// 
			// txtDesde
			// 
			this.txtDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDesde.Location = new System.Drawing.Point(184, 16);
			this.txtDesde.Name = "txtDesde";
			this.txtDesde.Size = new System.Drawing.Size(104, 21);
			this.txtDesde.TabIndex = 1;
			// 
			// txtHasta
			// 
			this.txtHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHasta.Location = new System.Drawing.Point(184, 48);
			this.txtHasta.Name = "txtHasta";
			this.txtHasta.Size = new System.Drawing.Size(104, 21);
			this.txtHasta.TabIndex = 3;
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance2.TextVAlignAsString = "Middle";
			this.ultraLabel1.Appearance = appearance2;
			this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel1.Location = new System.Drawing.Point(120, 48);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(48, 23);
			this.ultraLabel1.TabIndex = 2;
			this.ultraLabel1.Text = "Hasta:";
			// 
			// FormSeleccionPeriodo
			// 
			this.AcceptButton = this.botonAceptar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.botonCancelar;
			this.ClientSize = new System.Drawing.Size(298, 135);
			this.Controls.Add(this.txtHasta);
			this.Controls.Add(this.ultraLabel1);
			this.Controls.Add(this.txtDesde);
			this.Controls.Add(this.labelFecha);
			this.Controls.Add(this.botonCancelar);
			this.Controls.Add(this.botonAceptar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSeleccionPeriodo";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Seleccione un período";
			this.Load += new System.EventHandler(this.FormSeleccionPeriodo_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtDesde)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHasta)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		#region Constructor(es) y Dispose
		public FormSeleccionPeriodo(Periodo periodo)
		{
			InitializeComponent();
			this.periodo = periodo;

			this.txtDesde.Leave +=new EventHandler(txtDesde_Leave);
			this.txtHasta.Leave+=new EventHandler(txtHasta_Leave);
			this.txtDesde.Enter += new EventHandler(txtDesde_Enter);
			this.txtHasta.Enter += new EventHandler(txtHasta_Enter);
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

		private Periodo periodo = null;

		private void FormSeleccionPeriodo_Load(object sender, System.EventArgs e)
		{
			this.txtDesde.Value = this.periodo.Desde;
			this.txtHasta.Value = this.periodo.Hasta;
		}

		private void botonAceptar_Click(object sender, System.EventArgs e)
		{
			DateTime desde = this.txtDesde.DateTime;
			DateTime hasta = this.txtHasta.DateTime;

			this.periodo.Desde = new DateTime(desde.Year, desde.Month, desde.Day, 0, 0, 0);
			this.periodo.Hasta = new DateTime(hasta.Year, hasta.Month, hasta.Day, 23, 59, 59);
			this.Close();
		}
		private void botonCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void txtDesde_Leave(object sender, System.EventArgs e)
		{
			if ( this.txtDesde.DateTime > this.txtHasta.DateTime )
			{
				this.txtHasta.DateTime = this.txtDesde.DateTime;
			}
		}
		private void txtHasta_Leave(object sender, EventArgs e)
		{
			if ( this.txtHasta.DateTime < this.txtDesde.DateTime )
			{
				this.txtDesde.DateTime = this.txtHasta.DateTime;
			}
		}
		private void txtHasta_Enter(object sender, EventArgs e)
		{
			this.txtHasta.SelectAll();
		}
		private void txtDesde_Enter(object sender, EventArgs e)
		{
			this.txtDesde.SelectAll();
		}

	}
}
