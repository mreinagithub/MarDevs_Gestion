using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Net;

using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.Diagnostics;
using System.Text;

namespace MarDevs.OC.Win
{
	/// <summary>
	/// Clase que gestiona 
	/// </summary>
	public class AutoUpdater: Component
	{

		#region  VARIABLES PRIVADAS 

		private bool _ProxyEnabled;
		private string _ProxyURL;
		private string _LoginUserName;
		private string _LoginUserPass;
		private string _ConfigURL;
		private bool _AutoRestart;
		private Form _RestartForm;
		private string _LatestConfigChanges;
		private bool _EjecutarBackground = false;
        private Version _NuevaVersion = null;
        private string _UltimoError = String.Empty;
        
        private bool CertificateValidation(
                    Object obj,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors errors)
        { return true; }

		#endregion
		
		public AutoUpdater()
		{
			//
			// If it was easy, anybody could do it!
			//
		}


		# region  PROPIEDADES 

		[DefaultValue(false)]
		[Description("Set to True if you want to use http proxy."), 
		Category("AutoUpdater Configuration")]
		public bool ProxyEnabled 
		{ get { return _ProxyEnabled; } set { _ProxyEnabled = value; } }

		[DefaultValue(@"http://myproxy.com:8080/")]
		[Description("The Proxy server URL.(For example:http://myproxy.com:port)"), 
		Category("AutoUpdater Configuration")]
		public string ProxyURL 
		{ get { return _ProxyURL; } set { _ProxyURL = value; } }

		[DefaultValue(@"")]
		[Description("The UserName to authenticate with."), 
		Category("AutoUpdater Configuration")]
		public string LoginUserName 
		{ get { return _LoginUserName; } set { _LoginUserName = value; } }

		[DefaultValue(@"")]
		[Description("The Password to authenticate with."), 
		Category("AutoUpdater Configuration")]
		public string LoginUserPass 
		{ get { return _LoginUserPass; } set { _LoginUserPass = value; } }
		
        [DefaultValue(@"http://localhost/UpdateConfig.xml")]
		[Description("The URL Path to the configuration file."), 
		Category("AutoUpdater Configuration")]
        public string ConfigURL 
		{ get { return _ConfigURL; } set { _ConfigURL = value; } }

        [DefaultValue(false)]
		[Description("Set to True if you want the app to restart automatically, set to False if you want to use the RestartForm to prompt the user, if RestartForm is null, the app will not restart."), 
		Category("AutoUpdater Configuration")]
        public bool AutoRestart 
		{ get { return _AutoRestart; } set { _AutoRestart = value; } }
		
        public Form RestartForm 
		{ get { return _RestartForm; } set { _RestartForm = value; } }
		
        [BrowsableAttribute(false)]
		public string LatestConfigChanges
		{ get { return _LatestConfigChanges; } set { _LatestConfigChanges = value; } }
		
        public bool EjecutarBackground
		{ get { return _EjecutarBackground; } set { _EjecutarBackground = value; } }

        [BrowsableAttribute(false)]
        public Version NuevaVersion
        {
            get { return _NuevaVersion; }
        }

        [BrowsableAttribute(false)]
        public string UltimoError
        {
            get { return _UltimoError; }
        }

		#endregion


        /// <summary>
        /// Chequea la existencia de una nueva version al archivo determinado por la propiedad
        /// UpdaterURL
        /// </summary>
        /// <returns></returns>
        public bool HayNuevaVersion()
        {
			//For using untrusted SSL Certificates
			//System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();

			//Do the load of the config file
			AutoUpdateConfig config = new AutoUpdateConfig();
			try
			{
				config.LoadConfig(this.ConfigURL, this.LoginUserName, this.LoginUserPass, this.ProxyURL, this.ProxyEnabled);
			}
			catch
			{
				return false;
			}

			this.LatestConfigChanges = config.LatestChanges;

			//Check the file for an update
			Version vCurrent = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
			Version vConfig = new Version(config.AvailableVersion);

			if (vConfig > vCurrent)
			{
				_NuevaVersion = vConfig;
				return true;
			}
			else
			{
				return false;
			}

		}

