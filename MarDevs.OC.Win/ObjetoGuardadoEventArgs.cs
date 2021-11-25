using System;

namespace MarDevs.OC.Win
{
	public delegate void ObjetoGuardadoEventHandler(object sender, ObjetoGuardadoEventArgs e);

	/// <summary>
	/// Clase que se utiliza para proporcionar la informacion del evento ObjetoGuardado
	/// </summary>
	public class ObjetoGuardadoEventArgs: EventArgs
	{
		public ObjetoGuardadoEventArgs(object objeto)
		{
			_objeto = objeto;
		}
		private object _objeto;
		public object Objeto
		{
			get { return _objeto; }
			set { _objeto = value; }
		}

	}


}



