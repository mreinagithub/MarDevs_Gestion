using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MarDevs.Gestion.Win
{
	public class FormMensaje : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		#region Variables del Diseñador
		private System.Windows.Forms.Panel panelMensaje;
		private Infragistics.Win.UltraWinEditors.UltraPictureBox imagenMensaje;
		private Infragistics.Win.Misc.UltraLabel labelMensaje;
		private Infragistics.Win.Misc.UltraButton botonAceptar;
		private Infragistics.Win.Misc.UltraButton botonDetalles;

		private System.Windows.Forms.Panel panelDetalle;
		private Infragistics.Win.Misc.UltraButton botonCopiarDetalle;
		private System.Windows.Forms.GroupBox grpDetalle;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetalle;
		#endregion
		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMensaje));
			this.panelDetalle = new System.Windows.Forms.Panel();
			this.grpDetalle = new System.Windows.Forms.GroupBox();
			this.botonCopiarDetalle = new Infragistics.Win.Misc.UltraButton();
			this.txtDetalle = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.panelMensaje = new System.Windows.Forms.Panel();
			this.labelMensaje = new Infragistics.Win.Misc.UltraLabel();
			this.imagenMensaje = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
			this.botonDetalles = new Infragistics.Win.Misc.UltraButton();
			this.botonAceptar = new Infragistics.Win.Misc.UltraButton();
			this.panelDetalle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtDetalle)).BeginInit();
			this.panelMensaje.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelDetalle
			// 
			this.panelDetalle.BackColor = System.Drawing.Color.Transparent;
			this.panelDetalle.Controls.Add(this.grpDetalle);
			this.panelDetalle.Controls.Add(this.botonCopiarDetalle);
			this.panelDetalle.Controls.Add(this.txtDetalle);
			this.panelDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelDetalle.Location = new System.Drawing.Point(0, 109);
			this.panelDetalle.Name = "panelDetalle";
			this.panelDetalle.Size = new System.Drawing.Size(434, 200);
			this.panelDetalle.TabIndex = 1;
			// 
			// grpDetalle
			// 
			this.grpDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpDetalle.Location = new System.Drawing.Point(-8, -16);
			this.grpDetalle.Name = "grpDetalle";
			this.grpDetalle.Size = new System.Drawing.Size(450, 24);
			this.grpDetalle.TabIndex = 5;
			this.grpDetalle.TabStop = false;
			// 
			// botonCopiarDetalle
			// 
			this.botonCopiarDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonCopiarDetalle.BackColor = System.Drawing.SystemColors.Control;
			this.botonCopiarDetalle.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonCopiarDetalle.Location = new System.Drawing.Point(338, 168);
			this.botonCopiarDetalle.Name = "botonCopiarDetalle";
			this.botonCopiarDetalle.Size = new System.Drawing.Size(88, 24);
			this.botonCopiarDetalle.TabIndex = 4;
			this.botonCopiarDetalle.Text = "Copiar Detalle";
			this.botonCopiarDetalle.Click += new System.EventHandler(this.botonCopiarDetalle_Click);
			// 
			// txtDetalle
			// 
			this.txtDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDetalle.Location = new System.Drawing.Point(8, 16);
			this.txtDetalle.Multiline = true;
			this.txtDetalle.Name = "txtDetalle";
			this.txtDetalle.ReadOnly = true;
			this.txtDetalle.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDetalle.Size = new System.Drawing.Size(418, 144);
			this.txtDetalle.TabIndex = 0;
			this.txtDetalle.Text = "Detalle del Mensaje";
			// 
			// panelMensaje
			// 
			this.panelMensaje.BackColor = System.Drawing.Color.Transparent;
			this.panelMensaje.Controls.Add(this.labelMensaje);
			this.panelMensaje.Controls.Add(this.imagenMensaje);
			this.panelMensaje.Controls.Add(this.botonDetalles);
			this.panelMensaje.Controls.Add(this.botonAceptar);
			this.panelMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMensaje.Location = new System.Drawing.Point(0, 0);
			this.panelMensaje.Name = "panelMensaje";
			this.panelMensaje.Size = new System.Drawing.Size(434, 109);
			this.panelMensaje.TabIndex = 0;
			// 
			// labelMensaje
			// 
			this.labelMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.labelMensaje.Appearance = appearance1;
			this.labelMensaje.BackColor = System.Drawing.Color.Transparent;
			this.labelMensaje.Location = new System.Drawing.Point(64, 16);
			this.labelMensaje.Name = "labelMensaje";
			this.labelMensaje.Size = new System.Drawing.Size(360, 48);
			this.labelMensaje.TabIndex = 1;
			this.labelMensaje.Text = "Texto del Mensaje";
			// 
			// imagenMensaje
			// 
			this.imagenMensaje.BorderShadowColor = System.Drawing.Color.Empty;
			this.imagenMensaje.Image = ((object)(resources.GetObject("imagenMensaje.Image")));
			this.imagenMensaje.Location = new System.Drawing.Point(16, 16);
			this.imagenMensaje.Name = "imagenMensaje";
			this.imagenMensaje.Size = new System.Drawing.Size(32, 32);
			this.imagenMensaje.TabIndex = 0;
			// 
			// botonDetalles
			// 
			this.botonDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonDetalles.BackColor = System.Drawing.SystemColors.Control;
			this.botonDetalles.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonDetalles.Location = new System.Drawing.Point(338, 77);
			this.botonDetalles.Name = "botonDetalles";
			this.botonDetalles.Size = new System.Drawing.Size(88, 24);
			this.botonDetalles.TabIndex = 3;
			this.botonDetalles.Text = "Detalles";
			this.botonDetalles.Click += new System.EventHandler(this.botonDetalles_Click);
			// 
			// botonAceptar
			// 
			this.botonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonAceptar.BackColor = System.Drawing.SystemColors.Control;
			this.botonAceptar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonAceptar.Location = new System.Drawing.Point(242, 77);
			this.botonAceptar.Name = "botonAceptar";
			this.botonAceptar.Size = new System.Drawing.Size(88, 24);
			this.botonAceptar.TabIndex = 2;
			this.botonAceptar.Text = "Aceptar";
			this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
			// 
			// FormMensaje
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(434, 309);
			this.Controls.Add(this.panelMensaje);
			this.Controls.Add(this.panelDetalle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(4800, 3200);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 100);
			this.Name = "FormMensaje";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TituloMensaje";
			this.Load += new System.EventHandler(this.FormMensaje_Load);
			this.panelDetalle.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtDetalle)).EndInit();
			this.panelMensaje.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Constructor(es) y Dispose
		protected FormMensaje():this(String.Empty,String.Empty) {}
		public FormMensaje(string mensaje):this(mensaje,String.Empty) {}
		public FormMensaje(string mensaje, string detalle)
		{
			InitializeComponent();

			this.mensaje = mensaje;
			this.detalle = detalle;
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

		#region Variables Privadas
		private	string	mensaje = String.Empty;
		private	string	detalle = String.Empty;
		private	bool	detalleVisible = false;

		int altoBarraTitulo = 32,
			franjaSobreMensaje = 16,
			altoMensaje = 0,
			franjaBotones = 40;
		#endregion

		#region Properties
		private bool DetalleVisible
		{
			get	{	return this.detalleVisible;	}
			set
			{
				this.detalleVisible = value;

				// Estetica del Boton de Detalle
				this.botonDetalles.Text = "Detalle  " + (( this.detalleVisible ) ? "<<" : ">>");
				this.botonDetalles.Enabled = (this.detalle.Length > 0);

				// Visibilidad del Panel
				this.panelDetalle.Visible = this.detalleVisible;

				// Altura del Formulario
				this.Height = this.altoBarraTitulo
							+ this.franjaSobreMensaje
							+ this.altoMensaje
							+ this.franjaBotones;
				if( this.detalleVisible )
				{
					this.Height += this.panelDetalle.Height;
				}

				this.labelMensaje.Height = this.altoMensaje;
			}
		}
		#endregion

		private void FormMensaje_Load(object sender, System.EventArgs e)
		{
			if( this.DesignMode )
			{	return;	}

			if( this.mensaje == null || this.mensaje.Trim().Length == 0 )
			{	return;	}

			this.Text = "Error";

			this.EstablecerAlturaMensaje(this.mensaje);

			this.labelMensaje.Text = this.mensaje;
			this.txtDetalle.Text = this.detalle;

			this.DetalleVisible = false;
		}

		private void botonAceptar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void botonDetalles_Click(object sender, System.EventArgs e)
		{
			this.DetalleVisible = !this.detalleVisible;
		}

		private void botonCopiarDetalle_Click(object sender, System.EventArgs e)
		{
			this.txtDetalle.Focus();
			this.txtDetalle.SelectAll();
			this.txtDetalle.Copy();
		}

		private void EstablecerAlturaMensaje(string mensaje)
		{
			if( mensaje == null || mensaje.Trim().Length == 0 )
			{	return;	}

			int cantidadNewLine = 0;
			int altoFuente = Convert.ToInt32(labelMensaje.Font.GetHeight());

			for( int i=0; i<mensaje.Trim().Length; i++ )
			{
				if( mensaje[i] == 13 )
				{
					cantidadNewLine++;
				}
			}

			this.altoMensaje = 48 + (altoFuente*cantidadNewLine);
		}
	}
}