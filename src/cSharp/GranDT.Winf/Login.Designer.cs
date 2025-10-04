    namespace GranDT.Winf;

partial class Login
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        textBox3 = new TextBox();
        textBox4 = new TextBox();
        textBox5 = new TextBox();
        textBox6 = new TextBox();
        textBox7 = new TextBox();
        textBox8 = new TextBox();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.Location = new Point(846, 182);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(192, 27);
        textBox1.TabIndex = 0;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(1078, 181);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(192, 27);
        textBox2.TabIndex = 1;
        // 
        // textBox3
        // 
        textBox3.Location = new Point(846, 257);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(192, 27);
        textBox3.TabIndex = 2;
        // 
        // textBox4
        // 
        textBox4.Location = new Point(846, 330);
        textBox4.Name = "textBox4";
        textBox4.Size = new Size(422, 27);
        textBox4.TabIndex = 3;
        // 
        // textBox5
        // 
        textBox5.Location = new Point(846, 401);
        textBox5.Name = "textBox5";
        textBox5.Size = new Size(422, 27);
        textBox5.TabIndex = 4;
        // 
        // textBox6
        // 
        textBox6.Location = new Point(-260, -158);
        textBox6.Name = "textBox6";
        textBox6.Size = new Size(422, 27);
        textBox6.TabIndex = 4;
        // 
        // textBox7
        // 
        textBox7.Location = new Point(848, 556);
        textBox7.Name = "textBox7";
        textBox7.Size = new Size(422, 27);
        textBox7.TabIndex = 6;
        // 
        // textBox8
        // 
        textBox8.Location = new Point(848, 485);
        textBox8.Name = "textBox8";
        textBox8.Size = new Size(422, 27);
        textBox8.TabIndex = 5;
        // 
        // Login
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        AutoValidate = AutoValidate.EnableAllowFocusChange;
        BackColor = SystemColors.ControlDarkDark;
        BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
        BackgroundImageLayout = ImageLayout.Zoom;
        ClientSize = new Size(1280, 711);
        Controls.Add(textBox7);
        Controls.Add(textBox8);
        Controls.Add(textBox6);
        Controls.Add(textBox5);
        Controls.Add(textBox4);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Name = "Login";
        Text = "Form1";
        Load += Login_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox7;
    private TextBox textBox8;
}
