using System;

namespace MarDevs.Gestion.Win
{
	public delegate void FormInvalidadoEventHandler(object sender, FormInvalidadoEventArgs e);

	/// <summary>
	/// Clase que se utiliza para proporcionar la informacion del evento FormInvalidado
	/// </summary>
	public class FormInvalidadoEventArgs: EventArgs
	{
		public FormInvalidadoEventArgs(Exception ex)
		{
			this.m_Excepcion = ex;
		}
		private Exception m_Excepcion;
		public Exception Excepcion
		{
			get {return m_Excepcion;}
			set 
			{
				m_Excepcion = value;
								 
			}
		}

	}


}



