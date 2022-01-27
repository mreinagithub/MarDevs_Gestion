using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinExplorerBar;
using MarDevs.Gestion.Core;
using System.Collections;
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win;

namespace MarDevs.Gestion.Win
{
	public partial class PanelNavegacionUserControl : UserControl
	{
		public PanelNavegacionUserControl()
		{
			InitializeComponent();
		}

		private Form _MDIParent;
		private bool _clicEnNodo = false;
		private PanelNavegacion _panelNavegacion;
		private UltraTreeNode _ultimoNodoClickeado = null;
		private string _nombreArchivo = String.Empty;

		public Form MDIParent
		{
			get { return _MDIParent; }
			set { _MDIParent = value; }
		}
		public UltraExplorerBar UltraExplorerBar1
		{
			get { return ultraExplorerBar1; }
		}
		public string NombreArchivo
		{
			get { return _nombreArchivo; }
			set
			{
				_nombreArchivo = value;
				Inicializar();
			}
		}
		public PanelNavegacion PanelNavegacion
		{
			get
			{
				return _panelNavegacion;
			}
		}

		private ComandoEjecutadoEventHandler _comandoEjecutado;
		public event ComandoEjecutadoEventHandler ComandoEjecutado
		{
			add { _comandoEjecutado += value; }
			remove { _comandoEjecutado -= value; }
		}

		protected virtual void OnComandoEjecutado(ComandoEjecutadoEventArgs e)
		{
			if (_comandoEjecutado != null)
			{
				// Invocar los delegados
				_comandoEjecutado(this, e);
			}
		}

		private PanelNavegacion ObtenerPanelNavegacion(Assembly assembly)
		{
			PanelNavegacion panel = null;
			string xml = String.Empty;

			foreach (string fileName in assembly.GetManifestResourceNames())
			{
				if (fileName.EndsWith("panel-navegacion.xml"))
				{
					xml = fileName;
					break;
				}
			}

			if (xml.Length > 0)
			{

				Stream stream = assembly.GetManifestResourceStream(xml);

				XmlSerializer mySerializer = new XmlSerializer(typeof(PanelNavegacion));
				panel = (PanelNavegacion)mySerializer.Deserialize(stream);
			}

			return panel;

		}
		private PanelNavegacion ObtenerDesdeRecursoIncrustado(string archivoRecursos)
		{
			string[] partes = archivoRecursos.Split(',');
			if (partes.Length != 2)
			{
				throw new ArgumentException("No se pudo encontrar el archivo de recursos: " + archivoRecursos);
			}
			Assembly assembly = BuscarEnsamblado(partes[1]);
			if (assembly == null)
			{
				throw new ArgumentException("No se pudo encontrar el ensamblado: " + partes[1]);
			}
			PanelNavegacion panel = null;
			string xml = String.Empty;
			foreach (string fileName in assembly.GetManifestResourceNames())
			{
				if (fileName.EndsWith(partes[0]))
				{
					xml = fileName;
					break;
				}
			}
			if (xml.Length > 0)
			{
				Stream stream = assembly.GetManifestResourceStream(xml);

				XmlSerializer mySerializer = new XmlSerializer(typeof(PanelNavegacion));
				panel = (PanelNavegacion)mySerializer.Deserialize(stream);
			}
			return panel;
		}

		private Assembly BuscarEnsamblado(string nombreEnsamblado)
		{
			Assembly[] ensamblados = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in ensamblados)
			{
				string[] partesNombre = assembly.FullName.Split(',');
				if (partesNombre[0] == nombreEnsamblado.Trim())
				{
					return assembly;
				}
			}
			return null;
		}

