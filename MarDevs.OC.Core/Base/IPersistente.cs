
namespace MarDevs.OC.Core
{
	public interface IPersistente
	{
		object Yo { get;}

		void Guardar();
		void Eliminar();
		void Actualizar(bool forzarInicializacionColecciones);

		void CapturarSnapshot();
		bool HayCambios();
		void DeshacerCambios();

		bool EsValido();
		string UltimoError();
        object ObtenerID();
		bool EsNuevo();
		
		string ObtenerTipo();
		void ResetearId();
		bool IdAutogenerado();
	}

	public interface IPersistente<TIPOID> : IPersistente
	{
		TIPOID Id { get;}
	}
}

