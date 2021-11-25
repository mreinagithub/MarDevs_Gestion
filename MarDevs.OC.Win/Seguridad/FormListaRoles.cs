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
	public partial class FormListaRoles : FormListaBase
	{
		public FormListaRoles() :base()
		{
			InitializeComponent();
		}

		protected override void InicializarFormulario()
		{
			base.InicializarFormulario();
			bool prvVerGrilla = ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_ROL);
			if (!prvVerGrilla)
			{
				throw new ExcepcionNegocios("No tiene privilegios para ver Roles.");
			}
			this.PermitirAgregarElementos = (ConfigBL.ticket.TienePrivilegio(PRV.ADMINISTRAR_ROL) > Alcances.Denegado);
			this.PermitirEliminarElementos = (ConfigBL.ticket.TienePrivilegio(PRV.ADMINISTRAR_ROL) > Alcances.Denegado);
			this.txtBusqueda.Select();
			this.ActualizarListaDesdeOrigen();
		}
		protected override void InicializarGrilla()
		{
			base.InicializarGrilla();
			UtilP.ConfigurarGrillaDesdeType(this.ultraGrid1, typeof(Rol));
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
		}
		protected override object RecuperarDatos()
		{
			return Rol.Buscar(this.txtBusqueda.Text);
		}
		public override void AbrirElemento(object elemento)
		{
			Rol rol = elemento as Rol;
			if (rol != null)
			{
				FormRol fRol = new FormRol(rol);
				fRol.ShowDialog();
			}
		}
		public override void AgregarElemento()
		{
			Rol rol = Rol.Crear();
			FormRol fRol = new FormRol(rol);
			fRol.ShowDialog();
			//si el usuario fue efectivamente creado, agregarlo a la lista
			if (rol.EsNuevo() == false)
			{
				//this._lista.Add(usu);
				//this.ultraGrid1.DataBind();
				this.bindingSource1.Add(rol);
			}
		}

		private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Keys)e.KeyChar == Keys.Enter)
			{
				ActualizarListaDesdeOrigen();
			}
		}

	}
}
