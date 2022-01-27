using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Reporting.WinForms;

namespace MarDevs.Gestion.Core
{
	public class Util
	{
		public static string STR_ERROR_ACCESO_DATOS = "Se ha producido un error al intentar acceder o modificar la base de datos.";

		#region Metodos relacionados con Encriptacion
		
		private static string _SemillaEncriptacion = "_marDevs_seedEnc";

		private static string EncriptarDES(byte[] bytes, string clave)
		{
			string lClave = _SemillaEncriptacion + clave;
			DESCryptoServiceProvider miDes = new DESCryptoServiceProvider();
			System.Text.StringBuilder lDevolver = new System.Text.StringBuilder();

			#region Incrementar o truncar el tamaño de la Clave
			// La Clave para DES debe tener una longitud de 64 bits (8 bytes)
			while( lClave.Length < 8 )
			{
				lClave += lClave;
			}
			if( lClave.Length > 8)
			{
				lClave = lClave.Substring(0,8);
			}
			#endregion

			#region Create the crypto objects, with the key, as passed in
			miDes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(lClave);
			miDes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(lClave);

	        MemoryStream miMS = new MemoryStream();
			CryptoStream miCS = new CryptoStream(miMS, miDes.CreateEncryptor(), CryptoStreamMode.Write);
			#endregion

			#region Write the byte array into the crypto stream (It will end up in the memory stream)
	        miCS.Write(bytes, 0, bytes.Length);
		    miCS.FlushFinalBlock();
			#endregion

			#region Get the data back from the memory stream, and into a string
			foreach( byte miByte in miMS.ToArray())
			{
				lDevolver.AppendFormat("{0:X2}", miByte);
			}
			#endregion

			return lDevolver.ToString();
		}
		private static string EncriptarDES(byte[] bytes)
		{
			return EncriptarDES(bytes,String.Empty);
		}
		public static string EncriptarDES(string texto, string clave)
		{
			byte[] Datos = System.Text.Encoding.UTF8.GetBytes(texto);
			return EncriptarDES(Datos, clave);
		}
		public static string EncriptarDES(string texto)
		{
			return EncriptarDES(texto, String.Empty);
		}
		private static string DecriptarDES(byte[] bytes, string clave)
		{
			string lClave = _SemillaEncriptacion + clave;
			DESCryptoServiceProvider miDes = new DESCryptoServiceProvider();
			System.Text.StringBuilder lDevolver = new System.Text.StringBuilder();

			#region Incrementar o truncar el tamaño de la Clave
			// La Clave para DES debe tener una longitud de 64 bits (8 bytes)
			while( lClave.Length < 8 )
			{
				lClave += lClave;
			}
			if( lClave.Length > 8)
			{
				lClave = lClave.Substring(0,8);
			}
			#endregion

			#region Create the crypto objects
	        miDes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(lClave);
		    miDes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(lClave);
			MemoryStream miMS = new MemoryStream();
			CryptoStream miCS = new CryptoStream(miMS, miDes.CreateDecryptor(), CryptoStreamMode.Write);
			#endregion

			#region Flush the data through the crypto stream into the memory stream
			miCS.Write(bytes, 0, bytes.Length);
			miCS.FlushFinalBlock();
			#endregion

			#region Get the decrypted data back from the memory stream
			foreach( byte miByte in miMS.ToArray() )
			{
				lDevolver.Append( (char) miByte );
			}
			#endregion

			return lDevolver.ToString();
		}
		private static string DecriptarDES(byte[] bytes)
		{
			return DecriptarDES(bytes,_SemillaEncriptacion);
		}
		public static string DecriptarDES(string texto, string clave)
		{
			if ( texto == null )
			{
				return null;
			}
			int lLongitud = texto.Length / 2;
			byte[] Datos = new byte[lLongitud];

			for(int i=0; i<lLongitud; i++)
			{
				int lIndividual = Convert.ToInt32(texto.Substring(i * 2, 2), 16);
				Datos[i] = (byte) lIndividual;
			}
			return DecriptarDES(Datos,clave);
		}
		public static string DecriptarDES(string texto)
		{
			return DecriptarDES(texto,_SemillaEncriptacion);
		}
		private static string EncriptarSHA(byte[] bytes, string clave)
		{
			string lClave = _SemillaEncriptacion + clave;
			byte[] miClave = System.Text.Encoding.UTF8.GetBytes(lClave);

			HMACSHA1 miHMAC = new HMACSHA1(miClave);
			CryptoStream cs = new CryptoStream(Stream.Null, miHMAC, CryptoStreamMode.Write);
			cs.Write(bytes,0,bytes.Length);
			cs.Close();

			return Convert.ToBase64String(miHMAC.Hash);
		}
		private static string EncriptarSHA(byte[] bytes)
		{
			return EncriptarSHA(bytes,String.Empty);
		}
		public static string EncriptarSHA(string texto, string clave)
		{
			byte[] Datos = System.Text.Encoding.UTF8.GetBytes(texto);
			return EncriptarSHA(Datos, clave);
		}
		public static string EncriptarSHA(string texto)
		{
			return EncriptarSHA(texto, String.Empty);
		}

		
		#endregion

