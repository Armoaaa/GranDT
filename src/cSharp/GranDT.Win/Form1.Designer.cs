namespace GranDT.Win;

partial class Form1
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
        B_Registrarse = new Button();
        B_Cancelar = new Button();
        SuspendLayout();
        // 
        // B_Registrarse
        // 
        B_Registrarse.Location = new Point(460, 320);
        B_Registrarse.Name = "B_Registrarse";
        B_Registrarse.Size = new Size(115, 23);
        B_Registrarse.TabIndex = 0;
        B_Registrarse.Text = "REGUISTRARSE";
        B_Registrarse.UseVisualStyleBackColor = true;
        // 
        // B_Cancelar
        // 
        B_Cancelar.Location = new Point(300, 320);
        B_Cancelar.Name = "B_Cancelar";
        B_Cancelar.Size = new Size(75, 23);
        B_Cancelar.TabIndex = 1;
        B_Cancelar.Text = "CANCELAR";
        B_Cancelar.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(B_Cancelar);
        Controls.Add(B_Registrarse);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button B_Registrarse;
    private Button B_Cancelar;
}
