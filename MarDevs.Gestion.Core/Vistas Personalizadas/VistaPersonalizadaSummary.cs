using System;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Core
{
	[Serializable]
	public class VistaPersonalizadaSummary : Persistente<int?>
	{
		AccionSummary m_Accion = AccionSummary.Suma;

		[NoVisibleEnGrilla]
		[XmlIgnore]
		public VistaPersonalizada VistaPersonalizada { get; set; }
		[GridDescriptor("Campo")]
		public string Campo { get; set; }
		[GridDescriptor("Acción")]
		public AccionSummary Accion
		{
			get { return m_Accion; }
			set 
			{
				m_Accion = value;
				if (m_Accion != AccionSummary.Formula)
					Formula = "";
			}
		}
		[GridDescriptor("Fórmula")]
		public string Formula { get; set; }
		[GridDescriptor("Texto a mostrar")]
		public string Display { get; set; }
		[GridDescriptor("Ubicación")]
		public UbicacionSummary Ubicacion { get; set; }

		public static VistaPersonalizadaSummary Crear(VistaPersonalizada vp)
		{
			return new VistaPersonalizadaSummary {
				VistaPersonalizada = vp,
				Campo = string.Empty,
				Accion = AccionSummary.Suma,
				Formula = string.Empty,
				Display = "{0}",
				Ubicacion = UbicacionSummary.Izquierda
			};
		}
		public static VistaPersonalizadaSummary Clonar(VistaPersonalizadaSummary summaryAClonar)
		{
			VistaPersonalizadaSummary vps = new VistaPersonalizadaSummary();
			vps.Campo = summaryAClonar.Campo;
			vps.Accion = summaryAClonar.Accion;
			vps.Formula = summaryAClonar.Formula;
			vps.Display = summaryAClonar.Display;
			vps.Ubicacion = summaryAClonar.Ubicacion;
			return vps;
		}
	}

	public enum AccionSummary
	{		
		Suma = 1,
		Cuenta = 2,
		Maximo = 3,
		Minimo = 4,		
		Promedio = 5,
		Formula = 6
	}
	public enum UbicacionSummary
	{
		Izquierda = 1,
		Derecha = 2,
		Centro = 3,
		Columna = 4
	}
}
