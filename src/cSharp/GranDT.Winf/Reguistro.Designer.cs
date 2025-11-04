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
            NombreT.Size = new Size(166, 23);
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
            Reguistrarse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            ApellidoT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ApellidoT.Location = new Point(329, 97);
            ApellidoT.Name = "ApellidoT";
            ApellidoT.Size = new Size(166, 23);
            ApellidoT.TabIndex = 9;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(332, 79);
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
            EmailT.Size = new Size(166, 23);
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
            // Contrasena
            // 
            Contrasena.AutoSize = true;
            Contrasena.Location = new Point(265, 221);
            Contrasena.Name = "Contrasena";
            Contrasena.Size = new Size(57, 15);
            Contrasena.TabIndex = 16;
            Contrasena.Text = "Password";
            // 
            // MaskFecha
            // 
            MaskFecha.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MaskFecha.Location = new Point(265, 190);
            MaskFecha.Mask = "0000-00-00";
            MaskFecha.Name = "MaskFecha";
            MaskFecha.Size = new Size(230, 23);
            MaskFecha.TabIndex = 17;
            MaskFecha.ValidatingType = typeof(DateTime);
            // 
            // ContrasenaT
            // 
            ContrasenaT.Location = new Point(269, 239);
            ContrasenaT.Name = "ContrasenaT";
            ContrasenaT.Size = new Size(167, 23);
            ContrasenaT.TabIndex = 15;
            ContrasenaT.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(331, 221);
            label5.Name = "label5";
            label5.Size = new Size(114, 15);
            label5.TabIndex = 30;
            label5.Text = "Confirmar Password";
            // 
            // ContrasenaC
            // 
            ContrasenaC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ContrasenaC.Location = new Point(328, 239);
            ContrasenaC.Name = "ContrasenaC";
            ContrasenaC.Size = new Size(167, 23);
            ContrasenaC.TabIndex = 29;
            ContrasenaC.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(329, 125);
            label6.Name = "label6";
            label6.Size = new Size(162, 15);
            label6.TabIndex = 28;
            label6.Text = "Confirmar Correo Electronico";
            // 
            // EmailC
            // 
            EmailC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EmailC.Location = new Point(329, 143);
            EmailC.Name = "EmailC";
            EmailC.Size = new Size(166, 23);
            EmailC.TabIndex = 27;
            // 
            // Reguistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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