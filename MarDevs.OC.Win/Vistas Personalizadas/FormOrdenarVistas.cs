using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MarDevs.OC.Core;

namespace MarDevs.OC.Win
{
	public partial class FormOrdenarVistas : Form
	{
		public FormOrdenarVistas()
		{
			InitializeComponent();
		}
		
		private void FormOrdenarVistas_Load(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				CargarComboEntidades();
				ObtenerVistasPorOrden();				

				this.cboEntidad.ValueChanged += new EventHandler(cboEntidad_ValueChanged);
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

		private void cboEntidad_ValueChanged(object sender, EventArgs e)
		{
			ObtenerVistasPorOrden();			
		}

		private void ObtenerVistasPorOrden()
		{
			using (DL dl = DL.ObtenerSesion())
			{
				IList<VistaPersonalizada> lista = dl.Listar<VistaPersonalizada>(String.Format("from VistaPersonalizada vp where vp.Entidad = '{0}' AND vp.VistaActiva = 1 Order by vp.Orden", this.cboEntidad.Value));
				this.listVistas.Items.Clear();
				foreach (VistaPersonalizada vp in lista)
				{
					this.listVistas.Items.Add(vp);
				}
				if (this.listVistas.Items.Count > 0)
				{
					this.listVistas.SelectedIndex = 0;
				}
			}
		}
		private void CargarComboEntidades()
		{
			//Combo Entidades			
			UtilP.CargarComboDesdeValueList(cboEntidad, App.vlVPEntidad);

			//Default Operacion
			this.cboEntidad.SelectedIndex = 0;
		}
		private void GuardarCambios()
		{ 
			if (this.listVistas.Items.Count > 0)
			{
				using (DL dl = DL.ObtenerSesion())
				{
					dl.IniciarTransaccion();
					VistaPersonalizada vp;
					for (int i = 0; i < this.listVistas.Items.Count; i++)
					{
						vp = this.listVistas.Items[i] as VistaPersonalizada;
						if (vp != null)
						{
							vp.Orden = i;
							dl.Guardar(vp);
						}
					}
					dl.ConfirmarTransaccion();
				}
			}
		}

		private void btnSubir_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listVistas.SelectedIndex == -1)
				{ return; }
				if (this.listVistas.SelectedIndex == 0)
				{ return; }
				VistaPersonalizada vp = this.listVistas.Items[this.listVistas.SelectedIndex] as VistaPersonalizada;
				this.listVistas.Items.Insert(this.listVistas.SelectedIndex - 1, vp);
				this.listVistas.Items.RemoveAt(this.listVistas.SelectedIndex);
				this.listVistas.SelectedItem = vp;
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private void btnBajar_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listVistas.SelectedIndex == -1)
				{ return; }
				if (this.listVistas.SelectedIndex == (this.listVistas.Items.Count - 1))
				{ return; }
				VistaPersonalizada vp = this.listVistas.Items[this.listVistas.SelectedIndex] as VistaPersonalizada;
				this.listVistas.Items.Insert(this.listVistas.SelectedIndex + 2, vp);
				this.listVistas.Items.RemoveAt(this.listVistas.SelectedIndex);
				this.listVistas.SelectedItem = vp;
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
		}
		private void botonAceptar_Click(object sender, EventArgs e) // Guardar y Cerrar
		{
			try
			{
				this.Cursor = Cursors.Default;
				GuardarCambios();
				this.Close();
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		private void btnGuardar_Click(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.Default;
				GuardarCambios();				
			}
			catch (Exception ex)
			{
				Mensaje.MostrarError(ex);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		private void btnCerrar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
