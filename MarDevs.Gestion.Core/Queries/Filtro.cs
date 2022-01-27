using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Core
{
    [Serializable]
	public class Filtro
    {
		public Filtro()
		{
		}
        
		private List<Condicion> _condiciones = new List<Condicion>();
        private OperadorLogico _operadorLogico=OperadorLogico.AND;
        private List<Filtro> _filtros = new List<Filtro>();

		[XmlAttribute]
		public OperadorLogico OperadorLogico
		{
			get { return _operadorLogico; }
			set { _operadorLogico = value; }
		}
		[XmlElement("Condiciones", Type = typeof(Condicion), ElementName = "Condicion")]
		public List<Condicion> Condiciones
        {
            get { return _condiciones; }
        }
		[XmlElement(Type = typeof(Filtro), ElementName = "Filtro")]
		public List<Filtro> Filtros
        {
            get { return _filtros; }
            set { _filtros = value; }
        }

        public void AgregarCondicionSimple(string propiedad, Operador operador, object valor)
        {
			if (valor == null && operador == Operador.Igual)
			{
				operador = Operador.EsNulo;
				valor = 1;
			}
			else if (valor == null && operador == Operador.Distinto)
			{
				operador = Operador.NoEsNulo;
				valor = 1;
			}
			else if (valor == null)
			{
				throw new Exception("El valor del operando de una condición no puede ser null. Para comparaciones con null utilizar los operadores EsNulo y NoEsNulo.");
			}
			AgregarCondicionSimple(propiedad, operador, new object[1]{valor});
        }
        public Condicion BuscarPropiedad(String propiedad)
        {
          foreach (Condicion condicion in _condiciones)
          {
              if (condicion.Propiedad == propiedad)
              {
                  return condicion;
              }
          }
            return null;
        }
		public void AgregarCondicionSimple(string propiedad, Operador operador, object[] valores)
		{
			if (valores == null)
			{
				throw new Exception("La colección de valores de una condición no puede ser null.");
			}
			Condicion cond = new Condicion();
			cond.Propiedad = propiedad;
			cond.Operador = operador;
			cond.Valores = valores;
			this.Condiciones.Add(cond);
		}
        
		public bool EsFiltroVacio()
		{
			return (_condiciones.Count + _filtros.Count) == 0;
		}
	}
}
