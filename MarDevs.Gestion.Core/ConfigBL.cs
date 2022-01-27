using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace MarDevs.Gestion.Core
{
	public class ConfigBL
	{
        public static string STR_NO_SE_ENCUENTRA_EL_ARCHIVO = "No se pudo encontrar el archivo de configuración." + Environment.NewLine
            + Environment.NewLine
            + "La próxima pantalla le permitirá ingresar los datos necesarios para conectarse a la Base de Datos.";

		public static string STR_ERROR_CONEXION		= "No se pudo lograr la conexión a la base de datos.";
		private static string usuarioLogon = "marDev";
		private static string usuarioPass = "mDev@1686";
        private static string nombreArchivoConfiguracion = "Config.xml";
        private static TimeSpan diferenciaServer;
        private static Config config = null;
		private static SqlConnection conexion = null;
        public static Ticket ticket;

		/// <summary>
		/// Obtiene la Conexion a la Base de Datos.
		/// </summary>
		public static SqlConnection Conexion
		{
			get
			{
				if( conexion == null )
				{
					try
					{
						conexion = new SqlConnection( ConfigBL.StringDeConexion );
					}
					catch
					{
					}
				}
				return conexion;
			}
		}

		/// <summary>
		/// Obtiene el String de Conexion a la Base de Datos. 
		/// Los valores del String se obtienen de lo que esta Persistido en el archivo de configuracion local.
		/// </summary>
		public static String StringDeConexion
		{
			get
			{
                Config config = ConfigBL.ObtenerConfiguracion();
                string servidor = config.Server;
                string puerto = config.Puerto.ToString();
                string instancia = config.Instancia;
                string baseDeDatos = config.BaseDatos;

				return ConfigBL.ArmarStringDeConexion(servidor, puerto, instancia, baseDeDatos, false);
			}
		}

		/// <summary>
		/// Arma el String de Conexion a la Base de Datos, de acuerdo a los parametros. 
		/// </summary>
		public static String ArmarStringDeConexion(	string server, 
													string puertoTCP, 
													string instancia, 
													string baseDeDatos)
		{
			return ConfigBL.ArmarStringDeConexion(server,puertoTCP,instancia,baseDeDatos,false);
		}

		/// <summary>
		/// Arma el String de Conexion a la Base de Datos, de acuerdo a los parametros. 
		/// Es posible enmascarar la contraseña del usuario (para que se pueda mostrar sin revelar la contraseña).
		/// </summary>
		public static String ArmarStringDeConexion(	string server, 
													string puertoTCP, 
													string instancia, 
													string baseDeDatos, 
													bool enmascararPass)
		{
			string tempString = "Server=" + server.Trim();
			if ( puertoTCP != null && puertoTCP.Length > 0 )
			{
				tempString += "," + puertoTCP.Trim();
			}
			if ( instancia != null && instancia.Length > 0 )
			{
				tempString += "\\" + instancia.Trim();
			}
			tempString += ";DataBase=" + baseDeDatos.Trim();
			//tempString += ";User ID=" + ConfigBL.usuarioLogon.Trim();
			tempString += ";User ID=";

			if (enmascararPass)
			{
				for (int i = 0; i < ConfigBL.usuarioLogon.Trim().Length; i++)
					tempString += "*";
			}
			else
			{
				tempString += ConfigBL.usuarioLogon.Trim();
			}

			tempString += ";Password=";
			if( enmascararPass )
			{
				for(int i=0; i<ConfigBL.usuarioPass.Trim().Length; i++)
					tempString += "*";
			}
			else
			{
				tempString += ConfigBL.usuarioPass.Trim();
			}

			tempString += ";Persist Security Info=False";

			return tempString;
		}


		/// <summary>
		/// Prueba la Conexion a la Base de Datos.
		/// </summary>
		public static void ProbarConexion()
		{
			try
			{
				ConfigBL.Conexion.Open();
			}
			catch (Exception ex)
			{
				throw new ExcepcionTecnica(ConfigBL.STR_ERROR_CONEXION + Environment.NewLine + Environment.NewLine
					+ "Es posible que los parametros del archivo de configuración " + Environment.NewLine
					+ "sean incorrectos o bien que el servidor no esté disponible.", ex);
			}
			finally
			{
				if (ConfigBL.Conexion.State == ConnectionState.Open) {ConfigBL.Conexion.Close();}
			}
		}
		/// <summary>
		/// Inicializa (en null) la Conexion a la Base de Datos.
		/// </summary>
		public static void ResetearConexion()
		{
			ConfigBL.conexion = null;
		}
        /// <summary>
        /// Comprueba el estado de la red e Internet
        /// </summary>
        public static void ComprobarConexionInternet()
        {
            Microsoft.VisualBasic.Devices.Network lObj_NetworkTester = new Microsoft.VisualBasic.Devices.Network();
            if (lObj_NetworkTester.IsAvailable)
                lObj_NetworkTester.Ping("www.google.com.ar", 1000);
            else
                throw new ExcepcionTecnica("No se encuentra disponible la conexión");
        }
		/// <summary>
		/// Obtiene la Fecha y Hora del Servidor de Base de Datos y retiene la diferencia con la fecha de la Maquina.
		/// </summary>
		public static void SincronizarHoraConServidor()
		{
			SqlCommand cmd = new SqlCommand("SELECT GETDATE()");
			try
			{
				cmd.Connection = ConfigBL.Conexion;
				cmd.Connection.Open();
				DateTime fechaServer = Convert.ToDateTime(cmd.ExecuteScalar());
				ConfigBL.diferenciaServer = fechaServer.Subtract(DateTime.Now);
			}
			catch(SqlException)
			{
				throw;
			}
			catch
			{
				throw new Exception("No fue posible sincronizar la hora con el servidor.");
			}
			finally
			{
				if (cmd.Connection.State == ConnectionState.Open )
				{
					cmd.Connection.Close();
				}
			}
		}
		/// <summary>
		/// Devuelve la fecha y hora actual.
		/// </summary>
		public static DateTime FechaYHoraActual
		{
			get
			{
				return DateTime.Now.AddTicks(ConfigBL.diferenciaServer.Ticks);
			}
		}
		/// <summary>
		/// Devuelve la fecha actual, sin incluir horas minutos o segundos.
		/// </summary>
		public static DateTime FechaActual
		{
			get {return ConfigBL.FechaYHoraActual.Date;}
		}
        /// <summary>
        /// Guarda la configuracion local (datos de conexion y demas parametros que se
        /// almacenan en el disco del usuario
        /// </summary>
        /// <param name="config"></param>
        public static void GuardarConfiguracion(Config config)
        {
            StreamWriter writer = null;
            try
            {
				string carpeta = System.Windows.Forms.Application.StartupPath;
				System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(config.GetType());
                writer = new StreamWriter(Path.Combine(carpeta,ConfigBL.nombreArchivoConfiguracion));
                x.Serialize(writer, config);
                ConfigBL.config = config;
            }
            finally
            {
                if (writer != null) { writer.Close(); }
            }

        }
        public static Config ObtenerConfiguracion()
        {
            if (ConfigBL.config == null)
            {
                FileStream stream = null;
                try
                {
                    string claseConfig = System.Configuration.ConfigurationManager.AppSettings.Get("config");
                    XmlSerializer mySerializer = new XmlSerializer(System.Type.GetType(claseConfig, true));
					string carpeta = System.Windows.Forms.Application.StartupPath;
                    stream = new FileStream(Path.Combine(carpeta,ConfigBL.nombreArchivoConfiguracion), FileMode.Open);
                    ConfigBL.config = (Config)mySerializer.Deserialize(stream);
                }
                finally
                {
                    if (stream != null) { stream.Close(); }
                }
            }
            return ConfigBL.config;
        }

	}

}
