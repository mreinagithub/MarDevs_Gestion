using System;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using MarDevs.OC.Core;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Net;
using System.Diagnostics;

namespace MarDevs.OC.Win
{
	public static class App
	{
		private static ValueList _vlProvincia;
		private static ValueList _vlTipoDocumento;
		private static ValueList _vlSituacionIVA;
		private static ValueList _vlVPEntidad;

		public static ValueList vlVPEntidad
		{
			get
			{
				if (_vlVPEntidad == null)
				{
					_vlVPEntidad = new ValueList();
					//_vlVPEntidad.ValueListItems.Add(typeof(PedidoRepuesto).Name, "Pedido Repuesto");
				}
				return _vlVPEntidad;
			}
		}
		public static ValueList vlProvincia
		{
			get
			{
				if (_vlProvincia == null)
					_vlProvincia = UtilP.CargarValueListDesdeTabla("Provincia", "ProvinciaId", "ProvinciaDesc");
				return UtilP.CopiarValueList(_vlProvincia);
			}
		}
		public static ValueList vlTipoDocumento
		{
			get
			{
				if (_vlTipoDocumento == null)
					_vlTipoDocumento = UtilP.CargarValueListDesdeTabla("TipoDocumento", "Id", "DescCorta");
				return UtilP.CopiarValueList(_vlTipoDocumento);
			}
		}
		public static ValueList vlSituacionIVA
		{
			get
			{
				if (_vlSituacionIVA == null)
					_vlSituacionIVA = UtilP.CargarValueListDesdeTabla("SituacionIVA", "SituacionIVAId", "Descripcion");
				return UtilP.CopiarValueList(_vlSituacionIVA);
			}
		}

		private static Hashtable _entidadesAbiertas = new Hashtable();
		public static string NombreInstalacion = String.Empty;

