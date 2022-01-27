using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{
	public class FormResumenPrivilegios : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid grillaPrivilegios;
		private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor comboCategorias;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
		private Infragistics.Win.UltraWinGrid.UltraGrid grillaMiembros;
		private Infragistics.Win.Misc.UltraButton botonCerrar;
		private System.ComponentModel.IContainer components = null;

		public FormResumenPrivilegios( Usuario usuario )
		{
			InitializeComponent();

			_usuario = usuario;

			this.grillaPrivilegios.InitializeLayout += new InitializeLayoutEventHandler(grillaPrivilegios_InitializeLayout);
			this.grillaPrivilegios.InitializeRow+=new InitializeRowEventHandler(grillaPrivilegios_InitializeRow);
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormResumenPrivilegios));
			this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
			this.grillaMiembros = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ultraCheckEditor1 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.comboCategorias = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.grillaPrivilegios = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.botonCerrar = new Infragistics.Win.Misc.UltraButton();
			this.ultraTabPageControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grillaMiembros)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboCategorias)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grillaPrivilegios)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraTabPageControl3
			// 
			this.ultraTabPageControl3.Controls.Add(this.grillaMiembros);
			this.ultraTabPageControl3.Location = new System.Drawing.Point(1, 23);
			this.ultraTabPageControl3.Name = "ultraTabPageControl3";
			this.ultraTabPageControl3.Size = new System.Drawing.Size(470, 358);
			// 
			// grillaMiembros
			// 
			this.grillaMiembros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grillaMiembros.Cursor = System.Windows.Forms.Cursors.Default;
			this.grillaMiembros.DataSource = this.ultraDataSource1;
			appearance1.BackColor = System.Drawing.SystemColors.Window;
			this.grillaMiembros.DisplayLayout.Appearance = appearance1;
            this.grillaMiembros.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
			this.grillaMiembros.DisplayLayout.MaxBandDepth = 1;
			this.grillaMiembros.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.grillaMiembros.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.grillaMiembros.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			this.grillaMiembros.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			this.grillaMiembros.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.grillaMiembros.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
			appearance2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.grillaMiembros.DisplayLayout.Override.RowAppearance = appearance2;
			this.grillaMiembros.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			this.grillaMiembros.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
			this.grillaMiembros.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaMiembros.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaMiembros.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			this.grillaMiembros.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.grillaMiembros.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.grillaMiembros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grillaMiembros.Location = new System.Drawing.Point(16, 24);
			this.grillaMiembros.Name = "grillaMiembros";
			this.grillaMiembros.Size = new System.Drawing.Size(440, 324);
			this.grillaMiembros.TabIndex = 3;
			this.grillaMiembros.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnUpdate;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.ultraCheckEditor1);
			this.groupBox1.Controls.Add(this.comboCategorias);
			this.groupBox1.Controls.Add(this.grillaPrivilegios);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(440, 424);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Privilegios";
			// 
			// ultraCheckEditor1
			// 
			this.ultraCheckEditor1.Location = new System.Drawing.Point(312, 24);
			this.ultraCheckEditor1.Name = "ultraCheckEditor1";
			this.ultraCheckEditor1.TabIndex = 1;
			this.ultraCheckEditor1.Text = "Ver sólo permitidos";
			this.ultraCheckEditor1.CheckedChanged += new System.EventHandler(this.ultraCheckEditor1_CheckedChanged);
			// 
			// comboCategorias
			// 
			this.comboCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboCategorias.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.comboCategorias.Location = new System.Drawing.Point(16, 24);
			this.comboCategorias.Name = "comboCategorias";
			this.comboCategorias.Size = new System.Drawing.Size(278, 21);
			this.comboCategorias.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
			this.comboCategorias.TabIndex = 0;
			// 
			// grillaPrivilegios
			// 
			this.grillaPrivilegios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grillaPrivilegios.Cursor = System.Windows.Forms.Cursors.Default;
			this.grillaPrivilegios.DataSource = this.ultraDataSource1;
			appearance3.BackColor = System.Drawing.SystemColors.Window;
			this.grillaPrivilegios.DisplayLayout.Appearance = appearance3;
            this.grillaPrivilegios.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
			this.grillaPrivilegios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.grillaPrivilegios.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.grillaPrivilegios.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			this.grillaPrivilegios.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			this.grillaPrivilegios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.grillaPrivilegios.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
			this.grillaPrivilegios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			appearance4.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.grillaPrivilegios.DisplayLayout.Override.RowAppearance = appearance4;
			this.grillaPrivilegios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			this.grillaPrivilegios.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
			this.grillaPrivilegios.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaPrivilegios.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.grillaPrivilegios.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			this.grillaPrivilegios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.grillaPrivilegios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.grillaPrivilegios.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
			this.grillaPrivilegios.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.grillaPrivilegios.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grillaPrivilegios.Location = new System.Drawing.Point(16, 56);
			this.grillaPrivilegios.Name = "grillaPrivilegios";
			this.grillaPrivilegios.Size = new System.Drawing.Size(408, 360);
			this.grillaPrivilegios.TabIndex = 2;
			// 
			// botonCerrar
			// 
			this.botonCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.botonCerrar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonCerrar.Location = new System.Drawing.Point(376, 432);
			this.botonCerrar.Name = "botonCerrar";
			this.botonCerrar.TabIndex = 3;
			this.botonCerrar.Text = "Cerrar";
			this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
			// 
			// FormResumenPrivilegios
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.botonCerrar;
			this.ClientSize = new System.Drawing.Size(458, 464);
			this.Controls.Add(this.botonCerrar);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormResumenPrivilegios";
			this.ShowInTaskbar = false;
			this.Load += new System.EventHandler(this.FormResumenPrivilegios_Load);
			this.ultraTabPageControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grillaMiembros)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboCategorias)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grillaPrivilegios)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private Usuario _usuario;
		private ValueList vlAlcanceFull = null;
		private ValueList vlAlcanceBasico = null;
		private Image imagenPermitido = null;
		private Image imagenDenegado = null;

		private void FormResumenPrivilegios_Load(object sender, System.EventArgs e)
		{
			this.Text = "Resumen de privilegios del usuario: " + _usuario.Logon;

			this.imagenPermitido = UtilP.TraerRecurso("ImagenPrivilegioConcedido") as Image;
			this.imagenDenegado = UtilP.TraerRecurso("ImagenPrivilegioDenegado") as Image;
			
			//inicializaciones varias
			this.CargarValueLists();
			this.CargarComboCategorias();
			this.grillaPrivilegios.DataSource = Usuario.ListarResumenPrivilegios(_usuario);
			if (this.grillaPrivilegios.Rows.Count > 0)
			{
				this.grillaPrivilegios.Rows[0].Selected = true;
				this.grillaPrivilegios.Rows[0].Activate();
			}
			this.comboCategorias.SelectedIndex = 0;

		}

		private void grillaPrivilegios_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			UtilP.ConfigurarColumna(this.grillaPrivilegios, "Categoria", false);
			UtilP.ConfigurarColumna(this.grillaPrivilegios, "Privilegio", true, 0, "Privilegio", 200);
			UtilP.ConfigurarColumna(this.grillaPrivilegios, "Alcance", true, 1, "Alcance", 80);

			this.grillaPrivilegios.DisplayLayout.Bands[0].Columns["Privilegio"].SortIndicator = SortIndicator.Ascending;
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
				this.grillaPrivilegios.DisplayLayout.Bands[0].ColumnFilters["Categoria"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, this.comboCategorias.Value);
			}
		}

		private void ultraCheckEditor1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.grillaPrivilegios.DisplayLayout.Bands[0].ColumnFilters["Alcance"].FilterConditions.Clear();
			if (this.ultraCheckEditor1.Checked)
			{
				this.grillaPrivilegios.DisplayLayout.Bands[0].ColumnFilters["Alcance"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, Alcances.Denegado);
			}
		}

		private void botonCerrar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}

