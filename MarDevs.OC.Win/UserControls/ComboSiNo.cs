using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarDevs.OC.Win
{
    public partial class ComboSiNo : UserControl
    {
        string _tituloLabel;
        public virtual string TituloLabel
        {
            get { return _tituloLabel; }
            set { _tituloLabel = value; }
        }

        public ComboSiNo()
        {
            InitializeComponent();
        }

        private void ComboSiNo_Load(object sender, EventArgs e)
        {
            ultraLabel1.Text = _tituloLabel;
            cboSiNo.Items.Add(true, "SI");
            cboSiNo.Items.Add(false, "NO");
        }

        [Bindable(true)]
        public bool Value
        {
            get { return Convert.ToBoolean(cboSiNo.Value); }
            set { cboSiNo.Value = value; }
        }
    }
}
