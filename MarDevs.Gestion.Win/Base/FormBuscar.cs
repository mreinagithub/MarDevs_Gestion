using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

namespace MarDevs.Gestion.Win
{
	/// <summary>
	/// Descripción breve de FormBuscarEnAgenda.
	/// </summary>
	public class FormBuscar : System.Windows.Forms.Form
	{
		private UltraGrid ultraGrid1;
		private int cantidadResultadosYaVistos = 0;

		private Infragistics.Win.UltraWinEditors.UltraTextEditor textBuscar;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton botonCerrar;
		private Infragistics.Win.Misc.UltraButton botonBuscarSiguiente;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor comboColumnas;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormBuscar(UltraGrid ultraGrid)
		{
			InitializeComponent();
			this.ultraGrid1 = ultraGrid;
			this.textBuscar.KeyPress+=new KeyPressEventHandler(textBuscar_KeyPress);
			this.textBuscar.ValueChanged+=new EventHandler(textBuscar_ValueChanged);
			this.comboColumnas.ValueChanged+=new EventHandler(comboColumnas_ValueChanged);
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

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormBuscar));
			this.botonCerrar = new Infragistics.Win.Misc.UltraButton();
			this.botonBuscarSiguiente = new Infragistics.Win.Misc.UltraButton();
			this.textBuscar = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.comboColumnas = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.textBuscar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboColumnas)).BeginInit();
			this.SuspendLayout();
			// 
			// botonCerrar
			// 
			this.botonCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.botonCerrar.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonCerrar.Location = new System.Drawing.Point(288, 54);
			this.botonCerrar.Name = "botonCerrar";
			this.botonCerrar.Size = new System.Drawing.Size(117, 24);
			this.botonCerrar.TabIndex = 4;
			this.botonCerrar.Text = "Cerrar";
			this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
			// 
			// botonBuscarSiguiente
			// 
			this.botonBuscarSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.botonBuscarSiguiente.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.botonBuscarSiguiente.Location = new System.Drawing.Point(288, 27);
			this.botonBuscarSiguiente.Name = "botonBuscarSiguiente";
			this.botonBuscarSiguiente.Size = new System.Drawing.Size(117, 24);
			this.botonBuscarSiguiente.TabIndex = 3;
			this.botonBuscarSiguiente.Text = "Buscar siguiente";
			this.botonBuscarSiguiente.Click += new System.EventHandler(this.botonBuscarSiguiente_Click);
			// 
			// textBuscar
			// 
			this.textBuscar.Location = new System.Drawing.Point(72, 27);
			this.textBuscar.Name = "textBuscar";
			this.textBuscar.Size = new System.Drawing.Size(207, 21);
			this.textBuscar.TabIndex = 1;
			// 
			// ultraLabel1
			// 
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel1.Appearance = appearance1;
			this.ultraLabel1.Location = new System.Drawing.Point(18, 27);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(54, 23);
			this.ultraLabel1.TabIndex = 0;
			this.ultraLabel1.Text = "Buscar:";
			// 
			// comboColumnas
			// 
			this.comboColumnas.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.comboColumnas.Location = new System.Drawing.Point(72, 54);
			this.comboColumnas.MaxDropDownItems = 15;
			this.comboColumnas.Name = "comboColumnas";
			this.comboColumnas.Size = new System.Drawing.Size(207, 21);
			this.comboColumnas.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
			this.comboColumnas.TabIndex = 2;
			// 
			// ultraLabel2
			// 
			appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel2.Appearance = appearance2;
			this.ultraLabel2.Location = new System.Drawing.Point(18, 54);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(63, 23);
			this.ultraLabel2.TabIndex = 5;
			this.ultraLabel2.Text = "Columnas:";
			// 
			// FormBuscar
			// 
			this.AcceptButton = this.botonBuscarSiguiente;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.botonCerrar;
			this.ClientSize = new System.Drawing.Size(408, 103);
			this.Controls.Add(this.comboColumnas);
			this.Controls.Add(this.botonBuscarSiguiente);
			this.Controls.Add(this.textBuscar);
			this.Controls.Add(this.botonCerrar);
			this.Controls.Add(this.ultraLabel1);
			this.Controls.Add(this.ultraLabel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormBuscar";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Buscar";
			this.Load += new System.EventHandler(this.FormBuscar_Load);
			((System.ComponentModel.ISupportInitialize)(this.textBuscar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboColumnas)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void botonBuscarSiguiente_Click(object sender, System.EventArgs e)
		{
				#region BUSQUEDA EN GRILLA

				UltraGridRow row = this.BuscarSiguienteRow(this.textBuscar.Text);
				if (row != null)
				{
					this.ultraGrid1.Selected.Rows.Clear();
					row.Selected = true;
					row.Activate();
				}
				else if(this.cantidadResultadosYaVistos == 0)
				{
					Mensaje.Informacion("No se ha encontrado el texto ingresado.");
				}
				else
				{
					Mensaje.Informacion("Se ha llegado al final de la búsqueda.");
					this.cantidadResultadosYaVistos = 0;
				}
				#endregion
		}

		private void botonCerrar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		private UltraGridRow BuscarSiguienteRow(string texto)
		{
			int encontrados = 0;
			string key = this.comboColumnas.Value as string;
			foreach(UltraGridRow row in this.ultraGrid1.Rows)
			{
				if (row.IsFilteredOut){continue;}
				if (key != null && key.Length > 0)
				{
					//BUSCAR SOLO EN LA CELDA SELECCIONADA

					if (row.Cells[key].Text != null
						&& row.Cells[key].Text.ToUpper().IndexOf(texto.ToUpper())>=0)
					{
						encontrados++;
						if (encontrados > this.cantidadResultadosYaVistos)
						{
							this.cantidadResultadosYaVistos++;
							row.Cells[key].Activate();
							//celda.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
							//celda.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
							return row;
						}
					}


				}
				else
				{
					//BUSCAR EN TODAS LAS CELDAS
					foreach (UltraGridCell celda in row.Cells)
					{
						if (celda.Column.IsVisibleInLayout 
							&& celda.Text != null
							&& celda.Text.ToUpper().IndexOf(texto.ToUpper())>=0)
						{
							encontrados++;
							if (encontrados > this.cantidadResultadosYaVistos)
							{
								this.cantidadResultadosYaVistos++;
								celda.Activate();
								//celda.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
								//celda.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
								return row;
							}
						}
					}
				}
			}
			return null;

		}

		private void FormBuscar_Load(object sender, System.EventArgs e)
		{
			foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
			{
				if (col.IsVisibleInLayout)
				{
					this.comboColumnas.Items.Add(col.Key, col.Header.Caption.Replace(Environment.NewLine, " "));
				}
			}
			this.comboColumnas.Items.Add(null, "[Todas las columnas]");
		}
		private void textBuscar_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Keys)e.KeyChar == Keys.Enter)
			{
				this.botonBuscarSiguiente_Click(this.botonBuscarSiguiente, new EventArgs());
			}
		}

		private void textBuscar_ValueChanged(object sender, EventArgs e)
		{
			this.cantidadResultadosYaVistos = 0;
		}
		private void comboColumnas_ValueChanged(object sender, EventArgs e)
		{
			this.cantidadResultadosYaVistos = 0;
		}
	}
}
