using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarDevs.Gestion.Win
{
	public partial class FormVistaPersonalizadaParametroTest : Form
	{
		public FormVistaPersonalizadaParametroTest()
		{
			InitializeComponent();
		}

		private void FormVistaPersonalizadaParametroTest_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_soloLectura && !_fueCerrado)
				e.Cancel = true;
		}

		private bool _fueCerrado = false;
		public bool _soloLectura = true;

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			_fueCerrado = true;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void FormVistaPersonalizadaParametroTest_Load(object sender, EventArgs e)
		{
			this.btnConsultar.Location = new Point(this.contenedorParametros1.Width + 10, (this.contenedorParametros1.Top + (this.btnConsultar.Height / 2) - 5));
			this.btnCancelar.Location = new Point(this.contenedorParametros1.Width + 10, this.btnConsultar.Bottom + 5);

		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			_fueCerrado = true;
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
