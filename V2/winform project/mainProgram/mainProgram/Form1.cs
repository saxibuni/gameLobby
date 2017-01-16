using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


//主程序
//1、检测版本（注册表）
//2、版本更新
//3、zip解压覆盖
//4、修改注册表版本号；
//5、启动gaming应用程序
namespace mainProgram
{
    public partial class Form1 : Form
    {

        //配置
        string merchantName = "";
        string language = "";
        string release = "";
        string baseUrl = "";

        ArrayList verList = new ArrayList();        //服务器需要更新的版本号数组
        ArrayList packageSizeList = new ArrayList();//每个更新包的大小
        string localVersion;                        //本地版本号
        System.Threading.Timer FileTm = null;       //定时器
        Thread th = null;                           //线程对象
        float fileRate = 0;                         //下载速度（带单位）
        float fileTemp = 0;                         //单位时间下载字节数
        int count = 3;                              //线程“重启”的次数
        Language olanguage;                         //语言对象
        int currentPackageIndex = 0;                //当前在更新第几个包
        long AllDownSize = 0;                       //总共下载的字节数

        public class barData
        {
            public int Value = 0;
            public int Maximum = 0;
        }
        barData picBarData = new barData();         //进度条


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dynamic model = JsonHelper.getPackage();
            merchantName = model["merchantCode"];
            language = model["lan"];
            release = model["release"];
            baseUrl = model["updateUrl"];

            olanguage = (Language)Assembly.GetExecutingAssembly().CreateInstance("mainProgram." + language);
            pb_starting_cn.Visible = false;
            pb_starting_us.Visible = false;
            switch (language)
            {
                case "en_us":
                    pb_install_us.Visible = true;
                    break;
                case "zh_cn":
                    pb_update_cn.Visible = true;
                    break;
                default:
                    break;
            }

            if (ReadXml())
            {
                StartUpdate();
            }
            //直接启动文件
            else
            {
                StartExe();
            }
        }

        // 获取所有更新包版本号  如果有则需要更新
        private bool ReadXml()
        {
            RegistryKey src = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
            RegistryKey read = src.CreateSubKey(merchantName + "_" + release + "_" + language);
            Object regVerObj = read.GetValue("DisplayVersion");
            localVersion = regVerObj == null ? "1_0_0" : regVerObj.ToString().Replace(".", "_");

            try
            {
                int verNum = Convert.ToInt16(localVersion.Replace("_", ""));
                string xmlUrl = baseUrl + "version.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlUrl);    //加载Xml文件  

                XmlNodeList xns = doc.SelectNodes("//vers/ver");
                for (int i = 0; i < xns.Count; i++)
                {
                    int currentVerNum = Convert.ToInt16(xns[i].InnerText.Replace("_", ""));
                    if (currentVerNum > verNum)
                    {
                        verList.Add(xns[i].InnerText);
                    }
                }
            }
            catch (Exception ex)
            {
                string spade_update_log = Path.GetTempPath() + "spade_update_log.txt";
                File.AppendAllText(spade_update_log, ex.Message);
            }

            return (verList.Count > 0);
        }

        // 获取每个包和所有包的大小
        private int GetAllPackageSize()
        {
            long allSize = 0;
            try
            {
                for (int i = 0; i < verList.Count; i++)
                {
                    string url = baseUrl + "upgrade\\" + "package_" + verList[i] + ".zip";
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse res = (HttpWebResponse)httpWebRequest.GetResponse();

                    long result = 0;
                    if (res.Headers["Content-Length"] != null)
                    {
                        string s = res.Headers["Content-Length"];
                        if (!long.TryParse(s, out result))
                        {
                            result = 0;
                        }
                    }
                    packageSizeList.Add(result);
                    allSize += result;

                    res.Close();
                }
            }
            catch (Exception ex)
            {
                string spade_update_log = Path.GetTempPath() + "spade_update_log.txt";
                File.AppendAllText(spade_update_log, ex.Message);
            }
            return (int)allSize;
        }

