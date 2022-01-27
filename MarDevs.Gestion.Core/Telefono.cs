using System;
using System.Text.RegularExpressions;
using System.Collections;

using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Core
{
    [Serializable]
    public class Telefono : NegocioBase
    {
        private static string m_TextoAyudaFormato = "Un teléfono válido tiene el siguiente formato:"
            + Environment.NewLine
            + Environment.NewLine
            + "Código de Area (opcional): entre dos y seis dígitos encerrados entre paréntesis. Ej: (011)"
            + Environment.NewLine
            + Environment.NewLine
            + "Número telefónico: (obligatorio): entre dos y cuatro dígitos para la característica"
            + " y exactamente cuatro dígitos para el número, separados (opcionalmente) por un guión. Ej: 4331-0318"
            + Environment.NewLine
            + Environment.NewLine
            + "Si el teléfono es un celular, debe anteponer el 15 al número telefónico y "
            + "separarlo con un guión. Ej: 15-5682-0358"
            + Environment.NewLine
            + Environment.NewLine
            + "Puede cargar teléfonos múltiples o consecutivos utilizando una barra como separador (no válido para celulares). Ej: 4331-8000/02";

        public static string TextoAyudaFormato
        {
            get { return m_TextoAyudaFormato; }
        }
        private static ArrayList _TiposTelefonoFisica = new ArrayList(new object[] { "Particular", "Celular", "Laboral", "Fax", "Otro" });
        public static ArrayList TiposTelefonoFisica()
        {
            return _TiposTelefonoFisica;
        }
        private static ArrayList _TiposTelefonoJuridica = new ArrayList(new object[] { "Principal", "Alternativo", "Fax", "Otro" });
        public static ArrayList TiposTelefonoJuridica()
        {
            return _TiposTelefonoJuridica;
        }

        public Telefono(string tipo, string numero)
        {
            this.Tipo = tipo;
            this.Numero = numero;
        }
        protected Telefono() : this(String.Empty, String.Empty)
        { }
        
        public virtual string Tipo { get; set; }
        public virtual string Numero { get; set; }

        public override string ToString()
        {
            return Numero;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Telefono)) { return false; }
            return (Numero.Equals((obj as Telefono).Numero));
        }
        public override int GetHashCode()
        {
            return Numero.GetHashCode();
        }
        public override bool EsValido()
        {
            //se dan por validos los telefonos vacios
            if (Numero.Length == 0)
            { _ultimoError = String.Empty; return true; }

            string patronTelNormal = @"^(\(\d{2,6}\))?\s?\d{2,4}(-\d{4}|\d{4})(/\d{1,4})*(\s|$)";
            string patronTelCelular = @"^(\(\d{2,6}\))?\s?15-\d{2,4}(-\d{4}|\d{4})(\s|$)";
            if (!Regex.IsMatch(Numero, patronTelNormal) && !Regex.IsMatch(Numero, patronTelCelular))
            {
                _ultimoError = "El teléfono ingresado no es válido. " + Telefono.TextoAyudaFormato;
                return false;
            }
            _ultimoError = String.Empty;
            return true;

        }

    }

}
