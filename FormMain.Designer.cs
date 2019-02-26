namespace ViewLocalWiFiKey
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listViewWifi = new System.Windows.Forms.ListView();
            this.btnWifi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewWifi
            // 
            this.listViewWifi.Location = new System.Drawing.Point(12, 41);
            this.listViewWifi.Name = "listViewWifi";
            this.listViewWifi.Size = new System.Drawing.Size(335, 397);
            this.listViewWifi.TabIndex = 0;
            this.listViewWifi.UseCompatibleStateImageBehavior = false;
            // 
            // btnWifi
            // 
            this.btnWifi.Enabled = false;
            this.btnWifi.Location = new System.Drawing.Point(12, 12);
            this.btnWifi.Name = "btnWifi";
            this.btnWifi.Size = new System.Drawing.Size(335, 23);
            this.btnWifi.TabIndex = 1;
            this.btnWifi.Text = "刷新";
            this.btnWifi.UseVisualStyleBackColor = true;
            this.btnWifi.Click += new System.EventHandler(this.btnWifi_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 450);
            this.Controls.Add(this.btnWifi);
            this.Controls.Add(this.listViewWifi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看本地WiFi密码";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewWifi;
        private System.Windows.Forms.Button btnWifi;
    }
}

