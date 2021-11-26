using System;
using System.Windows.Forms;
using MarDevs.OC.Core;

namespace MarDevs.OC.Win
{
	public class Mensaje
	{
		public static DialogResult Pregunta(string pTextoMensaje)
		{
			return Pregunta( pTextoMensaje, MessageBoxButtons.YesNo );
		}
		public static DialogResult Pregunta(string pTextoMensaje, MessageBoxButtons pBotones)
		{
			return MessageBox.Show( pTextoMensaje, "Pregunta", pBotones, MessageBoxIcon.Question );
		}

		public static DialogResult Informacion(string pTextoMensaje)
		{
			return Informacion( pTextoMensaje, MessageBoxButtons.OK );
		}
		public static DialogResult Informacion(string pTextoMensaje, MessageBoxButtons pBotones)
		{
			return MessageBox.Show( pTextoMensaje, "Información", pBotones, MessageBoxIcon.Information );
		}

		public static DialogResult Advertencia(string pTextoMensaje)
		{
			return Advertencia( pTextoMensaje, MessageBoxButtons.OK );
		}
		public static DialogResult Advertencia(string pTextoMensaje, MessageBoxButtons pBotones)
		{
			return MessageBox.Show( pTextoMensaje, "Advertencia", pBotones, MessageBoxIcon.Warning );
		}

		public static DialogResult Error(string textoMensaje, Exception excepcion)
		{
			if( String.IsNullOrEmpty(textoMensaje))
			{	return DialogResult.None;	}

			ExcepcionBase ex = excepcion as ExcepcionBase;

			if( ex == null || (ex != null && ex.DebeConsiderarseError) )
			{
				// es una excepcion y debe publicarse
				AdministradorDeExcepciones.Publicar(excepcion);
			}
			if( excepcion == null )
			{
				return MessageBox.Show(textoMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				FormMensaje formMensaje = new FormMensaje(textoMensaje, excepcion.ToString());
				return formMensaje.ShowDialog();
			}
		}
		public static DialogResult ErrorAlGuardar(string pTextoMensaje, Exception excepcion)
		{
			string textoMensaje = String.Empty;

			textoMensaje += "Se produjo el siguiente error al intentar guardar los cambios:" + Environment.NewLine + Environment.NewLine;
			textoMensaje += pTextoMensaje + Environment.NewLine + Environment.NewLine;
			textoMensaje += "Los cambios no han sido guardados.";

			return Mensaje.Error( textoMensaje, excepcion );
		}

		public static DialogResult MostrarError(Exception ex)
		{
			if (ex is ExcepcionNegocios)
			{
				return Mensaje.Advertencia(ex.Message);
			}
			else
			{
				return Mensaje.Error(ex.Message, ex);
			}
		}
	}
}
