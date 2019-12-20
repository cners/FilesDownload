namespace FilesDownload
{
    partial class Start
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrls = new System.Windows.Forms.TextBox();
            this.btnDonwload = new System.Windows.Forms.Button();
            this.btnOpenSavePath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSavePrint = new System.Windows.Forms.Button();
            this.btnLoadSuning = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(95, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "（一个链接一行）";
            // 
            // txtUrls
            // 
            this.txtUrls.Location = new System.Drawing.Point(31, 34);
            this.txtUrls.Multiline = true;
            this.txtUrls.Name = "txtUrls";
            this.txtUrls.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUrls.Size = new System.Drawing.Size(843, 174);
            this.txtUrls.TabIndex = 2;
            // 
            // btnDonwload
            // 
            this.btnDonwload.BackColor = System.Drawing.Color.LimeGreen;
            this.btnDonwload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonwload.Location = new System.Drawing.Point(799, 214);
            this.btnDonwload.Name = "btnDonwload";
            this.btnDonwload.Size = new System.Drawing.Size(75, 32);
            this.btnDonwload.TabIndex = 3;
            this.btnDonwload.Text = "下载";
            this.btnDonwload.UseVisualStyleBackColor = false;
            this.btnDonwload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnOpenSavePath
            // 
            this.btnOpenSavePath.Location = new System.Drawing.Point(651, 214);
            this.btnOpenSavePath.Name = "btnOpenSavePath";
            this.btnOpenSavePath.Size = new System.Drawing.Size(125, 32);
            this.btnOpenSavePath.TabIndex = 4;
            this.btnOpenSavePath.Text = "打开文件保存目录";
            this.btnOpenSavePath.UseVisualStyleBackColor = true;
            this.btnOpenSavePath.Visible = false;
            this.btnOpenSavePath.Click += new System.EventHandler(this.btnOpenSavePath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "下载输出";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(31, 252);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(843, 239);
            this.txtLog.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(651, 498);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清空输出框";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.Location = new System.Drawing.Point(779, 497);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(95, 23);
            this.btnSavePrint.TabIndex = 8;
            this.btnSavePrint.Text = "输出另存为";
            this.btnSavePrint.UseVisualStyleBackColor = true;
            this.btnSavePrint.Click += new System.EventHandler(this.btnSavePrint_Click);
            // 
            // btnLoadSuning
            // 
            this.btnLoadSuning.Location = new System.Drawing.Point(702, 5);
            this.btnLoadSuning.Name = "btnLoadSuning";
            this.btnLoadSuning.Size = new System.Drawing.Size(172, 23);
            this.btnLoadSuning.TabIndex = 9;
            this.btnLoadSuning.Text = "一键加载网络图片链接";
            this.btnLoadSuning.UseVisualStyleBackColor = true;
            this.btnLoadSuning.Click += new System.EventHandler(this.btnLoadSuning_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 533);
            this.Controls.Add(this.btnLoadSuning);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSavePrint);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOpenSavePath);
            this.Controls.Add(this.btnDonwload);
            this.Controls.Add(this.txtUrls);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件下载 - v1.0.1";
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrls;
        private System.Windows.Forms.Button btnDonwload;
        private System.Windows.Forms.Button btnOpenSavePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSavePrint;
        private System.Windows.Forms.Button btnLoadSuning;
    }
}

