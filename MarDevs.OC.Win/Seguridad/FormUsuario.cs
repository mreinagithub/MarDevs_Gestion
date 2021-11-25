using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using MarDevs.OC.Core;
using System.Collections.Generic;
using System.Linq;

namespace MarDevs.OC.Win
{
	public partial class FormUsuario : EditorBase
	{
        Usuario Entidad { get { return obj as Usuario; } }
        public FormUsuario(Usuario usuario): base(usuario)
		{
			InitializeComponent();

            this.checkUsaVigenciaPassDefault.CheckedChanged += new EventHandler(checkUsaVigenciaPassDefault_CheckedChanged);
			this.grillaRoles.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(grillaRoles_InitializeLayout);
            this.btnAgregarRol.Click+=new EventHandler(btnAgregarRol_Click);
            this.btnQuitarRol.Click+=new EventHandler(btnQuitarRol_Click);
		}

		protected override bool SoloLectura
		{
			get { return base.SoloLectura; }
			set
			{
				base.SoloLectura = value;

				//this.grpPass.Enabled = !_soloLectura;
				this.btnBlanquearPass.Enabled = (ConfigBL.ticket.TienePrivilegio(PRV.ADMINISTRAR_USUARIO) > Alcances.Denegado);
				this.comboRoles.Enabled = !_soloLectura;
			}
		}

		protected override void InicializarFormulario()
		{
			this.Icon = MarDevs.OC.Win.Properties.Resources.IconoUsuario;

			telefono1TelefonoUserControl.TiposTelefono = Telefono.TiposTelefonoFisica();
			telefono2TelefonoUserControl.TiposTelefono = Telefono.TiposTelefonoFisica();
			CargarCombos();

			bindingSource1.DataSource = Entidad;
			grillaRoles.DataSource = Entidad.Roles;			

			_controlesAExcluirProcesamientoSoloLectura.Add(this.txtFechaUltimoIngreso);
			_controlesAExcluirProcesamientoSoloLectura.Add(this.txtFechaUltimoCambioPass);
			_controlesAExcluirProcesamientoSoloLectura.Add(this.botonResumenPrivilegios);

			#region Verificar Privilegios y Determinar SoloLectura

			if (_obj.EsNuevo())
			{
				bool puedeCrear = ConfigBL.ticket.TienePrivilegio(PRV.ADMINISTRAR_USUARIO) > Alcances.Denegado;
				if (puedeCrear)
				{
					this.Text = "Nuevo usuario";
					this.SoloLectura = false;
				}
				else
				{
					throw new ExcepcionNegocios("No tiene privilegio para crear Usuarios");
				}
			}
			else
			{
				this.Text = Entidad.NombreCompleto;
				Alcances privModificar = ConfigBL.ticket.TienePrivilegio((int)MarDevs.OC.Core.PRV.ADMINISTRAR_USUARIO);
				this.SoloLectura = (privModificar == Alcances.Denegado);
			}

			#endregion

		}
		private void CargarCombos()
		{			

			this.comboRoles.Items.Add(null, "[Seleccione...]");
            foreach(Rol rol in Rol.Listar())
			{
				if (!this.Entidad.Roles.Contains(rol))
					this.comboRoles.Items.Add(rol, rol.Nombre);
			}			

		}
        private void ActualizarControlesVigenciaPass(bool usaVigenciaDefault)
        {
            this.labelDiasVigenciaPassword.Enabled = !usaVigenciaDefault;
            this.txtDiasVigenciaPassword.Enabled = !usaVigenciaDefault;
        }

		private void checkUsaVigenciaPassDefault_CheckedChanged(object sender, EventArgs e)
		{
			this.ActualizarControlesVigenciaPass(this.checkUsaVigenciaPassDefault.Checked);
		}
		private void btnBlanquearPass_Click(object sender, System.EventArgs e)
		{

			try
			{
				FormBlanquearPassword formBlanquear = new FormBlanquearPassword(Entidad);
				formBlanquear.ShowDialog();
				this.txtFechaUltimoCambioPass.Value = this.Entidad.FechaUltimoCambioPassword;
			}
			catch (Exception ex)
			{
				Mensaje.Error(ex.Message, ex);
			}
		}
		
        #region GESTION DE ROLES
		
		private void btnAgregarRol_Click(object sender, System.EventArgs e)
		{
            AgregarRol();
		}
        private void comboRoles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AgregarRol();
        }        
		private void grillaRoles_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			//UtilP.ConfigurarColumna(this.grillaRoles, "Id", false);
			//UtilP.ConfigurarColumna(this.grillaRoles, "Yo", false);
			UtilP.ConfigurarColumna(this.grillaRoles, "CreadoEl", false);
			UtilP.ConfigurarColumna(this.grillaRoles, "CreadoPor", false);
			UtilP.ConfigurarColumna(this.grillaRoles, "Editable", false);
		}
		private void btnQuitarRol_Click(object sender, System.EventArgs e)
		{
            Rol rol = null;
			List<Rol> rolesRemover = new List<Rol>();
            foreach (UltraGridRow r in this.grillaRoles.Selected.Rows)
            {
                rol = r.ListObject as Rol;
                if (rol != null)
                {
					rolesRemover.Add(rol);
                }
            }
			foreach (Rol rol2 in rolesRemover)
			{
				this.Entidad.EliminarRol(rol2);
				this.comboRoles.Items.Add(rol2, rol.Nombre);
			}
            this.grillaRoles.DataBind();
		}		
        private void botonResumenPrivilegios_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FormResumenPrivilegios f = new FormResumenPrivilegios(Entidad);
            f.ShowDialog();
            this.Cursor = Cursors.Default;

        }
		private void comboRoles_AfterExitEditMode(object sender, EventArgs e)
		{
			Rol rol = this.comboRoles.Value as Rol;
			if (rol == null)
			{
				this.comboRoles.SelectedIndex = 0;
			}
		}
		private void grillaRoles_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.grillaRoles.ActiveRow == null)
			{ return; }
			try
			{
				if (e.KeyCode == Keys.Delete)
				{
					Rol rol = null;
					List<Rol> rolesRemover = new List<Rol>();
					foreach (UltraGridRow r in this.grillaRoles.Selected.Rows)
					{
						rol = r.ListObject as Rol;
						if (rol != null)
						{
							rolesRemover.Add(rol);
						}
					}
					foreach (Rol rol2 in rolesRemover)
					{
						this.Entidad.EliminarRol(rol2);
						this.comboRoles.Items.Add(rol2, rol.Nombre);
					}
					this.grillaRoles.DataBind();
				}
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}

		private void AgregarRol()
		{
			Rol nuevoRol = this.comboRoles.Value as Rol;
			if (nuevoRol != null && !Entidad.Roles.Contains(nuevoRol))
			{
				int pos = this.comboRoles.SelectedIndex;
				this.Entidad.AgregarRol(nuevoRol);
				this.comboRoles.Items.Remove(this.comboRoles.SelectedItem);
				this.grillaRoles.DataBind();				
				this.comboRoles.SelectedIndex = (pos < this.comboRoles.Items.Count) ? pos : this.comboRoles.Items.Count;
			}
		}

	    #endregion
		

	}
}

