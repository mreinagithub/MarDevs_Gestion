using System;
using System.Collections;
using System.Collections.Generic;
using MarDevs.OC.Core;
using System.Linq;

namespace MarDevs.OC.Core
{
	/// <summary>
	/// Un numerador automatico de propuestas en función de un prefijo (usuarioid).
	/// </summary>
	public class Numerador: Persistente<int?>
	{
		protected Numerador()
		{
		}
        
        public virtual string Tipo { get; private set; }
        public virtual string Letra { get; private set; }
        public virtual int Sucursal { get; private set; }
        public virtual int ProximoNumero { get; set; }
        public virtual DateTime? ModificadoEl { get; private set; }
        public virtual UsuarioLight ModificadoPor { get; private set; }

		public override bool EsValido()
		{
			return true;
		}
		public static string ObtenerProximoNumero(string letra, int sucursal, DL dl)
		{
			return ObtenerProximoNumero("XX", letra, sucursal, dl);
		}
		public static string ObtenerProximoNumero(string tipo, string letra, int sucursal, DL dl)
		{
			#region VALIDACION DE PARAMETROS
			
			if (String.IsNullOrEmpty(tipo) || tipo.Length != 2)
				throw new ArgumentException("parámetro tipo debe tener 2 caracteres");
			if (String.IsNullOrEmpty(letra) || letra.Length != 1)
				throw new ArgumentException("parámetro letra debe tener 1 caracter");
			if (sucursal < 0 || sucursal > 9999)
				throw new ArgumentException("parámetro sucursal debe ser un número positivo de hasta 4 posiciones");

			#endregion

			Numerador numerador = dl.SessionLinq<Numerador>().FirstOrDefault(n => n.Tipo == tipo && n.Letra == letra && n.Sucursal == sucursal);
			if (numerador == null)
			{
                numerador = new Numerador()
                {
                    Tipo = tipo,
                    Letra = letra,
                    Sucursal = sucursal,
                    ProximoNumero = 1
                };
			}
			//FORMATEAR EL NUMERO DE COMPROBANTE
            string nro = String.Format("{0}-{1}-{2}-{3}",
				numerador.Tipo,
				numerador.Letra,
				numerador.Sucursal.ToString().PadLeft(4, Char.Parse("0")),
				numerador.ProximoNumero.ToString().PadLeft(8, Char.Parse("0")));
			numerador.ProximoNumero++;
			numerador.ModificadoEl = ConfigBL.FechaYHoraActual;
			numerador.ModificadoPor = UsuarioLight.Crear(ConfigBL.ticket.Usuario);
			dl.Guardar(numerador);
			return nro;
		}
		public static string ObtenerProximoNumero(string tipo, DL dl)
		{
            return ObtenerProximoNumero("X", 0, dl);
		}
	}
}
