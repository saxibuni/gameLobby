using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace downLoader
{
    public partial class ComfirmForm : Form
    {
        public bool isClose = false;
        Language olanguage;
        string merchantName;
        string lan;


        public ComfirmForm(string lan, string merchantName)
        {
            InitializeComponent();
            this.lan = lan;
            this.merchantName = merchantName;
            olanguage = (Language)Assembly.GetExecutingAssembly().CreateInstance("downLoader." + lan);
            statusIntro.Text = olanguage.comfirmExit;
            comfirm.Text = olanguage.comfirm;
            cancel.Text = olanguage.cancel;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comfirm_Click(object sender, EventArgs e)
        {
            try
            {
                deleteOtherLanguageShotCut(lan);
                downloadShotCut();
                Process.GetCurrentProcess().Kill();
                this.Close();
                System.Environment.Exit(0);
            }
            catch (Exception)
            {
                this.Close();
                System.Environment.Exit(0);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 写下载器的快捷方式
        private void downloadShotCut()
        {
            string shotcutName = merchantName.ToUpper().Replace("DEMO", "") + " " + olanguage.continueSetup;

            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + shotcutName + ".lnk");
            shortcut.TargetPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + new FileInfo(Application.ExecutablePath).Name; //目标文件
            shortcut.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);  //起始位置
            shortcut.Arguments = lan;
            shortcut.Save();
        }


        private void deleteOtherLanguageShotCut(string lan)
        {
            Language language_cn = (Language)Assembly.GetExecutingAssembly().CreateInstance("downLoader." + "zh_cn");
            Language language_us = (Language)Assembly.GetExecutingAssembly().CreateInstance("downLoader." + "en_us");

            string shotcut_cn = merchantName.ToUpper().Replace("DEMO", "") + " " + language_cn.continueSetup;
            string shotcut_us = merchantName.ToUpper().Replace("DEMO", "") + " " + language_us.continueSetup;


            //删除继续安装程序快捷方式
            string downloadlnkName_cn = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + shotcut_cn + ".lnk";
            string downloadlnkName_us = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + shotcut_us + ".lnk";

            if (File.Exists(downloadlnkName_cn) && lan != "zh_cn")
            {
                File.Delete(downloadlnkName_cn);
            }

            if (File.Exists(downloadlnkName_us) && lan != "en_us")
            {
                File.Delete(downloadlnkName_us);
            }


        }

    }
}
