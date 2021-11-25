using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MarDevs.OC.Win
{
	/// <summary>
	/// Descripción breve de selectorBase.
	/// </summary>
	public class SelectorBase : UserControl
    {
        private IContainer components;

        public SelectorBase()
		{
			InitializeComponent();
            comboQueBuscar.KeyPress += new KeyPressEventHandler(comboQueBuscar_KeyPress);
		}

        private void comboQueBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

		/// <summary> 
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
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

		#region Código generado por el Diseñador de componentes
		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar 
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectorBase));
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			this.comboQueBuscar = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.comboQueBuscar)).BeginInit();
			this.SuspendLayout();
			// 
			// comboQueBuscar
			// 
			this.comboQueBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.comboQueBuscar.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
			this.comboQueBuscar.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.comboQueBuscar.Location = new System.Drawing.Point(91, 0);
			this.comboQueBuscar.MaxDropDownItems = 25;
			this.comboQueBuscar.Name = "comboQueBuscar";
			this.comboQueBuscar.Size = new System.Drawing.Size(194, 21);
			this.comboQueBuscar.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
			this.comboQueBuscar.TabIndex = 1;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.contextMenuStrip1.ShowImageMargin = false;
			this.contextMenuStrip1.Size = new System.Drawing.Size(36, 4);
			// 
			// ultraButton1
			// 
			this.ultraButton1.AcceptsFocus = false;
			appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
			this.ultraButton1.Appearance = appearance1;
			this.ultraButton1.AutoSize = true;
			this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Borderless;
			this.ultraButton1.Location = new System.Drawing.Point(67, 0);
			this.ultraButton1.Name = "ultraButton1";
			this.ultraButton1.Size = new System.Drawing.Size(18, 18);
			this.ultraButton1.TabIndex = 4;
			this.ultraButton1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.ultraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.ultraButton1.Visible = false;
			this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
			// 
			// ultraLabel1
			// 
			appearance2.BackColor = System.Drawing.Color.Transparent;
			appearance2.TextHAlignAsString = "Left";
			appearance2.TextVAlignAsString = "Middle";
			this.ultraLabel1.Appearance = appearance2;
			this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(61, 23);
			this.ultraLabel1.TabIndex = 5;
			this.ultraLabel1.Text = "Label";
			this.ultraLabel1.WrapText = false;
			this.ultraLabel1.Click += new System.EventHandler(this.ultraLabel1_Click);
			// 
			// selectorBase
			// 
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.ultraButton1);
			this.Controls.Add(this.comboQueBuscar);
			this.Controls.Add(this.ultraLabel1);
			this.Name = "selectorBase";
			this.Size = new System.Drawing.Size(292, 21);
			((System.ComponentModel.ISupportInitialize)(this.comboQueBuscar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

        protected internal Infragistics.Win.UltraWinEditors.UltraComboEditor comboQueBuscar;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private ContextMenuStrip contextMenuStrip1;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;

		private int _SeparacionLabelCombo = 0;
		public int SeparacionLabelCombo
		{
			get {return _SeparacionLabelCombo;}
			set
			{
				_SeparacionLabelCombo = value;
                ReposicionarControles();
			}
		}
		public int AnchoLabel
		{
			get
			{
				return this.ultraLabel1.Width;
			}
			set
			{
                this.ultraLabel1.Width = value;
                ReposicionarControles();
            }
		}
		public void AgregarLabel(string property, string descripcion)
		{
            ToolStripMenuItem tool = new ToolStripMenuItem(descripcion);
            tool.Tag = property;
            contextMenuStrip1.Items.Add(tool);
            tool.Click += new EventHandler(tool_Click);
            ultraButton1.Visible = contextMenuStrip1.Items.Count > 1;
            ultraLabel1.Text = contextMenuStrip1.Items[0].Text;
            ultraLabel1.Tag = contextMenuStrip1.Items[0].Tag;
        }
		
        public string LabelSeleccionado
		{
			get{return ultraLabel1.Tag as string;}
		}
		public object Value
		{
			get{return this.comboQueBuscar.Value;}
		}
        public bool SoloLectura
        {
            get { return this.comboQueBuscar.ReadOnly; }
            set { this.comboQueBuscar.ReadOnly = value; }

        }
		
        public void Limpiar()
		{
            Limpiar(0);
		}
		public void Limpiar(int posicionCombo)
		{
			if(posicionCombo < this.comboQueBuscar.Items.Count)
			{
				this.comboQueBuscar.SelectedIndex = posicionCombo;
			}
			else
			{
				this.comboQueBuscar.SelectedIndex = 0;
			}
		}
        public void AgregarLabel(string property)
        {
            AgregarLabel(property, property);
        }
        public void EliminarLabels()
        {
            contextMenuStrip1.Items.Clear();
        }
        private void ReposicionarControles()
        {
            this.ultraButton1.Left = ultraLabel1.Left + ultraLabel1.Width;
            this.comboQueBuscar.Left = ultraButton1.Left + ultraButton1.Width + _SeparacionLabelCombo;
            this.comboQueBuscar.Width = this.Width - ultraButton1.Left - ultraButton1.Width - _SeparacionLabelCombo - 1;
        }
		private void MostrarMenuContextual()
		{
			if (contextMenuStrip1.Items.Count > 1)
			{
				contextMenuStrip1.Show(ultraLabel1, 0, ultraLabel1.Height);
			}
		}


        private void ultraButton1_Click(object sender, EventArgs e)
        {
			MostrarMenuContextual();
        }
        private void ultraLabel1_Click(object sender, EventArgs e)
        {
			MostrarMenuContextual();
		}
        private void tool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = sender as ToolStripMenuItem;
            if (tool != null)
            {
                ultraLabel1.Text = tool.Text;
                ultraLabel1.Tag = tool.Tag;
            }
        }

	}
}
