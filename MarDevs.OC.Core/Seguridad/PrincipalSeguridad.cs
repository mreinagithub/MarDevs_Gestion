using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MarDevs.OC.Core
{
    [Serializable]
    public class PrincipalSeguridad
    {
        public int Id { get; set; }
        public TipoPrincipalSeguridad Tipo { get; set; }
        public int EntidadID { get; set; }
        public String Descripcion { get; set; }
        public bool Activo { get; set; }

        public override bool Equals(object obj)
        {
            PrincipalSeguridad principal = obj as PrincipalSeguridad;
            if (principal == null) return false;

            return (principal.Id == this.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override string ToString()
        {
            return Descripcion;
        }

        public static IList<PrincipalSeguridad> Listar()
        {
            return Listar(null);
        }
        public static IList<PrincipalSeguridad> Listar(TipoPrincipalSeguridad? tipo)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                IQueryable<PrincipalSeguridad> query = dl.SessionLinq<PrincipalSeguridad>();
                if (tipo != null)
                    query = query.Where(ps => ps.Tipo == tipo);
                return query.ToList<PrincipalSeguridad>(); 
            }
        }
        //public static PrincipalSeguridad BuscarPorUsuarioId(int entidadId)
        //{
        //    return DL.SessionLinq<PrincipalSeguridad>()
        //        .FirstOrDefault(ps => ps.Id == entidadId);
        //}
    }
}
