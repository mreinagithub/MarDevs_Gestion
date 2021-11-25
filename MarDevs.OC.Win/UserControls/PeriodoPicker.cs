using System;
using MarDevs.OC.Core;

namespace MarDevs.OC.Win
{
	public class PeriodoPicker : System.Windows.Forms.UserControl
	{
		private Periodo _Periodo;

		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtHasta;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDesde;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor comboPeriodo;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtHoraDesde;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtHoraHasta;

		private System.ComponentModel.Container components = null;

		public PeriodoPicker()
		{
			InitializeComponent();
			//inicializar combo periodo
			this.comboPeriodo.Items.Clear();
			this.comboPeriodo.Items.Add("Hoy", "Hoy");
			this.comboPeriodo.Items.Add("SemanaActual", "Semana Actual");
			this.comboPeriodo.Items.Add("MesActual", "Mes Actual");
			this.comboPeriodo.Items.Add("MesAnterior", "Mes Anterior");
			this.comboPeriodo.Items.Add("Personalizado", "Personalizado");

			this.comboPeriodo.SelectionChanged +=new EventHandler(comboPeriodo_SelectionChanged);
//			this.txtDesde.ValueChanged +=new EventHandler(txtDesde_ValueChanged);
//			this.txtHasta.ValueChanged+=new EventHandler(txtHasta_ValueChanged);
//			this.txtHoraDesde.ValueChanged+=new EventHandler(txtHoraDesde_ValueChanged);
//			this.txtHoraHasta.ValueChanged+=new EventHandler(txtHoraHasta_ValueChanged);

			//setear valor inicial
			_Periodo = Periodo.Hoy();
			this.comboPeriodo.SelectedIndex = 0;
		}


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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.txtHasta = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.txtDesde = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.comboPeriodo = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.txtHoraDesde = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.txtHoraHasta = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			((System.ComponentModel.ISupportInitialize)(this.txtHasta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDesde)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboPeriodo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHoraDesde)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHoraHasta)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraLabel5
			// 
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel5.Appearance = appearance1;
			this.ultraLabel5.Location = new System.Drawing.Point(0, 48);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.Size = new System.Drawing.Size(40, 23);
			this.ultraLabel5.TabIndex = 12;
			this.ultraLabel5.Text = "Hasta:";
			// 
			// txtHasta
			// 
			this.txtHasta.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
			this.txtHasta.Enabled = false;
			this.txtHasta.Location = new System.Drawing.Point(48, 48);
			this.txtHasta.MaskInput = "{LOC}dd/mm/yyyy";
			this.txtHasta.Name = "txtHasta";
			this.txtHasta.ReadOnly = true;
			this.txtHasta.Size = new System.Drawing.Size(80, 21);
			this.txtHasta.TabIndex = 15;
			this.txtHasta.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextSection;
			// 
			// txtDesde
			// 
			this.txtDesde.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
			this.txtDesde.Enabled = false;
			this.txtDesde.Location = new System.Drawing.Point(48, 24);
			this.txtDesde.MaskInput = "{LOC}dd/mm/yyyy";
			this.txtDesde.Name = "txtDesde";
			this.txtDesde.ReadOnly = true;
			this.txtDesde.Size = new System.Drawing.Size(80, 21);
			this.txtDesde.TabIndex = 14;
			this.txtDesde.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextSection;
			// 
			// ultraLabel4
			// 
			appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel4.Appearance = appearance2;
			this.ultraLabel4.Location = new System.Drawing.Point(0, 24);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.Size = new System.Drawing.Size(40, 23);
			this.ultraLabel4.TabIndex = 11;
			this.ultraLabel4.Text = "Desde:";
			// 
			// ultraLabel2
			// 
			appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel2.Appearance = appearance3;
			this.ultraLabel2.Location = new System.Drawing.Point(0, 0);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(48, 23);
			this.ultraLabel2.TabIndex = 10;
			this.ultraLabel2.Text = "Período:";
			// 
			// comboPeriodo
			// 
			this.comboPeriodo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.comboPeriodo.Location = new System.Drawing.Point(48, 0);
			this.comboPeriodo.Name = "comboPeriodo";
			this.comboPeriodo.Size = new System.Drawing.Size(160, 21);
			this.comboPeriodo.TabIndex = 13;
			// 
			// txtHoraDesde
			// 
			this.txtHoraDesde.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
			this.txtHoraDesde.Enabled = false;
			this.txtHoraDesde.Location = new System.Drawing.Point(136, 24);
			this.txtHoraDesde.MaskInput = "{LOC}hh:mm:ss";
			this.txtHoraDesde.Name = "txtHoraDesde";
			this.txtHoraDesde.ReadOnly = true;
			this.txtHoraDesde.Size = new System.Drawing.Size(72, 21);
			this.txtHoraDesde.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
			this.txtHoraDesde.TabIndex = 16;
			// 
			// txtHoraHasta
			// 
			this.txtHoraHasta.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
			this.txtHoraHasta.Enabled = false;
			this.txtHoraHasta.Location = new System.Drawing.Point(136, 48);
			this.txtHoraHasta.MaskInput = "{LOC}hh:mm:ss";
			this.txtHoraHasta.Name = "txtHoraHasta";
			this.txtHoraHasta.ReadOnly = true;
			this.txtHoraHasta.Size = new System.Drawing.Size(72, 21);
			this.txtHoraHasta.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
			this.txtHoraHasta.TabIndex = 17;
			// 
			// PeriodoPicker
			// 
			this.Controls.Add(this.txtHoraHasta);
			this.Controls.Add(this.txtHoraDesde);
			this.Controls.Add(this.ultraLabel5);
			this.Controls.Add(this.txtHasta);
			this.Controls.Add(this.txtDesde);
			this.Controls.Add(this.ultraLabel4);
			this.Controls.Add(this.ultraLabel2);
			this.Controls.Add(this.comboPeriodo);
			this.Name = "PeriodoPicker";
			this.Size = new System.Drawing.Size(208, 72);
			((System.ComponentModel.ISupportInitialize)(this.txtHasta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDesde)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboPeriodo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHoraDesde)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHoraHasta)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public Periodo PeriodoSeleccionado
		{
			get
			{
				this.RecalcularPeriodo();
                return _Periodo;
			}
		}


		private void comboPeriodo_SelectionChanged(object sender, EventArgs e)
		{
				if ( Convert.ToString(comboPeriodo.Value) == "Personalizado" )
				{
					this.txtDesde.ReadOnly = false;
					this.txtHasta.ReadOnly = false;
					this.txtHoraDesde.ReadOnly = false;
					this.txtHoraHasta.ReadOnly = false;
					this.txtDesde.Enabled = true;
					this.txtHoraDesde.Enabled = true;
					this.txtHasta.Enabled = true;
					this.txtHoraHasta.Enabled = true;
				}
				else
				{
					this.txtDesde.ReadOnly = true;
					this.txtHasta.ReadOnly = true;
					this.txtHoraDesde.ReadOnly = true;
					this.txtHoraHasta.ReadOnly = true;
					this.txtDesde.Enabled = false;
					this.txtHasta.Enabled = false;
					this.txtHoraDesde.Enabled = false;
					this.txtHoraHasta.Enabled = false;

					switch ( Convert.ToString(comboPeriodo.Value) )
					{
						case "Hoy":
							_Periodo = Periodo.Hoy();
							break;
						case "SemanaActual":
							_Periodo = Periodo.SemanaActual();
							break;
						case "MesActual":
							_Periodo = Periodo.MesActual();
							break;
						case "MesAnterior":
							_Periodo = Periodo.MesAnterior();
							break;
					}
					this.txtDesde.DateTime = _Periodo.Desde;
					this.txtHasta.DateTime = _Periodo.Hasta;
					this.txtHoraDesde.DateTime = _Periodo.Desde;
					this.txtHoraHasta.DateTime = _Periodo.Hasta;
				}
		}

