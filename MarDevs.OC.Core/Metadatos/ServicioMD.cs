using System;
using System.Collections;
using System.Collections.Generic;
using MarDevs.OC.Core;
using System.Reflection;

namespace MarDevs.OC.Core
{
    public class ServicioMD
    {

		internal ServicioMD()
		{
		}

		private static ServicioMD _servicioMD;
		public static ServicioMD Instancia
		{
			get
			{
				if (_servicioMD == null)
				{
					_servicioMD = new ServicioMD();
				}
				return _servicioMD;
			}
		}

        private SortedList<string, Accion> _acciones = new SortedList<string, Accion>();
		private SortedList<string, Entidad> _entidades = new SortedList<string, Entidad>();

		public List<Accion> BuscarAccionPorEntidad(string entidad)
        {
            List<Accion> lista = new List<Accion>();
            Accion accion = null;
            foreach (KeyValuePair<string, Accion> de in _acciones)
            {
                accion = de.Value;
                if (accion.Entidad.Equals(entidad) )
                {
                    lista.Add(accion);
                }
            }
            return lista;
        }
        public Accion BuscarAccionPorKey(string key)
        {
            if (_acciones.ContainsKey(key))
            {
                return _acciones[key] as Accion;
            }
            return null;
		}
		public List<Accion> EvaluarAccionesEntidad(string tipoEntidad, IList lista)
		{
			//si no hay entidades, no se pueden ejecutar acciones
			//devolvemos una lista vacia de accioines permitidas
			if (lista == null || lista.Count == 0)
			{
				return new List<Accion>();

			}
			List<Accion> acciones = this.BuscarAccionPorEntidad(tipoEntidad);
			List<Accion> accionesRemover = new List<Accion>();
			foreach (object entidad in lista)
			{
				foreach (Accion accion in acciones)
				{
					if (accion.ValidaParaMultiplesInstancias == false && lista.Count > 1)
					{
						accionesRemover.Add(accion);
					}
					else if (EvaluarAccionEntidad(entidad, accion) == false)
					{
						accionesRemover.Add(accion);
					}
				}
				foreach (Accion accion in accionesRemover)
				{
					acciones.Remove(accion);
				}
				accionesRemover.Clear();
				if (acciones.Count == 0)
				{
					break;
				}
			}
			return acciones;
		}
		public IList<Accion> EvaluarAccionesEntidad(IList<Accion> acciones, IList lista)
		{
			//si no hay entidades, no se pueden ejecutar acciones
			//devolvemos una lista vacia de accioines permitidas
			if (lista == null || lista.Count == 0)
			{
				return new List<Accion>();

			}
			List<Accion> accionesPermitidas = new List<Accion>();
			foreach (Accion accion in acciones)
			{
				if (accion.ValidaParaMultiplesInstancias == false && lista.Count > 1)
				{
					continue;
				}
				bool agregar = true;
				foreach (object entidad in lista)
				{
					if (EvaluarAccionEntidad(entidad, accion) == false)
					{
						agregar = false;
						break;
					}
				}
				if (agregar)
				{
					accionesPermitidas.Add(accion);
				}
			}
			return accionesPermitidas;
		}

