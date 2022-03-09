using System;
using System.Windows.Forms;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{
	/// <summary>
	/// Punto de entrada principal del programa
	/// Adicionalmente realiza el login antes de llamar al formulario principal
	/// </summary>
	public class Program
	{
		private Program()
		{
		}

		[STAThread]
		static void Main()
		{
			string ruta = Application.StartupPath.Replace('\\','_');			
			using (SingleInstance spi = new SingleInstance(ruta))
			{
				if (!spi.IsSingleInstance)
				{
					spi.RaiseOtherProcess(ruta);
				}
				else
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Control.CheckForIllegalCrossThreadCalls = false;

					System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
					Version appVersion = a.GetName().Version;
					string appVersionString = appVersion.ToString();

					//ASEGURARNOS QUE SI CAMBIAMOS DE VERSION LOS SETTINGS DE USUARIO SE ACTUALICEN					
					if (MarDevs.Gestion.Win.Properties.Settings.Default.AppVersion != appVersion.ToString())
					{
						MarDevs.Gestion.Win.Properties.Settings.Default.Upgrade();
						MarDevs.Gestion.Win.Properties.Settings.Default.AppVersion = appVersionString;
					}

					#region OBTENER CONFIGURACION
                    try
                    {
                        ConfigBL.ObtenerConfiguracion();
                        //ConfigBL.ComprobarConexionInternet();
                        ConfigBL.SincronizarHoraConServidor();
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        string msg = "No se pudo encontrar el archivo de configuración.\n\n"
                    + "La próxima pantalla le permitirá ingresar los datos necesarios para conectarse a la Base de Datos.";

                        Mensaje.Advertencia(msg);

                        // Invoco a la pantalla de Configuracion de Conexión
                        FormConfigLocal fConfig = new FormConfigLocal(new Config());
                        DialogResult resultadoConfigLocal = fConfig.ShowDialog();

                        if (resultadoConfigLocal != DialogResult.OK)
                        {
                            Application.Exit();
                            return;
                        }
                    }
					//POR EL MOMENTO NO HACEMOS CAMBIOS POR FALLAS EN LA CONEXIÓN
					//catch (SqlException)
					//{
					//	//Mensaje.Error("Se produjo un error en la inicialización. La aplicación no pudo abrirse.", sqlEx);
					//	DialogResult resultPregunta = Mensaje.Pregunta("Se produjo un error en la inicialización: No fue posible conectarse con el servidor.\nDesea abrir el archivo de configuración?");
					//	DialogResult resultadoConfigLocal = DialogResult.Cancel;

					//	if (resultPregunta == DialogResult.Yes)
					//	{
					//		// Invoco a la pantalla de Configuracion de Conexión
					//		FormConfigLocal fConfig = new FormConfigLocal(ConfigBL.ObtenerConfiguracion());
					//		resultadoConfigLocal = fConfig.ShowDialog();
					//	}
					//	if (resultPregunta != DialogResult.Yes || resultadoConfigLocal != DialogResult.OK)
					//	{
					//		Application.Exit();
					//		return;
					//	}
					//}
                    catch (Exception ex)
                    {
                        //if (ex is System.Net.NetworkInformation.PingException)
                        //    Mensaje.Advertencia("No está disponible la conexión a Internet.");
                        //else if (ex is ExcepcionNegocios)
                        //    Mensaje.Error("No hay red disponible, verifique el cable de red o su conexión inalámbrica.",ex);
                        //else
                            Mensaje.Error("Se produjo un error en la inicialización. La aplicación no pudo abrirse.", ex);
                        Application.Exit();
                        return;
                    }

					#endregion

					#region AUTENTICAR
					try
					{
						//CONFIGURAR EL MAPPING PARA HIBERNATE
						Cronometro.Iniciar("MAPPING");
						DL.ConfigurarNHibernate("MarDevs.Gestion.Core", true);
						Cronometro.Detener("MAPPING");

						//AUTENTICACION
						Ticket ticket = null;
						Flags flags = FlagsFactory.ObtenerInstancia<Flags>();
						
						if (ticket == null)
						{
							FormLogin miFormLogin = new FormLogin();
							miFormLogin.TituloFormulario = "Ingreso al sistema";
							ticket = miFormLogin.RealizarAutenticacion(MarDevs.Gestion.Win.Properties.Settings.Default.UltimoUsuarioLogueado);
						}

                        //ESTABLECER EL NOMBRE DE LA INSTALACION                        
						App.NombreInstalacion = (flags != null) ? flags.NombreInstalacion : Application.ProductName;

                        //ESTABLECEMOS LA INSTALACION PARA EL LOGGER LUEGO DEL LOGIN YA QUE PUDIERON HABER CAMBIADO LA BASE
                        Logger.Configurar(App.NombreInstalacion);


                        //Enviamos mail de prueba
                        Logger.Error("Error de prueba",new Exception("Este es un error de prueba"));                   

                        //Usamos servicio de correo para probar
                        //var servicioCorreo = new ServicioCorreo();
                        //var servicionAsync = new ServicioEjecucionAsincrona();
                        //servicionAsync.EjectutarAsincronico(async () =>
                        //{
                        //    try
                        //    {
                        //        await servicioCorreo.EnviarEmailAsync("martinreina84@gmail.com", "Prueba de Envio", "Este es el cuerpo del envío");
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        Mensaje.MostrarError(ex);
                        //    }
                        //});



                        if (ticket != null)
						{
							ConfigBL.ticket = ticket;
							App.RegistrarLogIn();
							Application.Run(new Form1());
							App.RegistrarLogOut();
						}
					}
					catch (Exception ex)
					{
						Splash.Cerrar(false);
						Mensaje.MostrarError(ex);
					}
					finally
					{
						Application.Exit();
					}

					#endregion
				}
			}
		}
				
	}
}
