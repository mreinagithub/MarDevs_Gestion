using System;
using System.Collections;

namespace MarDevs.OC.Core
{
	/// <summary>
	/// Descripción breve de Privilegio.
	/// </summary>
	[Serializable]
    public class RolPrivilegio: NegocioBase
	{
        public virtual Privilegio Privilegio { get; set; }
        public virtual Alcances Alcance { get; set; }

		public override bool EsValido()
		{
			return (this.Privilegio != null && this.Alcance > 0);
		}
        public override string ToString()
        {
			return Privilegio.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is RolPrivilegio)) { return false; }
            return (this.Privilegio.Equals((obj as RolPrivilegio).Privilegio)
             && this.Alcance.Equals((obj as RolPrivilegio).Alcance));
        }
        public override int GetHashCode()
        {
            return (Privilegio.Id.ToString() + Privilegio.ToString()).GetHashCode();
        }


	}

}
