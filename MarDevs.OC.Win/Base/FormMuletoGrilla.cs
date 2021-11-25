using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MarDevs.OC.Win;
using Infragistics.Win.SupportDialogs.FilterUIProvider;
using Infragistics.Win.UltraWinGrid;

namespace MarDevs.OC.Win
{
	public partial class FormMuletoGrilla : Form
	{
		public FormMuletoGrilla()
		{
			InitializeComponent();

			this.ultraGrid1.InitializeLayout += ultraGrid1_InitializeLayout;
			this.ultraGridFilterUIProvider1.AfterMenuPopulate += ultraGridFilterUIProvider1_AfterMenuPopulate;
		}

		private void ultraGridFilterUIProvider1_AfterMenuPopulate(object sender, Infragistics.Win.SupportDialogs.FilterUIProvider.AfterMenuPopulateEventArgs e)
		{
			// CACHEAR FILTROS DE TEXTO
			if (FormListaUsuarios._filtrosTexto == null && e.ColumnFilter.Column.DataType.Name == "String")
			{
				foreach (FilterTool t in e.MenuItems)
				{
					if (t.Id == "Text Filters")
					{
						FormListaUsuarios._filtrosTexto = t;
						break;
					}
				}
			}
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			e.Layout.Override.FilterUIProvider = this.ultraGridFilterUIProvider1;
			e.Layout.Override.FilterUIType = FilterUIType.FilterRow;

			this.ultraGridFilterUIProvider1.Show(e.Layout.Bands[0].ColumnFilters[0], null, Rectangle.Empty, null);
			this.ultraGridFilterUIProvider1.Close(false);
		}
	}
}
