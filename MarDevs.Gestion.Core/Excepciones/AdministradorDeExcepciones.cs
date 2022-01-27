using System;
using log4net;

namespace MarDevs.Gestion.Core
{
	public class AdministradorDeExcepciones
	{
		/// <summary>
		/// Publica una excepción utilizando Log4Net. Absorbe cualquier excepción que se
		/// produzca durante la publicación, de manera que se puede utilizar perfectamente
		/// sin la necesidad de poner un bloque try...catch
		/// </summary>
		/// <param name="excepcion"></param>
        public static void Publicar(Exception excepcion)
        {
            try
            {
                Logger.Error(excepcion.Message, excepcion);
            }
            catch
            {
                //nada, no se pudo publicar la excepción
            }
        }
    }
}
