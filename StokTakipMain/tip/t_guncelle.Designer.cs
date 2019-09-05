namespace StokTakipMain.tip
{
    partial class t_guncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(t_guncelle));
            this.btn_sil = new System.Windows.Forms.Button();
            this.btn_kaydet = new System.Windows.Forms.Button();
            this.txt_ad = new System.Windows.Forms.TextBox();
            this.datagrid_tip = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_tip)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_sil
            // 
            this.btn_sil.BackColor = System.Drawing.Color.BlueViolet;
            this.btn_sil.Image = global::StokTakipMain.Properties.Resources.sil;
            this.btn_sil.Location = new System.Drawing.Point(187, 177);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(34, 36);
            this.btn_sil.TabIndex = 19;
            this.btn_sil.UseVisualStyleBackColor = false;
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.BackColor = System.Drawing.Color.BlueViolet;
            this.btn_kaydet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_kaydet.Image = global::StokTakipMain.Properties.Resources.kabul;
            this.btn_kaydet.Location = new System.Drawing.Point(227, 177);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(34, 36);
            this.btn_kaydet.TabIndex = 18;
            this.btn_kaydet.UseVisualStyleBackColor = false;
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // txt_ad
            // 
            this.txt_ad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_ad.Location = new System.Drawing.Point(23, 181);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(158, 26);
            this.txt_ad.TabIndex = 17;
            // 
            // datagrid_tip
            // 
            this.datagrid_tip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_tip.Location = new System.Drawing.Point(23, 12);
            this.datagrid_tip.Name = "datagrid_tip";
            this.datagrid_tip.ReadOnly = true;
            this.datagrid_tip.Size = new System.Drawing.Size(240, 150);
            this.datagrid_tip.TabIndex = 16;
            //this.datagrid_tip.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_tip_CellContentClick);
            this.datagrid_tip.Click += new System.EventHandler(this.datagrid_tip_Click);
            // 
            // t_guncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlueViolet;
            this.ClientSize = new System.Drawing.Size(284, 225);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_kaydet);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.datagrid_tip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "t_guncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tip Güncelle";
            this.Load += new System.EventHandler(this.t_guncelle_Load);
            //this.Click += new System.EventHandler(this.t_guncelle_Click);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_tip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_sil;
        private System.Windows.Forms.Button btn_kaydet;
        private System.Windows.Forms.TextBox txt_ad;
        private System.Windows.Forms.DataGridView datagrid_tip;

    }
}