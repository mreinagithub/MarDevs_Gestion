using System;

namespace MarDevs.OC.Core
{
	[Serializable]
	public class ExcepcionNegocios : ExcepcionBase
	{
		public ExcepcionNegocios(): base()
		{		}
		public ExcepcionNegocios(string pMensaje): base(pMensaje)
		{		}
		public ExcepcionNegocios(string pMensaje, Exception pInner): base(pMensaje,pInner)
		{		}
	}

}