		public static void RegistrarActualizacion()
		{
			string versionEnsamblado = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();

			string txtSql = "INSERT INTO UPDATELOG (Usuario, Maquina, Version, Fecha )"
				+ " VALUES (@Usuario, @Maquina, @Version, getdate())";
			SqlCommand cmd = new SqlCommand(txtSql, ConfigBL.Conexion);
			cmd.Parameters.AddWithValue("@Usuario", ConfigBL.ticket.UsuarioLogon);
			cmd.Parameters.AddWithValue("@Maquina", Environment.MachineName);
			cmd.Parameters.AddWithValue("@Version", versionEnsamblado);

			try
			{
				if (cmd.Connection.State != ConnectionState.Open)
				{
					cmd.Connection.Open();
				}
				cmd.ExecuteNonQuery();
				Config config = ConfigBL.ObtenerConfiguracion();
				if (config != null)
				{
					config.VersionReportada = versionEnsamblado;
					ConfigBL.GuardarConfiguracion(config);
				}
			}
			catch (Exception ex)
			{
				string tempTexto = "No se pudo notificar la actualización de versión." + Environment.NewLine
									+ "Ha ocurrido el siguiente error: " + Environment.NewLine
									+ Environment.NewLine
									+ ex.Message;
				Mensaje.Error(tempTexto, ex);
			}
			finally
			{
				if (cmd.Connection.State == ConnectionState.Open)
				{
					cmd.Connection.Close();
				}
			}
		}
		public static void CrearToolsSeguimiento(PopupMenuTool popupPadre, bool crearNuevoGrupo)
		{
			UltraToolbarsManager toolbarManager;
			PopupMenuTool nuevoPopup;
			ButtonTool nuevoBoton;
			string nuevoBotonKey = String.Empty;

			if (popupPadre == null)
				return;

			toolbarManager = popupPadre.Tools.ToolbarsManager;
			// PopUp Seguimiento, solo si hay q crearlo
			if (crearNuevoGrupo)
			{
				nuevoPopup = new PopupMenuTool("Seguimiento");
				nuevoPopup.SharedProps.Caption = "Seguimiento";
				toolbarManager.Tools.Add(nuevoPopup);
				popupPadre.Tools.AddTool(nuevoPopup.Key);
			}
			else
			{
				nuevoPopup = popupPadre;
			}
			// Crear Botones
			nuevoBoton = new ButtonTool("SeguimientoHoy");
			toolbarManager.Tools.Add(nuevoBoton);
			nuevoPopup.Tools.AddTool(nuevoBoton.Key);
			nuevoPopup.Tools["SeguimientoHoy"].InstanceProps.IsFirstInGroup = true;
			nuevoBoton.SharedProps.Caption = "Hoy";
			nuevoBoton.SharedProps.AppearancesSmall.Appearance.Image = MarDevs.OC.Win.Properties.Resources.ImagenSeguimiento;

			nuevoBoton = new ButtonTool("SeguimientoMañana");
			toolbarManager.Tools.Add(nuevoBoton);
			nuevoPopup.Tools.AddTool(nuevoBoton.Key);
			nuevoBoton.SharedProps.Caption = "Mañana";
			nuevoBoton.SharedProps.AppearancesSmall.Appearance.Image = MarDevs.OC.Win.Properties.Resources.ImagenSeguimiento;

			nuevoBoton = new ButtonTool("SeguimientoEstaSemana");
			toolbarManager.Tools.Add(nuevoBoton);
			nuevoPopup.Tools.AddTool(nuevoBoton.Key);
			nuevoBoton.SharedProps.Caption = "Esta semana";
			nuevoBoton.SharedProps.AppearancesSmall.Appearance.Image = MarDevs.OC.Win.Properties.Resources.ImagenSeguimiento;

			nuevoBoton = new ButtonTool("SeguimientoSemanaProxima");
			toolbarManager.Tools.Add(nuevoBoton);
			nuevoPopup.Tools.AddTool(nuevoBoton.Key);
			nuevoBoton.SharedProps.Caption = "La semana próxima";
			nuevoBoton.SharedProps.AppearancesSmall.Appearance.Image = MarDevs.OC.Win.Properties.Resources.ImagenSeguimiento;

			nuevoBoton = new ButtonTool("SeguimientoPersonalizar");
			toolbarManager.Tools.Add(nuevoBoton);
			nuevoPopup.Tools.AddTool(nuevoBoton.Key);
			nuevoBoton.SharedProps.Caption = "Personalizar...";
			nuevoBoton.SharedProps.AppearancesSmall.Appearance.Image = MarDevs.OC.Win.Properties.Resources.ImagenSeguimiento;

			nuevoBoton = new ButtonTool("SeguimientoAviso");
			toolbarManager.Tools.Add(nuevoBoton);
			nuevoPopup.Tools.AddTool(nuevoBoton.Key);
			nuevoPopup.Tools["SeguimientoAviso"].InstanceProps.IsFirstInGroup = true;
			nuevoBoton.SharedProps.Caption = "Aviso...";
			nuevoBoton.SharedProps.AppearancesSmall.Appearance.Image = MarDevs.OC.Win.Properties.Resources.ImagenAviso;

			nuevoBoton = new ButtonTool("SeguimientoBorrarMarca");
			toolbarManager.Tools.Add(nuevoBoton);
			nuevoPopup.Tools.AddTool(nuevoBoton.Key);
			nuevoBoton.SharedProps.Caption = "Borrar marca";
			//nuevoBoton.InstanceProps.IsFirstInGroup = true;
			//nuevoBoton.SharedProps.AppearancesSmall.Appearance.Image = Properties.Resources.ImagenBanderaRoja;
		}
		public static Form MostrarEntidad(object entidad)
		{
			return MostrarEntidad(entidad, false);
		}
		public static Form MostrarEntidad(object entidad, bool modoModal)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;

