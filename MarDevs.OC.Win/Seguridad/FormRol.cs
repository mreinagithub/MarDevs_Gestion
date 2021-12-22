using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using MarDevs.OC.Core;
using System.Collections.Generic;

namespace MarDevs.OC.Win
{
	public class FormRol : FormAbmBase
	{
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grillaPrivilegios;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtRolNombre;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor comboCategorias;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor1;
		private Infragistics.Win.Misc.UltraButton botonDenegarTodos;
		private Infragistics.Win.Misc.UltraButton botonConcederTodos;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
		private Infragistics.Win.UltraWinGrid.UltraGrid grillaMiembros;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ckSoloUsuariosActivos;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cboUsuarios;
		private Infragistics.Win.Misc.UltraButton btnQuitarUsuario;
		private Infragistics.Win.Misc.UltraButton btnAgregarUsuario;
		private System.ComponentModel.IContainer components = null;

		public FormRol( Rol rol ) :base(rol)
		{
			InitializeComponent();

			this.grillaPrivilegios.InitializeLayout += new InitializeLayoutEventHandler(grillaPrivilegios_InitializeLayout);
			this.grillaPrivilegios.InitializeRow+=new InitializeRowEventHandler(grillaPrivilegios_InitializeRow);
			this.grillaPrivilegios.BeforeCellListDropDown+=new CancelableCellEventHandler(grillaPrivilegios_BeforeCellListDropDown);
			this.grillaMiembros.InitializeLayout+=new InitializeLayoutEventHandler(grillaMiembros_InitializeLayout);
			this.comboCategorias.SelectionChangeCommitted+=new EventHandler(comboCategorias_SelectionChangeCommitted);
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

		#region Código generado por el diseñador
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRol));
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.btnQuitarUsuario = new Infragistics.Win.Misc.UltraButton();
            this.btnAgregarUsuario = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.cboUsuarios = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ckSoloUsuariosActivos = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.grillaMiembros = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonConcederTodos = new Infragistics.Win.Misc.UltraButton();
            this.ultraCheckEditor1 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.comboCategorias = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.grillaPrivilegios = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.botonDenegarTodos = new Infragistics.Win.Misc.UltraButton();
            this.txtRolNombre = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreadoEl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCreadoPor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).BeginInit();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckSoloUsuariosActivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMiembros)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCheckEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCategorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPrivilegios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRolNombre)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.MenuSettings.ForceSerialization = true;
            this.ultraToolbarsManager1.ToolbarSettings.ForceSerialization = true;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.txtRolNombre);
            this.ultraTabPageControl1.Controls.Add(this.groupBox1);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl1.Size = new System.Drawing.Size(472, 484);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Size = new System.Drawing.Size(472, 484);
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 28);
            this.ultraTabControl1.Size = new System.Drawing.Size(474, 507);
            this.ultraTabControl1.TabPageMargins.ForceSerialization = true;
            ultraTab1.Key = "Usuarios";
            ultraTab1.TabPage = this.ultraTabPageControl3;
            ultraTab1.Text = "Miembros";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            this.ultraTabControl1.Controls.SetChildIndex(this.ultraTabPageControl3, 0);
            this.ultraTabControl1.Controls.SetChildIndex(this.ultraTabPageControl2, 0);
            this.ultraTabControl1.Controls.SetChildIndex(this.ultraTabPageControl1, 0);
            // 
            // grillaBitacora
            // 
            appearance7.BackColor = System.Drawing.Color.White;
            this.grillaBitacora.DisplayLayout.Appearance = appearance7;
            this.grillaBitacora.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridBand1.AddButtonCaption = "DummyBand 1";
            this.grillaBitacora.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grillaBitacora.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grillaBitacora.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grillaBitacora.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grillaBitacora.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.grillaBitacora.DisplayLayout.Override.CardAreaAppearance = appearance8;
            this.grillaBitacora.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grillaBitacora.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance9.TextHAlignAsString = "Left";
            this.grillaBitacora.DisplayLayout.Override.HeaderAppearance = appearance9;
            this.grillaBitacora.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance10.BorderColor = System.Drawing.Color.LightGray;
            appearance10.TextVAlignAsString = "Middle";
            this.grillaBitacora.DisplayLayout.Override.RowAppearance = appearance10;
            this.grillaBitacora.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.Highlight;
            appearance11.BorderColor = System.Drawing.Color.Black;
            appearance11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.grillaBitacora.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grillaBitacora.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grillaBitacora.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grillaBitacora.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grillaBitacora.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.grillaBitacora.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grillaBitacora.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grillaBitacora.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grillaBitacora.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grillaBitacora.Size = new System.Drawing.Size(458, 409);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.btnQuitarUsuario);
            this.ultraTabPageControl3.Controls.Add(this.btnAgregarUsuario);
            this.ultraTabPageControl3.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl3.Controls.Add(this.cboUsuarios);
            this.ultraTabPageControl3.Controls.Add(this.ckSoloUsuariosActivos);
            this.ultraTabPageControl3.Controls.Add(this.grillaMiembros);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(472, 484);
            // 
            // btnQuitarUsuario
            // 
            this.btnQuitarUsuario.Location = new System.Drawing.Point(396, 37);
            this.btnQuitarUsuario.Name = "btnQuitarUsuario";
            this.btnQuitarUsuario.Size = new System.Drawing.Size(60, 23);
            this.btnQuitarUsuario.TabIndex = 2;
            this.btnQuitarUsuario.Text = "Quitar";
            this.btnQuitarUsuario.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnQuitarUsuario.Click += new System.EventHandler(this.btnQuitarUsuario_Click);
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Location = new System.Drawing.Point(330, 37);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(60, 23);
            this.btnAgregarUsuario.TabIndex = 1;
            this.btnAgregarUsuario.Text = "Agregar";
            this.btnAgregarUsuario.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // ultraLabel2
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance4;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Location = new System.Drawing.Point(16, 42);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(52, 14);
            this.ultraLabel2.TabIndex = 6;
            this.ultraLabel2.Text = "Usuarios:";
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboUsuarios.Location = new System.Drawing.Point(77, 39);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(247, 21);
            this.cboUsuarios.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.cboUsuarios.TabIndex = 0;
            this.cboUsuarios.AfterExitEditMode += new System.EventHandler(this.cboUsuarios_AfterExitEditMode);
            this.cboUsuarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboUsuarios_KeyDown);
            // 
            // ckSoloUsuariosActivos
            // 
            this.ckSoloUsuariosActivos.BackColor = System.Drawing.Color.Transparent;
            this.ckSoloUsuariosActivos.BackColorInternal = System.Drawing.Color.Transparent;
            this.ckSoloUsuariosActivos.Location = new System.Drawing.Point(16, 13);
            this.ckSoloUsuariosActivos.Name = "ckSoloUsuariosActivos";
            this.ckSoloUsuariosActivos.Size = new System.Drawing.Size(169, 20);
            this.ckSoloUsuariosActivos.TabIndex = 4;
            this.ckSoloUsuariosActivos.Text = "Ver solo usuarios habilitados";
            this.ckSoloUsuariosActivos.CheckedChanged += new System.EventHandler(this.ckSoloUsuariosActivos_CheckedChanged);
            // 
            // grillaMiembros
            // 
            this.grillaMiembros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grillaMiembros.Cursor = System.Windows.Forms.Cursors.Default;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            this.grillaMiembros.DisplayLayout.Appearance = appearance5;
            this.grillaMiembros.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.grillaMiembros.DisplayLayout.MaxBandDepth = 1;
            this.grillaMiembros.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grillaMiembros.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grillaMiembros.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grillaMiembros.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grillaMiembros.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grillaMiembros.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance6.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.grillaMiembros.DisplayLayout.Override.RowAppearance = appearance6;
            this.grillaMiembros.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grillaMiembros.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grillaMiembros.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grillaMiembros.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grillaMiembros.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grillaMiembros.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grillaMiembros.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grillaMiembros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grillaMiembros.Location = new System.Drawing.Point(16, 72);
            this.grillaMiembros.Name = "grillaMiembros";
            this.grillaMiembros.Size = new System.Drawing.Size(442, 399);
            this.grillaMiembros.TabIndex = 3;
            this.grillaMiembros.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnUpdate;
            this.grillaMiembros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grillaMiembros_KeyDown);
            // 
            // ultraLabel1
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance3;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(16, 16);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(72, 23);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.botonConcederTodos);
            this.groupBox1.Controls.Add(this.ultraCheckEditor1);
            this.groupBox1.Controls.Add(this.comboCategorias);
            this.groupBox1.Controls.Add(this.grillaPrivilegios);
            this.groupBox1.Controls.Add(this.botonDenegarTodos);
            this.groupBox1.Location = new System.Drawing.Point(16, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 425);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Privilegios";
            // 
            // botonConcederTodos
            // 
            this.botonConcederTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botonConcederTodos.Location = new System.Drawing.Point(130, 394);
            this.botonConcederTodos.Name = "botonConcederTodos";
            this.botonConcederTodos.Size = new System.Drawing.Size(144, 24);
            this.botonConcederTodos.TabIndex = 3;
            this.botonConcederTodos.Text = "Conceder todos";
            this.botonConcederTodos.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.botonConcederTodos.Click += new System.EventHandler(this.botonConcederTodos_Click);
            // 
            // ultraCheckEditor1
            // 
            this.ultraCheckEditor1.Location = new System.Drawing.Point(306, 24);
            this.ultraCheckEditor1.Name = "ultraCheckEditor1";
            this.ultraCheckEditor1.Size = new System.Drawing.Size(120, 20);
            this.ultraCheckEditor1.TabIndex = 1;
            this.ultraCheckEditor1.Text = "Ver sólo permitidos";
            this.ultraCheckEditor1.CheckedChanged += new System.EventHandler(this.ultraCheckEditor1_CheckedChanged);
            // 
            // comboCategorias
            // 
            this.comboCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCategorias.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.comboCategorias.Location = new System.Drawing.Point(16, 24);
            this.comboCategorias.MaxDropDownItems = 30;
            this.comboCategorias.Name = "comboCategorias";
            this.comboCategorias.Size = new System.Drawing.Size(282, 21);
            this.comboCategorias.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
            this.comboCategorias.TabIndex = 0;
            // 
            // grillaPrivilegios
            // 
            this.grillaPrivilegios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grillaPrivilegios.Cursor = System.Windows.Forms.Cursors.Default;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            this.grillaPrivilegios.DisplayLayout.Appearance = appearance1;
            this.grillaPrivilegios.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.grillaPrivilegios.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grillaPrivilegios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.grillaPrivilegios.DisplayLayout.Override.RowAppearance = appearance2;
            this.grillaPrivilegios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grillaPrivilegios.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grillaPrivilegios.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grillaPrivilegios.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grillaPrivilegios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grillaPrivilegios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grillaPrivilegios.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grillaPrivilegios.Location = new System.Drawing.Point(16, 56);
            this.grillaPrivilegios.Name = "grillaPrivilegios";
            this.grillaPrivilegios.Size = new System.Drawing.Size(412, 329);
            this.grillaPrivilegios.TabIndex = 2;
            this.grillaPrivilegios.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnUpdate;
            // 
            // botonDenegarTodos
            // 
            this.botonDenegarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botonDenegarTodos.Location = new System.Drawing.Point(282, 393);
            this.botonDenegarTodos.Name = "botonDenegarTodos";
            this.botonDenegarTodos.Size = new System.Drawing.Size(144, 24);
            this.botonDenegarTodos.TabIndex = 4;
            this.botonDenegarTodos.Text = "Denegar todos";
            this.botonDenegarTodos.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.botonDenegarTodos.Click += new System.EventHandler(this.botonDenegarTodos_Click);
            // 
            // txtRolNombre
            // 
            this.txtRolNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRolNombre.Location = new System.Drawing.Point(72, 16);
            this.txtRolNombre.Name = "txtRolNombre";
            this.txtRolNombre.Size = new System.Drawing.Size(378, 21);
            this.txtRolNombre.TabIndex = 0;
            // 
            // FormRol
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(474, 535);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRol";
            this.Text = "Rol";
            this.Load += new System.EventHandler(this.FormAbmRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreadoEl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCreadoPor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).EndInit();
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckSoloUsuariosActivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMiembros)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCheckEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPrivilegios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRolNombre)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private ValueList vlAlcanceFull = null;
		private ValueList vlAlcanceBasico = null;
		private Image imagenPermitido = null;
		private Image imagenDenegado = null;

		#region PROPIEDADES
		
		protected override bool SoloLectura
		{
			get
			{
				return base.SoloLectura;
			}
			set
			{
				base.SoloLectura = value;
				this.comboCategorias.ReadOnly = false;
				this.ultraCheckEditor1.Enabled = true;
				this.ckSoloUsuariosActivos.Enabled = true;
				this.grillaPrivilegios.DisplayLayout.Override.AllowUpdate = (_soloLectura) ? DefaultableBoolean.False : DefaultableBoolean.True;
				this.grillaPrivilegios.DisplayLayout.Override.CellClickAction = (_soloLectura) ? CellClickAction.CellSelect: CellClickAction.Default;
			}
		}
		private Rol Rol
		{
			get { return _obj as Rol; }
		}

		#endregion

		private void FormAbmRol_Load(object sender, System.EventArgs e)
		{
			this.Text = "Edición de Rol";

			this.imagenPermitido = UtilP.TraerRecurso("ImagenPrivilegioConcedido") as Image;
			this.imagenDenegado = UtilP.TraerRecurso("ImagenPrivilegioDenegado") as Image;
			
			bool puedeEditar = this.Rol.Editable && 
				(    this.Rol.EsNuevo() && ConfigBL.ticket.Usuario.ObtenerAlcancePrivilegio( PRV.ADMINISTRAR_ROL ) > Alcances.Denegado
				  || !this.Rol.EsNuevo() && ConfigBL.ticket.Usuario.ObtenerAlcancePrivilegio(PRV.ADMINISTRAR_ROL) > Alcances.Denegado
				);
			this.SoloLectura = !puedeEditar;

			this.BindearControles();
			//inicializaciones varias
			this.CargarValueLists();
			this.CargarComboCategorias();
			this.CargarComboUsuarios();
			this.LlenarGrillaPrivilegios();
			
			if (this.grillaPrivilegios.Rows.Count > 0)
			{
				this.grillaPrivilegios.Rows[0].Selected = true;
			}
			if (this.grillaMiembros.Rows.Count > 0)
			{
				this.grillaMiembros.Rows[0].Selected = true;
			}
			this.comboCategorias.SelectedIndex = 0;

			this.ckSoloUsuariosActivos.Checked = true;
			this.grillaMiembros.ActiveRow = null;
			this.grillaMiembros.Selected.Rows.Clear();
			

		}

		protected override bool GuardarCambios()
		{
			this.grillaPrivilegios.UpdateData();
			this.Rol.QuitarTodosLosPrivilegios();
			foreach( RolPrivilegio rolPrv in (this.grillaPrivilegios.DataSource as IList) )
			{
				if ( rolPrv.Alcance > Alcances.Denegado )
				{
					this.Rol.Privilegios.Add(rolPrv);
				}
			}
			return base.GuardarCambios();
		}
		private void CargarComboCategorias()
		{
			bool encontrado;
			this.comboCategorias.Items.Clear();
			this.comboCategorias.Items.Add("[Todas]");
			foreach (Privilegio prv in Privilegio.Listar())
			{
				encontrado = false;
				foreach(ValueListItem item in this.comboCategorias.Items)
				{
					if ( item.DataValue.Equals(prv.Categoria) )
					{
						encontrado = true;
						break;
					}
				}
				if (!encontrado)
				{
					this.comboCategorias.Items.Add(prv.Categoria);
				}
			}
		}
		private void LlenarGrillaPrivilegios()
		{
			ArrayList lista = new ArrayList();
			foreach (Privilegio prv in Privilegio.Listar())
			{
				RolPrivilegio rolPrv = new RolPrivilegio();
				rolPrv.Privilegio = prv;
				rolPrv.Alcance = this.Rol.TienePrivilegio(prv);
				lista.Add(rolPrv);
			}
			this.grillaPrivilegios.DataSource = lista;
			
		}
		private void CargarValueLists()
		{
			this.vlAlcanceBasico = new ValueList();
			ValueListItem vli;
			vli = new ValueListItem();
			vli.DataValue = Alcances.Denegado;
			vli.DisplayText = "Denegado";
			vli.Appearance.Image = this.imagenDenegado;
			vlAlcanceBasico.ValueListItems.Add(vli);
			vli = new ValueListItem();
			vli.DataValue = Alcances.Total;
			vli.DisplayText = "Permitido";
			vli.Appearance.Image = this.imagenPermitido;
			vlAlcanceBasico.ValueListItems.Add(vli);
			
			this.vlAlcanceFull = UtilP.CargarValueListDesdeEnum(typeof(Alcances));
		}
        private void BindearControles()
        {
            this.LimpiarBindings();

            this.txtRolNombre.DataBindings.Add("Text", Rol, "Nombre");
            this.grillaMiembros.DataSource = Rol.Usuarios;
            this.grillaMiembros.DataBind();
        }
		private void CargarComboUsuarios()
		{
			this.cboUsuarios.Items.Clear();
			this.cboUsuarios.Text = String.Empty;
			this.cboUsuarios.Items.Add(null, "[Seleccione...]");

			IList<Usuario> lista = Usuario.Listar(false); // SOLO LOS USUARIOS HABILITADOS
			foreach (Usuario usr in lista)
			{
				bool encontrado = false;
				foreach (Usuario usrAgregado in this.Rol.Usuarios)
				{
					if (usrAgregado != null && usrAgregado.Equals(usr))
					{
						encontrado = true;
						break;
					}
				}
				if (!encontrado)
					cboUsuarios.Items.Add(usr);				
			}
			this.cboUsuarios.SelectedIndex = 0;
		}
		private void AgregarMiembro()
		{
            try
            {
                Usuario user = this.cboUsuarios.Value as Usuario;
                if (user == null) { return; }
                this.Rol.Usuarios.Add(user);
                this.CargarComboUsuarios();
                this.grillaMiembros.DataBind();
            }
            catch (Exception ex)
            {
                Mensaje.Error(ex.Message, ex);
            }
		}
		private void QuitarMiembro()
		{
			if (this.grillaMiembros.ActiveRow == null) { return; }
			Usuario usr = this.grillaMiembros.ActiveRow.ListObject as Usuario;
			if (usr == null) { return; }
			if (Mensaje.Pregunta(String.Format("Está seguro que desea quitar del rol al usuario {0}?",usr.Logon)) != DialogResult.Yes) { return; }
			this.Rol.Usuarios.Remove(usr);			
			this.CargarComboUsuarios();
			this.grillaMiembros.DataBind();
		}

		private void grillaPrivilegios_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			UtilP.ConfigurarColumna(grillaPrivilegios, "Rol", false);
			UtilP.ConfigurarColumna(grillaPrivilegios, "Categoria", false);
			int i = 0;
			UltraGridColumn col = UtilP.ConfigurarColumna(grillaPrivilegios, "Privilegio", true, i++, "Privilegio", 200);
			col.SortIndicator = SortIndicator.Ascending;
			col.CellActivation = Activation.NoEdit;
			UtilP.ConfigurarColumna(this.grillaPrivilegios, "Alcance", true, i++, "Alcance", 80);

			this.grillaPrivilegios.DisplayLayout.Bands[0].Columns["Alcance"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
		}
		private void grillaPrivilegios_BeforeCellListDropDown(object sender, CancelableCellEventArgs e)
		{
			this.Rol.QuitarTodosLosPrivilegios();
		}
		private void grillaPrivilegios_InitializeRow(object sender, InitializeRowEventArgs e)
		{
			RolPrivilegio rolPrv = e.Row.ListObject as RolPrivilegio;
			if (rolPrv != null)
			{
				e.Row.Cells["Categoria"].Value = rolPrv.Privilegio.Categoria;
				e.Row.Cells["Alcance"].ValueList = this.vlAlcanceBasico;	
			}
		}
		private void comboCategorias_SelectionChangeCommitted(object sender, EventArgs e)
		{
			this.grillaPrivilegios.DisplayLayout.Bands[0].ColumnFilters["Categoria"].FilterConditions.Clear();
			if (!this.comboCategorias.Value.Equals("[Todas]"))
			{
				this.grillaPrivilegios.DisplayLayout.Bands[0].ColumnFilters["Categoria"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith, this.comboCategorias.Value);
			}
		}
		private void ultraCheckEditor1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.grillaPrivilegios.DisplayLayout.Bands[0].ColumnFilters["Alcance"].FilterConditions.Clear();
			if (this.ultraCheckEditor1.Checked)
			{
				this.grillaPrivilegios.DisplayLayout.Bands[0].ColumnFilters["Alcance"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, Alcances.Denegado.ToString());
			}
		}
		private void botonDenegarTodos_Click(object sender, System.EventArgs e)
		{
			this.Rol.QuitarTodosLosPrivilegios();
			foreach (UltraGridRow r in this.grillaPrivilegios.Rows)
			{
				if (!r.IsFilteredOut)
				{
					RolPrivilegio rolPrv = r.ListObject as RolPrivilegio;
					if (rolPrv != null)
					{
						rolPrv.Alcance = Alcances.Denegado;
					}
				}
			}
			this.grillaPrivilegios.DataBind();
		}
		private void botonConcederTodos_Click(object sender, System.EventArgs e)
		{
			this.Rol.QuitarTodosLosPrivilegios();
			foreach (UltraGridRow r in this.grillaPrivilegios.Rows)
			{
				if (!r.IsFilteredOut)
				{
					RolPrivilegio rolPrv = r.ListObject as RolPrivilegio;
					if (rolPrv != null)
					{
						rolPrv.Alcance = Alcances.Total;
					}
				}
			}
			this.grillaPrivilegios.DataBind();
		
		}
		private void grillaMiembros_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			foreach (UltraGridColumn col in this.grillaMiembros.DisplayLayout.Bands[0].Columns)
			{
				col.Hidden = true;
			}
			int i=0;
			UtilP.ConfigurarColumna(this.grillaMiembros, "Logon", true, i++, "Logon", 60);
			UtilP.ConfigurarColumna(this.grillaMiembros, "NombreCompleto", true, i++, "Nombre",120 );
			UtilP.ConfigurarColumna(this.grillaMiembros, "Area", true, i++, "Area", 120);
			UtilP.ConfigurarColumna(this.grillaMiembros, "Habilitado", true, i++, "Habilitado", 80);

			this.grillaMiembros.DisplayLayout.Bands[0].Columns["Logon"].SortIndicator = SortIndicator.Ascending;

		}
		private void ckSoloUsuariosActivos_CheckedChanged(object sender, EventArgs e)
		{
            this.grillaMiembros.DisplayLayout.Bands[0].ColumnFilters["Habilitado"].FilterConditions.Clear();
			if (this.ckSoloUsuariosActivos.Checked)
                this.grillaMiembros.DisplayLayout.Bands[0].ColumnFilters["Habilitado"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, false);
		}
		private void btnAgregarUsuario_Click(object sender, EventArgs e)
		{
            AgregarMiembro();
		}

        private void cboUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AgregarMiembro();
        }
		private void btnQuitarUsuario_Click(object sender, EventArgs e)
		{
			try
			{
				QuitarMiembro();
			}
			catch (Exception ex)
			{
				Mensaje.Error(ex.Message, ex);
			}
		}
		private void cboUsuarios_AfterExitEditMode(object sender, EventArgs e)
		{
            if (cboUsuarios.SelectedItem == null)
			{
				this.cboUsuarios.SelectedIndex = 0;
			}
		}
		private void grillaMiembros_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.grillaMiembros.ActiveRow == null)
			{ return; }
			try
			{
				if (e.KeyCode == Keys.Delete)
				{
					this.QuitarMiembro();
				}
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
	}
}

