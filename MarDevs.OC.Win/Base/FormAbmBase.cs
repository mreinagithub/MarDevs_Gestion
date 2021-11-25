using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MarDevs.OC.Core;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using System.Diagnostics;

namespace MarDevs.OC.Win
{

	public class FormAbmBase : System.Windows.Forms.Form
	{
		#region Variables del Diseñador
		protected Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FormAbmBase_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FormAbmBase_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FormAbmBase_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FormAbmBase_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		protected Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        protected Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        public Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtCreadoEl;
        public Infragistics.Win.Misc.UltraLabel UltraLabel34;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor comboCreadoPor;
        public Infragistics.Win.Misc.UltraLabel UltraLabel33;
		protected Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        protected Infragistics.Win.UltraWinGrid.UltraGrid grillaBitacora;
        public Infragistics.Win.Misc.UltraButton btnExportarLog;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Constructores
		
		private FormAbmBase() :this(null){}
		protected FormAbmBase(IPersistente obj, bool bindeaAuditoria) : this(obj)
		{
			BindeaAuditoria = bindeaAuditoria;
		}
		protected FormAbmBase(IPersistente obj)
		{
			InitializeComponent();
			this._obj = obj;

			this.Closing += new CancelEventHandler(FormAbmBase_Closing);
			this.ultraToolbarsManager1.ToolClick +=new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(ultraToolbarsManager1_ToolClick);
			this.grillaBitacora.InitializeLayout+=new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(grillaBitacora_InitializeLayout);
            this.grillaBitacora.DoubleClickRow += new DoubleClickRowEventHandler(grillaBitacora_DoubleClickRow);
			this.controlesAExcluirProcesamientoSoloLectura.Add(this.txtCreadoEl);
			this.controlesAExcluirProcesamientoSoloLectura.Add(this.comboCreadoPor);
		}
		
		#endregion

