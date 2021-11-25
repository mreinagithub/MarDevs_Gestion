using System;

namespace MarDevs.OC.Core
{
	[Serializable]
	public class ExcepcionConcurrencia : ExcepcionBase
	{
		public ExcepcionConcurrencia(): base()
		{		}
		public ExcepcionConcurrencia(string pMensaje): base(pMensaje)
		{		}
		public ExcepcionConcurrencia(string pMensaje, Exception pInner): base(pMensaje,pInner)
		{		}
	}

}
