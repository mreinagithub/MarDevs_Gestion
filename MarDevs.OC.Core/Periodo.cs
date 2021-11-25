using System;
using System.Collections;

namespace MarDevs.OC.Core
{
	/// <summary>
	/// Representa un intervalo de tiempo expresado en función de un desde y un hasta.
	/// </summary>
	public class Periodo
	{
		public Periodo(DateTime desde, DateTime hasta) : this(desde, hasta, String.Empty)
		{}
		public Periodo(DateTime desde, DateTime hasta, string descripcion)
		{
			_desde = desde;
			_hasta = hasta;
			_descripcion = descripcion;
		}

        private string _descripcion = String.Empty;
		private DateTime _desde = DateTime.MinValue;
		private DateTime _hasta = DateTime.MaxValue;

		private static DateTime _sinFiltroDesde = new DateTime(1901, 1, 1);
		private static DateTime _sinFiltroHasta = new DateTime(2079, 1, 1);

		public DateTime Desde
		{
			get{return _desde;}
			set{_desde = value;}
		}
		public DateTime Hasta
		{
			get{return _hasta;}
			set
			{
				if ( value < _desde )
				{
					throw new ExcepcionNegocios("Hasta nunca puede ser anterior a Desde");
				}
				_hasta = value;
			}
		}
		public string Descripcion
		{
			get{return _descripcion;}
			set{_descripcion = value;}
		}

