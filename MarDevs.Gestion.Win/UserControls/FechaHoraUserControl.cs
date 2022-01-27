using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MarDevs.Gestion.Win
{
    [System.ComponentModel.DefaultBindingProperty("Value")]
    public partial class FechaHoraUserControl : UserControl
    {
        public FechaHoraUserControl()
        {
            InitializeComponent();

            if (DesignMode)
            {
                return;
            }
            CargarComboHora();
            dtFecha.ValueChanged += new EventHandler(dtFecha_ValueChanged);
            comboHora.KeyPress += new KeyPressEventHandler(comboHora_KeyPress);
            comboHora.Leave += new EventHandler(comboHora_Leave);
        }

        void comboHora_Leave(object sender, EventArgs e)
        {
            if (this.comboHora.Text != null && this.comboHora.Text.Length == 4 && !this.comboHora.Text.Contains(":"))
            {
                this.comboHora.Text = this.comboHora.Text.Insert(2, ":");
            }
        }

        void comboHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar.Equals(Char.Parse(":")) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        void dtFecha_ValueChanged(object sender, EventArgs e)
        {
			if (dtFecha.Value == null)
			{
				_value = null;
				comboHora.Value = null;
				comboHora.Enabled = false;
			}
			else
			{
				_value = dtFecha.DateTime.Date;
				comboHora.Enabled = true;
			}
        }

        private DateTime? _value;
        private int _intervaloComboHora = 30;

        public DateTime? Value
        {
            get
            {
				if (dtFecha.Value == null)
				{
					return null;
				}
				else
				{
					DateTime hora = DateTime.MinValue;
					DateTime fecha = dtFecha.DateTime.Date;

					if (comboHora.Value != null)
					{
						bool result = DateTime.TryParse(comboHora.Text, out hora);
					}
					_value = (DateTime?)new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, 0);
					return _value;
				}
            }
            set
            {
                _value = value;
				dtFecha.Value = value;
				if (value != null)
				{
					comboHora.Value = FormatearStringHora(new DateTime(1, 1, 1, value.Value.Hour, value.Value.Minute, 0));
				}
				else
				{
					comboHora.Value = null;
					comboHora.Enabled = false;
				}
                base.OnValidated(EventArgs.Empty);
            }
        }
        public int IntervaloComboHora
        {
            get { return _intervaloComboHora; }
            set
            {
                if (value <= 0 || value >120)
                {
                    throw new ArgumentException("El valor debe estar entre 1 y 120");
                }
                _intervaloComboHora = value;
                CargarComboHora();
            }
        }
        public void CargarComboHora()
        {
            comboHora.Items.Clear();
            DateTime fecha = DateTime.MinValue;
            while (fecha.Day == 1)
            {
                comboHora.Items.Add(FormatearStringHora(fecha));
                fecha = fecha.AddMinutes(IntervaloComboHora);
            }
        }
        private string FormatearStringHora(DateTime fecha)
        {
            return fecha.ToString("HH:mm");
        }
    }
}
