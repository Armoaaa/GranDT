namespace GranDT.Winf
{
    partial class Equipos
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
            listBox1 = new ListBox();
            Confirmar = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(272, 22);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(226, 229);
            listBox1.TabIndex = 0;
            // 
            // Confirmar
            // 
            Confirmar.Location = new Point(346, 304);
            Confirmar.Name = "Confirmar";
            Confirmar.Size = new Size(75, 23);
            Confirmar.TabIndex = 1;
            Confirmar.Text = "Confirmar";
            Confirmar.UseVisualStyleBackColor = true;
            Confirmar.Click += Confirmar_Click;
            // 
            // Equipos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Confirmar);
            Controls.Add(listBox1);
            Name = "Equipos";
            Text = "Equipos";
            Load += Equipos_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button Confirmar;
    }
}