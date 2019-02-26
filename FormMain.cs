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
    }
}
