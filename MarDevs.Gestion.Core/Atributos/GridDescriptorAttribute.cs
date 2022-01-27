using System;

namespace MarDevs.Gestion.Core
{
	/// <summary>
	/// Descripción breve de FieldDescriptorAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class GridDescriptorAttribute : System.Attribute
	{
		public GridDescriptorAttribute()
		{
			Label = string.Empty;
			BackColor = String.Empty;
			VisiblePorDefault = true;
			//ValueList = string.Empty;
			Width = 0;
		}
		public GridDescriptorAttribute(string label) 
		{
			Label = label;
			BackColor = String.Empty;
			VisiblePorDefault = true;
			//ValueList = string.Empty;
			Width = 0;
		}

		public string BackColor { get; set; }
		public string Label { get; set; }
		public bool Bold { get; set; }
		public string Format { get; set; }
		public int Width { get; set; }
		//public string ValueList { get; set; }
		public bool VisiblePorDefault { get; set; }
	}
}
