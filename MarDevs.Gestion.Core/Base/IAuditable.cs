using System;
using System.Collections.Generic;

namespace MarDevs.Gestion.Core
{
    public interface IAuditable
    {
        UsuarioLight CreadoPor { get;set;}
        DateTime CreadoEl { get;set;}

        IList<Log> ObtenerLog();
    }
}
