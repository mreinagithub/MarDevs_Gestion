using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using Infragistics.Win.UltraWinToolbars;
using MarDevs.Gestion.Core;
using System.Collections.Generic;
using Infragistics.Win.UltraWinTabbedMdi;
using System.Data.SqlClient;
using System.Data;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.SupportDialogs.FilterUIProvider;

namespace MarDevs.Gestion.Win
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		
		#region Variables del Diseñador
		private Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager ultraTabbedMdiManager1;
		private Infragistics.Win.UltraWinDock.UltraDockManager ultraDockManager1;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _Form1UnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _Form1UnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _Form1UnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _Form1UnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.AutoHideControl _Form1AutoHideControl;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private PanelNavegacionUserControl panelNavegacionUserControl1;
		private Panel panel1;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea2;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		private ControlSeguimiento controlSeguimiento1;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
        private AutoUpdater autoUpdater1;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow7;
		#endregion

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedRight, new System.Guid("44847bda-29ba-4fae-8ebe-87f8eeb9230f"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("a19144ae-741d-4516-9ef3-ecc5b47c75bb"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("44847bda-29ba-4fae-8ebe-87f8eeb9230f"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("faf0ffc2-c20a-451e-bbd1-bd4cf8e2ea81"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("dea8c7eb-7006-4d8d-bf31-44ffe27fc519"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("faf0ffc2-c20a-451e-bbd1-bd4cf8e2ea81"), -1);
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MenuPrincipal");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupArchivo");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Herramientas");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupVentana");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Standard");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar3 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Navegador");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("NavegarAtras");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("NavegarAdelante");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupArchivo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Salir");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Salir");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Infragistics.Win.UltraWinToolbars.MdiWindowListTool mdiWindowListTool1 = new Infragistics.Win.UltraWinToolbars.MdiWindowListTool("MDIWindowListTool1");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool10 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupVentana");
            Infragistics.Win.UltraWinToolbars.MdiWindowListTool mdiWindowListTool2 = new Infragistics.Win.UltraWinToolbars.MdiWindowListTool("MDIWindowListTool1");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool11 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Herramientas");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CambioDePassword");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CambioDeUsuario");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ConfigFlag");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ConfigLocal");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Calculadora");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preferencias");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CambioDePassword");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CambioDeUsuario");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ConfigLocal");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ConfigFlag");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Calculadora");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool36 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AcercaDe");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool12 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("NavegarAtras");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool13 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("NavegarAdelante");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool14 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupPanelNavegacion");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool37 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AbrirEnNuevaVentana");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool38 = new Infragistics.Win.UltraWinToolbars.ButtonTool("VerDescripcionCarpeta");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool39 = new Infragistics.Win.UltraWinToolbars.ButtonTool("VerDescripcionCarpeta");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool40 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AbrirEnNuevaVentana");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool15 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupVer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool41 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preferencias");
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.controlSeguimiento1 = new MarDevs.Gestion.Win.ControlSeguimiento();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelNavegacionUserControl1 = new MarDevs.Gestion.Win.PanelNavegacionUserControl();
            this.ultraTabbedMdiManager1 = new Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(this.components);
            this.ultraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._Form1UnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._Form1UnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._Form1UnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._Form1UnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._Form1AutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.dockableWindow7 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this._Form1_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._Form1_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.windowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.autoUpdater1 = new MarDevs.Gestion.Win.AutoUpdater();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
            this._Form1AutoHideControl.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.dockableWindow7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).BeginInit();
            this.windowDockingArea2.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlSeguimiento1
            // 
            this.controlSeguimiento1.Location = new System.Drawing.Point(0, 18);
            this.controlSeguimiento1.Name = "controlSeguimiento1";
            this.controlSeguimiento1.Size = new System.Drawing.Size(264, 431);
            this.controlSeguimiento1.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panelNavegacionUserControl1);
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 431);
            this.panel1.TabIndex = 25;
            // 
            // panelNavegacionUserControl1
            // 
            this.panelNavegacionUserControl1.BackColor = System.Drawing.Color.Transparent;
            this.panelNavegacionUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNavegacionUserControl1.Location = new System.Drawing.Point(0, 0);
            this.panelNavegacionUserControl1.MDIParent = null;
            this.panelNavegacionUserControl1.Name = "panelNavegacionUserControl1";
            this.panelNavegacionUserControl1.NombreArchivo = "";
            this.panelNavegacionUserControl1.Size = new System.Drawing.Size(270, 431);
            this.panelNavegacionUserControl1.TabIndex = 18;
            this.panelNavegacionUserControl1.ComandoEjecutado += new MarDevs.Gestion.Win.ComandoEjecutadoEventHandler(this.panelNavegacionUserControl1_ComandoEjecutado);
            // 
            // ultraTabbedMdiManager1
            // 
            this.ultraTabbedMdiManager1.AllowNestedTabGroups = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabbedMdiManager1.MdiParent = this;
            this.ultraTabbedMdiManager1.TabGroupSettings.ShowTabListButton = Infragistics.Win.DefaultableBoolean.False;
            this.ultraTabbedMdiManager1.TabGroupSettings.TabAreaMargins.Bottom = 5;
            this.ultraTabbedMdiManager1.TabGroupSettings.TabAreaMargins.Left = 0;
            this.ultraTabbedMdiManager1.TabGroupSettings.TabAreaMargins.Right = 3;
            this.ultraTabbedMdiManager1.TabGroupSettings.TabAreaMargins.Top = 5;
            this.ultraTabbedMdiManager1.TabGroupSettings.TabPadding = new System.Drawing.Size(5, 5);
            this.ultraTabbedMdiManager1.TabGroupSettings.TabSizing = Infragistics.Win.UltraWinTabs.TabSizing.SizeToFit;
            appearance10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            appearance10.FontData.BoldAsString = "True";
            appearance10.FontData.SizeInPoints = 10F;
            appearance10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ultraTabbedMdiManager1.TabSettings.ActiveTabAppearance = appearance10;
            this.ultraTabbedMdiManager1.TabSettings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            this.ultraTabbedMdiManager1.TabSettings.DisplayFormIcon = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabbedMdiManager1.TabSettings.HotTrack = Infragistics.Win.DefaultableBoolean.True;
            appearance11.TextHAlignAsString = "Left";
            this.ultraTabbedMdiManager1.TabSettings.TabAppearance = appearance11;
            this.ultraTabbedMdiManager1.TabSettings.TabCloseAction = Infragistics.Win.UltraWinTabbedMdi.MdiTabCloseAction.Hide;
            this.ultraTabbedMdiManager1.ViewStyle = Infragistics.Win.UltraWinTabbedMdi.ViewStyle.Office2007;
            // 
            // ultraDockManager1
            // 
            this.ultraDockManager1.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.ultraDockManager1.AutoHideDelay = 250;
            dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.TabGroup;
            dockAreaPane1.DockedBefore = new System.Guid("faf0ffc2-c20a-451e-bbd1-bd4cf8e2ea81");
            dockableControlPane1.Control = this.controlSeguimiento1;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(264, -1);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(378, 145, 388, 258);
            dockableControlPane1.Pinned = false;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Seguimiento";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(287, 447);
            dockAreaPane2.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.TabGroup;
            dockableControlPane2.Control = this.panel1;
            dockableControlPane2.FlyoutSize = new System.Drawing.Size(242, -1);
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(555, 246, 200, 100);
            dockableControlPane2.Settings.CanDisplayAsMdiChild = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane2.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.None;
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "Panel de Navegación";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(270, 449);
            this.ultraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.ultraDockManager1.DragWindowStyle = Infragistics.Win.UltraWinDock.DragWindowStyle.LayeredWindow;
            this.ultraDockManager1.HostControl = this;
            this.ultraDockManager1.ShowCloseButton = false;
            this.ultraDockManager1.ShowDisabledButtons = false;
            this.ultraDockManager1.ShowMenuButton = Infragistics.Win.DefaultableBoolean.False;
            this.ultraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _Form1UnpinnedTabAreaLeft
            // 
            this._Form1UnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._Form1UnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Form1UnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 50);
            this._Form1UnpinnedTabAreaLeft.Name = "_Form1UnpinnedTabAreaLeft";
            this._Form1UnpinnedTabAreaLeft.Owner = this.ultraDockManager1;
            this._Form1UnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 449);
            this._Form1UnpinnedTabAreaLeft.TabIndex = 2;
            // 
            // _Form1UnpinnedTabAreaRight
            // 
            this._Form1UnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._Form1UnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Form1UnpinnedTabAreaRight.Location = new System.Drawing.Point(893, 50);
            this._Form1UnpinnedTabAreaRight.Name = "_Form1UnpinnedTabAreaRight";
            this._Form1UnpinnedTabAreaRight.Owner = this.ultraDockManager1;
            this._Form1UnpinnedTabAreaRight.Size = new System.Drawing.Size(21, 449);
            this._Form1UnpinnedTabAreaRight.TabIndex = 3;
            // 
            // _Form1UnpinnedTabAreaTop
            // 
            this._Form1UnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._Form1UnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Form1UnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 50);
            this._Form1UnpinnedTabAreaTop.Name = "_Form1UnpinnedTabAreaTop";
            this._Form1UnpinnedTabAreaTop.Owner = this.ultraDockManager1;
            this._Form1UnpinnedTabAreaTop.Size = new System.Drawing.Size(893, 0);
            this._Form1UnpinnedTabAreaTop.TabIndex = 4;
            // 
            // _Form1UnpinnedTabAreaBottom
            // 
            this._Form1UnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Form1UnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Form1UnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 499);
            this._Form1UnpinnedTabAreaBottom.Name = "_Form1UnpinnedTabAreaBottom";
            this._Form1UnpinnedTabAreaBottom.Owner = this.ultraDockManager1;
            this._Form1UnpinnedTabAreaBottom.Size = new System.Drawing.Size(893, 0);
            this._Form1UnpinnedTabAreaBottom.TabIndex = 5;
            // 
            // _Form1AutoHideControl
            // 
            this._Form1AutoHideControl.Controls.Add(this.dockableWindow1);
            this._Form1AutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Form1AutoHideControl.Location = new System.Drawing.Point(824, 50);
            this._Form1AutoHideControl.Name = "_Form1AutoHideControl";
            this._Form1AutoHideControl.Owner = this.ultraDockManager1;
            this._Form1AutoHideControl.Size = new System.Drawing.Size(69, 449);
            this._Form1AutoHideControl.TabIndex = 6;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.controlSeguimiento1);
            this.dockableWindow1.Location = new System.Drawing.Point(-10000, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.ultraDockManager1;
            this.dockableWindow1.Size = new System.Drawing.Size(264, 449);
            this.dockableWindow1.TabIndex = 31;
            // 
            // dockableWindow7
            // 
            this.dockableWindow7.Controls.Add(this.panel1);
            this.dockableWindow7.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow7.Name = "dockableWindow7";
            this.dockableWindow7.Owner = this.ultraDockManager1;
            this.dockableWindow7.Size = new System.Drawing.Size(270, 449);
            this.dockableWindow7.TabIndex = 32;
            // 
            // _Form1_Toolbars_Dock_Area_Left
            // 
            this._Form1_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Form1_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 50);
            this._Form1_Toolbars_Dock_Area_Left.Name = "_Form1_Toolbars_Dock_Area_Left";
            this._Form1_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 449);
            this._Form1_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingSize = new System.Drawing.Size(278, 20);
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool3});
            ultraToolbar1.Text = "MenuPrincipal";
            ultraToolbar2.DockedColumn = 1;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Text = "Standard";
            ultraToolbar3.DockedColumn = 0;
            ultraToolbar3.DockedRow = 1;
            ultraToolbar3.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool5,
            popupMenuTool6});
            ultraToolbar3.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar3.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar3.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar3.Text = "Navegador";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2,
            ultraToolbar3});
            popupMenuTool7.SharedPropsInternal.Caption = "Archivo";
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            popupMenuTool7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance1;
            buttonTool2.SharedPropsInternal.Caption = "Salir";
            buttonTool2.SharedPropsInternal.MergeOrder = 99;
            mdiWindowListTool1.SharedPropsInternal.Caption = "MDIWindowListTool1";
            popupMenuTool10.SharedPropsInternal.Caption = "Ventana";
            popupMenuTool10.SharedPropsInternal.MergeOrder = 99;
            popupMenuTool10.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            mdiWindowListTool2});
            popupMenuTool11.SharedPropsInternal.Caption = "Herramientas";
            popupMenuTool11.SharedPropsInternal.MergeOrder = 98;
            buttonTool17.InstanceProps.IsFirstInGroup = true;
            buttonTool19.InstanceProps.IsFirstInGroup = true;
            buttonTool24.InstanceProps.IsFirstInGroup = true;
            buttonTool25.InstanceProps.IsFirstInGroup = true;
            popupMenuTool11.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool17,
            buttonTool18,
            buttonTool19,
            buttonTool20,
            buttonTool24,
            buttonTool25});
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            buttonTool26.SharedPropsInternal.AppearancesSmall.Appearance = appearance2;
            buttonTool26.SharedPropsInternal.Caption = "Cambiar la Contraseña";
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            buttonTool27.SharedPropsInternal.AppearancesSmall.Appearance = appearance3;
            buttonTool27.SharedPropsInternal.Caption = "Cambiar de Usuario";
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            buttonTool28.SharedPropsInternal.AppearancesSmall.Appearance = appearance4;
            buttonTool28.SharedPropsInternal.Caption = "Configuración de la Conexión a la Base de datos";
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            buttonTool29.SharedPropsInternal.AppearancesSmall.Appearance = appearance5;
            buttonTool29.SharedPropsInternal.Caption = "Configuración de Parámetros";
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            buttonTool31.SharedPropsInternal.AppearancesSmall.Appearance = appearance6;
            buttonTool31.SharedPropsInternal.Caption = "Calculadora";
            buttonTool31.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.F2;
            buttonTool36.SharedPropsInternal.Caption = "Acerca de...";
            popupMenuTool12.DropDownArrowStyle = Infragistics.Win.UltraWinToolbars.DropDownArrowStyle.Segmented;
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            popupMenuTool12.SharedPropsInternal.AppearancesSmall.Appearance = appearance7;
            popupMenuTool12.SharedPropsInternal.Caption = "Atrás";
            popupMenuTool13.DropDownArrowStyle = Infragistics.Win.UltraWinToolbars.DropDownArrowStyle.Segmented;
            appearance8.Image = ((object)(resources.GetObject("appearance8.Image")));
            popupMenuTool13.SharedPropsInternal.AppearancesSmall.Appearance = appearance8;
            popupMenuTool13.SharedPropsInternal.Caption = "Adelante";
            popupMenuTool14.SharedPropsInternal.Caption = "PopupPanelNavegacion";
            popupMenuTool14.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool37,
            buttonTool38});
            buttonTool39.SharedPropsInternal.Caption = "Propiedades";
            buttonTool40.SharedPropsInternal.Caption = "Abri en una nueva ventana";
            popupMenuTool15.SharedPropsInternal.Caption = "Ver";
            buttonTool41.SharedPropsInternal.Caption = "Preferencias...";
            buttonTool41.SharedPropsInternal.MergeOrder = 99;
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool7,
            buttonTool2,
            mdiWindowListTool1,
            popupMenuTool10,
            popupMenuTool11,
            buttonTool26,
            buttonTool27,
            buttonTool28,
            buttonTool29,
            buttonTool31,
            buttonTool36,
            popupMenuTool12,
            popupMenuTool13,
            popupMenuTool14,
            buttonTool39,
            buttonTool40,
            popupMenuTool15,
            buttonTool41});
            // 
            // _Form1_Toolbars_Dock_Area_Right
            // 
            this._Form1_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Form1_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(914, 50);
            this._Form1_Toolbars_Dock_Area_Right.Name = "_Form1_Toolbars_Dock_Area_Right";
            this._Form1_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 449);
            this._Form1_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Form1_Toolbars_Dock_Area_Top
            // 
            this._Form1_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Form1_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Form1_Toolbars_Dock_Area_Top.Name = "_Form1_Toolbars_Dock_Area_Top";
            this._Form1_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(914, 50);
            this._Form1_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Form1_Toolbars_Dock_Area_Bottom
            // 
            this._Form1_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Form1_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 499);
            this._Form1_Toolbars_Dock_Area_Bottom.Name = "_Form1_Toolbars_Dock_Area_Bottom";
            this._Form1_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(914, 0);
            this._Form1_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 499);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            ultraStatusPanel1.Key = "Status";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            appearance9.TextHAlignAsString = "Right";
            ultraStatusPanel2.Appearance = appearance9;
            ultraStatusPanel2.Key = "PanelDerecho";
            ultraStatusPanel2.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel2.Width = 250;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2});
            this.ultraStatusBar1.Size = new System.Drawing.Size(914, 23);
            this.ultraStatusBar1.TabIndex = 16;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Right;
            this.windowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea1.Location = new System.Drawing.Point(0, 77);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.ultraDockManager1;
            this.windowDockingArea1.Size = new System.Drawing.Size(292, 447);
            this.windowDockingArea1.TabIndex = 25;
            // 
            // windowDockingArea2
            // 
            this.windowDockingArea2.Controls.Add(this.dockableWindow7);
            this.windowDockingArea2.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea2.Location = new System.Drawing.Point(0, 50);
            this.windowDockingArea2.Name = "windowDockingArea2";
            this.windowDockingArea2.Owner = this.ultraDockManager1;
            this.windowDockingArea2.Size = new System.Drawing.Size(275, 449);
            this.windowDockingArea2.TabIndex = 19;
            // 
            // autoUpdater1
            // 
            this.autoUpdater1.ConfigURL = null;
            this.autoUpdater1.EjecutarBackground = false;
            this.autoUpdater1.LatestConfigChanges = null;
            this.autoUpdater1.LoginUserName = null;
            this.autoUpdater1.LoginUserPass = null;
            this.autoUpdater1.ProxyURL = null;
            this.autoUpdater1.RestartForm = null;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(914, 522);
            this.Controls.Add(this._Form1AutoHideControl);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this.windowDockingArea2);
            this.Controls.Add(this._Form1UnpinnedTabAreaTop);
            this.Controls.Add(this._Form1UnpinnedTabAreaBottom);
            this.Controls.Add(this._Form1UnpinnedTabAreaLeft);
            this.Controls.Add(this._Form1UnpinnedTabAreaRight);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppName";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
            this._Form1AutoHideControl.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.dockableWindow7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).EndInit();
            this.windowDockingArea2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region CONSTRUCTOR Y DISPOSE

		public Form1()
		{
			Cronometro.Iniciar();

			//formulario de splash
			Splash.NombreAplicacion = App.NombreInstalacion;
			Splash.Version = "Versión " + Application.ProductVersion;
			Splash.Mostrar();
			
			Splash.EstadoCarga = "Inicializando formulario...";
			InitializeComponent();

			this.ultraToolbarsManager1.BeforeToolDropdown += new BeforeToolDropdownEventHandler(ultraToolbarsManager1_BeforeToolDropdown);
			this.ultraToolbarsManager1.ToolClick +=new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(ultraToolbarsManager1_ToolClick);
			this.MdiChildActivate +=new EventHandler(Form1_MdiChildActivate);
			this.Closing+=new CancelEventHandler(Form1_Closing);
			this.Shown += new EventHandler(Form1_Shown);
			this.ultraDockManager1.BeforeShowFlyout+=new Infragistics.Win.UltraWinDock.CancelableControlPaneEventHandler(ultraDockManager1_BeforeShowFlyout);

			#region COMPROBAR ACTUALIZACIONES

			Splash.EstadoCarga = "Verificando actualizaciones disponibles...";

			//setear URL para el archivo de actualizacion
            Flags flags = FlagsFactory.ObtenerInstancia<Flags>();
			bool updaterHabilitado = flags.UpdaterHabilitado;
			string updaterURL = flags.UpdaterURL;

			if( updaterHabilitado && !String.IsNullOrEmpty(updaterURL))
			{
				this.autoUpdater1.ConfigURL = updaterURL;
				if (this.autoUpdater1.HayNuevaVersion())
				{
					Splash.EstadoCarga = "Descargando actualizaciones...";
					this.EstablecerTextoStatusBarPanelDerecho("Descargando actualizaciones...");
					this.autoUpdater1.AutoRestart = false;
					this.autoUpdater1.RestartForm = new FormConfirmarDescarga();
					this.autoUpdater1.EjecutarBackground = true;
					this.autoUpdater1.IntentarUpdate();
				}
			}
			#endregion
		}
        		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#endregion

        #region VARIABLES PRIVADAS

		private static string MENSAJE_HAY_QUE_CAMBIAR_USUARIO = "Se ha cambiado la conexion a la Base de Datos, debe Cambiar de Usuario.";
		private bool _formInvalidado = false;
		private int _maximaHistoria = 10;
		private List<FormMDIBase> _historia = new List<FormMDIBase>(10);
		private int _posicion = -1;
		private Timer _notifyTimer = new Timer();
		private Timer _updateTimer = new Timer();
		private bool _multiFormulario = true;

	    #endregion
        
        private void Form1_Load(object sender, System.EventArgs e)
		{
			try
			{
				Config config = ConfigBL.ObtenerConfiguracion() as Config;
				//verificar si hay nueva version y, de haberla, actualizar XML y loguear en BD
				string versionEnsamblado = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
				string versionXML = config.VersionReportada;
				if (versionXML == null || versionXML != versionEnsamblado)
				{
					try
					{
						App.RegistrarActualizacion();
					}
					catch
					{ }
				}
				TraducirStringsInfragistics();
				Splash.EstadoCarga = "Inicializando listas...";
				InicializarListas();
				Splash.EstadoCarga = "Creando menú principal...";
				//REGISTRAR RECURSOS
				Recursos.AgregarEnsamblado(Assembly.GetEntryAssembly(), "MarDevs.Gestion.Win.Properties.Resources");
				Assembly ass = Assembly.GetAssembly(typeof(MarDevs.Gestion.Win.FormLogin));
				Recursos.AgregarEnsamblado(ass, "MarDevs.Gestion.Win.Properties.Resources");
				//CREAR MENU PRINCIPAL Y PANEL DE NAVEGACION.				
				CrearMenuPrincipal();
				SetearTituloAplicacion();
				EstablecerModoMDI(MarDevs.Gestion.Win.Properties.Settings.Default.MultiVentana);
				CachearMenuFiltrosTextoGrilla();
				Splash.Cerrar(false);
				this.WindowState = (MarDevs.Gestion.Win.Properties.Settings.Default.AppMaximizada == true) ? FormWindowState.Maximized : FormWindowState.Normal;
				//SUSCRIPCION AL EVENTO DE CAMBIO DE HORA PARA RESINCRONIZAR CON EL SERVER
				Microsoft.Win32.SystemEvents.TimeChanged += new EventHandler(SystemEvents_TimeChanged);
				//TIMER DE NOTIFICACIONES
				this._notifyTimer.Interval = 180000; //3 minutos
				this._notifyTimer.Tick += new EventHandler(notifyTimer_Tick);

                Flags flags = FlagsFactory.ObtenerInstancia<Flags>();
				int frecuenciaActualizaciones = (flags != null) ? flags.FrecuenciaBusquedaActualizaciones : 60;
				if (frecuenciaActualizaciones < 1)
				{
					this._updateTimer.Enabled = false;
				}
				else
				{

					this._updateTimer.Interval = (frecuenciaActualizaciones * 60000); //lo convierto a milisegundos.
					this._updateTimer.Tick += new EventHandler(updateTimer_Tick);
					this._updateTimer.Start();
				}
				
				Cronometro.Detener();

			}
			catch (Exception ex)
			{
				string texto = "Al intentar iniciar la aplicación, se ha producido el siguiente error:" + Environment.NewLine + Environment.NewLine;
				Mensaje.Error(texto + ex.Message, ex);
			}
		}
				
		private void Form1_Shown(object sender, EventArgs e)
		{
			this._notifyTimer.Start();
			//forzar ejecucion la primera vez.
			this.notifyTimer_Tick(null, new EventArgs());
		}

		private void Form1_Closing(object sender, CancelEventArgs e)
		{
			if( Mensaje.Pregunta("¿Está seguro que desea salir de la aplicación?") == DialogResult.No )
				e.Cancel = true;
			try
			{
				GuardarConfig();
			}
			catch { }
		}

		private void CachearMenuFiltrosTextoGrilla()
		{
			try
			{
				DataTable dt = new DataTable("muleto");
				dt.Columns.Add("Columna", typeof(String));
				DataRow dr = dt.NewRow();
				dr[0] = "hola";
				dt.Rows.Add(dr);

				FormMuletoGrilla f = new FormMuletoGrilla();
				//f.Width = 10;
				//f.Height = 10;
				f.StartPosition = FormStartPosition.CenterScreen;
				f.ultraGrid1.DataSource = dt;
			}
			catch (Exception ex)
			{
				AdministradorDeExcepciones.Publicar(ex);
			}
		}
		private void grilla_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			UltraGridFilterUIProvider provider = new UltraGridFilterUIProvider(this.components);
			e.Layout.Override.FilterUIProvider = provider;
			e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
			provider.AfterMenuPopulate += provider_AfterMenuPopulate;
			provider.Show(e.Layout.Bands[0].ColumnFilters[0], null, Rectangle.Empty, null);
			provider.Close(false);
		}
		private void provider_AfterMenuPopulate(object sender, AfterMenuPopulateEventArgs e)
		{
			// CACHEAR FILTROS DE TEXTO
			if (FormListaBase._filtrosTexto == null && e.ColumnFilter.Column.DataType.Name == "String")
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

		private void TraducirStringsInfragistics()
		{
			Infragistics.Shared.ResourceCustomizer rc = Infragistics.Win.UltraWinToolbars.Resources.Customizer;
			rc.SetCustomizedString("MdiCommandCloseWindows","Cerrar todas las ventanas");
			
			rc = Infragistics.Win.UltraWinGrid.Resources.Customizer;
			rc.SetCustomizedString("RowFilterDropDownAllItem","(Todas)");
			rc.SetCustomizedString("RowFilterDropDownBlanksItem","(Vacías)");
			rc.SetCustomizedString("RowFilterDropDownCustomItem","(Personalizar...)");
			rc.SetCustomizedString("RowFilterDropDownNonBlanksItem","(No Vacías)");
			rc.SetCustomizedString("RowFilterDialogBlanksItem", "(Vacías)");
			rc.SetCustomizedString("RowFilterDialogDBNullItem", "(Nulas)");
			rc.SetCustomizedString("RowFilterDialogEmptyTextItem", "(Texto Vacío)");
			rc.SetCustomizedString("RowFilterDialogOperandHeaderCaption", "Operando");
			rc.SetCustomizedString("RowFilterDialogOperatorHeaderCaption", "Operador");
			rc.SetCustomizedString("RowFilterDialogTitlePrefix", "Ingrese criterio de filtro");
			rc.SetCustomizedString("RowFilterDropDownEquals", "Es igual a");
			rc.SetCustomizedString("RowFilterDropDownGreaterThan", "Mayor que");
			rc.SetCustomizedString("RowFilterDropDownGreaterThanOrEqualTo", "Mayor o igual que");
			rc.SetCustomizedString("RowFilterDropDownLessThan", "Menor que");
			rc.SetCustomizedString("RowFilterDropDownLessThanOrEqualTo", "Menor o igual que");
			rc.SetCustomizedString("RowFilterDropDownLike", "Como");
			rc.SetCustomizedString("RowFilterDropDownMatch", "Coincide con expresión regular");
			rc.SetCustomizedString("RowFilterDropDownNotEquals", "No es igual a");

            rc.SetCustomizedString("RowFilterDropDown_Operator_Contains", "Contiene");
            rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotContain", "No contiene");
            rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotEndWith", "No termina en");
            rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotMatch", "No coincide con");
            rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotStartWith", "No comienza por");
            rc.SetCustomizedString("RowFilterDropDown_Operator_EndsWith", "Termina en");
            rc.SetCustomizedString("RowFilterDropDown_Operator_NotLike", "No como");
            rc.SetCustomizedString("RowFilterDropDown_Operator_StartsWith", "Comienza por");

			rc.SetCustomizedString("RowFilterRegexError", "Error procesando expresión regular {0}. Por favor, ingrese una expresión válida.");
			rc.SetCustomizedString("RowFilterRegexErrorCaption", "Expresión regular inválida");
			rc.SetCustomizedString("FilterDialogAddConditionButtonText", "&Agregar una Condición");
			rc.SetCustomizedString("FilterDialogAndRadioText", "Condiciones Y");
			rc.SetCustomizedString("FilterDialogCancelButtonText", "&Cancelar");
			rc.SetCustomizedString("FilterDialogDeleteButtonText", "Borrar Condición");
			rc.SetCustomizedString("FilterDialogOkButtonNoFiltersText", "&Sin filtros");
			rc.SetCustomizedString("FilterDialogOkButtonText", "&OK");
			rc.SetCustomizedString("FilterDialogOrRadioText", "Condiciones O");

			rc.SetCustomizedString("FilterDialogAllComboItem", "Todas");
			rc.SetCustomizedString("FilterDialogAnyComboItem", "Cualquiera");
			rc.SetCustomizedString("FilterDialogApplyLabelText", "Filtro basado en {0} de las siguientes condiciones:");
			rc.SetCustomizedString("FilterDialogCancelButtonText", "Cancelar");
			rc.SetCustomizedString("FilterDialogConditionAddButtonText", "Agregar");
			rc.SetCustomizedString("FilterDialogConditionDeleteButtonText", "Eliminar");
			rc.SetCustomizedString("FilterDialogDeleteButton_AccessibleDescription", "Eliminar la condición seleccionada");
			rc.SetCustomizedString("FilterDialogOkButtonNoFiltersText", "Sin Filtros");
			rc.SetCustomizedString("FilterDialogOkButtonText", "Ok");

			rc.SetCustomizedString("SummaryTypeSum","");
			rc.SetCustomizedString("ColumnChooserButtonToolTip", "Clic aquí para personalizar la nombreVista actual.");
			rc.SetCustomizedString("FilterClearButtonToolTip_RowSelector", "Clic aquí para remover todos los filtros.");
			rc.SetCustomizedString("FilterClearButtonToolTip_FilterCell", "Clic aquí para remover filtro para {0}.");

			rc.SetCustomizedString("Outlook_GroupByMode_Description_BeyondNextMonth", "Mas allá del mes próximo");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_EarlierThisMonth", "A comienzos de este mes");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_LastMonth", "El mes pasado");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_LastWeek", "La semana pasada");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_LaterThisMonth", "A fines de este mes");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_NextMonth", "El próximo mes");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_NextWeek", "La semana próxima");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_None", "Ninguno");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_Older", "Antiguo");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_Today", "Hoy");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_TwoWeeksAgo", "Hace 2 semanas");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_TwoWeeksAway", "Dentro de 2 semanas");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_Yesterday", "Ayer");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_ThreeWeeksAgo", "Hace 3 semanas");
			rc.SetCustomizedString("Outlook_GroupByMode_Description_ThreeWeeksAway", "Dentro de 3 semanas");

			rc.SetCustomizedString("FilterDialogTitle", "Filtro Personalizado");
			rc.SetCustomizedString("SpecialFilterOperand_January", "Enero");
			rc.SetCustomizedString("SpecialFilterOperand_February", "Febrero");
			rc.SetCustomizedString("SpecialFilterOperand_March", "Marzo");
			rc.SetCustomizedString("SpecialFilterOperand_April", "Abril");
			rc.SetCustomizedString("SpecialFilterOperand_May", "Mayo");
			rc.SetCustomizedString("SpecialFilterOperand_June", "Junio");
			rc.SetCustomizedString("SpecialFilterOperand_July", "Julio");
			rc.SetCustomizedString("SpecialFilterOperand_August", "Agosto");
			rc.SetCustomizedString("SpecialFilterOperand_September", "Septiembre");
			rc.SetCustomizedString("SpecialFilterOperand_October", "Octubre");
			rc.SetCustomizedString("SpecialFilterOperand_November", "Noviembre");
			rc.SetCustomizedString("SpecialFilterOperand_December", "Diciembre");

			rc.SetCustomizedString("SpecialFilterOperand_LastMonth", "Mes Anterior");
			rc.SetCustomizedString("SpecialFilterOperand_LastQuarter", "Ultimo Trimestre");
			rc.SetCustomizedString("SpecialFilterOperand_LastWeek", "Semana Anterior");
			rc.SetCustomizedString("SpecialFilterOperand_LastYear", "Año Anterior");
			rc.SetCustomizedString("SpecialFilterOperand_NextMonth", "Mes Próximo");
			rc.SetCustomizedString("SpecialFilterOperand_NextQuarter", "Próximo Trimestre");
			rc.SetCustomizedString("SpecialFilterOperand_NextWeek", "Próxima Semana");
			rc.SetCustomizedString("SpecialFilterOperand_NextYear", "Año Próximo");
			rc.SetCustomizedString("SpecialFilterOperand_Quarter1", "Trimestre 1");
			rc.SetCustomizedString("SpecialFilterOperand_Quarter2", "Trimestre 2");
			rc.SetCustomizedString("SpecialFilterOperand_Quarter3", "Trimestre 3");
			rc.SetCustomizedString("SpecialFilterOperand_Quarter4", "Trimestre 4");
			rc.SetCustomizedString("SpecialFilterOperand_ThisMonth", "Este Mes");
			rc.SetCustomizedString("SpecialFilterOperand_ThisQuarter", "Este Trimestre");
			rc.SetCustomizedString("SpecialFilterOperand_ThisWeek", "Esta Semana");
			rc.SetCustomizedString("SpecialFilterOperand_ThisYear", "Este Año");
			rc.SetCustomizedString("SpecialFilterOperand_Today", "Hoy");
			rc.SetCustomizedString("SpecialFilterOperand_Tomorrow", "Mañana");
			rc.SetCustomizedString("SpecialFilterOperand_YearToDate", "Acumulado Año");
			rc.SetCustomizedString("SpecialFilterOperand_Yesterday", "Ayer");
			rc.SetCustomizedString("RowFilterDropDownCustomItem", "Personalizado");

			rc = Infragistics.Win.SupportDialogs.Resources.Customizer;
			rc.SetCustomizedString("UltraGridFilterUIProvider_AfterOperand", "Después de...");
			rc.SetCustomizedString("UltraGridFilterUIProvider_AllDatesInPeriod_Menu", "Todas las fechas en el Período");
			rc.SetCustomizedString("UltraGridFilterUIProvider_BeforeOperand", "Antes de...");
			rc.SetCustomizedString("UltraGridFilterUIProvider_BeginsWithOperand", "Comienza Con…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_BetweenOperand", "Entre…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_ContainsOperand", "Contiene…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_CustomFilter", "Filtro Personalizado…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_DoesNotContainOperand", "No Contiene…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_DoesNotEqualOperand", "No es Igual a…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_EndsWithOperand", "Termina Con…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_EqualsOperand", "Es Igual a…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_GreaterThanOperand", "Mayor a…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_GreaterThanOrEqualToOperand", "Mayor o Igual a…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_LessThanOperand", "Menor a…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_LessThanOrEqualToOperand", "Menor o Igual a…");
			rc.SetCustomizedString("UltraGridFilterUIProvider_P_About", "Muestra la pantalla Acerca De…");
			rc.SetCustomizedString("FilterUIProvider_CancelButton", "Cancelar");
			rc.SetCustomizedString("FilterUIProvider_Menu_ClearFilter", "Borrar Filtro");
			rc.SetCustomizedString("FilterUIProvider_Menu_CustomFilters", "Filtros Personalizados");
			rc.SetCustomizedString("FilterUIProvider_Menu_DateFilters", "Filtros de Fecha");
			rc.SetCustomizedString("FilterUIProvider_Menu_NumberFilters", "Filtros Numéricos");
			rc.SetCustomizedString("FilterUIProvider_Menu_TextFilters", "Filtros de Texto");
			rc.SetCustomizedString("FilterUIProvider_OKButton", "OK");

            rc = Infragistics.Win.UltraWinDock.Resources.Customizer;
            rc.SetCustomizedString("PaneButtonToolTipPin", "Ocultar Automáticamente");
			rc.SetCustomizedString("ContextMenuAutoHide", "Ocultar Automáticamente");
			rc.SetCustomizedString("ContextMenuDockable", "Acoplable");
			rc.SetCustomizedString("ContextMenuFloating", "Flotante");
			rc.SetCustomizedString("ContextMenuHide", "Ocultar");
			rc.SetCustomizedString("PaneButtonToolTipClose", "Cerrar");
			rc.SetCustomizedString("PaneButtonToolTipMaximize", "Maximizar");
			rc.SetCustomizedString("PaneButtonToolTipMinimize", "Minimizar");
			rc.SetCustomizedString("PaneButtonToolTipUnpin", "Ocultar Automáticamente");

            rc = Infragistics.Win.UltraWinExplorerBar.Resources.Customizer;
            rc.SetCustomizedString("NavigationContextMenu_NavigationPaneOptions", "Opciones del Panel de Navegación");
            rc.SetCustomizedString("NavigationPaneOptionsDialog_Caption", "Opciones del Panel de Navegación");
            rc.SetCustomizedString("NavigationPaneOptionsDialog_MoveDownButton", "Mover abajo");
            rc.SetCustomizedString("NavigationPaneOptionsDialog_MoveUpButton", "Mover arriba");
            rc.SetCustomizedString("NavigationQuickCustomizeButton_Tooltip", "Configurar botones");
            rc.SetCustomizedString("NavigationQuickCustomizeMenu_ShowFewerButtons", "Mostrar menos botones");
            rc.SetCustomizedString("NavigationQuickCustomizeMenu_ShowMoreButtons", "Mostrar más botones");

			rc = Infragistics.Win.UltraWinTabbedMdi.Resources.Customizer;
			rc.SetCustomizedString("MenuItemClose", "Cerrar");
			rc.SetCustomizedString("MenuItemMoveToNextGroup", "Mover al próximo grupo");
			rc.SetCustomizedString("MenuItemMoveToPreviousGroup", "Mover al grupo anterior");
			rc.SetCustomizedString("MenuItemNewHorizontalGroup", "Nuevo grupo Horizontal");
			rc.SetCustomizedString("MenuItemNewVerticalGroup", "Nuevo grupo Vertical");
		}
		private void InicializarListas()
		{
			Cronometro.Iniciar("INICIALIZACION_LISTAS");

			Usuario.LimpiarCache();			
			FlagsFactory.LimpiarCache();
			Usuario.Listar(true);
			//UtilP.ValueListLimpiar();

			Cronometro.Detener("INICIALIZACION_LISTAS");
		}
		private void CrearMenuPrincipal()
		{
			Cronometro.Iniciar("CREAR_MENU_PRINCIPAL");

			InicializarHistoriaNavegacion();

			this.ultraToolbarsManager1.Tools["ConfigFlag"].SharedProps.Enabled = ConfigBL.ticket.VerificarPrivilegio(PRV.FLAGS_VER );
            this.ultraToolbarsManager1.Tools["ConfigLocal"].SharedProps.Enabled = ConfigBL.ticket.VerificarPrivilegio(PRV.CONFIGURACION_DB_VER);

			PanelNavegacion panel = PanelNavegacion.ObtenerDesdeRecursoIncrustado("panel-navegacion.xml, Gestion");

			#region VISTAS PERSONALIZADAS DE PEDIDO REPUESTOS

			//GrupoMenu grupo = panel.ObtenerGrupo("PedidoRepuestos");

			////Agrego el formulario de creacion de pedidos
			//Comando comando = new Comando();
			//comando.Key = "NuevoPedidoRepuesto";
			//comando.Nombre = "Nuevo pedido";
			//comando.Imagen = "ImagenFormulario";
			//comando.Accion = TipoComando.AbrirModal;
			//comando.Target = "MarDevs.Gestion.Win.FormPedidoRepuesto, OC";
			//comando.Privilegio = PRV.PEDIDO_REPUESTO_CREAR_MODIFICAR;//1200;
			//comando.Alcance = Alcances.Total;
			//comando.Parametros.Add(new ParametroComando(typeof(ModalidadPedido), ModalidadPedido.Fabrica));
			//grupo.Opciones.Add(comando);

			////Nueva Orden de Compra
			//comando = new Comando();
			//comando.Key = "NuevaOrdenDeCompra";
			//comando.Nombre = "Nueva Orden de Compra";
			//comando.Imagen = "ImagenFormulario";
			//comando.Accion = TipoComando.AbrirModal;
			//comando.Target = "MarDevs.Gestion.Win.FormPedidoRepuesto, OC";
			//comando.Privilegio = PRV.PEDIDO_REPUESTO_CREAR_MODIFICAR;//1200;
			//comando.Alcance = Alcances.Total;
			//comando.Parametros.Add(new ParametroComando(typeof(ModalidadPedido), ModalidadPedido.OrdenCompra));
			//grupo.Opciones.Add(comando);

			//// Agrego las vistas al árbol.
			//DataTable vistas = VistaPersonalizada.ListarActivosPorEntidadyUsuario(typeof(PedidoRepuesto ).Name, ConfigBL.ticket.Usuario);
			//foreach (DataRow dr in vistas.Rows)
			//{
			//	comando = new Comando();
			//	comando.Key = "VP_PEDREP_" + dr["ID"].ToString();
			//	comando.Nombre = dr["Nombre"].ToString();
			//	comando.Descripcion = dr["Descripcion"].ToString();
			//	comando.Imagen = String.IsNullOrEmpty(dr["ImagenCarpeta"].ToString()) ? "ImagenCarpeta" : dr["ImagenCarpeta"].ToString();
			//	comando.Target = "MarDevs.Gestion.Win.FormListaPedidoRepuesto, OC";
			//	comando.Parametros.Add(new ParametroComando(typeof(int), Convert.ToInt32(dr["ID"].ToString())));

			//	if (!String.IsNullOrEmpty(dr["Ruta"].ToString())) // TIENE RUTA ESPECÍFICADA
			//	{
			//		GrupoMenu subGrupoFinal = GrupoMenu.ObtenerGrupo(grupo, dr["Ruta"].ToString(), true);
			//		if (subGrupoFinal != null)
			//			subGrupoFinal.Opciones.Add(comando);
			//	}
			//	else // ES RAÍZ
			//		grupo.Opciones.Add(comando);
			//}

			#endregion 

            this.panelNavegacionUserControl1.Inicializar(panel);
			this.controlSeguimiento1.Actualizar();

			Cronometro.Detener("CREAR_MENU_PRINCIPAL");
		}
		private void SetearTituloAplicacion()
		{
			string version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString(),
					usuario = ConfigBL.ticket.UsuarioLogon;
					

			this.Text = String.Format("{0} v{1} ({2})", App.NombreInstalacion, version, usuario);
		}
		private void ProcesarSeleccion(string key)
		{
			if( _formInvalidado && key != "CambioDeUsuario" && key != "Salir")
			{
				Mensaje.Informacion(MENSAJE_HAY_QUE_CAMBIAR_USUARIO);
				return;
			}
			switch (key)
			{
				#region Opciones Generales (Menúes y Toolbars)
				
				case "Preferencias":
					MostrarPreferencias();
					break;

				case "CambioDePassword":
					FormCambioDePassword fCambioPassword = new FormCambioDePassword(ConfigBL.ticket.Usuario);
					fCambioPassword.ShowDialog();
					break;

				case "ConfigLocal":
					string viejoConnStr = ConfigBL.StringDeConexion;
					string nuevoConnStr = String.Empty;

                    Config config = ConfigBL.ObtenerConfiguracion();

					FormConfigLocal fConfigLocal = new FormConfigLocal(config);
					if( fConfigLocal.ShowDialog() == DialogResult.OK )
					{
						nuevoConnStr = ConfigBL.StringDeConexion;
						if( !nuevoConnStr.Equals(viejoConnStr) )
						{
							this._formInvalidado = true;
							this.InicializarHistoriaNavegacion();
							this.CambiarDeUsuario();                            
							//ESTABLECER EL NOMBRE DE LA INSTALACION
                            Flags flags = FlagsFactory.ObtenerInstancia<Flags>();
							App.NombreInstalacion = (flags != null) ? flags.NombreInstalacion : Application.ProductName;
							SetearTituloAplicacion();
						}
					}
					break;

				case "ConfigFlag":

                    FormParametro formEditorFlags = new FormParametro();
					//FormEditorFlags formEditorFlags = new FormEditorFlags();
					formEditorFlags.ShowDialog();
					break;

				case "CambioDeUsuario":
					this.CambiarDeUsuario();
					break;

				case "Calculadora":
					UtilP.MostrarCalculadora();
					break;

				case "NavegarAtras":
					this.NavegarAtras();
					break;

				case "NavegarAdelante":
					this.NavegarAdelante();
					break;

				case "Salir":
					this.Close();
					break;
					#endregion

			}
		}
	
		private void MostrarPreferencias()
		{
			FormPreferencias formPreferencias = new FormPreferencias();
			formPreferencias.ShowDialog();
			//VER SI CAMBIÓ EL MODO MDI
			if (MarDevs.Gestion.Win.Properties.Settings.Default.MultiVentana != _multiFormulario)
				EstablecerModoMDI(MarDevs.Gestion.Win.Properties.Settings.Default.MultiVentana);
		}
		private void EstablecerModoMDI(bool multipantalla)
		{
			_multiFormulario = multipantalla;
			InicializarHistoriaNavegacion();
            ultraTabbedMdiManager1.TabSettings.AllowClose = multipantalla ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
            ultraTabbedMdiManager1.TabSettings.TabCloseAction = multipantalla ? MdiTabCloseAction.Close : MdiTabCloseAction.Hide;
            ultraToolbarsManager1.Toolbars["Navegador"].Visible = !multipantalla;
            ultraToolbarsManager1.Tools["AbrirEnNuevaVentana"].SharedProps.Visible = multipantalla;
            ultraToolbarsManager1.Tools["PopupVentana"].SharedProps.Visible = multipantalla;
		}
		private void GuardarConfig()
		{
			MarDevs.Gestion.Win.Properties.Settings.Default.UltimoUsuarioLogueado = ConfigBL.ticket.Usuario.Logon;
			MarDevs.Gestion.Win.Properties.Settings.Default.MultiVentana = _multiFormulario;
			MarDevs.Gestion.Win.Properties.Settings.Default.AppMaximizada = (this.WindowState == FormWindowState.Maximized);
			MarDevs.Gestion.Win.Properties.Settings.Default.UltimoPanelActivo = panelNavegacionUserControl1.UltraExplorerBar1.SelectedGroup.Key;
			MarDevs.Gestion.Win.Properties.Settings.Default.Save();
		}
		public void EstablecerTextoStatusBarPanelDerecho(string texto)
		{
			try
			{
				ultraStatusBar1.Panels["PanelDerecho"].Text = texto;
				ultraStatusBar1.Refresh();
			}
			catch { }
		}

		#region METODOS DE OPCIONES DEL MENU Y TOOLBAR

		private void CambiarDeUsuario()
		{
			Ticket viejoTicket = ConfigBL.ticket;

			FormLogin formloguin = new FormLogin();
			Ticket nuevoTicket = formloguin.RealizarAutenticacion();
			if (nuevoTicket != null)
			{
				//si cambio el usuario... debemos registrar logout y login.
				if (viejoTicket != null && !viejoTicket.Equals(nuevoTicket))
				{
					//lo hacemos aqui porque todavia no se establecio el nuevo ticket.
					App.RegistrarLogOut();
				}
				ConfigBL.ticket = nuevoTicket;

				//ahora que se establecio el nuevo ticket... registro login
				if (viejoTicket != null && !viejoTicket.Equals(nuevoTicket))
				{
					App.RegistrarLogIn();
				}
				if( _formInvalidado && nuevoTicket.Equals(viejoTicket) )
				{
					return;
				}
				else
				{
					_formInvalidado = false;
					InicializarListas();
					CrearMenuPrincipal();
					SetearTituloAplicacion();
				}
			}
		}
		#endregion

		#region Manipulacion Historia de Navegacion

        /// <summary>
        ///deshabilitar navegacion hacia atras y hacia adelante
        ///si la pila esta vacia, ya no se puede navegar hacia atras
		/// </summary>
        private void InicializarHistoriaNavegacion()
		{
			foreach(Form form in this.MdiChildren)
			{
				form.Close();
				form.Dispose();
			}

			this._historia.Clear();
			this._posicion = -1;
			this.SetearBotonesNavegacion();
		}
		private void SetearBotonesNavegacion()
		{
			if (_multiFormulario) { return; }

			//si solo hay un elemento, no se puede navegar
			if (this._historia.Count <= 1)
			{
				this.ultraToolbarsManager1.Tools["NavegarAtras"].SharedProps.Enabled = false;
				this.ultraToolbarsManager1.Tools["NavegarAdelante"].SharedProps.Enabled = false;
			}
			else
			{
				this.ultraToolbarsManager1.Tools["NavegarAtras"].SharedProps.Enabled = (_posicion > 0);
				this.ultraToolbarsManager1.Tools["NavegarAdelante"].SharedProps.Enabled = (_posicion < (this._historia.Count-1));
			}
		}
		private void AgregarHistoria(FormMDIBase form)
		{
			if (form == null || _multiFormulario) { return; }

			if (this._historia.Count == 0 || !this._historia[this._historia.Count-1].Equals(form))
			{
				//this.historia.RemoveRange(_posicion, historia.Count-_posicion+1);
				//this.historia.Add(form);
				this._historia.Insert(_posicion+1, form);
				this._posicion = _posicion + 1;
			}
			if (_historia.Count > _maximaHistoria)
			{
				FormMDIBase formBorrar = _historia[0];
				_historia.RemoveAt(0);
				if (formBorrar != null && !_historia.Contains(formBorrar))
				{
					formBorrar.Visible = false;
					formBorrar.MdiParent = null;
					formBorrar.Close();
					formBorrar.Dispose();
					GC.Collect();
				}
				_posicion--;
			}
			this.SetearBotonesNavegacion();
		}
		private void EliminarHistoria(FormMDIBase form)
		{
			if (form == null || _multiFormulario) { return; }
			if (_historia.Contains(form))
			{
				int pos = _historia.IndexOf(form);
				if (pos < _posicion || _posicion == _historia.Count-1)
				{
					_posicion--;
				}
				_historia.Remove(form);
			}
		}
		private void NavegarAtras()
		{
			if (_multiFormulario) { return; }

			_posicion--;
			NavegarAPosicion(_posicion);
		}
		private void NavegarAPosicion(int nuevaPosicion)
		{
			if (_multiFormulario) { return; }

			_posicion = nuevaPosicion;

			if (_posicion <= (this._historia.Count - 1))
			{
				FormMDIBase mdi = this._historia[_posicion];
				if (mdi != null && !mdi.IsDisposed)
				{
					this.MostrarFormularioMDI(mdi, true, false);
				}
			}
			this.SetearBotonesNavegacion();
		}
		private void NavegarAdelante()
		{
			if (_multiFormulario) { return; }

			_posicion++;
			NavegarAPosicion(_posicion);
		}

		#endregion

		#region Manejo de Eventos

		private void ultraToolbarsManager1_BeforeToolDropdown(object sender, BeforeToolDropdownEventArgs e)
		{
			PopupMenuTool popup = e.Tool as PopupMenuTool;

			switch (e.Tool.Key)
			{
				case "NavegarAtras":

					if (popup != null)
					{
						ButtonTool tool;
						string key;
						popup.Tools.Clear();
						for (int i = _posicion-1; i >=0; i--)
						{
							key = String.Format("Historia_{0}", i);
							if (ultraToolbarsManager1.Tools.Exists(key))
							{
								tool = ultraToolbarsManager1.Tools[key] as ButtonTool;
							}
							else
							{
								tool = new ButtonTool(key);
								ultraToolbarsManager1.Tools.Add(tool);
							}
							tool.SharedProps.Tag = i;
							tool.SharedProps.Caption = _historia[i].Text;

							popup.Tools.AddTool(key);
						}
					}
					break;

				case "NavegarAdelante":

					if (popup != null)
					{
						ButtonTool tool;
						string key;
						popup.Tools.Clear();
						for (int i = _posicion + 1; i < _historia.Count; i++)
						{
							key = String.Format("Historia_{0}", i);
							if (ultraToolbarsManager1.Tools.Exists(key))
							{
								tool = ultraToolbarsManager1.Tools[key] as ButtonTool;
							}
							else
							{
								tool = new ButtonTool(key);
								ultraToolbarsManager1.Tools.Add(tool);
							}
							tool.SharedProps.Tag = i;
							tool.SharedProps.Caption = _historia[i].Text;

							popup.Tools.AddTool(key);
						}
					}
					break;
			}
		}
		private void ultraToolbarsManager1_ToolClick(object Sender, ToolClickEventArgs e)
		{
			if (e.Tool.SharedProps.Tag is int)//ES HISTORIA DE NAVEGACION
			{
				NavegarAPosicion(Convert.ToInt32(e.Tool.SharedProps.Tag));
			}
			else
			{
				this.ProcesarSeleccion(e.Tool.Key);
			}

		}
		private void ultraDockManager1_BeforeShowFlyout(object sender, Infragistics.Win.UltraWinDock.CancelableControlPaneEventArgs e)
		{
			//			Mensaje.Informacion("BeforeShowFlyout");
		}
		private void SystemEvents_TimeChanged(object sender, EventArgs e)
		{
			try
			{
				ConfigBL.SincronizarHoraConServidor();
			}
			catch (Exception ex)
			{
				string texto = "No fue posible sincronizar la hora con el servidor. La aplicación se cerrará.";
				Mensaje.Error(texto,ex);
				Application.Exit();				
			}

		}
		private void notifyTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (ConfigBL.ticket.Impersonado) { return; }
				
				this._notifyTimer.Stop();

				EstablecerTextoStatusBarPanelDerecho("Comprobando notificaciones...");

				//limpiar el cache de flags...
				FlagsFactory.LimpiarCache();

				#region COMPROBAR AVISOS DE MARCAS DE SEGUIMIENTO

				IList<MarcaSeguimiento> avisos = MarcaSeguimiento.BuscarUsuarioLogueado(true);
				if (avisos.Count > 0)
				{
					FormAvisoSeguimiento.MostrarAvisos(avisos);
				}

				#endregion

				#region ACTUALIZAR ULTIMA SINCRONIZACION

				EstablecerTextoStatusBarPanelDerecho( "" );

				#endregion
			}
			catch (Exception ex)
			{
				//NO MUESTRO MENSAJE, PERO LO LOGUEO
				AdministradorDeExcepciones.Publicar(ex);
			}
			finally
			{
				this._notifyTimer.Start();
				//this.EstablecerTextoStatusBarPanelDerecho(String.Empty);
			}
		}
		private void updateTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				this._notifyTimer.Stop();
				this._updateTimer.Stop();
				this.ComprobarActualizaciones();
			}
			finally
			{
				this._notifyTimer.Start();
				this._updateTimer.Start();
			}
		}
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.WindowState = FormWindowState.Normal;
			}
			this.BringToFront();

			if (e.Link != null && e.Link.Tag != null)
			{
				string keycomando = e.Link.Tag.ToString();
				Comando opcion = this.panelNavegacionUserControl1.ObtenerComando(keycomando);
				if (opcion != null)
				{
					EjecutarComando(opcion, false);
				}
			}
		}

		#endregion

		#region MANEJO DE FORMULARIOS MDI

		public void PrepararYMostrarFormularioMDI(FormMDIBase form, string titulo, string nombreIcono, string key)
		{
			PrepararYMostrarFormularioMDI(form, titulo, nombreIcono, key, String.Empty);
		}
		public void PrepararYMostrarFormularioMDI(FormMDIBase form, string titulo, string nombreIcono, string key, string descripcion)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				form.Text = titulo;
				form.Key = key;
				form.Descripcion = descripcion;
                
                //WORKARROUND PARA QUE LOS RECURSOS SE TRAIGAN
                //HAY QUE PLANTEAR UNA FORMA UNIFORME DE OBTENER RECURSOS
                object recurso = App.TraerRecurso(nombreIcono);
				if (recurso is Icon)
				{
					form.Icon = recurso as Icon;
				}
				else if (recurso is Image)
				{
					form.Icon = Icon.FromHandle((recurso as Bitmap).GetHicon());
				}
				form.FormInvalidado +=new FormInvalidadoEventHandler(MDIForm_FormInvalidado);
				form.ActualizarStatusBarText+=new EventHandler(pMDIForm_ActualizarStatusBarText);
				form.MdiParent = this;
				this.MostrarFormularioMDI(form, false, true);
			}
			catch// ( Exception ex )
			{
				//MessageBox.Show("ERROR TRAPEADO EN PrepararYMostrarFormularioMDI" + Environment.NewLine + ex.ToString());
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		public void MostrarFormularioMDI(FormMDIBase form, bool actualizarLista, bool agregarHistoria)
		{
			if (this.ActiveMdiChild != null)
			{
				//si es un form lista, retener la _posicion antes de ocultarlo porque despues se pierde
				if (this.ActiveMdiChild is FormListaBase)
				{
					(this.ActiveMdiChild as FormListaBase).RetenerPosicionGrilla();
				}
				if (!_multiFormulario)
				{
					this.ActiveMdiChild.Visible = false;
				}
			}
			//hacer visible el formulario que queremos activar
			//si es un form lista base
			form.Visible = true;
			form.Activate();

			FormListaBase fListaBase = form as FormListaBase;
			if (fListaBase != null)
			{
				fListaBase.RetenerPosicionGrilla();
				if (actualizarLista && fListaBase.DebeActualizarAlActivar)
				{
					fListaBase.ActualizarListaDesdeOrigen();
				}
				fListaBase.RestaurarPosicionGrilla();
			}
			if (agregarHistoria)
			{
				AgregarHistoria(form);
			}
			//llamada critica para que funcione correctamente el toolbarmanager
			//luego de, por ejemplo, cargar el xml de docking. Por alguna razón
			//se rompe el merge.
			ultraToolbarsManager1.RefreshMerge();

		}
		public Form TraerMDI(string key)
		{
			foreach (FormMDIBase form in this.MdiChildren)
			{
				if (form.Key == key)
				{
					return form;
				}
			}
			return null;
		}
		private void Form1_MdiChildActivate(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild != null)
			{
				FormMDIBase fMDI = this.ActiveMdiChild as FormMDIBase;
				if (fMDI != null)
				{
					//status bar text
					this.ultraStatusBar1.Panels["Status"].Text = fMDI.StatusBarText;
					//sincronizar el nodo del arbol
					//HAY Q IMPLEMENTAR...
					//UltraTreeNode lNodo = this.ultraTree1.GetNodeByKey("OpcionMenu_"+fMDI.Key);
					//if (lNodo != null)
					//{
					//    lNodo.Selected = true;
					//}
				}
			}
			else
			{
				this.ultraStatusBar1.Panels["Status"].Text = String.Empty;
			}
		}
		private void MDIForm_FormInvalidado(object sender, FormInvalidadoEventArgs e)
		{
			Form f = (Form)sender;
			EliminarHistoria(f as FormMDIBase);
			f.Visible = false;
			f.MdiParent = null;
			f.Close();
			f.Dispose();

			string tempTexto = "Al tratar de abrir el formulario se produjo el siguiente error: " + Environment.NewLine
				+ Environment.NewLine
				+ e.Excepcion.Message + Environment.NewLine
				+ Environment.NewLine
				+ "El formulario no puede abrirse. ";

			Mensaje.Error( tempTexto, e.Excepcion );
		}
		private void pMDIForm_ActualizarStatusBarText(object sender, EventArgs e)
		{
			FormMDIBase fMDI = (FormMDIBase)sender;
			if (fMDI != null)
			{
				this.ultraStatusBar1.Panels["Status"].Text = fMDI.StatusBarText;
			}
		}

		#endregion

		private void panelNavegacionUserControl1_ComandoEjecutado(object sender, ComandoEjecutadoEventArgs e)
		{				
			if (!ConfigBL.ticket.Impersonado) // Si el ticket es Impersonado no corresponde registrar el log de clicks en el Menu
			{				
				Comando cmd = e.Comando;
				try
				{
					using (DL dl = DL.ObtenerSesion())
					{
						dl.EjecutarSQL(CommandType.Text, "INSERT INTO LOGMENU (Usuario, Fecha, FormKey, FormDescripcion) VALUES (@Usr, @Fecha, @FormKey, @FormDesc)",
										new SqlParameter("@Usr", ConfigBL.ticket.UsuarioLogon),
										new SqlParameter("@Fecha", ConfigBL.FechaYHoraActual),
										new SqlParameter("@FormKey", cmd.Key),
										new SqlParameter("@FormDesc", cmd.Nombre));
					}
				}
				catch // Si hay algún error, lo consumo
				{ }
			}

			EjecutarComando(e.Comando, e.NuevaVentana);
		}
		private void EjecutarComando(Comando opcion, bool nuevaVentana)
		{
			try
			{
				Form form = null;
				Type tipo = null;

				switch (opcion.Accion)
				{
					case TipoComando.AbrirMDI:

						#region ABRIRMDI

						if (!nuevaVentana)
						{
							FormMDIBase fMDI = TraerMDI(opcion.Key) as FormMDIBase;
							if (fMDI != null)
							{
								MostrarFormularioMDI(fMDI, true, false);
								return;
							}
						}
						tipo = Type.GetType(opcion.Target);
						if (tipo == null)
						{
							throw new ArgumentException(String.Format("No se ha encontrado el tipo {0}", opcion.Target));
						}
						if (!tipo.IsSubclassOf(typeof(FormMDIBase)))
						{
							throw new Exception("El comando AbrirMDI requiere que el formulario derive de FormMDIBase. Asegúrese que el tipo de acción sea correcto o bien derive el formulario de FormMDIBase");
						}
						form = Activator.CreateInstance(tipo, Comando.ConvertirParametros(opcion.Parametros)) as Form;
						this.PrepararYMostrarFormularioMDI(form as FormMDIBase, opcion.Nombre, opcion.Imagen, opcion.Key, opcion.Descripcion);
						break;

						#endregion

					case TipoComando.AbrirForm:
					case TipoComando.AbrirModal:

						#region ABRIRFORM
						tipo = Type.GetType(opcion.Target);
						if (tipo == null)
						{
							throw new ArgumentException(String.Format("No se ha encontrado el tipo {0}", opcion.Target));
						}
						form = Activator.CreateInstance(tipo, Comando.ConvertirParametros(opcion.Parametros)) as Form;
						if (opcion.Accion == TipoComando.AbrirModal)
						{
							form.ShowDialog();
						}
						else
						{
							form.Show();
						}
						break;

						#endregion

					case TipoComando.Metodo:

						#region EJECUTAR METODO

						MethodInfo info = (MethodInfo)ObtenerMemberInfoDesdeClase(opcion.Target);
						if (info != null)
						{
							info.Invoke(null, Comando.ConvertirParametros(opcion.Parametros.ToArray()));
						}
						break;

						#endregion
				}
			}
			catch (Exception ex)
			{
				Mensaje.Error(ex.Message, ex);
			}
		}
		/// <summary>
		/// Devuelve el valor de una ruta por reflexión, a partir de un objeto base.
		/// Por ejemplo: control1.Panel1.TextBox1.Text
		/// </summary>
		/// <param name="objeto"></param>
		/// <param name="sPropiedad"></param>
		/// <returns></returns>
		private static MemberInfo ObtenerMemberInfoDesdeClase(String sCadena)
		{
			if (String.IsNullOrEmpty(sCadena))
			{
				return null;
			}
			String[] parseo = sCadena.Split(';');
			Type tipo = Type.GetType(parseo[0].Trim());
			if (parseo.Length == 2 && tipo != null)
			{
				MemberInfo[] miembros = tipo.GetMember(parseo[1].Trim());
				if (miembros.Length > 0) { return miembros[0]; }
			}
			return null;
		}
		private void ComprobarActualizaciones()
		{
			string textopanel = this.ultraStatusBar1.Panels["PanelDerecho"].Text;

			try
			{
				this.EstablecerTextoStatusBarPanelDerecho("Verificando actualizaciones disponibles...");
				FlagsFactory.LimpiarCache(); //asegurarnos tener info actualizada.
                Flags flags = FlagsFactory.ObtenerInstancia<Flags>();
				if (flags.UpdaterHabilitado && !String.IsNullOrEmpty(flags.UpdaterURL))
				{
					this.autoUpdater1.ConfigURL = flags.UpdaterURL;
					if (this.autoUpdater1.HayNuevaVersion())
					{
						this.EstablecerTextoStatusBarPanelDerecho("Descargando actualizaciones...");
						this.autoUpdater1.AutoRestart = false;
						this.autoUpdater1.RestartForm = new FormConfirmarDescarga();
						this.autoUpdater1.EjecutarBackground = true;
						this.autoUpdater1.IntentarUpdate();
					}
				}
			}
			catch (Exception ex)
			{
				//fallamos silencioso, pero la publicamos...
				AdministradorDeExcepciones.Publicar(ex);
			}
			finally
			{
				//restablecemos el texto que habia en el panel derecho.
				this.EstablecerTextoStatusBarPanelDerecho(textopanel);
			}
		}
	}
}
