namespace downLoader
{
    partial class ComfirmForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComfirmForm));
            this.statusIntro = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.comfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusIntro
            // 
            this.statusIntro.BackColor = System.Drawing.Color.Transparent;
            this.statusIntro.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.statusIntro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.statusIntro.Location = new System.Drawing.Point(38, 91);
            this.statusIntro.Name = "statusIntro";
            this.statusIntro.Size = new System.Drawing.Size(289, 30);
            this.statusIntro.TabIndex = 39;
            this.statusIntro.Text = "comfirm exit the installation ? ";
            this.statusIntro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.closeBtn.Location = new System.Drawing.Point(356, 18);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(16, 16);
            this.closeBtn.TabIndex = 38;
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.Transparent;
            this.cancel.BackgroundImage = global::downLoader.Properties.Resources.btn_on;
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.FlatAppearance.BorderSize = 0;
            this.cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.cancel.ForeColor = System.Drawing.Color.Khaki;
            this.cancel.Location = new System.Drawing.Point(192, 183);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(133, 43);
            this.cancel.TabIndex = 37;
            this.cancel.Text = "取 消";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // comfirm
            // 
            this.comfirm.BackColor = System.Drawing.Color.Transparent;
            this.comfirm.BackgroundImage = global::downLoader.Properties.Resources.btn_on;
            this.comfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comfirm.FlatAppearance.BorderSize = 0;
            this.comfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.comfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.comfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comfirm.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.comfirm.ForeColor = System.Drawing.Color.Khaki;
            this.comfirm.Location = new System.Drawing.Point(35, 183);
            this.comfirm.Name = "comfirm";
            this.comfirm.Size = new System.Drawing.Size(133, 43);
            this.comfirm.TabIndex = 36;
            this.comfirm.Text = "确 定";
            this.comfirm.UseVisualStyleBackColor = false;
            this.comfirm.Click += new System.EventHandler(this.comfirm_Click);
            // 
            // ComfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BackgroundImage = global::downLoader.Properties.Resources.comfirm_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(388, 256);
            this.Controls.Add(this.statusIntro);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.comfirm);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComfirmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ComfirmForm";
            this.TransparencyKey = System.Drawing.Color.Linen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label statusIntro;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button comfirm;


    }
}