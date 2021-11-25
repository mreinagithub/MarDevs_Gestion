using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MarDevs.OC.Core;

namespace MarDevs.OC.Win
{
	public partial class FormBlanquearPassword : Form
	{
		public FormBlanquearPassword(Usuario usuario)
		{
			_usuario = usuario;
			InitializeComponent();
		}

		private Usuario _usuario;

		private void FormBlanquearPassword_Load(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (_usuario == null)
				{
					throw new ExcepcionNegocios("No se ha establecido el usuario al que cambiar la contraseña.");
				}
				if (_usuario.EsNuevo())
				{
					throw new ExcepcionNegocios("El usuario es nuevo, por favor guarde el mismo antes de continuar.");
				}
				if (_usuario.HayCambios())
				{
					throw new ExcepcionNegocios("Se efectuaron cambios en los datos del usuario, por favor guardelos antes de continuar.");
				}
				this.lblInfo.Text = "Esta pantalla permite blanquear la contraseña para el usuario.";

			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
				this.Close();
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void BotonAceptar_Click(object sender, EventArgs e)
		{			
			try
			{				
				string passwordNuevo1 = this.txtPasswordNuevo.Text.Trim();
				string passwordNuevo2 = this.txtPasswordNuevo2.Text.Trim();

				if (!passwordNuevo1.Equals(passwordNuevo2))
				{
					throw new Exception("La password nueva no coincide.");
				}
				Usuario.BlanquearContraseña(_usuario, passwordNuevo1);
				Mensaje.Informacion("La Contraseña se cambió exitosamente.");
				this.Close();
			}			
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}



	}
}
