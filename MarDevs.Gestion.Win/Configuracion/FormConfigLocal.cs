using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{
	public class FormConfigLocal : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		#region Variables del diseñador
		private Infragistics.Win.Misc.UltraButton BotonCancelar;
		private Infragistics.Win.Misc.UltraButton BotonAceptar;
		private System.Windows.Forms.GroupBox groupBox4;
		private Infragistics.Win.Misc.UltraLabel labelStringResultado;
		private Infragistics.Win.UltraWinEditors.UltraPictureBox imagenRDBMS;
		private Infragistics.Win.UltraWinEditors.UltraPictureBox imagenServidor;
		private Infragistics.Win.UltraWinEditors.UltraPictureBox imagenConfiguracion;
		private Infragistics.Win.Misc.UltraLabel labelTitulo;
		private System.Windows.Forms.GroupBox motorRdbmsGrupo;
		private System.Windows.Forms.GroupBox servidorGrupo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor servidorPuertoTextEditor;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor servidorNombreTextEditor;
		private Infragistics.Win.Misc.UltraLabel servidorPuertoLabel;
		private Infragistics.Win.Misc.UltraLabel servidorNombreLabel;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor baseDeDatosNombreTextEditor;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor instanciaNombreTextEditor;
		private Infragistics.Win.Misc.UltraLabel baseDeDatosNombreLabel;
		private Infragistics.Win.Misc.UltraLabel instanciaNombreLabel;
		private Infragistics.Win.Misc.UltraLabel ayudaInicialLabel;
		private Infragistics.Win.Misc.UltraButton botonProbarConexion;
		#endregion
		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfigLocal));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelStringResultado = new Infragistics.Win.Misc.UltraLabel();
            this.botonProbarConexion = new Infragistics.Win.Misc.UltraButton();
            this.motorRdbmsGrupo = new System.Windows.Forms.GroupBox();
            this.imagenRDBMS = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.baseDeDatosNombreTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.instanciaNombreTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.baseDeDatosNombreLabel = new Infragistics.Win.Misc.UltraLabel();
            this.instanciaNombreLabel = new Infragistics.Win.Misc.UltraLabel();
            this.servidorGrupo = new System.Windows.Forms.GroupBox();
            this.imagenServidor = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.servidorPuertoTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.servidorNombreTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.servidorPuertoLabel = new Infragistics.Win.Misc.UltraLabel();
            this.servidorNombreLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BotonCancelar = new Infragistics.Win.Misc.UltraButton();
            this.BotonAceptar = new Infragistics.Win.Misc.UltraButton();
            this.imagenConfiguracion = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.labelTitulo = new Infragistics.Win.Misc.UltraLabel();
            this.ayudaInicialLabel = new Infragistics.Win.Misc.UltraLabel();
            this.groupBox4.SuspendLayout();
            this.motorRdbmsGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDeDatosNombreTextEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instanciaNombreTextEditor)).BeginInit();
            this.servidorGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servidorPuertoTextEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servidorNombreTextEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.labelStringResultado);
            this.groupBox4.Location = new System.Drawing.Point(8, 328);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(376, 80);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "String de Conexión";
            // 
            // labelStringResultado
            // 
            appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.labelStringResultado.Appearance = appearance1;
            this.labelStringResultado.Location = new System.Drawing.Point(16, 16);
            this.labelStringResultado.Name = "labelStringResultado";
            this.labelStringResultado.Size = new System.Drawing.Size(352, 56);
            this.labelStringResultado.TabIndex = 0;
            // 
            // botonProbarConexion
            // 
            this.botonProbarConexion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botonProbarConexion.Enabled = false;
			this.botonProbarConexion.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.botonProbarConexion.Location = new System.Drawing.Point(8, 416);
            this.botonProbarConexion.Name = "botonProbarConexion";
            this.botonProbarConexion.Size = new System.Drawing.Size(120, 24);
            this.botonProbarConexion.TabIndex = 6;
            this.botonProbarConexion.Text = "Probar Conexión...";
            this.botonProbarConexion.Click += new System.EventHandler(this.botonProbarConexion_Click);
            // 
            // motorRdbmsGrupo
            // 
            this.motorRdbmsGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.motorRdbmsGrupo.BackColor = System.Drawing.Color.Transparent;
            this.motorRdbmsGrupo.Controls.Add(this.imagenRDBMS);
            this.motorRdbmsGrupo.Controls.Add(this.baseDeDatosNombreTextEditor);
            this.motorRdbmsGrupo.Controls.Add(this.instanciaNombreTextEditor);
            this.motorRdbmsGrupo.Controls.Add(this.baseDeDatosNombreLabel);
            this.motorRdbmsGrupo.Controls.Add(this.instanciaNombreLabel);
            this.motorRdbmsGrupo.Location = new System.Drawing.Point(8, 240);
            this.motorRdbmsGrupo.Name = "motorRdbmsGrupo";
            this.motorRdbmsGrupo.Size = new System.Drawing.Size(376, 80);
            this.motorRdbmsGrupo.TabIndex = 4;
            this.motorRdbmsGrupo.TabStop = false;
            this.motorRdbmsGrupo.Text = "Datos del Motor de Base de Datos";
            // 
            // imagenRDBMS
            // 
            this.imagenRDBMS.BorderShadowColor = System.Drawing.Color.Empty;
            this.imagenRDBMS.Image = ((object)(resources.GetObject("imagenRDBMS.Image")));
            this.imagenRDBMS.Location = new System.Drawing.Point(16, 24);
            this.imagenRDBMS.Name = "imagenRDBMS";
            this.imagenRDBMS.Size = new System.Drawing.Size(40, 40);
            this.imagenRDBMS.TabIndex = 0;
            // 
            // baseDeDatosNombreTextEditor
            // 
            this.baseDeDatosNombreTextEditor.Location = new System.Drawing.Point(224, 40);
            this.baseDeDatosNombreTextEditor.Name = "baseDeDatosNombreTextEditor";
            this.baseDeDatosNombreTextEditor.Size = new System.Drawing.Size(144, 21);
            this.baseDeDatosNombreTextEditor.TabIndex = 4;
            this.baseDeDatosNombreTextEditor.ValueChanged += new System.EventHandler(this.txtBaseDeDatosNombre_ValueChanged);
            // 
            // instanciaNombreTextEditor
            // 
            this.instanciaNombreTextEditor.Location = new System.Drawing.Point(72, 40);
            this.instanciaNombreTextEditor.Name = "instanciaNombreTextEditor";
            this.instanciaNombreTextEditor.Size = new System.Drawing.Size(144, 21);
            this.instanciaNombreTextEditor.TabIndex = 2;
            this.instanciaNombreTextEditor.ValueChanged += new System.EventHandler(this.txtInstanciaNombre_ValueChanged);
            // 
            // baseDeDatosNombreLabel
            // 
            appearance2.FontData.BoldAsString = "True";
            appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.baseDeDatosNombreLabel.Appearance = appearance2;
            this.baseDeDatosNombreLabel.BackColor = System.Drawing.Color.Transparent;
            this.baseDeDatosNombreLabel.Location = new System.Drawing.Point(224, 24);
            this.baseDeDatosNombreLabel.Name = "baseDeDatosNombreLabel";
            this.baseDeDatosNombreLabel.Size = new System.Drawing.Size(144, 16);
            this.baseDeDatosNombreLabel.TabIndex = 3;
            this.baseDeDatosNombreLabel.Text = "Nombre Base de Datos";
            // 
            // instanciaNombreLabel
            // 
            appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.instanciaNombreLabel.Appearance = appearance3;
            this.instanciaNombreLabel.BackColor = System.Drawing.Color.Transparent;
            this.instanciaNombreLabel.Location = new System.Drawing.Point(72, 24);
            this.instanciaNombreLabel.Name = "instanciaNombreLabel";
            this.instanciaNombreLabel.Size = new System.Drawing.Size(144, 16);
            this.instanciaNombreLabel.TabIndex = 1;
            this.instanciaNombreLabel.Text = "Nombre Instancia";
            // 
            // servidorGrupo
            // 
            this.servidorGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.servidorGrupo.BackColor = System.Drawing.Color.Transparent;
            this.servidorGrupo.Controls.Add(this.imagenServidor);
            this.servidorGrupo.Controls.Add(this.servidorPuertoTextEditor);
            this.servidorGrupo.Controls.Add(this.servidorNombreTextEditor);
            this.servidorGrupo.Controls.Add(this.servidorPuertoLabel);
            this.servidorGrupo.Controls.Add(this.servidorNombreLabel);
            this.servidorGrupo.Location = new System.Drawing.Point(8, 152);
            this.servidorGrupo.Name = "servidorGrupo";
            this.servidorGrupo.Size = new System.Drawing.Size(376, 80);
            this.servidorGrupo.TabIndex = 3;
            this.servidorGrupo.TabStop = false;
            this.servidorGrupo.Text = "Datos del Servidor";
            // 
            // imagenServidor
            // 
            this.imagenServidor.BorderShadowColor = System.Drawing.Color.Empty;
            this.imagenServidor.Image = ((object)(resources.GetObject("imagenServidor.Image")));
            this.imagenServidor.Location = new System.Drawing.Point(16, 24);
            this.imagenServidor.Name = "imagenServidor";
            this.imagenServidor.Size = new System.Drawing.Size(40, 40);
            this.imagenServidor.TabIndex = 0;
            // 
            // servidorPuertoTextEditor
            // 
            this.servidorPuertoTextEditor.Location = new System.Drawing.Point(304, 40);
            this.servidorPuertoTextEditor.Name = "servidorPuertoTextEditor";
            this.servidorPuertoTextEditor.Size = new System.Drawing.Size(64, 21);
            this.servidorPuertoTextEditor.TabIndex = 4;
            this.servidorPuertoTextEditor.ValueChanged += new System.EventHandler(this.txtHostPuertoTcp_ValueChanged);
            // 
            // servidorNombreTextEditor
            // 
            this.servidorNombreTextEditor.Location = new System.Drawing.Point(72, 40);
            this.servidorNombreTextEditor.Name = "servidorNombreTextEditor";
            this.servidorNombreTextEditor.Size = new System.Drawing.Size(224, 21);
            this.servidorNombreTextEditor.TabIndex = 2;
            this.servidorNombreTextEditor.ValueChanged += new System.EventHandler(this.txtHostNombre_ValueChanged);
            // 
            // servidorPuertoLabel
            // 
            appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.servidorPuertoLabel.Appearance = appearance4;
            this.servidorPuertoLabel.BackColor = System.Drawing.Color.Transparent;
            this.servidorPuertoLabel.Location = new System.Drawing.Point(304, 24);
            this.servidorPuertoLabel.Name = "servidorPuertoLabel";
            this.servidorPuertoLabel.Size = new System.Drawing.Size(64, 16);
            this.servidorPuertoLabel.TabIndex = 3;
            this.servidorPuertoLabel.Text = "Puerto TCP";
            // 
            // servidorNombreLabel
            // 
            appearance5.FontData.BoldAsString = "True";
            appearance5.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.servidorNombreLabel.Appearance = appearance5;
            this.servidorNombreLabel.BackColor = System.Drawing.Color.Transparent;
            this.servidorNombreLabel.Location = new System.Drawing.Point(72, 24);
            this.servidorNombreLabel.Name = "servidorNombreLabel";
            this.servidorNombreLabel.Size = new System.Drawing.Size(224, 16);
            this.servidorNombreLabel.TabIndex = 1;
            this.servidorNombreLabel.Text = "Servidor";
            // 
            // BotonCancelar
            // 
            this.BotonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BotonCancelar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BotonCancelar.Location = new System.Drawing.Point(304, 416);
            this.BotonCancelar.Name = "BotonCancelar";
            this.BotonCancelar.Size = new System.Drawing.Size(80, 24);
            this.BotonCancelar.TabIndex = 8;
            this.BotonCancelar.Text = "Cancelar";
            this.BotonCancelar.Click += new System.EventHandler(this.BotonCancelar_Click);
            // 
            // BotonAceptar
            // 
            this.BotonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonAceptar.Enabled = false;
			this.BotonAceptar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BotonAceptar.Location = new System.Drawing.Point(216, 416);
            this.BotonAceptar.Name = "BotonAceptar";
            this.BotonAceptar.Size = new System.Drawing.Size(80, 24);
            this.BotonAceptar.TabIndex = 7;
            this.BotonAceptar.Text = "Aceptar";
            this.BotonAceptar.Click += new System.EventHandler(this.BotonAceptar_Click);
            // 
            // imagenConfiguracion
            // 
            this.imagenConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imagenConfiguracion.BackColor = System.Drawing.Color.Transparent;
            this.imagenConfiguracion.BorderShadowColor = System.Drawing.Color.Empty;
            this.imagenConfiguracion.Image = ((object)(resources.GetObject("imagenConfiguracion.Image")));
            this.imagenConfiguracion.Location = new System.Drawing.Point(336, 8);
            this.imagenConfiguracion.Name = "imagenConfiguracion";
            this.imagenConfiguracion.Size = new System.Drawing.Size(48, 48);
            this.imagenConfiguracion.TabIndex = 1;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            appearance6.BackColor2 = System.Drawing.Color.Transparent;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.FontData.BoldAsString = "True";
            appearance6.FontData.SizeInPoints = 14F;
            appearance6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            appearance6.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.labelTitulo.Appearance = appearance6;
            this.labelTitulo.BackColor = System.Drawing.Color.Transparent;
            this.labelTitulo.Location = new System.Drawing.Point(8, 8);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Padding = new System.Drawing.Size(8, 0);
            this.labelTitulo.Size = new System.Drawing.Size(328, 48);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Conexión a la base de datos";
            // 
            // ayudaInicialLabel
            // 
            appearance7.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ayudaInicialLabel.Appearance = appearance7;
            this.ayudaInicialLabel.BackColor = System.Drawing.Color.Transparent;
            this.ayudaInicialLabel.Location = new System.Drawing.Point(8, 64);
            this.ayudaInicialLabel.Name = "ayudaInicialLabel";
            this.ayudaInicialLabel.Size = new System.Drawing.Size(376, 80);
            this.ayudaInicialLabel.TabIndex = 2;
            this.ayudaInicialLabel.Text = "[ayudaInicialLabel.Text]";
            // 
            // FormConfigLocal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(394, 448);
            this.Controls.Add(this.ayudaInicialLabel);
            this.Controls.Add(this.imagenConfiguracion);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.BotonCancelar);
            this.Controls.Add(this.BotonAceptar);
            this.Controls.Add(this.servidorGrupo);
            this.Controls.Add(this.motorRdbmsGrupo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.botonProbarConexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfigLocal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.FormConfigLocal_Load);
            this.groupBox4.ResumeLayout(false);
            this.motorRdbmsGrupo.ResumeLayout(false);
            this.motorRdbmsGrupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDeDatosNombreTextEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instanciaNombreTextEditor)).EndInit();
            this.servidorGrupo.ResumeLayout(false);
            this.servidorGrupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servidorPuertoTextEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servidorNombreTextEditor)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Constructor(es) y Dispose
		
        public FormConfigLocal(Config config)
		{
			InitializeComponent();
            _config = config;

			this.Closing+=new CancelEventHandler(FormConfigLocal_Closing);
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

		private bool DatosValidos
		{
			get
			{
				if (this.servidorNombreTextEditor.Text.Trim().Length == 0 | 
					this.baseDeDatosNombreTextEditor.Text.Trim().Length == 0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		private string _CadenaConexion = String.Empty;
		private string _CadenaConexionMascara = String.Empty;
		private DialogResult resultado = DialogResult.Cancel;
        private Config _config = null;

		private void FormConfigLocal_Load(object sender, System.EventArgs e)
		{
			this.ayudaInicialLabel.Text = "En caso de no conocer los valores que debe ingresar "
										+ "en este formulario, comuníquese con el administrador "
										+ "para obtener asistencia." + Environment.NewLine
										+ Environment.NewLine
										+ "(Nota: Los campos en Negrita son obligatorios)";

            this.servidorNombreTextEditor.DataBindings.Add("Text", _config, "Server");
            this.servidorPuertoTextEditor.DataBindings.Add("Text", _config, "Puerto");
            this.instanciaNombreTextEditor.DataBindings.Add("Text", _config, "Instancia");
            this.baseDeDatosNombreTextEditor.DataBindings.Add("Text", _config, "BaseDatos");

			this.ArmarConexionString();
			this.labelStringResultado.Text = this._CadenaConexionMascara;
		}
		private void FormConfigLocal_Closing(object sender, CancelEventArgs e)
		{
			this.DialogResult = this.resultado;
		}
		private void txtHostNombre_ValueChanged(object sender, System.EventArgs e)
		{
			this.ArmarConexionString();
			this.labelStringResultado.Text = this._CadenaConexionMascara;
		}
		private void txtHostPuertoTcp_ValueChanged(object sender, System.EventArgs e)
		{
			this.ArmarConexionString();
			this.labelStringResultado.Text = this._CadenaConexionMascara;
		}
		private void txtInstanciaNombre_ValueChanged(object sender, System.EventArgs e)
		{
			this.ArmarConexionString();
			this.labelStringResultado.Text = this._CadenaConexionMascara;
		}
		private void txtBaseDeDatosNombre_ValueChanged(object sender, System.EventArgs e)
		{
			this.ArmarConexionString();
			this.labelStringResultado.Text = this._CadenaConexionMascara;
		}

        private void botonProbarConexion_Click(object sender, System.EventArgs e)
		{
			//probar la conexión
			if ( this.ProbarConexion() == false)
			{
				Mensaje.Advertencia(ConfigBL.STR_ERROR_CONEXION + Environment.NewLine + Environment.NewLine
					+ "Por favor, verifíque los datos ingresados e intente nuevamente.");
			}
			else
			{
				Mensaje.Informacion("La prueba de conexión ha sido satisfactoria");
			}
		
		}
        private void BotonAceptar_Click(object sender, System.EventArgs e)
		{
			//validar datos ingresados
			if (this.DatosValidos == false)
			{
				MessageBox.Show("Los datos de Nombre del Servidor y Base de datos son obligatorios. "
					+ "Falta uno o más de ellos. Por favor ingréselos.");
				return;
			}
			//probar la conexión
			if ( this.ProbarConexion() == false)
			{
				MessageBox.Show("No se pudo establecer la conexión a la Base de Datos "
					+ "con los datos ingresados. "
					+ "Por favor, verifíquelos e intente nuevamente.");
				return;
			}
            ConfigBL.GuardarConfiguracion(_config);
			ConfigBL.ResetearConexion();

			this.resultado = DialogResult.OK;
			this.Close();
		}
		private void BotonCancelar_Click(object sender, System.EventArgs e)
		{
			this.resultado = DialogResult.Cancel;
			this.Close();
		}

		private void ArmarConexionString()
		{
			string servidor = this.servidorNombreTextEditor.Text;
			string puerto = this.servidorPuertoTextEditor.Text;
			string instancia = this.instanciaNombreTextEditor.Text;
			string baseDeDatos = this.baseDeDatosNombreTextEditor.Text;
			
			this.botonProbarConexion.Enabled = this.DatosValidos;
			this.BotonAceptar.Enabled = this.DatosValidos;

			this._CadenaConexion = ConfigBL.ArmarStringDeConexion(servidor,puerto,instancia,baseDeDatos);
			this._CadenaConexionMascara = ConfigBL.ArmarStringDeConexion(servidor,puerto,instancia,baseDeDatos,true);
		}
		private bool ProbarConexion()
		{

			SqlConnection miCon = new SqlConnection(_CadenaConexion);

			try
			{
				miCon.Open();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
			finally
			{
				if (miCon.State == ConnectionState.Open) {miCon.Close();}
			}

		}

	}
}
