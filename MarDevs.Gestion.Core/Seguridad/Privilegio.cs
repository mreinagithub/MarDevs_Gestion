using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarDevs.Gestion.Core
{
	/// <summary>
	/// Descripción breve de Privilegio.
	/// </summary>
	[Serializable]
    public class Privilegio: Persistente<int>
	{
        private static IList<Privilegio> _privilegios = null;

        public virtual string Nombre { get; private set; }
        public virtual string Categoria { get; private set; }        

        public override string ToString()
        {
            return this.Categoria + " - " + this.Nombre;
        }

        public static IList<Privilegio> Listar()
		{
            if (_privilegios == null)
            {
                using(DL dl = DL.ObtenerSesion())
	            {
                    _privilegios = dl.Listar<Privilegio>();
	            }
            }
            return _privilegios;
        
		}
        public static Privilegio BuscarPorId(int id)
        {
            return Privilegio.Listar().FirstOrDefault(p => p.Id == id);
        }
	}
}
