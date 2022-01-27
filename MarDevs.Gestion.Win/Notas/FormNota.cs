using System;
using System.Windows.Forms;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{
    public partial class FormNota : Form
    {
        #region Constructor(es)
        
		private FormNota() : this(null)
        { 
		}
        private FormNota(Nota nota) : this(nota, false)
        { 
		}
        public FormNota(Nota nota, Boolean puedeEditar)
        {
            InitializeComponent();

            this._nota = nota;
            this._puedeEditar = puedeEditar;
        }

        #endregion

        private Nota _nota = null;
        private bool _puedeEditar = false;
        private string _descripcionEntidad = String.Empty;

        public string DescripcionEntidad
        {
            set
            {
                if (value == null)
                { return; }

                this._descripcionEntidad = value.Trim();

                if (this._descripcionEntidad.Length > 0)
                {
                    this.Text = String.Format("Nota - {0}", this._descripcionEntidad);
                }
            }
        }
		//public bool PuedeEditar
		//{
		//    get { return _puedeEditar; }
		//    set { _puedeEditar = value; }
		//}

        private void FormNota_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) { return; }

			try
			{
				if (this._nota == null)
				{
					throw new ExcepcionNegocios("El formulario no puede abrirse: la Nota no puede ser Nula.");
				}
				//combo visibilidad
				this.cmbConfidencial.Items.Add(true, "CONFIDENCIAL");
				this.cmbConfidencial.Items.Add(false, "PUBLICA");

				bool puedeVerConfidenciales = ConfigBL.ticket.VerificarPrivilegio(PRV.NOTA_VER_CONFIDENCIALES);
				bool puedeMarcarConfidenciales = ConfigBL.ticket.VerificarPrivilegio(PRV.NOTA_MARCAR_CONFIDENCIALES);
				bool esElCreador = false;
				if (_nota.CreadoPor != null && _nota.CreadoPor.Id == ConfigBL.ticket.UsuarioID)
				{
					esElCreador = true;
				}
				if (!puedeVerConfidenciales && _nota.Confidencial && !esElCreador)
				{
					throw new ExcepcionNegocios("No tiene Privilegio para ver esta nota.");
				}
				//ocultar controles de confidencialidad
				//no queremos q siquiera sepan q el sistema tiene notas q pueden ser consideradas confidenciales.
				this.lblVisibilidad.Visible = (puedeVerConfidenciales || puedeMarcarConfidenciales);
				this.cmbConfidencial.Visible = (puedeVerConfidenciales || puedeMarcarConfidenciales);
				this.cmbConfidencial.Enabled = (puedeVerConfidenciales || puedeMarcarConfidenciales);
				this.cmbConfidencial.ReadOnly = !puedeMarcarConfidenciales;
				//bindear valores
				this.notaText.Text = this._nota.Texto.Trim();
				this.cmbConfidencial.Value = _nota.Confidencial;
				//status bar
				this.ultraStatusBar1.Text = String.Format("Creada el {0:dd/MM/yyyy HH:mm} por el usuario {1}", _nota.CreadoEl, _nota.CreadoPor);

				//ajustar el valor de _puedeEditar para las notas nuevas, ya que siempre son editables.
				if (_nota.EsNuevo())
				{
					_puedeEditar = true;
				}
				this.notaText.ReadOnly = (!_puedeEditar);
				this.aceptarButton.Visible = (_puedeEditar || puedeMarcarConfidenciales); //en cualquiera de los dos casos deberá poder guardar la nota.
				this.cancelarButton.Text = (_puedeEditar || puedeMarcarConfidenciales) ? "Cancelar" : "Cerrar";

				if (_puedeEditar)
				{
					this.notaText.Select();
				}
				else
				{
					this.cancelarButton.Select();
				}

			}
			catch ( Exception ex)
			{
				Mensaje.MostrarError(ex);
				this.Close();
			}
		}

        private void aceptarButton_Click(object sender, EventArgs e)
        {
			try
			{
				if (String.IsNullOrEmpty(this.notaText.Text.Trim()))
				{
					Mensaje.Informacion("Debe ingresar texto para esta Nota");
				}
				else
				{
					this._nota.Texto = this.notaText.Text.Trim();
					this._nota.Confidencial = Convert.ToBoolean(this.cmbConfidencial.Value);
					this._nota.Guardar();
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}