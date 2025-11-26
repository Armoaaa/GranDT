namespace GranDT.Winf
{
    partial class AltaPuntuacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboFutbolista = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechaNro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPuntos = new System.Windows.Forms.TextBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Futbolista";
            // 
            // cboFutbolista
            // 
            this.cboFutbolista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFutbolista.FormattingEnabled = true;
            this.cboFutbolista.Location = new System.Drawing.Point(24, 42);
            this.cboFutbolista.Name = "cboFutbolista";
            this.cboFutbolista.Size = new System.Drawing.Size(322, 28);
            this.cboFutbolista.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Nro";
            // 
            // txtFechaNro
            // 
            this.txtFechaNro.Location = new System.Drawing.Point(24, 105);
            this.txtFechaNro.Name = "txtFechaNro";
            this.txtFechaNro.Size = new System.Drawing.Size(100, 27);
            this.txtFechaNro.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Puntos";
            // 
            // txtPuntos
            // 
            this.txtPuntos.Location = new System.Drawing.Point(24, 168);
            this.txtPuntos.Name = "txtPuntos";
            this.txtPuntos.Size = new System.Drawing.Size(100, 27);
            this.txtPuntos.TabIndex = 5;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(24, 210);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(122, 34);
            this.buttonGuardar.TabIndex = 6;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // AltaPuntuacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 266);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.txtPuntos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFechaNro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFutbolista);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaPuntuacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta Puntuación";
            this.Load += new System.EventHandler(this.AltaPuntuacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFutbolista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFechaNro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPuntos;
        private System.Windows.Forms.Button buttonGuardar;
    }
}
