using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace MarDevs.Gestion.Core
{
	[Serializable]
	public class Formulario : Persistente<int?>
	{
        public Formulario()
        {
            Copias = 0;
            Descripcion = String.Empty;
            Contenido = null;
            Tipo = TipoFormulario.DetalleFactura;
            FechaModificacion = ConfigBL.FechaYHoraActual;
        }
		private static Dictionary<TipoFormulario,Formulario> _formularios = new Dictionary<TipoFormulario,Formulario>();

		#region PROPIEDADES

        [GridDescriptor("Tipo", Width = 300)]
        public virtual TipoFormulario Tipo { get; set; }

        public virtual string Descripcion { get; set; }
		
		[Browsable(false)]
        public virtual byte[] Contenido { get; set; }

		[GridDescriptor("Copias", Width= 200)]
        public virtual int Copias { get; set; }

		[GridDescriptor("Fecha de Modificación", Format= "dd/MM/yyyy HH:mm:ss")]
        public virtual DateTime FechaModificacion { get; set; }

		#endregion

		#region MÉTODOS ESTÁTICOS
		
		public static IList<Formulario> Listar()
		{
			using (DL dl = DL.ObtenerSesion())
			{
                return dl.Listar<Formulario>();
			}
		}
		public static Formulario Leer(int formularioID)
		{
			using (DL dl = DL.ObtenerSesion())
			{
                return dl.Leer<Formulario>(formularioID);
			}
		}
		public static Formulario Obtener(TipoFormulario tipo)
		{			
			DateTime fechaReferencia = new DateTime(1900, 1, 1);
			if (_formularios.ContainsKey(tipo))
				fechaReferencia = _formularios[tipo].FechaModificacion;
			using (DL dl = DL.ObtenerSesion())
			{
				string hql = string.Format("FROM Formulario f WHERE f.Tipo = {0} AND f.FechaModificacion > '{1:yyyyMMdd HH:mm:ss}'", Convert.ToInt32(tipo), fechaReferencia); 
				Formulario formulario = dl.BuscarUniqueResult<Formulario>(hql);
				if (formulario != null)
				{
					if (_formularios.ContainsKey(tipo))
						_formularios.Remove(tipo);
                    _formularios.Add(formulario.Tipo, formulario);
				}
				else if (!_formularios.ContainsKey(tipo))
					throw new Exception(String.Format("No existe formulario asociado para el tipo de formulario {0}", tipo));
			}			
			if (_formularios[tipo].Contenido == null)
				throw new Exception(String.Format("El tipo de formulario {0} no tiene contenido asociado para generar la impresión.", tipo));
			return _formularios[tipo];
		}

		#endregion
	}

	public enum TipoFormulario
	{
        [EnumDescriptor("Detalle Factura")] DetalleFactura = 1
	}

}
