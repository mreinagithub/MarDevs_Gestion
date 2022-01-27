
namespace MarDevs.Gestion.Core
{
    //public enum ModoBlanqueoPasswordEnum
    //{
    //    Logon = 1,
    //    PasswordFijo = 2,
    //    Random = 3
    //}

	public enum Alcances :int
	{
		[EnumDescriptor("Denegado","ImagenPrivilegioDenegado")]
		Denegado				= 0,
		

		[EnumDescriptor("Permitido","ImagenPrivilegioConcedido")]
		Total					= 8
	}

	/// <summary>
	/// Enumeración que se utiliza para determinar el tipo de cambio al comparar dos objetos
	/// </summary>
	public enum TipoCambio
	{
		Property = 1,
		ElementoAgregado = 2,
		ElementoEliminado = 3,
	}
	public enum TipoPrincipalSeguridad
	{
		Usuario = 1,
		Rol = 2
	}
    public enum BusquedaTipo
    {
        [EnumDescriptor("Comienza por", "")]
        ComienzaPor = 1,
        [EnumDescriptor("Contiene", "")]
        Contiene = 2,
        [EnumDescriptor("Termina en", "")]
        TerminaEn = 3,
        [EnumDescriptor("Coincide con", "")]
        Coincide = 4
    }

	public enum TipoEntidad
    {
        [EnumDescriptor("Usuario", "")]
        Usuario = 1000,
        [EnumDescriptor("Rol", "")]
        Rol = 1001
        
    }

	public enum Cargo
	{ 
		[EnumDescriptor("Cliente")]
		Cliente = 1,
		[EnumDescriptor("Garantía")]
		Garantia = 2,
		[EnumDescriptor("Interno")]
		Interno = 3,
		[EnumDescriptor("Stock")]
		Stock = 4

	}
	public enum EstadoPedido
	{
		[EnumDescriptor("Pendiente", "ImagenCarpetaBusqueda")]
		Pendiente = 1,
		[EnumDescriptor("Autorizado", "ImagenPrivilegioConcedido")]
		Autorizado = 2,
		[EnumDescriptor("Rechazado", "ImagenPedidoRechazado")]
		Rechazado = 3,
		[EnumDescriptor("Con pedido", "ImagenPedidoPedido")]
		Pedido = 4,
		[EnumDescriptor("Aut.Parcial", "ImagenBorrador")]
		AutorizacionParcial = 5,
		[EnumDescriptor("Anulado", "ImagenPrivilegioDenegado")]
		Anulado = 9
	}

	public enum ModalidadPedido
	{
		Fabrica, OrdenCompra
	}
	
}
