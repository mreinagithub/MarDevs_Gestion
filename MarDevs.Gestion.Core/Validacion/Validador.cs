using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MarDevs.Gestion.Core
{
    public static class Validador
    {
        private static string _errores;

        public static string Errores
        {
            get { return _errores; }
        }


        public static bool EsValido(NegocioBase entidad)
        {
            _errores = String.Empty;
            foreach (PropertyInfo property in entidad.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                ValidarPropiedad(entidad, property);
            }
            return _errores.Length == 0;
        }
        public static bool EsValido(NegocioBase entidad, string propiedad)
        {
            _errores = String.Empty;
            PropertyInfo property = entidad.GetType().GetProperty(propiedad);
            if (property != null)
            {
                ValidarPropiedad(entidad, property);
            }
            return _errores.Length == 0;
        }

        private static void ValidarPropiedad(NegocioBase entidad, PropertyInfo property)
        {
            object[] attrArray = property.GetCustomAttributes(typeof(ValidadorBaseAttribute), true);
            foreach (ValidadorBaseAttribute validator in attrArray)
            {
                validator.Entidad = entidad;
                if (!validator.EsValido(property.GetValue(entidad, null)))
                {
                    _errores += String.Format("{0} - {1}\r\n", property.Name, validator.Error);
                }
            }
        }
        
    }
}
