namespace downLoader
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timeLeft = new System.Windows.Forms.Label();
            this.transferSpeed = new System.Windows.Forms.Label();
            this.merchant = new System.Windows.Forms.Label();
            this.btnFloderSelect = new System.Windows.Forms.Button();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.floderText = new System.Windows.Forms.TextBox();
            this.korean_btn = new System.Windows.Forms.Button();
            this.indenusia_btn = new System.Windows.Forms.Button();
            this.vietnam_btn = new System.Windows.Forms.Button();
            this.thailand_btn = new System.Windows.Forms.Button();
            this.cn_btn = new System.Windows.Forms.Button();
            this.en_btn = new System.Windows.Forms.Button();
            this.malaysia_btn = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.pictureBoxBar = new System.Windows.Forms.PictureBox();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.statusIntro = new System.Windows.Forms.Label();
            this.pb_install_us = new System.Windows.Forms.PictureBox();
            this.pb_install_cn = new System.Windows.Forms.PictureBox();
            this.pb_download_us = new System.Windows.Forms.PictureBox();
            this.pb_download_cn = new System.Windows.Forms.PictureBox();
            this.percentData = new System.Windows.Forms.Label();
            this.percentSign = new System.Windows.Forms.Label();
            this.backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBar)).BeginInit();
            this.progressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_install_us)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_install_cn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_download_us)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_download_cn)).BeginInit();
            this.SuspendLayout();
            // 
            // timeLeft
            // 
            this.timeLeft.BackColor = System.Drawing.Color.Transparent;
            this.timeLeft.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.timeLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.timeLeft.Location = new System.Drawing.Point(241, 396);
            this.timeLeft.Name = "timeLeft";
            this.timeLeft.Size = new System.Drawing.Size(170, 16);
            this.timeLeft.TabIndex = 1;
            // 
            // transferSpeed
            // 
            this.transferSpeed.BackColor = System.Drawing.Color.Transparent;
            this.transferSpeed.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.transferSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.transferSpeed.Location = new System.Drawing.Point(417, 396);
            this.transferSpeed.Name = "transferSpeed";
            this.transferSpeed.Size = new System.Drawing.Size(174, 16);
            this.transferSpeed.TabIndex = 4;
            // 
            // merchant
            // 
            this.merchant.AutoSize = true;
            this.merchant.BackColor = System.Drawing.Color.Transparent;
            this.merchant.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.merchant.ForeColor = System.Drawing.SystemColors.Control;
            this.merchant.Location = new System.Drawing.Point(31, 18);
            this.merchant.Name = "merchant";
            this.merchant.Size = new System.Drawing.Size(0, 22);
            this.merchant.TabIndex = 6;
            this.merchant.Visible = false;
            // 
            // btnFloderSelect
            // 
            this.btnFloderSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnFloderSelect.BackgroundImage = global::downLoader.Properties.Resources.broswer;
            this.btnFloderSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFloderSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFloderSelect.FlatAppearance.BorderSize = 0;
            this.btnFloderSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFloderSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFloderSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFloderSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFloderSelect.Location = new System.Drawing.Point(505, 421);
            this.btnFloderSelect.Name = "btnFloderSelect";
            this.btnFloderSelect.Size = new System.Drawing.Size(40, 26);
            this.btnFloderSelect.TabIndex = 23;
            this.btnFloderSelect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFloderSelect.UseVisualStyleBackColor = false;
            this.btnFloderSelect.Click += new System.EventHandler(this.btnFloderSelect_Click);
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.backgroundPanel.BackgroundImage = global::downLoader.Properties.Resources.c1;
            this.backgroundPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.backgroundPanel.Controls.Add(this.floderText);
            this.backgroundPanel.Location = new System.Drawing.Point(260, 421);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(247, 26);
            this.backgroundPanel.TabIndex = 21;
            // 
            // floderText
            // 
            this.floderText.BackColor = System.Drawing.Color.Black;
            this.floderText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.floderText.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.floderText.ForeColor = System.Drawing.Color.Gray;
            this.floderText.Location = new System.Drawing.Point(7, 2);
            this.floderText.Name = "floderText";
            this.floderText.Size = new System.Drawing.Size(231, 18);
            this.floderText.TabIndex = 22;
            // 
            // korean_btn
            // 
            this.korean_btn.BackColor = System.Drawing.Color.Transparent;
            this.korean_btn.BackgroundImage = global::downLoader.Properties.Resources.Korean_off;
            this.korean_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.korean_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.korean_btn.FlatAppearance.BorderSize = 0;
            this.korean_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.korean_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.korean_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.korean_btn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.korean_btn.ForeColor = System.Drawing.Color.Transparent;
            this.korean_btn.Location = new System.Drawing.Point(531, 359);
            this.korean_btn.Name = "korean_btn";
            this.korean_btn.Size = new System.Drawing.Size(48, 48);
            this.korean_btn.TabIndex = 19;
            this.korean_btn.UseVisualStyleBackColor = false;
            this.korean_btn.Click += new System.EventHandler(this.korean_btn_Click);
            // 
            // indenusia_btn
            // 
            this.indenusia_btn.BackColor = System.Drawing.Color.Transparent;
            this.indenusia_btn.BackgroundImage = global::downLoader.Properties.Resources.Indonesia_off;
            this.indenusia_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.indenusia_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.indenusia_btn.FlatAppearance.BorderSize = 0;
            this.indenusia_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.indenusia_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.indenusia_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.indenusia_btn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.indenusia_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.indenusia_btn.Location = new System.Drawing.Point(337, 359);
            this.indenusia_btn.Name = "indenusia_btn";
            this.indenusia_btn.Size = new System.Drawing.Size(48, 48);
            this.indenusia_btn.TabIndex = 18;
            this.indenusia_btn.UseVisualStyleBackColor = false;
            this.indenusia_btn.Click += new System.EventHandler(this.indenusia_btn_Click);
            // 
            // vietnam_btn
            // 
            this.vietnam_btn.BackColor = System.Drawing.Color.Transparent;
            this.vietnam_btn.BackgroundImage = global::downLoader.Properties.Resources.Vietnam_off;
            this.vietnam_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.vietnam_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vietnam_btn.FlatAppearance.BorderSize = 0;
            this.vietnam_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.vietnam_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.vietnam_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vietnam_btn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.vietnam_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.vietnam_btn.Location = new System.Drawing.Point(386, 359);
            this.vietnam_btn.Name = "vietnam_btn";
            this.vietnam_btn.Size = new System.Drawing.Size(48, 48);
            this.vietnam_btn.TabIndex = 17;
            this.vietnam_btn.UseVisualStyleBackColor = false;
            this.vietnam_btn.Click += new System.EventHandler(this.vietnam_btn_Click);
            // 
            // thailand_btn
            // 
            this.thailand_btn.BackColor = System.Drawing.Color.Transparent;
            this.thailand_btn.BackgroundImage = global::downLoader.Properties.Resources.Thailand_off;
            this.thailand_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.thailand_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thailand_btn.FlatAppearance.BorderSize = 0;
            this.thailand_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.thailand_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.thailand_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thailand_btn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thailand_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.thailand_btn.Location = new System.Drawing.Point(436, 359);
            this.thailand_btn.Name = "thailand_btn";
            this.thailand_btn.Size = new System.Drawing.Size(48, 48);
            this.thailand_btn.TabIndex = 16;
            this.thailand_btn.UseVisualStyleBackColor = false;
            this.thailand_btn.Click += new System.EventHandler(this.thailand_btn_Click);
            // 
            // cn_btn
            // 
            this.cn_btn.BackColor = System.Drawing.Color.Transparent;
            this.cn_btn.BackgroundImage = global::downLoader.Properties.Resources.cn_off;
            this.cn_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cn_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cn_btn.FlatAppearance.BorderSize = 0;
            this.cn_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cn_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cn_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cn_btn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cn_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cn_btn.Location = new System.Drawing.Point(288, 359);
            this.cn_btn.Name = "cn_btn";
            this.cn_btn.Size = new System.Drawing.Size(48, 48);
            this.cn_btn.TabIndex = 15;
            this.cn_btn.UseVisualStyleBackColor = false;
            this.cn_btn.Click += new System.EventHandler(this.cn_btn_Click);
            // 
            // en_btn
            // 
            this.en_btn.BackColor = System.Drawing.Color.Transparent;
            this.en_btn.BackgroundImage = global::downLoader.Properties.Resources.en;
            this.en_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.en_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.en_btn.FlatAppearance.BorderSize = 0;
            this.en_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.en_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.en_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.en_btn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.en_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.en_btn.Location = new System.Drawing.Point(238, 359);
            this.en_btn.Name = "en_btn";
            this.en_btn.Size = new System.Drawing.Size(48, 48);
            this.en_btn.TabIndex = 14;
            this.en_btn.UseVisualStyleBackColor = false;
            this.en_btn.Click += new System.EventHandler(this.en_btn_Click);
            // 
            // malaysia_btn
            // 
            this.malaysia_btn.BackColor = System.Drawing.Color.Transparent;
            this.malaysia_btn.BackgroundImage = global::downLoader.Properties.Resources.Malaysia_off;
            this.malaysia_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.malaysia_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.malaysia_btn.FlatAppearance.BorderSize = 0;
            this.malaysia_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.malaysia_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.malaysia_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.malaysia_btn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.malaysia_btn.ForeColor = System.Drawing.Color.Transparent;
            this.malaysia_btn.Location = new System.Drawing.Point(484, 359);
            this.malaysia_btn.Name = "malaysia_btn";
            this.malaysia_btn.Size = new System.Drawing.Size(48, 48);
            this.malaysia_btn.TabIndex = 13;
            this.malaysia_btn.UseVisualStyleBackColor = false;
            this.malaysia_btn.Click += new System.EventHandler(this.malaysia_btn_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.Transparent;
            this.btnStartGame.BackgroundImage = global::downLoader.Properties.Resources.btn_on;
            this.btnStartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartGame.FlatAppearance.BorderSize = 0;
            this.btnStartGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.btnStartGame.ForeColor = System.Drawing.Color.Khaki;
            this.btnStartGame.Location = new System.Drawing.Point(336, 374);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(133, 43);
            this.btnStartGame.TabIndex = 12;
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.BackgroundImage = global::downLoader.Properties.Resources._01;
            this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Location = new System.Drawing.Point(789, 17);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(16, 16);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.BackColor = System.Drawing.Color.Transparent;
            this.btnInstall.BackgroundImage = global::downLoader.Properties.Resources.btn_on;
            this.btnInstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstall.FlatAppearance.BorderSize = 0;
            this.btnInstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnInstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.btnInstall.ForeColor = System.Drawing.Color.Khaki;
            this.btnInstall.Location = new System.Drawing.Point(333, 463);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(133, 43);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // pictureBoxBar
            // 
            this.pictureBoxBar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBar.Image = global::downLoader.Properties.Resources.load;
            this.pictureBoxBar.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxBar.Name = "pictureBoxBar";
            this.pictureBoxBar.Size = new System.Drawing.Size(0, 12);
            this.pictureBoxBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBar.TabIndex = 24;
            this.pictureBoxBar.TabStop = false;
            this.pictureBoxBar.Visible = false;
            // 
            // progressPanel
            // 
            this.progressPanel.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel.BackgroundImage = global::downLoader.Properties.Resources.progress;
            this.progressPanel.Controls.Add(this.pictureBoxBar);
            this.progressPanel.Location = new System.Drawing.Point(234, 375);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(348, 19);
            this.progressPanel.TabIndex = 25;
            this.progressPanel.Visible = false;
            // 
            // statusIntro
            // 
            this.statusIntro.BackColor = System.Drawing.Color.Transparent;
            this.statusIntro.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.statusIntro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.statusIntro.Location = new System.Drawing.Point(236, 394);
            this.statusIntro.Name = "statusIntro";
            this.statusIntro.Size = new System.Drawing.Size(559, 20);
            this.statusIntro.TabIndex = 26;
            // 
            // pb_install_us
            // 
            this.pb_install_us.BackColor = System.Drawing.Color.Transparent;
            this.pb_install_us.Image = global::downLoader.Properties.Resources.installing_us;
            this.pb_install_us.Location = new System.Drawing.Point(350, 413);
            this.pb_install_us.Name = "pb_install_us";
            this.pb_install_us.Size = new System.Drawing.Size(116, 37);
            this.pb_install_us.TabIndex = 27;
            this.pb_install_us.TabStop = false;
            // 
            // pb_install_cn
            // 
            this.pb_install_cn.BackColor = System.Drawing.Color.Transparent;
            this.pb_install_cn.Image = global::downLoader.Properties.Resources.installing_cn;
            this.pb_install_cn.Location = new System.Drawing.Point(350, 413);
            this.pb_install_cn.Name = "pb_install_cn";
            this.pb_install_cn.Size = new System.Drawing.Size(96, 35);
            this.pb_install_cn.TabIndex = 28;
            this.pb_install_cn.TabStop = false;
            // 
            // pb_download_us
            // 
            this.pb_download_us.BackColor = System.Drawing.Color.Transparent;
            this.pb_download_us.Image = global::downLoader.Properties.Resources.downloading_us;
            this.pb_download_us.Location = new System.Drawing.Point(328, 412);
            this.pb_download_us.Name = "pb_download_us";
            this.pb_download_us.Size = new System.Drawing.Size(156, 37);
            this.pb_download_us.TabIndex = 29;
            this.pb_download_us.TabStop = false;
            // 
            // pb_download_cn
            // 
            this.pb_download_cn.BackColor = System.Drawing.Color.Transparent;
            this.pb_download_cn.Image = global::downLoader.Properties.Resources.downloading_cn;
            this.pb_download_cn.Location = new System.Drawing.Point(350, 413);
            this.pb_download_cn.Name = "pb_download_cn";
            this.pb_download_cn.Size = new System.Drawing.Size(96, 34);
            this.pb_download_cn.TabIndex = 30;
            this.pb_download_cn.TabStop = false;
            // 
            // percentData
            // 
            this.percentData.BackColor = System.Drawing.Color.Transparent;
            this.percentData.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.percentData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(77)))), ((int)(((byte)(48)))));
            this.percentData.Location = new System.Drawing.Point(378, 351);
            this.percentData.Name = "percentData";
            this.percentData.Size = new System.Drawing.Size(45, 20);
            this.percentData.TabIndex = 32;
            this.percentData.Text = "0";
            this.percentData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // percentSign
            // 
            this.percentSign.BackColor = System.Drawing.Color.Transparent;
            this.percentSign.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.percentSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(77)))), ((int)(((byte)(48)))));
            this.percentSign.Location = new System.Drawing.Point(416, 354);
            this.percentSign.Name = "percentSign";
            this.percentSign.Size = new System.Drawing.Size(15, 17);
            this.percentSign.TabIndex = 33;
            this.percentSign.Text = "%";
            this.percentSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::downLoader.Properties.Resources.loading_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(825, 550);
            this.Controls.Add(this.percentSign);
            this.Controls.Add(this.percentData);
            this.Controls.Add(this.pb_download_cn);
            this.Controls.Add(this.pb_install_cn);
            this.Controls.Add(this.pb_download_us);
            this.Controls.Add(this.pb_install_us);
            this.Controls.Add(this.statusIntro);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.btnFloderSelect);
            this.Controls.Add(this.backgroundPanel);
            this.Controls.Add(this.korean_btn);
            this.Controls.Add(this.indenusia_btn);
            this.Controls.Add(this.vietnam_btn);
            this.Controls.Add(this.thailand_btn);
            this.Controls.Add(this.cn_btn);
            this.Controls.Add(this.en_btn);
            this.Controls.Add(this.malaysia_btn);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.merchant);
            this.Controls.Add(this.transferSpeed);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.timeLeft);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = resources.GetString("$this.Text");
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.backgroundPanel.ResumeLayout(false);
            this.backgroundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBar)).EndInit();
            this.progressPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_install_us)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_install_cn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_download_us)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_download_cn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label timeLeft;
        private System.Windows.Forms.Label transferSpeed;
        private System.Windows.Forms.Label merchant;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button malaysia_btn;
        private System.Windows.Forms.Button en_btn;
        private System.Windows.Forms.Button cn_btn;
        private System.Windows.Forms.Button thailand_btn;
        private System.Windows.Forms.Button vietnam_btn;
        private System.Windows.Forms.Button indenusia_btn;
        private System.Windows.Forms.Button korean_btn;
        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.Button btnFloderSelect;
        private System.Windows.Forms.PictureBox pictureBoxBar;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.TextBox floderText;
        private System.Windows.Forms.Label statusIntro;
        private System.Windows.Forms.PictureBox pb_install_us;
        private System.Windows.Forms.PictureBox pb_install_cn;
        private System.Windows.Forms.PictureBox pb_download_us;
        private System.Windows.Forms.PictureBox pb_download_cn;
        private System.Windows.Forms.Label percentData;
        private System.Windows.Forms.Label percentSign;
    }
}

