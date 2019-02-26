using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewLocalWiFiKey
{
    public partial class FormMain : Form
    {
        private ClassWiFi ObjWiFi;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ObjWiFi = new ClassWiFi();

            this.Text += @" V" + Application.ProductVersion.ToString();

            InitListView(listViewWifi);
            //GetWiFiListViewData(listViewWifi);
        }

        /// <summary>
        /// 初始化列表界面
        /// </summary>
        /// <param name="listView"></param>
        private void InitListView(ListView listView)
        {
            //基本属性设置
            listView.Clear();
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView.View = View.Details;

            //创建列表头
            listView.Columns.Add("序号", 40, HorizontalAlignment.Center);
            listView.Columns.Add("WiFi名称", 135, HorizontalAlignment.Center);
            listView.Columns.Add("WiFi密码", 135, HorizontalAlignment.Center);
        }

        /// <summary>
        /// 获取选中列表项
        /// </summary>
        /// <param name="listView"></param>
        /// <returns></returns>
        private ListViewItem GetSelectListViewItem(ListView listView)
        {
            if (listView.SelectedItems.Count == 1)
            {
                return listView.SelectedItems[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取列表文本
        /// </summary>
        /// <param name="listView"></param>
        /// <returns></returns>
        private string GetListViewText(ListView listView)
        {
            StringBuilder ret = new StringBuilder(listView.Columns[1].Text + "\t" + listView.Columns[2].Text + "\r\n");
            foreach (ListViewItem item in listView.Items)
            {
                ret.AppendLine(item.SubItems[1].Text + "\t" + item.SubItems[2].Text);
            }
            return ret.ToString();
        }

        /// <summary>
        /// 获取WiFi列表数据
        /// </summary>
        /// <param name="listView"></param>
        private void GetWiFiListViewData(ListView listView)
        {
            InitListView(listView);
            string[] arrSSID = ObjWiFi.GetWiFiSSID();
            if (arrSSID.Length > 0)
            {
                foreach (string item in arrSSID)
                {
                    this.Refresh();
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = (listView.Items.Count + 1).ToString();
                    listViewItem.SubItems.Add(item);
                    listViewItem.SubItems.Add(ObjWiFi.GetWiFiKey(item));
                    listView.Items.Add(listViewItem);
                }
            }
            else
            {
                MessageBox.Show("未找到WiFi信息。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWifi_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            GetWiFiListViewData(listViewWifi);
            ((Button)sender).Enabled = true;
        }

        /// <summary>
        /// 页面加载完成时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Shown(object sender, EventArgs e)
        {
            GetWiFiListViewData(listViewWifi);
            btnWifi.Enabled = true;
        }

        /// <summary>
        /// 菜单刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuWiFi_Click(object sender, EventArgs e)
        {
            btnWifi.Enabled = false;
            GetWiFiListViewData(listViewWifi);
            btnWifi.Enabled = true;
        }

        /// <summary>
        /// 菜单复制Wifi密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuCopyKey_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = GetSelectListViewItem(listViewWifi);
            if (listViewItem != null)
            {
                Clipboard.SetDataObject(listViewItem.SubItems[2].Text, true);
                MessageBox.Show("已复制选中项密码。", "复制", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("请先选中要复制的内容。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 菜单复制WiFi名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuCopySSID_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = GetSelectListViewItem(listViewWifi);
            if (listViewItem != null)
            {
                Clipboard.SetDataObject(listViewItem.SubItems[1].Text, true);
                MessageBox.Show("已复制选中项SSID。", "复制", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("请先选中要复制的内容。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 保存Wifi信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件（*.txt）|*.txt|表格文件（*.csv）|*.csv";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            sfd.FileName = "备份WiFi信息";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                ClassFile.WriteFile(localFilePath, GetListViewText(listViewWifi));
                MessageBox.Show("【" + fileNameExt + "】备份完成。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            sfd.Dispose();
        }
    }
}
