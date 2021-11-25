using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MarDevs.OC.Core;
using System.Reflection;

namespace MarDevs.OC.Win
{
    public partial class FormProcesarAccion : Form
    {
        protected FormProcesarAccion() : this(null) { }
        public FormProcesarAccion(IList lista)
        {
            InitializeComponent();

            this._lista = lista;
        }

        protected IList _lista = new ArrayList();
        protected string _errorAlProcesar = "Se produjo un error al procesar uno de los Items.";
		protected string _errorDeValidacion = String.Empty;
        protected DataTable _erroresDeEjecucion = null;
        private Accion _accion;
		bool _finalizoProceso = false;
		public Accion Accion
		{
			get { return _accion; }
			set { _accion = value; }
		}
		public IList Lista
		{
			get { return _lista; }
			set { _lista = value; }
		}
			
        private void FormProcesarAccion_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) { return; }

            this.tareaProgressBar.Minimum = 0;
            this.tareaProgressBar.Step = 1;
            this.tareaProgressBar.Maximum = (this._lista == null) ? 0 : this._lista.Count;
            this.tareaProgressBar.Visible = (this._lista == null) ? false : (this._lista.Count > 1);

			if (_accion != null && !String.IsNullOrEmpty(_accion.Descripcion))
			{
				this.labelInfo.Text = _accion.Descripcion;
			}
        }

		protected virtual void ProcesarLista()
		{
			CrearDataTableErrores();

			if (this._lista == null || this._lista.Count == 0) { return; }

			foreach (object item in this._lista)
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					this.ProcesarItem(item);
				}
				catch (Exception ex)
				{
					//Si la excepcion sale de un llamado por reflection, tomamos la innerExcepcion con el detalle del error
					Exception excepcion ;
					if (ex is TargetInvocationException)
						excepcion = ex.InnerException;
					else
						excepcion = ex;
					//las SqlException internas son excepciones de los STORE y dan mensaje que queremos mostrar al usuario tal como son.
					if (excepcion.InnerException != null && excepcion.InnerException is System.Data.SqlClient.SqlException)
						excepcion = excepcion.InnerException;
                    //ALMACENAMOS EL ERROR PARA MOSTRARLO LUEGO.
					DataRow dr = _erroresDeEjecucion.NewRow();
                    dr["Item"] = item.ToString();
					dr["Mensaje"] = excepcion.Message;
					dr["Error"] = excepcion;
                    _erroresDeEjecucion.Rows.Add(dr);
					
					//PREGUNTAMOS SI DESEA CONTINUAR...
					//string texto = String.Format("Se ha producido un error al procesar el item {0}. Desea continuar procesando el resto?", item.ToString());
					//DialogResult resu = MessageBox.Show(texto, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
					//if (resu != DialogResult.Yes)
					//{
					//    break;
					//}
				}
				finally
				{
					this.tareaProgressBar.PerformStep();
					this.Cursor = Cursors.Default;
				}
			}
		}

		private void CrearDataTableErrores()
		{
			_erroresDeEjecucion = new DataTable();
			_erroresDeEjecucion.Columns.Add("Item", typeof(String));
			_erroresDeEjecucion.Columns.Add("Mensaje", typeof(String));
			_erroresDeEjecucion.Columns.Add("Error", typeof(Exception));
		}
        protected virtual void ProcesarItem(object item)
        {
			if (String.IsNullOrEmpty(_accion.MetodoMasivo))
				throw new NotImplementedException("Debe implementar 'ProcesarItem'.");

			MemberInfo[] miembros = item.GetType().GetMember(_accion.MetodoMasivo);
			if (miembros.Length == 0)
				throw new Exception("No se encuentra el metodo " + _accion.MetodoMasivo);
			MethodInfo info = miembros[0] as MethodInfo;
			if (info != null)
			{
				object resu = info.Invoke(item, null);
				if (!(resu is Boolean))
				{
					return;
				}
				if ((bool)resu == false)
				{
					return;
				}
			}
        }
		protected virtual bool ValidarIngreso()
		{
			return (this._errorDeValidacion.Length == 0);
		}

        protected virtual void aceptarButton_Click(object sender, EventArgs e)
        {
			if (!this.ValidarIngreso())
			{
				Mensaje.Advertencia(this._errorDeValidacion);
				return;
			}
            this.ProcesarLista();
			if (_erroresDeEjecucion != null && _erroresDeEjecucion.Rows.Count > 0)
			{
                    String _errores = String.Empty;
					Exception excepcion;
                    for (int i = 0; i < _erroresDeEjecucion.Rows.Count; i++)
                    {
						excepcion = _erroresDeEjecucion.Rows[i]["Error"] as Exception;
						//solo agregarla si no es una ExcepcionNegocios
						if (excepcion != null && !(excepcion is ExcepcionNegocios))
						{
							_errores += String.Format("\r\n {0} \r\n", (_erroresDeEjecucion.Rows[i]["Error"] as Exception).ToString());
						}
                    }
					//solo publicar si hay errores que no son ExcepcionNegocios
					if (!String.IsNullOrEmpty(_errores))
					{
						Exception ex = new Exception(_errores);
						AdministradorDeExcepciones.Publicar(ex);
					}
					//mostrar los errores
                    FormProcesarAccionError errores = new FormProcesarAccionError(_erroresDeEjecucion);
                    errores.ShowDialog();
			}
			_finalizoProceso = true;
			AccionesDespuesDeFinalizar();
        }

		public virtual void AccionesDespuesDeFinalizar()
		{
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
			this.DialogResult = _finalizoProceso? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }
    }
}