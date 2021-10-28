namespace İnternet_Cafe_Otomasyonu
{
    partial class Aktar
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblMasaAdi = new System.Windows.Forms.Label();
            this.btnAktar = new DevExpress.XtraEditors.SimpleButton();
            this.cboxAktar = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(22, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Masa Seçiniz: ";
            // 
            // lblMasaAdi
            // 
            this.lblMasaAdi.AutoSize = true;
            this.lblMasaAdi.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMasaAdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblMasaAdi.Location = new System.Drawing.Point(134, 15);
            this.lblMasaAdi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMasaAdi.Name = "lblMasaAdi";
            this.lblMasaAdi.Size = new System.Drawing.Size(0, 21);
            this.lblMasaAdi.TabIndex = 2;
            // 
            // btnAktar
            // 
            this.btnAktar.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAktar.Appearance.Options.UseFont = true;
            this.btnAktar.Location = new System.Drawing.Point(102, 126);
            this.btnAktar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAktar.Name = "btnAktar";
            this.btnAktar.Size = new System.Drawing.Size(154, 24);
            this.btnAktar.TabIndex = 3;
            this.btnAktar.Text = "Aktar";
            this.btnAktar.Click += new System.EventHandler(this.btnAktar_Click);
            // 
            // cboxAktar
            // 
            this.cboxAktar.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cboxAktar.FormattingEnabled = true;
            this.cboxAktar.Items.AddRange(new object[] {
            "Masa-1",
            "Masa-2",
            "Masa-3",
            "Masa-4",
            "Masa-5",
            "Masa-6",
            "Masa-7",
            "Masa-8",
            "Masa-9",
            "Masa-10",
            "Masa-11",
            "Masa-12",
            "Masa-13",
            "Masa-14",
            "Masa-15",
            "Masa-16",
            "Masa-17",
            "Masa-18",
            "Masa-19",
            "Masa-20"});
            this.cboxAktar.Location = new System.Drawing.Point(139, 68);
            this.cboxAktar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboxAktar.Name = "cboxAktar";
            this.cboxAktar.Size = new System.Drawing.Size(167, 28);
            this.cboxAktar.TabIndex = 4;
            // 
            // Aktar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(367, 177);
            this.Controls.Add(this.cboxAktar);
            this.Controls.Add(this.btnAktar);
            this.Controls.Add(this.lblMasaAdi);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Aktar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aktar";
            this.Load += new System.EventHandler(this.Aktar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnAktar;
        public System.Windows.Forms.Label lblMasaAdi;
        private System.Windows.Forms.ComboBox cboxAktar;
    }
}