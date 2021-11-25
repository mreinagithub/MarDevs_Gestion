using System;
using System.Drawing;
using System.Data;
using System.Xml.Serialization;

namespace MarDevs.OC.Core
{
	[Serializable]
	public class VistaPersonalizadaFormatoColumna : NegocioBase
	{
		#region PROPIEDADES

        [GridDescriptor("Columna", Width = 175)]
        public virtual string Columna { get; set; }

		[GridDescriptor("Título",Width = 175)]
        public virtual string Titulo { get; set; }

		[GridDescriptor("Formato",Width=100)]
        public virtual string Formato { get; set; }

		[GridDescriptor("Value\nList/Enum", Width = 100)]
        public virtual string ValueList { get; set; }

		[GridDescriptor("Color\nFondo", Width = 120)]
        public virtual int BackColor { get; set; }

		[GridDescriptor("Color\nFuente", Width = 120)]
        public virtual int ForeColor { get; set; }

		[GridDescriptor("Bold")]
        public virtual bool Bold { get; set; }

		[GridDescriptor("Ancho")]
        public virtual int Ancho { get; set; }

		[GridDescriptor("Visible")]
        public virtual bool Visible { get; set; }

        [GridDescriptor("Excluir del\nSelector")]
        public virtual bool ExcluirDelSelector { get; set; }

		[NoVisibleEnGrilla]
		[XmlIgnore]
        public virtual VistaPersonalizada VistaPersonalizada { get; set; }

		#endregion

		public static VistaPersonalizadaFormatoColumna Crear(DataColumn col)
		{
			VistaPersonalizadaFormatoColumna vpfcNuevo = Crear();
			if (col.ColumnName.ToUpper() == "ID" || col.ColumnName.ToUpper() == "CATEGORIAID" || col.ColumnName.ToUpper() == "COLORFILA" || col.ColumnName.ToUpper() == "COLORTEXTO" || col.ColumnName.ToUpper() == "TOOLTIP")
			{
				vpfcNuevo.ExcluirDelSelector = true;
				vpfcNuevo.Visible = false;
			}
			else
			{
				vpfcNuevo.ExcluirDelSelector = false;
				vpfcNuevo.Visible = true;
			}

			vpfcNuevo.Columna = col.ColumnName;
			vpfcNuevo.Titulo = col.ColumnName;
			if (col.DataType == typeof(Decimal)
				|| col.DataType == typeof(Int32)
				|| col.DataType == typeof(Double))
			{
				vpfcNuevo.Formato = "#,#";
			}
			else if (col.DataType == typeof(DateTime))
			{
				vpfcNuevo.Formato = "dd/MM/yyyy";
			}
			return vpfcNuevo;
		}
		public static VistaPersonalizadaFormatoColumna Crear()
		{
			return new VistaPersonalizadaFormatoColumna
			{
				Bold = false,
				Visible = true,
				ExcluirDelSelector = false,
				Formato = string.Empty,
				Ancho = 100,
				BackColor = Color.Transparent.ToArgb(),
				ForeColor = Color.Black.ToArgb()
			};
		}
		public static VistaPersonalizadaFormatoColumna Clonar(VistaPersonalizadaFormatoColumna formatoAClonar)
		{
			VistaPersonalizadaFormatoColumna vpfc = VistaPersonalizadaFormatoColumna.Crear();
			vpfc.Columna = formatoAClonar.Columna;
			vpfc.Titulo = formatoAClonar.Titulo;
			vpfc.Formato = formatoAClonar.Formato;
			vpfc.ValueList = formatoAClonar.ValueList;
			vpfc.BackColor = formatoAClonar.BackColor;
			vpfc.ForeColor = formatoAClonar.ForeColor;
			vpfc.Bold = formatoAClonar.Bold;
			vpfc.Ancho = formatoAClonar.Ancho;
			vpfc.Visible = formatoAClonar.Visible;
			vpfc.ExcluirDelSelector = formatoAClonar.ExcluirDelSelector;
			return vpfc;
		}

		public override bool Equals(object obj)
		{
			VistaPersonalizadaFormatoColumna otro = (obj as VistaPersonalizadaFormatoColumna);

			if (otro == null) { return false; }
			if (this == otro) { return true; }			
			return (this.Columna == otro.Columna);
		}

	}
}
