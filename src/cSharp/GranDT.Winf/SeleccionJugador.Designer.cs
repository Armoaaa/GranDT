namespace GranDT.Winf
{
    partial class SeleccionJugador
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            idFutbolistaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            apellidoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            apodoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechadeNacimientoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cotizacionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            puntuacionesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            futbolistaBindingSource = new BindingSource(components);
            Confirmar = new Button();
            FutbolistaListado = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)futbolistaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idFutbolistaDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, apellidoDataGridViewTextBoxColumn, apodoDataGridViewTextBoxColumn, fechadeNacimientoDataGridViewTextBoxColumn, cotizacionDataGridViewTextBoxColumn, puntuacionesDataGridViewTextBoxColumn });
            dataGridView1.DataSource = futbolistaBindingSource;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(745, 348);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // idFutbolistaDataGridViewTextBoxColumn
            // 
            idFutbolistaDataGridViewTextBoxColumn.DataPropertyName = "IdFutbolista";
            idFutbolistaDataGridViewTextBoxColumn.HeaderText = "IdFutbolista";
            idFutbolistaDataGridViewTextBoxColumn.Name = "idFutbolistaDataGridViewTextBoxColumn";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            // 
            // apodoDataGridViewTextBoxColumn
            // 
            apodoDataGridViewTextBoxColumn.DataPropertyName = "Apodo";
            apodoDataGridViewTextBoxColumn.HeaderText = "Apodo";
            apodoDataGridViewTextBoxColumn.Name = "apodoDataGridViewTextBoxColumn";
            // 
            // fechadeNacimientoDataGridViewTextBoxColumn
            // 
            fechadeNacimientoDataGridViewTextBoxColumn.DataPropertyName = "FechadeNacimiento";
            fechadeNacimientoDataGridViewTextBoxColumn.HeaderText = "FechadeNacimiento";
            fechadeNacimientoDataGridViewTextBoxColumn.Name = "fechadeNacimientoDataGridViewTextBoxColumn";
            // 
            // cotizacionDataGridViewTextBoxColumn
            // 
            cotizacionDataGridViewTextBoxColumn.DataPropertyName = "Cotizacion";
            cotizacionDataGridViewTextBoxColumn.HeaderText = "Cotizacion";
            cotizacionDataGridViewTextBoxColumn.Name = "cotizacionDataGridViewTextBoxColumn";
            // 
            // puntuacionesDataGridViewTextBoxColumn
            // 
            puntuacionesDataGridViewTextBoxColumn.DataPropertyName = "Puntuaciones";
            puntuacionesDataGridViewTextBoxColumn.HeaderText = "Puntuaciones";
            puntuacionesDataGridViewTextBoxColumn.Name = "puntuacionesDataGridViewTextBoxColumn";
            // 
            // futbolistaBindingSource
            // 
            futbolistaBindingSource.DataSource = typeof(Core.Futbolista);
            // 
            // Confirmar
            // 
            Confirmar.Location = new Point(604, 388);
            Confirmar.Name = "Confirmar";
            Confirmar.Size = new Size(140, 50);
            Confirmar.TabIndex = 1;
            Confirmar.Text = "Confirmar";
            Confirmar.UseVisualStyleBackColor = true;
            Confirmar.Click += Confirmar_Click;
            // 
            // FutbolistaListado
            // 
            FutbolistaListado.FormattingEnabled = true;
            FutbolistaListado.Location = new Point(12, 415);
            FutbolistaListado.Name = "FutbolistaListado";
            FutbolistaListado.Size = new Size(203, 23);
            FutbolistaListado.TabIndex = 2;
            FutbolistaListado.SelectedIndexChanged += FutbolistaListado_SelectedIndexChanged;
            // 
            // SeleccionJugador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FutbolistaListado);
            Controls.Add(Confirmar);
            Controls.Add(dataGridView1);
            Name = "SeleccionJugador";
            Text = "SeleccionJugador";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)futbolistaBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idFutbolistaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn apodoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechadeNacimientoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cotizacionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn puntuacionesDataGridViewTextBoxColumn;
        private BindingSource futbolistaBindingSource;
        private Button Confirmar;
        private ComboBox FutbolistaListado;
    }
}