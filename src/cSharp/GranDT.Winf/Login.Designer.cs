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
            Contrasena = new Label();
            ContrasenaT = new TextBox();
            label3 = new Label();
            EmailT = new TextBox();
            Atras = new Button();
            Reguistrarse = new Button();
            label1 = new Label();
            EmailC = new TextBox();
            label2 = new Label();
            ContrasenaC = new TextBox();
            SuspendLayout();
            // 
            // Contrasena
            // 
            Contrasena.AutoSize = true;
            Contrasena.Location = new Point(285, 173);
            Contrasena.Name = "Contrasena";
            Contrasena.Size = new Size(57, 15);
            Contrasena.TabIndex = 22;
            Contrasena.Text = "Password";
            // 
            // ContrasenaT
            // 
            ContrasenaT.Location = new Point(285, 191);
            ContrasenaT.Name = "ContrasenaT";
            ContrasenaT.Size = new Size(230, 23);
            ContrasenaT.TabIndex = 21;
            ContrasenaT.TextChanged += ContrasenaT_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 77);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 20;
            label3.Text = "Correo Electronico";
            // 
            // EmailT
            // 
            EmailT.Location = new Point(285, 95);
            EmailT.Name = "EmailT";
            EmailT.Size = new Size(230, 23);
            EmailT.TabIndex = 19;
            EmailT.TextChanged += EmailT_TextChanged;
            // 
            // Atras
            // 
            Atras.Location = new Point(285, 316);
            Atras.Name = "Atras";
            Atras.Size = new Size(104, 33);
            Atras.TabIndex = 18;
            Atras.Text = "Atras";
            Atras.UseVisualStyleBackColor = true;
            Atras.Click += Atras_Click;
            // 
            // Reguistrarse
            // 
            Reguistrarse.Location = new Point(411, 316);
            Reguistrarse.Name = "Reguistrarse";
            Reguistrarse.Size = new Size(104, 33);
            Reguistrarse.TabIndex = 17;
            Reguistrarse.Text = "Login";
            Reguistrarse.UseVisualStyleBackColor = true;
            Reguistrarse.Click += Reguistrarse_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(284, 121);
            label1.Name = "label1";
            label1.Size = new Size(162, 15);
            label1.TabIndex = 24;
            label1.Text = "Confirmar Correo Electronico";
            label1.Click += label1_Click;
            // 
            // EmailC
            // 
            EmailC.Location = new Point(284, 139);
            EmailC.Name = "EmailC";
            EmailC.Size = new Size(230, 23);
            EmailC.TabIndex = 23;
            EmailC.TextChanged += EmailC_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(285, 222);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 26;
            label2.Text = "Confirmar Password";
            // 
            // ContrasenaC
            // 
            ContrasenaC.Location = new Point(285, 240);
            ContrasenaC.Name = "ContrasenaC";
            ContrasenaC.Size = new Size(230, 23);
            ContrasenaC.TabIndex = 25;
            ContrasenaC.TextChanged += ContrasenaC_TextChanged;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(ContrasenaC);
            Controls.Add(label1);
            Controls.Add(EmailC);
            Controls.Add(Contrasena);
            Controls.Add(ContrasenaT);
            Controls.Add(label3);
            Controls.Add(EmailT);
            Controls.Add(Atras);
            Controls.Add(Reguistrarse);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Contrasena;
        private TextBox ContrasenaT;
        private Label label3;
        private TextBox EmailT;
        private Button Atras;
        private Button Reguistrarse;
        private Label label1;
        private TextBox EmailC;
        private Label label2;
        private TextBox ContrasenaC;
    }
}