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
            Contrasena.Anchor = AnchorStyles.None;
            Contrasena.AutoSize = true;
            Contrasena.Location = new Point(326, 231);
            Contrasena.Name = "Contrasena";
            Contrasena.Size = new Size(70, 20);
            Contrasena.TabIndex = 22;
            Contrasena.Text = "Password";
            // 
            // ContrasenaT
            // 
            ContrasenaT.Anchor = AnchorStyles.None;
            ContrasenaT.Location = new Point(326, 255);
            ContrasenaT.Margin = new Padding(3, 4, 3, 4);
            ContrasenaT.Name = "ContrasenaT";
            ContrasenaT.Size = new Size(680, 27);
            ContrasenaT.TabIndex = 21;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(326, 103);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 20;
            label3.Text = "Correo Electronico";
            // 
            // EmailT
            // 
            EmailT.Anchor = AnchorStyles.None;
            EmailT.Location = new Point(326, 127);
            EmailT.Margin = new Padding(3, 4, 3, 4);
            EmailT.Name = "EmailT";
            EmailT.Size = new Size(680, 27);
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
            Atras.Location = new Point(326, 421);
            Atras.Margin = new Padding(3, 4, 3, 4);
            Atras.Name = "Atras";
            Atras.Size = new Size(256, 87);
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
            Reguistrarse.Location = new Point(749, 421);
            Reguistrarse.Margin = new Padding(3, 4, 3, 4);
            Reguistrarse.Name = "Reguistrarse";
            Reguistrarse.Size = new Size(256, 92);
            Reguistrarse.TabIndex = 17;
            Reguistrarse.UseVisualStyleBackColor = false;
            Reguistrarse.Click += Reguistrarse_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(325, 161);
            label1.Name = "label1";
            label1.Size = new Size(202, 20);
            label1.TabIndex = 24;
            label1.Text = "Confirmar Correo Electronico";
            // 
            // EmailC
            // 
            EmailC.Anchor = AnchorStyles.None;
            EmailC.Location = new Point(325, 185);
            EmailC.Margin = new Padding(3, 4, 3, 4);
            EmailC.Name = "EmailC";
            EmailC.Size = new Size(680, 27);
            EmailC.TabIndex = 23;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(326, 296);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 26;
            label2.Text = "Confirmar Password";
            // 
            // ContrasenaC
            // 
            ContrasenaC.Anchor = AnchorStyles.None;
            ContrasenaC.Location = new Point(326, 320);
            ContrasenaC.Margin = new Padding(3, 4, 3, 4);
            ContrasenaC.Name = "ContrasenaC";
            ContrasenaC.Size = new Size(680, 27);
            ContrasenaC.TabIndex = 25;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 703);
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
            Margin = new Padding(3, 4, 3, 4);
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