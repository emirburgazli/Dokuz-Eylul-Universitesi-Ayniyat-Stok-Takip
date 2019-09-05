namespace StokTakipMain.tip
{
    partial class tip_ekle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tip_ekle));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.güncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.güncelleSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ad = new System.Windows.Forms.TextBox();
            this.btn_iptal = new System.Windows.Forms.Button();
            this.btn_kabul = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.BlueViolet;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.güncelleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(299, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // güncelleToolStripMenuItem
            // 
            this.güncelleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.güncelleSilToolStripMenuItem});
            this.güncelleToolStripMenuItem.Image = global::StokTakipMain.Properties.Resources.bakım;
            this.güncelleToolStripMenuItem.Name = "güncelleToolStripMenuItem";
            this.güncelleToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.güncelleToolStripMenuItem.Text = "Düzenle";
            // 
            // güncelleSilToolStripMenuItem
            // 
            this.güncelleSilToolStripMenuItem.Image = global::StokTakipMain.Properties.Resources.guncelle;
            this.güncelleSilToolStripMenuItem.Name = "güncelleSilToolStripMenuItem";
            this.güncelleSilToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.güncelleSilToolStripMenuItem.Text = "Güncelle / Sil";
            this.güncelleSilToolStripMenuItem.Click += new System.EventHandler(this.güncelleSilToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(16, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ad";
            // 
            // txt_ad
            // 
            this.txt_ad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_ad.Location = new System.Drawing.Point(58, 186);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(211, 29);
            this.txt_ad.TabIndex = 22;
            // 
            // btn_iptal
            // 
            this.btn_iptal.BackColor = System.Drawing.Color.BlueViolet;
            this.btn_iptal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_iptal.Image = global::StokTakipMain.Properties.Resources.iptal;
            this.btn_iptal.Location = new System.Drawing.Point(20, 229);
            this.btn_iptal.Name = "btn_iptal";
            this.btn_iptal.Size = new System.Drawing.Size(115, 41);
            this.btn_iptal.TabIndex = 25;
            this.btn_iptal.UseVisualStyleBackColor = false;
            this.btn_iptal.Click += new System.EventHandler(this.btn_iptal_Click);
            // 
            // btn_kabul
            // 
            this.btn_kabul.BackColor = System.Drawing.Color.BlueViolet;
            this.btn_kabul.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_kabul.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kabul.Image = global::StokTakipMain.Properties.Resources.kabul;
            this.btn_kabul.Location = new System.Drawing.Point(154, 229);
            this.btn_kabul.Name = "btn_kabul";
            this.btn_kabul.Size = new System.Drawing.Size(115, 41);
            this.btn_kabul.TabIndex = 24;
            this.btn_kabul.UseVisualStyleBackColor = false;
            this.btn_kabul.Click += new System.EventHandler(this.btn_kabul_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.BlueViolet;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Enabled = false;
            this.button1.Image = global::StokTakipMain.Properties.Resources.tip2;
            this.button1.Location = new System.Drawing.Point(20, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(249, 144);
            this.button1.TabIndex = 21;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // tip_ekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlueViolet;
            this.ClientSize = new System.Drawing.Size(299, 278);
            this.Controls.Add(this.btn_iptal);
            this.Controls.Add(this.btn_kabul);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "tip_ekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tip Ekle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.tip_ekle_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem güncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem güncelleSilToolStripMenuItem;
        private System.Windows.Forms.Button btn_iptal;
        private System.Windows.Forms.Button btn_kabul;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ad;
        private System.Windows.Forms.Button button1;
    }
}