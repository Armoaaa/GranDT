namespace GranDT.Winf
{
    partial class AltaPuntuacion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaPuntuacion));
            label1 = new Label();
            cboFutbolista = new ComboBox();
            label2 = new Label();
            txtFechaNro = new TextBox();
            label3 = new Label();
            txtPuntos = new TextBox();
            buttonGuardar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 14);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Futbolista";
            // 
            // cboFutbolista
            // 
            cboFutbolista.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFutbolista.FormattingEnabled = true;
            cboFutbolista.Location = new Point(21, 32);
            cboFutbolista.Margin = new Padding(3, 2, 3, 2);
            cboFutbolista.Name = "cboFutbolista";
            cboFutbolista.Size = new Size(282, 23);
            cboFutbolista.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 62);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 2;
            label2.Text = "Fecha Nro";
            // 
            // txtFechaNro
            // 
            txtFechaNro.Location = new Point(21, 79);
            txtFechaNro.Margin = new Padding(3, 2, 3, 2);
            txtFechaNro.Name = "txtFechaNro";
            txtFechaNro.Size = new Size(88, 23);
            txtFechaNro.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 109);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 4;
            label3.Text = "Puntos";
            // 
            // txtPuntos
            // 
            txtPuntos.Location = new Point(21, 126);
            txtPuntos.Margin = new Padding(3, 2, 3, 2);
            txtPuntos.Name = "txtPuntos";
            txtPuntos.Size = new Size(88, 23);
            txtPuntos.TabIndex = 5;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(21, 158);
            buttonGuardar.Margin = new Padding(3, 2, 3, 2);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(107, 26);
            buttonGuardar.TabIndex = 6;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // AltaPuntuacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 200);
            Controls.Add(buttonGuardar);
            Controls.Add(txtPuntos);
            Controls.Add(label3);
            Controls.Add(txtFechaNro);
            Controls.Add(label2);
            Controls.Add(cboFutbolista);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AltaPuntuacion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "GranDT";
            Load += AltaPuntuacion_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFutbolista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFechaNro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPuntos;
        private System.Windows.Forms.Button buttonGuardar;
    }
}