		/// <summary>
		/// TryUpdate: Invoke this method when you are ready to run the update checking thread
		/// </summary>
		public void IntentarUpdate()
		{
			if (_EjecutarBackground)
			{
				Thread backgroundThread = new Thread(new ThreadStart(this.updateThread));
				backgroundThread.IsBackground = true;
				backgroundThread.Start();
			}
			else
			{
				this.updateThread();
			}
		}//TryUpdate()

		/// <summary>
		/// updateThread: This is the Thread that runs for checking updates against the config file
		/// </summary>
        private void updateThread()
        {
			//For using untrusted SSL Certificates
			//System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();			

			string stUpdateName = "update";
			AutoUpdateConfig config = new AutoUpdateConfig();

			//Do the load of the config file
			try
			{
				config.LoadConfig(this.ConfigURL, this.LoginUserName, this.LoginUserPass, this.ProxyURL, this.ProxyEnabled);
			}
			catch
			{
				return;
			}

			this.LatestConfigChanges = config.LatestChanges;

			//Check the file for an update
			Version vCurrent = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
			Version vConfig = new Version(config.AvailableVersion);
			if (vConfig > vCurrent)
			{
				//MessageBox.Show("New Version Available, New Version: " + vConfig.ToString() + "\r\nDownloading File from: " + config.AppFileURL);               

				/*OLD WAY*/

				//DirectoryInfo diDest = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
				//string stPath = diDest.Parent.FullName + System.IO.Path.DirectorySeparatorChar + stUpdateName + ".zip";

				//There is a new version available
				//if (this.descargarArchivo(config.AppFileURL, stPath))
				//{
				//	//MessageBox.Show("Downloaded New File");
				//	string stDest = diDest.Parent.FullName + System.IO.Path.DirectorySeparatorChar + stUpdateName + System.IO.Path.DirectorySeparatorChar;
				//	//Extract Zip File
				//	this.unzip(stPath, stDest);
				//	//Delete Zip File
				//	File.Delete(stPath);
				//	//Restart App if Necessary
				//	//If true, the app will restart automatically, if false the app will use the RestartForm to prompt the user, if RestartForm is null, it doesn't restart
				//	if (this.AutoRestart || (this.RestartForm != null && this.RestartForm.ShowDialog() == DialogResult.Yes))
				//		this.restart();
				//	//else don't restart
				//}
				/*END OLD WAY*/

				/*NEW WAY*/

				string stPath = Path.Combine(Path.GetTempPath(), stUpdateName + ".zip");
				try
				{
					if (File.Exists(stPath))
					{
						File.Delete(stPath);
					}
				}
				catch
				{
					return;
				}

				if (this.descargarArchivo(config.AppFileURL, stPath))
				{
					string installerPath = Path.Combine(Path.GetDirectoryName(stPath), "ZipExtractor.exe");
					if (File.Exists(installerPath))
						File.Delete(installerPath);
					File.WriteAllBytes(installerPath, Properties.Resources.ZipExtractor);
					StringBuilder arguments = new StringBuilder("\"" + stPath + "\"" + " " + "\"" + Process.GetCurrentProcess().MainModule.FileName + "\"");
					try
					{
						string txtFileLog = Path.Combine(Path.GetDirectoryName(stPath), "updaterArgs.txt");
						if (File.Exists(txtFileLog))
							File.Delete(txtFileLog);
						// Create a new file   
						using (FileStream fs = File.Create(txtFileLog))
						{
							// Add some text to file                                
							byte[] txt = new UTF8Encoding(true).GetBytes(arguments.ToString());
							fs.Write(txt, 0, txt.Length);
						}
					}
					catch { }
					var processStartInfo = new ProcessStartInfo
					{
						FileName = installerPath,
						UseShellExecute = true,
						Arguments = arguments.ToString()//,
														//Verb = "runas"
					};
					if (this.AutoRestart || (this.RestartForm != null && this.RestartForm.ShowDialog() == DialogResult.Yes))
					{
						try
						{
							Process.Start(processStartInfo);
						}
						catch (Win32Exception exception)
						{
							if (exception.NativeErrorCode != 1223)
								throw;
						}
						Application.Exit();
					}

				}

				/*END NEW WAY*/

				//else
				//	MessageBox.Show("Didn't Download File");

			}
			//else
			//	MessageBox.Show("No New Version Available, Web Version: " + vConfig.ToString() + ", Current Version: " +  vCurrent.ToString());

		}