        // 启动程序
        private void StartExe()
        {
            pb_update_cn.Visible = false;
            pb_install_us.Visible = false;
            progressPanel.Visible = false;
            pictureBoxBar.Visible = false;
            timeLeft.Visible = false;
            transferSpeed.Visible = false;
            statusIntro.Visible = false;

            switch (language)
            {
                case "en_us":
                    pb_starting_us.Visible = true;
                    break;
                case "zh_cn":
                    pb_starting_cn.Visible = true;
                    break;
                default:
                    break;
            }

            string strFileName = GetInstallPath() + "Lobby Gaming.exe";
            if (File.Exists(strFileName))
            {
                Process.Start(strFileName);
            }
            this.Close();
            System.Environment.Exit(0);
        }

        // 开始下载
        private void StartUpdate()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            progressPanel.Visible = true;
            pictureBoxBar.Visible = true;
            timeLeft.Text = olanguage.leftTime + "—";
            transferSpeed.Text = olanguage.transferSpeed + "—";

            th = new Thread(new ThreadStart(DownloadFunc));
            th.Start();
        }

        // 重新下载
        private void RestartDownload()
        {
            if (FileTm != null)
            {
                FileTm.Dispose();
            }

            //3次重连，连不上提示网络问题
            if (count > 1)
            {
                new Thread(new ThreadStart(DownloadFunc)).Start();
                count--;
            }
            else
            {
                statusIntro.Text = olanguage.net_error2;
            }
        }

        // 断点续传下载
        private void DownloadFunc()
        {
            int bufferSize = 10;
            long totalDownloadedByte = 0;               //已下载的字节数
            long totalBytes = 0;                        //当前下载包的总字节数
            string downVersion = verList[currentPackageIndex].ToString();
            string strFileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\package_" + downVersion + ".zip";
            string url = baseUrl + "upgrade\\" + "package_" + downVersion + ".zip";

            FileStream fs = null;
            Stream stream = null;

            FileMode fm = FileMode.Create;
            HttpWebRequest httpWebRequest;
            HttpWebResponse response;

            statusIntro.Visible = false;
            transferSpeed.Visible = true;
            timeLeft.Visible = true;

            //打开网络
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url);


                //设置进度条最大数
                picBarData.Maximum = GetAllPackageSize();

                if (File.Exists(strFileName))
                {
                    FileInfo fn = new FileInfo(strFileName);
                    totalDownloadedByte = fn.Length;
                    httpWebRequest.AddRange(fn.Length);
                    fm = FileMode.Append;
                }
                totalBytes = long.Parse(packageSizeList[currentPackageIndex].ToString());
                AllDownSize = getAllDownSize() + totalDownloadedByte;

                //當前這個包下完了
                if (totalBytes == totalDownloadedByte)
                {
                    picBarData.Value = (int)(getAllDownSize() + totalBytes);
                    pictureBoxBar.Width = (int)((double)(totalDownloadedByte) / (double)(picBarData.Maximum) * 343);
                    percentData.Text = ((int)((double)(totalDownloadedByte) / (double)(picBarData.Maximum) * 100)).ToString();
                    InstallPackage(strFileName, downVersion);
                    return;
                }

                response = (HttpWebResponse)httpWebRequest.GetResponse();
                stream = httpWebRequest.GetResponse().GetResponseStream();
                fs = new FileStream(strFileName, fm);
            }
            catch (Exception)
            {
                transferSpeed.Visible = false;
                timeLeft.Visible = false;
                statusIntro.Visible = true;
                statusIntro.Text = olanguage.net_error1;
                RestartDownload();
                return;
            }


            //开始下载
            try
            {
                byte[] nbytes = new byte[bufferSize];
                int nReadSize = 0;
                FileTm = new System.Threading.Timer(SpeedTimer, null, 0, 1000);//使用回调函数，每1秒执行一次

                nReadSize = stream.Read(nbytes, 0, bufferSize);
                while (nReadSize > 0 || totalDownloadedByte < totalBytes)
                {
                    fileTemp += nReadSize;
                    AllDownSize += nReadSize;
                    totalDownloadedByte += nReadSize;
                    picBarData.Value = (int)AllDownSize;
                    pictureBoxBar.Width = (int)((double)(AllDownSize) / (double)(picBarData.Maximum) * 343);
                    percentData.Text = ((int)((double)(totalDownloadedByte) / (double)(picBarData.Maximum) * 100)).ToString();
                    System.Windows.Forms.Application.DoEvents();
                    fs.Write(nbytes, 0, nReadSize);
                    nReadSize = stream.Read(nbytes, 0, bufferSize);
                    fs.Flush();
                }
                FileTm.Dispose();
                fs.Close();
                stream.Close();
                response.Close();
                InstallPackage(strFileName, downVersion);
            }
            catch (Exception)
            {
                FileTm.Dispose();
                fs.Close();
                fs.Dispose();
                response.Close();
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
                transferSpeed.Visible = false;
                timeLeft.Visible = false;
                statusIntro.Visible = true;
                statusIntro.Text = olanguage.net_error1;
                RestartDownload();
            }
        }

        // 獲取已經下載的包下了多少字節
        private long getAllDownSize()
        {
            long size = 0;

            for (int i = 0; i < currentPackageIndex; i++)
            {
                size += long.Parse(packageSizeList[currentPackageIndex].ToString());
            }

            return size;
        }

        // 解压当前更新包 下载下一个更新包
        private void InstallPackage(string strFileName, string downloadVer)
        {
            FileUnZip.UnZip(strFileName, Path.GetDirectoryName(Application.ExecutablePath), true);
            ModifyReg(downloadVer);
            if (localVersion != verList[verList.Count - 1].ToString())
            {
                //还未下完 开启线程继续下载
                currentPackageIndex++;
                count = 3;
                new Thread(new ThreadStart(DownloadFunc)).Start();
            }
            else
            {
                StartExe();
            }
        }

        // 下载状态信息
        private void SpeedTimer(object state)
        {
            fileRate = fileTemp / 1024; //kb/秒,
            fileTemp = 0; //清空临时储存

            Action act = () =>
            {
                if (fileRate > 1000)
                {
                    transferSpeed.Text = olanguage.transferSpeed + (fileRate / 1024).ToString("0.0") + "Mb/" + olanguage.second;
                }
                else
                {
                    transferSpeed.Text = olanguage.transferSpeed + fileRate.ToString("0.00") + "Kb/" + olanguage.second;
                }
            };

            Action act1 = () =>
            {
                if (fileRate > 0)
                {
                    int seconds = Convert.ToInt32((picBarData.Maximum - picBarData.Value) / 1024 / fileRate);
                    if (seconds < 60)
                    {
                        timeLeft.Text = olanguage.leftTime + seconds + olanguage.second;
                    }
                    else
                    {
                        if (seconds > 3600)
                        {
                            timeLeft.Text = olanguage.leftTime +
                                            Convert.ToInt32(seconds / 3600).ToString() + olanguage.hour +
                                            Convert.ToInt32((seconds % 3600) / 60).ToString() + olanguage.minute +
                                            Convert.ToInt32(seconds % 60).ToString() + olanguage.second;
                        }
                        else
                        {
                            timeLeft.Text = olanguage.leftTime + Convert.ToInt32(seconds / 60).ToString() + olanguage.minute + (seconds % 60) + olanguage.second;
                        }
                    }
                }
            };
            transferSpeed.Invoke(act);
            timeLeft.Invoke(act1);
        }

        // 修改注册表版本号
        private void ModifyReg(string downloadVer)
        {
            RegistryKey src = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
            RegistryKey read = src.CreateSubKey(merchantName + "_" + release + "_" + language);
            localVersion = downloadVer;
            read.SetValue("DisplayVersion", localVersion.Replace("_", "."));
        }

        // 获取安装路径
        private string GetInstallPath()
        {
            RegistryKey src = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
            RegistryKey read = src.CreateSubKey(merchantName + "_" + release + "_" + language);
            Object regInstallPathObj = read.GetValue("UninstallPath");
            string installPath = regInstallPathObj == null ? Path.GetDirectoryName(Application.ExecutablePath) : regInstallPathObj.ToString();
            return installPath + "\\";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FileTm != null)
            {
                FileTm.Dispose();
            }
            Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
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
