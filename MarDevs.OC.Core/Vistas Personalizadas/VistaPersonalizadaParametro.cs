using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MarDevs.OC.Core
{
	[Serializable]
	public class VistaPersonalizadaParametro : Persistente<int?>
	{
		/*
		 * #IdParametro -- representa el campo por el cual buscar
		 * @IdParametro -- representa el valor a buscar
		 */

        #region Propiedades

        [GridDescriptor("Parámetros ID")]
        public string IdParametro { get; set; } //El ID que luego se reemplaza por las variables en la consulta principal

		[NoVisibleEnGrilla]
        public string Etiqueta { get; set; } //La etiqueta a mostrar (con ; se separan los valores a listar y con | key y texto a mostrar)

		[GridDescriptor("Tipo de Control")]
        public TipoControl TipoControl { get; set; } //determina que control selector va a incializar

		[GridDescriptor("Punto X")]
        public int PuntoX { get; set; } //Punto X

		[GridDescriptor("Punto Y")]
        public int PuntoY { get; set; } //Punto Y

		[GridDescriptor("Ancho total")]
        public int Ancho { get; set; } //Ancho total del control

		[GridDescriptor("Ancho etiqueta")]
        public int AnchoEtiqueta { get; set; } //Ancho de la etiqueta

		[GridDescriptor("Alto Control")]
        public int Alto { get; set; }

		[GridDescriptor("Orden Tabulación")]
        public int Orden { get; set; } //Orden en que se generan los controles (y se tabulan)		

		[NoVisibleEnGrilla]
        public string ConsultaDatos { get; set; } //Consulta para obtener los datos	

		[NoVisibleEnGrilla]
        public string ConsultaDefault { get; set; } //Consulta para obtener el default

		[GridDescriptor("Activo")]
        public bool Activo { get; set; }

		[NoTracking]
		[NoVisibleEnGrilla]
		[XmlIgnore]
        public virtual VistaPersonalizada VistaPersonalizada { get; set; }

        #endregion Propiedades

		public override string ToString()
		{
			return this.IdParametro;
		}

		public static VistaPersonalizadaParametro Crear(VistaPersonalizada vp)
		{
            return new VistaPersonalizadaParametro()
            {
				IdParametro = String.Empty,
				ConsultaDatos = String.Empty,
				ConsultaDefault = String.Empty,
                TipoControl = TipoControl.Texto,
                PuntoX = 5,
                PuntoY = 7,
                Ancho = 250,
                AnchoEtiqueta = 120,
                Alto = 21,
                Orden = 1,
                Activo = true,
                VistaPersonalizada = vp,
				Etiqueta = String.Empty
            };
		}		
		public static VistaPersonalizadaParametro Clonar(VistaPersonalizadaParametro parametroAClonar)
		{
			VistaPersonalizadaParametro vpp = new VistaPersonalizadaParametro();
			vpp.IdParametro = parametroAClonar.IdParametro;
			vpp.Etiqueta = parametroAClonar.Etiqueta;
			vpp.TipoControl = parametroAClonar.TipoControl;
			vpp.PuntoX = parametroAClonar.PuntoX;
			vpp.PuntoY = parametroAClonar.PuntoY;
			vpp.Ancho = parametroAClonar.Ancho;
			vpp.AnchoEtiqueta = parametroAClonar.AnchoEtiqueta;
			vpp.Alto = parametroAClonar.Alto;
			vpp.Orden = parametroAClonar.Orden;
			vpp.ConsultaDatos = parametroAClonar.ConsultaDatos;
			vpp.ConsultaDefault = parametroAClonar.ConsultaDefault;
			vpp.Activo = parametroAClonar.Activo;			
			return vpp;
		}
		public List<string[]> ObtenerPropiedadesParaControl()
		{
			List<string[]> lista = new List<string[]>();
			string[] div = Etiqueta.Split(';').Where( s => !String.IsNullOrEmpty(s)).ToArray();
			foreach (string str in div)
			{
				string[] ve = str.Split('|');
				if (ve.Count() == 1)
					lista.Add( new string[2] {ve[0], ve[0]});
				else if (ve.Count() > 1)
					lista.Add(ve);
			}
			return lista;
		}
	}

	public enum TipoControl
	{
		Texto = 1,
		Check = 2,
		Fecha = 3,
		Combo = 4,
		Periodo = 5,
		Label = 6,
		Boton = 7
	}
}
