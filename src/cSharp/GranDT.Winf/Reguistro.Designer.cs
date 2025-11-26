namespace GranDT.Winf
{
    partial class Reguistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reguistro));
            label1 = new Label();
            NombreT = new TextBox();
            Atras = new Button();
            Reguistrarse = new Button();
            ApellidoT = new TextBox();
            label2 = new Label();
            label3 = new Label();
            EmailT = new TextBox();
            label4 = new Label();
            Contrasena = new Label();
            MaskFecha = new MaskedTextBox();
            ContrasenaT = new TextBox();
            label5 = new Label();
            ContrasenaC = new TextBox();
            label6 = new Label();
            EmailC = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(265, 65);
            label1.Name = "label1";
            label1.Size = new Size(91, 29);
            label1.TabIndex = 8;
            label1.Text = "Nombre";
            // 
            // NombreT
            // 
            NombreT.Anchor = AnchorStyles.None;
            NombreT.Location = new Point(265, 97);
            NombreT.Name = "NombreT";
            NombreT.Size = new Size(224, 23);
            NombreT.TabIndex = 7;
            // 
            // Atras
            // 
            Atras.Anchor = AnchorStyles.None;
            Atras.BackColor = Color.Transparent;
            Atras.BackgroundImage = Properties.Resources.Cancelar;
            Atras.BackgroundImageLayout = ImageLayout.Zoom;
            Atras.FlatStyle = FlatStyle.Flat;
            Atras.Location = new Point(265, 339);
            Atras.Name = "Atras";
            Atras.Size = new Size(224, 65);
            Atras.TabIndex = 6;
            Atras.UseVisualStyleBackColor = false;
            Atras.Click += Atras_Click;
            // 
            // Reguistrarse
            // 
            Reguistrarse.Anchor = AnchorStyles.None;
            Reguistrarse.BackColor = Color.Transparent;
            Reguistrarse.BackgroundImage = Properties.Resources.Registrarse;
            Reguistrarse.BackgroundImageLayout = ImageLayout.Zoom;
            Reguistrarse.FlatStyle = FlatStyle.Flat;
            Reguistrarse.Location = new Point(636, 339);
            Reguistrarse.Name = "Reguistrarse";
            Reguistrarse.Size = new Size(224, 65);
            Reguistrarse.TabIndex = 5;
            Reguistrarse.UseVisualStyleBackColor = false;
            Reguistrarse.Click += Reguistrarse_Click;
            // 
            // ApellidoT
            // 
            ApellidoT.Anchor = AnchorStyles.None;
            ApellidoT.Location = new Point(634, 97);
            ApellidoT.Name = "ApellidoT";
            ApellidoT.Size = new Size(227, 23);
            ApellidoT.TabIndex = 9;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(636, 65);
            label2.Name = "label2";
            label2.Size = new Size(92, 29);
            label2.TabIndex = 10;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(265, 125);
            label3.Name = "label3";
            label3.Size = new Size(201, 29);
            label3.TabIndex = 12;
            label3.Text = "Correo Electronico";
            // 
            // EmailT
            // 
            EmailT.Anchor = AnchorStyles.None;
            EmailT.Location = new Point(265, 157);
            EmailT.Name = "EmailT";
            EmailT.Size = new Size(224, 23);
            EmailT.TabIndex = 11;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(265, 189);
            label4.Name = "label4";
            label4.Size = new Size(221, 29);
            label4.TabIndex = 14;
            label4.Text = "Fecha de nacimiento";
            // 
            // Contrasena
            // 
            Contrasena.Anchor = AnchorStyles.None;
            Contrasena.AutoSize = true;
            Contrasena.BackColor = Color.Transparent;
            Contrasena.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            Contrasena.ForeColor = SystemColors.ControlLightLight;
            Contrasena.Location = new Point(261, 255);
            Contrasena.Name = "Contrasena";
            Contrasena.Size = new Size(103, 29);
            Contrasena.TabIndex = 16;
            Contrasena.Text = "Password";
            // 
            // MaskFecha
            // 
            MaskFecha.Anchor = AnchorStyles.None;
            MaskFecha.Location = new Point(265, 221);
            MaskFecha.Mask = "0000-00-00";
            MaskFecha.Name = "MaskFecha";
            MaskFecha.Size = new Size(224, 23);
            MaskFecha.TabIndex = 17;
            MaskFecha.ValidatingType = typeof(DateTime);
            // 
            // ContrasenaT
            // 
            ContrasenaT.Anchor = AnchorStyles.None;
            ContrasenaT.Location = new Point(261, 287);
            ContrasenaT.Name = "ContrasenaT";
            ContrasenaT.Size = new Size(225, 23);
            ContrasenaT.TabIndex = 15;
            ContrasenaT.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(632, 255);
            label5.Name = "label5";
            label5.Size = new Size(212, 29);
            label5.TabIndex = 30;
            label5.Text = "Confirmar Password";
            // 
            // ContrasenaC
            // 
            ContrasenaC.Anchor = AnchorStyles.None;
            ContrasenaC.Location = new Point(632, 287);
            ContrasenaC.Name = "ContrasenaC";
            ContrasenaC.Size = new Size(228, 23);
            ContrasenaC.TabIndex = 29;
            ContrasenaC.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(632, 125);
            label6.Name = "label6";
            label6.Size = new Size(310, 29);
            label6.TabIndex = 28;
            label6.Text = "Confirmar Correo Electronico";
            // 
            // EmailC
            // 
            EmailC.Anchor = AnchorStyles.None;
            EmailC.Location = new Point(633, 157);
            EmailC.Name = "EmailC";
            EmailC.Size = new Size(227, 23);
            EmailC.TabIndex = 27;
            // 
            // Reguistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_generico;
            ClientSize = new Size(1166, 527);
            Controls.Add(label5);
            Controls.Add(ContrasenaC);
            Controls.Add(label6);
            Controls.Add(EmailC);
            Controls.Add(MaskFecha);
            Controls.Add(Contrasena);
            Controls.Add(ContrasenaT);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(EmailT);
            Controls.Add(label2);
            Controls.Add(ApellidoT);
            Controls.Add(label1);
            Controls.Add(NombreT);
            Controls.Add(Atras);
            Controls.Add(Reguistrarse);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Reguistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GranDT";
            Load += Reguistro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox NombreT;
        private Button Atras;
        private Button Reguistrarse;
        private TextBox ApellidoT;
        private Label label2;
        private Label label3;
        private TextBox EmailT;
        private Label label4;
        private Label Contrasena;
        private MaskedTextBox MaskFecha;
        private TextBox ContrasenaT;
        private Label label5;
        private TextBox ContrasenaC;
        private Label label6;
        private TextBox EmailC;
    }
}