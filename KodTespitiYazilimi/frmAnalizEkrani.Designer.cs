namespace KodTespitiYazilimi
{
    partial class frmAnalizEkrani
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rtbKod = new RichTextBox();
            btnAnaliz = new Button();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            progressBar3 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblSonuc = new Label();
            btnCikis = new Button();
            SuspendLayout();
            // 
            // rtbKod
            // 
            rtbKod.Font = new Font("Consolas", 9F);
            rtbKod.Location = new Point(12, 12);
            rtbKod.Name = "rtbKod";
            rtbKod.Size = new Size(533, 583);
            rtbKod.TabIndex = 0;
            rtbKod.Text = "";
            // 
            // btnAnaliz
            // 
            btnAnaliz.Font = new Font("Segoe UI", 16F);
            btnAnaliz.Location = new Point(614, 102);
            btnAnaliz.Name = "btnAnaliz";
            btnAnaliz.Size = new Size(184, 80);
            btnAnaliz.TabIndex = 1;
            btnAnaliz.Text = "Analiz Et";
            btnAnaliz.UseVisualStyleBackColor = true;
            btnAnaliz.Click += btnAnaliz_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(576, 364);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(479, 23);
            progressBar1.TabIndex = 2;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(576, 429);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(479, 23);
            progressBar2.TabIndex = 3;
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(576, 493);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(479, 23);
            progressBar3.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(576, 340);
            label1.Name = "label1";
            label1.Size = new Size(92, 21);
            label1.TabIndex = 5;
            label1.Text = "Algoritma 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(576, 405);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 6;
            label2.Text = "Algoritma 2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(576, 469);
            label3.Name = "label3";
            label3.Size = new Size(92, 21);
            label3.TabIndex = 7;
            label3.Text = "Algoritma 3";
            // 
            // lblSonuc
            // 
            lblSonuc.AutoSize = true;
            lblSonuc.Font = new Font("Segoe UI", 12F);
            lblSonuc.Location = new Point(576, 535);
            lblSonuc.Name = "lblSonuc";
            lblSonuc.Size = new Size(139, 21);
            lblSonuc.TabIndex = 8;
            lblSonuc.Text = "Sonuç Bekleniyor...";
            // 
            // btnCikis
            // 
            btnCikis.Font = new Font("Segoe UI", 16F);
            btnCikis.Location = new Point(827, 102);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(184, 80);
            btnCikis.TabIndex = 9;
            btnCikis.Text = "Çıkış Yap";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            // 
            // frmAnalizEkrani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1088, 607);
            Controls.Add(btnCikis);
            Controls.Add(lblSonuc);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar3);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(btnAnaliz);
            Controls.Add(rtbKod);
            Name = "frmAnalizEkrani";
            Text = "Analiz Ekranı";
            Load += frmAnalizEkrani_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbKod;
        private Button btnAnaliz;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private ProgressBar progressBar3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblSonuc;
        private Button btnCikis;
    }
}
