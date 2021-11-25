namespace MarDevs.OC.Win
{
    partial class DomicilioUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.Label ciudadLabel;
			System.Windows.Forms.Label codigoPostalLabel;
			System.Windows.Forms.Label linea1Label;
			System.Windows.Forms.Label provinciaLabel;
			System.Windows.Forms.Label paisLabel;
			this.codigoPostalUltraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.linea1UltraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.provinciaUltraComboEditor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.paisUltraComboEditor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ciudadUltraComboEditor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			ciudadLabel = new System.Windows.Forms.Label();
			codigoPostalLabel = new System.Windows.Forms.Label();
			linea1Label = new System.Windows.Forms.Label();
			provinciaLabel = new System.Windows.Forms.Label();
			paisLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.codigoPostalUltraTextEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.linea1UltraTextEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.provinciaUltraComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paisUltraComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ciudadUltraComboEditor)).BeginInit();
			this.SuspendLayout();
			// 
			// ciudadLabel
			// 
			ciudadLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			ciudadLabel.BackColor = System.Drawing.Color.Transparent;
			ciudadLabel.Location = new System.Drawing.Point(3, 30);
			ciudadLabel.Name = "ciudadLabel";
			ciudadLabel.Size = new System.Drawing.Size(84, 21);
			ciudadLabel.TabIndex = 2;
			ciudadLabel.Text = "Barrio/Ciudad:";
			ciudadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// codigoPostalLabel
			// 
			codigoPostalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			codigoPostalLabel.BackColor = System.Drawing.Color.Transparent;
			codigoPostalLabel.Location = new System.Drawing.Point(3, 57);
			codigoPostalLabel.Name = "codigoPostalLabel";
			codigoPostalLabel.Size = new System.Drawing.Size(84, 21);
			codigoPostalLabel.TabIndex = 4;
			codigoPostalLabel.Text = "Código Postal:";
			codigoPostalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// linea1Label
			// 
			linea1Label.BackColor = System.Drawing.Color.Transparent;
			linea1Label.Location = new System.Drawing.Point(3, 3);
			linea1Label.Name = "linea1Label";
			linea1Label.Size = new System.Drawing.Size(84, 21);
			linea1Label.TabIndex = 0;
			linea1Label.Text = "Calle:";
			linea1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// provinciaLabel
			// 
			provinciaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			provinciaLabel.BackColor = System.Drawing.Color.Transparent;
			provinciaLabel.Location = new System.Drawing.Point(169, 57);
			provinciaLabel.Name = "provinciaLabel";
			provinciaLabel.Size = new System.Drawing.Size(61, 21);
			provinciaLabel.TabIndex = 6;
			provinciaLabel.Text = "Provincia:";
			provinciaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// paisLabel
			// 
			paisLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			paisLabel.BackColor = System.Drawing.Color.Transparent;
			paisLabel.Location = new System.Drawing.Point(3, 83);
			paisLabel.Name = "paisLabel";
			paisLabel.Size = new System.Drawing.Size(84, 21);
			paisLabel.TabIndex = 8;
			paisLabel.Text = "País:";
			paisLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// codigoPostalUltraTextEditor
			// 
			this.codigoPostalUltraTextEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.codigoPostalUltraTextEditor.Location = new System.Drawing.Point(93, 57);
			this.codigoPostalUltraTextEditor.Name = "codigoPostalUltraTextEditor";
			this.codigoPostalUltraTextEditor.Size = new System.Drawing.Size(72, 21);
			this.codigoPostalUltraTextEditor.TabIndex = 5;
			// 
			// linea1UltraTextEditor
			// 
			this.linea1UltraTextEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.linea1UltraTextEditor.Location = new System.Drawing.Point(93, 3);
			this.linea1UltraTextEditor.Multiline = true;
			this.linea1UltraTextEditor.Name = "linea1UltraTextEditor";
			this.linea1UltraTextEditor.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
			this.linea1UltraTextEditor.Size = new System.Drawing.Size(303, 21);
			this.linea1UltraTextEditor.TabIndex = 1;
			// 
			// provinciaUltraComboEditor
			// 
			this.provinciaUltraComboEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.provinciaUltraComboEditor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
			this.provinciaUltraComboEditor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.provinciaUltraComboEditor.Location = new System.Drawing.Point(228, 57);
			this.provinciaUltraComboEditor.Name = "provinciaUltraComboEditor";
			this.provinciaUltraComboEditor.Size = new System.Drawing.Size(168, 21);
			this.provinciaUltraComboEditor.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
			this.provinciaUltraComboEditor.TabIndex = 7;
			// 
			// paisUltraComboEditor
			// 
			this.paisUltraComboEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.paisUltraComboEditor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
			this.paisUltraComboEditor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.paisUltraComboEditor.Location = new System.Drawing.Point(93, 84);
			this.paisUltraComboEditor.Name = "paisUltraComboEditor";
			this.paisUltraComboEditor.Size = new System.Drawing.Size(303, 21);
			this.paisUltraComboEditor.TabIndex = 9;
			// 
			// ciudadUltraComboEditor
			// 
			this.ciudadUltraComboEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ciudadUltraComboEditor.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
			this.ciudadUltraComboEditor.Location = new System.Drawing.Point(93, 30);
			this.ciudadUltraComboEditor.Name = "ciudadUltraComboEditor";
			this.ciudadUltraComboEditor.Size = new System.Drawing.Size(303, 21);
			this.ciudadUltraComboEditor.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;
			this.ciudadUltraComboEditor.TabIndex = 3;
			// 
			// DomicilioUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.ciudadUltraComboEditor);
			this.Controls.Add(this.provinciaUltraComboEditor);
			this.Controls.Add(paisLabel);
			this.Controls.Add(this.paisUltraComboEditor);
			this.Controls.Add(provinciaLabel);
			this.Controls.Add(ciudadLabel);
			this.Controls.Add(codigoPostalLabel);
			this.Controls.Add(this.codigoPostalUltraTextEditor);
			this.Controls.Add(linea1Label);
			this.Controls.Add(this.linea1UltraTextEditor);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "DomicilioUserControl";
			this.Size = new System.Drawing.Size(400, 135);
			((System.ComponentModel.ISupportInitialize)(this.codigoPostalUltraTextEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.linea1UltraTextEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.provinciaUltraComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paisUltraComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ciudadUltraComboEditor)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor codigoPostalUltraTextEditor;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor linea1UltraTextEditor;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor provinciaUltraComboEditor;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor paisUltraComboEditor;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor ciudadUltraComboEditor;


    }
}
