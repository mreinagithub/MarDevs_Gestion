using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Infragistics.Win.UltraWinToolbars;
using MarDevs.Gestion.Core;
using System.Windows.Forms;

namespace MarDevs.Gestion.Win
{
    public class ServicioUI
    {
        private static Hashtable _entidadesAbiertas = new Hashtable();
		private ServicioUI()
		{
		}

		private static ServicioUI _instancia;
		public static ServicioUI Instancia
		{
			get
			{
				if (_instancia == null)
				{
					_instancia = new ServicioUI();
				}
				return _instancia;
			}
		}
        
        #region PROCESAMIENTO DE ACCIONES

        /// <summary>
        /// Habilita los tools correspondientes a las acciones de la lista de acciones pasada como parámetro.
		/// Deshabilita el resto de las acciones (las no contenidas en la lista).
        /// </summary>
        /// <param name="toolbarManager"></param>
        /// <param name="acciones">Lista de acciones que se desean habilitar.</param>
		public void HabilitarAcciones(UltraToolbarsManager toolbarManager, IList<Accion> acciones)
        {
            Accion accion = null;
            foreach (ToolBase tool in toolbarManager.Tools )
            {
                accion = tool.SharedProps.Tag as Accion;
                if (accion != null)
                {
                    tool.SharedProps.Enabled = acciones.Contains(accion);
                }
            }
        }
        /// <summary>
        /// Crea los tools para las acciones pasadas como parametro en un PopupMenuTool
        /// </summary>
        /// <param name="acciones">Lista de acciones que se desea registrar.</param>
        /// <param name="popup">PopupMenuTool sobre el que se crearán los tools (uno por cada acción)</param>
		public void RegistrarAcciones(IList<Accion> acciones, PopupMenuTool popup)
        {
            if (popup == null)
            {
                throw new ArgumentNullException("El popup pasado es nulo");
            }
			foreach (Accion accion in acciones)
            {
				Image imagen = Recursos.TraerRecursoEnsamblado(accion.Imagen) as Image;
                this.CrearToolButtonEnPopup(popup, accion.Key, accion.Nombre, accion.ComenzarGrupoEnPopup, imagen, accion, accion.RutaGrupoEnPopup);
            }
        }
		/// <summary>
		/// Crea los tools para las acciones definidas para una entidad en un PopupMenuTool
		/// </summary>
		/// <param name="entidad">Entidad sobre la que se desean registrar las acciones.</param>
		/// <param name="popup">PopupMenuTool sobre el que se crearán los tools (uno por cada acción)</param>
		public void RegistrarAcciones(string entidad, PopupMenuTool popup)
		{
			if (popup == null)
			{
				throw new ArgumentNullException("El popup pasado es nulo");
			}
			foreach (Accion accion in ServicioMD.Instancia.BuscarAccionPorEntidad(entidad))
			{
                this.CrearToolButtonEnPopup(popup, accion.Key, accion.Nombre, accion.ComenzarGrupoEnPopup, null, accion, accion.RutaGrupoEnPopup);
			}
		}

		/// <summary>
		/// Método helper para crear un ToolButton en un PopupMenuTool de un UltraToolbarsManager
		/// </summary>
		/// <param name="popup">Popup en el que se creará el tool</param>
		/// <param name="key">key del tool</param>
		/// <param name="caption">label del tool</param>
		/// <param name="comenzarGrupo">Indica si antes de este tool se pondrá una línea divisoria.</param>
        /// <param name="rutaGrupo">Indica la ruta del grupo en la que se creará el ToolButton.</param>
		/// <param name="imagen">Imagen del tool</param>
		/// <param name="tag">Cualquier objeto que quiera asociarse con el tool</param>
		/// <returns>Devuelve una instancia del ButtonTool creado</returns>
        public ButtonTool CrearToolButtonEnPopup(PopupMenuTool popup, string key, string caption, bool comenzarGrupo, Image imagen, object tag, string rutaGrupo)
		{
			ButtonTool tool = null;
			if (popup != null)
			{
                PopupMenuTool popUpPadre = null;
                if (!String.IsNullOrEmpty(rutaGrupo))
                    popUpPadre = ObtenerPopUp(popup, rutaGrupo);
                else
                    popUpPadre = popup;
                    
				tool = new ButtonTool(key);
				tool.SharedProps.Tag = tag;
				tool.SharedProps.Caption = caption;
				if (imagen != null) { tool.SharedProps.AppearancesSmall.Appearance.Image = imagen; }
				popup.ToolbarsManager.Tools.Add(tool);
                popUpPadre.Tools.AddTool(key);
                popUpPadre.Tools[key].InstanceProps.IsFirstInGroup = comenzarGrupo;
			}
			return tool;
		}

