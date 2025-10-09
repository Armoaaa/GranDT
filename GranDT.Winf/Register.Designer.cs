    namespace GranDT.Winf;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
        Nombre = new TextBox();
        Apellido = new TextBox();
        Nacimiento = new TextBox();
        Correo = new TextBox();
        CCorreo = new TextBox();
        textBox6 = new TextBox();
        CContraseña = new TextBox();
        Contraseña = new TextBox();
        CancelarR = new Button();
        RegistrarseR = new Button();
        SuspendLayout();
        // 
        // Nombre
        // 
        Nombre.Location = new Point(846, 182);
        Nombre.Name = "Nombre";
        Nombre.Size = new Size(192, 27);
        Nombre.TabIndex = 0;
        // 
        // Apellido
        // 
        Apellido.Location = new Point(1078, 181);
        Apellido.Name = "Apellido";
        Apellido.Size = new Size(192, 27);
        Apellido.TabIndex = 1;
        // 
        // Nacimiento
        // 
        Nacimiento.Location = new Point(846, 257);
        Nacimiento.Name = "Nacimiento";
        Nacimiento.Size = new Size(192, 27);
        Nacimiento.TabIndex = 2;
        // 
        // Correo
        // 
        Correo.Location = new Point(846, 330);
        Correo.Name = "Correo";
        Correo.Size = new Size(422, 27);
        Correo.TabIndex = 3;
        // 
        // CCorreo
        // 
        CCorreo.Location = new Point(846, 401);
        CCorreo.Name = "CCorreo";
        CCorreo.Size = new Size(422, 27);
        CCorreo.TabIndex = 4;
        // 
        // textBox6
        // 
        textBox6.Location = new Point(-260, -158);
        textBox6.Name = "textBox6";
        textBox6.Size = new Size(422, 27);
        textBox6.TabIndex = 4;
        // 
        // CContraseña
        // 
        CContraseña.Location = new Point(848, 556);
        CContraseña.Name = "CContraseña";
        CContraseña.Size = new Size(422, 27);
        CContraseña.TabIndex = 6;
        // 
        // Contraseña
        // 
        Contraseña.Location = new Point(848, 485);
        Contraseña.Name = "Contraseña";
        Contraseña.Size = new Size(422, 27);
        Contraseña.TabIndex = 5;
        // 
        // CancelarR
        // 
        CancelarR.BackColor = Color.Transparent;
        CancelarR.Location = new Point(1071, 622);
        CancelarR.Name = "CancelarR";
        CancelarR.Size = new Size(182, 28);
        CancelarR.TabIndex = 14;
        CancelarR.Text = "Cancelar";
        CancelarR.UseVisualStyleBackColor = false;
        CancelarR.Click += this.CancelarR_Click;
        // 
        // RegistrarseR
        // 
        RegistrarseR.BackColor = Color.Transparent;
        RegistrarseR.Location = new Point(853, 622);
        RegistrarseR.Name = "RegistrarseR";
        RegistrarseR.Size = new Size(185, 28);
        RegistrarseR.TabIndex = 13;
        RegistrarseR.Text = "Registrarse";
        RegistrarseR.UseVisualStyleBackColor = false;
        // 
        // Register
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        AutoValidate = AutoValidate.EnableAllowFocusChange;
        BackColor = SystemColors.ControlDarkDark;
        BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
        BackgroundImageLayout = ImageLayout.Zoom;
        ClientSize = new Size(1280, 711);
        Controls.Add(CancelarR);
        Controls.Add(RegistrarseR);
        Controls.Add(CContraseña);
        Controls.Add(Contraseña);
        Controls.Add(textBox6);
        Controls.Add(CCorreo);
        Controls.Add(Correo);
        Controls.Add(Nacimiento);
        Controls.Add(Apellido);
        Controls.Add(Nombre);
        Name = "Register";
        Text = "GranDT";
        Load += Login_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox Nombre;
    private TextBox Apellido;
    private TextBox Nacimiento;
    private TextBox Correo;
    private TextBox CCorreo;
    private TextBox textBox6;
    private TextBox CContraseña;
    private TextBox Contraseña;
    private Button CancelarR;
    private Button RegistrarseR;
}
