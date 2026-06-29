namespace CinePOS
{
    partial class FormTicket
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
            this.txtTicket = new System.Windows.Forms.RichTextBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTicket
            // 
            this.txtTicket.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTicket.Location = new System.Drawing.Point(0, 36);
            this.txtTicket.Name = "txtTicket";
            this.txtTicket.ReadOnly = true;
            this.txtTicket.Size = new System.Drawing.Size(395, 627);
            this.txtTicket.TabIndex = 0;
            this.txtTicket.Text = "";
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnclose.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnclose.Location = new System.Drawing.Point(218, 6);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(165, 27);
            this.btnclose.TabIndex = 1;
            this.btnclose.Text = "Listo";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Location = new System.Drawing.Point(21, 6);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(167, 27);
            this.btnprint.TabIndex = 2;
            this.btnprint.Text = "Imprimir";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 36);
            this.panel1.TabIndex = 3;
            // 
            // FormTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(395, 663);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtTicket);
            this.Name = "FormTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTicket";
            this.Load += new System.EventHandler(this.FormTicket_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtTicket;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel1;
    }
}