		/// <summary>
		/// descargarArchivo: Download a file from the specified url and copy it to the specified path
		/// </summary>
		private bool descargarArchivo(string url, string path)
		{
            FileStream fs = null;
            HttpWebResponse Response;
            HttpWebRequest Request;

            try
            {

                Request = (HttpWebRequest)HttpWebRequest.Create(url);
                //Request.Headers.Add("Translate: f"); //Commented out 11/16/2004 Matt Palmerlee, this Header is more for DAV and causes a known security issue
                if (this.LoginUserName != null && this.LoginUserName != String.Empty)
                    Request.Credentials = new NetworkCredential(this.LoginUserName, this.LoginUserPass);
                else
                    Request.Credentials = CredentialCache.DefaultCredentials;

				//Modificar políticas de cache para leer siempre desde el server.
				Request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);

				//Added 11/16/2004 For Proxy Clients, Thanks George for submitting these changes
				if (this.ProxyEnabled == true)
                    Request.Proxy = new WebProxy(this.ProxyURL);

                Response = (HttpWebResponse)Request.GetResponse();

                Stream respStream = null;
                respStream = Response.GetResponseStream();

                //Do the Download
                byte[] buffer = new byte[4096];
                int length;

                fs = File.Open(path, FileMode.Create, FileAccess.Write);

                length = respStream.Read(buffer, 0, 4096);
                while (length > 0)
                {
                    fs.Write(buffer, 0, length);
                    length = respStream.Read(buffer, 0, 4096);
                }
                _UltimoError = String.Empty;
                return true;
            }
            catch (Exception e)
            {
				_UltimoError = e.Message;
				try
				{
					//asegurarnos que falle silencioso si no pudiera eliminar el archivo...
					if (File.Exists(path))
						File.Delete(path);
					return false;
				}
				catch
				{
					return false;
				}
            }
            finally
            {
                if (fs != null) { fs.Close(); }
            }
		}//descargarArchivo(string url, string path)

		/// <summary>
		/// unzip: Open the zip file specified by stZipPath, into the stDestPath Directory
		/// </summary>
		private void unzip(string stZipPath, string stDestPath)
		{
			ZipInputStream s = new ZipInputStream(File.OpenRead(stZipPath));
		
			ZipEntry theEntry;
			while ((theEntry = s.GetNextEntry()) != null) 
			{
			
				string fileName = stDestPath + Path.GetDirectoryName(theEntry.Name) + System.IO.Path.DirectorySeparatorChar + Path.GetFileName(theEntry.Name);
			
				//create directory for file (if necessary)
				Directory.CreateDirectory(Path.GetDirectoryName(fileName));
			
				if (!theEntry.IsDirectory) 
				{
					FileStream streamWriter = File.Create(fileName);
				
					int size = 2048;
					byte[] data = new byte[2048];
					while (true) 
					{
						size = s.Read(data, 0, data.Length);
						if (size > 0) 
						{
							streamWriter.Write(data, 0, size);
						} 
						else 
						{
							break;
						}
					}
				
					streamWriter.Close();
				}
			}
			s.Close();
		}//unzip(string stZipPath, string stDestPath)

		/// <summary>
		/// restart: Restart the app, the AppStarter will be responsible for actually restarting the main application.
		/// </summary>
		private void restart()
		{
			Environment.ExitCode = 2; //the surrounding AppStarter must look for this to restart the app.
			Application.Exit();
		}//restart()

	}//class AutoUpdater

	public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
	{
		public TrustAllCertificatePolicy()
		{ }

		public bool CheckValidationResult(ServicePoint sp,
			System.Security.Cryptography.X509Certificates.X509Certificate cert, WebRequest req, int problem)
		{
			return true;
		}


	}
}
