namespace GranDT.Winf
{
    partial class Login
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            CContraseña = new TextBox();
            Contraseña = new TextBox();
            CCorreo = new TextBox();
            Correo = new TextBox();
            IngresarL = new Button();
            CancelarL = new Button();
            SuspendLayout();
            // 
            // CContraseña
            // 
            CContraseña.Location = new Point(821, 484);
            CContraseña.Name = "CContraseña";
            CContraseña.Size = new Size(422, 27);
            CContraseña.TabIndex = 10;
            // 
            // Contraseña
            // 
            Contraseña.Location = new Point(821, 413);
            Contraseña.Name = "Contraseña";
            Contraseña.Size = new Size(422, 27);
            Contraseña.TabIndex = 9;
            // 
            // CCorreo
            // 
            CCorreo.Location = new Point(819, 329);
            CCorreo.Name = "CCorreo";
            CCorreo.Size = new Size(422, 27);
            CCorreo.TabIndex = 8;
            // 
            // Correo
            // 
            Correo.Location = new Point(819, 258);
            Correo.Name = "Correo";
            Correo.Size = new Size(422, 27);
            Correo.TabIndex = 7;
            // 
            // IngresarL
            // 
            IngresarL.BackColor = Color.Transparent;
            IngresarL.Location = new Point(837, 540);
            IngresarL.Name = "IngresarL";
            IngresarL.Size = new Size(164, 31);
            IngresarL.TabIndex = 11;
            IngresarL.Text = "Ingresar";
            IngresarL.UseVisualStyleBackColor = false;
            // 
            // CancelarL
            // 
            CancelarL.BackColor = Color.Transparent;
            CancelarL.Location = new Point(1071, 539);
            CancelarL.Name = "CancelarL";
            CancelarL.Size = new Size(161, 31);
            CancelarL.TabIndex = 12;
            CancelarL.Text = "Cancelar";
            CancelarL.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1263, 715);
            Controls.Add(CancelarL);
            Controls.Add(IngresarL);
            Controls.Add(CContraseña);
            Controls.Add(Contraseña);
            Controls.Add(CCorreo);
            Controls.Add(Correo);
            DoubleBuffered = true;
            Name = "Login";
            Text = "GranDT";
            Load += this.Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox CContraseña;
        private TextBox Contraseña;
        private TextBox CCorreo;
        private TextBox Correo;
        private Button IngresarL;
        private Button CancelarL;
    }
}