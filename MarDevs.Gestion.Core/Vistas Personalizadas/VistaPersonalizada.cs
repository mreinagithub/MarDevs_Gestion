using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MarDevs.Gestion.Core;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Core
{
	[Serializable]
	public class VistaPersonalizada : Persistente<Int32?>, IAuditable
	{
		private IList<PrincipalSeguridad> m_Permisos = new List<PrincipalSeguridad>();
		private IList<VistaPersonalizadaFormatoColumna> m_Formatos = new List<VistaPersonalizadaFormatoColumna>();
		private IList<VistaPersonalizadaParametro> m_Parametros = new List<VistaPersonalizadaParametro>();
		private IList<VistaPersonalizadaSummary> m_Summaries = new List<VistaPersonalizadaSummary>();

		#region PROPIEDADES

		[Requerido]
		public virtual string Entidad { get; set; }

		[Requerido]
		[GridDescriptor("Nombre", Width = 150)]
		public virtual string Nombre { get; set; }

		[Requerido]
		[NoVisibleEnGrilla]
		public virtual string Descripcion { get; set; }

		[Requerido]
		[GridDescriptor("Orden")]
		public virtual int Orden { get; set; }

		[Requerido]
		[GridDescriptor("Tipo Vista", Width = 100)]
		public virtual TipoVistaPersonalizada TipoVista { get; set; }

		[Requerido]
		[NoVisibleEnGrilla]
		public virtual string Texto { get; set; }

		[GridDescriptor("Ruta", Width = 150)]
		public virtual string Ruta { get; set; }

		[GridDescriptor("Activa")]
		public virtual bool VistaActiva { get; set; }

		[GridDescriptor("Mostrar datos\nal abrir")]
		public virtual bool EjecutarAlAbrir { get; set; }

		[NoVisibleEnGrilla]
		public virtual string ImagenCarpeta { get; set; }

		[GridDescriptor("Creado El", VisiblePorDefault = false)]
		public virtual DateTime CreadoEl { get; set; }

		[GridDescriptor("Creado Por", VisiblePorDefault = false)]
		[XmlIgnore]
		public virtual UsuarioLight CreadoPor { get; set; }

		[Browsable(false)]
		[TrackAsComponent]
		[XmlIgnore]
		public virtual IList<VistaPersonalizadaFormatoColumna> Formatos
		{
			get
			{
				if (!_coleccionesInicializadas) { InicializarColecciones(); }
				return m_Formatos;
			}
		}
		[Browsable(false)]		
		public virtual IList<PrincipalSeguridad> Permisos
		{
			get
			{
				if (!_coleccionesInicializadas) { InicializarColecciones(); }
				return m_Permisos;
			}
		}
		[Browsable(false)]
		[TrackAsComponent]
		[XmlIgnore]
		public virtual IList<VistaPersonalizadaParametro> Parametros
		{
			get
			{
				if (!_coleccionesInicializadas) { InicializarColecciones(); }
				return m_Parametros;
			}
		}
		[Browsable(false)]
		[TrackAsComponent]
		[XmlIgnore]
		public virtual IList<VistaPersonalizadaSummary> Summaries
		{
			get
			{
				if (!_coleccionesInicializadas) { InicializarColecciones(); }
				return m_Summaries;
			}
		}

		#endregion

		#region PROPIEDADES PARA SERIALIZAR XML

		[XmlElement("Formatos")]
		[NoTracking]
		[NoAuditable]
		public List<VistaPersonalizadaFormatoColumna> FormatosXML
		{
			get { return m_Formatos.ToList(); }			
		}
		[XmlElement("Parametros")]
		[NoTracking]
		[NoAuditable]
		public List<VistaPersonalizadaParametro> ParametrosXML
		{
			get { return m_Parametros.ToList(); }			
		}
		[XmlElement("Summaries")]
		[NoTracking]
		[NoAuditable]
		public List<VistaPersonalizadaSummary> SummariesXML
		{
			get { return m_Summaries.ToList(); }			
		}

		#endregion

		[NoTracking]
		[Browsable(false)]
		public VistaPersonalizadaConvencion Convencion
		{
			get
			{
				switch (Entidad)
				{
					default:
						return new VistaPersonalizadaConvencion();
				}
			}
		}

		public override string ToString()
		{
			if (String.IsNullOrEmpty(Ruta))
				return Nombre;
			else
				return Ruta + "\\" + Nombre;
		}

		#region METODOS DE INSTANCIA

		public override void InicializarColecciones()
		{
			using (DL dl = DL.ObtenerSesion())
			{
				dl.InicializarColeccion(this, m_Permisos);
				dl.InicializarColeccion(this, m_Formatos);
				dl.InicializarColeccion(this, m_Parametros);
				dl.InicializarColeccion(this, m_Summaries);
				this._coleccionesInicializadas = true;
			}
		}

		#endregion

		#region METODOS DE CLASE

		public static VistaPersonalizada Crear()
		{
			return new VistaPersonalizada
			{
				CreadoEl = ConfigBL.FechaYHoraActual,
				CreadoPor = UsuarioLight.Crear(ConfigBL.ticket.Usuario),
				//Entidad = 1000,
				VistaActiva = true,
				TipoVista = TipoVistaPersonalizada.HQL
			};
		}
		public static IList<VistaPersonalizada> Buscar(string queBusca, bool soloActivos)
		{
			using (DL dl = DL.ObtenerSesion())
			{
				IQueryable<VistaPersonalizada> query = dl.SessionLinq<VistaPersonalizada>();
				if (soloActivos)
					query = query.Where(vp => vp.VistaActiva);
				if (!String.IsNullOrEmpty(queBusca))
					query = query.Where(vp => vp.Nombre.Contains(queBusca));

				return query.ToList();
			}
		}
		public static VistaPersonalizada Leer(int? id)
		{
			try
			{
				using (DL dl = DL.ObtenerSesion())
				{
					return dl.Leer<VistaPersonalizada>(id);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		public static DataTable ListarActivosPorEntidadyUsuario(string entidad, Usuario usr)
		{
			//SQL que busca todas las vistas personalizadas activas dada la entidad y el usuario logueado.
			string SQL = "SELECT DISTINCT VP.VISTAPERSONALIZADAID AS ID, VP.NOMBRE AS NOMBRE, VP.DESCRIPCION AS DESCRIPCION, VP.ORDEN, VP.RUTA, VP.IMAGENCARPETA"
						+ " FROM VISTAPERSONALIZADA VP"
						+ " INNER JOIN VISTAPERSONALIZADAPERMISO PER ON PER.VISTAPERSONALIZADAID = VP.VISTAPERSONALIZADAID"
						+ " INNER JOIN PRINCIPALSEGURIDAD PS ON PER.PRINCIPALSEGURIDADID = PS.PRINCIPALSEGURIDADID"
						+ " WHERE VP.VISTAACTIVA = 1"
						+ " AND VP.ENTIDAD = '{0}'"
						+ " AND (PS.TIPO = 1 AND PS.ID = {1} OR PS.TIPO = 2 AND PS.ID IN ( SELECT R.ROLID"
																					   + " FROM ROL R"
																					   + " INNER JOIN USUARIOROL UR ON UR.ROLID = R.ROLID"
																					   + " INNER JOIN USUARIO U ON U.USUARIOID = UR.USUARIOID"
																					   + " WHERE U.USUARIOID = {1}))"
						+ " ORDER BY VP.ORDEN";

			using (DL dl = DL.ObtenerSesion())
			{
				return dl.EjecutarSQL(String.Format(SQL, entidad, usr.Id.Value));
			}
		}
		public static VistaPersonalizada Clonar(VistaPersonalizada vistaAClonar)
		{
			if (vistaAClonar == null)
			{ return null; }
			VistaPersonalizada vistaClonada = VistaPersonalizada.Crear();
			vistaClonada.Entidad = vistaAClonar.Entidad;
			vistaClonada.TipoVista = vistaAClonar.TipoVista;
			vistaClonada.Nombre = vistaAClonar.Nombre;
			vistaClonada.Descripcion = vistaAClonar.Descripcion;
			vistaClonada.Texto = vistaAClonar.Texto;
			vistaClonada.Ruta = vistaAClonar.Ruta;
			vistaClonada.EjecutarAlAbrir = vistaAClonar.EjecutarAlAbrir;
			vistaClonada.ImagenCarpeta = vistaAClonar.ImagenCarpeta;
			foreach (PrincipalSeguridad ps in vistaAClonar.Permisos)
			{
				vistaClonada.Permisos.Add(ps);
			}
			VistaPersonalizadaFormatoColumna formatoClonado;
			foreach (VistaPersonalizadaFormatoColumna vpfc in vistaAClonar.Formatos)
			{
				formatoClonado = VistaPersonalizadaFormatoColumna.Clonar(vpfc);
				formatoClonado.VistaPersonalizada = vistaClonada;
				vistaClonada.Formatos.Add(formatoClonado);
			}
			VistaPersonalizadaParametro parametroClonado;
			foreach (VistaPersonalizadaParametro vpparam in vistaAClonar.Parametros)
			{
				parametroClonado = VistaPersonalizadaParametro.Clonar(vpparam);
				parametroClonado.VistaPersonalizada = vistaClonada;
				vistaClonada.Parametros.Add(parametroClonado);
			}
			VistaPersonalizadaSummary summaryClonado;
			foreach (VistaPersonalizadaSummary vps in vistaAClonar.Summaries)
			{
				summaryClonado = VistaPersonalizadaSummary.Clonar(vps);
				summaryClonado.VistaPersonalizada = vistaClonada;
				vistaClonada.Summaries.Add(summaryClonado);
			}
			return vistaClonada;
		}

		#endregion

		public string ObtenerConvenciones()
		{
			return Convencion.ObtenerConvenciones();
		}

		public string EjecutarConsulta(Dictionary<string, string[]> valoresParametros)
		{
			try
			{
				string consulta = this.Texto;

				foreach (KeyValuePair<string, string[]> kvp in valoresParametros)
				{
					consulta = consulta.Replace("#" + kvp.Key, kvp.Value[0]);
					consulta = consulta.Replace("@" + kvp.Key, kvp.Value[1]);
				}

				//Remplazar variables de alcance y usuario con alcance total ya que son propias de cada entidad
				consulta = consulta.Replace(BuscarAlias(consulta) + "$alcance", "1=1");
				consulta = consulta.Replace("$usuarioId", ConfigBL.ticket.UsuarioID.ToString());
				consulta = consulta.Replace("$usuarioLogon", "'" + ConfigBL.ticket.UsuarioLogon + "'");

				string cumplimientoConvenciones = string.Empty;
				int cantRegistros = 0;
				StringBuilder sbCartel = new StringBuilder();
				using (DL dl = DL.ObtenerSesion())
				{
					if (TipoVista == TipoVistaPersonalizada.HQL)
					{
						IList lista = dl.Listar(consulta);
						cantRegistros = lista.Count;
						cumplimientoConvenciones = Convencion.DeterminarCumplimientoConvencionesHQL(consulta);
						Formatos.Clear();
					}
					else if (TipoVista == TipoVistaPersonalizada.SQL)
					{
						DataTable dt = dl.EjecutarSQL(consulta);
						cantRegistros = dt.Rows.Count;
						cumplimientoConvenciones = Convencion.DeterminarCumplimientoConvencionesSQL(consulta, dt);
						CrearFormatosColumnas(dt);
					}
				}
				sbCartel.AppendLine(String.Format("Comandos completados exitosamente. Cantidad de registros devueltos: {0}", cantRegistros));
				if (string.IsNullOrEmpty(cumplimientoConvenciones))
				{
					sbCartel.AppendLine("Se cumplen correctamente las convenciones.");
				}
				else
				{
					sbCartel.AppendLine("Las siguientes convenciones NO se cumplen:");
					sbCartel.AppendLine(cumplimientoConvenciones);
				}
				return sbCartel.ToString();
			}
			catch
			{
				throw;
			}
		}

		private void CrearFormatosColumnas(DataTable dt)
		{
			// Agrego las columnas que no existan en la colección
			int indice = 0;

			foreach (DataColumn col in dt.Columns)
			{
				bool columnaNueva = true;
				IList<VistaPersonalizadaFormatoColumna> copia = new List<VistaPersonalizadaFormatoColumna>(Formatos);
				foreach (VistaPersonalizadaFormatoColumna vpfc in copia)
				{
					if (col.ColumnName == vpfc.Columna)
					{
						if (indice != copia.IndexOf(vpfc))
						{
							Formatos.Remove(vpfc);
							Formatos.Insert(indice, vpfc);
						}
						columnaNueva = false;
						break;
					}
				}
				if (columnaNueva)
				{
					VistaPersonalizadaFormatoColumna vpfcNuevo = VistaPersonalizadaFormatoColumna.Crear(col);
					vpfcNuevo.VistaPersonalizada = this;
					Formatos.Insert(indice, vpfcNuevo);
				}
				indice++;
			}
			//Elimino de la colección las columnas que ya no existan
			//Para ello creo un IList copia para poder recorrer
			IList<VistaPersonalizadaFormatoColumna> copia2 = new List<VistaPersonalizadaFormatoColumna>(Formatos);
			foreach (VistaPersonalizadaFormatoColumna vpfc in copia2)
			{
				bool existeColumna = false;
				foreach (DataColumn col in dt.Columns)
				{
					if (col.ColumnName == vpfc.Columna)
					{
						existeColumna = true;
						break;
					}
				}
				if (!existeColumna)
					Formatos.Remove(vpfc);
			}
		}
		private string BuscarAlias(string consulta)
		{
			int indice = consulta.IndexOf("$alcance");
			if (indice <= 0)
				return string.Empty;
			int desde = indice;
			int cant = 0;
			for (int i = indice; i > 0; i--)
			{
				if (!consulta[i - 1].Equals(' '))
				{
					desde--;
					cant++;
				}
				else
					break;
			}
			return consulta.Substring(desde, cant);
		}
	}

	public enum TipoVistaPersonalizada
	{
		HQL = 1,
		SQL = 2
	}
}
