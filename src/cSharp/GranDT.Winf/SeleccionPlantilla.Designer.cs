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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionPlantilla));
            SPlantilla = new ComboBox();
            Confirmar = new Button();
            Crear = new Button();
            Cerrar = new Button();
            SuspendLayout();
            // 
            // SPlantilla
            // 
            SPlantilla.FormattingEnabled = true;
            SPlantilla.Location = new Point(392, 137);
            SPlantilla.Name = "SPlantilla";
            SPlantilla.Size = new Size(313, 23);
            SPlantilla.TabIndex = 2;
            SPlantilla.SelectedIndexChanged += SPlantilla_SelectedIndexChanged;
            // 
            // Confirmar
            // 
            Confirmar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Confirmar.BackColor = Color.Transparent;
            Confirmar.BackgroundImage = Properties.Resources.ConfirmarSeleccion;
            Confirmar.BackgroundImageLayout = ImageLayout.Zoom;
            Confirmar.FlatStyle = FlatStyle.Flat;
            Confirmar.Location = new Point(634, 240);
            Confirmar.Name = "Confirmar";
            Confirmar.Size = new Size(255, 89);
            Confirmar.TabIndex = 3;
            Confirmar.UseVisualStyleBackColor = false;
            Confirmar.Click += Confirmar_Click;
            // 
            // Crear
            // 
            Crear.BackColor = Color.Transparent;
            Crear.BackgroundImage = Properties.Resources.CrearPlantilla;
            Crear.BackgroundImageLayout = ImageLayout.Zoom;
            Crear.FlatStyle = FlatStyle.Flat;
            Crear.Location = new Point(273, 240);
            Crear.Name = "Crear";
            Crear.Size = new Size(253, 89);
            Crear.TabIndex = 4;
            Crear.UseVisualStyleBackColor = false;
            Crear.Click += Crear_Click;
            // 
            // Cerrar
            // 
            Cerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Cerrar.Location = new Point(1051, 12);
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
            BackgroundImage = Properties.Resources.Fondo_generico;
            ClientSize = new Size(1166, 527);
            Controls.Add(Cerrar);
            Controls.Add(Crear);
            Controls.Add(Confirmar);
            Controls.Add(SPlantilla);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SeleccionPlantilla";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GranDT";
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