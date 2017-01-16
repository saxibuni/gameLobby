using Microsoft.Win32;
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

namespace uninstall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string merchantName = "";
        string release = "";
        string shotCut_cn = "";
        string shotCut_en = "";
        string shotCutName = "";                    //快捷方式 开始菜单名
        string language = "";
        Language olanguage;

        public class barData
        {
            public int Value = 0;
            public int Maximum = 0;
        }
        barData picBarData = new barData();         //进度条

        private void Form1_Load(object sender, EventArgs e)
        {
            dynamic model = JsonHelper.getPackage();
            merchantName = model["merchantCode"];
            language = model["lan"];
            release = model["release"];
            shotCut_cn = model["shotCut_cn"];
            shotCut_en = model["shotCut_en"];

            merchant.Text = merchantName.ToUpper().Replace("DEMO", "") + " GAMING";

            olanguage = (Language)Assembly.GetExecutingAssembly().CreateInstance("uninstall." + language);
            btnUninstall.Text = olanguage.btnRemove;
            btnCancel.Text = olanguage.btnStartGame;
            btnComplete.Text = olanguage.btnComplete;
            percentData.Visible = false;
            percentSign.Visible = false;

            SetStatusIntro(comfirmTxt, string.Format(olanguage.confirmTxt, merchantName.ToUpper().Replace("DEMO", "")), true);
        }

        //关闭
        private void closeBtn_Click(object sender, EventArgs e)
        {
            //卸载完成
            if (btnComplete.Visible)
            {
                DeleteItself();
            }
            this.Close();
            System.Environment.Exit(0);
        }

        //卸载游戏
        private void BtnUninstall_Click(object sender, EventArgs e)
        {
            if (!CheckIsUsed())
            {
                ShowBar();
            }
            else {
                return;
            }
            string installPath = GetInstallPath();
            string[] directorys = { "locales", "resources" };
            string[] files = {
                                "Lobby Gaming.exe",
                                "content_resources_200_percent.pak",
                                "content_shell.pak",
                                "d3dcompiler_47.dll",
                                "ffmpeg.dll",
                                "icudtl.dat",
                                "libEGL.dll",
                                "libGLESv2.dll",
                                "LICENSE",
                                "LICENSES.chromium.html",
                                "msvcp120.dll",
                                "msvcr120.dll",
                                "natives_blob.bin",
                                "node.dll",
                                "snapshot_blob.bin",
                                "ui_resources_200_percent.pak",
                                "vccorlib120.dll",
                                "version",
                                "xinput1_3.dll",
                                "mainProgram.exe"
                             };
            int value = 0;            
            picBarData.Maximum = (directorys.Length + files.Length) * 1000;

            foreach (string file in files)
            {
                
                SetStatusIntro(statusInfo, olanguage.removeFile + file, false);
                value++;
                if (File.Exists(installPath + file))
                {
                    File.Delete(installPath + file);
                }
                //增加进度条状态变化频率
                for (int i = picBarData.Value; i < 1000 * value; i++)
                {
                    picBarData.Value = i;
                    pictureBoxBar.Width = (int)((double)(picBarData.Value) / (double)(picBarData.Maximum) * 343);
                    percentData.Text = ((int)((double)(picBarData.Value) / (double)(picBarData.Maximum) * 100)).ToString();
                    System.Windows.Forms.Application.DoEvents();
                }
                System.Threading.Thread.Sleep(30);
            }

            foreach (string floder in directorys)
            {
                SetStatusIntro(statusInfo, olanguage.removeFile + floder, false);
                value++;
                if (Directory.Exists(installPath + floder))
                {
                    Directory.Delete(installPath + floder, true);
                }
                //增加进度条状态变化频率
                for (int i = picBarData.Value; i < 1000 * value; i++)
                {
                    picBarData.Value = i;
                    pictureBoxBar.Width = (int)((double)(picBarData.Value) / (double)(picBarData.Maximum) * 343);
                    percentData.Text = ((int)((double)(picBarData.Value) / (double)(picBarData.Maximum) * 100)).ToString();
                    System.Windows.Forms.Application.DoEvents();
                }
                System.Threading.Thread.Sleep(30);

                if (value * 1000 == picBarData.Maximum)
                {
                    DeleteReg();
                    troggleUI();
                }
            }

        }

        //取消卸载(继续游戏)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            string installPath = GetInstallPath();
            string strFileName = installPath + "\\" + "Lobby Gaming.exe";
            if (File.Exists(strFileName))
            {
                Process.Start(strFileName);
            }

            System.Environment.Exit(0);
        }

        //卸载完成
        private void btnComplete_Click(object sender, EventArgs e)
        {
            DeleteItself();
        }

        //卸载完成UI
        private void troggleUI()
        {
            comfirmTxt.Visible = false;
            btnUninstall.Visible = false;
            btnCancel.Visible = false;
            pb_uninstall_us.Visible = false;
            pb_uninstall_cn.Visible = false;

            progressPanel.Visible = false;
            pictureBoxBar.Visible = false;
            percentData.Visible = false;
            percentSign.Visible = false;
            System.Windows.Forms.Application.DoEvents();

            statusInfo.Visible = false;
            System.Windows.Forms.Application.DoEvents();

            btnComplete.Visible = true;
        }

        //程序占用检测
        private bool CheckIsUsed()
        {
            if (System.Diagnostics.Process.GetProcessesByName(merchantName + " Gaming").ToList().Count > 0)
            {
                MessageBox.Show(olanguage.isUsed);
                return true;
            }
            else
            {
                return false;
            }
        }

        // 删除自身
        private void DeleteItself()
        {
            //获取文件夹路径
            string merchantFolder = Path.GetDirectoryName(Application.ExecutablePath);

            //获取当前盘符
            string volume = merchantFolder.Substring(0, merchantFolder.IndexOf(':'));

            string vBatFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\DeleteItself.bat";
            using (StreamWriter vStreamWriter = new StreamWriter(vBatFile, false, Encoding.Default))
            {
                var script = string.Format(
                    ":del\r\n" +
                    "del \"{0}\"\r\n" +
                    "if exist \"{0}\" goto del\r\n" +
                    volume + ":\r\n" +      //跳转盘符
                    "cd " + merchantFolder + "\r\n" +  //跳转文件执行路径
                    "cd.." + "\r\n" +
                    //"echo %cd% >> c:\\a.txt\r\n" +
                    "rd/s/q " + merchantName + "_" + release + "(" + language + ")" + "\r\n"
                    , Application.ExecutablePath); 
                vStreamWriter.Write(script);
            }
            //************ 执行批处理
            WinExec(vBatFile, 0);
            //************ 结束退出
            Application.Exit();
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern uint WinExec(string lpCmdLine, uint uCmdShow);

        //删除安装注册表、快捷方式、快速启动栏
        private void DeleteReg()
        {
            RegistryKey src = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
            string[] keyNames = src.GetSubKeyNames();
            foreach (string keyName in keyNames)
            {
                if (keyName == merchantName + "_" + release + "_" + language)
                {
                    src.DeleteSubKey(keyName);
                }
            }

            shotCutName = language == "en_us" ? shotCut_en : shotCut_cn;
            string lnkFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + shotCutName + ".lnk";
            if (File.Exists(lnkFile))
            {
                File.Delete(lnkFile);
            }

            var startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + "\\" + shotCutName + "\\";
            if (Directory.Exists(startupPath))
            {
                Directory.Delete(startupPath,true);
            }
        }

        //获取安装路径
        private string GetInstallPath()
        {
            RegistryKey src = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
            RegistryKey read = src.CreateSubKey(merchantName + "_" + release + "_" + language);
            Object regInstallPathObj = read.GetValue("UninstallPath");
            string installPath = regInstallPathObj == null ? Path.GetDirectoryName(Application.ExecutablePath) : regInstallPathObj.ToString();
            return installPath + "\\";
        }

        //设置卸载状态
        private void SetStatusIntro(Label sender, string info, bool icompleted)
        {
            sender.Text = info;
            if (icompleted)
                sender.Location = new Point((this.Width - sender.Width) / 2, sender.Location.Y);
            System.Windows.Forms.Application.DoEvents();
        }

        //显示卸载进度条
        private void ShowBar()
        {
            comfirmTxt.Visible = false;
            btnUninstall.Visible = false;
            btnCancel.Visible = false;
            progressPanel.Visible = true;
            pictureBoxBar.Visible = true;
            statusInfo.Visible = true;
            percentData.Visible = true;
            percentSign.Visible = true;

            switch (language)
            {
                case "en_us":
                    pb_uninstall_us.Visible = true;
                    break;
                case "zh_cn":
                    pb_uninstall_cn.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private Point mPoint = new Point();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            } 
        }

    }
}
