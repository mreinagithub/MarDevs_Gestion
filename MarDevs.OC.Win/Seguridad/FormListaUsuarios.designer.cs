namespace MarDevs.OC.Win
{
	partial class FormListaUsuarios
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
			Infragistics.Win.UltraWinGrid.UltraGridLayout ultraGridLayout1 = new Infragistics.Win.UltraWinGrid.UltraGridLayout("Default");
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Usuario", -1);
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Logon");
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaUltimoIngreso");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CreadoEl");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Apellido");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CreadoPor");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Telefono2");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCompleto");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Telefono1");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaUltimoCambioPassword");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Habilitado");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsarVigenciaPasswordDefault");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Email1");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Area", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasVigenciaPassword");
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			this.txtBusqueda = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.chkSoloActivos = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelBusqueda)).BeginInit();
			this.panelBusqueda.SuspendLayout();
			this.ultraExpandableGroupBoxPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBusqueda)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSoloActivos)).BeginInit();
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
			this.ultraGrid1.DisplayLayout.EmptyRowSettings.ShowEmptyRows = true;
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
			appearance3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			appearance3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ultraGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance3;
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			appearance4.BorderColor = System.Drawing.Color.LightGray;
			appearance4.TextVAlignAsString = "Middle";
			this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance4;
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
			appearance5.BackColor = System.Drawing.Color.White;
			ultraGridLayout1.Appearance = appearance5;
			ultraGridLayout1.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
			appearance6.BackColor = System.Drawing.SystemColors.ControlLight;
			ultraGridColumn1.CellAppearance = appearance6;
			ultraGridColumn1.ColumnChooserCaption = "Cuenta";
			ultraGridColumn1.Header.Caption = "Cuenta";
			ultraGridColumn1.Header.VisiblePosition = 0;
			ultraGridColumn1.Width = 88;
			ultraGridColumn2.ColumnChooserCaption = "Ultimo Ingreso";
			ultraGridColumn2.Header.Caption = "Ultimo Ingreso";
			ultraGridColumn2.Header.VisiblePosition = 3;
			ultraGridColumn2.Width = 71;
			ultraGridColumn3.ColumnChooserCaption = "Cargado El";
			ultraGridColumn3.Header.Caption = "Cargado El";
			ultraGridColumn3.Header.VisiblePosition = 14;
			ultraGridColumn3.Hidden = true;
			ultraGridColumn4.ColumnChooserCaption = "Apellido";
			ultraGridColumn4.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
			ultraGridColumn4.Header.VisiblePosition = 4;
			ultraGridColumn4.Hidden = true;
			ultraGridColumn5.ColumnChooserCaption = "Creado Por";
			ultraGridColumn5.Header.Caption = "Creado Por";
			ultraGridColumn5.Header.VisiblePosition = 13;
			ultraGridColumn5.Hidden = true;
			ultraGridColumn6.ColumnChooserCaption = "Nombre";
			ultraGridColumn6.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
			ultraGridColumn6.Header.VisiblePosition = 5;
			ultraGridColumn6.Hidden = true;
			ultraGridColumn7.ColumnChooserCaption = "Telefono2";
			ultraGridColumn7.Header.VisiblePosition = 7;
			ultraGridColumn7.Hidden = true;
			ultraGridColumn8.ColumnChooserCaption = "Nombre Completo";
			ultraGridColumn8.Header.Caption = "Nombre Completo";
			ultraGridColumn8.Header.VisiblePosition = 1;
			ultraGridColumn8.Width = 164;
			ultraGridColumn9.ColumnChooserCaption = "Telefono1";
			ultraGridColumn9.Header.VisiblePosition = 6;
			ultraGridColumn10.ColumnChooserCaption = "Ultimo Cambio Password";
			ultraGridColumn10.Header.Caption = "Ultimo Cambio Password";
			ultraGridColumn10.Header.VisiblePosition = 8;
			ultraGridColumn10.Width = 75;
			ultraGridColumn11.ColumnChooserCaption = "Habilitado";
			ultraGridColumn11.Header.VisiblePosition = 9;
			ultraGridColumn11.Width = 90;
			ultraGridColumn12.ColumnChooserCaption = "Usar Vigencia Password Default";
			ultraGridColumn12.Header.Caption = "Usar Vigencia Password Default";
			ultraGridColumn12.Header.VisiblePosition = 10;
			ultraGridColumn12.Hidden = true;
			ultraGridColumn12.Width = 113;
			ultraGridColumn13.ColumnChooserCaption = "e-mail";
			ultraGridColumn13.Header.Caption = "e-mail";
			ultraGridColumn13.Header.VisiblePosition = 11;
			ultraGridColumn13.Width = 135;
			ultraGridColumn14.ColumnChooserCaption = "Area";
			ultraGridColumn14.Header.VisiblePosition = 2;
			ultraGridColumn14.Width = 204;
			ultraGridColumn15.ColumnChooserCaption = "Dias Vigencia Password";
			ultraGridColumn15.Header.Caption = "Dias Vigencia Password";
			ultraGridColumn15.Header.VisiblePosition = 12;
			ultraGridColumn15.Hidden = true;
			ultraGridColumn15.Width = 84;
			ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15});
			ultraGridLayout1.BandsSerializer.Add(ultraGridBand2);
			ultraGridLayout1.EmptyRowSettings.ShowEmptyRows = true;
			ultraGridLayout1.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
			ultraGridLayout1.GroupByBox.Prompt = "Arrastre un encabezado de columna aquí para agrupar por esa columna";
			ultraGridLayout1.Key = "Default";
			ultraGridLayout1.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
			ultraGridLayout1.MaxBandDepth = 1;
			ultraGridLayout1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			ultraGridLayout1.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			ultraGridLayout1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			ultraGridLayout1.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
			appearance7.BackColor = System.Drawing.Color.Transparent;
			ultraGridLayout1.Override.CardAreaAppearance = appearance7;
			ultraGridLayout1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			ultraGridLayout1.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
			ultraGridLayout1.Override.FilterOperatorDropDownItems = ((Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems)(((((((((((((Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Equals | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.NotEquals) 
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
			appearance8.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			appearance8.ForeColor = System.Drawing.SystemColors.ControlText;
			ultraGridLayout1.Override.GroupByRowAppearance = appearance8;
			ultraGridLayout1.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			appearance9.BorderColor = System.Drawing.Color.LightGray;
			appearance9.TextVAlignAsString = "Middle";
			ultraGridLayout1.Override.RowAppearance = appearance9;
			ultraGridLayout1.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
			ultraGridLayout1.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
			ultraGridLayout1.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
			ultraGridLayout1.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			ultraGridLayout1.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			ultraGridLayout1.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
			ultraGridLayout1.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
			ultraGridLayout1.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
			ultraGridLayout1.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
			ultraGridLayout1.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			ultraGridLayout1.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			ultraGridLayout1.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
			ultraGridLayout1.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.ultraGrid1.Layouts.Add(ultraGridLayout1);
			this.ultraGrid1.Location = new System.Drawing.Point(0, 143);
			this.ultraGrid1.Size = new System.Drawing.Size(720, 287);
			// 
			// panelBusqueda
			// 
			this.panelBusqueda.ExpandedSize = new System.Drawing.Size(720, 78);
			this.panelBusqueda.Size = new System.Drawing.Size(720, 55);
			this.panelBusqueda.Visible = true;
			// 
			// btnRestablecerParametros
			// 
			this.btnRestablecerParametros.Location = new System.Drawing.Point(527, 3);
			// 
			// btnActualizarDatos
			// 
			this.btnActualizarDatos.Location = new System.Drawing.Point(429, 3);
			// 
			// ultraExpandableGroupBoxPanel1
			// 
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel1);
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtBusqueda);
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.chkSoloActivos);
			this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(714, 32);
			this.ultraExpandableGroupBoxPanel1.Controls.SetChildIndex(this.btnActualizarDatos, 0);
			this.ultraExpandableGroupBoxPanel1.Controls.SetChildIndex(this.chkSoloActivos, 0);
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
			// _FormMDIBaseUnpinnedTabAreaBottom
			// 
			this._FormMDIBaseUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 430);
			// 
			// _FormMDIBaseUnpinnedTabAreaLeft
			// 
			this._FormMDIBaseUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 50);
			this._FormMDIBaseUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 380);
			// 
			// _FormMDIBaseUnpinnedTabAreaRight
			// 
			this._FormMDIBaseUnpinnedTabAreaRight.Location = new System.Drawing.Point(720, 50);
			this._FormMDIBaseUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 380);
			// 
			// txtBusqueda
			// 
			this.txtBusqueda.Location = new System.Drawing.Point(106, 4);
			this.txtBusqueda.Name = "txtBusqueda";
			this.txtBusqueda.Size = new System.Drawing.Size(156, 21);
			this.txtBusqueda.TabIndex = 8;
			// 
			// ultraLabel1
			// 
			appearance10.BackColor = System.Drawing.Color.Transparent;
			this.ultraLabel1.Appearance = appearance10;
			this.ultraLabel1.AutoSize = true;
			this.ultraLabel1.Location = new System.Drawing.Point(10, 7);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(90, 14);
			this.ultraLabel1.TabIndex = 9;
			this.ultraLabel1.Text = "Logon o nombre:";
			// 
			// chkSoloActivos
			// 
			appearance11.BackColor = System.Drawing.Color.Transparent;
			this.chkSoloActivos.Appearance = appearance11;
			this.chkSoloActivos.BackColor = System.Drawing.Color.Transparent;
			this.chkSoloActivos.BackColorInternal = System.Drawing.Color.Transparent;
			this.chkSoloActivos.Checked = true;
			this.chkSoloActivos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSoloActivos.Location = new System.Drawing.Point(278, 4);
			this.chkSoloActivos.Name = "chkSoloActivos";
			this.chkSoloActivos.Size = new System.Drawing.Size(145, 20);
			this.chkSoloActivos.TabIndex = 10;
			this.chkSoloActivos.Text = "Sólo usuarios activos";
			// 
			// FormListaUsuarios
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(720, 430);
			this.Name = "FormListaUsuarios";
			this.PermitirAgregarElementos = true;
			this.PermitirEliminarElementos = true;
			this.Text = "Administración de usuarios";
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
			((System.ComponentModel.ISupportInitialize)(this.chkSoloActivos)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBusqueda;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkSoloActivos;
		
	}
}