        /// <summary>
        /// Método helper para crear un nuevo grupo PopUp en un PopupMenuTool de un UltraToolbarsManager
        /// </summary>
        /// <param name="popup">Popup en el que se creará el tool</param>
        /// <param name="rutaGrupo">Ruta del grupo Popup en el que se creará el tool</param>
        /// <returns>Devuelve una instancia del PopupMenuTool creado</returns>
        public PopupMenuTool ObtenerPopUp(PopupMenuTool popup, string rutaGrupo)
        {
            PopupMenuTool nuevoGrupo = null;
            string[] grupos = rutaGrupo.Split('\\');
            PopupMenuTool toolPadre = popup;
            foreach(string grupo in grupos)
            {
                if (!popup.ToolbarsManager.Tools.Exists(grupo))
                {
                    nuevoGrupo = new PopupMenuTool(grupo);
                    nuevoGrupo.SharedProps.Caption = grupo;
                    popup.ToolbarsManager.Tools.Add(nuevoGrupo);
                    toolPadre.Tools.AddTool(grupo);
                    toolPadre = nuevoGrupo;
                }
                else
                {
                    toolPadre = popup.ToolbarsManager.Tools[grupo] as PopupMenuTool;
                    nuevoGrupo = popup.ToolbarsManager.Tools[grupo] as PopupMenuTool;
                }
            }
            return nuevoGrupo;
        }

		/// <summary>
		/// Método helper para crear un ToolButton en un PopupMenuTool de un UltraToolbarsManager
		/// </summary>
		/// <param name="popup">Popup en el que se creará el tool</param>
		/// <param name="key">key del tool</param>
		/// <param name="caption">label del tool</param>
		/// <param name="comenzarGrupo">Indica si antes de este tool se pondrá una línea divisoria.</param>
		/// <param name="imagen">Imagen del tool</param>
		/// <param name="tag">Cualquier objeto que quiera asociarse con el tool</param>
		/// <returns>Devuelve una instancia del ButtonTool creado</returns>
		public ButtonTool CrearToolButtonEnPopup(PopupMenuTool popup, string key, string caption, bool comenzarGrupo, Image imagen, object tag)
		{
            return CrearToolButtonEnPopup(popup, key, caption, comenzarGrupo, imagen, tag,  null);
		}
        /// <summary>
        /// Ejecuta la acción definida por el parámetro accion, para la lista de entidades del parámetro lista.
        /// </summary>
        /// <param name="accion">Acción que se desea procesar.</param>
        /// <param name="lista">Lista de entidades a procesar.</param>
        /// <returns>Ok si la acción se pudo procesar, Cancel si el usuario canceló la acción o Abort si hubo un error de concurrencia.</returns>
		public DialogResult ProcesarAccion(Accion accion, IList lista)
        {
            Type tipo = Type.GetType(accion.FormAsociado);
            if (tipo == null)
            {
                throw new Exception(String.Format("No se pudo resolver el tipo {0}", accion.FormAsociado));
            }
            ArrayList paramTemp = new ArrayList();
            paramTemp.Add(lista);
            if (accion.ParamForm != null)
            {
                paramTemp.Add(accion.ParamForm);
            }
            Form form = Activator.CreateInstance(tipo, paramTemp.ToArray()) as Form;
            if (form == null)
            {
                throw new Exception(String.Format("No se pudo instanciar el form del tipo {0}", tipo));
            }
			if (form is FormProcesarAccion)
			{
				(form as FormProcesarAccion).Accion = accion;
			}
            DialogResult resultado = form.ShowDialog();
            return resultado;
        }
		public DialogResult ProcesarAccion2(Accion accion, IList lista)
		{
			Type tipo = Type.GetType(accion.FormAsociado);
			if (tipo == null)
			{
				throw new Exception(String.Format("No se pudo resolver el tipo {0}", accion.FormAsociado));
			}
			ArrayList paramTemp = new ArrayList();
			paramTemp.Add(lista);
			foreach (ParametroAccion param in accion.Parametros)
			{
				object valor = Util.ConvertirValor(Type.GetType(param.Tipo), param.Valor);
				paramTemp.Add(valor);
			}
			Form form = Activator.CreateInstance(tipo, paramTemp.ToArray()) as Form;
			if (form == null)
			{
				throw new Exception(String.Format("No se pudo instanciar el form del tipo {0}", tipo));
			}
			if (form is FormProcesarAccion)
			{
				(form as FormProcesarAccion).Accion = accion;
			}
			DialogResult resultado = form.ShowDialog();
			return resultado;
		}

        #endregion
    }
}
