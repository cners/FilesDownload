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
            this.components = new System.ComponentModel.Container();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimeInterval = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDownNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rCircle = new System.Windows.Forms.RadioButton();
            this.rDoneStop = new System.Windows.Forms.RadioButton();
            this.timerDownload = new System.Windows.Forms.Timer(this.components);
            this.lbStatus = new System.Windows.Forms.Label();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
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
            this.btnDonwload.Location = new System.Drawing.Point(6, 247);
            this.btnDonwload.Name = "btnDonwload";
            this.btnDonwload.Size = new System.Drawing.Size(172, 32);
            this.btnDonwload.TabIndex = 3;
            this.btnDonwload.Text = "下载";
            this.btnDonwload.UseVisualStyleBackColor = false;
            this.btnDonwload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnOpenSavePath
            // 
            this.btnOpenSavePath.Location = new System.Drawing.Point(7, 209);
            this.btnOpenSavePath.Name = "btnOpenSavePath";
            this.btnOpenSavePath.Size = new System.Drawing.Size(172, 32);
            this.btnOpenSavePath.TabIndex = 4;
            this.btnOpenSavePath.Text = "打开文件自动保存目录";
            this.btnOpenSavePath.UseVisualStyleBackColor = true;
            this.btnOpenSavePath.Visible = false;
            this.btnOpenSavePath.Click += new System.EventHandler(this.btnOpenSavePath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "输出";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(31, 233);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(843, 258);
            this.txtLog.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(698, 497);
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
            this.btnLoadSuning.Location = new System.Drawing.Point(779, 5);
            this.btnLoadSuning.Name = "btnLoadSuning";
            this.btnLoadSuning.Size = new System.Drawing.Size(95, 23);
            this.btnLoadSuning.TabIndex = 9;
            this.btnLoadSuning.Text = "打开Urls文件";
            this.btnLoadSuning.UseVisualStyleBackColor = true;
            this.btnLoadSuning.Click += new System.EventHandler(this.btnLoadSuning_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.btnDonwload);
            this.groupBox1.Controls.Add(this.btnOpenSavePath);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.rCircle);
            this.groupBox1.Controls.Add(this.rDoneStop);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDownNum);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTimeInterval);
            this.groupBox1.Location = new System.Drawing.Point(897, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 312);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作区域";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "时间间隔";
            // 
            // txtTimeInterval
            // 
            this.txtTimeInterval.Location = new System.Drawing.Point(6, 45);
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.txtTimeInterval.Size = new System.Drawing.Size(134, 23);
            this.txtTimeInterval.TabIndex = 10;
            this.txtTimeInterval.Text = "120";
            this.txtTimeInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "s";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(6, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "每批下载个数";
            // 
            // txtDownNum
            // 
            this.txtDownNum.Location = new System.Drawing.Point(6, 91);
            this.txtDownNum.Name = "txtDownNum";
            this.txtDownNum.Size = new System.Drawing.Size(134, 23);
            this.txtDownNum.TabIndex = 13;
            this.txtDownNum.Text = "20-30";
            this.txtDownNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(6, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 34);
            this.label8.TabIndex = 14;
            this.label8.Text = "随机格式：min-max,如1-10\r\n固定个数：value,如10\r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(6, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "是否循环";
            // 
            // rCircle
            // 
            this.rCircle.AutoSize = true;
            this.rCircle.Checked = true;
            this.rCircle.Location = new System.Drawing.Point(7, 187);
            this.rCircle.Name = "rCircle";
            this.rCircle.Size = new System.Drawing.Size(74, 21);
            this.rCircle.TabIndex = 15;
            this.rCircle.TabStop = true;
            this.rCircle.Text = "循环下载";
            this.rCircle.UseVisualStyleBackColor = true;
            // 
            // rDoneStop
            // 
            this.rDoneStop.AutoSize = true;
            this.rDoneStop.Location = new System.Drawing.Point(86, 187);
            this.rDoneStop.Name = "rDoneStop";
            this.rDoneStop.Size = new System.Drawing.Size(74, 21);
            this.rDoneStop.TabIndex = 16;
            this.rDoneStop.Text = "下完截止";
            this.rDoneStop.UseVisualStyleBackColor = true;
            // 
            // timerDownload
            // 
            this.timerDownload.Tick += new System.EventHandler(this.timerDownload_Tick);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.ForeColor = System.Drawing.Color.Maroon;
            this.lbStatus.Location = new System.Drawing.Point(22, 286);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(140, 17);
            this.lbStatus.TabIndex = 17;
            this.lbStatus.Text = "距离下次下载还剩：？秒";
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 1000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 533);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoadSuning);
            this.Controls.Add(this.btnSavePrint);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUrls);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件下载 - v1.0.2";
            this.Load += new System.EventHandler(this.Start_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimeInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDownNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rCircle;
        private System.Windows.Forms.RadioButton rDoneStop;
        private System.Windows.Forms.Timer timerDownload;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Timer timerStatus;
    }
}

