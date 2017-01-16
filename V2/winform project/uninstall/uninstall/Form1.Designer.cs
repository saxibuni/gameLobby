namespace uninstall
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.merchant = new System.Windows.Forms.Label();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comfirmTxt = new System.Windows.Forms.Label();
            this.statusInfo = new System.Windows.Forms.Label();
            this.btnComplete = new System.Windows.Forms.Button();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.pictureBoxBar = new System.Windows.Forms.PictureBox();
            this.pb_uninstall_cn = new System.Windows.Forms.PictureBox();
            this.pb_uninstall_us = new System.Windows.Forms.PictureBox();
            this.percentData = new System.Windows.Forms.Label();
            this.percentSign = new System.Windows.Forms.Label();
            this.progressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_uninstall_cn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_uninstall_us)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeBtn.BackgroundImage")));
            this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closeBtn.Location = new System.Drawing.Point(789, 17);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(16, 16);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // merchant
            // 
            this.merchant.AutoSize = true;
            this.merchant.BackColor = System.Drawing.Color.Transparent;
            this.merchant.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.merchant.ForeColor = System.Drawing.SystemColors.Control;
            this.merchant.Location = new System.Drawing.Point(31, 18);
            this.merchant.Name = "merchant";
            this.merchant.Size = new System.Drawing.Size(108, 22);
            this.merchant.TabIndex = 7;
            this.merchant.Text = "SG GAMING";
            this.merchant.Visible = false;
            // 
            // btnUninstall
            // 
            this.btnUninstall.BackColor = System.Drawing.Color.Transparent;
            this.btnUninstall.BackgroundImage = global::uninstall.Properties.Resources._03;
            this.btnUninstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUninstall.FlatAppearance.BorderSize = 0;
            this.btnUninstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUninstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUninstall.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnUninstall.ForeColor = System.Drawing.Color.LightYellow;
            this.btnUninstall.Location = new System.Drawing.Point(424, 413);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(133, 43);
            this.btnUninstall.TabIndex = 8;
            this.btnUninstall.UseVisualStyleBackColor = false;
            this.btnUninstall.Click += new System.EventHandler(this.BtnUninstall_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::uninstall.Properties.Resources._02;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Khaki;
            this.btnCancel.Location = new System.Drawing.Point(265, 413);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 43);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comfirmTxt
            // 
            this.comfirmTxt.AutoSize = true;
            this.comfirmTxt.BackColor = System.Drawing.Color.Transparent;
            this.comfirmTxt.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comfirmTxt.ForeColor = System.Drawing.SystemColors.Control;
            this.comfirmTxt.Location = new System.Drawing.Point(300, 373);
            this.comfirmTxt.Name = "comfirmTxt";
            this.comfirmTxt.Size = new System.Drawing.Size(0, 25);
            this.comfirmTxt.TabIndex = 10;
            // 
            // statusInfo
            // 
            this.statusInfo.BackColor = System.Drawing.Color.Transparent;
            this.statusInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.statusInfo.Location = new System.Drawing.Point(241, 400);
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(343, 20);
            this.statusInfo.TabIndex = 13;
            this.statusInfo.Visible = false;
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.Transparent;
            this.btnComplete.BackgroundImage = global::uninstall.Properties.Resources._02;
            this.btnComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComplete.FlatAppearance.BorderSize = 0;
            this.btnComplete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnComplete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnComplete.ForeColor = System.Drawing.Color.LightYellow;
            this.btnComplete.Location = new System.Drawing.Point(345, 383);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(133, 43);
            this.btnComplete.TabIndex = 14;
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Visible = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // progressPanel
            // 
            this.progressPanel.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel.BackgroundImage = global::uninstall.Properties.Resources.progress;
            this.progressPanel.Controls.Add(this.pictureBoxBar);
            this.progressPanel.Location = new System.Drawing.Point(239, 380);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(348, 19);
            this.progressPanel.TabIndex = 26;
            this.progressPanel.Visible = false;
            // 
            // pictureBoxBar
            // 
            this.pictureBoxBar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBar.BackgroundImage = global::uninstall.Properties.Resources.load;
            this.pictureBoxBar.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxBar.Name = "pictureBoxBar";
            this.pictureBoxBar.Size = new System.Drawing.Size(343, 12);
            this.pictureBoxBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBar.TabIndex = 24;
            this.pictureBoxBar.TabStop = false;
            this.pictureBoxBar.Visible = false;
            // 
            // pb_uninstall_cn
            // 
            this.pb_uninstall_cn.BackColor = System.Drawing.Color.Transparent;
            this.pb_uninstall_cn.Image = global::uninstall.Properties.Resources.uninstalling_cn;
            this.pb_uninstall_cn.Location = new System.Drawing.Point(362, 419);
            this.pb_uninstall_cn.Name = "pb_uninstall_cn";
            this.pb_uninstall_cn.Size = new System.Drawing.Size(93, 28);
            this.pb_uninstall_cn.TabIndex = 27;
            this.pb_uninstall_cn.TabStop = false;
            this.pb_uninstall_cn.Visible = false;
            // 
            // pb_uninstall_us
            // 
            this.pb_uninstall_us.BackColor = System.Drawing.Color.Transparent;
            this.pb_uninstall_us.BackgroundImage = global::uninstall.Properties.Resources.uninstalling_us;
            this.pb_uninstall_us.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_uninstall_us.Location = new System.Drawing.Point(338, 419);
            this.pb_uninstall_us.Name = "pb_uninstall_us";
            this.pb_uninstall_us.Size = new System.Drawing.Size(144, 29);
            this.pb_uninstall_us.TabIndex = 28;
            this.pb_uninstall_us.TabStop = false;
            this.pb_uninstall_us.Visible = false;
            // 
            // percentData
            // 
            this.percentData.BackColor = System.Drawing.Color.Transparent;
            this.percentData.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.percentData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(77)))), ((int)(((byte)(48)))));
            this.percentData.Location = new System.Drawing.Point(375, 356);
            this.percentData.Name = "percentData";
            this.percentData.Size = new System.Drawing.Size(45, 20);
            this.percentData.TabIndex = 35;
            this.percentData.Text = "0";
            this.percentData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // percentSign
            // 
            this.percentSign.BackColor = System.Drawing.Color.Transparent;
            this.percentSign.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.percentSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(77)))), ((int)(((byte)(48)))));
            this.percentSign.Location = new System.Drawing.Point(413, 359);
            this.percentSign.Name = "percentSign";
            this.percentSign.Size = new System.Drawing.Size(15, 17);
            this.percentSign.TabIndex = 36;
            this.percentSign.Text = "%";
            this.percentSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::uninstall.Properties.Resources.loading_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(825, 550);
            this.Controls.Add(this.percentSign);
            this.Controls.Add(this.percentData);
            this.Controls.Add(this.pb_uninstall_us);
            this.Controls.Add(this.pb_uninstall_cn);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.statusInfo);
            this.Controls.Add(this.comfirmTxt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.merchant);
            this.Controls.Add(this.closeBtn);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.progressPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_uninstall_cn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_uninstall_us)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label merchant;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label comfirmTxt;
        private System.Windows.Forms.Label statusInfo;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.PictureBox pictureBoxBar;
        private System.Windows.Forms.PictureBox pb_uninstall_cn;
        private System.Windows.Forms.PictureBox pb_uninstall_us;
        private System.Windows.Forms.Label percentData;
        private System.Windows.Forms.Label percentSign;

    }
}

