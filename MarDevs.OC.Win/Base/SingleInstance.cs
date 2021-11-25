using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

namespace MarDevs.OC.Win
{
	/// <summary>
	///SingleProgamInstance uses a mutex synchronization object
	///to ensure that only one copy of process is running at
	///a particular time.  It also allows for UI identification
	///of the intial process by bring that window to the foreground.
	/// </summary>
	public class SingleInstance : IDisposable
	{

		//Win32 API calls necesary to raise an unowned processs main window
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("user32.dll")]
		private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
		[DllImport("user32.dll")]
		private static extern bool IsIconic(IntPtr hWnd);

		private const int SW_RESTORE = 9;

		//private members 
		private Mutex _processSync;
		private bool _owned = false;


		public SingleInstance()
		{
			//Initialize a named mutex and attempt to
			// get ownership immediatly 
			_processSync = new Mutex(
				true, // desire intial ownership
				Assembly.GetEntryAssembly().GetName().Name,
				out _owned);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="identifier">identificador opcional para el mutex</param>
		public SingleInstance(string identifier)
		{
			//Initialize a named mutex and attempt to
			// get ownership immediately.
			//Use an addtional identifier to lower
			// our chances of another process creating
			// a mutex with the same name.
			_processSync = new Mutex(
				true, // desire intial ownership
				Assembly.GetEntryAssembly().GetName().Name + identifier,
				out _owned);
		}

		~SingleInstance()
		{
			//Release mutex (if necessary) 
			//This should have been accomplished using Dispose() 
			Release();
		}

		public bool IsSingleInstance
		{
			//If we don't own the mutex than
			// we are not the first instance.
			get { return _owned; }
		}

		public void RaiseOtherProcess()
		{
			Process proc = Process.GetCurrentProcess();
			// Using Process.ProcessName does not function properly when
			// the name exceeds 15 characters. Using the assembly name
			// takes care of this problem and is more accruate than other
			// work arounds.
			string assemblyName = Assembly.GetEntryAssembly().GetName().Name;			
			foreach (Process otherProc in Process.GetProcessesByName(assemblyName))
			{
				//ignore this process
				if (proc.Id != otherProc.Id)
				{
					// Found a "same named process".
					// Assume it is the one we want brought to the foreground.
					// Use the Win32 API to bring it to the foreground.
					IntPtr hWnd = otherProc.MainWindowHandle;
					ShowWindowAsync(hWnd, SW_RESTORE);
					if (IsIconic(hWnd))
					{
						ShowWindowAsync(hWnd, SW_RESTORE);
					}
					SetForegroundWindow(hWnd);
					return;
				}
			}
		}
		public void RaiseOtherProcess(string identifier)
		{
			try
			{
				Process proc = Process.GetCurrentProcess();
				// Using Process.ProcessName does not function properly when
				// the name exceeds 15 characters. Using the assembly name
				// takes care of this problem and is more accruate than other
				// work arounds.
				string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
				foreach (Process otherProc in Process.GetProcessesByName(assemblyName))
				{
					//Padeo el camino
					if (otherProc.MainModule != null && !String.IsNullOrEmpty(otherProc.MainModule.FileName))
					{
						string camino = otherProc.MainModule.FileName;
						int largo = 0;
						for (int i = camino.Length; camino[i - 1] != '\\'; i--)
						{
							largo = i;
						}
						camino = camino.Substring(0, largo - 2).Replace('\\', '_');

						//ignore this process
						if (proc.Id != otherProc.Id && assemblyName + identifier == assemblyName + camino)
						{
							// Found a "same named process".
							// Assume it is the one we want brought to the foreground.
							// Use the Win32 API to bring it to the foreground.
							IntPtr hWnd = otherProc.MainWindowHandle;
							if (IsIconic(hWnd))
							{
								ShowWindowAsync(hWnd, SW_RESTORE);
							}
							SetForegroundWindow(hWnd);
							return;
						}
					}
				}
			}
			catch { }; //Consumido
		}

		private void Release()
		{
			if (_owned)
			{
				//If we owne the mutex than release it so that
				// other "same" processes can now start.
				_processSync.ReleaseMutex();
				_owned = false;
			}
		}


		#region Implementation of IDisposable
		public void Dispose()
		{
			//release mutex (if necessary) and notify 
			// the garbage collector to ignore the destructor
			Release();
			GC.SuppressFinalize(this);
		}
		#endregion

	}
}

