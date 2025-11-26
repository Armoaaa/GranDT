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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
        Login = new PictureBox();
        Reguistrarse = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)Login).BeginInit();
        ((System.ComponentModel.ISupportInitialize)Reguistrarse).BeginInit();
        SuspendLayout();
        // 
        // Login
        // 
        Login.BackColor = Color.Transparent;
        Login.Image = (Image)resources.GetObject("Login.Image");
        Login.Location = new Point(598, 322);
        Login.Margin = new Padding(3, 2, 3, 2);
        Login.Name = "Login";
        Login.Size = new Size(301, 77);
        Login.SizeMode = PictureBoxSizeMode.Zoom;
        Login.TabIndex = 2;
        Login.TabStop = false;
        Login.Click += Login_Click_1;
        // 
        // Reguistrarse
        // 
        Reguistrarse.Anchor = AnchorStyles.None;
        Reguistrarse.BackColor = Color.Transparent;
        Reguistrarse.Image = (Image)resources.GetObject("Reguistrarse.Image");
        Reguistrarse.Location = new Point(278, 322);
        Reguistrarse.Margin = new Padding(3, 2, 3, 2);
        Reguistrarse.Name = "Reguistrarse";
        Reguistrarse.Size = new Size(301, 77);
        Reguistrarse.SizeMode = PictureBoxSizeMode.Zoom;
        Reguistrarse.TabIndex = 3;
        Reguistrarse.TabStop = false;
        Reguistrarse.Click += Reguistrarse_Click_1;
        // 
        // Inicio
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = Properties.Resources.Fondo_generico;
        ClientSize = new Size(1166, 527);
        Controls.Add(Reguistrarse);
        Controls.Add(Login);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Inicio";
        StartPosition = FormStartPosition.CenterScreen;
        Text = " GranDT";
        Load += Inicio_Load;
        ((System.ComponentModel.ISupportInitialize)Login).EndInit();
        ((System.ComponentModel.ISupportInitialize)Reguistrarse).EndInit();
        ResumeLayout(false);
    }

    #endregion
    private PictureBox Login;
    private PictureBox Reguistrarse;
}
