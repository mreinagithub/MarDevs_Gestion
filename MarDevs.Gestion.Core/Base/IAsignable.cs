using System;
using System.Collections.Generic;
using System.Text;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Core
{
	public interface IAsignable
	{
		Usuario Responsable { get; set; }	
	}
}
