using System;

namespace MarDevs.OC.Core
{
	[Serializable]
	public class ExcepcionInsertClaveDuplicada : ExcepcionBase
	{
		public ExcepcionInsertClaveDuplicada(): base()
		{		}
		public ExcepcionInsertClaveDuplicada(string pMensaje): base(pMensaje)
		{		}
		public ExcepcionInsertClaveDuplicada(string pMensaje, Exception pInner): base(pMensaje,pInner)
		{		}
	}

}