		#region Limpiar los recursos que se estén utilizando.
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
		#endregion
		
		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbmBase));
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Principal");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("GuardarYNuevo");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guardar");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("GuardarYCerrar");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cerrar");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Imprimir");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Calculadora");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guardar");
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("GuardarYCerrar");
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cerrar");
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("GuardarYNuevo");
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Imprimir");
			Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Calculadora");
			Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
			Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
			this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
			this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
			this.btnExportarLog = new Infragistics.Win.Misc.UltraButton();
			this.grillaBitacora = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.txtCreadoEl = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.UltraLabel34 = new Infragistics.Win.Misc.UltraLabel();
			this.comboCreadoPor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.UltraLabel33 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this._FormAbmBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._FormAbmBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._FormAbmBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._FormAbmBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
			this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
			this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
			this.ultraTabPageControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreadoEl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboCreadoPor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
			this.ultraTabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraTabPageControl1
			// 
			this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 22);
			this.ultraTabPageControl1.Name = "ultraTabPageControl1";
			this.ultraTabPageControl1.Size = new System.Drawing.Size(590, 322);
			// 
			// ultraTabPageControl2
			// 
			this.ultraTabPageControl2.Controls.Add(this.btnExportarLog);
			this.ultraTabPageControl2.Controls.Add(this.grillaBitacora);
			this.ultraTabPageControl2.Controls.Add(this.txtCreadoEl);
			this.ultraTabPageControl2.Controls.Add(this.UltraLabel34);
			this.ultraTabPageControl2.Controls.Add(this.comboCreadoPor);
			this.ultraTabPageControl2.Controls.Add(this.UltraLabel33);
			this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
			this.ultraTabPageControl2.Name = "ultraTabPageControl2";
			this.ultraTabPageControl2.Size = new System.Drawing.Size(590, 322);
			// 
			// btnExportarLog
			// 
			appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
			appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.btnExportarLog.Appearance = appearance1;
			this.btnExportarLog.Location = new System.Drawing.Point(252, 32);
			this.btnExportarLog.Name = "btnExportarLog";
			this.btnExportarLog.Size = new System.Drawing.Size(75, 23);
			this.btnExportarLog.TabIndex = 12;
			this.btnExportarLog.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnExportarLog.Click += new System.EventHandler(this.btnExportarLog_Click);
			// 
			// grillaBitacora
			// 
			this.grillaBitacora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			appearance2.BackColor = System.Drawing.Color.White;
			this.grillaBitacora.DisplayLayout.Appearance = appearance2;
			this.grillaBitacora.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
			ultraGridBand1.AddButtonCaption = "DummyBand 1";
			this.grillaBitacora.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
			this.grillaBitacora.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.grillaBitacora.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.grillaBitacora.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			this.grillaBitacora.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
			appearance3.BackColor = System.Drawing.Color.Transparent;
			this.grillaBitacora.DisplayLayout.Override.CardAreaAppearance = appearance3;
			this.grillaBitacora.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.grillaBitacora.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
			appearance4.TextHAlignAsString = "Left";
			this.grillaBitacora.DisplayLayout.Override.HeaderAppearance = appearance4;
			this.grillaBitacora.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			appearance5.BorderColor = System.Drawing.Color.LightGray;
			appearance5.TextVAlignAsString = "Middle";
			this.grillaBitacora.DisplayLayout.Override.RowAppearance = appearance5;
			this.grillaBitacora.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance6.BackColor = System.Drawing.SystemColors.Highlight;
			appearance6.BorderColor = System.Drawing.Color.Black;
			appearance6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.grillaBitacora.DisplayLayout.Override.SelectedRowAppearance = appearance6;
			this.grillaBitacora.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaBitacora.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaBitacora.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			this.grillaBitacora.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
			this.grillaBitacora.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.grillaBitacora.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.grillaBitacora.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
			this.grillaBitacora.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.grillaBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grillaBitacora.Location = new System.Drawing.Point(8, 64);
			this.grillaBitacora.Name = "grillaBitacora";
			this.grillaBitacora.Size = new System.Drawing.Size(578, 250);
			this.grillaBitacora.TabIndex = 7;
			this.grillaBitacora.Text = "Log de Cambios";
			// 
			// txtCreadoEl
			// 
			this.txtCreadoEl.DateTime = new System.DateTime(2004, 11, 14, 0, 0, 0, 0);
			this.txtCreadoEl.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
			this.txtCreadoEl.Location = new System.Drawing.Point(120, 8);
			this.txtCreadoEl.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
			this.txtCreadoEl.MaskInput = "{LOC}dd/mm/yyyy hh:mm:ss";
			this.txtCreadoEl.Name = "txtCreadoEl";
			this.txtCreadoEl.ReadOnly = true;
			this.txtCreadoEl.Size = new System.Drawing.Size(117, 21);
			this.txtCreadoEl.TabIndex = 1;
			this.txtCreadoEl.TabStop = false;
			this.txtCreadoEl.Value = new System.DateTime(2004, 11, 14, 0, 0, 0, 0);
			// 
			// UltraLabel34
			// 
			appearance7.TextVAlignAsString = "Middle";
			this.UltraLabel34.Appearance = appearance7;
			this.UltraLabel34.BackColorInternal = System.Drawing.Color.Transparent;
			this.UltraLabel34.Location = new System.Drawing.Point(8, 8);
			this.UltraLabel34.Name = "UltraLabel34";
			this.UltraLabel34.Size = new System.Drawing.Size(112, 23);
			this.UltraLabel34.TabIndex = 0;
			this.UltraLabel34.Text = "Elemento creado el:";
			// 
			// comboCreadoPor
			// 
			this.comboCreadoPor.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
			this.comboCreadoPor.Location = new System.Drawing.Point(120, 32);
			this.comboCreadoPor.Name = "comboCreadoPor";
			this.comboCreadoPor.ReadOnly = true;
			this.comboCreadoPor.Size = new System.Drawing.Size(117, 21);
			this.comboCreadoPor.TabIndex = 3;
			this.comboCreadoPor.TabStop = false;
			// 
			// UltraLabel33
			// 
			appearance8.TextVAlignAsString = "Middle";
			this.UltraLabel33.Appearance = appearance8;
			this.UltraLabel33.BackColorInternal = System.Drawing.Color.Transparent;
			this.UltraLabel33.Location = new System.Drawing.Point(8, 32);
			this.UltraLabel33.Name = "UltraLabel33";
			this.UltraLabel33.Size = new System.Drawing.Size(112, 21);
			this.UltraLabel33.TabIndex = 2;
			this.UltraLabel33.Text = "Elemento creado por:";
			// 
			// ultraToolbarsManager1
			// 
			this.ultraToolbarsManager1.DesignerFlags = 1;
			this.ultraToolbarsManager1.DockWithinContainer = this;
			this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
			this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
			this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			buttonTool6.InstanceProps.IsFirstInGroup = true;
			ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6});
			ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
			ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
			ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
			ultraToolbar1.Settings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
			ultraToolbar1.Text = "Principal";
			this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			appearance10.Image = ((object)(resources.GetObject("appearance10.Image")));
			buttonTool7.SharedPropsInternal.AppearancesSmall.Appearance = appearance10;
			buttonTool7.SharedPropsInternal.Caption = "Guardar";
			buttonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			appearance11.Image = ((object)(resources.GetObject("appearance11.Image")));
			buttonTool8.SharedPropsInternal.AppearancesSmall.Appearance = appearance11;
			buttonTool8.SharedPropsInternal.Caption = "Guardar y Cerrar";
			buttonTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			appearance12.Image = ((object)(resources.GetObject("appearance12.Image")));
			buttonTool9.SharedPropsInternal.AppearancesSmall.Appearance = appearance12;
			buttonTool9.SharedPropsInternal.Caption = "Cerrar";
			buttonTool9.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			appearance13.Image = ((object)(resources.GetObject("appearance13.Image")));
			buttonTool10.SharedPropsInternal.AppearancesSmall.Appearance = appearance13;
			buttonTool10.SharedPropsInternal.Caption = "Guardar y Nuevo";
			buttonTool10.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool10.SharedPropsInternal.Visible = false;
			appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
			buttonTool11.SharedPropsInternal.AppearancesSmall.Appearance = appearance14;
			buttonTool11.SharedPropsInternal.Caption = "Imprimir";
			buttonTool11.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool11.SharedPropsInternal.Visible = false;
			appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
			buttonTool12.SharedPropsInternal.AppearancesSmall.Appearance = appearance15;
			buttonTool12.SharedPropsInternal.Caption = "Calculadora";
			buttonTool12.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12});
			// 
			// _FormAbmBase_Toolbars_Dock_Area_Left
			// 
			this._FormAbmBase_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._FormAbmBase_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this._FormAbmBase_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._FormAbmBase_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._FormAbmBase_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 28);
			this._FormAbmBase_Toolbars_Dock_Area_Left.Name = "_FormAbmBase_Toolbars_Dock_Area_Left";
			this._FormAbmBase_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 345);
			this._FormAbmBase_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _FormAbmBase_Toolbars_Dock_Area_Right
			// 
			this._FormAbmBase_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._FormAbmBase_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this._FormAbmBase_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._FormAbmBase_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._FormAbmBase_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(592, 28);
			this._FormAbmBase_Toolbars_Dock_Area_Right.Name = "_FormAbmBase_Toolbars_Dock_Area_Right";
			this._FormAbmBase_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 345);
			this._FormAbmBase_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _FormAbmBase_Toolbars_Dock_Area_Top
			// 
			this._FormAbmBase_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._FormAbmBase_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this._FormAbmBase_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._FormAbmBase_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._FormAbmBase_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._FormAbmBase_Toolbars_Dock_Area_Top.Name = "_FormAbmBase_Toolbars_Dock_Area_Top";
			this._FormAbmBase_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(592, 28);
			this._FormAbmBase_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _FormAbmBase_Toolbars_Dock_Area_Bottom
			// 
			this._FormAbmBase_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._FormAbmBase_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this._FormAbmBase_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._FormAbmBase_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._FormAbmBase_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 373);
			this._FormAbmBase_Toolbars_Dock_Area_Bottom.Name = "_FormAbmBase_Toolbars_Dock_Area_Bottom";
			this._FormAbmBase_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(592, 0);
			this._FormAbmBase_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// ultraTabControl1
			// 
			appearance9.FontData.BoldAsString = "True";
			this.ultraTabControl1.ActiveTabAppearance = appearance9;
			this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
			this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
			this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
			this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ultraTabControl1.Location = new System.Drawing.Point(0, 28);
			this.ultraTabControl1.Name = "ultraTabControl1";
			this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
			this.ultraTabControl1.Size = new System.Drawing.Size(592, 345);
			this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
			this.ultraTabControl1.TabIndex = 0;
			ultraTab1.Key = "General";
			ultraTab1.TabPage = this.ultraTabPageControl1;
			ultraTab1.Text = "General";
			ultraTab2.Key = "Auditoria";
			ultraTab2.TabPage = this.ultraTabPageControl2;
			ultraTab2.Text = "Auditoría";
			this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
			this.ultraTabControl1.TabStop = false;
			this.ultraTabControl1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
			// 
			// ultraTabSharedControlsPage1
			// 
			this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
			this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
			this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(590, 322);
			// 
			// FormAbmBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 373);
			this.Controls.Add(this.ultraTabControl1);
			this.Controls.Add(this._FormAbmBase_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._FormAbmBase_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._FormAbmBase_Toolbars_Dock_Area_Bottom);
			this.Controls.Add(this._FormAbmBase_Toolbars_Dock_Area_Top);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormAbmBase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormAbmBase";
			this.Load += new System.EventHandler(this.FormAbmBase_Load);
			this.ultraTabPageControl2.ResumeLayout(false);
			this.ultraTabPageControl2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreadoEl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboCreadoPor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
			this.ultraTabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region   Eventos

		private ObjetoGuardadoEventHandler _objetoGuardadoEventHandler;
		public event ObjetoGuardadoEventHandler ObjetoGuardado
		{
			add { _objetoGuardadoEventHandler += value; }
			remove { _objetoGuardadoEventHandler -= value; }
		}
		protected virtual void OnObjetoGuardado(ObjetoGuardadoEventArgs e)
		{
			if (_objetoGuardadoEventHandler != null)
			{
				// Invocar los delegados
				_objetoGuardadoEventHandler(this, e);
			}
		}

		#endregion

		protected IPersistente _obj;
		protected bool _soloLectura = false;
		protected bool _bindeaAuditoria = true;
		protected ArrayList controlesAExcluirProcesamientoSoloLectura = new ArrayList();
		public static string STR_CONFIRMACION_AL_SALIR = "Se han producido cambios.\n¿Desea guardarlos?";

		public bool BindeaAuditoria
		{
			get { return _bindeaAuditoria; }
			set { _bindeaAuditoria = value; }
		}
		protected virtual bool SoloLectura
		{
			get { return _soloLectura; }
			set 
			{ 
				_soloLectura = value; 
				this.EstablecerSoloLecturaEnControles(this, value);
			}
		}
		protected virtual bool CalculadoraVisible
		{
			get{ return this.ultraToolbarsManager1.Tools["Calculadora"].SharedProps.Visible;}
			set{ this.ultraToolbarsManager1.Tools["Calculadora"].SharedProps.Visible = value;}
		}

		protected virtual void CrearElemento()
		{
			// En el ABM Base no hay logica de negocios para Crear Elemento
		}
		protected virtual bool GuardarCambios()
		{
			//ASEGURARSE DE SACAR EL FOCO DEL CONTROL ACTUAL PARA QUE GUARDE LOS CAMBIOS
			this.GetNextControl(this, true).Focus();

			try
			{
				_obj.Guardar();
                _obj.CapturarSnapshot();
				OnObjetoGuardado(new ObjetoGuardadoEventArgs(_obj));
                return true;
			}
			catch (ExcepcionNegocios exN)
			{
				Mensaje.Advertencia(exN.Message);
				return false;
			}
			catch( Exception ex )
			{
				Mensaje.ErrorAlGuardar(ex.Message, ex);
				return false;
			}
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
        protected virtual void ExportarLog()
        {
            bool exito = true;
            string archivo = String.Empty;
            string carpeta = String.Empty;
            try
            {
                archivo = String.Format("tmp{0}.xls", new Random().Next(9999).ToString().PadLeft(4, Char.Parse("0")));
                archivo = Path.Combine(UtilP.CarpetaTemporal(), archivo);
                this.ultraGridExcelExporter1.Export(this.grillaBitacora, archivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar crear el archivo de Excel "
                    + archivo + ". La Exportacin no pudo realizarse." + ex.ToString(),
                    "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                exito = false;
            }
            if (exito == true)
            {
                try
                {
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = archivo;
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.RedirectStandardOutput = false;
                    myProcess.Start();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al intentar abrir el archivo generado. Posiblemente no existan en el sistema aplicaciones para abrir archivos XLS.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        protected void EstablecerSoloLecturaEnControles(Control control, bool valor)
        {
            if (this.controlesAExcluirProcesamientoSoloLectura.Contains(control))
            {
                return;
            }
            if (control is Infragistics.Win.UltraWinEditors.UltraTextEditor)
            {
                (control as Infragistics.Win.UltraWinEditors.UltraTextEditor).ReadOnly = valor;
                return;
            }
            if (control is Infragistics.Win.UltraWinEditors.UltraComboEditor)
            {
                (control as Infragistics.Win.UltraWinEditors.UltraComboEditor).ReadOnly = valor;
                return;
            }
            if (control is Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)
            {
                (control as Infragistics.Win.UltraWinEditors.UltraDateTimeEditor).ReadOnly = valor;
                return;
            }
            if (control is Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit)
            {
                (control as Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit).ReadOnly = valor;
                return;
            }
            if (control is Infragistics.Win.Misc.UltraButton)
            {
                (control as Infragistics.Win.Misc.UltraButton).Enabled = !valor;
                return;
            }
            if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
            {
                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = !valor;
                return;
            }
            foreach (Control c in control.Controls)
            {
                this.EstablecerSoloLecturaEnControles(c, valor);
            }
        }
        protected void LimpiarBindings()
        {
            UtilP.LimpiarBingingsControl(this);
        }
        protected void BindearAuditoria()
        {
			if (BindeaAuditoria && _obj is IAuditable)
			{
				IAuditable auditable2 = _obj as IAuditable;
				this.ultraTabControl1.Tabs["Auditoria"].Visible = true;
				this.grillaBitacora.DataSource = auditable2.ObtenerLog();
				if (this.grillaBitacora.Rows.Count > 0)
				{
					UtilP.AutoAjustarColumnas(this.grillaBitacora);
					this.grillaBitacora.Rows[0].Selected = true;
					this.grillaBitacora.Rows[0].Activate();
				}
				txtCreadoEl.Value = auditable2.CreadoEl;
				comboCreadoPor.Value = auditable2.CreadoPor;
			}
			else
			{
				this.ultraTabControl1.Tabs["Auditoria"].Visible = false;
			}
        }
		protected virtual void Imprimir()
		{
			// En el ABM Base no hay logica de negocios para Imprimir
		}

        #region CONTROLADORES DE EVENTOS

		private void FormAbmBase_Load(object sender, System.EventArgs e)
		{
			if (this.DesignMode) { return; }

            this.controlesAExcluirProcesamientoSoloLectura.Add(this.btnExportarLog);
			BindearAuditoria();
			if (_obj != null)
			{
				_obj.Actualizar(true);
				_obj.CapturarSnapshot();
			}
			this.ultraTabControl1.VisibleTabs["Auditoria"].VisibleIndex = this.ultraTabControl1.Tabs.Count - 1;
			this.CalculadoraVisible = false;
		}
        protected virtual void FormAbmBase_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ASEGURARSE DE SACAR EL FOCO DEL CONTROL ACTUAL PARA QUE GUARDE LOS CAMBIOS
            this.GetNextControl(this, true).Focus();

            if (_soloLectura == false && _obj.HayCambios())
            {
                DialogResult resu = Mensaje.Pregunta(FormAbmBase.STR_CONFIRMACION_AL_SALIR, MessageBoxButtons.YesNoCancel);
                switch (resu)
                {
                    case DialogResult.Yes:
                        if (!this.GuardarCambios())
                        {
                            e.Cancel = true;
                        }
                        break;
                    case DialogResult.No:
                        try
                        {
                            _obj.Actualizar(true);
                        }
                        catch (Exception ex)
                        {
                            Mensaje.Error(ex.Message, ex);
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
        protected virtual void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Guardar":
                    if (this.GuardarCambios())
                    {
                        this.BindearAuditoria();
                        Mensaje.Informacion("Los cambios han sido guardados satisfactoriamente.");
                    }
                    break;
                case "GuardarYNuevo":
                    if (this.GuardarCambios())
                    {
                        this.CrearElemento();
                    }
                    break;
                case "GuardarYCerrar":
                    if (this.GuardarCambios())
                    {
                        this.Close();
                    }
                    break;
                case "Cerrar":
                    this.Close();
                    break;
                case "Imprimir":
                    this.Imprimir();
                    break;

                case "Calculadora":
                    UtilP.MostrarCalculadora();
                    break;
            }
        }
        private void grillaBitacora_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grillaBitacora.DisplayLayout.Override.CellAppearance.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grillaBitacora.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;

            UtilP.ConfigurarColumna(this.grillaBitacora, "Fecha", true, 0, "Fecha", 120, "dd/MM/yyyy HH:mm:ss");
            UtilP.ConfigurarColumna(this.grillaBitacora, "Usuario", true, 1, "Usuario", 80);
            UtilP.ConfigurarColumna(this.grillaBitacora, "Detalle", true, 2, "Detalle", 150);

            this.grillaBitacora.DisplayLayout.Bands[0].Columns["Fecha"].SortIndicator = SortIndicator.Descending;
        }
        private void grillaBitacora_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (e.RowArea == RowArea.Cell)
            {
                MostrarLog();
            }
        }
        private void btnExportarLog_Click(object sender, EventArgs e)
        {
            ExportarLog();
        }

        #endregion


	}
}



