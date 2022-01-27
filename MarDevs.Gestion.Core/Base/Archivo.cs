using System;
using System.Collections;
using System.Collections.Generic;

namespace MarDevs.Gestion.Core
{
    [Serializable]
    public class Archivo //: Persistente<int?>
	{
        public Archivo()
        {
            Nombre = string.Empty;
        }

        public virtual string Nombre { get; set; }
        public virtual string Extension { get; set; }
        public virtual byte[] Contenido { get; set; }

		public override string ToString()
		{
			return Nombre;
		}
        //public static Archivo Buscar(string nombre)
        //{
        //    using (DL dl = DL.ObtenerSesion())
        //    {
        //        string hql = String.Format("from Archivo a where a.Nombre='{0}'", nombre);
        //        IList<Archivo> lista = dl.Buscar<Archivo>(hql);
        //        if (lista.Count > 0)
        //        {
        //            return lista[0];
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
	}
}