				if (entidad == null) //no hago ni muestro nada
				{
					return null;
				}
				Form form = null;
				//evaluar si la entidad ya esta siendo mostrada
				if (_entidadesAbiertas.ContainsKey(entidad))
				{
					form = _entidadesAbiertas[entidad] as Form;
					if (form.WindowState == FormWindowState.Minimized)
					{
						form.WindowState = FormWindowState.Normal;
					}
					form.BringToFront();
					return form;
				}
				//HAY QUE INSTANCIAR UN NUEVO FORMULARIO
				if (entidad is VistaPersonalizada)
					form = new FormVistaPersonalizada(entidad as VistaPersonalizada);
				
				if (form != null)
				{
					//agregar la entidad y el form al hashtable de entidades-forms abiertos
					_entidadesAbiertas.Add(entidad, form);

					//enlazar el evento para q cuando se cierre el form, remover la entrada
					//del hashtable de entidades-forms abiertos
					form.Closed += new EventHandler(form_Closed);

					form.ShowInTaskbar = !modoModal;
					if (modoModal)
						form.ShowDialog();
					else
						form.Show();
				}
				return form;
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}
		private static void form_Closed(object sender, EventArgs e)
		{
			object entidad = null;
			Form form = sender as Form;
			foreach (DictionaryEntry de in _entidadesAbiertas)
			{
				if (de.Value == form)
				{
					entidad = de.Key;
					break;
				}
			}
			if (entidad != null)
			{
				_entidadesAbiertas.Remove(entidad);
			}
		}
		public static string ObtenerValorDeValueList(ValueList vl, object dataValue)
		{
			if (vl == null) { return ""; }
			foreach (ValueListItem vli in vl.ValueListItems)
			{
				if (vli.DataValue == null && dataValue == null)
				{
					return vli.DisplayText;
				}
				if (vli.DataValue != null && vli.DataValue.Equals(dataValue))
				{
					return vli.DisplayText;
				}
			}
			return "";
		}
		public static object TraerRecurso(string nombreRecurso)
		{
			//WORKARROUND PARA QUE LOS RECURSOS
			//HAY QUE PLANTEAR UNA FORMA UNIFORME DE OBTENER RECURSOS
			object recurso = MarDevs.OC.Win.Properties.Resources.ResourceManager.GetObject(nombreRecurso);
			if (recurso == null)
			{
				recurso = UtilP.TraerRecurso(nombreRecurso);
			}
			return recurso;
		}
		public static void RegistrarLogIn()
		{
			try
			{
				if (ConfigBL.ticket.Impersonado) { return; }
				using (DL dl = DL.ObtenerSesion())
				{

					//Obtengo la versión del CRM
					System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
					Version appVersion = a.GetName().Version;
					string appVersionString = appVersion.ToString();

					//Creo el Log
					dl.IniciarTransaccion();
					dl.EjecutarSQL(CommandType.StoredProcedure, "RegistrarLogIn",
						new SqlParameter("@UsuarioID", ConfigBL.ticket.Usuario.Id),
						new SqlParameter("@IpPublica", GetExternalIp()),
						new SqlParameter("@VersionApp", appVersionString),
						new SqlParameter("@VersionSO", Environment.OSVersion.VersionString));
					dl.ConfirmarTransaccion();
				}
			}
			catch
			{
				//nada, consumimos la excepcion.
			}
		}
		public static void RegistrarLogOut()
		{
			try
			{
				if (ConfigBL.ticket.Impersonado) { return; }
				using (DL dl = DL.ObtenerSesion())
				{
					dl.IniciarTransaccion();
					dl.EjecutarSQL(CommandType.StoredProcedure, "RegistrarLogOut", new SqlParameter("@UsuarioID", ConfigBL.ticket.Usuario.Id));
					dl.ConfirmarTransaccion();
				}
			}
			catch
			{
				//nada, consumimos la excepcion.
			}
		}
		public static string GetExternalIp()
		{
			try
			{
				WebClient WanIP = new WebClient();
				string texto = WanIP.DownloadString("http://espasamail.espasa.com.ar/utils/daniel.php");
				IPAddress ip = IPAddress.Parse(texto);
				return ip != null ? ip.ToString() : String.Empty;
			}
			catch
			{
				return String.Empty;
			}
		}

