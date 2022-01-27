using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MarDevs.Gestion.Win
{
	/// <summary>
	/// Descripción breve de FormConfirmarDescarga.
	/// </summary>
	public class FormConfirmarDescarga : System.Windows.Forms.Form
	{
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton BotonAceptar;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormConfirmarDescarga()
		{
			InitializeComponent();
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
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.BotonAceptar = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            appearance1.TextHAlignAsString = "Center";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Location = new System.Drawing.Point(16, 16);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(256, 64);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Las actualizaciones disponibles ya se han descargado y están listas para ser inst" +
    "aladas. Presione aceptar para instalarlas e iniciar nuevamente el sistema.";
            // 
            // BotonAceptar
            // 
            this.BotonAceptar.Location = new System.Drawing.Point(112, 88);
            this.BotonAceptar.Name = "BotonAceptar";
            this.BotonAceptar.Size = new System.Drawing.Size(75, 23);
            this.BotonAceptar.TabIndex = 1;
            this.BotonAceptar.Text = "Aceptar";
            this.BotonAceptar.Click += new System.EventHandler(this.BotonAceptar_Click);
            // 
            // FormConfirmarDescarga
            // 
            this.AcceptButton = this.BotonAceptar;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 117);
            this.ControlBox = false;
            this.Controls.Add(this.BotonAceptar);
            this.Controls.Add(this.ultraLabel1);
            this.Name = "FormConfirmarDescarga";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aviso de actualización disponible";
            this.TopMost = true;
            this.ResumeLayout(false);

		}
		#endregion

		private void BotonAceptar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}
	}
}
