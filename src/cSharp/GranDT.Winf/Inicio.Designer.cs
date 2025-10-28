namespace GranDT.Winf;

partial class Inicio
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
        Reguistrarse = new Button();
        Login = new Button();
        SuspendLayout();
        // 
        // Reguistrarse
        // 
        Reguistrarse.Location = new Point(464, 295);
        Reguistrarse.Name = "Reguistrarse";
        Reguistrarse.Size = new Size(120, 42);
        Reguistrarse.TabIndex = 0;
        Reguistrarse.Text = "Reguistrarse";
        Reguistrarse.UseVisualStyleBackColor = true;
        Reguistrarse.Click += Reguistrarse_Click;
        // 
        // Login
        // 
        Login.Location = new Point(213, 295);
        Login.Name = "Login";
        Login.Size = new Size(120, 42);
        Login.TabIndex = 1;
        Login.Text = "Login";
        Login.UseVisualStyleBackColor = true;
        Login.Click += Login_Click;
        // 
        // Inicio
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(Login);
        Controls.Add(Reguistrarse);
        Name = "Inicio";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GranDT";
        Load += Inicio_Load;
        ResumeLayout(false);
    }

    #endregion

    private Button Reguistrarse;
    private Button Login;
}
