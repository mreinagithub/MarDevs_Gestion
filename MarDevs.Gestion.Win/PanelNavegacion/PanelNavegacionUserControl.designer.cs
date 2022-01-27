namespace MarDevs.Gestion.Win
{
    partial class PanelNavegacionUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
			this.ultraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
			this.ultraTreeAdministracion = new Infragistics.Win.UltraWinTree.UltraTree();
			this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
			this.nuevaVentanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propiedadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager();
			((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).BeginInit();
			this.ultraExplorerBar1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraTreeAdministracion)).BeginInit();
			this.ultraExplorerBarContainerControl1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraExplorerBarContainerControl2
			// 
			this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(1, 26);
			this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
			this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(260, 260);
			this.ultraExplorerBarContainerControl2.TabIndex = 0;
			// 
			// ultraExplorerBar1
			// 
			this.ultraExplorerBar1.Controls.Add(this.ultraExplorerBarContainerControl2);
			this.ultraExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl2;
			ultraExplorerBarGroup1.Key = "Design";
			ultraExplorerBarGroup1.Text = "Design";
			this.ultraExplorerBar1.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
			this.ultraExplorerBar1.GroupSettings.NavigationAllowHide = Infragistics.Win.DefaultableBoolean.False;
			this.ultraExplorerBar1.GroupSettings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
			this.ultraExplorerBar1.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
			this.ultraExplorerBar1.ImageSizeLarge = new System.Drawing.Size(24, 24);
			this.ultraExplorerBar1.Location = new System.Drawing.Point(0, 0);
			this.ultraExplorerBar1.Name = "ultraExplorerBar1";
			this.ultraExplorerBar1.NavigationAllowGroupReorder = false;
			this.ultraExplorerBar1.ShowDefaultContextMenu = false;
			this.ultraExplorerBar1.Size = new System.Drawing.Size(262, 347);
			this.ultraExplorerBar1.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.OutlookNavigationPane;
			this.ultraExplorerBar1.TabIndex = 4;
			this.ultraExplorerBar1.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
			this.ultraExplorerBar1.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2007;
			// 
			// ultraTreeAdministracion
			// 
			this.ultraTreeAdministracion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ultraTreeAdministracion.HideSelection = false;
			this.ultraTreeAdministracion.Indent = 15;
			this.ultraTreeAdministracion.Location = new System.Drawing.Point(0, 0);
			this.ultraTreeAdministracion.Name = "ultraTreeAdministracion";
			_override1.HotTracking = Infragistics.Win.DefaultableBoolean.True;
			appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
			_override1.HotTrackingNodeAppearance = appearance1;
			_override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Single;
			this.ultraTreeAdministracion.Override = _override1;
			this.ultraTreeAdministracion.Size = new System.Drawing.Size(260, 254);
			this.ultraTreeAdministracion.TabIndex = 3;
			// 
			// ultraExplorerBarContainerControl1
			// 
			this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraTreeAdministracion);
			this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(1, 26);
			this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
			this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(260, 254);
			this.ultraExplorerBarContainerControl1.TabIndex = 0;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaVentanaToolStripMenuItem,
            this.propiedadesToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(155, 48);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
			// 
			// nuevaVentanaToolStripMenuItem
			// 
			this.nuevaVentanaToolStripMenuItem.Name = "nuevaVentanaToolStripMenuItem";
			this.nuevaVentanaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.nuevaVentanaToolStripMenuItem.Text = "Nueva Ventana";
			// 
			// propiedadesToolStripMenuItem
			// 
			this.propiedadesToolStripMenuItem.Name = "propiedadesToolStripMenuItem";
			this.propiedadesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.propiedadesToolStripMenuItem.Text = "Propiedades";
			// 
			// ultraToolTipManager1
			// 
			this.ultraToolTipManager1.ContainingControl = this;
			this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
			// 
			// PanelNavegacionUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ultraExplorerBar1);
			this.Name = "PanelNavegacionUserControl";
			this.Size = new System.Drawing.Size(262, 347);
			((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).EndInit();
			this.ultraExplorerBar1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraTreeAdministracion)).EndInit();
			this.ultraExplorerBarContainerControl1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar ultraExplorerBar1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
        private Infragistics.Win.UltraWinTree.UltraTree ultraTreeAdministracion;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem nuevaVentanaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem propiedadesToolStripMenuItem;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
    }
}
