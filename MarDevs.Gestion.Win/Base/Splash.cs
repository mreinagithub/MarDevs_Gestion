using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace MarDevs.Gestion.Win
{
	/// <summary>
	/// Descripción breve de FormSplash.
	/// </summary>
	public class Splash : System.Windows.Forms.Form
	{
		private Infragistics.Win.UltraWinTabControl.UltraTabStripControl ultraTabStripControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		internal Infragistics.Win.UltraWinEditors.UltraPictureBox UltraPictureBox1;
		internal Infragistics.Win.Misc.UltraLabel LabelStatus;
		internal System.Windows.Forms.Label labelNombreAplicacion;
		internal System.Windows.Forms.Label labelVersion;
		private System.ComponentModel.IContainer components;

		static Splash formSplash = null;
		static Thread ms_oThread = null;
		static string estadoCarga = String.Empty;
		static string nombreAplicacion = String.Empty;
		private System.Windows.Forms.Timer timer1;
		private static double incrementoOpacity = -1;
		private static bool cierreIniciado = false;
		static string version = String.Empty;

		protected Splash()
		{
			InitializeComponent();

			this.timer1.Interval = 50;
			this.timer1.Start();
			this.labelNombreAplicacion.Text = nombreAplicacion;
			this.LabelStatus.Text = estadoCarga;
			this.labelVersion.Text = version;
		}

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
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

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraTabStripControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabStripControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelNombreAplicacion = new System.Windows.Forms.Label();
            this.UltraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.LabelStatus = new Infragistics.Win.Misc.UltraLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabStripControl1)).BeginInit();
            this.ultraTabStripControl1.SuspendLayout();
            this.ultraTabSharedControlsPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabStripControl1
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.ultraTabStripControl1.Appearance = appearance1;
            this.ultraTabStripControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabStripControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabStripControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabStripControl1.Name = "ultraTabStripControl1";
            this.ultraTabStripControl1.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.labelVersion,
            this.labelNombreAplicacion,
            this.UltraPictureBox1,
            this.LabelStatus});
            this.ultraTabStripControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabStripControl1.Size = new System.Drawing.Size(398, 286);
            this.ultraTabStripControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.ultraTabStripControl1.TabIndex = 0;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Controls.Add(this.labelVersion);
            this.ultraTabSharedControlsPage1.Controls.Add(this.labelNombreAplicacion);
            this.ultraTabSharedControlsPage1.Controls.Add(this.LabelStatus);
            this.ultraTabSharedControlsPage1.Controls.Add(this.UltraPictureBox1);
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(398, 286);
            // 
            // labelVersion
            // 
            this.labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelVersion.Location = new System.Drawing.Point(48, 231);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(296, 16);
            this.labelVersion.TabIndex = 6;
            this.labelVersion.Text = "Versión";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNombreAplicacion
            // 
            this.labelNombreAplicacion.BackColor = System.Drawing.Color.Transparent;
            this.labelNombreAplicacion.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreAplicacion.Location = new System.Drawing.Point(48, 199);
            this.labelNombreAplicacion.Name = "labelNombreAplicacion";
            this.labelNombreAplicacion.Size = new System.Drawing.Size(296, 20);
            this.labelNombreAplicacion.TabIndex = 5;
            this.labelNombreAplicacion.Text = "NombreAplicacion";
            this.labelNombreAplicacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UltraPictureBox1
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.UltraPictureBox1.Appearance = appearance3;
            this.UltraPictureBox1.AutoSize = true;
            this.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.UltraPictureBox1.DrawBorderShadow = true;
            this.UltraPictureBox1.Image = ((object)(resources.GetObject("UltraPictureBox1.Image")));
            this.UltraPictureBox1.Location = new System.Drawing.Point(-49, -104);
            this.UltraPictureBox1.Name = "UltraPictureBox1";
            this.UltraPictureBox1.ScaleImage = Infragistics.Win.ScaleImage.Never;
            this.UltraPictureBox1.Size = new System.Drawing.Size(505, 505);
            this.UltraPictureBox1.TabIndex = 3;
            // 
            // LabelStatus
            // 
            appearance2.TextHAlignAsString = "Center";
            this.LabelStatus.Appearance = appearance2;
            this.LabelStatus.BackColorInternal = System.Drawing.Color.Transparent;
            this.LabelStatus.Location = new System.Drawing.Point(24, 260);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(352, 23);
            this.LabelStatus.TabIndex = 4;
            this.LabelStatus.Text = "Estado:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(398, 286);
            this.ControlBox = false;
            this.Controls.Add(this.ultraTabStripControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Splash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabStripControl1)).EndInit();
            this.ultraTabStripControl1.ResumeLayout(false);
            this.ultraTabSharedControlsPage1.ResumeLayout(false);
            this.ultraTabSharedControlsPage1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public static string EstadoCarga
		{
			get
			{
				return (formSplash == null) ? String.Empty : Splash.estadoCarga;
			}
			set
			{
				Splash.estadoCarga = value;
			}
		}

		public static string NombreAplicacion
		{
			get
			{
				return Splash.nombreAplicacion;
			}
			set
			{
				Splash.nombreAplicacion = value;
				//formSplash.labelNombreAplicacion.Text = value;
				//formSplash.Refresh();
			}
		}

		public static string Version
		{
			get
			{
				return Splash.version;
			}
			set
			{
				Splash.version = value;
//				formSplash.labelVersion.Text = value;
//				formSplash.Refresh();
			}
		}

		static public void Mostrar()
		{
			// Make sure it is only launched once.
			if( formSplash != null )
				return;
			ms_oThread = new Thread(new ThreadStart(Splash.ShowForm));
			ms_oThread.IsBackground = true;
			ms_oThread.SetApartmentState(ApartmentState.STA);
			ms_oThread.Start();
		}
		static private void ShowForm()
		{
			formSplash = new Splash();
			Application.Run(formSplash);
		}
		static public void Cerrar(bool desvanecer)
		{
			cierreIniciado = true;
			if (!desvanecer && formSplash != null)
			{
				formSplash.Close();
				formSplash.Dispose();
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.LabelStatus.Text = estadoCarga;
			//si se inició el proceso de fadeout
			if ( cierreIniciado )
			{
				this.Opacity += incrementoOpacity;
				if (this.Opacity <= 0)
				{
					this.Close();
					this.Dispose();
				}
			}
		}


	}
}