        public override string ToString()
        {
            return this._desde.ToString() + " - " + this._hasta.ToString();
        }
        public string ToShortDateString()
        {
            return _desde.ToString("dd/MM/yy") + " - " + _hasta.ToString("dd/MM/yy");
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Periodo)) { return false; }
            Periodo per = (Periodo)obj;
            return this.Desde.Equals(per.Desde) && this.Hasta.Equals(per.Hasta);
        }
        public override int GetHashCode()
        {
            return this.Desde.GetHashCode() + this.Hasta.GetHashCode();
        }
        public bool EsPeriodoSinFiltro()
		{
			return _desde.Equals(Periodo._sinFiltroDesde) && _hasta.Equals(Periodo._sinFiltroHasta);
		}

        public static Periodo Hoy()
		{
			DateTime desde = DateTime.Parse(DateTime.Today.ToShortDateString() + " 00:00:00");
			DateTime hasta = DateTime.Parse(DateTime.Today.ToShortDateString() + " 23:59:59");
			return new Periodo(desde, hasta, "Hoy");
		}
		public static Periodo Ayer()
		{
			DateTime desde = DateTime.Parse(DateTime.Today.AddDays(-1).ToShortDateString() + " 00:00:00");
			DateTime hasta = DateTime.Parse(DateTime.Today.AddDays(-1).ToShortDateString() + " 23:59:59");
			return new Periodo(desde, hasta, "Ayer");
		}
        public static Periodo Mañana()
        {
            DateTime desde = DateTime.Parse(DateTime.Today.AddDays(1).ToShortDateString() + " 00:00:00");
            DateTime hasta = DateTime.Parse(DateTime.Today.AddDays(1).ToShortDateString() + " 23:59:59");
            return new Periodo(desde, hasta, "Mañana");
        }
        public static Periodo SemanaQueContiene(DateTime fecha)
		{
			int desplazamientoDesde = 0;
			int desplazamientoHasta = 0;
			
			if (fecha.DayOfWeek == 0)//domingo
			{
				desplazamientoDesde = 6;
				desplazamientoHasta = 0;
			}
			else
			{
				desplazamientoDesde = Convert.ToInt32(fecha.DayOfWeek)-1;
				desplazamientoHasta = Convert.ToInt32(fecha.DayOfWeek)-7;
			}
			DateTime desde = DateTime.Parse((fecha.AddDays( desplazamientoDesde * -1 )).ToShortDateString() + " 00:00:00");
			DateTime hasta = DateTime.Parse((fecha.AddDays( desplazamientoHasta * -1 )).ToShortDateString() + " 23:59:59");

			return new Periodo(desde, hasta, String.Empty);
	
		}
		public static Periodo SemanaActual()
		{
			Periodo periodo =  Periodo.SemanaQueContiene(DateTime.Today);
			periodo.Descripcion = "Semana actual";
			return periodo;
		}
		public static Periodo SemanaAnterior()
		{
			Periodo periodo =  Periodo.SemanaQueContiene(DateTime.Today.AddDays(-7));
			periodo.Descripcion = "Semana anterior";
			return periodo;
		}
		public static Periodo SemanaProxima()
		{
			Periodo periodo =  Periodo.SemanaQueContiene(DateTime.Today.AddDays(7));
			periodo.Descripcion = "Semana próxima";
			return periodo;
		}
		public static Periodo MesActual()
		{
			DateTime desde = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1,0,0,0);
			DateTime hasta = desde.AddMonths(1).AddSeconds(-1);
			
			return new Periodo(desde, hasta, "Mes actual");
		}
		public static Periodo MesAnterior()
		{
			DateTime desde = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1,0,0,0);
			desde = desde.AddMonths(-1);
			DateTime hasta = desde.AddMonths(1).AddSeconds(-1);
			
			return new Periodo(desde, hasta, "Mes anterior");
		}
		public static Periodo MesAnioAnterior()
		{
			DateTime desde = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1,0,0,0);
			desde = desde.AddMonths(-12);
			DateTime hasta = desde.AddMonths(1).AddSeconds(-1);
			
			return new Periodo(desde, hasta);
		}
		public static Periodo AnioActual()
		{
			DateTime desde = new DateTime(DateTime.Now.Year,1,1,0,0,0);
			DateTime hasta = desde.AddMonths(12).AddSeconds(-1);
			
			return new Periodo(desde, hasta, "Año actual");
		}
		public static Periodo AnioAnterior()
		{
			DateTime desde = new DateTime(DateTime.Now.Year,1,1,0,0,0);
			desde = desde.AddMonths(-12);
			DateTime hasta = desde.AddMonths(12).AddSeconds(-1);
			
			return new Periodo(desde, hasta, "Año anterior");
		}
		public static Periodo HastaAyer()
		{
			DateTime desde = new DateTime(1901, 1, 1, 0, 0, 0);
			DateTime hasta = DateTime.Parse(DateTime.Today.AddDays(-1).ToShortDateString() + " 23:59:59");
			return new Periodo(desde, hasta, "Hasta Ayer");
		}
		public static Periodo SinFiltro()
		{
			return new Periodo(Periodo._sinFiltroDesde, Periodo._sinFiltroHasta, "Sin Filtro");
		}
		public static ArrayList PeriodosTipicos()
		{
			ArrayList lista = new ArrayList();
			lista.Add(Periodo.Hoy());
			lista.Add(Periodo.SemanaActual());
			lista.Add(Periodo.MesActual());
			lista.Add(Periodo.MesAnterior());
			lista.Add(Periodo.AnioAnterior());
			return lista;
		}

        public static Periodo ObtenerDesdeTexto(string texto)
        {
            //TODO: Ver esto , me parece que ya esta en otro lado.
            if (String.IsNullOrEmpty(texto))
                return null;
            if (texto.Trim().ToUpper() == "HOY")
                return Periodo.Hoy();
            if (texto.Trim().ToUpper() == "AYER")
                return Periodo.Ayer();
            if (texto.Trim().ToUpper() == "SEMANA ACTUAL")
                return Periodo.SemanaActual();
            if (texto.Trim().ToUpper() == "SEMANA ANTERIOR")
                return Periodo.SemanaAnterior();
            if (texto.Trim().ToUpper() == "MES ACTUAL")
                return Periodo.MesActual();
            if (texto.Trim().ToUpper() == "MES ANTERIOR")
                return Periodo.MesAnterior();
            return null;
        }

	}
}
