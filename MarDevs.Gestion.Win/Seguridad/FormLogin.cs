using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{
	/// <summary>
	/// Descripción breve de Form1.
	/// </summary>
	public class FormLogin : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		#region Variables del Diseñador
		internal Infragistics.Win.UltraWinEditors.UltraPictureBox UltraPictureBox1;
		internal Infragistics.Win.Misc.UltraLabel labelUsuario;
		internal Infragistics.Win.UltraWinEditors.UltraTextEditor TxtUsuarioLogon;
		internal Infragistics.Win.Misc.UltraLabel labelPassword;
		internal Infragistics.Win.UltraWinEditors.UltraTextEditor TxtUsuarioPass;
		private Infragistics.Win.Misc.UltraButton BotonLogin;
		internal Infragistics.Win.Misc.UltraLabel LabelResultado;
		private Infragistics.Win.Misc.UltraButton botonConexion;
		internal Infragistics.Win.Misc.UltraLabel labelBaseDeDatos;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor comboBaseDeDatos;
		private Infragistics.Win.Misc.UltraButton BotonCerrar;
		#endregion
		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			this.UltraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
			this.TxtUsuarioPass = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.TxtUsuarioLogon = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.BotonLogin = new Infragistics.Win.Misc.UltraButton();
			this.BotonCerrar = new Infragistics.Win.Misc.UltraButton();
			this.labelPassword = new Infragistics.Win.Misc.UltraLabel();
			this.labelUsuario = new Infragistics.Win.Misc.UltraLabel();
			this.LabelResultado = new Infragistics.Win.Misc.UltraLabel();
			this.botonConexion = new Infragistics.Win.Misc.UltraButton();
			this.labelBaseDeDatos = new Infragistics.Win.Misc.UltraLabel();
			this.comboBaseDeDatos = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			((System.ComponentModel.ISupportInitialize)(this.TxtUsuarioPass)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TxtUsuarioLogon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBaseDeDatos)).BeginInit();
			this.SuspendLayout();
			// 
			// UltraPictureBox1
			// 
			this.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
			this.UltraPictureBox1.Image = ((object)(resources.GetObject("UltraPictureBox1.Image")));
			this.UltraPictureBox1.Location = new System.Drawing.Point(16, 16);
			this.UltraPictureBox1.Name = "UltraPictureBox1";
			this.UltraPictureBox1.Size = new System.Drawing.Size(48, 48);
			this.UltraPictureBox1.TabIndex = 0;
			// 
			// TxtUsuarioPass
			// 
			this.TxtUsuarioPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtUsuarioPass.Location = new System.Drawing.Point(176, 112);
			this.TxtUsuarioPass.Name = "TxtUsuarioPass";
			this.TxtUsuarioPass.PasswordChar = '*';
			this.TxtUsuarioPass.Size = new System.Drawing.Size(168, 21);
			this.TxtUsuarioPass.TabIndex = 5;
			// 
			// TxtUsuarioLogon
			// 
			this.TxtUsuarioLogon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtUsuarioLogon.Location = new System.Drawing.Point(176, 80);
			this.TxtUsuarioLogon.Name = "TxtUsuarioLogon";
			this.TxtUsuarioLogon.Size = new System.Drawing.Size(168, 21);
			this.TxtUsuarioLogon.TabIndex = 3;
			// 
			// BotonLogin
			// 
			this.BotonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BotonLogin.Location = new System.Drawing.Point(178, 176);
			this.BotonLogin.Name = "BotonLogin";
			this.BotonLogin.Size = new System.Drawing.Size(80, 24);
			this.BotonLogin.TabIndex = 9;
			this.BotonLogin.Text = "Ingresar";
			this.BotonLogin.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.BotonLogin.Click += new System.EventHandler(this.BotonLogin_Click);
			// 
			// BotonCerrar
			// 
			this.BotonCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BotonCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BotonCerrar.Location = new System.Drawing.Point(266, 176);
			this.BotonCerrar.Name = "BotonCerrar";
			this.BotonCerrar.Size = new System.Drawing.Size(80, 24);
			this.BotonCerrar.TabIndex = 10;
			this.BotonCerrar.Text = "Cerrar";
			this.BotonCerrar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.BotonCerrar.Click += new System.EventHandler(this.BotonCerrar_Click);
			// 
			// labelPassword
			// 
			this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance1.TextVAlignAsString = "Middle";
			this.labelPassword.Appearance = appearance1;
			this.labelPassword.BackColorInternal = System.Drawing.Color.Transparent;
			this.labelPassword.Location = new System.Drawing.Point(8, 112);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(168, 23);
			this.labelPassword.TabIndex = 4;
			this.labelPassword.Text = "Contraseña:";
			// 
			// labelUsuario
			// 
			this.labelUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance2.TextVAlignAsString = "Middle";
			this.labelUsuario.Appearance = appearance2;
			this.labelUsuario.BackColorInternal = System.Drawing.Color.Transparent;
			this.labelUsuario.Location = new System.Drawing.Point(8, 80);
			this.labelUsuario.Name = "labelUsuario";
			this.labelUsuario.Size = new System.Drawing.Size(168, 23);
			this.labelUsuario.TabIndex = 2;
			this.labelUsuario.Text = "Usuario:";
			// 
			// LabelResultado
			// 
			this.LabelResultado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance3.TextVAlignAsString = "Middle";
			this.LabelResultado.Appearance = appearance3;
			this.LabelResultado.BackColorInternal = System.Drawing.Color.Transparent;
			this.LabelResultado.Location = new System.Drawing.Point(88, 16);
			this.LabelResultado.Name = "LabelResultado";
			this.LabelResultado.Size = new System.Drawing.Size(256, 48);
			this.LabelResultado.TabIndex = 1;
			this.LabelResultado.Text = "LabelResultado.Text";
			// 
			// botonConexion
			// 
			this.botonConexion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.botonConexion.Location = new System.Drawing.Point(8, 176);
			this.botonConexion.Name = "botonConexion";
			this.botonConexion.Size = new System.Drawing.Size(120, 24);
			this.botonConexion.TabIndex = 8;
			this.botonConexion.Text = "Conexión...";
			this.botonConexion.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonConexion.Click += new System.EventHandler(this.botonConexion_Click);
			// 
			// labelBaseDeDatos
			// 
			this.labelBaseDeDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance4.TextVAlignAsString = "Middle";
			this.labelBaseDeDatos.Appearance = appearance4;
			this.labelBaseDeDatos.BackColorInternal = System.Drawing.Color.Transparent;
			this.labelBaseDeDatos.Location = new System.Drawing.Point(8, 144);
			this.labelBaseDeDatos.Name = "labelBaseDeDatos";
			this.labelBaseDeDatos.Size = new System.Drawing.Size(168, 23);
			this.labelBaseDeDatos.TabIndex = 6;
			this.labelBaseDeDatos.Text = "Base de Datos:";
			this.labelBaseDeDatos.Visible = false;
			// 
			// comboBaseDeDatos
			// 
			this.comboBaseDeDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBaseDeDatos.Location = new System.Drawing.Point(176, 144);
			this.comboBaseDeDatos.Name = "comboBaseDeDatos";
			this.comboBaseDeDatos.Size = new System.Drawing.Size(168, 21);
			this.comboBaseDeDatos.TabIndex = 7;
			this.comboBaseDeDatos.Visible = false;
			// 
			// FormLogin
			// 
			this.AcceptButton = this.BotonLogin;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.BotonCerrar;
			this.ClientSize = new System.Drawing.Size(354, 208);
			this.Controls.Add(this.comboBaseDeDatos);
			this.Controls.Add(this.labelBaseDeDatos);
			this.Controls.Add(this.botonConexion);
			this.Controls.Add(this.BotonCerrar);
			this.Controls.Add(this.BotonLogin);
			this.Controls.Add(this.UltraPictureBox1);
			this.Controls.Add(this.TxtUsuarioPass);
			this.Controls.Add(this.TxtUsuarioLogon);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labelUsuario);
			this.Controls.Add(this.LabelResultado);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormLogin";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login al Sistema";
			this.Load += new System.EventHandler(this.FormLogin_Load);
			((System.ComponentModel.ISupportInitialize)(this.TxtUsuarioPass)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TxtUsuarioLogon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBaseDeDatos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		#region Constructor(es) y Dispose
		public FormLogin()
		{
			InitializeComponent();
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
		private Ticket ticket = null;
		private string _TituloFormulario;
		private string _TextoEstadoInicial = "Ingrese usuario y contraseña...";
		private string _TextoNoSePudoAutenticar = "No se pudo realizar la Autenticación." + Environment.NewLine;
		#endregion

		#region Propiedades
		public string TituloFormulario
		{
			get
			{
				return _TituloFormulario;
			}
			set
			{
				_TituloFormulario = value;
				this.Text = _TituloFormulario;
			}
		}

		#endregion

		public Ticket RealizarAutenticacion()
		{
			this.ShowDialog();
			return this.ticket;
		}
		public Ticket RealizarAutenticacion(string ultimoUsuarioLogueado)
		{
			if (!String.IsNullOrEmpty(ultimoUsuarioLogueado))
			{
				this.TxtUsuarioLogon.Text = ultimoUsuarioLogueado;
				this.TxtUsuarioLogon.TabIndex = 11;
			}
			return RealizarAutenticacion();
		}

		private void FormLogin_Load(object sender, System.EventArgs e)
		{
			this.LabelResultado.Text = this._TextoEstadoInicial;
		}
		private void BotonLogin_Click(object sender, System.EventArgs e)
		{
			Ticket ticket = null;
			this.LabelResultado.Text = "Realizando autenticación...";
			this.Refresh();

			string logon	= this.TxtUsuarioLogon.Text.Trim();
			string password	= this.TxtUsuarioPass.Text.Trim();
			try
			{
				ticket = Usuario.Autenticar(logon, password);

				this.ticket = ticket;
				
				this.LabelResultado.Text = "Autenticación Correcta.";
				this.Refresh();

				this.Close();
			}
			catch( ExcepcionAutenticacion exNEL )
			{
				this.LabelResultado.Text = this._TextoNoSePudoAutenticar + exNEL.Message;
				this.TxtUsuarioLogon.Focus();
				this.Refresh();
			}
			catch (ExcepcionAutenticacionPswdVencido exAPV)
			{
				try
				{
					this.LabelResultado.Text = this._TextoNoSePudoAutenticar + exAPV.Message;
					this.Refresh();

					Usuario usuario = Usuario.Leer(logon);
					if (usuario != null)
					{
						FormCambioDePassword fCambioPass = new FormCambioDePassword(usuario, "La contraseña actual ha vencido." + Environment.NewLine + "Debe cambiarla ahora.");
						fCambioPass.ShowDialog();
					}
				}
				catch( Exception ex )
				{
					Mensaje.Error(ex.Message, ex);
				}
				finally
				{
					this.LabelResultado.Text = this._TextoEstadoInicial;
					this.TxtUsuarioPass.Text = String.Empty;
					this.TxtUsuarioPass.Focus();
				}
			}
			catch( Exception ex )
			{
				this.LabelResultado.Text = this._TextoNoSePudoAutenticar
					+ "Posiblemente la base de datos no esté accesible.";

				Mensaje.Error(ex.Message, ex);
			}
		}
		private void BotonCerrar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void botonConexion_Click(object sender, System.EventArgs e)
		{
			// Invoco a la pantalla de Configuracion de Conexión
            object config = null;
            try
            {
                config = ConfigBL.ObtenerConfiguracion();
            }
            catch (System.IO.FileNotFoundException)
            {
				string claseConfig = System.Configuration.ConfigurationManager.AppSettings.Get("config");
				config = Activator.CreateInstance(Type.GetType(claseConfig));
			}
			FormConfigLocal form = new FormConfigLocal(config as Config);
			form.ShowDialog();
		}

	}
}
