using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace MarDevs.OC.Core
{
    [Serializable]
    public class Nota : Persistente<int?>, IAuditable
    {
        [Browsable(false)]
        public virtual string EntidadTipo { get; set; }

        [Browsable(false)]
        public virtual string EntidadId { get; set; }

        public virtual string Texto { get; set; }

        public virtual DateTime CreadoEl { get; set; }

        public virtual UsuarioLight CreadoPor { get; set; }

        public virtual bool Confidencial { get; set; }

        public override bool EsValido()
        {
            _ultimoError = String.Empty;
            if (CreadoPor == null)
                _ultimoError = "No se ha asociado un usuario para esta nota";
            else if (String.IsNullOrEmpty(EntidadTipo))
                _ultimoError = "No se ha especificado el tipo de entidad a la que está asociada la nota";
            else if (String.IsNullOrEmpty(EntidadId))
                _ultimoError = "No se ha especificado el Id de la entidad a la que está asociada la nota";
            else if (Texto.Trim().Length == 0)
                _ultimoError = "Debe ingresar texto para la nota";

            return String.IsNullOrEmpty(_ultimoError);
        }
        public override string ToString()
        {
            return Texto;
        }

        public static Nota Crear(IPersistente entidad)
        {
            if (entidad == null || entidad.EsNuevo() || entidad.ObtenerID() == null)
                return null;
            Nota cNota = new Nota();
            cNota.EntidadTipo = entidad.ObtenerTipo();
            cNota.EntidadId = entidad.ObtenerID().ToString();
            cNota.CreadoPor = UsuarioLight.Crear(ConfigBL.ticket.Usuario);
            cNota.CreadoEl = ConfigBL.FechaYHoraActual;

            return cNota;
        }
        public static IList<Nota> ListarPorEntidad(IPersistente entidad)
        {
            //si la entidad es nueva (no existe en la base de datos, no tiene notas todavía
            if (entidad.EsNuevo())
                return new List<Nota>();
            return ListarPorEntidad(entidad.ObtenerTipo(), entidad.ObtenerID().ToString());
        }
        /*Solo valido para unidades just for time being*/
        public static IList<Nota> ListarPorEntidad(string entidadTipo, object entidadId)
        {
            //si la entidad es nueva (no existe en la base de datos, no tiene notas todavía
            if (entidadId == null)
                return new List<Nota>();
            using (DL dl = DL.ObtenerSesion())
            {
                IQueryable<Nota> query = dl.SessionLinq<Nota>().Where(n => n.EntidadTipo == entidadTipo && n.EntidadId == entidadId.ToString());
                if (!ConfigBL.ticket.VerificarPrivilegio(PRV.NOTA_VER_CONFIDENCIALES))
                    query = query.Where(n => n.Confidencial == false);

                return query.ToList();
            }
        }
    }
}