using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using MarDevs.OC.Core;

namespace MarDevs.OC.Win
{
	/// <summary>
	/// Descripción breve de FormLog.
	/// </summary>
	public class FormLog : System.Windows.Forms.Form
	{
		private Log log = null;

		private Infragistics.Win.Misc.UltraButton botonAceptar;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetalle;
		private Infragistics.Win.Misc.UltraLabel labelLogHeader;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormLog(Log log)
		{
			InitializeComponent();

			this.log = log;
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			this.botonAceptar = new Infragistics.Win.Misc.UltraButton();
			this.txtDetalle = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.labelLogHeader = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.txtDetalle)).BeginInit();
			this.SuspendLayout();
			// 
			// botonAceptar
			// 
			this.botonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonAceptar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonAceptar.Location = new System.Drawing.Point(384, 279);
			this.botonAceptar.Name = "botonAceptar";
			this.botonAceptar.Size = new System.Drawing.Size(80, 25);
			this.botonAceptar.TabIndex = 10;
			this.botonAceptar.Text = "Cerrar";
			this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
			// 
			// txtDetalle
			// 
			this.txtDetalle.AcceptsReturn = true;
			this.txtDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDetalle.Location = new System.Drawing.Point(8, 48);
			this.txtDetalle.Multiline = true;
			this.txtDetalle.Name = "txtDetalle";
			this.txtDetalle.Nullable = false;
			this.txtDetalle.ReadOnly = true;
			this.txtDetalle.Size = new System.Drawing.Size(456, 224);
			this.txtDetalle.TabIndex = 9;
			// 
			// labelLogHeader
			// 
			appearance1.FontData.BoldAsString = "True";
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.labelLogHeader.Appearance = appearance1;
			this.labelLogHeader.Location = new System.Drawing.Point(9, 8);
			this.labelLogHeader.Name = "labelLogHeader";
			this.labelLogHeader.Size = new System.Drawing.Size(455, 32);
			this.labelLogHeader.TabIndex = 11;
			// 
			// FormLog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(469, 308);
			this.Controls.Add(this.labelLogHeader);
			this.Controls.Add(this.botonAceptar);
			this.Controls.Add(this.txtDetalle);
			this.Name = "FormLog";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Entrada de Log";
			this.Load += new System.EventHandler(this.FormLog_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtDetalle)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void botonAceptar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void FormLog_Load(object sender, System.EventArgs e)
		{
			this.labelLogHeader.Text = String.Format("Log creado el {0} por el usuario {1}",
				this.log.Fecha.ToString("dd/MM/yyyy HH:mm:ss "),
				this.log.Usuario.NombreCompleto);
			
			this.txtDetalle.Text = this.log.Detalle;
		}
	}
}
