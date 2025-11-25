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
        Login.Image = (Image)resources.GetObject("Login.Image");
        Login.Location = new Point(684, 430);
        Login.Name = "Login";
        Login.Size = new Size(344, 103);
        Login.SizeMode = PictureBoxSizeMode.Zoom;
        Login.TabIndex = 2;
        Login.TabStop = false;
        Login.Click += Login_Click_1;
        // 
        // Reguistrarse
        // 
        Reguistrarse.Anchor = AnchorStyles.None;
        Reguistrarse.Image = (Image)resources.GetObject("Reguistrarse.Image");
        Reguistrarse.Location = new Point(318, 430);
        Reguistrarse.Name = "Reguistrarse";
        Reguistrarse.Size = new Size(344, 103);
        Reguistrarse.SizeMode = PictureBoxSizeMode.Zoom;
        Reguistrarse.TabIndex = 3;
        Reguistrarse.TabStop = false;
        Reguistrarse.Click += Reguistrarse_Click_1;
        // 
        // Inicio
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1332, 703);
        Controls.Add(Reguistrarse);
        Controls.Add(Login);
        Margin = new Padding(3, 4, 3, 4);
        Name = "Inicio";
        StartPosition = FormStartPosition.CenterScreen;
        Text = " ";
        Load += Inicio_Load;
        ((System.ComponentModel.ISupportInitialize)Login).EndInit();
        ((System.ComponentModel.ISupportInitialize)Reguistrarse).EndInit();
        ResumeLayout(false);
    }

    #endregion
    private PictureBox Login;
    private PictureBox Reguistrarse;
}
