using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

using MarDevs.OC.Core;
using System.Collections.Generic;

namespace MarDevs.OC.Win
{
	public partial class FormListaUsuarios : FormListaBase
	{
		public FormListaUsuarios():base()
		{
			InitializeComponent();

			this.txtBusqueda.KeyPress += new KeyPressEventHandler(txtBusqueda_KeyPress);
		}

		private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Keys)e.KeyChar == Keys.Enter)
				ActualizarListaDesdeOrigen();
		}

		protected override object RecuperarDatos()
		{
			return Usuario.Buscar(this.txtBusqueda.Text, this.chkSoloActivos.Checked);
		}
		public override void AbrirElemento(object elemento)
		{
			Usuario usu = elemento as Usuario;
			if (usu != null)
			{
				FormUsuario fUsu = new FormUsuario(usu);
				fUsu.ShowDialog();
			}
		}
		public override void AgregarElemento()
		{
			Usuario usu = Usuario.Crear();
			FormUsuario fUsu = new FormUsuario(usu);
			fUsu.ShowDialog();
			//si el usuario fue efectivamente creado, agregarlo a la lista
			if (usu.EsNuevo() == false)
			{
                this.bindingSource1.Add(usu);
			}
		}
		protected override void InicializarFormulario()
		{
			base.InicializarFormulario();
			bool privVer = ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_USUARIO);
			if (privVer == false)
			{
				throw new ExcepcionNegocios("No tiene Privilegios para ver Usuarios");
			}
			this.PermitirAgregarElementos = (ConfigBL.ticket.TienePrivilegio(PRV.ADMINISTRAR_USUARIO) > Alcances.Denegado);
			this.PermitirEliminarElementos = (ConfigBL.ticket.TienePrivilegio(PRV.ADMINISTRAR_USUARIO) > Alcances.Denegado);
			this.txtBusqueda.Select();
			this.ActualizarListaDesdeOrigen();
		}
		protected override void InicializarGrilla()
		{
			base.InicializarGrilla();
			UtilP.ConfigurarGrillaDesdeType(ultraGrid1, typeof(Usuario));			
		}
		public override bool PermitirMultiplesInstancias
		{
			get
			{
				return false;
			}
		}
		protected override void RestablecerParametros()
		{
			this.txtBusqueda.Text = String.Empty;
			this.chkSoloActivos.Checked = true;
		}
		
	}
}

