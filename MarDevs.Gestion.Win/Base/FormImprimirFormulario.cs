using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace MarDevs.Gestion.Win
{
	public partial class FormImprimirFormulario : Form
	{
		public FormImprimirFormulario()
		{
			InitializeComponent();
		}
		private void FormImprimirFormulario_Load(object sender, EventArgs e)
		{
			try
			{
				PrintDocument prtdoc = new PrintDocument();
				string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;

				foreach (string impresora in PrinterSettings.InstalledPrinters)
				{
					comboImpresoras.Items.Add(impresora);
					if (impresora == strDefaultPrinter)
					{
						comboImpresoras.SelectedIndex = comboImpresoras.Items.Count - 1;
					}
				}
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
				this.Close();
			}

		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

	}
}
