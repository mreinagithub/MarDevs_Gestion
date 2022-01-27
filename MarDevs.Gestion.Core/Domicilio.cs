using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Core
{
    [Serializable]
    public class Domicilio : NegocioBase
    {
        public Domicilio()
        {
        }
        private static IList<String> _listaProvincias = null;

        #region MIEMBROS PRIVADOS

        private string m_Linea1 = String.Empty;
        private string m_Linea2 = String.Empty;
        private string m_Ciudad = String.Empty;
        private string m_CodigoPostal = String.Empty;
        private int m_ProvinciaId;
        private int m_PaisId;

        #endregion

        #region PROPIEDADES

        public virtual string Linea1
        {
            get { return m_Linea1; }
            set { m_Linea1 = value.Trim().ToUpper(); }
        }
        public virtual string Linea2
        {
            get { return m_Linea2; }
            set { m_Linea2 = value.Trim().ToUpper(); }
        }
        public virtual string Ciudad
        {
            get { return m_Ciudad; }
            set { m_Ciudad = value.Trim().ToUpper(); }
        }
        public virtual string CodigoPostal
        {
            get { return m_CodigoPostal; }
            set { m_CodigoPostal = value.Trim().ToUpper(); }
        }
        public virtual int ProvinciaId
        {
            get { return m_ProvinciaId; }
            set
            {
                m_ProvinciaId = value;
                if (m_ProvinciaId != 0) { m_PaisId = 1; } //Provincia Argentina, pais Argentina

            }
        }
        public virtual int PaisId
        {
            get { return m_PaisId; }
            set { m_PaisId = value; }
        }

        #endregion

        public override string ToString()
        {
            return m_Linea1.Trim() + " " + m_Ciudad.Trim();
        }
        public override bool EsValido()
        {
            //si esta todo vacio, es un domicilio valido (vacio!)
            if (m_Linea1.Trim().Length == 0
                 && m_Linea2.Trim().Length == 0
                 && m_Ciudad.Trim().Length == 0
                 && m_CodigoPostal.Trim().Length == 0
                 && m_ProvinciaId == 0
                 && m_PaisId == 0)
            {
                _ultimoError = String.Empty;
                return true;
            }
            if (m_Linea1.Trim().Length == 0)
            { _ultimoError = "El domicilio ingresado no es válido"; return false; };
            if (m_Ciudad.Trim().Length == 0)
            { _ultimoError = "La ciudad ingresada no es válida"; return false; };
            if (m_PaisId == 0)
            { _ultimoError = "Debe ingresar el país"; return false; };
            if (m_PaisId == 1)//Argentina
            {
                //validar codigo postal
                string patronCodPos = @"^(\b[1-9]\d{3}\b)|(\b[A-Z][1-9]\d{3}[A-Z]{3}\b)$";
                if (m_CodigoPostal.Length > 0 && !Regex.IsMatch(m_CodigoPostal, patronCodPos))
                {
                    _ultimoError = "El código postal no tiene un formato válido para Argentina."
                                    + Environment.NewLine
                                    + "Puede ingresar los viejos códigos postales, por ejemplo 1024 o los nuevos, como C1024ADA";
                    return false;
                };
                if (m_ProvinciaId == 0)
                {
                    _ultimoError = "Debe ingresar una provincia";
                    return false;
                }
            }
            _ultimoError = String.Empty;
            return true;

        }
        public static IList<String> ListaProvincias()
        {
            if (_listaProvincias == null)
            {
                using (DL dl = DL.ObtenerSesion())
                {
                    _listaProvincias = dl.Listar<String>("SELECT ProvinciaDesc FROM Provincia WHERE ProvinciaId > 0");
                }
            }
            return _listaProvincias;
        }
    }

}
