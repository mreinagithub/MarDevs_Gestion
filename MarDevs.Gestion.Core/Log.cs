using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MarDevs.Gestion.Core
{
    [Serializable]
    public class Log : Persistente<int?>
    {
        protected Log()
        {
            Fecha = DateTime.Now;
            Usuario = null;
            Detalle = String.Empty;
        }
        public virtual DateTime Fecha { get; set; }
        public virtual UsuarioLight Usuario { get; set; }
        [Browsable(false)]
        public virtual string EntidadTipo { get; set; }
        [Browsable(false)]
        public virtual string EntidadId { get; set; }
        public virtual string Detalle { get; set; }

        public static Log Crear(IPersistente entidad, string mensaje)
        {
            if (entidad == null || entidad.EsNuevo() || entidad.ObtenerID() == null)
                return null;
            return Crear(entidad.ObtenerTipo(), entidad.ObtenerID().ToString(), mensaje);
        }
        public static Log Crear(string entidadTipo, string entidadId, string mensaje)
        {
            Log li = new Log();
            li.EntidadId = entidadId;
            li.EntidadTipo = entidadTipo;
            li.Usuario = UsuarioLight.Crear(ConfigBL.ticket.Usuario);
            li.Fecha = ConfigBL.FechaYHoraActual;
            li.Detalle = mensaje;

            return li;
        }

        public static IList<Log> Listar(IPersistente entidad)
        {
            using (DL dl = DL.ObtenerSesion())
            {
                return dl.SessionLinq<Log>()
                        .Where(log => log.EntidadTipo == entidad.ObtenerTipo() && log.EntidadId == Convert.ToString(entidad.ObtenerID()))
                        .ToList<Log>(); 
            }
        }
        public static string MensajeCambioStandard(string propiedad, object valorAnterior, object valorNuevo)
        {
            string stringValorAnterior = FormatearValor(valorAnterior);
            string stringValorNuevo = FormatearValor(valorNuevo);

            return String.Format("Campo {0} cambiado de '{1}' a '{2}'",
                propiedad,
                stringValorAnterior,
                stringValorNuevo);
        }
        public static string FormatearValor(object valor)
        {
            if (valor == null)
                return String.Empty;

            switch (valor.GetType().Name.ToUpper())
            {
                case "DATETIME":
                    return FormatearValor((DateTime)valor);
                case "DECIMAL":
                    return FormatearValor((Decimal)valor);
                case "BOOLEAN":
                    return FormatearValor((Boolean)valor);
                default:
                    return valor.ToString();
            }
        }
        public static string FormatearValor(DateTime valor)
        {
            DateTime valorDateTime = (DateTime)valor;
            if (valorDateTime == DateTime.MinValue)
                return String.Empty;
            else if (valorDateTime.Hour == 0 && valorDateTime.Minute == 0)
                return valorDateTime.Date.ToString("dd/MM/yyyy");
            return valorDateTime.ToString("dd/MM/yyyy HH:mm");
        }
        public static string FormatearValor(Decimal valor)
        {
            Decimal valorDecimal = (Decimal)valor;
            return valorDecimal.ToString("###,###,###,###.##");
        }
        public static string FormatearValor(Boolean valor)
        {
            return (valor == true) ? "SI" : "NO";
        }
    }
}
