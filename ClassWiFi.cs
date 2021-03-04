using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLocalWiFiKey
{
    public class ClassWiFi
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClassWiFi()
        {
            
        }

        public Dictionary<string,string> GetWiFiInfo()
        {
            Dictionary<string, string> dicWiFi = new Dictionary<string, string>();
            string[] arrSSID = GetWiFiSSID();
            if (arrSSID.Length > 0)
            {
                foreach (string item in arrSSID)
                {
                    dicWiFi.Add(item, "");
                }
                object lockObj = new object();
                Parallel.ForEach(arrSSID, (item) => {
                    string key = GetWiFiKey(item);
                    lock (lockObj)
                    {
                        dicWiFi[item] = key;
                    }
                });
            }
            return dicWiFi;
        }

        /// <summary>
        /// 获取指定WiFi密码
        /// </summary>
        /// <param name="ssid"></param>
        /// <returns></returns>
        public string GetWiFiKey(string ssid)
        {
            string strWifiInfo;
            try
            {
                const string DEFAULT = "    关键内容            : ";
                strWifiInfo = RunCommand("wlan show profile \"" + ssid + "\" key=clear" );
                int start = strWifiInfo.IndexOf(DEFAULT);
                if (start > 0)
                {
                    strWifiInfo = strWifiInfo.Substring(start + DEFAULT.Length);
                    int end = strWifiInfo.IndexOf("\r\n");
                    if (end > 0)
                    {
                        strWifiInfo = strWifiInfo.Substring(0, end);
                    }
                }
                else
                {
                    strWifiInfo = "无";
                }
            }
            catch (Exception)
            {
                strWifiInfo = "未知";
            }
            return strWifiInfo;
        }

        /// <summary>
        /// 获取Wifi名称
        /// </summary>
        /// <returns></returns>
        public string[] GetWiFiSSID()
        {
            string strWifiInfo;
            try
            {
                strWifiInfo = RunCommand("wlan show profile");
                int start = strWifiInfo.IndexOf("    所有用户配置文件 : ");
                if (start > 0)
                {
                    strWifiInfo = strWifiInfo.Substring(start).Replace("    所有用户配置文件 : ","");
                }
                else
                {
                    return new string[] { };
                }
            }
            catch (Exception)
            {
                return new string[] { };
            }
            
            return strWifiInfo.Trim().Replace("\r","").Split('\n');
        }

        /// <summary>
        /// Process类执行DOS命令
        /// </summary>
        /// <param name="command">执行的命令行</param>
        /// <returns></returns>
        private string RunCommand(string command)
        {
            string returnStr = null;
            //實例一個Process類，啟動一個獨立進程
            Process p = new Process();
            //Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：
            p.StartInfo.FileName = "netsh.exe";  //設定程序名
            p.StartInfo.Arguments = command;            //設定程式執行參數
            p.StartInfo.Verb = "runas";
            p.StartInfo.UseShellExecute = false;        //關閉Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向標準輸入
            p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出
            p.StartInfo.RedirectStandardError = true;   //重定向錯誤輸出
            p.StartInfo.CreateNoWindow = true;          //設置不顯示窗口
            p.Start();                                  //啟動
            returnStr = p.StandardOutput.ReadToEnd();     //赋值
            p.Dispose();                                //释放资源
            return returnStr;        //從輸出流取得命令執行結果
        }
    }
}
