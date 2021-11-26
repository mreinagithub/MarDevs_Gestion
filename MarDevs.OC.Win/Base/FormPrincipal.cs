using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MarDevs.OC.Win;
using System.Reflection;
using System.Collections;
using MarDevs.OC.Core;
using Infragistics.Win.UltraWinToolbars;
using System.Xml;
using System.IO;
using System.Reflection.Emit;
using System.ComponentModel.Design;
using Infragistics.Win.UltraWinDock;
using System.Runtime.Remoting;
using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinStatusBar;
using Infragistics.Win.UltraWinTree;


namespace MarDevs.OC.Win
{
	public partial class FormPrincipal : Form
	{
		public static FormPrincipal Instancia
		{
			get
			{
				if (_instancia == null)
				{
					_instancia = new FormPrincipal();
				}
				return _instancia;
			}
		}

		private FormPrincipal()
		{
			if (!this.DesignMode)
			{
				Cronometro.Iniciar("INICIALIZACION");

				//formulario de splash
				Splash.NombreAplicacion = Application.ProductName;
				Splash.Version = "Versión " + Application.ProductVersion;
				Splash.Mostrar();

				Splash.EstadoCarga = "Inicializando formulario...";
			}

			InitializeComponent();

			this.MdiChildActivate += new EventHandler(FormPrincipal_MdiChildActivate);
			this.FormClosing += new FormClosingEventHandler(FormPrincipal_FormClosing);
		}

		#region Variables

		public delegate void DelegadoEvento(object sender, KeyPressEventArgs e);
		private bool _preguntarAlSalir = true;
		private static UltraToolbarsManager _tbManager = null;
		private static FormPrincipal _instancia = null;
		private List<Temporizador> _timers = new List<Temporizador>();
		private PanelNavegacionUserControl _panelNavegacion;

		#endregion

		public UltraDockManager DockManager
		{
			get { return this.ultraDockManager1; }
		}
		public UltraTabbedMdiManager MdiManager
		{
			get { return this.ultraTabbedMdiManager1; }
		}
		public UltraToolbarsManager ToolbarManager
		{
			get { return this.ultraToolbarsManager1; }
		}
		public UltraStatusBar StatusBar
		{
			get { return this.ultraStatusBar1; }
		}
		public List<Temporizador> Timers
		{
			get { return _timers; }
		}
		public bool PreguntarAlSalir
		{
			get { return _preguntarAlSalir; }
			set { _preguntarAlSalir = value; }
		}
		public PanelNavegacionUserControl PanelNavegacion
		{
			get
			{
				return _panelNavegacion;
			}
		}
				
		private void FormPrincipal_Load(object sender, EventArgs e)
		{
			try
			{
				if (this.DesignMode)
				{
					return;
				}

				string carpeta = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
				+ Path.DirectorySeparatorChar
				+ "MarDevs"
				+ Path.DirectorySeparatorChar
				+ System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

				UserSettings.SettingsPath = carpeta;

				_tbManager = this.ultraToolbarsManager1;

				this.TraducirStringsInfragistics();
				this.Inicializar();
				Splash.Cerrar(false);
				Cronometro.Detener("INICIALIZACION");
				this.Activate();
			}
			catch (Exception ex)
			{

				Mensaje.Advertencia(ex.ToString());
			}
			finally
			{
				this.ResumeLayout();
			}
		}

		public void Inicializar()
		{
			this.ultraToolbarsManager1.Tools.Clear();
			this.ultraToolbarsManager1.Toolbars.Clear();
			this.ultraDockManager1.DockAreas.Clear();
			this.ultraDockManager1.ControlPanes.Clear();

			this.SuspendLayout();

			UltraToolbar tbMenu = new UltraToolbar("MP");
			tbMenu.DockedColumn = 0;
			tbMenu.DockedRow = 0;
			tbMenu.FloatingSize = new System.Drawing.Size(133, 41);
			tbMenu.IsMainMenuBar = true;
			tbMenu.Text = "Menu Principal";

			UltraToolbar tb1 = new UltraToolbar("TB");
			tb1.DockedColumn = 0;
			tb1.DockedRow = 1;
			tb1.Text = "Standard";

			this.ultraToolbarsManager1.Toolbars.AddRange(new UltraToolbar[] {tbMenu, tb1});

			//popups
			PopupMenuTool popupMenuTool1 = new PopupMenuTool("PopupArchivo");
			PopupMenuTool popupMenuTool2 = new PopupMenuTool("PopupVer");
			PopupMenuTool popupMenuTool3 = new PopupMenuTool("PopupVentana");
			MdiWindowListTool mdiWindowListTool1 = new MdiWindowListTool("MDIWindowListTool1");

			this.ultraToolbarsManager1.Tools.Add(popupMenuTool1);
			this.ultraToolbarsManager1.Tools.Add(popupMenuTool2);
			this.ultraToolbarsManager1.Tools.Add(popupMenuTool3);
			this.ultraToolbarsManager1.Tools.Add(mdiWindowListTool1);

			popupMenuTool1.SharedProps.Caption = "Archivo";
			popupMenuTool2.SharedProps.Caption = "Ver";
			popupMenuTool3.SharedProps.Caption = "Ventana";
			popupMenuTool3.SharedProps.MergeOrder = 99;

			popupMenuTool3.Tools.AddToolRange(new String[] { "MDIWindowListTool1" });

			tbMenu.Tools.AddRange(new ToolBase[] {popupMenuTool1, popupMenuTool2, popupMenuTool3});


			this.AgregarEnsamblado(Assembly.GetExecutingAssembly());
			this.AgregarEnsamblado(Assembly.GetEntryAssembly());
			this.EstablecerTimers();

			ButtonTool boton = new ButtonTool("MP.Archivo.Salir");
			_tbManager.Tools.Add(boton);
			boton.SharedProps.Caption = "Salir";
			boton.SharedProps.MergeOrder = 99;
			this.AgregarAPadre(boton, "PopupArchivo");

			popupMenuTool1.Tools["MP.Archivo.Salir"].InstanceProps.IsFirstInGroup = true;

			this.ResumeLayout();

			this.CargarPreferencias();
		}
		public void CerrarFormulariosMDI()
		{
			foreach (Form form in this.MdiChildren)
			{
				form.Close();
				form.Dispose();
			}
		}

