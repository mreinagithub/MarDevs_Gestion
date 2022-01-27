using System;
using System.Data;
using System.Windows.Forms;
using MarDevs.Gestion.Core;
using Infragistics.Win;

namespace MarDevs.Gestion.Win
{
	public partial class FormListaFormulario : FormListaBase
	{
		public FormListaFormulario()
		{
			InitializeComponent();
		}	

		protected override void InicializarFormulario()
		{
			base.InicializarFormulario();		
			this.PermitirAgregarElementos = false;
			this.PermitirEliminarElementos = false;
			this.PermitirMultiSelect = false;
			ActualizarListaDesdeOrigen();
		}
		protected override object RecuperarDatos()
		{			
			return Formulario.Listar();
		}
		protected override void InicializarGrilla()
		{
			base.InicializarGrilla();
			UtilP.OcultarColumnas(this.ultraGrid1);
			int i = 0;
			ValueList vlist = UtilP.CargarValueListDesdeEnum(typeof(TipoFormulario));
			UtilP.ConfigurarColumna(this.ultraGrid1, "Tipo", true, i++, "Tipo", 250, vlist);
			UtilP.ConfigurarColumna(this.ultraGrid1, "Descripcion", true, i++, "Descripción", 150);
			UtilP.ConfigurarColumna(this.ultraGrid1, "Copias", true, i++, "Copias", 50);			
			UtilP.ConfigurarColumna(this.ultraGrid1, "FechaModificacion", true, i++, "Fecha de Modificación", 200, "dd/MM/yyyy HH:mm:ss");
		}

		public override void AbrirElemento(object elemento)
		{
            Formulario formulario = elemento as Formulario;
			if (formulario != null)
			{
				FormFormulario form = new FormFormulario(formulario);
				if (form.ShowDialog() == DialogResult.OK)
                	this.ActualizarListaDesdeOrigen();
			}
		}
	}

}
