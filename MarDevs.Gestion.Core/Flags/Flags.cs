using System;
using System.ComponentModel;

namespace MarDevs.Gestion.Core
{
	/// <summary>
	/// Clase que implementa los flags del modelo de seguridad
	/// se puede heredar de esta clase en cualquier sistema que utilice seguridad
	/// para agregar Flags propios
	/// </summary>
    [Serializable]
	public class Flags: NegocioBase, IFlagsSeguridad
	{
        public Flags()
		{
		}

		[Browsable(false)]
        public int? Id { get; private set;}

        [CategoryAttribute("Varios"), DescriptionAttribute("Especifica el nombre de la instalación del sistema.")]
        public virtual string NombreInstalacion { get; set; }

        #region Seguridad

        [CategoryAttribute("Seguridad"), DefaultValueAttribute(5), DescriptionAttribute("Longitud mínima de password.")]
        public int PasswordLongitudMinima { get; set; }
		
		[CategoryAttribute("Seguridad"), DefaultValueAttribute(10), DescriptionAttribute("Longitud máxima de password.")]
        public int PasswordLongitudMaxima { get; set; }

		[CategoryAttribute("Seguridad"), DefaultValueAttribute(30), DescriptionAttribute("Días de vigencia de password, para los usuarios que tienen vigencia por default. Ingrese 0 si desea que las contraseñas nunca caduquen.")]
        public int DiasVigenciaPassword { get; set; }

		#endregion

        #region Actualizaciones Automáticas

        [CategoryAttribute("Actualizaciones Automáticas"), DefaultValueAttribute(true), DescriptionAttribute("Determina si se habilita o no la descarga de actualizaciones para la aplicacion.")]
        public bool UpdaterHabilitado { get; set; }

        [CategoryAttribute("Actualizaciones Automáticas"), DescriptionAttribute("Dirección URL que utilizará el updater para obtener actualizaciones.")]
        public string UpdaterURL { get; set; }

        [CategoryAttribute("Actualizaciones Automáticas"), DescriptionAttribute("Frecuencia en minutos con la que el sistema buscará actualizaciones.")]
        public int FrecuenciaBusquedaActualizaciones { get; set; }


        #endregion

        #region Configuracion SMTP

        [CategoryAttribute("Notificaciones del Sistema"), DescriptionAttribute("Servidor SMTP que se utiliza para los mails de notificación del sistema.")]
        public string MailSmtp { get; set; }
        [CategoryAttribute("Notificaciones del Sistema"), DescriptionAttribute("Puerto SMTP que se utiliza para los mails de notificación del sistema.")]
        public int MailPort { get; set; }

        [CategoryAttribute("Notificaciones del Sistema"), DescriptionAttribute("Cuenta de usuario del servidor SMTP que se utiliza para los mails de notificación del sistema.")]
        public string MailUserAuth { get; set; }

        [CategoryAttribute("Notificaciones del Sistema"), DescriptionAttribute("Password de la cuenta de usuario del servidor SMTP que se utiliza para los mails de notificación del sistema.")]
        public string MailPassAuth { get; set; }

        [CategoryAttribute("Notificaciones del Sistema"), DescriptionAttribute("Dirección de correo electrónico perteneciente al servidor SMTP que se utiliza para los mails de notificación del sistema.")]
        public string MailFrom { get; set; }
        [CategoryAttribute("Notificaciones del Sistema"), DescriptionAttribute("Nombre a mostrar para la dirección de correo electrónico perteneciente al servidor SMTP que se utiliza para los mails de notificación del sistema.")]
        public string MailFromDisplayName { get; set; }
        [CategoryAttribute("Notificaciones del Sistema"), DescriptionAttribute("Indicar si se debe habilitar SSL para el envío de los mails de notificación del sistema.")]
        public bool HabilitarSSL { get; set; }


        #endregion Configuracion SMTP
     
        #region Reglas de validación de teléfonos y correo

        [CategoryAttribute("Varios"), DescriptionAttribute("Expresión regular para validar telefonos fijos.")]
        public string TelefonoNormalPatronValidacion { get; set; }
        [CategoryAttribute("Varios"), DescriptionAttribute("Texto de ayuda al usuario sobre la carga de un teléfono fijo.")]
        public string TelefonoNormalTextoAyuda { get; set; }
        [CategoryAttribute("Varios"), DescriptionAttribute("Expresión regular para validar telefonos celulares.")]
        public string TelefonoCelularPatronValidacion { get; set; }
        [CategoryAttribute("Varios"), DescriptionAttribute("Texto de ayuda al usuario sobre la carga de un teléfono celular.")]
        public string TelefonoCelularTextoAyuda { get; set; }
		public string EmailPatronValidacion { get; set; }

        #endregion


	}
}
