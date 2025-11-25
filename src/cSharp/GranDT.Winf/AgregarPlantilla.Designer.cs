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
            TPresupuesto = new TextBox();
            label123 = new Label();
            TNombre = new TextBox();
            label65 = new Label();
            SuspendLayout();
            // 
            // SEquipos
            // 
            SEquipos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SEquipos.FormattingEnabled = true;
            SEquipos.Location = new Point(343, 287);
            SEquipos.Margin = new Padding(3, 4, 3, 4);
            SEquipos.Name = "SEquipos";
            SEquipos.Size = new Size(646, 28);
            SEquipos.TabIndex = 0;
            // 
            // Confirmar
            // 
            Confirmar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Confirmar.BackColor = Color.Transparent;
            Confirmar.BackgroundImage = Properties.Resources.Aceptar;
            Confirmar.BackgroundImageLayout = ImageLayout.Zoom;
            Confirmar.Location = new Point(343, 348);
            Confirmar.Margin = new Padding(3, 4, 3, 4);
            Confirmar.Name = "Confirmar";
            Confirmar.Size = new Size(230, 71);
            Confirmar.TabIndex = 1;
            Confirmar.UseVisualStyleBackColor = false;
            Confirmar.Click += Confirmar_Click;
            // 
            // Cancelar
            // 
            Cancelar.BackColor = Color.Transparent;
            Cancelar.BackgroundImage = Properties.Resources.Cancelar;
            Cancelar.BackgroundImageLayout = ImageLayout.Zoom;
            Cancelar.Location = new Point(759, 348);
            Cancelar.Margin = new Padding(3, 4, 3, 4);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(230, 71);
            Cancelar.TabIndex = 2;
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += Cancelar_Click;
            // 
            // CoAS
            // 
            CoAS.AutoSize = true;
            CoAS.Location = new Point(343, 263);
            CoAS.Name = "CoAS";
            CoAS.Size = new Size(60, 20);
            CoAS.TabIndex = 3;
            CoAS.Text = "Equipo ";
            // 
            // TPresupuesto
            // 
            TPresupuesto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TPresupuesto.Location = new Point(343, 212);
            TPresupuesto.Margin = new Padding(3, 4, 3, 4);
            TPresupuesto.Name = "TPresupuesto";
            TPresupuesto.Size = new Size(646, 27);
            TPresupuesto.TabIndex = 4;
            // 
            // label123
            // 
            label123.AutoSize = true;
            label123.Location = new Point(343, 188);
            label123.Name = "label123";
            label123.Size = new Size(89, 20);
            label123.TabIndex = 5;
            label123.Text = "Presupuesto";
            // 
            // TNombre
            // 
            TNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TNombre.Location = new Point(343, 140);
            TNombre.Margin = new Padding(3, 4, 3, 4);
            TNombre.Name = "TNombre";
            TNombre.Size = new Size(646, 27);
            TNombre.TabIndex = 6;
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Location = new Point(343, 116);
            label65.Name = "label65";
            label65.Size = new Size(64, 20);
            label65.TabIndex = 7;
            label65.Text = "Nombre";
            // 
            // AgregarPlantilla
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 703);
            Controls.Add(label65);
            Controls.Add(TNombre);
            Controls.Add(label123);
            Controls.Add(TPresupuesto);
            Controls.Add(CoAS);
            Controls.Add(Cancelar);
            Controls.Add(Confirmar);
            Controls.Add(SEquipos);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AgregarPlantilla";
            Text = "EditorPlantilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox SEquipos;
        private Button Confirmar;
        private Button Cancelar;
        private Label CoAS;
        private TextBox TPresupuesto;
        private Label label123;
        private TextBox TNombre;
        private Label label65;
    }
}