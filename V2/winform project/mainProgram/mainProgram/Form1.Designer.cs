namespace mainProgram
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
            this.statusIntro = new System.Windows.Forms.Label();
            this.timeLeft = new System.Windows.Forms.Label();
            this.transferSpeed = new System.Windows.Forms.Label();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.pictureBoxBar = new System.Windows.Forms.PictureBox();
            this.pb_update_cn = new System.Windows.Forms.PictureBox();
            this.pb_install_us = new System.Windows.Forms.PictureBox();
            this.pb_starting_cn = new System.Windows.Forms.PictureBox();
            this.pb_starting_us = new System.Windows.Forms.PictureBox();
            this.percentData = new System.Windows.Forms.Label();
            this.percentSign = new System.Windows.Forms.Label();
            this.progressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_update_cn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_install_us)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_starting_cn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_starting_us)).BeginInit();
            this.SuspendLayout();
            // 
            // statusIntro
            // 
            this.statusIntro.BackColor = System.Drawing.Color.Transparent;
            this.statusIntro.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.statusIntro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.statusIntro.Location = new System.Drawing.Point(25, 216);
            this.statusIntro.Name = "statusIntro";
            this.statusIntro.Size = new System.Drawing.Size(350, 16);
            this.statusIntro.TabIndex = 6;
            // 
            // timeLeft
            // 
            this.timeLeft.BackColor = System.Drawing.Color.Transparent;
            this.timeLeft.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.timeLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.timeLeft.Location = new System.Drawing.Point(30, 215);
            this.timeLeft.Name = "timeLeft";
            this.timeLeft.Size = new System.Drawing.Size(170, 16);
            this.timeLeft.TabIndex = 7;
            // 
            // transferSpeed
            // 
            this.transferSpeed.BackColor = System.Drawing.Color.Transparent;
            this.transferSpeed.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.transferSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.transferSpeed.Location = new System.Drawing.Point(209, 215);
            this.transferSpeed.Name = "transferSpeed";
            this.transferSpeed.Size = new System.Drawing.Size(155, 16);
            this.transferSpeed.TabIndex = 8;
            // 
            // progressPanel
            // 
            this.progressPanel.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel.BackgroundImage = global::mainProgram.Properties.Resources.progress;
            this.progressPanel.Controls.Add(this.pictureBoxBar);
            this.progressPanel.Location = new System.Drawing.Point(24, 194);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(348, 19);
            this.progressPanel.TabIndex = 27;
            this.progressPanel.Visible = false;
            // 
            // pictureBoxBar
            // 
            this.pictureBoxBar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBar.BackgroundImage = global::mainProgram.Properties.Resources.load;
            this.pictureBoxBar.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxBar.Name = "pictureBoxBar";
            this.pictureBoxBar.Size = new System.Drawing.Size(0, 12);
            this.pictureBoxBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBar.TabIndex = 24;
            this.pictureBoxBar.TabStop = false;
            this.pictureBoxBar.Visible = false;
            // 
            // pb_update_cn
            // 
            this.pb_update_cn.BackColor = System.Drawing.Color.Transparent;
            this.pb_update_cn.BackgroundImage = global::mainProgram.Properties.Resources.update_cn;
            this.pb_update_cn.Location = new System.Drawing.Point(146, 231);
            this.pb_update_cn.Name = "pb_update_cn";
            this.pb_update_cn.Size = new System.Drawing.Size(100, 35);
            this.pb_update_cn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_update_cn.TabIndex = 29;
            this.pb_update_cn.TabStop = false;
            // 
            // pb_install_us
            // 
            this.pb_install_us.BackColor = System.Drawing.Color.Transparent;
            this.pb_install_us.BackgroundImage = global::mainProgram.Properties.Resources.update_us;
            this.pb_install_us.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_install_us.Location = new System.Drawing.Point(145, 231);
            this.pb_install_us.Name = "pb_install_us";
            this.pb_install_us.Size = new System.Drawing.Size(96, 35);
            this.pb_install_us.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_install_us.TabIndex = 30;
            this.pb_install_us.TabStop = false;
            this.pb_install_us.Visible = false;
            // 
            // pb_starting_cn
            // 
            this.pb_starting_cn.BackColor = System.Drawing.Color.Transparent;
            this.pb_starting_cn.BackgroundImage = global::mainProgram.Properties.Resources.start_cn;
            this.pb_starting_cn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_starting_cn.Location = new System.Drawing.Point(140, 199);
            this.pb_starting_cn.Name = "pb_starting_cn";
            this.pb_starting_cn.Size = new System.Drawing.Size(117, 39);
            this.pb_starting_cn.TabIndex = 31;
            this.pb_starting_cn.TabStop = false;
            // 
            // pb_starting_us
            // 
            this.pb_starting_us.BackColor = System.Drawing.Color.Transparent;
            this.pb_starting_us.BackgroundImage = global::mainProgram.Properties.Resources.start_us;
            this.pb_starting_us.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_starting_us.Location = new System.Drawing.Point(109, 199);
            this.pb_starting_us.Name = "pb_starting_us";
            this.pb_starting_us.Size = new System.Drawing.Size(179, 34);
            this.pb_starting_us.TabIndex = 32;
            this.pb_starting_us.TabStop = false;
            // 
            // percentData
            // 
            this.percentData.BackColor = System.Drawing.Color.Transparent;
            this.percentData.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.percentData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(77)))), ((int)(((byte)(48)))));
            this.percentData.Location = new System.Drawing.Point(157, 170);
            this.percentData.Name = "percentData";
            this.percentData.Size = new System.Drawing.Size(45, 20);
            this.percentData.TabIndex = 33;
            this.percentData.Text = "0";
            this.percentData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // percentSign
            // 
            this.percentSign.BackColor = System.Drawing.Color.Transparent;
            this.percentSign.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.percentSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(77)))), ((int)(((byte)(48)))));
            this.percentSign.Location = new System.Drawing.Point(195, 173);
            this.percentSign.Name = "percentSign";
            this.percentSign.Size = new System.Drawing.Size(15, 17);
            this.percentSign.TabIndex = 34;
            this.percentSign.Text = "%";
            this.percentSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::mainProgram.Properties.Resources.loading_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.percentSign);
            this.Controls.Add(this.percentData);
            this.Controls.Add(this.pb_starting_us);
            this.Controls.Add(this.pb_starting_cn);
            this.Controls.Add(this.pb_install_us);
            this.Controls.Add(this.pb_update_cn);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.transferSpeed);
            this.Controls.Add(this.timeLeft);
            this.Controls.Add(this.statusIntro);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.progressPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_update_cn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_install_us)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_starting_cn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_starting_us)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label statusIntro;
        private System.Windows.Forms.Label timeLeft;
        private System.Windows.Forms.Label transferSpeed;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.PictureBox pictureBoxBar;
        private System.Windows.Forms.PictureBox pb_update_cn;
        private System.Windows.Forms.PictureBox pb_install_us;
        private System.Windows.Forms.PictureBox pb_starting_cn;
        private System.Windows.Forms.PictureBox pb_starting_us;
        private System.Windows.Forms.Label percentData;
        private System.Windows.Forms.Label percentSign;
    }
}

