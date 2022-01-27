using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarDevs.Gestion.Core
{
    public class ValidarRegexAttribute: ValidadorBaseAttribute
    {
        public ValidarRegexAttribute(string patron)
        {
            _patron = patron;
        }

        private string _patron;
        public string Patron
        {
            get { return _patron; }
            set { _patron = value; }
        }

        public override bool EsValido(object valor)
        {
            string valor2 = valor as string;
            if (!String.IsNullOrEmpty(valor2))
            {
                _error = "Formato inválido.";
                return Regex.IsMatch(Convert.ToString(valor), _patron);
            }
            else
            {
                _error = String.Empty;
                return true;
            }
        }
    }
}
