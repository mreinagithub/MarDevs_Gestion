using System;
using System.Collections.Generic;
using System.Text;

namespace MarDevs.OC.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=true)]
    public abstract class ValidadorBaseAttribute: Attribute
    {
        protected string _error;
        protected object _entidad;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        public object Entidad
        {
            get { return _entidad; }
            set { _entidad = value; }
        }

        public virtual bool EsValido(object valor)
        {
            return true;
        }

    }
}
