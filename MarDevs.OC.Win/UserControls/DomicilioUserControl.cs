using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MarDevs.OC.Core;

namespace MarDevs.OC.Win
{
    [System.ComponentModel.DefaultBindingProperty("Value")]
    public partial class DomicilioUserControl : UserControl
    {
        public DomicilioUserControl()
        {
            InitializeComponent();

            this.Load += new EventHandler(DomicilioUserControl_Load);
        }

        void DomicilioUserControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            this.provinciaUltraComboEditor.DataSource = Domicilio.ListaProvincias();
        }
        
        private MarDevs.OC.Core.Domicilio _value;
        public MarDevs.OC.Core.Domicilio Value
        {
            get { return _value; }
            set
            {
                this.linea1UltraTextEditor.DataBindings.Clear();
                this.ciudadUltraComboEditor.DataBindings.Clear();
                this.codigoPostalUltraTextEditor.DataBindings.Clear();
                this.provinciaUltraComboEditor.DataBindings.Clear();
                this.paisUltraComboEditor.DataBindings.Clear();
                _value = value;
                if (_value != null)
                {
                    this.linea1UltraTextEditor.DataBindings.Add("Text", _value, "Linea1");
                    this.ciudadUltraComboEditor.DataBindings.Add("Text", _value, "Ciudad");
                    this.codigoPostalUltraTextEditor.DataBindings.Add("Text", _value, "CodigoPostal");
                    this.provinciaUltraComboEditor.DataBindings.Add("Text", _value, "Provincia");
                    this.paisUltraComboEditor.DataBindings.Add("Text", _value, "Pais");
                }
            }
        }
	
    
    }
	
}
