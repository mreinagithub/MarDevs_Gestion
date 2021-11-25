using System;
using System.ComponentModel;

namespace MarDevs.OC.Core
{
	/// <summary>
	/// Descripción breve de IFlagsSeguridad.
	/// </summary>
	public interface IFlagsSeguridad
	{
        int? Id { get; }

        //ModoBlanqueoPasswordEnum ModoBlanqueoPassword {get;set;}
        //string ValorPasswordFijo {get;set;}
		int PasswordLongitudMinima {get;set;}
		int PasswordLongitudMaxima {get;set;}
		int DiasVigenciaPassword {get;set;}

	}
}
