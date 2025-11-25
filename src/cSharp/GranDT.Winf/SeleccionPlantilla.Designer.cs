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
            SPlantilla = new ComboBox();
            Confirmar = new Button();
            Crear = new Button();
            Cerrar = new Button();
            SuspendLayout();
            // 
            // SPlantilla
            // 
            SPlantilla.FormattingEnabled = true;
            SPlantilla.Location = new Point(389, 136);
            SPlantilla.Margin = new Padding(3, 4, 3, 4);
            SPlantilla.Name = "SPlantilla";
            SPlantilla.Size = new Size(137, 28);
            SPlantilla.TabIndex = 2;
            SPlantilla.SelectedIndexChanged += SPlantilla_SelectedIndexChanged;
            // 
            // Confirmar
            // 
            Confirmar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Confirmar.Location = new Point(864, 396);
            Confirmar.Margin = new Padding(3, 4, 3, 4);
            Confirmar.Name = "Confirmar";
            Confirmar.Size = new Size(162, 31);
            Confirmar.TabIndex = 3;
            Confirmar.Text = "Confirmar seleccion";
            Confirmar.UseVisualStyleBackColor = true;
            Confirmar.Click += Confirmar_Click;
            // 
            // Crear
            // 
            Crear.Location = new Point(286, 396);
            Crear.Margin = new Padding(3, 4, 3, 4);
            Crear.Name = "Crear";
            Crear.Size = new Size(153, 31);
            Crear.TabIndex = 4;
            Crear.Text = "Crear plantilla";
            Crear.UseVisualStyleBackColor = true;
            Crear.Click += Crear_Click;
            // 
            // Cerrar
            // 
            Cerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Cerrar.Location = new Point(1201, 16);
            Cerrar.Margin = new Padding(3, 4, 3, 4);
            Cerrar.Name = "Cerrar";
            Cerrar.Size = new Size(118, 31);
            Cerrar.TabIndex = 5;
            Cerrar.Text = "Cerrar cuenta";
            Cerrar.UseVisualStyleBackColor = true;
            Cerrar.Click += Cerrar_Click;
            // 
            // SeleccionPlantilla
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 703);
            Controls.Add(Cerrar);
            Controls.Add(Crear);
            Controls.Add(Confirmar);
            Controls.Add(SPlantilla);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SeleccionPlantilla";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Equipos";
            Load += Equipos_Load;
            ResumeLayout(false);
        }

        #endregion
        private ComboBox SPlantilla;
        private Button Confirmar;
        private Button Crear;
        private Button Cerrar;
    }
}