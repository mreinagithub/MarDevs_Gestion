using System;

namespace MarDevs.Gestion.Core
{
	[Serializable]
	public class ExcepcionAutenticacion : ExcepcionBase
	{
		public ExcepcionAutenticacion(): base()
		{		}
		public ExcepcionAutenticacion(string pMensaje): base(pMensaje)
		{		}
		public ExcepcionAutenticacion(string pMensaje, Exception pInner): base(pMensaje,pInner)
		{		}
	}
}
