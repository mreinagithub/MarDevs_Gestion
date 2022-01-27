using System;
using System.Collections.Generic;
using System.Text;

namespace MarDevs.Gestion.Core
{
    public class Cambio
    {
        private TipoCambio _tipo;
        private string _nombreProperty = String.Empty;
        private object _valorAnterior = String.Empty;
        private object _valorNuevo = String.Empty;

        public TipoCambio Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public string NombreProperty
        {
            get { return _nombreProperty; }
            set { _nombreProperty = value; }
        }
        public object ValorAnterior
        {
            get { return _valorAnterior; }
            set { _valorAnterior = value; }
        }
        public object ValorNuevo
        {
            get { return _valorNuevo; }
            set { _valorNuevo = value; }
        }

    }
}
