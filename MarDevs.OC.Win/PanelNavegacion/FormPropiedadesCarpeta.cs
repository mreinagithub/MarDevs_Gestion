using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarDevs.OC.Win
{
	public partial class FormPropiedadesCarpeta : Form
	{
		public FormPropiedadesCarpeta()
		{
			InitializeComponent();
		}

		private void botonAceptar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}