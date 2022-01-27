using System;
using System.Collections;
using NHibernate;

namespace MarDevs.Gestion.Core
{
	/// <summary>
	/// Descripción breve de NHInterceptor.
	/// </summary>
	public class NHInterceptor: EmptyInterceptor
	{
		public NHInterceptor(DL dl)
		{
			this.dl = dl;
		}
		private DL dl = null;
	
		public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
		{
			if (dl.listaRestablecerId == null)
			{
				dl.listaRestablecerId = new ArrayList();
			}
			dl.listaRestablecerId.Add(entity);
			return false;
		}
	}
}
