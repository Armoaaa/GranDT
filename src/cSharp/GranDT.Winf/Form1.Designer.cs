namespace GranDT.Winf
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // textBox7
            // 
            textBox7.Location = new Point(821, 484);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(422, 27);
            textBox7.TabIndex = 10;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(821, 413);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(422, 27);
            textBox8.TabIndex = 9;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(819, 329);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(422, 27);
            textBox5.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(819, 258);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(422, 27);
            textBox4.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1263, 715);
            Controls.Add(textBox7);
            Controls.Add(textBox8);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox5;
        private TextBox textBox4;
    }
}