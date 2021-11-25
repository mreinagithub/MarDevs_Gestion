using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MarDevs.OC.Core;
using Infragistics.Win.UltraWinGrid;

namespace MarDevs.OC.Win
{
	public partial class FormAuditoria : Form
	{
		public FormAuditoria()
		{
			InitializeComponent();
		}
		public FormAuditoria(object obj)
		{
			InitializeComponent();
			_obj = obj;

			this.grillaBitacora.DoubleClickRow+=new DoubleClickRowEventHandler(grillaBitacora_DoubleClickRow);
		}
		private object _obj;

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MostrarLog()
		{
			if (this.grillaBitacora.ActiveRow != null)
			{
				Log log = this.grillaBitacora.ActiveRow.ListObject as Log;
				if (log != null)
				{
					FormLog f = new FormLog(log);
					f.ShowDialog();
				}
			}
		}

		private void grillaBitacora_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
		{
			if (e.RowArea == RowArea.Cell)
			{
				MostrarLog();
			}
		}

		private void FormAuditoria_Load(object sender, EventArgs e)
		{
			IAuditable auditable = _obj as IAuditable;
			if (auditable != null)
			{
				this.bindingSourceLog.DataSource = auditable.ObtenerLog();
				this.txtCreadoEl.Value = auditable.CreadoEl;
				this.txtCreadoPor.Value = (auditable.CreadoPor != null) ? auditable.CreadoPor.Logon : String.Empty;

				if (this.grillaBitacora.Rows.Count > 0)
				{
					this.grillaBitacora.Rows[0].Selected = true;
				}
			}

		}

	}
}
