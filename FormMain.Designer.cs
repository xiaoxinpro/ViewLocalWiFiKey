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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listViewWifi = new System.Windows.Forms.ListView();
            this.btnWifi = new System.Windows.Forms.Button();
            this.menuListWifi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMenuCopyKey = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuCopySSID = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolMenuWiFi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuListWifi.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewWifi
            // 
            this.listViewWifi.ContextMenuStrip = this.menuListWifi;
            this.listViewWifi.Location = new System.Drawing.Point(12, 47);
            this.listViewWifi.MultiSelect = false;
            this.listViewWifi.Name = "listViewWifi";
            this.listViewWifi.Size = new System.Drawing.Size(335, 391);
            this.listViewWifi.TabIndex = 0;
            this.listViewWifi.UseCompatibleStateImageBehavior = false;
            // 
            // btnWifi
            // 
            this.btnWifi.Enabled = false;
            this.btnWifi.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWifi.Location = new System.Drawing.Point(12, 12);
            this.btnWifi.Name = "btnWifi";
            this.btnWifi.Size = new System.Drawing.Size(335, 29);
            this.btnWifi.TabIndex = 1;
            this.btnWifi.Text = "刷新";
            this.btnWifi.UseVisualStyleBackColor = true;
            this.btnWifi.Click += new System.EventHandler(this.btnWifi_Click);
            // 
            // menuListWifi
            // 
            this.menuListWifi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuWiFi,
            this.toolStripSeparator1,
            this.toolMenuCopyKey,
            this.toolMenuCopySSID,
            this.toolStripSeparator2,
            this.toolMenuSave});
            this.menuListWifi.Name = "menuListWifi";
            this.menuListWifi.Size = new System.Drawing.Size(149, 104);
            // 
            // toolMenuCopyKey
            // 
            this.toolMenuCopyKey.Name = "toolMenuCopyKey";
            this.toolMenuCopyKey.Size = new System.Drawing.Size(148, 22);
            this.toolMenuCopyKey.Text = "复制WiFi密码";
            this.toolMenuCopyKey.Click += new System.EventHandler(this.toolMenuCopyKey_Click);
            // 
            // toolMenuCopySSID
            // 
            this.toolMenuCopySSID.Name = "toolMenuCopySSID";
            this.toolMenuCopySSID.Size = new System.Drawing.Size(148, 22);
            this.toolMenuCopySSID.Text = "复制WiFi名称";
            this.toolMenuCopySSID.Click += new System.EventHandler(this.toolMenuCopySSID_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // toolMenuWiFi
            // 
            this.toolMenuWiFi.Name = "toolMenuWiFi";
            this.toolMenuWiFi.Size = new System.Drawing.Size(148, 22);
            this.toolMenuWiFi.Text = "刷新";
            this.toolMenuWiFi.Click += new System.EventHandler(this.toolMenuWiFi_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // toolMenuSave
            // 
            this.toolMenuSave.Name = "toolMenuSave";
            this.toolMenuSave.Size = new System.Drawing.Size(148, 22);
            this.toolMenuSave.Text = "备份WiFi信息";
            this.toolMenuSave.Click += new System.EventHandler(this.toolMenuSave_Click);
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
            this.menuListWifi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewWifi;
        private System.Windows.Forms.Button btnWifi;
        private System.Windows.Forms.ContextMenuStrip menuListWifi;
        private System.Windows.Forms.ToolStripMenuItem toolMenuWiFi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolMenuCopyKey;
        private System.Windows.Forms.ToolStripMenuItem toolMenuCopySSID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolMenuSave;
    }
}

