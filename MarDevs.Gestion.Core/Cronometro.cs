using System;
using System.Collections.Generic;
using System.Text;

namespace MarDevs.Gestion.Core
{
	public class Cronometro
	{
		private long _inicio = DateTime.Now.Ticks;
		private long _fin;

		private static Dictionary<string, Cronometro> _cronometros = new Dictionary<string,Cronometro>();

		public static void Iniciar()
		{
			Iniciar("DEFAULT");
		}
		public static void Iniciar(string nombre)
		{
			_cronometros.Add(nombre, new Cronometro());
		}
		public static double Detener()
		{
			return Detener("DEFAULT");
		}
		public static double Detener(string nombre)
		{
			Cronometro cronometro = _cronometros[nombre];
			cronometro._fin = DateTime.Now.Ticks;
			double _duracion = new TimeSpan(cronometro._fin - cronometro._inicio).TotalMilliseconds;
			Console.WriteLine("Cronometro {0}: {1} ms", nombre, _duracion);
			_cronometros.Remove(nombre);
			return _duracion;
		}

	}
}
