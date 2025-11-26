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
            dataGridView1.Location = new Point(219, 96);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(928, 348);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // idFutbolistaDataGridViewTextBoxColumn
            // 
            idFutbolistaDataGridViewTextBoxColumn.DataPropertyName = "IdFutbolista";
            idFutbolistaDataGridViewTextBoxColumn.HeaderText = "IdFutbolista";
            idFutbolistaDataGridViewTextBoxColumn.MinimumWidth = 6;
            idFutbolistaDataGridViewTextBoxColumn.Name = "idFutbolistaDataGridViewTextBoxColumn";
            idFutbolistaDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            apellidoDataGridViewTextBoxColumn.MinimumWidth = 6;
            apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            apellidoDataGridViewTextBoxColumn.Width = 125;
            // 
            // apodoDataGridViewTextBoxColumn
            // 
            apodoDataGridViewTextBoxColumn.DataPropertyName = "Apodo";
            apodoDataGridViewTextBoxColumn.HeaderText = "Apodo";
            apodoDataGridViewTextBoxColumn.MinimumWidth = 6;
            apodoDataGridViewTextBoxColumn.Name = "apodoDataGridViewTextBoxColumn";
            apodoDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechadeNacimientoDataGridViewTextBoxColumn
            // 
            fechadeNacimientoDataGridViewTextBoxColumn.DataPropertyName = "FechadeNacimiento";
            fechadeNacimientoDataGridViewTextBoxColumn.HeaderText = "FechadeNacimiento";
            fechadeNacimientoDataGridViewTextBoxColumn.MinimumWidth = 6;
            fechadeNacimientoDataGridViewTextBoxColumn.Name = "fechadeNacimientoDataGridViewTextBoxColumn";
            fechadeNacimientoDataGridViewTextBoxColumn.Width = 125;
            // 
            // cotizacionDataGridViewTextBoxColumn
            // 
            cotizacionDataGridViewTextBoxColumn.DataPropertyName = "Cotizacion";
            cotizacionDataGridViewTextBoxColumn.HeaderText = "Cotizacion";
            cotizacionDataGridViewTextBoxColumn.MinimumWidth = 6;
            cotizacionDataGridViewTextBoxColumn.Name = "cotizacionDataGridViewTextBoxColumn";
            cotizacionDataGridViewTextBoxColumn.Width = 125;
            // 
            // puntuacionesDataGridViewTextBoxColumn
            // 
            puntuacionesDataGridViewTextBoxColumn.DataPropertyName = "Puntuaciones";
            puntuacionesDataGridViewTextBoxColumn.HeaderText = "Puntuaciones";
            puntuacionesDataGridViewTextBoxColumn.MinimumWidth = 6;
            puntuacionesDataGridViewTextBoxColumn.Name = "puntuacionesDataGridViewTextBoxColumn";
            puntuacionesDataGridViewTextBoxColumn.Width = 125;
            // 
            // futbolistaBindingSource
            // 
            futbolistaBindingSource.DataSource = typeof(Core.Futbolista);
            // 
            // Confirmar
            // 
            Confirmar.Location = new Point(1007, 474);
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
            FutbolistaListado.Location = new Point(219, 474);
            FutbolistaListado.Name = "FutbolistaListado";
            FutbolistaListado.Size = new Size(203, 23);
            FutbolistaListado.TabIndex = 2;
            FutbolistaListado.SelectedIndexChanged += FutbolistaListado_SelectedIndexChanged;
            // 
            // SeleccionJugador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1334, 711);
            Controls.Add(FutbolistaListado);
            Controls.Add(Confirmar);
            Controls.Add(dataGridView1);
            Name = "SeleccionJugador";
            StartPosition = FormStartPosition.CenterScreen;
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