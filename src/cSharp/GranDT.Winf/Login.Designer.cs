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
            Contrasena.Anchor = AnchorStyles.None;
            Contrasena.AutoSize = true;
            Contrasena.BackColor = Color.Transparent;
            Contrasena.FlatStyle = FlatStyle.Popup;
            Contrasena.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            Contrasena.ForeColor = SystemColors.ButtonHighlight;
            Contrasena.Location = new Point(284, 201);
            Contrasena.Name = "Contrasena";
            Contrasena.Size = new Size(103, 29);
            Contrasena.TabIndex = 22;
            Contrasena.Text = "Password";
            // 
            // ContrasenaT
            // 
            ContrasenaT.Anchor = AnchorStyles.None;
            ContrasenaT.Location = new Point(283, 233);
            ContrasenaT.Name = "ContrasenaT";
            ContrasenaT.Size = new Size(596, 23);
            ContrasenaT.TabIndex = 21;
            ContrasenaT.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Popup;
            label3.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(285, 77);
            label3.Name = "label3";
            label3.Size = new Size(201, 29);
            label3.TabIndex = 20;
            label3.Text = "Correo Electronico";
            // 
            // EmailT
            // 
            EmailT.Anchor = AnchorStyles.None;
            EmailT.Location = new Point(284, 109);
            EmailT.Name = "EmailT";
            EmailT.Size = new Size(596, 23);
            EmailT.TabIndex = 19;
            // 
            // Atras
            // 
            Atras.Anchor = AnchorStyles.None;
            Atras.BackColor = Color.Transparent;
            Atras.BackgroundImage = Properties.Resources.Cancelar;
            Atras.BackgroundImageLayout = ImageLayout.Zoom;
            Atras.FlatStyle = FlatStyle.Flat;
            Atras.ImageAlign = ContentAlignment.BottomCenter;
            Atras.Location = new Point(286, 412);
            Atras.Name = "Atras";
            Atras.Size = new Size(224, 65);
            Atras.TabIndex = 18;
            Atras.UseVisualStyleBackColor = false;
            Atras.Click += Atras_Click;
            // 
            // Reguistrarse
            // 
            Reguistrarse.Anchor = AnchorStyles.None;
            Reguistrarse.BackColor = Color.Transparent;
            Reguistrarse.BackgroundImage = Properties.Resources.Aceptar;
            Reguistrarse.BackgroundImageLayout = ImageLayout.Zoom;
            Reguistrarse.FlatStyle = FlatStyle.Flat;
            Reguistrarse.Location = new Point(656, 412);
            Reguistrarse.Name = "Reguistrarse";
            Reguistrarse.Size = new Size(224, 69);
            Reguistrarse.TabIndex = 17;
            Reguistrarse.UseVisualStyleBackColor = false;
            Reguistrarse.Click += Reguistrarse_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(283, 143);
            label1.Name = "label1";
            label1.Size = new Size(310, 29);
            label1.TabIndex = 24;
            label1.Text = "Confirmar Correo Electronico";
            // 
            // EmailC
            // 
            EmailC.Anchor = AnchorStyles.None;
            EmailC.Location = new Point(283, 175);
            EmailC.Name = "EmailC";
            EmailC.Size = new Size(596, 23);
            EmailC.TabIndex = 23;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Popup;
            label2.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(283, 270);
            label2.Name = "label2";
            label2.Size = new Size(212, 29);
            label2.TabIndex = 26;
            label2.Text = "Confirmar Password";
            // 
            // ContrasenaC
            // 
            ContrasenaC.Anchor = AnchorStyles.None;
            ContrasenaC.Location = new Point(284, 302);
            ContrasenaC.Name = "ContrasenaC";
            ContrasenaC.Size = new Size(596, 23);
            ContrasenaC.TabIndex = 25;
            ContrasenaC.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_generico;
            ClientSize = new Size(1166, 527);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GranDT";
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