using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarDevs.Gestion.Core
{
    public class LongitudMaximaAttribute: ValidadorBaseAttribute
    {
        public LongitudMaximaAttribute(int maximo)
        {
            _longitudMaxima = maximo;
        }
        
        private int _longitudMaxima;
        public int LongitudMaxima
        {
            get { return _longitudMaxima; }
            set { _longitudMaxima = value; }
        }

        public override bool EsValido(object valor)
        {
            _error = String.Empty;
            string valor2 = valor as string;
            if (String.IsNullOrEmpty(valor2))
            {
                return true;
            }
            else
            {
                bool resultado = (valor2.Length <= _longitudMaxima);
                if (!resultado)
                {
                    _error = String.Format("La longitud máxima es de {0} caracteres", _longitudMaxima);
                }
                return resultado;
            }
        }
    }
}
