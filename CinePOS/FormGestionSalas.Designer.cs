namespace CinePOS
{
    partial class FormGestionSalas
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.txtNombreSala = new System.Windows.Forms.TextBox();
            this.cmbTipoSala = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numColumnas = new System.Windows.Forms.NumericUpDown();
            this.numFilas = new System.Windows.Forms.NumericUpDown();
            this.lblColumnas = new System.Windows.Forms.Label();
            this.lblFilas = new System.Windows.Forms.Label();
            this.dgvSalas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColumnas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(936, 752);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 51);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(793, 752);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 51);
            this.button2.TabIndex = 4;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Location = new System.Drawing.Point(644, 752);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(142, 51);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.Controls.Add(this.txtNombreSala);
            this.GroupBox.Controls.Add(this.cmbTipoSala);
            this.GroupBox.Controls.Add(this.lblTipo);
            this.GroupBox.Controls.Add(this.lblNombre);
            this.GroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox.Location = new System.Drawing.Point(617, 18);
            this.GroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox.Size = new System.Drawing.Size(466, 405);
            this.GroupBox.TabIndex = 6;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Datos Basicos";
            // 
            // txtNombreSala
            // 
            this.txtNombreSala.Location = new System.Drawing.Point(28, 75);
            this.txtNombreSala.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreSala.Name = "txtNombreSala";
            this.txtNombreSala.Size = new System.Drawing.Size(235, 34);
            this.txtNombreSala.TabIndex = 3;
            // 
            // cmbTipoSala
            // 
            this.cmbTipoSala.FormattingEnabled = true;
            this.cmbTipoSala.Items.AddRange(new object[] {
            "2D",
            "3D",
            "4DX"});
            this.cmbTipoSala.Location = new System.Drawing.Point(28, 182);
            this.cmbTipoSala.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTipoSala.Name = "cmbTipoSala";
            this.cmbTipoSala.Size = new System.Drawing.Size(113, 37);
            this.cmbTipoSala.TabIndex = 2;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(23, 153);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(153, 29);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo de sala:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(23, 45);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(315, 29);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Inserta el nombre de la sala:";
            this.lblNombre.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numColumnas);
            this.groupBox1.Controls.Add(this.numFilas);
            this.groupBox1.Controls.Add(this.lblColumnas);
            this.groupBox1.Controls.Add(this.lblFilas);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(617, 306);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(466, 264);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimensiones de la sala";
            // 
            // numColumnas
            // 
            this.numColumnas.Location = new System.Drawing.Point(29, 189);
            this.numColumnas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numColumnas.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numColumnas.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numColumnas.Name = "numColumnas";
            this.numColumnas.Size = new System.Drawing.Size(165, 34);
            this.numColumnas.TabIndex = 3;
            this.numColumnas.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numColumnas.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numFilas
            // 
            this.numFilas.Location = new System.Drawing.Point(29, 74);
            this.numFilas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numFilas.Maximum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.numFilas.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFilas.Name = "numFilas";
            this.numFilas.Size = new System.Drawing.Size(165, 34);
            this.numFilas.TabIndex = 2;
            this.numFilas.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblColumnas
            // 
            this.lblColumnas.AutoSize = true;
            this.lblColumnas.Location = new System.Drawing.Point(25, 154);
            this.lblColumnas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnas.Name = "lblColumnas";
            this.lblColumnas.Size = new System.Drawing.Size(356, 29);
            this.lblColumnas.TabIndex = 1;
            this.lblColumnas.Text = "Indique el numero de columnas:";
            // 
            // lblFilas
            // 
            this.lblFilas.AutoSize = true;
            this.lblFilas.Location = new System.Drawing.Point(25, 45);
            this.lblFilas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilas.Name = "lblFilas";
            this.lblFilas.Size = new System.Drawing.Size(296, 29);
            this.lblFilas.TabIndex = 0;
            this.lblFilas.Text = "Indique el numero de filas:";
            // 
            // dgvSalas
            // 
            this.dgvSalas.AllowUserToAddRows = false;
            this.dgvSalas.AllowUserToDeleteRows = false;
            this.dgvSalas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalas.Location = new System.Drawing.Point(16, 16);
            this.dgvSalas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSalas.Name = "dgvSalas";
            this.dgvSalas.ReadOnly = true;
            this.dgvSalas.RowHeadersWidth = 51;
            this.dgvSalas.RowTemplate.Height = 24;
            this.dgvSalas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalas.Size = new System.Drawing.Size(593, 786);
            this.dgvSalas.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(619, 594);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(465, 150);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Precios y asientos";
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(77, 106);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(378, 52);
            this.button3.TabIndex = 1;
            this.button3.Text = "Habilitar/deshabilitar asientos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(117, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Precios por tipo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FormGestionSalas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 820);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvSalas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnGuardar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormGestionSalas";
            this.Text = "FormGestionSalas";
            this.Load += new System.EventHandler(this.FormGestionSalas_Load_1);
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColumnas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombreSala;
        private System.Windows.Forms.ComboBox cmbTipoSala;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numColumnas;
        private System.Windows.Forms.Label lblColumnas;
        private System.Windows.Forms.Label lblFilas;
        private System.Windows.Forms.NumericUpDown numFilas;
        private System.Windows.Forms.DataGridView dgvSalas;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}