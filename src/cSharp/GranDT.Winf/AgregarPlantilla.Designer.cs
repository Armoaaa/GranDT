namespace GranDT.Winf
{
    partial class AgregarPlantilla
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
            SEquipos = new ComboBox();
            Confirmar = new Button();
            Cancelar = new Button();
            CoAS = new Label();
            label123 = new Label();
            TNombre = new TextBox();
            label65 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // SEquipos
            // 
            SEquipos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SEquipos.FormattingEnabled = true;
            SEquipos.Location = new Point(300, 215);
            SEquipos.Name = "SEquipos";
            SEquipos.Size = new Size(566, 23);
            SEquipos.TabIndex = 0;
            // 
            // Confirmar
            // 
            Confirmar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Confirmar.BackColor = Color.Transparent;
            Confirmar.BackgroundImage = Properties.Resources.Aceptar;
            Confirmar.BackgroundImageLayout = ImageLayout.Zoom;
            Confirmar.FlatStyle = FlatStyle.Flat;
            Confirmar.Location = new Point(300, 261);
            Confirmar.Name = "Confirmar";
            Confirmar.Size = new Size(201, 53);
            Confirmar.TabIndex = 1;
            Confirmar.UseVisualStyleBackColor = false;
            Confirmar.Click += Confirmar_Click;
            // 
            // Cancelar
            // 
            Cancelar.BackColor = Color.Transparent;
            Cancelar.BackgroundImage = Properties.Resources.Cancelar;
            Cancelar.BackgroundImageLayout = ImageLayout.Zoom;
            Cancelar.FlatStyle = FlatStyle.Flat;
            Cancelar.Location = new Point(664, 261);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(201, 53);
            Cancelar.TabIndex = 2;
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += Cancelar_Click;
            // 
            // CoAS
            // 
            CoAS.AutoSize = true;
            CoAS.Location = new Point(300, 197);
            CoAS.Name = "CoAS";
            CoAS.Size = new Size(47, 15);
            CoAS.TabIndex = 3;
            CoAS.Text = "Equipo ";
            // 
            // label123
            // 
            label123.AutoSize = true;
            label123.Location = new Point(300, 141);
            label123.Name = "label123";
            label123.Size = new Size(72, 15);
            label123.TabIndex = 5;
            label123.Text = "Presupuesto";
            // 
            // TNombre
            // 
            TNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TNombre.Location = new Point(300, 105);
            TNombre.Name = "TNombre";
            TNombre.Size = new Size(566, 23);
            TNombre.TabIndex = 6;
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Location = new Point(300, 87);
            label65.Name = "label65";
            label65.Size = new Size(51, 15);
            label65.TabIndex = 7;
            label65.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(311, 156);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 8;
            label1.Text = "65.000.000";
            // 
            // AgregarPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 527);
            Controls.Add(label1);
            Controls.Add(label65);
            Controls.Add(TNombre);
            Controls.Add(label123);
            Controls.Add(CoAS);
            Controls.Add(Cancelar);
            Controls.Add(Confirmar);
            Controls.Add(SEquipos);
            Name = "AgregarPlantilla";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditorPlantilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox SEquipos;
        private Button Confirmar;
        private Button Cancelar;
        private Label CoAS;
        private Label label123;
        private TextBox TNombre;
        private Label label65;
        private Label label1;
    }
}