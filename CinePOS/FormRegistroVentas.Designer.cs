namespace CinePOS
{
    partial class FormRegistroVentas
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
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotalCajaxDia = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnAplicarRangosFecha = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buscarID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RankingPelis = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RankingPelis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.Location = new System.Drawing.Point(0, 0);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 24;
            this.dgvVentas.Size = new System.Drawing.Size(500, 503);
            this.dgvVentas.TabIndex = 0;
            this.dgvVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(500, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(469, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ranking Por Peliculas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(500, 28);
            this.label5.TabIndex = 2;
            this.label5.Text = "Registro General";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 107);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(961, 28);
            this.panel4.TabIndex = 3;
            // 
            // lblTotalCajaxDia
            // 
            this.lblTotalCajaxDia.AutoSize = true;
            this.lblTotalCajaxDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCajaxDia.Location = new System.Drawing.Point(3, 76);
            this.lblTotalCajaxDia.Name = "lblTotalCajaxDia";
            this.lblTotalCajaxDia.Size = new System.Drawing.Size(53, 20);
            this.lblTotalCajaxDia.TabIndex = 1;
            this.lblTotalCajaxDia.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAplicarRangosFecha);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.dtpFechaIni);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(524, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 107);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccion de rango ";
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Location = new System.Drawing.Point(27, 39);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(180, 22);
            this.dtpFechaIni.TabIndex = 0;
            this.dtpFechaIni.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(257, 39);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(174, 22);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // btnAplicarRangosFecha
            // 
            this.btnAplicarRangosFecha.Location = new System.Drawing.Point(159, 67);
            this.btnAplicarRangosFecha.Name = "btnAplicarRangosFecha";
            this.btnAplicarRangosFecha.Size = new System.Drawing.Size(173, 34);
            this.btnAplicarRangosFecha.TabIndex = 2;
            this.btnAplicarRangosFecha.Text = "Buscar";
            this.btnAplicarRangosFecha.UseVisualStyleBackColor = true;
            this.btnAplicarRangosFecha.Click += new System.EventHandler(this.btnAplicarRangosFecha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Fin";
            // 
            // buscarID
            // 
            this.buscarID.Location = new System.Drawing.Point(340, 11);
            this.buscarID.Name = "buscarID";
            this.buscarID.Size = new System.Drawing.Size(144, 22);
            this.buscarID.TabIndex = 3;
            this.buscarID.TextChanged += new System.EventHandler(this.buscarID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Buscar por ID(folio de venta):";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buscarID);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblTotalCajaxDia);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 107);
            this.panel1.TabIndex = 0;
            // 
            // RankingPelis
            // 
            this.RankingPelis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RankingPelis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RankingPelis.Location = new System.Drawing.Point(0, 0);
            this.RankingPelis.Name = "RankingPelis";
            this.RankingPelis.ReadOnly = true;
            this.RankingPelis.RowHeadersVisible = false;
            this.RankingPelis.RowHeadersWidth = 51;
            this.RankingPelis.RowTemplate.Height = 24;
            this.RankingPelis.Size = new System.Drawing.Size(457, 503);
            this.RankingPelis.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 135);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AllowDrop = true;
            this.splitContainer1.Panel1.Controls.Add(this.dgvVentas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.RankingPelis);
            this.splitContainer1.Size = new System.Drawing.Size(961, 503);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 4;
            // 
            // FormRegistroVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(961, 638);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "FormRegistroVentas";
            this.Text = "FormRegistroVentas";
            this.Load += new System.EventHandler(this.FormRegistroVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RankingPelis)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTotalCajaxDia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView RankingPelis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAplicarRangosFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaIni;
        private System.Windows.Forms.TextBox buscarID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}