using System;

namespace MarDevs.Gestion.Win
{
    public delegate void ComandoEjecutadoEventHandler(object sender, ComandoEjecutadoEventArgs e);

	/// <summary>
    /// Clase que se utiliza para proporcionar la informacion del evento OpcionEjecutada
	/// </summary>
    public class ComandoEjecutadoEventArgs : EventArgs
    {
        public ComandoEjecutadoEventArgs(Comando comando)
        {
            _comando= comando;
			_nuevaVentana = false;
        }
		public ComandoEjecutadoEventArgs(Comando comando, bool nuevaVentana)
		{
			_comando = comando;
			_nuevaVentana = nuevaVentana;
		}

        private Comando _comando;
		private bool _nuevaVentana;
		
		public Comando Comando
        {
            get { return _comando; }
            set { _comando = value; }
        }
		public bool NuevaVentana
		{
			get { return _nuevaVentana; }
			set { _nuevaVentana = value; }
		}

    }

}



