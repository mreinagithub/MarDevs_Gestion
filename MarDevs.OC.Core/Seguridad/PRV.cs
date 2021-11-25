
namespace MarDevs.OC.Core
{
    public class PRV
    {
		public const int Ninguno = 0;

        #region Sistema

        public const int FLAGS_VER = 1;
        public const int CONFIGURACION_DB_VER = 2;
        
        #endregion

        #region Administración

        public const int ADMINISTRAR_USUARIO			= 1000;
        public const int ADMINISTRAR_ROL				= 1001;        
        public const int ADMINISTRAR_VISTAS_PERSONALIZADAS = 1004;
        public const int ADMINISTRAR_VISTAS_PERSONALIZADAS_LIMITADA = 1005;        
        public const int ADMINISTRAR_FORMULARIOS        = 1013;

		public const int ADMINISTRAR_DEPOSITOS = 1014;
		public const int ADMINISTRAR_TIPOS_PEDIDO = 1015;

        #endregion      

        #region Notas

        public const int NOTA_VER_CONFIDENCIALES        = 1100;
		public const int NOTA_MARCAR_CONFIDENCIALES     = 1101;

        #endregion

		#region PEDIDOS DE REPUESTOS

		public const int PEDIDO_REPUESTO_CREAR_MODIFICAR = 1200;
		public const int PEDIDO_REPUESTO_AUTORIZACION = 1201;
		public const int PEDIDO_REPUESTO_CARGAR_PEDIDO_FABRICA = 1202;
		public const int PEDIDO_REPUESTO_MODIFICAR_AUTORIZADOS = 1203;
		public const int PEDIDO_REPUESTO_LIBERAR_PEDIDO_TOMADO = 1204;
        public const int PEDIDO_REPUESTO_GENERAR_ARCHIVO_FABRICA = 1205;

		#endregion

	}
}

