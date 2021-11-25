using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using MarDevs.OC.Core;

namespace MarDevs.OC.Win
{
	/// <summary>
	/// Descripción breve de FormCambioDePassword.
	/// </summary>
	public class FormCambioDePassword : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		#region Variables del diseñador
		internal Infragistics.Win.Misc.UltraButton BotonCancelar;
		internal Infragistics.Win.Misc.UltraButton BotonAceptar;
		internal Infragistics.Win.Misc.UltraLabel UltraLabel3;
		internal Infragistics.Win.Misc.UltraLabel UltraLabel2;
		internal Infragistics.Win.Misc.UltraLabel UltraLabel1;
		internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtPasswordActual;
		internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtPasswordNuevo;
		internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtPasswordNuevo2;
		internal Infragistics.Win.Misc.UltraLabel labelTextoAdicional;
		private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;
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
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormCambioDePassword));
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			this.BotonCancelar = new Infragistics.Win.Misc.UltraButton();
			this.BotonAceptar = new Infragistics.Win.Misc.UltraButton();
			this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPasswordNuevo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPasswordNuevo2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPasswordActual = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
			this.labelTextoAdicional = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordNuevo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordNuevo2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordActual)).BeginInit();
			this.SuspendLayout();
			// 
			// BotonCancelar
			// 
			this.BotonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BotonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BotonCancelar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.BotonCancelar.Location = new System.Drawing.Point(266, 176);
			this.BotonCancelar.Name = "BotonCancelar";
			this.BotonCancelar.Size = new System.Drawing.Size(80, 24);
			this.BotonCancelar.TabIndex = 9;
			this.BotonCancelar.Text = "Cancelar";
			// 
			// BotonAceptar
			// 
			this.BotonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BotonAceptar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.BotonAceptar.Location = new System.Drawing.Point(176, 176);
			this.BotonAceptar.Name = "BotonAceptar";
			this.BotonAceptar.Size = new System.Drawing.Size(82, 24);
			this.BotonAceptar.TabIndex = 8;
			this.BotonAceptar.Text = "Aceptar";
			this.BotonAceptar.Click += new System.EventHandler(this.BotonAceptar_Click);
			// 
			// UltraLabel3
			// 
			this.UltraLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.UltraLabel3.Appearance = appearance1;
			this.UltraLabel3.BackColor = System.Drawing.Color.Transparent;
			this.UltraLabel3.Location = new System.Drawing.Point(8, 112);
			this.UltraLabel3.Name = "UltraLabel3";
			this.UltraLabel3.Size = new System.Drawing.Size(168, 23);
			this.UltraLabel3.TabIndex = 4;
			this.UltraLabel3.Text = "Contraseña nueva:";
			// 
			// txtPasswordNuevo
			// 
			this.txtPasswordNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPasswordNuevo.Location = new System.Drawing.Point(176, 112);
			this.txtPasswordNuevo.Name = "txtPasswordNuevo";
			this.txtPasswordNuevo.PasswordChar = '*';
			this.txtPasswordNuevo.Size = new System.Drawing.Size(168, 21);
			this.txtPasswordNuevo.TabIndex = 5;
			// 
			// UltraLabel2
			// 
			this.UltraLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.UltraLabel2.Appearance = appearance2;
			this.UltraLabel2.BackColor = System.Drawing.Color.Transparent;
			this.UltraLabel2.Location = new System.Drawing.Point(8, 144);
			this.UltraLabel2.Name = "UltraLabel2";
			this.UltraLabel2.Size = new System.Drawing.Size(168, 23);
			this.UltraLabel2.TabIndex = 6;
			this.UltraLabel2.Text = "Confirmar contraseña nueva:";
			// 
			// txtPasswordNuevo2
			// 
			this.txtPasswordNuevo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPasswordNuevo2.Location = new System.Drawing.Point(176, 144);
			this.txtPasswordNuevo2.Name = "txtPasswordNuevo2";
			this.txtPasswordNuevo2.PasswordChar = '*';
			this.txtPasswordNuevo2.Size = new System.Drawing.Size(168, 21);
			this.txtPasswordNuevo2.TabIndex = 7;
			// 
			// UltraLabel1
			// 
			this.UltraLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.UltraLabel1.Appearance = appearance3;
			this.UltraLabel1.BackColor = System.Drawing.Color.Transparent;
			this.UltraLabel1.Location = new System.Drawing.Point(8, 80);
			this.UltraLabel1.Name = "UltraLabel1";
			this.UltraLabel1.Size = new System.Drawing.Size(168, 23);
			this.UltraLabel1.TabIndex = 2;
			this.UltraLabel1.Text = "Contraseña actual:";
			// 
			// txtPasswordActual
			// 
			this.txtPasswordActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPasswordActual.Location = new System.Drawing.Point(176, 80);
			this.txtPasswordActual.Name = "txtPasswordActual";
			this.txtPasswordActual.PasswordChar = '*';
			this.txtPasswordActual.Size = new System.Drawing.Size(168, 21);
			this.txtPasswordActual.TabIndex = 3;
			// 
			// ultraPictureBox1
			// 
			this.ultraPictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
			this.ultraPictureBox1.Image = ((object)(resources.GetObject("ultraPictureBox1.Image")));
			this.ultraPictureBox1.Location = new System.Drawing.Point(16, 16);
			this.ultraPictureBox1.Name = "ultraPictureBox1";
			this.ultraPictureBox1.Size = new System.Drawing.Size(48, 48);
			this.ultraPictureBox1.TabIndex = 0;
			// 
			// labelTextoAdicional
			// 
			this.labelTextoAdicional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			appearance4.FontData.BoldAsString = "True";
			appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.labelTextoAdicional.Appearance = appearance4;
			this.labelTextoAdicional.BackColor = System.Drawing.Color.Transparent;
			this.labelTextoAdicional.Location = new System.Drawing.Point(88, 16);
			this.labelTextoAdicional.Name = "labelTextoAdicional";
			this.labelTextoAdicional.Size = new System.Drawing.Size(258, 48);
			this.labelTextoAdicional.TabIndex = 1;
			this.labelTextoAdicional.Text = "[labelTextoAdicional.Text]";
			// 
			// FormCambioDePassword
			// 
			this.AcceptButton = this.BotonAceptar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.BotonCancelar;
			this.ClientSize = new System.Drawing.Size(354, 208);
			this.ControlBox = false;
			this.Controls.Add(this.labelTextoAdicional);
			this.Controls.Add(this.ultraPictureBox1);
			this.Controls.Add(this.BotonCancelar);
			this.Controls.Add(this.BotonAceptar);
			this.Controls.Add(this.UltraLabel3);
			this.Controls.Add(this.txtPasswordNuevo);
			this.Controls.Add(this.UltraLabel2);
			this.Controls.Add(this.txtPasswordNuevo2);
			this.Controls.Add(this.UltraLabel1);
			this.Controls.Add(this.txtPasswordActual);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormCambioDePassword";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cambio de Contraseña";
			this.Load += new System.EventHandler(this.FormCambioDePassword_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordNuevo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordNuevo2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordActual)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Constructor(es) y Dispose
		public FormCambioDePassword()
		{
			if (ConfigBL.ticket != null)
			{
				this.usuario = ConfigBL.ticket.Usuario;
				this.textoAdicional = String.Empty;
			}
			InitializeComponent();
		}
		public FormCambioDePassword(Usuario usuario):this(usuario, String.Empty)	{}
		public FormCambioDePassword(Usuario usuario, string textoAdicional)
		{
			InitializeComponent();

			this.usuario = usuario;
			this.textoAdicional = textoAdicional;
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
		private Usuario usuario;
		private string textoAdicional;
		private string textoNoSePuedeCambiar = "No se puede cambiar la Contraseña." + Environment.NewLine;
		#endregion

		private void FormCambioDePassword_Load(object sender, System.EventArgs e)
		{
			if (usuario == null)
			{
				Mensaje.Advertencia("No se ha establecido el usuario al que cambiar la contraseña.");
				this.Close();
			}
			this.labelTextoAdicional.Text = this.textoAdicional;		
		}

		private void BotonAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				string passwordActual = this.txtPasswordActual.Text.Trim();
				string passwordNuevo1 = this.txtPasswordNuevo.Text.Trim();
				string passwordNuevo2 = this.txtPasswordNuevo2.Text.Trim();

				if (!passwordNuevo1.Equals(passwordNuevo2))
				{
					throw new Exception("La password nueva no coincide.");
				}
				Usuario.CambiarContraseña(usuario, passwordActual, passwordNuevo1);
				Mensaje.Informacion("La Contraseña se cambió exitosamente.");
				this.Close();
			}
			catch( ExcepcionTecnica exTecnica )
			{
				Mensaje.Error( this.textoNoSePuedeCambiar, exTecnica );
				this.txtPasswordActual.Focus();
			}
			catch( Exception ex)
			{
				Mensaje.Advertencia( this.textoNoSePuedeCambiar + ex.Message );
				this.txtPasswordActual.Focus();
			}
		}
	}
}