		private void RegistrarPanelNavegacion()
		{
			//this.ultraExplorerBar1.BeginUpdate();
			this.ultraExplorerBar1.NavigationMaxGroupHeaders = 0;
			this.ultraExplorerBar1.Groups.Clear();
			//this.ultraExplorerBar1.GroupSettings.Style = GroupStyle.ControlContainer;
			//this.ultraExplorerBar1.ActiveGroup = null;

			if (_panelNavegacion == null) return;

			//this.ultraTree1.Nodes.Clear();
			object imagen;
			UltraTree ultraTree;
			UltraExplorerBarGroup ultraExplorerBarGroup;

			//PANELES
			foreach (PanelNav panel in _panelNavegacion.Paneles)
			{
				#region CREAR PANEL + EL ULTRATREE

				ultraTree = new UltraTree();
				ultraTree.ContextMenuStrip = contextMenuStrip1;
				ultraTree.Dock = DockStyle.Fill;
				ultraTree.Override.HotTracking = Infragistics.Win.DefaultableBoolean.True;
				ultraTree.HideSelection = false;
				ultraTree.Indent = 15;
				ultraExplorerBarGroup = ultraExplorerBar1.Groups.Add(panel.Key, panel.Nombre);
				ultraExplorerBarGroup.Settings.Style = GroupStyle.ControlContainer;
				ultraExplorerBarGroup.Container.Controls.Add(ultraTree);

				if (panel.Imagen != null)
				{
					imagen = Recursos.TraerRecursoEnsamblado(panel.Imagen);
					if (imagen is Image)
					{
						ultraExplorerBarGroup.Settings.AppearancesLarge.HeaderAppearance.Image = imagen;
						ultraExplorerBarGroup.Settings.AppearancesSmall.HeaderAppearance.Image = imagen;
					}
				}


				#endregion

				#region CREAR LOS GRUPOS

				foreach (GrupoMenu grupo in panel.Grupos)
				{
					CrearGrupo(ultraTree, null, grupo);

				}
				#endregion

				if (ultraTree.Nodes.Count > 0)
				{
					//SUSCRIBIR A LOS EVENTOS DEL ULTRATREE
					ultraTree.Click += ultraTree_Click;
					ultraTree.MouseDown += ultraTree_MouseDown;
					ultraTree.KeyPress += ultraTree_KeyPress;
					ultraTree.MouseMove += new MouseEventHandler(ultraTree_MouseMove);
				}
				else
				{
					//si no tiene nodos no debe estar visible el panel.
					ultraExplorerBarGroup.Visible = false;
				}
			}
			this.ultraExplorerBar1.NavigationMaxGroupHeaders = -1;

			PosicionarseEnGrupoVisible();
		}
		private void PosicionarseEnGrupoVisible()
		{
            string panelSeleccionado = Properties.Settings.Default.UltimoPanelActivo;

            if (ultraExplorerBar1 == null || ultraExplorerBar1.Groups.Count <= 0)
            {
                return;
            }
            else if (ultraExplorerBar1.Groups.Exists(panelSeleccionado) && ultraExplorerBar1.Groups[panelSeleccionado].Visible)
            {
                ultraExplorerBar1.Groups[panelSeleccionado].Selected = true;
                ultraExplorerBar1.Groups[panelSeleccionado].Expanded = true;
            }
            else
            {
                ultraExplorerBar1.Groups.CollapseAll();
                foreach (UltraExplorerBarGroup g in ultraExplorerBar1.Groups)
                {
                    if (g.Visible)
                    {
                        g.Selected = true;
                        g.Expanded = true;
                        break;
                    }
                }
            }
		}

		public void Inicializar(Assembly assembly)
		{
			_panelNavegacion = ObtenerPanelNavegacion(assembly);
			RegistrarPanelNavegacion();
		}
		private void Inicializar()
		{
			if (!String.IsNullOrEmpty(_nombreArchivo))
			{
				_panelNavegacion = ObtenerDesdeRecursoIncrustado(_nombreArchivo);
				RegistrarPanelNavegacion();
			}
		}
		public void Inicializar(PanelNavegacion panelNavegacion)
		{
			_panelNavegacion = panelNavegacion;
			RegistrarPanelNavegacion();
		}
		public Comando ObtenerComando(string key)
		{
			if (_panelNavegacion == null)
			{
				return null;
			}
			else
			{
				return _panelNavegacion.ObtenerComando(key);
			}
		}
		public GrupoMenu ObtenerGrupo(string key)
		{
			if (_panelNavegacion == null)
			{
				return null;
			}
			else
			{
				return _panelNavegacion.ObtenerGrupo(key);
			}
		}

