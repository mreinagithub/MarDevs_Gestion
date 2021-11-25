using System;
using System.Windows.Forms;
using System.Xml;
using MarDevs.OC.Core;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;

namespace MarDevs.OC.Win
{
	public partial class FormListaVistaPersonalizada : FormListaBase
	{
		public FormListaVistaPersonalizada()
		{
			InitializeComponent();

			this.txtBuscar.KeyPress += new KeyPressEventHandler(txtBuscar_KeyPress);
		}

		private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Keys)e.KeyChar == Keys.Enter)
			{
				ActualizarListaDesdeOrigen();
			}
		}
		private void btnOrdenar_Click(object sender, EventArgs e)
		{
			if (!ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS))
			{
				Mensaje.Advertencia("No tiene privilegios suficientes para administrar el orden de las vistas personalizadas.");
				return;
			}
			try
			{
				this.Cursor = Cursors.WaitCursor;
				FormOrdenarVistas formOrden = new FormOrdenarVistas();
				formOrden.ShowDialog();
				ActualizarListaDesdeOrigen();
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
		protected override void InicializarFormulario()
		{
			base.InicializarFormulario();			
			this.PermitirAbrirElementos = true;
			this.PermitirAgregarElementos = true;
			this.PermitirEliminarElementos = true;
			this.ActualizarListaDesdeOrigen();
			this.txtBuscar.Select();
		}
		protected override void InicializarGrilla()
		{
			base.InicializarGrilla();
			UtilP.ConfigurarColumna(this.ultraGrid1, "Entidad", true, 0, "Entidad", 200, App.vlVPEntidad);			
			UtilP.ConfigurarGrillaDesdeType(this.ultraGrid1,typeof(VistaPersonalizada));
		}
		protected override void InicializarToolbar()
		{
			base.InicializarToolbar();

			Accion accion;

			accion = Accion.Crear(this.GetType().Name, "Clonar", "Clonar Vista...", true, PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS, "ClonarVistaPersonalizada");
			accion.ValidaParaMultiplesInstancias = false;
			accion.Tipo = TipoAccion.EjecutarMetodo;
			_acciones.Add(accion);

			accion = Accion.Crear(this.GetType().Name, "ExportarXML", "Exportar XML...", true, PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS, "ExportarXML");
			accion.ValidaParaMultiplesInstancias = false;
			accion.Tipo = TipoAccion.EjecutarMetodo;
			_acciones.Add(accion);

			accion = Accion.Crear(this.GetType().Name, "ImportarXML", "Importar XML...", false, PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS, "ImportarXML");
			//accion.ValidaParaMultiplesInstancias = false;
			accion.Tipo = TipoAccion.EjecutarMetodo;
			_acciones.Add(accion);

			ServicioUI.Instancia.RegistrarAcciones(_acciones, ultraToolbarsManager1.Tools["PopupAcciones"] as PopupMenuTool);
		}		
		protected override object RecuperarDatos()
		{
			return VistaPersonalizada.Buscar(this.txtBuscar.Text,this.ckActivos.Checked);
		}
		public override void AbrirElemento(object elemento)
		{
			App.MostrarEntidad(elemento,true);
			this.ActualizarListaDesdeOrigen();
		}
		public override void AgregarElemento()
		{
			if(!ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS))
			{
				Mensaje.Advertencia("No tiene privilegios suficientes para crear nuevas vistas personalizadas.");
				return;
			}
			VistaPersonalizada vp = VistaPersonalizada.Crear();
			FormVistaPersonalizada form = new FormVistaPersonalizada(vp);
			form.ShowDialog();
			ActualizarListaDesdeOrigen();
		}
		protected override void RestablecerParametros()
		{
			this.txtBuscar.Text = String.Empty;
			this.ckActivos.Checked = true;
		}
		public void ClonarVistaPersonalizada()
		{
			if (!ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS))
			{
				Mensaje.Advertencia("No tiene privilegios suficientes para clonar vistas personalizadas.");
				return;
			}
			VistaPersonalizada vista = this.ultraGrid1.ActiveRow.ListObject as VistaPersonalizada;
			VistaPersonalizada vpClonada = VistaPersonalizada.Clonar(vista);
			if (vpClonada != null)
			{
				FormVistaPersonalizada form = new FormVistaPersonalizada(vpClonada);
				form.ShowDialog();
				ActualizarListaDesdeOrigen();
			}
		}
		public void ExportarXML()
		{
			if (!ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS))
			{
				Mensaje.Advertencia("No tiene privilegios suficientes para exportar vistas personalizadas.");
				return;
			}
			VistaPersonalizada vista = this.ultraGrid1.ActiveRow.ListObject as VistaPersonalizada;
			VistaPersonalizada vpClonada = VistaPersonalizada.Clonar(vista);
			if (vpClonada != null)
			{
				try
				{
					vpClonada.CreadoPor = null;
					this.saveFileDialog1.Filter = "Archivo a exportar (*.xml)|*.xml";
					string nombreArchivo = vpClonada.Nombre;
					this.saveFileDialog1.FileName = nombreArchivo;
					DialogResult resu = this.saveFileDialog1.ShowDialog();
					if (resu == DialogResult.OK)
					{
						UtilP.SerializarXML(vpClonada, saveFileDialog1.FileName);
						Mensaje.Informacion("Se ha exportado correctamente.");
					}


				}
				catch (Exception ex)
				{
					Mensaje.Error("No se pudo exportar. Error: ", ex);
				}
				finally
				{
					Cursor.Current = Cursors.Default;
				}
			}
		}
		public void ImportarXML()
		{
			try
			{
				this.openFileDialog1.Multiselect = false;
				this.openFileDialog1.Filter = "Archivos XML a importar (*.xml)|*.xml";
				this.openFileDialog1.FileName = string.Empty;
				this.openFileDialog1.ShowDialog();
				XmlDocument document = new XmlDocument();
				document.Load(openFileDialog1.FileName);
				VistaPersonalizada vp = UtilP.DesserializarXML<VistaPersonalizada>(openFileDialog1.FileName);
				if (vp != null)
				{
					vp.CreadoPor = UsuarioLight.Crear(ConfigBL.ticket.Usuario);
					vp.CreadoEl = ConfigBL.FechaYHoraActual;
					vp.Texto = vp.Texto.Replace("\n", "\r\n"); //Ajustamos lineas en texto consulta
					VistaPersonalizadaFormatoColumna vperFcolumna;
					VistaPersonalizadaParametro vperParam;
					VistaPersonalizadaSummary vperSumm;

					#region COLECCION DE FORMATOS

					XmlNodeList listaFormatos = document.SelectNodes("/VistaPersonalizada/Formatos");
					if (listaFormatos != null)
					{
						foreach (XmlNode vpfc in listaFormatos)
						{
							vperFcolumna = new VistaPersonalizadaFormatoColumna();
							foreach (XmlNode nodo in vpfc.ChildNodes)
							{
								switch (nodo.Name)
								{
									case "Columna":
										vperFcolumna.Columna = nodo.InnerText;
										break;
									case "Titulo":
										vperFcolumna.Titulo = nodo.InnerText;
										break;
									case "Formato":
										vperFcolumna.Formato = nodo.InnerText;
										break;
									case "ValueList":
										vperFcolumna.ValueList = nodo.InnerText;
										break;
									case "BackColor":
										vperFcolumna.BackColor = Convert.ToInt32(nodo.InnerText);
										break;
									case "ForeColor":
										vperFcolumna.ForeColor = Convert.ToInt32(nodo.InnerText);
										break;
									case "Bold":
										vperFcolumna.Bold = Convert.ToBoolean(nodo.InnerText);
										break;
									case "Ancho":
										vperFcolumna.Ancho = Convert.ToInt32(nodo.InnerText);
										break;
									case "Visible":
										vperFcolumna.Visible = Convert.ToBoolean(nodo.InnerText);
										break;
									case "ExcluirDelSelector":
										vperFcolumna.ExcluirDelSelector = Convert.ToBoolean(nodo.InnerText);
										break;
								}
							}
							vperFcolumna.VistaPersonalizada = vp;
							vp.Formatos.Add(vperFcolumna);
						}
					}

					#endregion

					#region COLLECCION DE PARAMETROS

					XmlNodeList listaParametros = document.SelectNodes("/VistaPersonalizada/Parametros");
					if (listaParametros != null)
					{
						foreach (XmlNode vpp in listaParametros)
						{
							vperParam = new VistaPersonalizadaParametro();
							foreach (XmlNode nodo in vpp.ChildNodes)
							{
								switch (nodo.Name)
								{
									case "IdParametro":
										vperParam.IdParametro = nodo.InnerText;
										break;
									case "Etiqueta":
										vperParam.Etiqueta = nodo.InnerText;
										break;
									case "TipoControl":
										vperParam.TipoControl = (TipoControl)Enum.Parse(typeof(TipoControl), nodo.InnerText);
										break;
									case "PuntoX":
										vperParam.PuntoX = Convert.ToInt32(nodo.InnerText);
										break;
									case "PuntoY":
										vperParam.PuntoY = Convert.ToInt32(nodo.InnerText);
										break;
									case "Ancho":
										vperParam.Ancho = Convert.ToInt32(nodo.InnerText);
										break;
									case "AnchoEtiqueta":
										vperParam.AnchoEtiqueta = Convert.ToInt32(nodo.InnerText);
										break;
									case "Alto":
										vperParam.Alto = Convert.ToInt32(nodo.InnerText);
										break;
									case "Orden":
										vperParam.Orden = Convert.ToInt32(nodo.InnerText);
										break;
									case "ConsultaDatos":
										vperParam.ConsultaDatos = nodo.InnerText;
										break;
									case "ConsultaDefault":
										vperParam.ConsultaDefault = nodo.InnerText;
										break;
									case "Activo":
										vperParam.Activo = Convert.ToBoolean(nodo.InnerText);
										break;
								}
							}
							vperParam.VistaPersonalizada = vp;
							vp.Parametros.Add(vperParam);
						}
					}

					#endregion

					#region COLLECCION DE SUMMARIES

					XmlNodeList listaSummaries = document.SelectNodes("/VistaPersonalizada/Summaries");
					if (listaSummaries != null)
					{
						foreach (XmlNode vps in listaSummaries)
						{
							vperSumm = new VistaPersonalizadaSummary();
							foreach (XmlNode nodo in vps.ChildNodes)
							{
								switch (nodo.Name)
								{
									case "Campo":
										vperSumm.Campo = nodo.InnerText;
										break;
									case "Accion":
										vperSumm.Accion = (AccionSummary)Enum.Parse(typeof(AccionSummary), nodo.InnerText);
										break;
									case "Formula":
										vperSumm.Formula = nodo.InnerText;
										break;
									case "Display":
										vperSumm.Display = nodo.InnerText;
										break;
									case "Ubicacion":
										vperSumm.Ubicacion = (UbicacionSummary)Enum.Parse(typeof(UbicacionSummary), nodo.InnerText);
										break;
								}
							}
							vperSumm.VistaPersonalizada = vp;
							vp.Summaries.Add(vperSumm);
						}
					}

					#endregion

					FormVistaPersonalizada form = new FormVistaPersonalizada(vp);
					form.ShowDialog();
					ActualizarListaDesdeOrigen();

				}


			}
			catch (Exception ex)
			{
				Mensaje.Error("Se ha producido un error al abrir el archivo seleccionado. ", ex);
			}
		}
	}
}
