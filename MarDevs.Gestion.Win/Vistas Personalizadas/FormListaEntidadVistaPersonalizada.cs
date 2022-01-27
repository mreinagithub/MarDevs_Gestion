using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Daruma.Cross.Core;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Daruma.Cross.Win
{
    public partial class FormListaEntidadVistaPersonalizada : FormListaBase
    {
        int? _vpId;
		VistaPersonalizada _vp;
		Type _tipoEntidad;
		public FormListaEntidadVistaPersonalizada(Int32? vistaId)
        {
            _vpId = vistaId;
            InitializeComponent();
        }

        protected override void InicializarFormulario()
        {
            if (_vpId == null)
            { this.Close(); }
            _vp = VistaPersonalizada.Leer(_vpId);
			
            if (_vp == null)
            {
                Mensaje.Advertencia("No se encontró la vista a la cual está haciendo referencia");
                this.Close();
            }
			//_tipoEntidad = Type.GetType("Daruma.Cross.Core." + _vp.EntidadTipo);
            base.InicializarFormulario();
            CargarContenedorParametros();
            if (_vp.EjecutarAlAbrir)
                ActualizarListaDesdeOrigen();
        }
        protected override void InicializarGrilla()
        {
            if (_vp != null && _vp.TipoVista == TipoVistaPersonalizada.HQL)
            {
				UtilP.ConfigurarGrillaDesdeType(this.ultraGrid1, _tipoEntidad);
            }
            else if (_vp != null && _vp.TipoVista == TipoVistaPersonalizada.SQL)
            {
                UtilP.OcultarColumnas(this.ultraGrid1);
                this.ultraGrid1.DisplayLayout.Bands[0].ColHeaderLines = 2;
                this.ultraGrid1.DisplayLayout.UseFixedHeaders = true;
                this.ultraGrid1.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
                UltraGridColumn col;

                //Marca Seguimiento
				//col = this.ConfigurarColumna("MarcaSeguimiento", true, 0, "S", 15);
				//col.DataType = typeof(MarcaSeguimiento);
				//col.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True;
				//col.LockedWidth = true;
				//col.Header.Fixed = true;
				//col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
				//col.Header.ToolTipText = "Marca de seguimiento";
				//col.ColumnChooserCaption = "Marca de seguimiento";

                //Columnas de la consulta
                foreach (VistaPersonalizadaFormatoColumna vpfc in _vp.Formatos)
                {
                    string titulo = String.IsNullOrEmpty(vpfc.Titulo) ? vpfc.Columna : vpfc.Titulo;
                    titulo = titulo.Replace('|', '\n');
                    col = UtilP.ConfigurarColumna(this.ultraGrid1, vpfc.Columna, vpfc.Visible, -1, titulo, vpfc.Ancho, vpfc.Formato);
					col.CellAppearance.FontData.Bold = vpfc.Bold ? DefaultableBoolean.True : DefaultableBoolean.False;
					col.ExcludeFromColumnChooser = vpfc.ExcluirDelSelector ? ExcludeFromColumnChooser.True : ExcludeFromColumnChooser.False;
                    if (Color.Transparent.ToArgb() != vpfc.BackColor)
                        col.CellAppearance.BackColor = Color.FromArgb(vpfc.BackColor);
                    if (vpfc.ForeColor != Color.Black.ToArgb())
                        col.CellAppearance.ForeColor = Color.FromArgb(vpfc.ForeColor);
                }
            }
            ////Summaries			
            CrearSummaries();
        }
        protected override void UltraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            try
            {
                if (_vp.TipoVista == TipoVistaPersonalizada.HQL)
                {
                    base.UltraGrid1_InitializeRow(sender, e);
                }
                else if (_vp.TipoVista == TipoVistaPersonalizada.SQL)
                {
                    DataRowView entidad = e.Row.ListObject as DataRowView;

                    //Marca Seguimiento
                    if (entidad != null)
                    {
						//if (entidad.Row.Table.Columns.Contains("Id"))
						//{
						//	string id = entidad["Id"].ToString();
						//	if (_marcasSeguimiento != null && _marcasSeguimiento.ContainsKey(id))
						//	{
						//		MarcaSeguimiento marca = _marcasSeguimiento[id];
						//		e.Row.Cells["MarcaSeguimiento"].Value = marca;
						//		e.Row.Cells["MarcaSeguimiento"].Appearance.Image = Recursos.TraerRecursoEnsamblado(marca.Imagen.ToString()) as Image;
						//		e.Row.Cells["MarcaSeguimiento"].ToolTipText = marca.Comentarios;
						//	}
						//	else
						//	{
						//		e.Row.Cells["MarcaSeguimiento"].Value = null;
						//		e.Row.Cells["MarcaSeguimiento"].Appearance.Image = null;
						//		e.Row.Cells["MarcaSeguimiento"].ToolTipText = String.Empty;
						//	}
						//}

                        if (entidad.Row.Table.Columns.Contains("ColorFila"))
                        {
                            string color = Convert.ToString(entidad["ColorFila"]);
                            e.Row.Appearance.BackColor = !String.IsNullOrEmpty(color) ? Color.FromName(color) : SystemColors.Window;
                        }
                        if (entidad.Row.Table.Columns.Contains("ColorTexto"))
                        {
                            string color = Convert.ToString(entidad["ColorTexto"]);
                            if (!String.IsNullOrEmpty(color))
                                e.Row.Appearance.ForeColor = Color.FromName(color);
                        }
                        if (entidad.Row.Table.Columns.Contains("ToolTip"))
                        {
                            e.Row.ToolTipText = Convert.ToString(entidad["ToolTip"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensaje.MostrarError(ex);
            }
        }
        private void CrearSummaries()
        {
            if (_vp == null) return;

            UltraGridBand banda = this.ultraGrid1.DisplayLayout.Bands[0];
            this.ultraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            this.ultraGrid1.CalcManager = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager();
            banda.Summaries.Clear();
            SummarySettings settings = null;
            foreach (VistaPersonalizadaSummary summary in _vp.Summaries)
            {
                try
                {
                    switch (summary.Accion)
                    {
                        case AccionSummary.Suma:
                            settings = banda.Summaries.Add(summary.Id + "_" + summary.Campo, SummaryType.Sum, banda.Columns[summary.Campo], SummaryPosition.Left);
                            break;
                        case AccionSummary.Cuenta:
                            settings = banda.Summaries.Add(summary.Id + "_" + summary.Campo, SummaryType.Count, banda.Columns[summary.Campo], SummaryPosition.Left);
                            break;
                        case AccionSummary.Maximo:
                            settings = banda.Summaries.Add(summary.Id + "_" + summary.Campo, SummaryType.Maximum, banda.Columns[summary.Campo], SummaryPosition.Left);
                            break;
                        case AccionSummary.Minimo:
                            settings = banda.Summaries.Add(summary.Id + "_" + summary.Campo, SummaryType.Minimum, banda.Columns[summary.Campo], SummaryPosition.Left);
                            break;
                        case AccionSummary.Promedio:
                            settings = banda.Summaries.Add(summary.Id + "_" + summary.Campo, SummaryType.Average, banda.Columns[summary.Campo], SummaryPosition.Left);
                            break;
                        case AccionSummary.Formula:
                            settings = banda.Summaries.Add(summary.Id + "_" + summary.Campo, summary.Formula, SummaryPosition.Left, banda.Columns[summary.Campo]);
                            break;
                    }
                    if (settings != null && !String.IsNullOrEmpty(summary.Display))
                        settings.DisplayFormat = summary.Display;
                }
                catch (Exception ex)
                {
                    Mensaje.MostrarError(ex);
                }
            }
        }

		//protected override GuiaImportacion GuiaImportacionActivaEnGrilla
		//{
		//	get
		//	{
		//		if (_vp.TipoVista == TipoVistaPersonalizada.HQL)
		//		{
		//			return base.GuiaImportacionActivaEnGrilla;
		//		}
		//		else if (_vp.TipoVista == TipoVistaPersonalizada.SQL)
		//		{
		//			if (this.ultraGrid1.ActiveRow != null &&
		//			!this.ultraGrid1.ActiveRow.IsGroupByRow)
		//			{
		//				DataRowView drv = this.ultraGrid1.ActiveRow.ListObject as DataRowView;
		//				if (drv != null && drv.Row.Table.Columns.Contains("Id"))
		//					return GuiaImportacion.Leer(Convert.ToInt32(drv["Id"]));
		//			}
		//		}
		//		return null;
		//	}
		//}
        protected override ArrayList ElementosSeleccionados
        {
            get
            {
                if (_vp.TipoVista == TipoVistaPersonalizada.HQL)
                {
                    return base.ElementosSeleccionados;
                }
                else if (_vp.TipoVista == TipoVistaPersonalizada.SQL)
                {
                    ArrayList seleccionados = new ArrayList();

                    if (this.ultraGrid1.Selected.Rows.Count == 0)
                    {
                        return seleccionados;
                    }
                    DataRowView drv;
                    if (this.ultraGrid1.ActiveRow != null && !this.ultraGrid1.ActiveRow.Selected)
                    {
                        drv = this.ultraGrid1.ActiveRow.ListObject as DataRowView;
                        if (drv != null)
                        {
                            if (drv.Row.Table.Columns.Contains("Id"))
                            {
                                seleccionados.Add(GuiaImportacion.Leer(Convert.ToInt32(drv["Id"])));
                                if (seleccionados[0] == null)
                                    return null;
                                return seleccionados;
                            }
                        }
                    }
                    foreach (UltraGridRow r in this.ultraGrid1.Selected.Rows)
                    {
                        if (r.ListObject != null && !r.IsFilteredOut)
                        {
                            drv = r.ListObject as DataRowView;
                            if (drv != null && drv.Row.Table.Columns.Contains("Id"))
                                seleccionados.Add( GuiaImportacion.Leer(Convert.ToInt32(drv["Id"])));
                        }
                    }
                    //Si Algo de los elementos seleccionados es null - no devuelve elementos
                    bool tieneNulos = false;
                    foreach (object obj in seleccionados)
                    {
                        if (obj == null)
                        {
                            tieneNulos = true;
                            break;
                        }
                    }
                    if (tieneNulos)
                        return null;
                    else
                        return seleccionados;
                }
                return null;
            }
        }
		//public override void AbrirElemento(object elemento)
		//{
		//	if (_vp.TipoVista == TipoVistaPersonalizada.HQL)
		//		base.AbrirElemento(elemento);
		//	else if (_vp.TipoVista == TipoVistaPersonalizada.SQL)
		//	{
		//		if (GuiaImportacionActivaEnGrilla != null)
		//			base.AbrirElemento(GuiaImportacionActivaEnGrilla);
		//	}
		//}
		//protected override void ActualizarPaneles()
		//{
		//	if (_vp.TipoVista == TipoVistaPersonalizada.HQL)
		//	{
		//		base.ActualizarPaneles();
		//	}
		//	else if (_vp.TipoVista == TipoVistaPersonalizada.SQL)
		//	{
		//		if (_refreshPanelesHabilitado && this.ultraGrid1.ActiveRow != null && this.ultraGrid1.ActiveRow.ListObject is DataRowView)
		//		{
		//			DataRowView drv = this.ultraGrid1.ActiveRow.ListObject as DataRowView;
		//			int EntidadId;
		//			if (drv.Row.Table.Columns.Contains("Id"))
		//				EntidadId = Convert.ToInt32(drv["Id"]);

		//			//panel actividades
		//			bool panelVisible = !ultraDockManager1.ControlPanes[this.controlNotas1].Closed;
		//			if (panelVisible)
		//			{
		//				this.controlNotas1.Entidad = GuiaImportacionActivaEnGrilla;
		//				this.ultraDockManager1.ControlPanes[this.controlNotas1].Text = "Notas";
		//			}
		//		}
		//	}
		//}

        protected override object RecuperarDatos()
        {
            using (DL dl = DL.ObtenerSesion())
            {
                Alcances alcance = ConfigBL.ticket.TienePrivilegio(PRV.GUIA_IMPO_VER);
                //string alias = "op";
                if (_vp.TipoVista == TipoVistaPersonalizada.HQL)
                    return dl.Listar<GuiaImportacion>(ReemplazarVariables(_vp.Texto));
                else if (_vp.TipoVista == TipoVistaPersonalizada.SQL)
                    return dl.EjecutarSQL(ReemplazarVariables(_vp.Texto));
                else
                    return null;
            }
        }
        protected override void RestablecerParametros()
        {
            this.contenedorParametros1.RestituirDefaults();
        }

        private string ReemplazarVariables(string consulta)
        {
            foreach (KeyValuePair<string, string[]> kvp in this.contenedorParametros1.Valores)
            {
                consulta = consulta.Replace("#" + kvp.Key, kvp.Value[0]);
                consulta = consulta.Replace("@" + kvp.Key, kvp.Value[1]);
            }
            return AgregarCondicionesVariables(consulta);
        }
        private string AgregarCondicionesVariables(string consulta)
        {
            if (consulta.Contains("$usuarioId"))
                consulta = consulta.Replace("$usuarioId", ConfigBL.ticket.UsuarioID.ToString());
            if (consulta.Contains("$usuarioLogon"))
                consulta = consulta.Replace("$usuarioLogon", "'" + ConfigBL.ticket.UsuarioLogon + "'");
            return consulta;
        }

        private void CargarContenedorParametros()
        {
            this.btnActualizarDatos.Visible = this.btnRestablecerParametros.Visible = false;
            this.panelBusqueda.Visible = ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS)
                                            || ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS_LIMITADA) || _vp.Parametros.Count > 0;
            this.btnEditarVista.Visible = ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS)
                                            || ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS_LIMITADA);
            this.panelBusqueda.Expanded = _vp.Parametros.Count > 0;
            this.contenedorParametros1.VistaPersonalizada = _vp;
            this.contenedorParametros1.Select();
        }
        private void btnEditarVista_Click(object sender, EventArgs e)
        {
            bool administra = ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS);
            bool vistaLimitada = ConfigBL.ticket.VerificarPrivilegio(PRV.ADMINISTRAR_VISTAS_PERSONALIZADAS_LIMITADA);
            bool teniaParametros = _vp.Parametros.Count != 0;
            if (administra || vistaLimitada)
            {
                Form form = App.MostrarEntidad(_vp, true);
                if (form.DialogResult == DialogResult.OK)
                {
                    if (administra && (teniaParametros || _vp.Parametros.Count != 0) && Mensaje.Pregunta("¿Desea volver a cargar los parámetros?") == DialogResult.Yes)
                        CargarContenedorParametros();

                    ActualizarListaDesdeOrigen();
                }
            }
        }

    }
}
