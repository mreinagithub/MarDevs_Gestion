using System;

namespace MarDevs.Gestion.Core
{
	[Serializable]
	public class ExcepcionTecnica: ExcepcionBase
	{
		public ExcepcionTecnica(): base()
		{
			//AdministradorDeExcepciones.Publicar(this);
		}
		public ExcepcionTecnica(string pMensaje): base(pMensaje)
		{
			//AdministradorDeExcepciones.Publicar(this);
		}
		public ExcepcionTecnica(string pMensaje, Exception pInner): base(pMensaje,pInner)
		{
			//AdministradorDeExcepciones.Publicar(this);
		}

		public override bool DebeConsiderarseError
		{
			get
			{
				return true;
			}
		}

	}

}
