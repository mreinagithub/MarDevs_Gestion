using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace MarDevs.OC.Core
{
	/// <summary>
	/// Descripción breve de FlagsFactory.
	/// </summary>
	public class FlagsFactory
	{
		private FlagsFactory()
		{
		}

        private static Dictionary<string, object> _flags = new Dictionary<string, object>();

        public static T ObtenerInstancia<T>()
        {
            Type tipo = typeof(T);
            if (!_flags.ContainsKey(tipo.Name))
            {
                using (DL dl = DL.ObtenerSesion())
                {
                    T flag = dl.SessionLinq<T>().FirstOrDefault();
                    if (flag != null)
                        _flags.Add(tipo.Name, flag);
                    else
                        throw new ExcepcionNegocios(String.Format("No existen {0} en la base de datos", tipo.Name));
                }
            }
            return (T)_flags[tipo.Name];
        }

        public static void LimpiarCache()
        {
            _flags.Clear();
        }

        public static void Guardar()
        {
            using(DL dl = DL.ObtenerSesion())
            {
                dl.IniciarTransaccion();
                foreach (KeyValuePair<string, object> flag in _flags)
                {
                    dl.Guardar(flag.Value);
                    NegocioBase neg = flag.Value as NegocioBase;
                    neg.AceptarCambios();
                    neg.CapturarSnapshot();
                }
                dl.ConfirmarTransaccion();
            }
        }

        public static void AceptarCambios()
        {
            foreach (KeyValuePair<string, object> flag in _flags)
            {
                NegocioBase neg = flag.Value as NegocioBase;
                neg.AceptarCambios();
            }
        }
        public static void CapturarSnapshot()
        {
            foreach (KeyValuePair<string, object> flag in _flags)
            {
                NegocioBase neg = flag.Value as NegocioBase;
                neg.CapturarSnapshot();
            }
        }

        public static void DeshacerCambios()
        {
            foreach (KeyValuePair<string, object> flag in _flags)
            {
                NegocioBase neg = flag.Value as NegocioBase;
                neg.DeshacerCambios();
            }
        }

        public static bool HayCambios()
        {
            bool cambios = false;
            foreach (KeyValuePair<string, object> flag in _flags)
            {
                NegocioBase neg = flag.Value as NegocioBase;
                if (neg.HayCambios())
                {
                    cambios = true;
                    break;
                }
            }
            return cambios;
        }
    }
}
