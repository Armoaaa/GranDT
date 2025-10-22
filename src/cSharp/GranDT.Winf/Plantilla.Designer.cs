namespace GranDT.Winf
{
    partial class Plantilla
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
            checkedListBox1 = new CheckedListBox();
            label1 = new Label();
            button1 = new Button();
            Arquero = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(637, 30);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(151, 346);
            checkedListBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(676, 9);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Jugadores";
            // 
            // button1
            // 
            button1.Location = new Point(676, 395);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Confirmar";
            button1.UseVisualStyleBackColor = true;
            // 
            // Arquero
            // 
            Arquero.Location = new Point(302, 395);
            Arquero.Name = "Arquero";
            Arquero.Size = new Size(75, 23);
            Arquero.TabIndex = 3;
            Arquero.Text = "Arquero";
            Arquero.UseVisualStyleBackColor = true;
            Arquero.Click += button2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(82, 342);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "DefensaI1";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(515, 342);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "DefensaD2";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(217, 342);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 6;
            button4.Text = "DefensaI1";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(302, 113);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 7;
            button5.Text = "Delantero";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(163, 87);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 8;
            button6.Text = "DelanteroI";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(445, 87);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 9;
            button7.Text = "DelanteroD";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(302, 214);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 10;
            button8.Text = "Medio";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(423, 214);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 11;
            button9.Text = "MedioD";
            button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Location = new Point(193, 214);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 12;
            button10.Text = "MedioI";
            button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(388, 342);
            button11.Name = "button11";
            button11.Size = new Size(75, 23);
            button11.TabIndex = 13;
            button11.Text = "DefensaD1";
            button11.UseVisualStyleBackColor = true;
            // 
            // Plantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(Arquero);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Name = "Plantilla";
            Text = "Plantilla";
            Load += Plantilla_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Label label1;
        private Button button1;
        private Button Arquero;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
    }
}