		public static void ArchivoAbrir(Archivo archivo)
		{
			string nombre = Path.Combine(UtilP.CarpetaTemporal(), String.Format("{0}.{1}", archivo.Nombre, archivo.Extension));
			FileStream fs = new FileStream(nombre, FileMode.Create);

			fs.Write(archivo.Contenido, 0, archivo.Contenido.Length);
			fs.Close();
			ArchivoAbrir(nombre);
		}
		public static void ArchivoAbrir(string rutaCompleta)
		{
			try
			{
				if (File.Exists(rutaCompleta))
				{
					Process proceso = new Process();
					proceso.StartInfo.FileName = rutaCompleta;
					proceso.Start();
				}
			}
			catch
			{
				MessageBox.Show("Hubo un error al intentar abrir el archivo. Posiblemente no existan en el sistema aplicaciones para abrir ese tipo de archivos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

		}
		public static string ArchivoSeleccionar(string filtroDialog, string tituloDialog)
		{
			try
			{
				OpenFileDialog openFileDialog1 = new OpenFileDialog();
				openFileDialog1.Multiselect = false;
				if (!String.IsNullOrEmpty(filtroDialog))
					openFileDialog1.Filter = filtroDialog;
				if (!String.IsNullOrEmpty(tituloDialog))
					openFileDialog1.Title = tituloDialog;
				openFileDialog1.FileName = string.Empty;
				return (openFileDialog1.ShowDialog() == DialogResult.OK ? openFileDialog1.FileName : string.Empty);
				//if (openFileDialog1.ShowDialog() == DialogResult.OK)
				//	return new FileStream(openFileDialog1.FileName, FileMode.Open);
				//else
				//	return null;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void ArchivoGuardarComo(string filtroSaveDialog, string tituloSaveDialog, Archivo archivo, bool abrirArchivo)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			if (!String.IsNullOrEmpty(filtroSaveDialog))
				saveFileDialog1.Filter = filtroSaveDialog; //"JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
			if (!String.IsNullOrEmpty(tituloSaveDialog))
				saveFileDialog1.Title = tituloSaveDialog; //"Save an Image File";
			saveFileDialog1.ShowDialog();

			// If the file name is not an empty string open it for saving.
			if (!String.IsNullOrEmpty(saveFileDialog1.FileName))
			{
				// Saves the Image via a FileStream created by the OpenFile method.
				using (FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile())
				{
					fs.Write(archivo.Contenido, 0, archivo.Contenido.Length);
				}
				if (abrirArchivo)
					ArchivoAbrir(saveFileDialog1.FileName);
			}
		}
		public static void ExportarGrillaAExcel(UltraGrid grilla)
		{
			string nombreArchivo = String.Format("tmp{0}.xls", new Random().Next(9999).ToString().PadLeft(4, Char.Parse("0")));
			string carpetaArchivo = UtilP.CarpetaTemporal();
			ExportarGrillaAExcel(grilla, carpetaArchivo, nombreArchivo);
		}
		public static void ExportarGrillaAExcel(UltraGrid grilla, string carpetaArchivo, string nombreArchivo)
		{
			bool exito = true;
			string archivo = String.Empty;
			try
			{
				if (grilla == null || grilla.Rows.Count == 0) return;
				archivo = Path.Combine(carpetaArchivo, nombreArchivo);
				Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter();
				ultraGridExcelExporter1.Export(grilla, archivo);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Hubo un error al intentar crear el archivo de Excel "
					+ archivo + ". La Exportacin no pudo realizarse." + ex.ToString(),
					"Advertencia", MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				exito = false;
			}
			if (exito == true)
				ArchivoAbrir(archivo);
		}
	}
}