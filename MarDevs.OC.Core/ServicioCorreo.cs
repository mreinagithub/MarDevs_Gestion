using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MarDevs.OC.Core
{
    public class ServicioCorreo
    {
        public ServicioCorreo()
        {
            var flags = FlagsFactory.ObtenerInstancia<Flags>();

            if (flags == null)
                throw new ExcepcionNegocios("No se lograron obtener los parámetros de la aplicación.");

            SMTP = flags.MailSmtp;
            Puerto = flags.MailPort;
            SSL = flags.HabilitarSSL;
            Usuario = flags.MailUserAuth;
            Password = flags.MailPassAuth;
            From = flags.MailFrom;
            DisplayName = flags.MailFromDisplayName;            

        }

        public string SMTP { get; set; }
        public int Puerto { get; set; }
        public bool SSL { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
        public string DisplayName { get; set; }
        

        public void EnviarEmail(string mailTo, string mailSubject, string mailBody, string pathAdjunto = null)
        {
            try
            {
                VerificarDatosEnvio(mailTo, mailSubject, mailBody);
                var message = ArmarMailMessage(mailTo, mailSubject, mailBody, pathAdjunto);
                var cliente = ObtenerClienteSMTP();
                cliente.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task EnviarEmailAsync(string mailTo, string mailSubject, string mailBody, string pathAdjunto = null)
        {
            try
            {                
                VerificarDatosEnvio(mailTo, mailSubject, mailBody);
                var message = ArmarMailMessage(mailTo, mailSubject, mailBody, pathAdjunto);
                var cliente = ObtenerClienteSMTP();
                await cliente.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void VerificarDatosEnvio(string mailTo, string mailSubject, string mailBody)
        {
            if (SMTP == null || SMTP.Length == 0)
            { throw new ArgumentException("No se ha indicado la Dirección del Servidor SMTP."); }
            if (Usuario == null || Usuario.Length == 0)
            { throw new ArgumentException("No se ha indicado el Logon de Usuario para Autenticar con el Servidor SMTP."); }
            if (Password == null || Password.Length == 0)
            { throw new ArgumentException("No se ha indicado la Contraseña de Usuario para Autenticar con el Servidor SMTP."); }
            if (Puerto == 0)
            { throw new ArgumentException("No se ha indicado el puerto para el Servidor SMTP."); }
            if (From == null || From.Length == 0)
            { throw new ArgumentException("No se ha indicado el remitente del correo."); }
            if (mailTo == null || mailTo.Length == 0)
            { throw new ArgumentException("No se ha indicado una Dirección de Destinatario para enviar el correo."); }
            if (mailSubject == null || mailSubject.Length == 0)
            { throw new ArgumentException("No se ha indicado un Asunto para el correo."); }
            if (mailBody == null || mailBody.Length == 0)
            { throw new ArgumentException("No se ha indicado el cuerpo principal para el correo."); }
        }
        private MailMessage ArmarMailMessage(string mailTo, string mailSubject, string mailBody, string pathAdjunto = null)
        {
            MailAddress from = new MailAddress(From, DisplayName);
            mailTo = LimpiarCadenaDestinatarios(mailTo);
            MailMessage message = new MailMessage();
            message.From = from;
            message.To.Add(mailTo);
            message.Subject = mailSubject;
            message.Body = mailBody + Declaimer();

            if (!String.IsNullOrWhiteSpace(pathAdjunto)) message.Attachments.Add(new Attachment(pathAdjunto));

            return message;
        }
        private SmtpClient ObtenerClienteSMTP()
        {
            //FALTA DARLE LAS CREDENCIALES, VA A FALLAR
            SmtpClient client = new SmtpClient(SMTP, Puerto);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(Usuario, Password);
            if( SSL ) client.EnableSsl = true;
            return client;
        }
        private string Declaimer()
        {            
            string decl = "\n\n\n";
            decl += "------------------------------------------------------------------------\n";
            decl += "Este correo fue enviado automáticamente, no responder.\n";
            decl += "------------------------------------------------------------------------\n";
            return decl;
        }
        private string LimpiarCadenaDestinatarios(string destinatarios)
        {
            //reemplazar ; por , ya que ; no le gusta como separador de múltiples direcciones
            destinatarios = destinatarios.Trim();
            destinatarios = destinatarios.Replace(";", ",");
            //reemplazar , al principio y al final;
            if (destinatarios.StartsWith(","))
                destinatarios = destinatarios.Substring(1, destinatarios.Length - 1);
            if (destinatarios.EndsWith(","))
                destinatarios = destinatarios.Substring(0, destinatarios.Length - 1);
            return destinatarios;
        }
    }
}