		private void CrearGrupo(UltraTree ultraTree, UltraTreeNode grupoPadre, GrupoMenu grupo)
		{
			object imagen;
			UltraTreeNode nodoGrupo = null;
			nodoGrupo = new UltraTreeNode();
			nodoGrupo.Key = "GRUPO_" + grupo.Key;
			nodoGrupo.Text = grupo.Nombre;
			nodoGrupo.Tag = grupo;
			if (grupo.Bold) nodoGrupo.Override.NodeAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			nodoGrupo.Override.NodeSpacingBefore = 4;
			if (grupo.Imagen != null)
			{
				imagen = Recursos.TraerRecursoEnsamblado(grupo.Imagen);

				if (imagen is Image)
				{
					nodoGrupo.LeftImages.Add(imagen);
				}
			}

			foreach (GrupoMenu grupoHijo in grupo.Grupos)
			{
				CrearGrupo(ultraTree, nodoGrupo, grupoHijo);
			}
			#region CREAR LAS OPCIONES

			UltraTreeNode nodoOpcion;
			Alcances alcance;
			foreach (Comando opcion in grupo.Opciones)
			{
				if (this.DesignMode)
				{
					alcance = Alcances.Total;
				}
				else
				{
					if (opcion.Privilegio == 0)//no se requieren privilegios
					{
						alcance = Alcances.Total;
					}
					else
					{
						alcance = ConfigBL.ticket.TienePrivilegio(opcion.Privilegio);
					}
				}

				if (alcance >= opcion.Alcance)
				{
					nodoOpcion = new UltraTreeNode();
					nodoOpcion.Key = opcion.GetType().Name + "_" + opcion.Key;
					nodoOpcion.Text = opcion.Nombre;
					nodoOpcion.Tag = opcion;
					if (opcion.Imagen != null)
					{
						imagen = Recursos.TraerRecursoEnsamblado(opcion.Imagen);
						if (imagen != null)
						{
							nodoOpcion.LeftImages.Add(imagen);
						}
					}
					nodoGrupo.Nodes.Add(nodoOpcion);
				}
			}
			#endregion

			//solo lo agrego si tiene nodos dentro
			//Tiene que Agregar igual ya se puede completar dinamicamente como paso con Fincas
			if (nodoGrupo.Nodes.Count > 0)
			{
				if (grupoPadre == null)
				{
					ultraTree.Nodes.Add(nodoGrupo);
				}
				else
				{
					grupoPadre.Nodes.Add(nodoGrupo);
				}
				if (grupo.Expandido)
				{
					nodoGrupo.ExpandAll();
				}
			}

		}
		private void MostrarPropiedades(Comando opcion)
		{
			FormPropiedadesCarpeta form = new FormPropiedadesCarpeta();
			form.Text = "Propiedades de " + opcion.Nombre;
			if (!String.IsNullOrEmpty(opcion.Descripcion))
			{
				form.labelDescripcion.Text = opcion.Descripcion;
			}
			form.ShowDialog();

		}
		private void ultraTree_Click(object sender, EventArgs e)
		{
			//UltraTree tree = sender as UltraTree;
			//if (this._clicEnNodo && tree.ActiveNode != null && !tree.ActiveNode.HasNodes)
			if (this._clicEnNodo && _ultimoNodoClickeado != null && !_ultimoNodoClickeado.HasNodes)
			{
				this.Cursor = Cursors.WaitCursor;
				//if (tree.ActiveNode.Tag is Comando)
				if (_ultimoNodoClickeado.Tag is Comando)
				{
					//OnComandoEjecutado(new ComandoEjecutadoEventArgs(tree.ActiveNode.Tag as Comando));
					OnComandoEjecutado(new ComandoEjecutadoEventArgs(_ultimoNodoClickeado.Tag as Comando));
				}
				this.Cursor = Cursors.Default;
			}
			//_expandioOContrajo = false;
		}
		private void ultraTree_KeyPress(object sender, KeyPressEventArgs e)
		{
			UltraTree tree = sender as UltraTree;
			switch ((Keys)e.KeyChar)
			{
				case Keys.Enter:
					this.Cursor = Cursors.WaitCursor;
					if (tree.ActiveNode.Tag is Comando)
					{
						OnComandoEjecutado(new ComandoEjecutadoEventArgs(tree.ActiveNode.Tag as Comando));
					}
					this.Cursor = Cursors.Default;
					e.Handled = true;
					break;
			}
		}
		private void ultraTree_MouseDown(object sender, MouseEventArgs e)
		{
			UltraTree tree = sender as UltraTree;
			UltraTreeNode nodo = tree.GetNodeFromPoint(e.X, e.Y);
			_ultimoNodoClickeado = nodo;
			this._clicEnNodo = (nodo != null);
			if (_ultimoNodoClickeado != null && e.Button == MouseButtons.Right)
			{
				_ultimoNodoClickeado.Selected = true;
			}
		}

		private void ultraTree_MouseMove(object sender, MouseEventArgs e)
		{
			UltraTree tree = sender as UltraTree;

			UltraTreeNode nodo = tree.GetNodeFromPoint(e.X, e.Y);

			string descripcion = String.Empty;
			if (nodo != null && nodo.Tag is Comando)
			{
				Comando comando = nodo.Tag as Comando;
				descripcion = "Descripción: " + (String.IsNullOrEmpty(comando.Descripcion) ? "NO DISPONIBLE" : comando.Descripcion);
			}
			string actual = String.Empty;
			UltraToolTipInfo info = this.ultraToolTipManager1.GetUltraToolTip(tree);
			if (info != null)
			{
				actual = info.ToolTipText;
			}
			else
			{
				info = new UltraToolTipInfo(descripcion, ToolTipImage.Default, null, DefaultableBoolean.Default);
				this.ultraToolTipManager1.SetUltraToolTip(tree, info);
			}
			if (actual != descripcion)
			{
				info.ToolTipText = descripcion;
				this.ultraToolTipManager1.ShowToolTip(tree);
			}
		}

		private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			ContextMenuStrip context = sender as ContextMenuStrip;
			if (context == null || _ultimoNodoClickeado == null)
			{
				return;
			}
			//Mensaje.Informacion(e.ClickedItem.Name + " " + (_ultimoNodoClickeado.Tag as OpcionMenu).Nombre);
			Comando opcion = _ultimoNodoClickeado.Tag as Comando;
			if (opcion != null)
			{
				if (e.ClickedItem.Text == "Propiedades")
				{
					MostrarPropiedades(opcion);
				}
				else
				{
					OnComandoEjecutado(new ComandoEjecutadoEventArgs(opcion, true));
				}
			}
		}
		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			if (_ultimoNodoClickeado == null || !(_ultimoNodoClickeado.Tag is Comando))
			{
				e.Cancel = true;
			}
		}

	}
}
