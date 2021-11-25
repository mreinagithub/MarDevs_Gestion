using System;
using System.Collections.Generic;

namespace MarDevs.OC.Core
{
    public interface IAuditable
    {
        UsuarioLight CreadoPor { get;set;}
        DateTime CreadoEl { get;set;}

        IList<Log> ObtenerLog();
    }
}
