using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{
	public partial class FormListaTipo : FormListaBase
	{
		public FormListaTipo(string tipoEntidad): base()
		{
			TipoEntidad = Type.GetType(tipoEntidad);
            if (TipoEntidad == null)
				throw new ArgumentException("tipoEntidad no se pudo obtener el tipo.");

            object[] attrs = TipoEntidad.GetCustomAttributes(typeof(ClassDescriptorAttribute), false);
			if (attrs != null && attrs.Length > 0)
				_classDescriptor = attrs[0] as ClassDescriptorAttribute;
			else
				throw new ExcepcionNegocios("No se ha definido el atributo ClassDescriptor.");
		}
		private FormListaTipo():base()
		{
			InitializeComponent();
		}
		
		private ClassDescriptorAttribute _classDescriptor = null;

		protected override void InicializarGrilla()
		{
			base.InicializarGrilla();
            UtilP.ConfigurarGrillaDesdeType(this.ultraGrid1, TipoEntidad);
		}
		protected override void InicializarToolbar()
		{
			base.InicializarToolbar();
            ServicioUI.Instancia.RegistrarAcciones(TipoEntidad.FullName, ultraToolbarsManager1.Tools["PopupAcciones"] as PopupMenuTool);
		}
		public override void AbrirElemento(object elemento)
		{
			Type tipo = this.TipoFormularioAbrirElemento();
			if (tipo != null)
			{
				Form form = Activator.CreateInstance(tipo, new object[] { elemento }) as Form;
				form.ShowDialog();
			}
		}
		public override void AgregarElemento()
		{
			object entidad = CrearNuevaEntidad();
			Type tipo = this.TipoFormularioAbrirElemento();
			if (tipo != null)
			{
				Form form = Activator.CreateInstance(tipo, new object[] { entidad }) as Form;
				form.ShowDialog();
				this.ActualizarListaDesdeOrigen();
			}
		}
		public override bool DebeActualizarAlActivar
		{
			get
			{
				return true;
			}
		}

		private object CrearNuevaEntidad()
		{
            object entidad = Activator.CreateInstance(TipoEntidad, true);
			IAuditable auditable = entidad as IAuditable;
			if (auditable != null)
			{
				auditable.CreadoEl = ConfigBL.FechaYHoraActual;
				auditable.CreadoPor = UsuarioLight.Crear(ConfigBL.ticket.Usuario);
			}
			return entidad;
		}
		protected override object RecuperarDatos()
		{
			using (DL dl = DL.ObtenerSesion())
			{
                return dl.Listar(TipoEntidad);
			}
		}
		protected override void InicializarFormulario()
		{
			base.InicializarFormulario();
			this.PermitirEliminarElementos = _classDescriptor.Eliminar && ConfigBL.ticket.TienePrivilegio(_classDescriptor.PrivilegioEliminar) > Alcances.Denegado;
			this.PermitirAgregarElementos = _classDescriptor.Agregar && ConfigBL.ticket.TienePrivilegio(_classDescriptor.PrivilegioAgregar) > Alcances.Denegado;
			ActualizarListaDesdeOrigen();
		}
		private Type TipoFormularioAbrirElemento()
		{
			if (_classDescriptor == null)
			{
				throw new Exception("Falta el atributo ClassDescriptor en la clase");
			}
			Type tipo = Type.GetType(_classDescriptor.TipoFormulario, true);
			return tipo;
		}
		protected override void UltraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
		{
			if (e.Tool.SharedProps.Tag is Accion)
			{
				try
				{
					DialogResult res = ServicioUI.Instancia.ProcesarAccion2(e.Tool.SharedProps.Tag as Accion, this.ElementosSeleccionados);
				}
				catch (Exception ex)
				{
					Mensaje.Error(String.Format("No se pudo abrir el formulario de la acción. Motivo: {0}", ex.Message), ex);
				}
			}
			else
			{
				base.UltraToolbarsManager1_ToolClick(sender, e);
			}
		}

	}
}