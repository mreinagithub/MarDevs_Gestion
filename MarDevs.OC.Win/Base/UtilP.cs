using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Data;
using System.Windows.Forms;
using MarDevs.OC.Core;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System.Drawing.Printing;
using System.IO;
using System.Xml.Serialization;
using Infragistics.Win.UltraWinTree;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace MarDevs.OC.Win
{
	public class UtilP
	{
        public static ValueList CopiarValueList(ValueList valuelist)
        {
            if (valuelist == null)
            {
                return null;
            }
            ValueList vlCopia = new ValueList();
            ValueListItem vli = null;
            foreach (ValueListItem vlItem in valuelist.ValueListItems)
            {
                vli = vlCopia.ValueListItems.Add(vlItem.DataValue, vlItem.DisplayText);
                if (vlItem.Appearance.Image != null)
                    vli.Appearance.Image = vlItem.Appearance.Image;
            }
            return vlCopia;
        }
		public static void AutoAjustarColumnas(UltraGrid pGrilla)
		{
			foreach (UltraGridColumn col in pGrilla.DisplayLayout.Bands[0].Columns)
			{
				col.PerformAutoResize();
			}
		}
        public static void OcultarColumnas(UltraGrid grilla)
        {
            OcultarColumnas(grilla.DisplayLayout.Bands[0]);
        }
		public static void OcultarColumnas(UltraGridBand ultraGridBand)
		{
			for (int i = 0; i < ultraGridBand.Columns.Count; i++)
				ultraGridBand.Columns[i].Hidden = true;
		}
        public static void OcultarColumna(UltraGrid gr, string keyColumna)
        {
            if (gr == null || String.IsNullOrEmpty(keyColumna)) return;
            if (gr.DisplayLayout.Bands[0].Columns.Exists(keyColumna))
                gr.DisplayLayout.Bands[0].Columns[keyColumna].Hidden = true;
        }

        public static void EmularTabConEnter(object sender, KeyPressEventArgs e)
        {
			if ((Keys)e.KeyChar == Keys.Enter)
			{
				SendKeys.Send("{tab}");
				e.Handled = true;
			}
        }
		public static UltraGridColumn ConfigurarColumna(UltraGrid grilla, string columna)
		{
			if (grilla == null)
				throw new ArgumentNullException("grilla");
			if (String.IsNullOrEmpty(columna))
				throw new ArgumentNullException("columna");
			if (!grilla.DisplayLayout.Bands[0].Columns.Exists(columna))
				grilla.DisplayLayout.Bands[0].Columns.Add(columna);
			UltraGridColumn col = grilla.DisplayLayout.Bands[0].Columns[columna];

			//Determino DataType					
			if (col.DataType == typeof(Decimal)
				|| col.DataType == typeof(Int32)
				|| col.DataType == typeof(Double))
			{
				col.CellAppearance.TextHAlign = HAlign.Right;
			}
			return col;
		}
        public static UltraGridColumn ConfigurarColumna(UltraGrid grilla, string columna, bool visible)
        {
            UltraGridColumn col = ConfigurarColumna(grilla, columna);
            col.Hidden = !visible;
		    return col;
        }
        public static UltraGridColumn ConfigurarColumna(UltraGrid grilla, string columna, bool visible, bool siempreOculta)
        {
            UltraGridColumn col = ConfigurarColumna(grilla, columna, visible);
            col.ExcludeFromColumnChooser = siempreOculta ? ExcludeFromColumnChooser.True : col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.False;
            return col;
        }
		public static UltraGridColumn ConfigurarColumna(UltraGrid grilla, string columna, bool visible, int posicion, string titulo)
		{
			UltraGridColumn col = ConfigurarColumna(grilla, columna, visible);
			col.Header.Caption = titulo;
			if (posicion >= 0)
				col.Header.VisiblePosition = posicion;
			return col;
		}
		public static UltraGridColumn ConfigurarColumna(UltraGrid grilla, string columna, bool visible, int posicion, string titulo, int ancho)
		{
			UltraGridColumn col = ConfigurarColumna(grilla, columna, visible, posicion, titulo);
			if (ancho > 0)
			{
				col.Width = ancho;
			}
			return col;
		}
		public static UltraGridColumn ConfigurarColumna(UltraGrid grilla, string columna, bool visible, int posicion, string titulo, int ancho, ValueList valuelist)
		{
			UltraGridColumn col = ConfigurarColumna(grilla, columna, visible, posicion, titulo, ancho);
			col.ValueList = valuelist;
			return col;
		}
		public static UltraGridColumn ConfigurarColumna(UltraGrid grilla, string columna, bool visible, ValueList valuelist)
		{
			UltraGridColumn col = ConfigurarColumna(grilla, columna, visible);
			col.ValueList = valuelist;
			return col;
		}
		public static UltraGridColumn ConfigurarColumna(UltraGrid grilla, string columna, bool visible, int posicion, string titulo, int ancho, string formato)
		{
			UltraGridColumn col = ConfigurarColumna(grilla, columna, visible, posicion, titulo, ancho);
			col.Format = formato;
			return col;
		}

		public static UltraGridColumn ConfigurarColumna(UltraGrid grilla, string nombreColumna, int orden)
		{
			UltraGridColumn col = ConfigurarColumna(grilla, nombreColumna);
			col.Header.VisiblePosition = orden;
			return col;
		}

		//CARGA DE COMBOS
		public static void CargarComboDesdeValueList(UltraComboEditor cb, Infragistics.Win.ValueList vl)
		{
			CargarComboDesdeValueList(cb, vl, false, String.Empty);
		}
		public static void CargarComboDesdeValueList(UltraComboEditor cb, Infragistics.Win.ValueList vl, bool incluirNull, string textoNull)
		{
            CargarComboDesdeValueList(cb, vl, incluirNull, null, textoNull);
		}
        public static void CargarComboDesdeValueList(UltraComboEditor cb, Infragistics.Win.ValueList vl, bool incluirNull, object valorNull, string textoNull)
        {
            cb.Items.Clear();
            if (incluirNull)
                cb.Items.Add(valorNull, textoNull);
            foreach (Infragistics.Win.ValueListItem item in vl.ValueListItems)
            {
                ValueListItem itemClone = new ValueListItem();
                itemClone.DataValue = item.DataValue;
                itemClone.DisplayText = item.DisplayText;
                cb.Items.Add(itemClone);
            }
        }
		public static void CargarComboDesdeTabla(UltraComboEditor cb, string pTabla, string pCampoId, string pCampoDe, string pFiltroCampo, string pFiltroOperador, int pFiltroValor)
		{
            string query = "SELECT " + pCampoId + ", " + pCampoDe
                + " FROM " + pTabla
                + " WHERE " + pFiltroCampo + " " + pFiltroOperador + " " + pFiltroValor.ToString()
                + " GROUP BY " + pCampoId + ", " + pCampoDe;
            CargarComboDesdeTabla(cb, query);
		}
		public static void CargarComboDesdeTabla(UltraComboEditor cb, string pTabla, string pCampoId, string pCampoDe)
		{
            string query = "SELECT " + pCampoId + ", " + pCampoDe + " FROM " + pTabla + " GROUP BY " + pCampoId + ", " + pCampoDe;
            CargarComboDesdeTabla(cb, query);
        }
		public static void CargarComboDesdeTabla(UltraComboEditor cb, string comandoSql)
		{
            try
            {
                DataTable dt;
                using (DL dl = DL.ObtenerSesion())
                {
                    dt = dl.EjecutarSQL(comandoSql);
                }
                foreach (DataRow dr in dt.Rows)
                    cb.Items.Add(dr[0], dr[1].ToString());
            }
            catch(Exception ex)
            {
                throw new ExcepcionTecnica(Util.STR_ERROR_ACCESO_DATOS, ex);
            }
		}
        public static ValueList CargarValueListDesdeTabla(string pTabla, string pCampoId, string pCampoDe)
        {
            Infragistics.Win.ValueList vl = new Infragistics.Win.ValueList();
			DataTable dt;
			using (DL dl = DL.ObtenerSesion())
			{
				dt = dl.EjecutarSQL("SELECT " + pCampoId + ", " + pCampoDe + " FROM " + pTabla);
			}
			foreach (DataRow dr in dt.Rows)
				vl.ValueListItems.Add(dr[0], (string)dr[1]);

            return vl;
        }
		public static void CargarComboDesdeIList(UltraComboEditor cb, IEnumerable lista)
		{
			CargarComboDesdeIList(cb, lista, false);
		}
		public static void CargarComboDesdeIList(UltraComboEditor cb, IEnumerable lista, bool incluirNull)
		{
			CargarComboDesdeIList(cb, lista, incluirNull, "<No establecido>");
		}
		public static void CargarComboDesdeIList(UltraComboEditor cb, IEnumerable lista, bool incluirNull, string textoNull)
		{
			cb.Items.Clear();
            if (incluirNull)
                cb.Items.Add(null, textoNull);
			foreach (object item in lista)
			{
				cb.Items.Add(item, item.ToString());
			}
		}
		public static void CargarComboDesdeEnum(UltraComboEditor cb, System.Type en)
		{
			if (!en.IsEnum)
			{
				throw new ArgumentException("El parámetro en debe ser una enumeración");
			}
			cb.Items.Clear();
			ValueList vl = UtilP.CargarValueListDesdeEnum(en);
			UtilP.CargarComboDesdeValueList(cb, vl);
		}
		public static void CargarComboDesdeEnum(UltraComboEditor cb, System.Type en, bool incluirNull, string textoNull)
		{
			if (!en.IsEnum)
				throw new ArgumentException("El parámetro en debe ser una enumeración");
			ValueList vl = UtilP.CargarValueListDesdeEnum(en);
            UtilP.CargarComboDesdeValueList(cb, vl, incluirNull, textoNull);
		}
		public static ValueList CargarValueListDesdeEnum(System.Type en)
		{
			if (!en.IsEnum)
				throw new ArgumentException("El parámetro debe ser una enumeración");
			ValueList vl = new ValueList();
			ValueListItem vli;

			foreach (Enum item in Enum.GetValues(en))
			{
				FieldInfo fi = item.GetType().GetField(item.ToString());
				EnumDescriptorAttribute[] attributes = (EnumDescriptorAttribute[])fi.GetCustomAttributes(typeof(EnumDescriptorAttribute), false);

				vli = new ValueListItem();
				vli.DataValue = item;
				vli.DisplayText = (attributes.Length > 0) ? attributes[0].Descripcion : item.ToString();
				if (attributes.Length > 0 && attributes[0].Imagen != String.Empty)
					vli.Appearance.Image = UtilP.TraerRecurso(attributes[0].Imagen);

				vl.ValueListItems.Add(vli);
			}
			return vl;
		}
		public static ValueList CargarValueListDesdeEnumVP(System.Type en)
		{
			if (!en.IsEnum)
				throw new ArgumentException("El parámetro debe ser una enumeración");
			ValueList vl = new ValueList();
			ValueListItem vli;

			foreach (Enum item in Enum.GetValues(en))
			{
				FieldInfo fi = item.GetType().GetField(item.ToString());
				EnumDescriptorAttribute[] attributes = (EnumDescriptorAttribute[])fi.GetCustomAttributes(typeof(EnumDescriptorAttribute), false);

				vli = new ValueListItem();
				vli.DataValue = Convert.ToInt32(item);
				vli.DisplayText = (attributes.Length > 0) ? attributes[0].Descripcion : item.ToString();
				if (attributes.Length > 0 && attributes[0].Imagen != String.Empty)
					vli.Appearance.Image = UtilP.TraerRecurso(attributes[0].Imagen);

				vl.ValueListItems.Add(vli);
			}
			return vl;
		}
        public static IList<TEnum> CargarIListDesdeEnum<TEnum>()
        {
            Type tipo = typeof(TEnum);
            if (!tipo.IsEnum)
                throw new ArgumentException("El parámetro debe ser una enumeración");
            IList<TEnum> list = new List<TEnum>();

            foreach (TEnum item in Enum.GetValues(tipo))
                list.Add(item);
            return list;
        }
		public static T ObtenerObjetoDesdeCombo<T>(UltraCombo cb)
		{
			T objeto = default(T);
			if (cb != null && cb.SelectedRow != null)
				objeto = (T)cb.SelectedRow.ListObject;
			return objeto;
		}

		public static object TraerRecurso(string nombreRecurso)
		{
			System.Reflection.Assembly ass = System.Reflection.Assembly.GetEntryAssembly();
			object recurso = TraerRecurso(nombreRecurso, ass);
			if (recurso != null)
			{
				return recurso;
			}
			else
			{
				return TraerRecurso(nombreRecurso, typeof(UtilP).Assembly);
			}
		}
		public static object TraerRecurso(string nombreRecurso, Assembly ass)
		{
			string[] lista = ass.GetManifestResourceNames();
			string archivoRecursos = String.Empty;
			foreach (string str in lista)
			{
				if (str.ToUpper().IndexOf(".PROPERTIES.RESOURCES") > 0)
				{
					archivoRecursos = str.Replace(".resources", String.Empty);
					break;
				}
			}
			if (archivoRecursos != String.Empty)
			{
				System.Resources.ResourceManager res = new System.Resources.ResourceManager(archivoRecursos, ass);
				return res.GetObject(nombreRecurso);
			}
			else
			{
				return null;
			}
		}
		public static void MostrarCalculadora()
		{
			try
			{
				System.Diagnostics.Process.Start("Calc.exe");
			}
			catch (Exception ex)
			{
				Mensaje.Error("Hubo un error al intentar abrir la calculadora de Windows", ex);
			}
		}
		public static string NombreProducto()
		{
			string nombre = String.Empty;

			System.Reflection.Assembly ass = System.Reflection.Assembly.GetEntryAssembly();
			object[] attr = ass.GetCustomAttributes(typeof(System.Reflection.AssemblyProductAttribute), true);
			if (attr.Length > 0)
			{
				System.Reflection.AssemblyProductAttribute prodattr = attr[0] as System.Reflection.AssemblyProductAttribute;
				nombre = prodattr.Product;
			}
			return nombre;

		}
		public static void LimpiarBingingsControl(Control control)
		{
			control.DataBindings.Clear();
			foreach (Control c in control.Controls)
			{
				UtilP.LimpiarBingingsControl(c);
			}
		}
		[System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
		private static extern bool BitBlt(
			IntPtr hdcDest, // handle to destination DC
			int nXDest,  // x-coord of destination upper-left corner
			int nYDest,  // y-coord of destination upper-left corner
			int nWidth,  // width of destination rectangle
			int nHeight, // height of destination rectangle
			IntPtr hdcSrc,  // handle to source DC
			int nXSrc,   // x-coordinate of source upper-left corner
			int nYSrc,   // y-coordinate of source upper-left corner
			System.Int32 dwRop  // raster operation code
			);

		public static Image CapturarForm(Form form)
		{
			Graphics g1 = form.CreateGraphics();
			//g1.DrawString(form.Text, new Font(FontFamily.GenericSansSerif, 10),Brushes.Black, 2, 2);
			g1.DrawRectangle(Pens.Black, 1, 1, form.ClientRectangle.Width - 2, form.ClientRectangle.Height - 2);
			//g1.DrawLine(Pens.Black, 1, 20, form.ClientRectangle.Width-2, 20);
			Image imagen = new Bitmap(form.ClientRectangle.Width, form.ClientRectangle.Height, g1);
			Graphics g2 = Graphics.FromImage(imagen);
			IntPtr dc1 = g1.GetHdc();
			IntPtr dc2 = g2.GetHdc();
			BitBlt(dc2, 0, 0, form.ClientRectangle.Width, form.ClientRectangle.Height, dc1, 0, 0, 13369376);
			g1.ReleaseHdc(dc1);
			g2.ReleaseHdc(dc2);

			return imagen;
		}
		public static void ImprimirForm(Form form, bool mostrarVistaPrevia, bool landscape)
		{
			Color colorAnterior = form.BackColor;
			form.BackColor = Color.White;
			form.Invalidate();
			form.Refresh();

			Bitmap bitmap = new Bitmap(UtilP.CapturarForm(form));

			form.BackColor = colorAnterior;
			form.Invalidate();
			form.Refresh();

			PrintDocument pd = new PrintDocument();
			pd.DefaultPageSettings.Landscape = landscape;
			pd.DocumentName = form.Text;

			dotNETLib.Printing printing = new dotNETLib.Printing();
			printing.printImage(pd, bitmap, mostrarVistaPrevia);

		}
		public static LayoutGrilla CrearLayoutGrilla(UltraGrid grilla)
		{
			try
			{
				LayoutGrilla layout = new LayoutGrilla();
				layout.PanelAgrupacion = (grilla.DisplayLayout.ViewStyleBand == ViewStyleBand.OutlookGroupBy);


				UltraGridBand banda = grilla.DisplayLayout.Bands[0];
				LayoutColumna lcol = null;
				ArrayList columnas = new ArrayList();
				foreach (UltraGridColumn col in banda.Columns)
				{
					if (!col.IsChaptered && col.ExcludeFromColumnChooser != ExcludeFromColumnChooser.True)
					{
						lcol = new LayoutColumna();
						lcol.Nombre = col.Key;
						lcol.Posicion = col.Header.VisiblePosition;
						lcol.Visible = !col.Hidden;
						lcol.Ancho = col.Width;
						lcol.Orden = Convert.ToInt32(col.SortIndicator);
						lcol.EsGroupBy = col.IsGroupByColumn;
						columnas.Add(lcol);
					}
				}
				layout.Columnas = (LayoutColumna[])columnas.ToArray(typeof(LayoutColumna));
				return layout;
			}
			catch
			{
				throw;
			}
		}
		public static void SerializarLayoutGrilla(LayoutGrilla layout, string archivo)
		{
			StreamWriter writer = null;
			try
			{
				System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(layout.GetType());
				writer = new StreamWriter(archivo);
				x.Serialize(writer, layout);
			}
			catch
			{
				throw;
			}
			finally
			{
				if (writer != null) { writer.Close(); }
			}
		}
		public static LayoutGrilla DeserializarLayoutGrilla(string archivo)
		{
			FileStream stream = null;
			try
			{
				XmlSerializer mySerializer = new XmlSerializer(typeof(LayoutGrilla));
				stream = new FileStream(archivo, FileMode.Open);
				LayoutGrilla layout = (LayoutGrilla)mySerializer.Deserialize(stream);
				return layout;
			}
			catch
			{
				throw;
			}
			finally
			{
				if (stream != null) { stream.Close(); }
			}
		}
		public static System.Resources.ResourceManager ResourceManager()
		{
			return MarDevs.OC.Win.Properties.Resources.ResourceManager;
		}
		public static bool TieneNodosVisibles(UltraTree tree)
		{
			foreach (UltraTreeNode nodo in tree.Nodes)
			{
				if (nodo.Visible)
				{
					return true;
				}
				else if (TieneNodosVisibles(nodo))
				{
					return true;
				}
			}
			return false;

		}
		public static bool TieneNodosVisibles(UltraTreeNode nodo)
		{
			foreach (UltraTreeNode nodoHijo in nodo.Nodes)
			{
				if (nodoHijo.Visible)
				{
					return true;
				}
				else if (TieneNodosVisibles(nodoHijo))
				{
					return true;
				}
			}
			return false;

		}
		public static void StartDefaultClient(string direccion, string cc, string asunto, string body)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("mailto:{0}", direccion);
			if (!String.IsNullOrEmpty(asunto))
			{
				sb.AppendFormat("&subject={0}", asunto);
			}
			if (!String.IsNullOrEmpty(body))
			{
				sb.AppendFormat("&body={0}", body);
			}
			if (!String.IsNullOrEmpty(cc))
			{
				sb.AppendFormat("&cc={0}", cc);
			}
			string filename = sb.ToString();
			Process myProcess = new Process();
			myProcess.StartInfo.FileName = filename;
			myProcess.StartInfo.UseShellExecute = true;
			myProcess.StartInfo.RedirectStandardOutput = false;
			myProcess.Start();
		}
		public static void StartDefaultClient(string direccion)
		{
			StartDefaultClient(direccion, String.Empty, String.Empty, String.Empty);
		}
		public static void ConfigurarGrillaDesdeType(UltraGrid grilla, Type tipo)
		{
			ConfigurarGrillaDesdeType(grilla, tipo, Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn);
		}
		public static void ConfigurarGrillaDesdeType(UltraGrid grilla, Type tipo, AutoFitStyle fitStyle)
		{
			UltraGridColumn col;
			int i = 0;
			object[] attrArray;
			GridDescriptorAttribute fieldDefinition;
			if (grilla == null || tipo == null)
				return;

			grilla.DisplayLayout.AutoFitStyle = fitStyle;

			foreach (PropertyInfo property in tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance))
			{
				attrArray = property.GetCustomAttributes(typeof(BrowsableAttribute), true);
				if (attrArray.Length > 0 && (attrArray[0] as BrowsableAttribute).Browsable == false) // el atributo existe
					continue;
				attrArray = property.GetCustomAttributes(typeof(NoVisibleEnGrillaAttribute), true);
				if (attrArray.Length > 0) // el atributo existe
				{
					col = ConfigurarColumna(grilla, property.Name, false);
					col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
					continue;
				}
				//para las colecciones no hago nada, no se representan en la grilla
				if (property.PropertyType.Name.Contains("IList"))
					continue;

				//OBTENER LA DEFINICION DE LA PROPERTY
				attrArray = property.GetCustomAttributes(typeof(GridDescriptorAttribute), true);
				if (attrArray.Length > 0) // el atributo existe
				{
					fieldDefinition = attrArray[0] as GridDescriptorAttribute;
					col = ConfigurarColumna(grilla, property.Name, fieldDefinition.VisiblePorDefault, i++, fieldDefinition.Label);
					//BACKCOLOR
					if (!String.IsNullOrEmpty(fieldDefinition.BackColor))
					{
						Color backcolor = Util.ColorFromString(fieldDefinition.BackColor);
						if (backcolor != Color.Empty)
							col.CellAppearance.BackColor = backcolor;
					}
					//BOLD
					if (fieldDefinition.Bold)
						col.CellAppearance.FontData.Bold = DefaultableBoolean.True;
					//FORMAT
					if (!String.IsNullOrEmpty(fieldDefinition.Format))
						col.Format = fieldDefinition.Format;

					//WIDTH
					if (fieldDefinition.Width > 0)
						col.Width = fieldDefinition.Width;
				}
				else
				{
					col = ConfigurarColumna(grilla, property.Name, true, i++, property.Name);
				}

				//ALINEACION PARA NUMERICOS (Q SEA POR DEFAULT A LA DERECHA)
				switch (property.PropertyType.Name)
				{
					case "Int32":
					case "Decimal":
					case "Double":
						col.CellAppearance.TextHAlign = HAlign.Right;
						break;
				}

				//VALUELIST - Enum
				if (property.PropertyType.IsEnum)
					col.ValueList = UtilP.CargarValueListDesdeEnum(property.PropertyType);
			}
		}
		public static void ConfigurarGrillaDesdeVistaPersonalizada(UltraGrid gr, VistaPersonalizada vp, bool soportaMarcaSeguimiento)
		{
			UtilP.OcultarColumnas(gr);
			gr.DisplayLayout.Bands[0].ColHeaderLines = 2;
			gr.DisplayLayout.UseFixedHeaders = true;
			gr.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
			UltraGridColumn col;

			#region Marca Seguimiento
			if (soportaMarcaSeguimiento)
			{
				col = UtilP.ConfigurarColumna(gr, "MarcaSeguimiento", true, 0, "S", 15);
				col.DataType = typeof(MarcaSeguimiento);
				col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
				col.LockedWidth = true;
				col.Header.Fixed = true;
				col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
				col.Header.ToolTipText = "Marca de seguimiento";
				col.ColumnChooserCaption = "Marca de seguimiento";
			}
			#endregion

			//Columnas de la consulta
			foreach (VistaPersonalizadaFormatoColumna vpfc in vp.Formatos)
			{
				string titulo = String.IsNullOrEmpty(vpfc.Titulo) ? vpfc.Columna : vpfc.Titulo;
				titulo = titulo.Replace('|', '\n');

				col = UtilP.ConfigurarColumna(gr, vpfc.Columna, vpfc.Visible, -1, titulo, vpfc.Ancho, vpfc.Formato);

				if (!String.IsNullOrEmpty(vpfc.ValueList))
				{
					Type tipo = Type.GetType(vpfc.ValueList);
					if (tipo != null)
						col.ValueList = UtilP.CargarValueListDesdeEnumVP(tipo);
				}
				if (Color.Transparent.ToArgb() != vpfc.BackColor)
					col.CellAppearance.BackColor = Color.FromArgb(vpfc.BackColor);
				if (vpfc.ForeColor != Color.Black.ToArgb())
					col.CellAppearance.ForeColor = Color.FromArgb(vpfc.ForeColor);

				col.CellAppearance.FontData.Bold = vpfc.Bold ? DefaultableBoolean.True : DefaultableBoolean.False;
				col.ExcludeFromColumnChooser = vpfc.ExcluirDelSelector ? ExcludeFromColumnChooser.True : ExcludeFromColumnChooser.False;

				//Determino DataType					
				if (col.DataType == typeof(Decimal)
					|| col.DataType == typeof(Int32)
					|| col.DataType == typeof(Double))
				{
					col.CellAppearance.TextHAlign = HAlign.Right;
				}
			}
		}
		public static string CarpetaConfiguracion()
		{
			string carpeta = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
				+ Path.DirectorySeparatorChar
				+ "Daruma"
				+ Path.DirectorySeparatorChar
				+ System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
				if (ConfigBL.ticket != null)
				{
					carpeta = carpeta + Path.DirectorySeparatorChar + "User" + ConfigBL.ticket.Usuario.Id.ToString();
				}
			
			//crearla si no existe
			if (!Directory.Exists(carpeta))
			{
				Directory.CreateDirectory(carpeta);
			}
			return carpeta;
		}
		public static string CarpetaTemporal()
		{
			string carpeta = Path.Combine(CarpetaConfiguracion(), "Temp");
			if ( !Directory.Exists(carpeta) )
			{
				Directory.CreateDirectory(carpeta);
			}
			return carpeta;
		}
		public static T DesserializarXML<T>(string archivo)
		{
			FileStream stream = null;
			try
			{
				XmlSerializer mySerializer = new XmlSerializer(typeof(T));
				stream = new FileStream(archivo, FileMode.Open);
				T objeto = (T)mySerializer.Deserialize(stream);
				return objeto;
			}
			finally
			{
				if (stream != null) { stream.Close(); }
			}

		}
		public static void SerializarXML(object objeto, string archivo)
		{
			StreamWriter writer = null;
			try
			{
				System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(objeto.GetType());
				writer = new StreamWriter(archivo);
				x.Serialize(writer, objeto);
			}
			finally
			{
				if (writer != null) { writer.Close(); }
			}

		}

		public static Icon IconoParaExtension(string extension, bool large)
		{
			if (extension != null)
			{
				//let's just make up a file name with that extension
				string fictitiousFile = "0" + extension;
				//now get the icon for that file
				return GetAssociatedIcon(fictitiousFile, large);
			}
			else
			{
				throw new ArgumentException("Invalid file or extension.", "fileOrExtension");
			}

		}
		private static Icon GetAssociatedIcon(string stubPath, bool large)
		{
			SHFILEINFO info = new SHFILEINFO(true);
			int cbFileInfo = Marshal.SizeOf(info);
			SHGFI flags;

			if (large)
				flags = SHGFI.Icon | SHGFI.LargeIcon | SHGFI.UseFileAttributes;
			else
				flags = SHGFI.Icon | SHGFI.SmallIcon | SHGFI.UseFileAttributes;


			SHGetFileInfo(stubPath, 256, out info, (uint)cbFileInfo, flags);
			return (Icon)Icon.FromHandle(info.hIcon);
		}
		#region Win32 API imports



		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		private static extern int SHGetFileInfo(
			string pszPath,
			int dwFileAttributes,
			out    SHFILEINFO psfi,
			uint cbfileInfo,
			SHGFI uFlags);

		private const int MAX_PATH = 260;
		private const int MAX_TYPE = 80;

		private struct SHFILEINFO
		{
			public SHFILEINFO(bool b)
			{
				hIcon = IntPtr.Zero;
				iIcon = 0;
				dwAttributes = 0;
				szDisplayName = String.Empty;
				szTypeName = String.Empty;
			}


			public IntPtr hIcon;
			public int iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_TYPE)]
			public string szTypeName;
		};

		[Flags]
		enum SHGFI : int
		{
			/// <summary>get icon</summary>
			Icon = 0x000000100,

			/// <summary>get display name</summary>
			DisplayName = 0x000000200,

			/// <summary>get type name</summary>
			TypeName = 0x000000400,

			/// <summary>get attributes</summary>
			Attributes = 0x000000800,

			/// <summary>get icon location</summary>
			IconLocation = 0x000001000,

			/// <summary>return exe type</summary>
			ExeType = 0x000002000,

			/// <summary>get system icon index</summary>
			SysIconIndex = 0x000004000,

			/// <summary>put a link overlay on icon</summary>
			LinkOverlay = 0x000008000,

			/// <summary>show icon in selected state</summary>
			Selected = 0x000010000,

			/// <summary>get only specified attributes</summary>
			Attr_Specified = 0x000020000,

			/// <summary>get large icon</summary>
			LargeIcon = 0x000000000,

			/// <summary>get small icon</summary>
			SmallIcon = 0x000000001,

			/// <summary>get open icon</summary>
			OpenIcon = 0x000000002,

			/// <summary>get shell size icon</summary>
			ShellIconize = 0x000000004,

			/// <summary>pszPath is a pidl</summary>
			PIDL = 0x000000008,

			/// <summary>use passed dwFileAttribute</summary>
			UseFileAttributes = 0x000000010,

			/// <summary>apply the appropriate overlays</summary>
			AddOverlays = 0x000000020,

			/// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
			OverlayIndex = 0x000000040,
		}

		#endregion
	}
}
