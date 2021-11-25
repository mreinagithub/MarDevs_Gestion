using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarDevs.OC.Core
{
    public class ValidarRangoAttribute: ValidadorBaseAttribute
    {
        public ValidarRangoAttribute(int minimo, int maximo)
        {
            _minimo = minimo;
            _maximo = maximo;
        }
        
        private int _minimo;
        private int _maximo;

        public int Minimo
        {
            get { return _minimo; }
            set { _minimo = value; }
        }
        public int Maximo
        {
            get { return _maximo; }
            set { _maximo = value; }
        }

        public override bool EsValido(object valor)
        {
            double numero = Convert.ToDouble(valor);
            bool resultado = (numero >= _minimo && numero <= _maximo);
            if (!resultado)
            {
                _error = String.Format("El valor debe estar entre {0} y {1}", _minimo, _maximo);
            }
            return resultado;
        }
    }
}
