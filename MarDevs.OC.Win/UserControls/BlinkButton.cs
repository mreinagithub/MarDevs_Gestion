using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;

namespace MarDevs.OC.Win
{
	public class BlinkButton : UltraButton
	{
		private Timer _timer;
		private Color? ColorOriginal = null;
		private string Texto;

		public int Intervalo = 200;
		public Color colorAIntercalar = Color.Red;

		public BlinkButton()
		{
			this._timer = new Timer();
			this._timer.Tick += new EventHandler(_timer_Tick);
			this.TextChanged += BlinkButton_TextChanged;
		}
				
		public void StartBlink()
		{
			if(ColorOriginal == null)
				ColorOriginal = base.Appearance.ForeColor;
			base.Appearance.ForeColor = colorAIntercalar;
			this._timer.Interval = Intervalo;
			this._timer.Start();
		}
		public void StopBlink()
		{
			if (!_timer.Enabled)
				return;

			this._timer.Stop();
			base.Appearance.ForeColor = ColorOriginal != null ? ColorOriginal.Value : Color.Black;
			base.Text = Texto;
		}
		private void _timer_Tick(object sender, EventArgs e)
		{			
			base.Text = String.IsNullOrEmpty(base.Text) ? Texto : "";
		}
		private void BlinkButton_TextChanged(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(base.Text))
				Texto = base.Text;
		}

	}
}
