using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarDevs.Gestion.Win
{
    
    public partial class FormProcesarAccionError : Form
    {

        private const int _Abierto = 115;
        private const int _Cerrado = 180;

        private DataTable _listadeerrores = null;
		public FormProcesarAccionError(DataTable lista)
        {
            InitializeComponent();
            _listadeerrores = lista;
            grillaErrores.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(grillaErrores_InitializeLayout);
        }

        void grillaErrores_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UtilP.ConfigurarColumna(grillaErrores, "Error", false);
        }

        private void FormProcesarAccionError_Load(object sender, EventArgs e)
        {
            grillaErrores.DataSource = _listadeerrores;
            splitter1.SplitPosition = splitter1.Top + textError.Height + 5;
          
        }


        private void grillaErrores_AfterRowActivate(object sender, EventArgs e)
        {
            if (grillaErrores.ActiveRow != null)
            {
                DataRowView dr = grillaErrores.ActiveRow.ListObject as DataRowView;
                if (dr != null)
                {
                    this.textError.Text = dr.Row["Error"].ToString();
                }
            }
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (BtnDetalle.Text == "Detalle")
            {
                splitter1.SplitPosition = _Abierto;
                splitter1.Refresh();
                BtnDetalle.Text = "Ocultar";
            }
            else
            {
                splitter1.SplitPosition = splitter1.Top+textError.Height+5;
                splitter1.Refresh();
                BtnDetalle.Text = "Detalle";

            }
        }

        private void FormProcesarAccionError_Resize(object sender, EventArgs e)
        {
            if (BtnDetalle.Text =="Detalle")
            splitter1.SplitPosition = splitter1.Top + textError.Height + 5;
        }

		private void btnExportar_Click(object sender, EventArgs e)
		{
			App.ExportarGrillaAExcel(grillaErrores);
		}
    }
}