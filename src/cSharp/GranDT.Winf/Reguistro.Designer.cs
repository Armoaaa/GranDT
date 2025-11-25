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
            label1.Location = new Point(303, 105);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 8;
            label1.Text = "Nombre";
            // 
            // NombreT
            // 
            NombreT.Anchor = AnchorStyles.None;
            NombreT.Location = new Point(303, 129);
            NombreT.Margin = new Padding(3, 4, 3, 4);
            NombreT.Name = "NombreT";
            NombreT.Size = new Size(256, 27);
            NombreT.TabIndex = 7;
            // 
            // Atras
            // 
            Atras.Anchor = AnchorStyles.None;
            Atras.BackgroundImage = Properties.Resources.Cancelar;
            Atras.BackgroundImageLayout = ImageLayout.Zoom;
            Atras.FlatStyle = FlatStyle.Flat;
            Atras.Location = new Point(303, 452);
            Atras.Margin = new Padding(3, 4, 3, 4);
            Atras.Name = "Atras";
            Atras.Size = new Size(256, 87);
            Atras.TabIndex = 6;
            Atras.UseVisualStyleBackColor = true;
            Atras.Click += Atras_Click;
            // 
            // Reguistrarse
            // 
            Reguistrarse.Anchor = AnchorStyles.None;
            Reguistrarse.BackgroundImage = Properties.Resources.Registrarse;
            Reguistrarse.BackgroundImageLayout = ImageLayout.Zoom;
            Reguistrarse.FlatStyle = FlatStyle.Flat;
            Reguistrarse.Location = new Point(727, 452);
            Reguistrarse.Margin = new Padding(3, 4, 3, 4);
            Reguistrarse.Name = "Reguistrarse";
            Reguistrarse.Size = new Size(256, 87);
            Reguistrarse.TabIndex = 5;
            Reguistrarse.UseVisualStyleBackColor = true;
            Reguistrarse.Click += Reguistrarse_Click;
            // 
            // ApellidoT
            // 
            ApellidoT.Anchor = AnchorStyles.None;
            ApellidoT.Location = new Point(724, 129);
            ApellidoT.Margin = new Padding(3, 4, 3, 4);
            ApellidoT.Name = "ApellidoT";
            ApellidoT.Size = new Size(259, 27);
            ApellidoT.TabIndex = 9;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(727, 105);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 10;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(303, 167);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 12;
            label3.Text = "Correo Electronico";
            // 
            // EmailT
            // 
            EmailT.Anchor = AnchorStyles.None;
            EmailT.Location = new Point(303, 191);
            EmailT.Margin = new Padding(3, 4, 3, 4);
            EmailT.Name = "EmailT";
            EmailT.Size = new Size(256, 27);
            EmailT.TabIndex = 11;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(303, 228);
            label4.Name = "label4";
            label4.Size = new Size(146, 20);
            label4.TabIndex = 14;
            label4.Text = "Fecha de nacimiento";
            // 
            // Contrasena
            // 
            Contrasena.Anchor = AnchorStyles.None;
            Contrasena.AutoSize = true;
            Contrasena.Location = new Point(303, 295);
            Contrasena.Name = "Contrasena";
            Contrasena.Size = new Size(70, 20);
            Contrasena.TabIndex = 16;
            Contrasena.Text = "Password";
            // 
            // MaskFecha
            // 
            MaskFecha.Anchor = AnchorStyles.None;
            MaskFecha.Location = new Point(303, 253);
            MaskFecha.Margin = new Padding(3, 4, 3, 4);
            MaskFecha.Mask = "0000-00-00";
            MaskFecha.Name = "MaskFecha";
            MaskFecha.Size = new Size(256, 27);
            MaskFecha.TabIndex = 17;
            MaskFecha.ValidatingType = typeof(DateTime);
            // 
            // ContrasenaT
            // 
            ContrasenaT.Anchor = AnchorStyles.None;
            ContrasenaT.Location = new Point(307, 319);
            ContrasenaT.Margin = new Padding(3, 4, 3, 4);
            ContrasenaT.Name = "ContrasenaT";
            ContrasenaT.Size = new Size(257, 27);
            ContrasenaT.TabIndex = 15;
            ContrasenaT.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(726, 295);
            label5.Name = "label5";
            label5.Size = new Size(140, 20);
            label5.TabIndex = 30;
            label5.Text = "Confirmar Password";
            // 
            // ContrasenaC
            // 
            ContrasenaC.Anchor = AnchorStyles.None;
            ContrasenaC.Location = new Point(723, 319);
            ContrasenaC.Margin = new Padding(3, 4, 3, 4);
            ContrasenaC.Name = "ContrasenaC";
            ContrasenaC.Size = new Size(260, 27);
            ContrasenaC.TabIndex = 29;
            ContrasenaC.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(724, 167);
            label6.Name = "label6";
            label6.Size = new Size(202, 20);
            label6.TabIndex = 28;
            label6.Text = "Confirmar Correo Electronico";
            // 
            // EmailC
            // 
            EmailC.Anchor = AnchorStyles.None;
            EmailC.Location = new Point(724, 191);
            EmailC.Margin = new Padding(3, 4, 3, 4);
            EmailC.Name = "EmailC";
            EmailC.Size = new Size(259, 27);
            EmailC.TabIndex = 27;
            // 
            // Reguistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 703);
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
            Margin = new Padding(3, 4, 3, 4);
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