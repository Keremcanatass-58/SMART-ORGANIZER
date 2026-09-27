namespace SmartOrganizer
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnArsiv = new System.Windows.Forms.Button();
            this.btnMedyalar = new System.Windows.Forms.Button();
            this.btnBelgeler = new System.Windows.Forms.Button();
            this.btnTumDosyalar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.listView4 = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKopyala = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSil = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmYolaGit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnArsiv);
            this.panel1.Controls.Add(this.btnMedyalar);
            this.panel1.Controls.Add(this.btnBelgeler);
            this.panel1.Controls.Add(this.btnTumDosyalar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 706);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Image = global::SmartOrganizer.Properties.Resources.search_interface_symbol;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "Dosya Ara";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::SmartOrganizer.Properties.Resources.Proje_İsmi_SMARTORGANIZER_Bunun_için_bir_logo_istiyorum_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(12, 300);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 351);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(-44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "SMARTORGANIZER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnArsiv
            // 
            this.btnArsiv.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArsiv.Image = global::SmartOrganizer.Properties.Resources.archive_1_;
            this.btnArsiv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArsiv.Location = new System.Drawing.Point(12, 189);
            this.btnArsiv.Name = "btnArsiv";
            this.btnArsiv.Size = new System.Drawing.Size(253, 44);
            this.btnArsiv.TabIndex = 3;
            this.btnArsiv.Text = "Arşivler";
            this.btnArsiv.UseVisualStyleBackColor = true;
            this.btnArsiv.Click += new System.EventHandler(this.btnArsiv_Click);
            // 
            // btnMedyalar
            // 
            this.btnMedyalar.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMedyalar.Image = global::SmartOrganizer.Properties.Resources.image_1_;
            this.btnMedyalar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedyalar.Location = new System.Drawing.Point(12, 145);
            this.btnMedyalar.Name = "btnMedyalar";
            this.btnMedyalar.Size = new System.Drawing.Size(253, 44);
            this.btnMedyalar.TabIndex = 2;
            this.btnMedyalar.Text = "Medya";
            this.btnMedyalar.UseVisualStyleBackColor = true;
            this.btnMedyalar.Click += new System.EventHandler(this.btnMedyalar_Click);
            // 
            // btnBelgeler
            // 
            this.btnBelgeler.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBelgeler.Image = global::SmartOrganizer.Properties.Resources.google_docs_1_;
            this.btnBelgeler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBelgeler.Location = new System.Drawing.Point(12, 102);
            this.btnBelgeler.Name = "btnBelgeler";
            this.btnBelgeler.Size = new System.Drawing.Size(253, 44);
            this.btnBelgeler.TabIndex = 1;
            this.btnBelgeler.Text = "Belgeler";
            this.btnBelgeler.UseVisualStyleBackColor = true;
            this.btnBelgeler.Click += new System.EventHandler(this.btnBelgeler_Click_1);
            // 
            // btnTumDosyalar
            // 
            this.btnTumDosyalar.BackColor = System.Drawing.Color.White;
            this.btnTumDosyalar.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTumDosyalar.Image = global::SmartOrganizer.Properties.Resources.document;
            this.btnTumDosyalar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTumDosyalar.Location = new System.Drawing.Point(12, 62);
            this.btnTumDosyalar.Name = "btnTumDosyalar";
            this.btnTumDosyalar.Size = new System.Drawing.Size(253, 44);
            this.btnTumDosyalar.TabIndex = 0;
            this.btnTumDosyalar.Text = "Tüm Dosyalar";
            this.btnTumDosyalar.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.listView4);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.listView3);
            this.panel2.Controls.Add(this.listView2);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(266, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(636, 706);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::SmartOrganizer.Properties.Resources.Proje_İsmi_SMARTORGANIZER_Bunun_için_bir_logo_istiyorum_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(31, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(580, 94);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // listView4
            // 
            this.listView4.ContextMenuStrip = this.contextMenuStrip1;
            this.listView4.FullRowSelect = true;
            this.listView4.GridLines = true;
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(31, 599);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(548, 97);
            this.listView4.TabIndex = 10;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(31, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Uygulamalar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(31, 554);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kod/Yazılım";
            // 
            // listView3
            // 
            this.listView3.ContextMenuStrip = this.contextMenuStrip1;
            this.listView3.FullRowSelect = true;
            this.listView3.GridLines = true;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(31, 435);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(548, 97);
            this.listView3.TabIndex = 8;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // listView2
            // 
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(31, 281);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(548, 97);
            this.listView2.TabIndex = 6;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(31, 149);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(548, 97);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(31, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Medya";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(31, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Belgeler";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAc,
            this.tsmKopyala,
            this.tsmSil,
            this.tsmYolaGit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 128);
            // 
            // tsmAc
            // 
            this.tsmAc.Name = "tsmAc";
            this.tsmAc.Size = new System.Drawing.Size(210, 24);
            this.tsmAc.Text = "Aç";
            this.tsmAc.Click += new System.EventHandler(this.tsmAc_Click);
            // 
            // tsmKopyala
            // 
            this.tsmKopyala.Name = "tsmKopyala";
            this.tsmKopyala.Size = new System.Drawing.Size(132, 24);
            this.tsmKopyala.Text = "Kopyala";
            // 
            // tsmSil
            // 
            this.tsmSil.Name = "tsmSil";
            this.tsmSil.Size = new System.Drawing.Size(132, 24);
            this.tsmSil.Text = "Sil";
            // 
            // tsmYolaGit
            // 
            this.tsmYolaGit.Name = "tsmYolaGit";
            this.tsmYolaGit.Size = new System.Drawing.Size(132, 24);
            this.tsmYolaGit.Text = "Yola Git";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 706);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "SMARTORGANIZER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnArsiv;
        private System.Windows.Forms.Button btnMedyalar;
        private System.Windows.Forms.Button btnBelgeler;
        private System.Windows.Forms.Button btnTumDosyalar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmAc;
        private System.Windows.Forms.ToolStripMenuItem tsmKopyala;
        private System.Windows.Forms.ToolStripMenuItem tsmSil;
        private System.Windows.Forms.ToolStripMenuItem tsmYolaGit;
    }
}

