namespace GranDT.Winf
{
    partial class Register
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
            Apellido = new TextBox();
            Nombre = new TextBox();
            Nacimiento = new TextBox();
            Email = new TextBox();
            Contrasena = new TextBox();
            NombreTxt = new Label();
            NacimientoTxt = new Label();
            ContrasenaTxt = new Label();
            EmailTxt = new Label();
            ApellidoTxt = new Label();
            Registrarse = new Button();
            SuspendLayout();
            // 
            // Apellido
            // 
            Apellido.Location = new Point(429, 72);
            Apellido.Name = "Apellido";
            Apellido.Size = new Size(100, 23);
            Apellido.TabIndex = 0;
            Apellido.TextChanged += Apellido_TextChanged;
            // 
            // Nombre
            // 
            Nombre.Location = new Point(307, 72);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(100, 23);
            Nombre.TabIndex = 1;
            Nombre.TextChanged += Nombre_TextChanged;
            // 
            // Nacimiento
            // 
            Nacimiento.Location = new Point(307, 124);
            Nacimiento.Name = "Nacimiento";
            Nacimiento.Size = new Size(222, 23);
            Nacimiento.TabIndex = 2;
            Nacimiento.TextChanged += Nacimiento_TextChanged;
            // 
            // Email
            // 
            Email.Location = new Point(307, 171);
            Email.Name = "Email";
            Email.Size = new Size(222, 23);
            Email.TabIndex = 3;
            Email.TextChanged += Email_TextChanged;
            // 
            // Contrasena
            // 
            Contrasena.Location = new Point(308, 224);
            Contrasena.Name = "Contrasena";
            Contrasena.Size = new Size(222, 23);
            Contrasena.TabIndex = 4;
            Contrasena.TextChanged += Contrasena_TextChanged;
            // 
            // NombreTxt
            // 
            NombreTxt.AutoSize = true;
            NombreTxt.Location = new Point(310, 54);
            NombreTxt.Name = "NombreTxt";
            NombreTxt.Size = new Size(51, 15);
            NombreTxt.TabIndex = 5;
            NombreTxt.Text = "Nombre";
            // 
            // NacimientoTxt
            // 
            NacimientoTxt.AutoSize = true;
            NacimientoTxt.Location = new Point(310, 106);
            NacimientoTxt.Name = "NacimientoTxt";
            NacimientoTxt.Size = new Size(117, 15);
            NacimientoTxt.TabIndex = 6;
            NacimientoTxt.Text = "Fecha de nacimiento";
            // 
            // ContrasenaTxt
            // 
            ContrasenaTxt.AutoSize = true;
            ContrasenaTxt.Location = new Point(311, 206);
            ContrasenaTxt.Name = "ContrasenaTxt";
            ContrasenaTxt.Size = new Size(67, 15);
            ContrasenaTxt.TabIndex = 8;
            ContrasenaTxt.Text = "Contrasena";
            // 
            // EmailTxt
            // 
            EmailTxt.AutoSize = true;
            EmailTxt.Location = new Point(310, 153);
            EmailTxt.Name = "EmailTxt";
            EmailTxt.Size = new Size(36, 15);
            EmailTxt.TabIndex = 7;
            EmailTxt.Text = "Email";
            // 
            // ApellidoTxt
            // 
            ApellidoTxt.AutoSize = true;
            ApellidoTxt.Location = new Point(432, 54);
            ApellidoTxt.Name = "ApellidoTxt";
            ApellidoTxt.Size = new Size(51, 15);
            ApellidoTxt.TabIndex = 9;
            ApellidoTxt.Text = "Apellido";
            // 
            // Registrarse
            // 
            Registrarse.Location = new Point(562, 185);
            Registrarse.Name = "Registrarse";
            Registrarse.Size = new Size(208, 98);
            Registrarse.TabIndex = 10;
            Registrarse.Text = "Registrarse";
            Registrarse.UseVisualStyleBackColor = true;
            Registrarse.Click += Registrarse_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Registrarse);
            Controls.Add(ApellidoTxt);
            Controls.Add(ContrasenaTxt);
            Controls.Add(EmailTxt);
            Controls.Add(NacimientoTxt);
            Controls.Add(NombreTxt);
            Controls.Add(Contrasena);
            Controls.Add(Email);
            Controls.Add(Nacimiento);
            Controls.Add(Nombre);
            Controls.Add(Apellido);
            Name = "Register";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Apellido;
        private TextBox Nombre;
        private TextBox Nacimiento;
        private TextBox Email;
        private TextBox Contrasena;
        private Label NombreTxt;
        private Label NacimientoTxt;
        private Label ContrasenaTxt;
        private Label EmailTxt;
        private Label ApellidoTxt;
        private Button Registrarse;
    }
}
