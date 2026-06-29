namespace CinePOS
{
    partial class FormCartelera
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flpHorarios = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Cartelera = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.posterPeli = new System.Windows.Forms.PictureBox();
            this.lblSinopsis = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.PanelDeFechas = new System.Windows.Forms.Panel();
            this.PanelFechas = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posterPeli)).BeginInit();
            this.PanelDeFechas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 408);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione una pelicula";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(163, 356);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.flpHorarios);
            this.panel2.Location = new System.Drawing.Point(412, 141);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(386, 307);
            this.panel2.TabIndex = 1;
            // 
            // flpHorarios
            // 
            this.flpHorarios.AutoScroll = true;
            this.flpHorarios.AutoSize = true;
            this.flpHorarios.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpHorarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpHorarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpHorarios.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpHorarios.Location = new System.Drawing.Point(0, 0);
            this.flpHorarios.Name = "flpHorarios";
            this.flpHorarios.Size = new System.Drawing.Size(386, 307);
            this.flpHorarios.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Cartelera);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 39);
            this.panel3.TabIndex = 2;
            // 
            // Cartelera
            // 
            this.Cartelera.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Cartelera.Dock = System.Windows.Forms.DockStyle.Left;
            this.Cartelera.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cartelera.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Cartelera.Location = new System.Drawing.Point(0, 0);
            this.Cartelera.Name = "Cartelera";
            this.Cartelera.Size = new System.Drawing.Size(409, 39);
            this.Cartelera.TabIndex = 1;
            this.Cartelera.Text = "Cartelera";
            this.Cartelera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Horarios por pelicula";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.posterPeli);
            this.panel4.Controls.Add(this.lblSinopsis);
            this.panel4.Controls.Add(this.lblDuracion);
            this.panel4.Controls.Add(this.lblClasificacion);
            this.panel4.Controls.Add(this.lblTitulo);
            this.panel4.Location = new System.Drawing.Point(192, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(217, 408);
            this.panel4.TabIndex = 3;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // posterPeli
            // 
            this.posterPeli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.posterPeli.Location = new System.Drawing.Point(3, 36);
            this.posterPeli.Name = "posterPeli";
            this.posterPeli.Size = new System.Drawing.Size(209, 236);
            this.posterPeli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.posterPeli.TabIndex = 4;
            this.posterPeli.TabStop = false;
            // 
            // lblSinopsis
            // 
            this.lblSinopsis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblSinopsis.Location = new System.Drawing.Point(5, 353);
            this.lblSinopsis.Name = "lblSinopsis";
            this.lblSinopsis.Size = new System.Drawing.Size(208, 46);
            this.lblSinopsis.TabIndex = 3;
            this.lblSinopsis.Text = "label6";
            // 
            // lblDuracion
            // 
            this.lblDuracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(2, 322);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(44, 16);
            this.lblDuracion.TabIndex = 2;
            this.lblDuracion.Text = "label5";
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblClasificacion.Location = new System.Drawing.Point(2, 289);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(44, 16);
            this.lblClasificacion.TabIndex = 1;
            this.lblClasificacion.Text = "label4";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(3, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(52, 18);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "label3";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // PanelDeFechas
            // 
            this.PanelDeFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDeFechas.AutoScroll = true;
            this.PanelDeFechas.AutoSize = true;
            this.PanelDeFechas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelDeFechas.Controls.Add(this.PanelFechas);
            this.PanelDeFechas.Location = new System.Drawing.Point(409, 67);
            this.PanelDeFechas.Name = "PanelDeFechas";
            this.PanelDeFechas.Size = new System.Drawing.Size(389, 47);
            this.PanelDeFechas.TabIndex = 4;
            // 
            // PanelFechas
            // 
            this.PanelFechas.AutoSize = true;
            this.PanelFechas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelFechas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelFechas.Location = new System.Drawing.Point(0, 0);
            this.PanelFechas.Name = "PanelFechas";
            this.PanelFechas.Size = new System.Drawing.Size(385, 43);
            this.PanelFechas.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(409, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Funciones por dia";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(407, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(391, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Formato-Sala-Horario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormCartelera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PanelDeFechas);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormCartelera";
            this.Text = "FormCartelera";
            this.Load += new System.EventHandler(this.FormCartelera_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posterPeli)).EndInit();
            this.PanelDeFechas.ResumeLayout(false);
            this.PanelDeFechas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Cartelera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpHorarios;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel PanelDeFechas;
        private System.Windows.Forms.Label lblSinopsis;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label lblClasificacion;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox posterPeli;
        private System.Windows.Forms.FlowLayoutPanel PanelFechas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}