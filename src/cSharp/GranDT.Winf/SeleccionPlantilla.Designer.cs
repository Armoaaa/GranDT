namespace GranDT.Winf
{
    partial class SeleccionPlantilla
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
            Crear = new Button();
            Cerrar = new Button();
            SuspendLayout();
            // 
            // SEquipos
            // 
            SEquipos.FormattingEnabled = true;
            SEquipos.Location = new Point(325, 102);
            SEquipos.Name = "SEquipos";
            SEquipos.Size = new Size(121, 23);
            SEquipos.TabIndex = 2;
            // 
            // Confirmar
            // 
            Confirmar.Location = new Point(390, 297);
            Confirmar.Name = "Confirmar";
            Confirmar.Size = new Size(142, 23);
            Confirmar.TabIndex = 3;
            Confirmar.Text = "Confirmar seleccion";
            Confirmar.UseVisualStyleBackColor = true;
            Confirmar.Click += Confirmar_Click;
            // 
            // Crear
            // 
            Crear.Location = new Point(250, 297);
            Crear.Name = "Crear";
            Crear.Size = new Size(134, 23);
            Crear.TabIndex = 4;
            Crear.Text = "Crear plantilla";
            Crear.UseVisualStyleBackColor = true;
            Crear.Click += Crear_Click;
            // 
            // Cerrar
            // 
            Cerrar.Location = new Point(685, 12);
            Cerrar.Name = "Cerrar";
            Cerrar.Size = new Size(103, 23);
            Cerrar.TabIndex = 5;
            Cerrar.Text = "Cerrar cuenta";
            Cerrar.UseVisualStyleBackColor = true;
            Cerrar.Click += Cerrar_Click;
            // 
            // SeleccionPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Cerrar);
            Controls.Add(Crear);
            Controls.Add(Confirmar);
            Controls.Add(SEquipos);
            Name = "SeleccionPlantilla";
            Text = "Equipos";
            Load += Equipos_Load;
            ResumeLayout(false);
        }

        #endregion
        private ComboBox SEquipos;
        private Button Confirmar;
        private Button Crear;
        private Button Cerrar;
    }
}