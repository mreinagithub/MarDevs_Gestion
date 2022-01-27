using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace MarDevs.Gestion.Win
{
	public partial class FormPersonalizarGrilla : Form
	{
		public FormPersonalizarGrilla(UltraGrid grilla)
		{
			InitializeComponent();
			_grilla = grilla;
			this.Activated += new EventHandler(FormPersonalizarGrilla_Activated);
			this.Shown += new EventHandler(FormPersonalizarGrilla_Shown);
		}

		void FormPersonalizarGrilla_Shown(object sender, EventArgs e)
		{
			UltraGridBand banda = this.ultraGridColumnChooser1.DisplayLayout.Bands[0];
			banda.RowLayoutStyle = RowLayoutStyle.ColumnLayout;
			banda.RowLayoutLabelPosition = LabelPosition.Top;
			banda.Override.AllowColMoving = AllowColMoving.WithinBand;
			banda.Override.AllowColSizing = AllowColSizing.Free;
			this.ultraGridColumnChooser1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
			this.ultraGridColumnChooser1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
			if (this.ultraGridColumnChooser1.DisplayLayout.Bands[0].Columns.Exists("Value"))
			{
				this.ultraGridColumnChooser1.DisplayLayout.Bands[0].SortedColumns.Add("Value", false);
			}
			banda.ColHeadersVisible = true;
		}
		void FormPersonalizarGrilla_Activated(object sender, EventArgs e)
		{
		}

		private UltraGrid _grilla;

		private void FormPersonalizarGrilla_Load(object sender, EventArgs e)
		{
			this.ultraGridColumnChooser1.SourceGrid = _grilla;
			foreach (UltraGridColumn col in this.ultraGridColumnChooser1.SourceGrid.DisplayLayout.Bands[0].Columns)
			{
				if (col.ColumnChooserCaption == null)
				{
					col.ColumnChooserCaption = col.Header.Caption.Replace("\n", " ");
				}
			}
			this.ultraGridColumnChooser1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
			this.ultraGridColumnChooser1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.ExternalSortSingle;
			if (this.ultraGridColumnChooser1.DisplayLayout.Bands[0].Columns.Exists("Value"))
			{
				this.ultraGridColumnChooser1.DisplayLayout.Bands[0].Columns["Value"].SortIndicator = SortIndicator.Ascending;
			}

		}

		private void ultraButton1_Click(object sender, EventArgs e)
		{
			UltraGridBand banda = this.ultraGridColumnChooser1.DisplayLayout.Bands[0];
			if (banda.Columns.Exists("Value"))
			{
				banda.SortedColumns.Clear();
				banda.SortedColumns.Add("Value", true);
			}
		}
		private void botonOrdenarAsc_Click(object sender, EventArgs e)
		{
			UltraGridBand banda = this.ultraGridColumnChooser1.DisplayLayout.Bands[0];
			if (banda.Columns.Exists("Value"))
			{
				banda.SortedColumns.Clear();
				banda.SortedColumns.Add("Value", false);
			}

		}
		private void FormPersonalizarGrilla_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;
		}

	}
}