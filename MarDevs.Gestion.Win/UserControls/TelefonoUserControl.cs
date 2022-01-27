using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MarDevs.Gestion.Core;

namespace MarDevs.Gestion.Win
{
    [System.ComponentModel.DefaultBindingProperty("Value")]
    public partial class TelefonoUserControl : UserControl
    {
        public TelefonoUserControl()
        {
            InitializeComponent();
        }
        
        private MarDevs.Gestion.Core.Telefono _value;
        private ArrayList _tiposTelefono;

        public ArrayList TiposTelefono
        {
            get { return _tiposTelefono; }
            set
            {
                _tiposTelefono = value;
                this.comboTipo.DataSource = value;
            }
        }
        public MarDevs.Gestion.Core.Telefono Value
        {
            get { return _value; }
            set
            {
                _value = value;
                this.comboTipo.DataBindings.Clear();
                this.txtNumero.DataBindings.Clear();
                if (_value != null)
                {
                    this.comboTipo.DataBindings.Add("Value", _value, "Tipo");
                    this.txtNumero.DataBindings.Add("Text", _value, "Numero");
                }
            }
        }
	
    
    }
	
}