//		private void txtDesde_ValueChanged(object sender, EventArgs e)
//		{
//			this.RecalcularPeriodo();
//		}
//
//		private void txtHasta_ValueChanged(object sender, EventArgs e)
//		{
//			this.RecalcularPeriodo();
//		}
//
//		private void txtHoraDesde_ValueChanged(object sender, EventArgs e)
//		{
//			this.RecalcularPeriodo();
//		}
//
//		private void txtHoraHasta_ValueChanged(object sender, EventArgs e)
//		{
//			this.RecalcularPeriodo();
//		}
//
		private void RecalcularPeriodo()
		{
			DateTime dde = new DateTime(this.txtDesde.DateTime.Year,
				this.txtDesde.DateTime.Month,
				this.txtDesde.DateTime.Day,
				this.txtHoraDesde.DateTime.Hour,
				this.txtHoraDesde.DateTime.Minute,
				this.txtHoraDesde.DateTime.Second);
			_Periodo.Desde = dde;

			DateTime hta = new DateTime(this.txtHasta.DateTime.Year,
				this.txtHasta.DateTime.Month,
				this.txtHasta.DateTime.Day,
				this.txtHoraHasta.DateTime.Hour,
				this.txtHoraHasta.DateTime.Minute,
				this.txtHoraHasta.DateTime.Second);
			_Periodo.Hasta = hta;


		}
	}
}
