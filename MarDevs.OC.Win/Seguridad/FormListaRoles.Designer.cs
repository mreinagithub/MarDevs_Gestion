namespace MarDevs.OC.Win
{
	partial class FormListaRoles
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BindingList`1", -1);
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.txtBusqueda = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelBusqueda)).BeginInit();
			this.panelBusqueda.SuspendLayout();
			this.ultraExpandableGroupBoxPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBusqueda)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraGrid1
			// 
			this.ultraToolbarsManager1.SetContextMenuUltra(this.ultraGrid1, "PopupAcciones");
			appearance1.BackColor = System.Drawing.Color.White;
			this.ultraGrid1.DisplayLayout.Appearance = appearance1;
			this.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
			ultraGridBand1.ColHeaderLines = 2;
			this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
			this.ultraGrid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
			this.ultraGrid1.DisplayLayout.GroupByBox.Prompt = "Arrastre un encabezado de columna aquí para agrupar por esa columna";
			this.ultraGrid1.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
			this.ultraGrid1.DisplayLayout.MaxBandDepth = 1;
			this.ultraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.ultraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
			appearance2.BackColor = System.Drawing.Color.Transparent;
			this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
			this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.ultraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
			this.ultraGrid1.DisplayLayout.Override.FilterOperatorDropDownItems = ((Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems)(((((((((((((Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Equals | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.NotEquals) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.LessThan) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.LessThanOrEqualTo) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.GreaterThan) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.GreaterThanOrEqualTo) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Like) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.StartsWith) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.DoesNotStartWith) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.EndsWith) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.DoesNotEndWith) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Contains) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.DoesNotContain)));
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			appearance3.BorderColor = System.Drawing.Color.LightGray;
			appearance3.TextVAlignAsString = "Middle";
			this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance3;
			this.ultraGrid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
			this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
			this.ultraGrid1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
			this.ultraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.ultraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
			this.ultraGrid1.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
			this.ultraGrid1.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
			this.ultraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
			this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.ultraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
			this.ultraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.ultraGrid1.Location = new System.Drawing.Point(0, 145);
			this.ultraGrid1.Size = new System.Drawing.Size(720, 341);
			this.ultraGrid1.TabIndex = 0;
			// 
			// panelBusqueda
			// 
			this.panelBusqueda.ExpandedSize = new System.Drawing.Size(720, 57);
			this.panelBusqueda.Size = new System.Drawing.Size(720, 57);
			this.panelBusqueda.Visible = true;
			// 
			// btnRestablecerParametros
			// 
			this.btnRestablecerParametros.Location = new System.Drawing.Point(406, 3);
			this.btnRestablecerParametros.TabIndex = 2;
			// 
			// btnActualizarDatos
			// 
			this.btnActualizarDatos.Location = new System.Drawing.Point(307, 3);
			this.btnActualizarDatos.TabIndex = 1;
			// 
			// ultraExpandableGroupBoxPanel1
			// 
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel1);
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtBusqueda);
			this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(714, 34);
			this.ultraExpandableGroupBoxPanel1.Controls.SetChildIndex(this.btnActualizarDatos, 0);
			this.ultraExpandableGroupBoxPanel1.Controls.SetChildIndex(this.txtBusqueda, 0);
			this.ultraExpandableGroupBoxPanel1.Controls.SetChildIndex(this.btnRestablecerParametros, 0);
			this.ultraExpandableGroupBoxPanel1.Controls.SetChildIndex(this.ultraLabel1, 0);
			// 
			// ultraToolbarsManager1
			// 
			this.ultraToolbarsManager1.MenuSettings.ForceSerialization = true;
			this.ultraToolbarsManager1.ToolbarSettings.ForceSerialization = true;
			// 
			// ultraDockManager1
			// 
			this.ultraDockManager1.DefaultGroupSettings.ForceSerialization = true;
			this.ultraDockManager1.DefaultPaneSettings.ForceSerialization = true;
			// 
			// _FormMDIBaseUnpinnedTabAreaTop
			// 
			this._FormMDIBaseUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 50);
			// 
			// _FormMDIBaseUnpinnedTabAreaLeft
			// 
			this._FormMDIBaseUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 50);
			this._FormMDIBaseUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 436);
			// 
			// _FormMDIBaseUnpinnedTabAreaRight
			// 
			this._FormMDIBaseUnpinnedTabAreaRight.Location = new System.Drawing.Point(720, 50);
			this._FormMDIBaseUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 436);
			// 
			// ultraLabel1
			// 
			appearance4.BackColor = System.Drawing.Color.Transparent;
			this.ultraLabel1.Appearance = appearance4;
			this.ultraLabel1.AutoSize = true;
			this.ultraLabel1.Location = new System.Drawing.Point(10, 6);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(48, 14);
			this.ultraLabel1.TabIndex = 8;
			this.ultraLabel1.Text = "Nombre:";
			// 
			// txtBusqueda
			// 
			this.txtBusqueda.Location = new System.Drawing.Point(65, 3);
			this.txtBusqueda.Name = "txtBusqueda";
			this.txtBusqueda.Size = new System.Drawing.Size(235, 21);
			this.txtBusqueda.TabIndex = 0;
			this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
			// 
			// FormListaRoles
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 486);
			this.Name = "FormListaRoles";
			this.Text = "FormListaRoles";
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelBusqueda)).EndInit();
			this.panelBusqueda.ResumeLayout(false);
			this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
			this.ultraExpandableGroupBoxPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBusqueda)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBusqueda;
	}
}