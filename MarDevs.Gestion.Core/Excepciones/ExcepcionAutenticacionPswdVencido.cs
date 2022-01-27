using System;

namespace MarDevs.Gestion.Core
{
	[Serializable]
	public class ExcepcionAutenticacionPswdVencido : ExcepcionBase
	{
		public ExcepcionAutenticacionPswdVencido(): base()
		{
        }
		public ExcepcionAutenticacionPswdVencido(string pMensaje): base(pMensaje)
		{
        }
		public ExcepcionAutenticacionPswdVencido(string pMensaje, Exception pInner)
			: base(pMensaje, pInner)
		{
        }
	}
}
