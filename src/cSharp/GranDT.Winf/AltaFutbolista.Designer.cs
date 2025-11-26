namespace GranDT.Winf
{
    partial class AltaFutbolista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaFutbolista));
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            label1 = new Label();
            label2 = new Label();
            buttonGuardar = new Button();
            txtApodo = new TextBox();
            label3 = new Label();
            dateNacimiento = new DateTimePicker();
            label4 = new Label();
            txtCotizacion = new TextBox();
            label5 = new Label();
            cboTipo = new ComboBox();
            label6 = new Label();
            cboEquipo = new ComboBox();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(21, 27);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(282, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(21, 64);
            txtApellido.Margin = new Padding(3, 2, 3, 2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(282, 23);
            txtApellido.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 10);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 2;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 47);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Apellido";
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(21, 248);
            buttonGuardar.Margin = new Padding(3, 2, 3, 2);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(107, 26);
            buttonGuardar.TabIndex = 4;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // txtApodo
            // 
            txtApodo.Location = new Point(21, 102);
            txtApodo.Margin = new Padding(3, 2, 3, 2);
            txtApodo.Name = "txtApodo";
            txtApodo.Size = new Size(282, 23);
            txtApodo.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 85);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 6;
            label3.Text = "Apodo";
            // 
            // dateNacimiento
            // 
            dateNacimiento.Location = new Point(21, 140);
            dateNacimiento.Margin = new Padding(3, 2, 3, 2);
            dateNacimiento.Name = "dateNacimiento";
            dateNacimiento.Size = new Size(282, 23);
            dateNacimiento.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 122);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 8;
            label4.Text = "Fecha nacimiento";
            // 
            // txtCotizacion
            // 
            txtCotizacion.Location = new Point(21, 177);
            txtCotizacion.Margin = new Padding(3, 2, 3, 2);
            txtCotizacion.Name = "txtCotizacion";
            txtCotizacion.Size = new Size(282, 23);
            txtCotizacion.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 160);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 10;
            label5.Text = "Cotización";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(21, 214);
            cboTipo.Margin = new Padding(3, 2, 3, 2);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(106, 23);
            cboTipo.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 197);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 12;
            label6.Text = "Tipo";
            // 
            // cboEquipo
            // 
            cboEquipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEquipo.FormattingEnabled = true;
            cboEquipo.Location = new Point(175, 214);
            cboEquipo.Margin = new Padding(3, 2, 3, 2);
            cboEquipo.Name = "cboEquipo";
            cboEquipo.Size = new Size(128, 23);
            cboEquipo.TabIndex = 13;
            // 
            // AltaFutbolista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 290);
            Controls.Add(cboEquipo);
            Controls.Add(label6);
            Controls.Add(cboTipo);
            Controls.Add(txtCotizacion);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dateNacimiento);
            Controls.Add(label3);
            Controls.Add(txtApodo);
            Controls.Add(buttonGuardar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AltaFutbolista";
            StartPosition = FormStartPosition.CenterParent;
            Text = "GranDT";
            Load += AltaFutbolista_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.TextBox txtApodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateNacimiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCotizacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboEquipo;
    }
}