		public bool EvaluarAccionEntidad(object entidad, Accion accion)
		{
			IPersistente persistente = entidad as IPersistente;
			if (persistente != null && persistente.EsNuevo())
			{
				return false;
			}
			return (EvaluarPrivilegios(entidad, accion) &&
					 EvaluarCondiciones(entidad, accion.Condiciones, OperadorLogico.AND));
		}
		public bool EvaluarAccionEntidad2(object entidad, Accion accion)
		{
			IPersistente persistente = entidad as IPersistente;
			if (persistente != null && persistente.EsNuevo())
			{
				return false;
			}
			return (EvaluarPrivilegios(entidad, accion) &&
					 EvaluarCondiciones2(entidad, accion.Condiciones, OperadorLogico.AND));
		}
		private bool EvaluarPrivilegios(object entidad, Accion accion)
		{
			if (accion.PrivilegioRequerido == PRV.Ninguno)
			{
				return true;
			}
			Usuario usuario = ConfigBL.ticket.Usuario;
			Alcances alcance = usuario.ObtenerAlcancePrivilegio(accion.PrivilegioRequerido);
			//EVALUACION DE PRIVILEGIO, SI ES DENEGADO, ALPISTE
			if (alcance == Alcances.Denegado)
			{
				return false;
			}
			Privilegio prv = Privilegio.BuscarPorId(accion.PrivilegioRequerido);
			if (prv == null)
			{
				throw new Exception(String.Format("No existe el privilegio {0}", accion.PrivilegioRequerido));
			}
			return true; //No existe soporte de alcances.
				
			
			////OBTENER USUARIO A COMPARAR DE LA ENTIDAD, YA QUE EL PRIVILEGIO ES CON SOPORTE A ALCANCES
			//UsuarioLight usuComparar = null;
			//if (entidad is IAsignable)
			//{
			//	IAsignable asignagle = entidad as IAsignable;
			//	usuComparar = UsuarioLight.Crear(asignagle.Responsable);
			//}
			//else
			//{
			//	//la propiedad a leer debe necesariamente salir de AttrUsuario de la accion.
			//	if (String.IsNullOrEmpty(accion.AttrUsuario))
			//	{
			//		throw new Exception(String.Format("Accion {0}: no se ha definido una propiedad tipo UsuarioLight para comparar alcances de privilegios.", accion.Key));
			//	}
			//	PropertyInfo propiedad = entidad.GetType().GetProperty(accion.AttrUsuario);
			//	if (propiedad == null)
			//	{
			//		throw new Exception(String.Format("La propiedad {0} no existe en la entidad.", accion.AttrUsuario));
			//	}
			//	//leer la propiedad y convertirla a UsuarioLight si no lo es.
			//	object valorPropiedad = propiedad.GetValue(entidad, null);
			//	if (valorPropiedad == null)
			//	{
			//		return true; //se supone que la entidad todavia no tiene responsable, por lo tanto es suficiente con tener el privilegio.
			//	}
			//	if (valorPropiedad is Usuario)
			//	{
			//		usuComparar = UsuarioLight.Crear(valorPropiedad as Usuario);
			//	}
			//	else if (valorPropiedad is UsuarioLight)
			//	{
			//		usuComparar = valorPropiedad as UsuarioLight;
			//	}
			//	else
			//	{
			//		throw new Exception(String.Format("La propiedad {0} no es del tipo Usuario ni UsuarioLight.", accion.AttrUsuario));
			//	}

            //}
            //EVALUAR EL ALCANCE DEL USUARIO LOGUEADO SOBRE usuComparar
			//switch (alcance)
			//{                
			//	case Alcances.Total:
			//		return true;
			//}
			//return false;


		}
		private bool EvaluarCondiciones(object entidad, List<CondicionAccion> condiciones, OperadorLogico operador)
		{
			bool resultado = (operador == OperadorLogico.OR) ? false : true;
			bool comparacionOk;

			foreach (CondicionAccion cond in condiciones)
			{
				//leer el valor de la property de la entidad via reflexion

				object valor = Util.LeerProperty(entidad, cond.Propiedad);

				comparacionOk = EvaluarValor(valor, cond.Operador, cond.Valores[0]);
				//evaluar resultado
				if (operador == OperadorLogico.AND && !comparacionOk)
				{
					return false;
				}
				else if (operador == OperadorLogico.OR && comparacionOk)
				{
					return true;
				}
			}
			return resultado;


		}
		private bool EvaluarCondiciones2(object entidad, List<CondicionAccion> condiciones, OperadorLogico operador)
		{
			bool resultado = (operador == OperadorLogico.OR) ? false : true;
			bool comparacionOk;

			foreach (CondicionAccion cond in condiciones)
			{
				//leer el valor de la property de la entidad via reflexion
				object valor = Util.LeerProperty(entidad, cond.Propiedad);
				Type tipo = Util.TipoProperty(entidad, cond.Propiedad);
				object valorAComparar = Util.ConvertirValor(tipo, cond.Valor);

				comparacionOk = EvaluarValor(valor, cond.Operador, valorAComparar);
				//evaluar resultado
				if (operador == OperadorLogico.AND && !comparacionOk)
				{
					return false;
				}
				else if (operador == OperadorLogico.OR && comparacionOk)
				{
					return true;
				}
			}
			return resultado;


		}
		private bool EvaluarValor(object valor, OperadorAccion operador, object valorAComparar)
		{
			if (valorAComparar is String && valorAComparar.ToString()== "null") { valorAComparar = null; }
			switch (operador)
			{
				case OperadorAccion.Igual:
					if (valor == null)
					{
						return (valorAComparar == null);
					}
					else
					{
						return valor.Equals(valorAComparar);
					}
				case OperadorAccion.Distinto:
					if (valor == null)
					{
						return (valorAComparar != null);
					}
					else
					{
						return !valor.Equals(valorAComparar);
					}
                case OperadorAccion.MayorIgual:
                    if (valor == null) return false;

                    if (valor is IComparable && valorAComparar is IComparable)
                    {
                        return ((IComparable)valor).CompareTo(valorAComparar) >= 0;
                    }
                    else 
                    {
                        throw new ExcepcionTecnica("No son elementos comparables");
                    }
				default:
					throw new NotSupportedException(String.Format("Operador {0} no soportado, todavia!", operador));
			}
		}
		public void RegistrarAcciones(SortedList<string, Accion> acciones)
		{
			_acciones = acciones;
		}
	}
}