		/// <summary>
		/// Genera un string random.
		/// </summary>
		/// <param name="longitud">La longitud del string a generar.</param>
		/// <returns>Una cadena random de acuerdo a la longitud indicada por el parámetro longitud</returns>
		public static string GenerarRandomString(int longitud)
		{
			Random miRandom = new Random();
			string lNuevoString = Util.EncriptarSHA( Convert.ToString(miRandom.Next()), longitud.ToString() );
			return lNuevoString.Substring( 0, longitud );
		}
		/// <summary>
		/// Método helper que devuelve el valor de una propiedad de un objeto utilizando reflexión.
		/// </summary>
		/// <param name="objeto">Objeto al que se le va a leer la propiedad</param>
		/// <param name="propiedad">Nombre de la propiedad a leer del objeto</param>
		/// <returns>El valor de la propiedad leída del objeto.</returns>
		
		public static object LeerProperty(object objeto, string propiedad)
		{
			object valor = null;

			Type tipo = objeto.GetType();
			PropertyInfo pinfo = tipo.GetProperty(propiedad);
			if (pinfo != null && pinfo.CanRead)
			{
				valor = pinfo.GetValue(objeto, null);
			}
			return valor;
		}
		
		public static Boolean EscribirProperty(object objeto, string propiedad,Object valor)
		{
			Type tipo = objeto.GetType();
			PropertyInfo pinfo = tipo.GetProperty(propiedad);
			if (pinfo != null && pinfo.CanWrite)
			{
				pinfo.SetValue(objeto, valor,null);
			}
			return (pinfo!=null);
		}
		public static Type TipoProperty(object objeto, string propiedad)
		{
			Type tipo = objeto.GetType();
			PropertyInfo pinfo = tipo.GetProperty(propiedad);
			if (pinfo != null)
			{
				return pinfo.PropertyType;
			}
			else
			{
				return null;
			}

		}

        /// <summary>
        /// Compara dos objetos y deuvelve una lista de diferencias.
        /// </summary>
        /// <param name="nombreObjeto">Nombre del objeto para utilizar como prefijo en propiedades que se comparan con el atributo TrackAsComponent</param>
        /// <param name="actual">Objeto actual</param>
        /// <param name="snapshot">Objeto contra el que comparar</param>
        /// <returns>Lista de cambios detectados por la comparación</returns>
		public static ArrayList ObtenerDiferenciasObjetos(object actual, object snapshot, string nombreObjeto)
        {
            ArrayList cambios = new ArrayList();
            Cambio cambio = null;
            object valorActual;
            object valorSnapshot;
            string nombreFull = String.Empty;
            object[] attrArray;

            if (snapshot == null)
            {
                return cambios;
            }

            foreach (PropertyInfo property in actual.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (nombreObjeto != null && nombreObjeto.Length > 0)
                {
                    nombreFull = nombreObjeto + "." + property.Name;
                }
                else
                {
                    nombreFull = property.Name;
                }

                attrArray = property.GetCustomAttributes(typeof(NoTrackingAttribute), true);
                if (attrArray.Length > 0) // el atributo de no tracking fue aplicado, salteo la property
                {
                    continue;
                }

				bool trackAsComponent = (property.GetCustomAttributes(typeof(TrackAsComponentAttribute), true).Length > 0);
                //ver si hay q trackear cambios como component                
 				if (trackAsComponent && !property.PropertyType.Name.Contains("IList")) //trackear como component
                {
                    valorActual = property.GetValue(actual, null);
                    valorSnapshot = property.GetValue(snapshot, null);
					cambios.AddRange(Util.ObtenerDiferenciasObjetos(valorActual, valorSnapshot, nombreFull));
                    continue;
                }
                if (property.PropertyType.Name.Contains("IList") )
                {
                    IList listaActual = property.GetValue(actual, null) as IList;
                    IList listaCopia = property.GetValue(snapshot, null) as IList;
                    cambios.AddRange(Util.ObtenerDiferenciasColeccion(property.Name, listaActual, listaCopia, trackAsComponent));
                }
                else
                {
                    valorActual = property.GetValue(actual, null);
                    valorSnapshot = property.GetValue(snapshot, null);
                    if (valorActual == null && valorSnapshot != null)
                    {
                        cambio = new Cambio();
                        cambio.Tipo = TipoCambio.Property;
                        cambio.NombreProperty = nombreFull;
                        cambio.ValorAnterior = valorSnapshot;
                        cambio.ValorNuevo = valorActual;
                        cambios.Add(cambio);
                    }
                    else if (valorActual != null && !valorActual.Equals(valorSnapshot))
                    {
                        cambio = new Cambio();
                        cambio.Tipo = TipoCambio.Property;
                        cambio.NombreProperty = nombreFull;
                        cambio.ValorAnterior = valorSnapshot;
                        cambio.ValorNuevo = valorActual;
                        cambios.Add(cambio);
                    }

                }
            }
            return cambios;

        }
		public static ArrayList ObtenerDiferenciasObjetos(object actual, object snapshot)
		{
			return ObtenerDiferenciasObjetos(actual, snapshot, String.Empty);
		}
        protected static ArrayList ObtenerDiferenciasColeccion(string nombreProperty, IList listaActual, IList listaSnapshot, bool trackAsComponent)
        {
            ArrayList cambios = new ArrayList();
            Cambio cambio = null;
            //verificar elementos agregados
            foreach (object item in listaActual)
            {
                if (!listaSnapshot.Contains(item))
                {
                    cambio = new Cambio();
                    cambio.Tipo = TipoCambio.ElementoAgregado;
                    cambio.NombreProperty = nombreProperty;
                    cambio.ValorAnterior = null;
                    cambio.ValorNuevo = item;
                    cambios.Add(cambio);
                }
				else if (trackAsComponent)
				{
					ArrayList cambiosItem = ObtenerDiferenciasObjetos(item, listaSnapshot[listaSnapshot.IndexOf(item)], String.Concat(nombreProperty, "(", item.ToString(), ")"));
					cambios.AddRange(cambiosItem);
				}
            }
            //verificar elementos eliminados
            foreach (object item in listaSnapshot)
            {
                if (!listaActual.Contains(item))
                {
                    cambio = new Cambio();
                    cambio.Tipo = TipoCambio.ElementoEliminado;
                    cambio.NombreProperty = nombreProperty;
                    cambio.ValorAnterior = item;
                    cambio.ValorNuevo = null;
                    cambios.Add(cambio);
                }
            }
            return cambios;

        }

