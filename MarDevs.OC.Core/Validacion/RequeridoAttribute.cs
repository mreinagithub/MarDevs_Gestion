using System;
using System.Collections.Generic;
using System.Text;

namespace MarDevs.OC.Core
{
    public class RequeridoAttribute: ValidadorBaseAttribute
    {
        public override bool EsValido(object valor)
        {
            _error = String.Empty;
            bool resultado = (valor is String) ? !String.IsNullOrEmpty(Convert.ToString(valor).Trim()) : (valor != null);
            if (!resultado)
            {
                _error = String.Format("El dato es obligatorio");
            }
            return resultado;
        }
    }
}
