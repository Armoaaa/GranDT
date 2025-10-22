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
            NacimientoT = new TextBox();
            Contrasena = new Label();
            ContrasenaT = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(265, 79);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 8;
            label1.Text = "Nombre";
            // 
            // NombreT
            // 
            NombreT.Location = new Point(265, 97);
            NombreT.Name = "NombreT";
            NombreT.Size = new Size(106, 23);
            NombreT.TabIndex = 7;
            // 
            // Atras
            // 
            Atras.Location = new Point(265, 339);
            Atras.Name = "Atras";
            Atras.Size = new Size(104, 33);
            Atras.TabIndex = 6;
            Atras.Text = "Atras";
            Atras.UseVisualStyleBackColor = true;
            Atras.Click += Atras_Click;
            // 
            // Reguistrarse
            // 
            Reguistrarse.Location = new Point(391, 339);
            Reguistrarse.Name = "Reguistrarse";
            Reguistrarse.Size = new Size(104, 33);
            Reguistrarse.TabIndex = 5;
            Reguistrarse.Text = "Reguistrarse";
            Reguistrarse.UseVisualStyleBackColor = true;
            Reguistrarse.Click += Reguistrarse_Click;
            // 
            // ApellidoT
            // 
            ApellidoT.Location = new Point(389, 97);
            ApellidoT.Name = "ApellidoT";
            ApellidoT.Size = new Size(106, 23);
            ApellidoT.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(389, 79);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 10;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 125);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 12;
            label3.Text = "Correo Electronico";
            // 
            // EmailT
            // 
            EmailT.Location = new Point(265, 143);
            EmailT.Name = "EmailT";
            EmailT.Size = new Size(230, 23);
            EmailT.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(265, 171);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 14;
            label4.Text = "Fecha de nacimiento";
            // 
            // NacimientoT
            // 
            NacimientoT.Location = new Point(265, 189);
            NacimientoT.Name = "NacimientoT";
            NacimientoT.Size = new Size(230, 23);
            NacimientoT.TabIndex = 13;
            // 
            // Contrasena
            // 
            Contrasena.AutoSize = true;
            Contrasena.Location = new Point(265, 221);
            Contrasena.Name = "Contrasena";
            Contrasena.Size = new Size(57, 15);
            Contrasena.TabIndex = 16;
            Contrasena.Text = "Password";
            // 
            // ContrasenaT
            // 
            ContrasenaT.Location = new Point(265, 239);
            ContrasenaT.Name = "ContrasenaT";
            ContrasenaT.Size = new Size(230, 23);
            ContrasenaT.TabIndex = 15;
            // 
            // Reguistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Contrasena);
            Controls.Add(ContrasenaT);
            Controls.Add(label4);
            Controls.Add(NacimientoT);
            Controls.Add(label3);
            Controls.Add(EmailT);
            Controls.Add(label2);
            Controls.Add(ApellidoT);
            Controls.Add(label1);
            Controls.Add(NombreT);
            Controls.Add(Atras);
            Controls.Add(Reguistrarse);
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
        private TextBox NacimientoT;
        private Label Contrasena;
        private TextBox ContrasenaT;
    }
}