		/// <summary>
        /// Genera una copia exacta del objeto utilizando serialización binaria.
        /// </summary>
        /// <param name="objeto">El objeto que se va a copiar.</param>
        /// <returns></returns>
		public static object CopiarObjeto(object objeto)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(ms, objeto);
                ms.Seek(0, SeekOrigin.Begin);
                object copia = formatter.Deserialize(ms);
                return copia;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                ms.Close();
                ms.Dispose();
            }
        }
		
		/// <summary>
		/// Convierte la primera letra da cada palabra de un string a mayúsculas.
		/// </summary>
		/// <param name="texto"></param>
		/// <returns></returns>
		public static string ConvertirToProperCase(string texto)
		{
			return Regex.Replace(texto, @"\w+", new MatchEvaluator(CapitalizeText));
		}
		private static string CapitalizeText(Match m)
		{
			string x = m.ToString();
			string res = String.Empty;
			for (int i = 0; i < x.Length; i++)
			{
				if (i == 0)
				{
					res += x.Substring(i, 1).ToUpper();
				}
				else
				{
					res += x.Substring(i, 1).ToLower();
				}
			}
			return res;
		}

		/// <summary>
		/// Devuelver verdadero si todos los caracteres del string son dígitos
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool EsNumero(string str)
		{
			for (int i = 0; i < str.Length; i++)
			{
				if (Char.IsDigit(str, i) == false)
				{ return false; }
			}
			return true;
		}

		///// <summary>
		///// Envía un correo electrónico.
		///// </summary>
		///// <param name="smtp">servidor smtp</param>
		///// <param name="usuario">usuario válido en el servidor smtp</param>
		///// <param name="password">password del usuario en el servidor smtp</param>
		///// <param name="mailFrom">dirección desde la que se realiza el envío</param>
		///// <param name="mailTo">destinatario</param>
		///// <param name="mailSubject">Asunto del correo electrónico.</param>
		///// <param name="mailBody">Cuerpo del mensaje</param>
		//public static void EnviarMail(string smtp, int port, bool habilitarSsl,
		//						string usuario, string password,
		//						string mailFrom, string mailTo,
		//						string mailSubject, string mailBody)
		//{
		//	#region Validacion de Parámetros
		//	if (smtp == null || smtp.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado la Dirección del Servidor SMTP."); }
		//	if (usuario == null || usuario.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado el Logon de Usuario para Autenticar con el Servidor SMTP."); }
		//	if (password == null || password.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado la Contraseña de Usuario para Autenticar con el Servidor SMTP."); }
		//	if (mailFrom == null || mailFrom.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado una Dirección de Remitente para enviar el correo."); }
		//	if (mailTo == null || mailTo.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado una Dirección de Destinatario para enviar el correo."); }
		//	if (mailSubject == null || mailSubject.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado un Asunto para el correo."); }
		//	if (mailBody == null || mailBody.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado el cuerpo principal para el correo."); }
		//	#endregion

		//	try
		//	{
		//		//reemplazar ; por , ya que ; no le gusta como separador de múltiples direcciones
		//		mailTo = mailTo.Replace(";", ",");
		//		MailMessage message = new MailMessage(mailFrom, mailTo);
		//		message.Subject = mailSubject;
		//		message.Body = mailBody;
				
		//		//Config smtp y enviar
		//		SmtpClient client = new SmtpClient(smtp, port);
		//		client.DeliveryMethod = SmtpDeliveryMethod.Network;
		//		client.UseDefaultCredentials = false;
		//		client.Credentials = new System.Net.NetworkCredential(usuario, password);
		//		if (habilitarSsl) client.EnableSsl = true;				
		//		client.Send(message);
				
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new ExcepcionTecnica("No se pudo realizar el envío del mail.", ex);
		//	}
		//}

		///// <summary>
		///// Envía un correo electrónico.
		///// </summary>
		///// <param name="smtp">servidor smtp</param>
		///// <param name="usuario">usuario válido en el servidor smtp</param>
		///// <param name="password">password del usuario en el servidor smtp</param>
		///// <param name="mailFrom">dirección desde la que se realiza el envío</param>
		///// <param name="mailTo">destinatario</param>
		///// <param name="mailSubject">Asunto del correo electrónico.</param>
		///// <param name="mailBody">Cuerpo del mensaje</param>
		///// <param name="archivo">Ruta completa de un archivo que se desea adjuntar.</param>
		//public static void EnviarMail(string smtp, int port, bool habilitarSsl,
		//				string usuario, string password,
		//				string mailFrom, string mailTo,
		//				string mailSubject, string mailBody, string archivo)
		//{
		//	#region Validacion de Parámetros
		//	if (smtp == null || smtp.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado la Dirección del Servidor SMTP."); }
		//	if (usuario == null || usuario.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado el Logon de Usuario para Autenticar con el Servidor SMTP."); }
		//	if (password == null || password.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado la Contraseña de Usuario para Autenticar con el Servidor SMTP."); }
		//	if (mailFrom == null || mailFrom.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado una Dirección de Remitente para enviar el correo."); }
		//	if (mailTo == null || mailTo.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado una Dirección de Destinatario para enviar el correo."); }
		//	if (mailSubject == null || mailSubject.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado un Asunto para el correo."); }
		//	if (mailBody == null || mailBody.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado el cuerpo principal para el correo."); }
		//	#endregion
		//	try
		//	{
		//		MailAddress from = new MailAddress(mailFrom);
		//		MailAddress to = new MailAddress(mailTo);
		//		MailMessage message = new MailMessage(from, to);
		//		message.Subject = mailSubject;
		//		message.Body = mailBody;
		//		Attachment attach = new Attachment(archivo, MediaTypeNames.Application.Octet);
		//		// Add time stamp information for the file.
		//		ContentDisposition disposition = attach.ContentDisposition;
		//		disposition.CreationDate = System.IO.File.GetCreationTime(archivo);
		//		disposition.ModificationDate = System.IO.File.GetLastWriteTime(archivo);
		//		disposition.ReadDate = System.IO.File.GetLastAccessTime(archivo);
		//		message.Attachments.Add(attach);

		//		//Config smtp y enviar
		//		SmtpClient client = new SmtpClient(smtp, port);
		//		client.DeliveryMethod = SmtpDeliveryMethod.Network;
		//		client.UseDefaultCredentials = false;
		//		client.Credentials = new System.Net.NetworkCredential(usuario, password);
		//		if (habilitarSsl) client.EnableSsl = true;
		//		client.Send(message);
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new ExcepcionTecnica("No se pudo realizar el envío del mail.", ex);
		//	}
		//}

		///// <summary>
		///// Envía un correo electrónico.
		///// </summary>
		///// <param name="smtp">servidor smtp</param>
		///// <param name="usuario">usuario válido en el servidor smtp</param>
		///// <param name="password">password del usuario en el servidor smtp</param>
		///// <param name="mailFrom">dirección desde la que se realiza el envío</param>
		///// <param name="mailTo">destinatario</param>
		///// <param name="mailSubject">Asunto del correo electrónico.</param>
		///// <param name="mailBody">Cuerpo del mensaje</param>
		///// <param name="streamArchivo">Stream con los bytes del archivo que se desea adjuntar.</param>
		//public static void EnviarMail(string smtp, int port, bool habilitarSsl,
		//		string usuario, string password,
		//		string mailFrom, string mailTo,
		//		string mailSubject, string mailBody, Stream streamArchivo)
		//{
		//	#region Validacion de Parámetros
		//	if (smtp == null || smtp.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado la Dirección del Servidor SMTP."); }
		//	if (usuario == null || usuario.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado el Logon de Usuario para Autenticar con el Servidor SMTP."); }
		//	if (password == null || password.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado la Contraseña de Usuario para Autenticar con el Servidor SMTP."); }
		//	if (mailFrom == null || mailFrom.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado una Dirección de Remitente para enviar el correo."); }
		//	if (mailTo == null || mailTo.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado una Dirección de Destinatario para enviar el correo."); }
		//	if (mailSubject == null || mailSubject.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado un Asunto para el correo."); }
		//	if (mailBody == null || mailBody.Length == 0)
		//	{ throw new ArgumentException("No se ha indicado el cuerpo principal para el correo."); }
		//	#endregion
		//	try
		//	{
		//		MailAddress from = new MailAddress(mailFrom);
		//		MailAddress to = new MailAddress(mailTo);
		//		MailMessage message = new MailMessage(from, to);
		//		message.Subject = mailSubject;
		//		message.Body = mailBody;
		//		Attachment attach = new Attachment(streamArchivo, MediaTypeNames.Application.Octet);
		//		message.Attachments.Add(attach);

		//		//Config smtp y enviar
		//		SmtpClient client = new SmtpClient(smtp, port);
		//		client.DeliveryMethod = SmtpDeliveryMethod.Network;
		//		client.UseDefaultCredentials = false;
		//		client.Credentials = new System.Net.NetworkCredential(usuario, password);
		//		if (habilitarSsl) client.EnableSsl = true;
		//		client.Send(message);

		//	}
		//	catch (Exception ex)
		//	{
		//		throw new ExcepcionTecnica("No se pudo realizar el envío del mail.", ex);
		//	}
		//}

		#region SERIALIZACION DE DATASETS DESDE Y HACIA XML
		
		/// <summary>
		/// Guarda un DataSet en formato XML.
		/// </summary>
		/// <param name="pArchivoNombre">Ruta completa del archivo a generar.</param>
		/// <param name="pDataSet">DataSet a guardar como XML.</param>
		public static void XmlGuardar(string pArchivoNombre, DataSet pDataSet)
		{
			pDataSet.WriteXml( pArchivoNombre );
		}
		/// <summary>
		/// Genera un DataSet a partir de su representación en XML guardada en un archivo.
		/// </summary>
		/// <param name="pArchivoNombre">Ruta completa del archivo a leer.</param>
		/// <returns>DataSet con la misma estructura y datos que el archivo XML leído.</returns>
		public static DataSet XmlRecuperar(string pArchivoNombre)
		{
			DataSet miDataSet = new DataSet();

			miDataSet.ReadXml( pArchivoNombre );

			return miDataSet;
		}

		#endregion

		#region Helpers de SQL

		public static DataTable SqlEjecutarComando(SqlConnection conexion,string sentenciaSql)
		{
			DataTable miDataTable = new DataTable();
			DataRow miDataRow;
			SqlCommand miSqlCommand = new SqlCommand();

			miSqlCommand.Connection = conexion;
			miSqlCommand.CommandType = CommandType.Text;
			miSqlCommand.CommandText = sentenciaSql;
			
			try
			{
				if (miSqlCommand.Connection.State != ConnectionState.Open) {miSqlCommand.Connection.Open();}
				SqlDataReader miDataReader = miSqlCommand.ExecuteReader();
				for(int i=0; i < miDataReader.FieldCount; i++)
				{
					miDataTable.Columns.Add(miDataReader.GetName(i), miDataReader.GetFieldType(i));
				}
				while( miDataReader.Read() )
				{
					miDataRow = miDataTable.NewRow();
					for(int i=0; i < miDataReader.FieldCount; i++)
					{
						miDataRow[i] = miDataReader[i];
					}
					miDataTable.Rows.Add(miDataRow);
				}
			}
			catch (Exception ex)
			{
				throw new ExcepcionTecnica( Util.STR_ERROR_ACCESO_DATOS, ex );
			}
			finally
			{
				miSqlCommand.Connection.Close();
			}

			return miDataTable;
		}
		public static DataTable SqlEjecutarComando(SqlCommand cmd)
		{
			DataTable miDataTable = new DataTable();
			DataRow miDataRow;
			SqlCommand miSqlCommand = cmd;

			//command.Connection = conexion;
			//command.CommandType = CommandType.Text;
			//command.CommandText = sentenciaSql;
			
			try
			{
				miSqlCommand.Connection.Open();
				SqlDataReader miDataReader = miSqlCommand.ExecuteReader();
				for(int i=0; i < miDataReader.FieldCount; i++)
				{
					miDataTable.Columns.Add(miDataReader.GetName(i), miDataReader.GetFieldType(i));
				}
				while( miDataReader.Read() )
				{
					miDataRow = miDataTable.NewRow();
					for(int i=0; i < miDataReader.FieldCount; i++)
					{
						miDataRow[i] = miDataReader[i];
					}
					miDataTable.Rows.Add(miDataRow);
				}
			}
			catch (Exception ex)
			{
				throw new ExcepcionTecnica( Util.STR_ERROR_ACCESO_DATOS, ex);
			}
			finally
			{
				miSqlCommand.Connection.Close();
			}

			return miDataTable;
		}
		public static Object SqlEjecutarEscalar(SqlConnection conexion,string pSentenciaSQL)
		{
			SqlCommand miSqlCommand = new SqlCommand();

			miSqlCommand.Connection = conexion;
			miSqlCommand.CommandType = CommandType.Text;
			miSqlCommand.CommandText = pSentenciaSQL;
			Object miEscalar;
			try
			{
				miSqlCommand.Connection.Open();
				miEscalar = miSqlCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				throw new ExcepcionTecnica( Util.STR_ERROR_ACCESO_DATOS, ex);
			}
			finally
			{
				miSqlCommand.Connection.Close();
			}

			return miEscalar;
		}
		public static int SqlEjecutarNonQuery(SqlConnection conexion,string pSentenciaSQL)
		{
			SqlCommand miSqlCommand = new SqlCommand();
			int miResultado;
			miSqlCommand.Connection = conexion;
			miSqlCommand.CommandType = CommandType.Text;
			miSqlCommand.CommandText = pSentenciaSQL;
			try
			{
				miSqlCommand.Connection.Open();
				miResultado = miSqlCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new ExcepcionTecnica( Util.STR_ERROR_ACCESO_DATOS, ex);
			}
			finally
			{
				miSqlCommand.Connection.Close();
			}

			return miResultado;
		}

		#endregion

		public static DateTime ConvertirToDateTime(object objeto)
		{
			return Convert.ToDateTime((objeto == Convert.DBNull) ? null : objeto);
		}
		public static decimal ConvertirToDecimal(object objeto)
		{
			return Convert.ToDecimal((objeto == Convert.DBNull) ? 0 : objeto);
		}
		public static int ConvertirToInt(object objeto)
		{
			return Convert.ToInt32((objeto == Convert.DBNull) ? 0 : objeto);
		}
		public static double ConvertirToDouble(object objeto)
		{
			return Convert.ToDouble((objeto == Convert.DBNull) ? 0 : objeto);
		}
		public static string ConvertirToString(object objeto)
		{
			return Convert.ToString((objeto == Convert.DBNull) ? String.Empty : objeto);

		}
		/// <summary>
		/// Devuelve una instancia de System.Drawing.Color a partir de su representación en String
		/// </summary>
		/// <param name="colorString">Cadena que representa un color, puede ser en formato RGB por ejemplo 255,255,255 o un nombre, por ejemplo Black o Gray</param>
		/// <returns>Una instancia de System.Drawing.Color o null si colorString no representa un color válido.</returns>
		public static Color ColorFromString(string colorString)
		{
			Color color = Color.Empty;
			string[] rgb = colorString.Split(Char.Parse(","));
			if (rgb.Length == 3)
			{
				int r = Convert.ToInt32(rgb[0]);
				int g = Convert.ToInt32(rgb[1]);
				int b = Convert.ToInt32(rgb[2]);
				color = Color.FromArgb(r, g, b);
			}
			else
			{
				color = Color.FromName(colorString);
			}
			return color;
		}
		public static object ConvertirValor(Type tipo, string valorAConvertir)
		{
			if (valorAConvertir == "null" || tipo == typeof(DBNull))
			{
				return null;
			}
			object valor = null;
			if (tipo == typeof(Color))
			{
				return Color.FromName(valorAConvertir);
			}
			//codigo para manejar nullables
			if (tipo.IsGenericType)
			{
				Type innerType = tipo.GetGenericArguments()[0];
				return ConvertirValor(innerType, valorAConvertir);
			}
			if (tipo.IsEnum)
			{
				valor = Enum.Parse(tipo, valorAConvertir, true);
			}
			else if (tipo.Equals(typeof(Guid)))
			{
				valor = new Guid(valorAConvertir);
			}
			else
			{
				valor = Convert.ChangeType(valorAConvertir, tipo);
			}
			return valor;

		}


		#region DLL IMPORTS
		
		[DllImport("advapi32.dll")]
		private static extern int LogonUser(
			String lpszUsername,
			String lpszDomain,
			String lpszPassword,
			int dwLogonType,
			int dwLogonProvider,
			out IntPtr phToken
			);
		[DllImport("kernel32.dll")]
		private static extern bool CloseHandle(IntPtr hObject);

		[DllImport("advapi32.dll")]
		private static extern bool ImpersonateLoggedOnUser(IntPtr hToken);

		[DllImport("kernel32.dll")]
		private static extern int GetLastError();

		[DllImport("advapi32.dll", SetLastError = true)]
		static extern int RevertToSelf();

		private enum LogonTypes
		{
			LOGON32_PROVIDER_DEFAULT = 0,
			LOGON32_LOGON_INTERACTIVE = 2,
			LOGON32_LOGON_NETWORK = 3,
			LOGON32_LOGON_BATCH = 4,
			LOGON32_LOGON_SERVICE = 5,
			LOGON32_LOGON_UNLOCK = 7,
			LOGON32_LOGON_NETWORK_CLEARTEXT = 8,
			LOGON32_LOGON_NEW_CREDENTIALS = 9
		}

		#endregion

		/// <summary>
		/// Verifica las credenciales provistas con el sistema operativo.
		/// </summary>
		/// <param name="username">cuenta de usuario en Windows (incluyendo cuentas de dominio)</param>
		/// <param name="password">password de la cuenta</param>
		/// <returns>True si las credenciales provistas son válidas o False en caso contrario.</returns>.
		/// ....
		/// .
		public static int CheckWindowsUser(string username, string password)
		{
			IntPtr existingTokenHandle = IntPtr.Zero;

			String domain;
			if (username.IndexOf("\\") > 0)
			{
				//split domain and name
				String[] splitUserName = username.Split('\\');
				domain = splitUserName[0];
				username = splitUserName[1];
			}
			else
			{
				domain = String.Empty;
			}

			int isOkay = 0;

			try
			{
				isOkay = LogonUser(username, domain, password,
					(int)LogonTypes.LOGON32_LOGON_NETWORK, (int)LogonTypes.LOGON32_PROVIDER_DEFAULT,
					out existingTokenHandle);

				return isOkay;
			}
			catch
			{
				throw;
			}
			finally
			{
				//free all handles
				if (existingTokenHandle != IntPtr.Zero)
				{
					CloseHandle(existingTokenHandle);
				}
			}
		}
		public static bool ImpersonarUsuario(string username, string password)
		{
			String domain;
			if (username.IndexOf("\\") > 0)
			{
				//split domain and name
				String[] splitUserName = username.Split('\\');
				domain = splitUserName[0];
				username = splitUserName[1];
			}
			else
			{
				domain = String.Empty;
			}

			IntPtr lnToken;
			int TResult = LogonUser(username, domain, password, (int)LogonTypes.LOGON32_LOGON_NETWORK, (int)LogonTypes.LOGON32_PROVIDER_DEFAULT, out lnToken);
			if (TResult > 0)
			{
				ImpersonateLoggedOnUser(lnToken);
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool RevertirImpersonar()
		{
			RevertToSelf();
			return true;
		}
		/// <summary>
		/// Method to convert a custom Object to XML string
		/// </summary>
		/// <param name="objeto">Object that is to be serialized to XML</param>
		/// <returns>XML string</returns>
		public static String SerializeToXml(object objeto)
		{
			try
			{
				String XmlizedString = null;
				MemoryStream memoryStream = new MemoryStream();
				XmlSerializer xs = new XmlSerializer(objeto.GetType());
				XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

				xs.Serialize(xmlTextWriter, objeto);
				memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
				XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
				return XmlizedString;
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e);
				return null;
			}
		}
		/// <summary>
		/// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
		/// </summary>
		/// <param name="characters">Unicode Byte Array to be converted to String</param>
		/// <returns>String converted from Unicode Byte Array</returns>
		private static String UTF8ByteArrayToString(Byte[] characters)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			String constructedString = encoding.GetString(characters);
			return (constructedString);
		}
		/// <summary>
		/// Converts the String to UTF8 Byte array and is used in De serialization
		/// </summary>
		/// <param name="pXmlString"></param>
		/// <returns></returns>
		private static Byte[] StringToUTF8ByteArray(String pXmlString)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			Byte[] byteArray = encoding.GetBytes(pXmlString);
			return byteArray;
		}

		public static void RestaurarEstado(NegocioBase negocioBase, object _snapshot)
		{
			if (negocioBase == null)
			{
				throw new ArgumentNullException("El objeto a restaurar no puede ser null");
			}
			if (_snapshot == null)
			{
				return;
			}
			foreach (FieldInfo field in negocioBase.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
			{
				object valor = field.GetValue(_snapshot);
				field.SetValue(negocioBase, valor);
			}
		}
		public static char DigitoVerificadorCuit(long rut)
		{
			long contador = 0, sumaTotal = 0, ultimoDigito;
			do
			{
				rut = rut - (ultimoDigito = rut % 10);
				sumaTotal += ultimoDigito * (2 + contador++ % 6);
			} while ((rut /= 10) > 0);
			return (sumaTotal = 11 - (sumaTotal % 11)) == 10 ? 'K' : (sumaTotal == 11 ? '0' : (char)(sumaTotal + (int)'0'));
		}
		public static bool ValidarCuit(string cuit)
		{
			if (String.IsNullOrEmpty(cuit)) { return false; }
			string cuit_limpio = cuit.Replace("-", "");
			if (cuit_limpio.Length != 11) { return false; }
			long numero = Convert.ToInt64(cuit_limpio.Substring(0, 10));
			char digito = Convert.ToChar(cuit_limpio.Substring(10, 1));
			//calcular digito correcto
			char digitoCorrecto = DigitoVerificadorCuit(numero);
			//comparar y devolver resultado
			return (digitoCorrecto == digito);
		}
		public static string GetExternalIp(string urlProveedorIP)
		{
			WebClient WanIP = new WebClient();
			string texto = WanIP.DownloadString(urlProveedorIP);
			return texto;
        }

        #region Metodos Nuevos

        public enum UsuarioDueñoResponsable
        {
            EsDueño,
            EsResponsable,
            EsDueño_O_Responsable
        }
        internal static string ArmarClausulaWhereConAnd(ArrayList condiciones)
        {
            if (condiciones == null || condiciones.Count == 0)
            {
                return String.Empty;
            }

            string txtWhere = String.Empty;
            string condicion = String.Empty;

            for (int i = 0; i < condiciones.Count; i++)
            {
                condicion = Convert.ToString(condiciones[i]);
                if (condicion.Length > 0)
                {
                    txtWhere += String.Format("( {0} )", condiciones[i]);
                    if (i < (condiciones.Count - 1))
                    {
                        txtWhere += " AND ";
                    }
                }
            }
            return txtWhere;
        }
        internal static string ClausulaWherePorAlcance(string prefijoAlias, Alcances alcance, Usuario usuario, UsuarioDueñoResponsable queUsuario)
        {
            string txtWhere = String.Empty;

            switch (alcance)
            {
                case Alcances.Total:
                    txtWhere = "1=1";
                    break;

                case Alcances.Denegado:
                    txtWhere = "1=0";
                    break;
            }
            return txtWhere;
        }

        public static void EnviarMailNotificacion(string mailTo, string mailSubject, string mailBody, string replyTo, string cc)
        {
            Flags flags = FlagsFactory.ObtenerInstancia<Flags>();
            try
            {
                //reemplazar ; por , ya que ; no le gusta como separador de múltiples direcciones
                mailTo = mailTo.Replace(";", ",");
                MailMessage message = new MailMessage(flags.MailFrom, mailTo);
                message.Subject = mailSubject;
                message.Body = mailBody;

                if (!String.IsNullOrEmpty(replyTo))
                {
                    MailAddress replyAddress = new MailAddress(replyTo);
                    message.ReplyToList.Add(replyAddress);
                }
                if (!String.IsNullOrEmpty(cc))
                {
                    cc = cc.Replace(";", ",");
                    message.CC.Add(cc);
                }
                SmtpClient client = new SmtpClient(flags.MailSmtp);
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(flags.MailUserAuth, flags.MailPassAuth);
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw new ExcepcionTecnica("No se pudo realizar el envío del mail.", ex);
            }
        }

        public static string PrepararStringSql(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return texto;
            }
            texto = texto.Replace("*", "%");
            return texto.Replace("'", "''");
        }
        /// <summary>
        /// Valida la corrección de una dirección de mail. Considera válidas las cadenas vacías.
        /// </summary>
        /// <param name="email">email a validar</param>
        /// <returns></returns>
        public static bool ValidarEmail(string email)
        {
            try
            {
                MailAddress ma;
                if (!string.IsNullOrEmpty(email))
                     ma = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion 
    
		public static string ObtenerCopia(int nroCopia)
		{
			string copia;
			switch (nroCopia)
			{
				case 0:
					copia = "ORIGINAL";
					break;
				case 1:
					copia = "DUPLICADO";
					break;
				case 2:
					copia = "TRIPLICADO";
					break;
				case 3:
					copia = "CUADRUPLICADO";
					break;
				case 4:
					copia = "QUINTUPLICADO";
					break;
				case 5:
					copia = "SEXTUPLICADO";
					break;
				case 6:
					copia = "SEPTUPLICADO";
					break;
				case 7:
					copia = "OCTUPLICADO";
					break;
				case 8:
					copia = "NONUPLICADO";
					break;
				case 9:
					copia = "DECUPLICADO";
					break;
				default:
					copia = null;
					break;
			}
			return copia;
		}

        public static void ImprimirFormulario(Formulario formulario, string impresora, params DataTable[] dataSources)
        {
            MemoryStream streamForm = new MemoryStream(formulario.Contenido);
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(streamForm);
            IList<string> lista = report.GetDataSourceNames();

            ReportDataSource dataSource;
            for (int i = 0; i < dataSources.Length; i++)
            {
                dataSource = new ReportDataSource();
                dataSource.Value = dataSources[i];
                dataSource.Name = lista[i];
                report.DataSources.Add(dataSource);
            }

            //SETEAMOS LOS PARAMETROS PARA GENERAR LA COPIA EN LA BASE
			ReportParameter param;
			ReportPrinter rprinter;
			
			for (int i = 0; i < formulario.Copias; i++)
            {
                param = new ReportParameter("Copia", ObtenerCopia(i));
                report.SetParameters(new ReportParameter[] { param });

                //Imprime el boleto
                rprinter = new ReportPrinter();
				rprinter.GenerarPDFReporte(report, false);
                rprinter.ImprimirReporte(report, impresora);
            }
        }
		public static void ArchivoGuardar(string carpetaArchivo, Archivo archivo)
		{
			try
			{
				if (archivo == null || archivo.Contenido == null || String.IsNullOrWhiteSpace(carpetaArchivo + archivo.Nombre)) return;

				using (FileStream fs = new FileStream(Path.Combine(carpetaArchivo, String.Format("{0}.{1}", archivo.Nombre, archivo.Extension)), FileMode.Create))
				{
					fs.Write(archivo.Contenido, 0, archivo.Contenido.Length);	
				}
			}
			catch
			{
				throw;
			}
		}
    }

}