		private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_preguntarAlSalir && Mensaje.Pregunta("¿Está seguro que desea salir de la aplicación?") == DialogResult.No)
			{
				e.Cancel = true;
			}
			else
			{
				_instancia = null;
				GuardarPreferencias();
			}
		}

		private void TraducirStringsInfragistics()
		{
			Infragistics.Shared.ResourceCustomizer rc = Infragistics.Win.UltraWinToolbars.Resources.Customizer;
			rc.SetCustomizedString("MdiCommandCloseWindows", "Cerrar todas las ventanas");

			rc = Infragistics.Win.UltraWinGrid.Resources.Customizer;
			rc.SetCustomizedString("RowFilterDropDownAllItem", "(Todas)");
			rc.SetCustomizedString("RowFilterDropDownBlanksItem", "(Vacías)");
			rc.SetCustomizedString("RowFilterDropDownCustomItem", "(Personalizar...)");
			rc.SetCustomizedString("RowFilterDropDownNonBlanksItem", "(No Vacías)");
			rc.SetCustomizedString("RowFilterDialogBlanksItem", "(Vacías)");
			rc.SetCustomizedString("RowFilterDialogDBNullItem", "(Nulas)");
			rc.SetCustomizedString("RowFilterDialogEmptyTextItem", "(Texto Vacío)");
			rc.SetCustomizedString("RowFilterDialogOperandHeaderCaption", "Operando");
			rc.SetCustomizedString("RowFilterDialogOperatorHeaderCaption", "Operador");
			rc.SetCustomizedString("RowFilterDialogTitlePrefix", "Ingrese criterio de filtro");
			rc.SetCustomizedString("RowFilterDropDownEquals", "Es igual a");
			rc.SetCustomizedString("RowFilterDropDownGreaterThan", "Mayor que");
			rc.SetCustomizedString("RowFilterDropDownGreaterThanOrEqualTo", "Mayor o igual que");
			rc.SetCustomizedString("RowFilterDropDownLessThan", "Menor que");
			rc.SetCustomizedString("RowFilterDropDownLessThanOrEqualTo", "Menor o igual que");
			rc.SetCustomizedString("RowFilterDropDownLike", "Como");
			rc.SetCustomizedString("RowFilterDropDownMatch", "Coincide con expresión regular");
			rc.SetCustomizedString("RowFilterDropDownNotEquals", "No es igual a");

			rc.SetCustomizedString("RowFilterDropDown_Operator_Contains", "Contiene");
			rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotContain", "No contiene");
			rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotEndWith", "No termina en");
			rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotMatch", "No coincide con");
			rc.SetCustomizedString("RowFilterDropDown_Operator_DoesNotStartWith", "No comienza por");
			rc.SetCustomizedString("RowFilterDropDown_Operator_EndsWith", "Termina en");
			rc.SetCustomizedString("RowFilterDropDown_Operator_NotLike", "No como");
			rc.SetCustomizedString("RowFilterDropDown_Operator_StartsWith", "Comienza por");

			rc.SetCustomizedString("RowFilterRegexError", "Error procesando expresión regular {0}. Por favor, ingrese una expresión válida.");
			rc.SetCustomizedString("RowFilterRegexErrorCaption", "Expresión regular inválida");
			rc.SetCustomizedString("FilterDialogAddConditionButtonText", "&Agregar una Condición");
			rc.SetCustomizedString("FilterDialogAndRadioText", "Condiciones Y");
			rc.SetCustomizedString("FilterDialogCancelButtonText", "&Cancelar");
			rc.SetCustomizedString("FilterDialogDeleteButtonText", "Borrar Condición");
			rc.SetCustomizedString("FilterDialogOkButtonNoFiltersText", "&Sin filtros");
			rc.SetCustomizedString("FilterDialogOkButtonText", "&OK");
			rc.SetCustomizedString("FilterDialogOrRadioText", "Condiciones O");
			rc.SetCustomizedString("SummaryTypeSum", "");
			rc.SetCustomizedString("ColumnChooserButtonToolTip", "Clic aquí para personalizar la nombreVista actual.");
			rc.SetCustomizedString("FilterClearButtonToolTip_RowSelector", "Clic aquí para remover todos los filtros.");
			rc.SetCustomizedString("FilterClearButtonToolTip_FilterCell", "Clic aquí para remover filtro para {0}.");

			rc = Infragistics.Win.UltraWinDock.Resources.Customizer;
			rc.SetCustomizedString("PaneButtonToolTipPin", "Ocultar Automáticamente");
			rc.SetCustomizedString("ContextMenuAutoHide", "Ocultar Automáticamente");
			rc.SetCustomizedString("ContextMenuDockable", "Acoplable");
			rc.SetCustomizedString("ContextMenuFloating", "Flotante");
			rc.SetCustomizedString("ContextMenuHide", "Ocultar");
			rc.SetCustomizedString("PaneButtonToolTipClose", "Cerrar");
			rc.SetCustomizedString("PaneButtonToolTipMaximize", "Maximizar");
			rc.SetCustomizedString("PaneButtonToolTipMinimize", "Minimizar");
			rc.SetCustomizedString("PaneButtonToolTipUnpin", "Ocultar Automáticamente");

			rc = Infragistics.Win.UltraWinExplorerBar.Resources.Customizer;
			rc.SetCustomizedString("NavigationContextMenu_NavigationPaneOptions", "Opciones del Panel de Navegación");
			rc.SetCustomizedString("NavigationPaneOptionsDialog_Caption", "Opciones del Panel de Navegación");
			rc.SetCustomizedString("NavigationPaneOptionsDialog_MoveDownButton", "Mover abajo");
			rc.SetCustomizedString("NavigationPaneOptionsDialog_MoveUpButton", "Mover arriba");
			rc.SetCustomizedString("NavigationQuickCustomizeButton_Tooltip", "Configurar botones");
			rc.SetCustomizedString("NavigationQuickCustomizeMenu_ShowFewerButtons", "Mostrar menos botones");
			rc.SetCustomizedString("NavigationQuickCustomizeMenu_ShowMoreButtons", "Mostrar más botones");

			rc = Infragistics.Win.UltraWinTabbedMdi.Resources.Customizer;
			rc.SetCustomizedString("MenuItemClose", "Cerrar");
			rc.SetCustomizedString("MenuItemMoveToNextGroup", "Mover al próximo grupo");
			rc.SetCustomizedString("MenuItemMoveToPreviousGroup", "Mover al grupo anterior");
			rc.SetCustomizedString("MenuItemNewHorizontalGroup", "Nuevo grupo Horizontal");
			rc.SetCustomizedString("MenuItemNewVerticalGroup", "Nuevo grupo Vertical");
		}

		private void AgregarEnsamblado(Assembly ass)
		{
			this.ConfigurarDesdeEnsamblado(ass);
		}
		private void SetearPropiedadesForm(XmlElement nodo)
		{

			for (int i = 0; i < nodo.ChildNodes.Count; i++)
			{

				if (nodo.ChildNodes[i].Name.ToUpper() == "PROPIEDAD")
				{
					SeteaPropiedadControlPorXml(this, nodo.ChildNodes[i] as XmlElement);
				}
			}
		}

		#region CrearPaneles

		/// <summary>
		/// Crea Panel con Controles diseñados por usuario Anexados(Dockeados) a un toolbar
		/// </summary>
		/// <param name="nodo"></param>
		private void CrearPanel(XmlElement nodo)
		{
			#region Crea Panel a dockear
			Panel nuevoPanel = new Panel();
			#endregion

			#region Verifica Propiedades necesarias
			if (String.IsNullOrEmpty(nodo.GetAttribute("key")))
			{
				Mensaje.Advertencia("No se ha asignado el nombre del control");
				return;
			}
			#endregion

			#region Ingresa nombre y Dockea
			nuevoPanel.Name = nodo.GetAttribute("key");
			DockAreaPane panel = new DockAreaPane((DockedLocation)Util.ConvertirValor(typeof(DockedLocation), nodo.GetAttribute("dock")));
			if (!String.IsNullOrEmpty(nodo.GetAttribute("size").ToUpper()))
			{
				String sValor = nodo.GetAttribute("size").ToString();
				Object valor = Util.ConvertirValor(typeof(int), sValor);
				if (valor == null) { valor = 200; }
				Size largo = new Size((int)valor, panel.Size.Height);
				panel.Key = nuevoPanel.Name;
				panel.Size = largo;
			}
			DockableControlPane panelControl = ultraDockManager1.ControlPanes.Add(nuevoPanel.Name, nodo.GetAttribute("nombre"), nuevoPanel);
			panel.Panes.Add(panelControl);
			ultraDockManager1.DockAreas.Add(panel);
			#endregion

			#region acceso desde ventana
			ButtonTool boton = new ButtonTool("MP." + nodo.GetAttribute("key"));
			boton.SharedProps.Caption = nodo.GetAttribute("nombre");
			boton.SharedProps.Tag = nuevoPanel.Name;
			int ubicacion = _tbManager.Tools.IndexOf("PopupVer");
			_tbManager.Tools.Add(boton);
			ToolBase Tool = _tbManager.Tools[ubicacion];
			if (Tool != null)
			{
				(Tool as PopupMenuTool).Tools.AddTool("MP." + nodo.GetAttribute("key"));
			}
			#endregion

			#region Ingresa Shortcut
			String teclaasignada = nodo.GetAttribute("shortcut");
			if (!String.IsNullOrEmpty(teclaasignada))
			{
				try
				{
					boton.SharedProps.Shortcut = (Shortcut)Util.ConvertirValor(typeof(Shortcut), teclaasignada);
				}
				catch
				{
					Mensaje.Advertencia("No se pudo asignar el shortcut a " + nuevoPanel.Name);
				}
			}

			#endregion

			for (int i = 0; i < nodo.ChildNodes.Count; i++)
			{
				Boolean ultimo = (nodo.ChildNodes.Count - 1 == i);
				XmlElement elem = nodo.ChildNodes[i] as XmlElement;
				if (elem.Name.ToUpper() == "CONTROL")
				{
					CrearControl(nuevoPanel, elem, ultimo);
				}
				else
					if (elem.Name.ToUpper() == "PROPIEDAD")
					{
						SeteaPropiedadControlPorXml(panelControl, nodo.ChildNodes[i] as XmlElement);
					}
			}


		}
		private void CrearControl(Panel nuevoPanel, XmlElement nodo, Boolean ultimo)
		{
			String nombre = nodo.GetAttribute("key");
			Type tipoUserControl = Type.GetType(nombre, false, true);
			if (tipoUserControl == null)
			{
				throw new Exception(String.Format("No se pudo resolver el tipo {0} para el panel {1}", nombre, nuevoPanel.Name));
			}
			Control userControl = Activator.CreateInstance(tipoUserControl) as Control;
			if (userControl == null)
			{
				throw new Exception(nombre + "no deriva de Control Verifique");
			}
			if (userControl is PanelNavegacionUserControl)
			{
				(userControl as PanelNavegacionUserControl).ComandoEjecutado += new ComandoEjecutadoEventHandler(FormPrincipal_ComandoEjecutado);
				_panelNavegacion = userControl as PanelNavegacionUserControl;
			}
			nuevoPanel.Name = nodo.GetAttribute("nombre");

			for (int i = 0; i < nodo.ChildNodes.Count; i++)
			{
				foreach (XmlElement elem in nodo.ChildNodes)
				{
					if (elem.Name.ToUpper() == "PROPIEDAD")
					{
						SeteaPropiedadControlPorXml(userControl, elem);
					}
					else
						if (elem.Name.ToUpper() == "EVENTO")
						{
							SetearEvento(userControl, elem);
						}
				}
			}
			nuevoPanel.Controls.Add(userControl);
			userControl.BringToFront();
			if (ultimo)
			{
				userControl.Dock = DockStyle.Fill;
			}
			else
				userControl.Dock = DockStyle.Top;


		}

		#endregion

		#region Obtencion de MemberInfo y propiedades, Esto Tendria que ir en Util.Reflexion

		/// <summary>
		/// Devuelve el valor de una ruta por reflexión, a partir de un objeto base.
		/// Por ejemplo: control1.Panel1.TextBox1.Text
		/// </summary>
		/// <param name="objeto"></param>
		/// <param name="sPropiedad"></param>
		/// <returns></returns>
		private static MemberInfo ObtenerMemberInfoDesdeClase(String sCadena)
		{
			if (String.IsNullOrEmpty(sCadena))
			{
				return null;
			}
			String[] parseo = sCadena.Split(';');
			Type tipo = Type.GetType(parseo[0].Trim());
			if (parseo.Length == 2 && tipo != null)
			{
				MemberInfo[] miembros = tipo.GetMember(parseo[1].Trim());
				if (miembros.Length > 0) { return miembros[0]; }
			}
			return null;
		}
		/// <summary>
		/// devuelve un MemberInfo  desde una Clase Estatica
		/// tiene dos partes separadas por punto y coma
		/// la izq: es la clase + mas el ensamblado separado por coma
		/// la der: es el Miembro que se quiere buscar
		/// el miembro puede ser una propiedad, un evento, un metodo, un campo,etc.
		/// cualquier derivado de MemberInfo
		/// Si el tipo o el miembro no existe, devuelve null
		/// </summary>
		/// <param name="sCadena">type , ensamblado; MemberInfo</param>
		/// <returns></returns>

		/// <summary>
		/// Devuelve un MemberInfo a partir de un objeto
		/// 
		/// </summary>
		/// <param name="objeto">Objeto al que se le busca el MemberInfo</param>
		/// <param name="sRutaMemberInfo">Ruta de Ubicacion</param>
		/// <returns></returns>
		private static MemberInfo ObtenerMemberInfoDesdeObjeto(Control objeto, String sRutaMemberInfo, out Control control)
		{
			String[] parseo = sRutaMemberInfo.Split('.');
			Control oMiembroBase = objeto;
			for (int i = 0; i < parseo.Length; i++)
			{
				try
				{
					if (i == parseo.Length - 1)
					{
						control = oMiembroBase;
						Type tipo = oMiembroBase.GetType();
						return tipo.GetMember(parseo[i])[0];
					}
					else
					{
						oMiembroBase = oMiembroBase.Controls.Find(parseo[i], false)[0];
					}
				}
				catch (Exception ex)
				{
					throw new ArgumentException("no  se encontro el miembro " + sRutaMemberInfo, ex);
				}
			}
			control = null;
			return null;
		}
		private Object DevolverValorPropiedad(Object objeto, String sPropiedad)
		{
			String[] parseo = sPropiedad.Split('.');
			Object propiedadBase = Type.GetType(parseo[0]);
			for (int i = 0; i < parseo.Length; i++)
			{
				try
				{
					if (i == parseo.Length - 1)
					{
						Object valor = Util.LeerProperty(propiedadBase, parseo[i]);
						return valor;
					}
					else
					{
						propiedadBase = Util.TipoProperty(propiedadBase, parseo[i]);
					}
				}
				catch
				{
					Mensaje.Advertencia("No existe la Propiedad");
					return null;
				}
			}
			return null;
		}
		private static Boolean EscribirValorPropiedad(Object objeto, String sPropiedad, String valorNuevo)
		{
			String[] parseo = sPropiedad.Split('.');
			Object objetoBase = objeto;
			Object valor = null;
			for (int i = 0; i < parseo.Length; i++)
			{
				if (i == parseo.Length - 1)
				{
					Type tipo = Util.TipoProperty(objetoBase, parseo[i]);
					if (tipo == null)
					{
						throw new Exception(String.Format("No existe la propiedad {0}", parseo[i]));
					}

					if (tipo == typeof(Icon) || tipo == typeof(Image))
					{
						if (!String.IsNullOrEmpty(valorNuevo))
						{
							valor = Recursos.TraerRecursoEnsamblado(valorNuevo);
							if (valor == null)
							{
								throw new Exception(String.Format("No existe el recurso {0} para la propiedad {1}", valorNuevo, sPropiedad));
							}
						}
					}
					else
					{
						try
						{
							valor = Util.ConvertirValor(Util.TipoProperty(objetoBase, parseo[i]), valorNuevo);
						}
						catch (Exception ex)
						{
							throw new Exception(String.Format("No se pudo convertir el valor {0} para la propiedad {1}", valorNuevo, sPropiedad), ex);
						}
					}
					try
					{
						return Util.EscribirProperty(objetoBase, parseo[i], valor);
					}
					catch (Exception ex)
					{
						throw new Exception(String.Format("No se pudo escribir la propiedad {0}", sPropiedad), ex);
					}
				}
				else //OBTENEMOS LA PROPIEDAD INTERMEDIA
				{
					try
					{
						objetoBase = Util.LeerProperty(objetoBase, parseo[i]);
					}
					catch (Exception ex)
					{
						throw new Exception(String.Format("Error al leer la propiedad {0}: {1}", parseo[i], ex.Message));
					}
				}
			}
			return false;
		}

		#endregion

		#region Tratamiento del Archivo Xml

		/// <summary>
		/// Busca en el ensamblado archivo .mod y procesa el contenido de dicho archivo
		/// </summary>
		/// <param name="ass"></param>
		private void ConfigurarDesdeEnsamblado(Assembly ass)
		{
			Assembly assembly = ass;
			string xml = String.Empty;

			foreach (string fileName in assembly.GetManifestResourceNames())
			{
				if (fileName.EndsWith(".mod.xml"))
				{
					xml = fileName;

					#region CREAR Y PROCESAR EL XMLDOCUMENT

					if (xml.Length > 0)
					{
						Stream stream = assembly.GetManifestResourceStream(xml);

						XmlDocument documento = new XmlDocument();
						documento.Load(stream);
						XmlNodeList cmd = documento.DocumentElement.ChildNodes;
						String nombrecomando = String.Empty;

						try
						{
							foreach (XmlElement elem in cmd)
							{
								ProcesarElementoXml(elem, ass);
							}
						}
						catch (Exception ex)
						{
							Mensaje.Error(ex.Message, ex);
						}
					}
					#endregion
				}
			}
		}
		private static void SeteaPropiedadControlPorXml(Object control, XmlElement elem)
		{
			String propiedad = elem.GetAttribute("nombre");
			String sValor = elem.GetAttribute("valor");

			EscribirValorPropiedad(control, propiedad, sValor);
		}
		private void ProcesarElementoXml(XmlElement elem, Assembly ass)
		{
			string nombreDelEnsamblado = ass.GetName().Name;

			string key = elem.GetAttribute("key");
			string nombre = elem.GetAttribute("nombre");
			string padrenombre = elem.GetAttribute("padre");
			string imagen = elem.GetAttribute("imagen");
			string orden = elem.GetAttribute("orden");
			if (elem.Name.ToUpper() == "MENU")
			{
				#region CREAR EL MENU
				if (!_tbManager.Tools.Exists(key))
				{
					UltraToolbar toolbar = _tbManager.Toolbars.AddToolbar(key);
					toolbar.Text = nombre;
					string menuprincipal = elem.GetAttribute("menuprincipal");
					if (menuprincipal.ToUpper() == "SI")
					{
						toolbar.IsMainMenuBar = true;
						toolbar.DockedRow = 0;
						//Agregar Ventana y Salir
						PopupMenuTool popup = new PopupMenuTool("MP.Ventanas");
						popup.Tag = _tbManager.Tools.Add(popup);
						popup.SharedProps.Caption = "Ventanas";
						toolbar.Tools.AddTool("MP.Ventanas");
					}
				}
				#endregion
			}
			else if (elem.Name.ToUpper() == "TOOLBAR")
			{
				#region CREAR EL TOOLBAR
				if (!_tbManager.Toolbars.Exists(key))
				{
					UltraToolbar toolbar = _tbManager.Toolbars.AddToolbar(key);
					toolbar.IsStockToolbar = true;
					toolbar.Text = nombre;
				}
				#endregion
			}
			else if (elem.Name.ToUpper() == "POPUP")
			{
				#region CREAR EL POPUP
				PopupMenuTool popup = new PopupMenuTool(key);
				popup.Tag = _tbManager.Tools.Add(popup);
				popup.SharedProps.Caption = nombre;
				Image imagenRecurso = null;
				if (!String.IsNullOrEmpty(imagen))
				{
					imagenRecurso = Recursos.TraerRecursoEnsamblado(imagen) as Image;
				}
				if (imagen != null)
				{
					popup.SharedProps.AppearancesSmall.Appearance.Image = imagenRecurso;
				}
				AgregarAPadre(popup, padrenombre);

				#endregion
			}
			else if (elem.Name.ToUpper() == "COMANDO")
			{
				#region Crear Boton de Accion
				if (_tbManager.Tools.Exists(key))
				{
					throw new Exception(String.Format("Error al procesar comando. La clave {0} ya existe.",key));
				}
				String teclaasignada = String.Empty;
				teclaasignada = elem.GetAttribute("shortcut");
				ButtonTool boton = new ButtonTool(key);
				if (!String.IsNullOrEmpty(teclaasignada))
				{
					try
					{

						boton.SharedProps.Shortcut = (Shortcut)Util.ConvertirValor(typeof(Shortcut), teclaasignada);
					}
					catch
					{
						Mensaje.Advertencia("No se pudo asignar el Shortcut a " + nombre);
					}

				}
				boton.SharedProps.Caption = nombre;
				boton.SharedProps.DisplayStyle = ToolDisplayStyle.ImageAndText;
				boton.SharedProps.Priority = 1;
				Image imagenRecurso = null;
				if (!String.IsNullOrEmpty(imagen))
					imagenRecurso = Recursos.TraerRecursoEnsamblado(imagen) as Image;
				if (imagenRecurso != null)
				{
					boton.SharedProps.AppearancesSmall.Appearance.Image = imagenRecurso;
				}
				int nrodeejec = _tbManager.Tools.Add(boton);

				#region AgregarInstruccion
				Comando instruccion = new Comando();
				instruccion.Key = key;
				instruccion.Target = elem.GetAttribute("target");
				instruccion.Nombre = elem.Name;
				instruccion.Descripcion = nombre;
				instruccion.Accion = (TipoComando)Enum.Parse(typeof(TipoComando), elem.GetAttribute("tipo"));

				#endregion

				#region Agregar Parametros

				foreach (XmlElement child in elem.ChildNodes)
				{
					Type tipodeparametro = Type.GetType(child.GetAttribute("tipo"));
					instruccion.Parametros.Add(new ParametroComando(tipodeparametro, child.GetAttribute("valor")));
				}

				#endregion

				boton.SharedProps.Tag = instruccion;
				AgregarAPadre(boton, padrenombre);

				#endregion
			}
			else if (elem.Name.ToUpper() == "TIMER")
			{
				#region CREAR EL TEMPORIZADOR

				Temporizador temporizador = new Temporizador();
				temporizador.Key = key;
				temporizador.Nombre = nombre;
				temporizador.Descripcion = elem.GetAttribute("descripcion");
				temporizador.Intervalo = Convert.ToInt32(elem.GetAttribute("intervalo"));

				#region AGREGAR COMANDOS

				XmlNodeList comandos = elem.GetElementsByTagName("comando");
				foreach (XmlElement nodoAccion in comandos)
				{
					Comando comando = new Comando();
					comando.Key = nodoAccion.GetAttribute("key");
					comando.Target = nodoAccion.GetAttribute("target");
					comando.Nombre = nodoAccion.GetAttribute("nombre");
					comando.Descripcion = nodoAccion.GetAttribute("descripcion");
					comando.Accion = (TipoComando)Enum.Parse(typeof(TipoComando), nodoAccion.GetAttribute("tipo"));

					temporizador.Comandos.Add(comando);

					#region Agregar Parametros

					foreach (XmlElement nodoParametro in nodoAccion.ChildNodes)
					{
						Type tipo = Type.GetType(nodoParametro.GetAttribute("tipo"));
						comando.Parametros.Add(new ParametroComando(tipo, nodoParametro.GetAttribute("valor")));
					}

					#endregion

				}


				#endregion

				#endregion

				_timers.Add(temporizador);

			}

			else if (elem.Name.ToUpper() == "ASOCIAR")
			{
				if (!_tbManager.Tools.Exists(key))
				{
					throw new ArgumentException("No existe el tool " + key);
				}
				ToolBase asociado = _tbManager.Tools[key];

				AgregarAPadre(asociado, padrenombre);
			}
			else if (elem.Name.ToUpper() == "CREARRECURSO")
			{
				String nombrerecurso = elem.GetAttribute("recurso");
				Recursos.AgregarEnsamblado(ass, nombrerecurso);
			}
			else if (elem.Name.ToUpper() == "PANEL")
			{
				CrearPanel(elem);
			}
			else if (elem.Name.ToUpper() == "FORMPRINCIPAL")
			{
				SetearPropiedadesForm(elem);
			}
		}
		private static Boolean SetearEvento(Control objeto, XmlElement elem)
		{
			XmlAttributeCollection atrib = elem.Attributes;
			{
				String sControl = atrib["nombre"].Value;
				String sDelegado = atrib["delegado"].Value;
				#region Asigna Metodo a Control
				// obtengo el Control
				Control control = null;
				//((UserControl)objeto).Controls.Find(sControl,false)[0];
				MethodInfo metodoInfo = (MethodInfo)ObtenerMemberInfoDesdeClase(sDelegado);
				EventInfo eventoInfo = (EventInfo)ObtenerMemberInfoDesdeObjeto(objeto, sControl, out control);
				TextBox t = new TextBox();
				if (eventoInfo != null)
				{
					eventoInfo.GetRemoveMethod();
					Delegate instancia = (Delegate)Activator.CreateInstance(eventoInfo.EventHandlerType, new object[] { metodoInfo.GetType(), metodoInfo.MethodHandle.GetFunctionPointer() });
					eventoInfo.AddEventHandler(control, instancia);
				}
				#endregion

			}
			return false;
		}

		#endregion

		public virtual void CargarPreferencias()
		{
			UserSettings settings = new UserSettings();
			int panelNavegacionAncho = settings.GetInt("PanelNavegacionAncho");
			if (panelNavegacionAncho != 0)
			{
				this.ultraDockManager1.DockAreas[0].Size = new Size(panelNavegacionAncho, -1);
				this.ultraDockManager1.ControlPanes[0].FlyoutSize = new Size(panelNavegacionAncho, -1);
			}
			bool autohide = settings.GetBoolean("PanelNavegacionAutoHide");
			if (autohide)
			{
				this.ultraDockManager1.DockAreas[0].Unpin();
			}
			else
			{
				this.ultraDockManager1.DockAreas[0].Pin();
			}
			
			this.WindowState = FormWindowState.Normal;

			int appWidth = settings.GetInt("AppWidth");
			int appHeight = settings.GetInt("AppHeight");
			if (appHeight > 0 && appWidth > 0)
			{
				this.Size = new Size(appWidth, appHeight);
			}
			int appLeft = settings.GetInt("AppLeft");
			int appTop = settings.GetInt("AppTop");
			if (appLeft != 0 && appTop != 0)
			{
				this.Location = new Point(appLeft, appTop);
			}
			int appWindowState = settings.GetInt("AppWindowState");
			if (appWindowState >= 0)
			{
				this.WindowState = (FormWindowState)appWindowState;
			}
		}
		public virtual void GuardarPreferencias()
		{
			try
			{
				UserSettings settings = new UserSettings();
				settings["PanelNavegacionAncho"] = this.ultraDockManager1.DockAreas[0].Size.Width.ToString();
				settings["PanelNavegacionAutoHide"] = (!this.ultraDockManager1.ControlPanes[0].Pinned).ToString();
				settings["AppWindowState"] = Convert.ToInt32(this.WindowState).ToString();
				this.WindowState = FormWindowState.Normal;
				settings["AppWidth"] = this.Width.ToString();
				settings["AppHeight"] = this.Height.ToString();
				settings["AppTop"] = this.Top.ToString();
				settings["AppLeft"] = this.Left.ToString();
				settings.Guardar();
			}
			catch { }
		}

		private void AgregarAPadre(ToolBase elemento, string padre)
		{
			//EL PADRE PUEDE SER UN POPUPMENUTOOL O UN TOOLBAR

			if (_tbManager.Toolbars.Exists(padre))
			{
				_tbManager.Toolbars[padre].Tools.Add(elemento as ToolBase);
			}
			else if (_tbManager.Tools.Exists(padre))
			{
				PopupMenuTool toolPadre = _tbManager.Tools[padre] as PopupMenuTool;
				if (toolPadre != null)
				{
					toolPadre.Tools.AddTool(elemento.Key);
				}
				else
				{
					throw new ArgumentException(String.Format("El item padre {0} no es de un tipo válido. Los tipos válidos son Toolbar y Popup", padre));
				}
			}
			else
			{
				throw new ArgumentException(String.Format("El item padre {0} no está definido.", padre));
			}
		}
		private void EjecutarComando(Comando opcion, bool nuevaVentana)
		{
			try
			{
				Form form = null;
				Type tipo = null;

				switch (opcion.Accion)
				{
					case TipoComando.AbrirMDI:

						#region ABRIRMDI

						if (!nuevaVentana)
						{
							FormMDIBase fMDI = TraerMDI(opcion.Key) as FormMDIBase;
							if (fMDI != null)
							{
								MostrarFormularioMDI(fMDI, true, false);
								return;
							}
						}
						tipo = Type.GetType(opcion.Target);
						if (tipo == null)
						{
							throw new ArgumentException(String.Format("No se ha encontrado el tipo {0}", opcion.Target));
						}
						if (!tipo.IsSubclassOf(typeof(FormMDIBase)))
						{
							throw new Exception("El comando AbrirMDI requiere que el formulario derive de FormMDIBase. Asegúrese que el tipo de acción sea correcto o bien derive el formulario de FormMDIBase");
						}
						form = Activator.CreateInstance(tipo, Comando.ConvertirParametros(opcion.Parametros)) as Form;
						this.PrepararYMostrarFormularioMDI(form as FormMDIBase, opcion.Nombre, opcion.Imagen, opcion.Key, opcion.Descripcion);
						break;

						#endregion

					case TipoComando.AbrirForm:
						#region ABRIRFORM

						tipo = Type.GetType(opcion.Target);
						if (tipo == null)
							throw new ArgumentException(String.Format("No se ha encontrado el tipo {0}", opcion.Target));
						form = Activator.CreateInstance(tipo, Comando.ConvertirParametros(opcion.Parametros)) as Form;
						form.Show();
						break;

						#endregion
					case TipoComando.AbrirModal:

						#region ABRIRFORM
						tipo = Type.GetType(opcion.Target);
						if (tipo == null)
						{
							throw new ArgumentException(String.Format("No se ha encontrado el tipo {0}", opcion.Target));
						}
						form = Activator.CreateInstance(tipo, Comando.ConvertirParametros(opcion.Parametros)) as Form;
						form.ShowDialog();
						break;

						#endregion
					
					case TipoComando.Metodo:

						#region EJECUTAR METODO
						
						MethodInfo info = (MethodInfo)ObtenerMemberInfoDesdeClase(opcion.Target);
						if (info != null)
						{
							info.Invoke(null, Comando.ConvertirParametros(opcion.Parametros.ToArray()));
						}
						break;

						#endregion
				}
			}
			catch (Exception ex)
			{
				Mensaje.Error(ex.Message, ex);
			}
		}
		private void FormPrincipal_ComandoEjecutado(object sender, ComandoEjecutadoEventArgs e)
		{
			EjecutarComando(e.Comando, e.NuevaVentana);
		}
		private void EstablecerTimers()
		{
			foreach (Temporizador temporizador in _timers)
			{
				Timer timer = new Timer();
				timer.Interval = (temporizador.Intervalo * 1000);
				timer.Tag = temporizador.Comandos;
				timer.Tick += new EventHandler(timer_Tick);
				timer.Enabled = true;
			}
		}
		public static void Salir()
		{
			_instancia.Close();
		}

		#region MANEJO DE FORMULARIOS MDI

		public void PrepararYMostrarFormularioMDI(FormMDIBase form, string titulo, string nombreIcono, string key)
		{
			PrepararYMostrarFormularioMDI(form, titulo, nombreIcono, key, String.Empty);
		}
		public void PrepararYMostrarFormularioMDI(FormMDIBase form, string titulo, string nombreIcono, string key, string descripcion)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				form.Text = titulo;
				form.Key = key;
				form.Descripcion = descripcion;
				
				object recurso = Recursos.TraerRecursoEnsamblado(nombreIcono);
				if (recurso is Icon)
				{
					form.Icon = recurso as Icon;
				}
				else if (recurso is Image)
				{
					form.Icon = Icon.FromHandle((recurso as Bitmap).GetHicon());
				}

				form.MdiParent = this;
				form.ActualizarStatusBarText += new EventHandler(form_ActualizarStatusBarText);
				this.MostrarFormularioMDI(form, false, true);
			}
			catch (Exception ex)
			{
				Mensaje.Error(ex.Message, ex);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void form_ActualizarStatusBarText(object sender, EventArgs e)
		{
			FormMDIBase fMDI = sender as FormMDIBase;
			if (fMDI != null)
			{
				this.ultraStatusBar1.Panels["Status"].Text = fMDI.StatusBarText;
			}
		}
		public void MostrarFormularioMDI(FormMDIBase form, bool actualizarLista, bool agregarHistoria)
		{
			if (this.ActiveMdiChild != null)
			{
				//si es un form lista, retener la _posicion antes de ocultarlo porque despues se pierde
				if (this.ActiveMdiChild is FormListaBase)
				{
					(this.ActiveMdiChild as FormListaBase).RetenerPosicionGrilla();
				}

			}
			//hacer visible el formulario que queremos activar
			form.Visible = true;
			form.Activate();

			//si es un form lista base
			FormListaBase fListaBase = form as FormListaBase;
			if (fListaBase != null)
			{
				fListaBase.RetenerPosicionGrilla();
				if (actualizarLista && fListaBase.DebeActualizarAlActivar)
				{
					fListaBase.ActualizarListaDesdeOrigen();
				}
				fListaBase.RestaurarPosicionGrilla();
			}

			//llamada critica para que funcione correctamente el toolbarmanager
			//luego de, por ejemplo, cargar el xml de docking. Por alguna razón
			//se rompe el merge.
			ultraToolbarsManager1.RefreshMerge();

		}
		public Form TraerMDI(string key)
		{
			foreach (FormMDIBase form in this.MdiChildren)
			{
				if (form.Key == key)
				{
					return form;
				}
			}
			return null;
		}
		//private void MDIForm_FormInvalidado(object sender, FormInvalidadoEventArgs e)
		//{
		//    Form f = (Form)sender;
		//    f.MdiParent = null;
		//    f.Visible = false;
		//    f.Close();
		//    f.Dispose();

		//    string tempTexto = "Al tratar de abrir el formulario se produjo el siguiente error: " + Environment.NewLine
		//        + Environment.NewLine
		//        + e.Excepcion.Message + Environment.NewLine
		//        + Environment.NewLine
		//        + "El formulario no puede abrirse. ";

		//    Mensaje.Error(tempTexto, e.Excepcion);
		//}
		private void FormPrincipal_MdiChildActivate(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild != null)
			{
				FormMDIBase fMDI = this.ActiveMdiChild as FormMDIBase;
				if (fMDI != null)
				{
					//status bar text
					this.ultraStatusBar1.Panels["Status"].Text = fMDI.StatusBarText;
				}
			}
			else
			{
				this.ultraStatusBar1.Panels["Status"].Text = String.Empty;
			}

			FormListaBase formLista = this.ActiveMdiChild as FormListaBase;
			if (formLista != null && formLista.DebeActualizarAlActivar)
			{
				formLista.ActualizarListaDesdeOrigen();
			}

		}


		#endregion

		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			// verifico si es un comando si no es un comando es una opcion del menu ventana
			Comando comando = ultraToolbarsManager1.Tools[e.Tool.Key].SharedProps.Tag as Comando;
			if (ultraToolbarsManager1.Tools[e.Tool.Key].Key.ToUpper() == "MP.ARCHIVO.SALIR")
			{
				Salir();
			}
			if (comando == null)
			{
				String visualizar = ultraToolbarsManager1.Tools[e.Tool.Key].SharedProps.Tag as String;
				// verifico que visualizar sea distino de null o vacio
				if (!String.IsNullOrEmpty(visualizar) && !String.IsNullOrEmpty(visualizar))
				{
					#region Verifico la existencia del panel, y lo busco en las diferentes Areas y lo muestro
					for (int i = 0; i < ultraDockManager1.DockAreas.Count; i++)
					{
						int posicion = ultraDockManager1.DockAreas[i].Panes.IndexOf(visualizar);
						if (posicion != -1)
						{
							DockAreaPane panelavisualizar = ultraDockManager1.DockAreas[i];
							panelavisualizar.ShowChildPanes(true);
							return;
						}
					}
					#endregion
				}
				return;
			}
			EjecutarComando(comando, false);
		}
		private void timer_Tick(object sender, EventArgs e)
		{
			Timer timer = sender as Timer;
			try
			{
				timer.Enabled = false;
				List<Comando> comandos = timer.Tag as List<Comando>;
				if (comandos != null)
				{
					foreach (Comando comando in comandos)
					{
						EjecutarComando(comando, false);
					}
				}
			}
			catch
			{
			}
			finally
			{
				timer.Enabled = true;
			}
		}

	}
}