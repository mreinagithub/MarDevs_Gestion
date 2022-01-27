using System;
using log4net.Appender;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace MarDevs.Gestion.Core
{
	/// <summary>
	/// Descripción breve de Logger.
	/// </summary>
	public class Logger
	{
		private Logger()
		{
		}
		private static log4net.ILog log = log4net.LogManager.GetLogger("LOGGER");

		static Logger()
		{
			log4net.Config.XmlConfigurator.Configure();
			log4net.GlobalContext.Properties["Logon"] = Environment.UserName;
			log4net.GlobalContext.Properties["Equipo"] = Environment.MachineName;
			log4net.GlobalContext.Properties["SistemaOperativo"] = Environment.OSVersion;
			log4net.GlobalContext.Properties["Ejecutable"] = System.Reflection.Assembly.GetEntryAssembly().GetName();
			log4net.GlobalContext.Properties["Usuario"] = ( ConfigBL.ticket == null ) ? "[Desconocido]" : (ConfigBL.ticket.Usuario.NombreCompleto + " (" + ConfigBL.ticket.Usuario.Logon + ")");
		}

        public static void Configurar(string nombreInstalacion)
        {
            IAppender[] appenders = log4net.LogManager.GetRepository().GetAppenders();
            foreach (IAppender appender in appenders)
            {
                if (appender is SmtpCustomAppender)
                {
					SmtpCustomAppender smtpappender = appender as SmtpCustomAppender;
                    smtpappender.Subject = nombreInstalacion + " - Reporte de Excepción";
					
                    smtpappender.ActivateOptions();
                }
            }
        }

		public static void Error(object mensaje)
		{
			log.Error(mensaje);
			
		}
		public static void Error(object mensaje, Exception ex)
		{
			log.Error(mensaje, ex);
			
		}
		public static void Info(object mensaje)
		{
			log.Info(mensaje);
		}

	}

	/// <summary>
	/// This is a custom appender so that we can enable SSL properly (and support TLS)
	/// </summary>
	public class SmtpCustomAppender : SmtpAppender
	{
		public bool EnableSsl { get; set; }

		public SmtpCustomAppender()
		{				
		}

		/// <summary>
		/// Send the email message - this overrides the email sender so that we can add enabling SSL
		/// </summary>
		/// <param name="messageBody">the body text to include in the mail</param>
		protected override void SendEmail(string messageBody)
		{
			SmtpClient client = new SmtpClient();
			if (!string.IsNullOrEmpty(SmtpHost))
			{
				client.Host = SmtpHost;
			}
			client.Port = Port;
			client.EnableSsl = EnableSsl;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;			
			client.UseDefaultCredentials = false;			
			switch (Authentication)
			{
				case SmtpAuthentication.Basic:
					client.Credentials = new NetworkCredential(Username, Password);
					break;
				case SmtpAuthentication.Ntlm:
					client.Credentials = CredentialCache.DefaultNetworkCredentials;
					break;
			}

			MailMessage message = new MailMessage
			{
				Body = messageBody,
				From = new MailAddress(From)
			};
			message.To.Add(To);
			message.Subject = Subject;
			message.Priority = Priority;
			client.Send(message);
		}
	
	}
	
}
