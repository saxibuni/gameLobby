using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using System;
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
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

// 在线安装程序
//1、下载zip压缩需要的dll文件   dll源码集成到项目中  不用了
//2、下载zip安装包，解压
//3、写入注册表信息
namespace downLoader
{
    public partial class Form1 : Form
    {   

        //配置
        string merchantName = "cmdcash";
        string release = "living";
        string lan = "en_us";
        string shotCut_cn = "cmd368_SG";
        string shotCut_en = "cmd368_SG";

        //string socket = "ws://lobbydev.egame.staging.spadegaming.biz:8080";
        //string gameUrl = "lobbydev.egame.staging.spadegaming.biz/index.jsp";
        //string baseUrl = "http://192.168.0.61:8080/pc__package/";

        string socket = "";
        string baseUrl = "";
        string gameUrl = "";

        //string cdnRouter = "http://www.spadebar.net/rngUrl.action";        //rng CDN
        //string cdnRouter = "http://www.spadebar.net/devUrl.action";        //dev CDN 
        //string cdnRouter = "http://www.spadebar.net/appUrl.action";            //staging CDN
        string cdnRouter = "http://www.spadebar.com/sgUrl.action";              //live CDN

        string shotCutName = "";                    //快捷方式 开始菜单名
        float fileRate = 0;                         //下载速度（带单位）
        float fileTemp = 0;                         //单位时间下载字节数
        long totalDownloadedByte = 0;               //已下载的字节数
        int count = 3;                              //线程“重启”的次数
        string userSavePath = "";                   //用户安装路径
        string tempPath = Path.GetTempPath();       //临时文件路径
        string logFile = Path.GetTempPath() + "spade.log";  //日志文件
        bool isClick = false;                       //开始按钮是否点击

        Language olanguage;                         //语言对象
        System.Threading.Timer FileTm = null;       //定时器
        Thread th = null;                           //线程对象.
        FileStream fs = null;                       //文件流
        Stream stream = null;                       //网络流

        public class barData
        {
            public int Value = 0;
            public int Maximum = 0;
        }
        barData picBarData = new barData();         //进度条

        public Form1(string lan)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            if (lan!="")
            {
                this.lan = lan;
                RestAllLanguage();
                setSelectLanIcon(lan);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            floderText.Text = "C:\\Program Files (x86)\\" + merchantName + "_" + release + "(" + lan + ")\\"; //默认32位安装路径
            InitUI(lan);

            //临时测试代码
            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }
        }

        // 获取最优网路
        public string HttpGet(string Url, string postDataStr)
        {
            string retString = "";
            string baseUrl = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?" + postDataStr));
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dynamic model = js.Deserialize<dynamic>(retString);
                baseUrl = model["resource"];
                socket = model["webSocket"];
                gameUrl = model["lobby"] + "/index.jsp";
                if (gameUrl != "")
                {
                    gameUrl = gameUrl.Replace(@"http://", "");
                }
                myStreamReader.Close();
                myResponseStream.Close();
                return baseUrl;
            }
            catch (Exception)
            {
                timeLeft.Visible = false;
                transferSpeed.Visible = false;
                percentData.Visible = false;
                percentSign.Visible = false;
                statusIntro.Visible = true;
                statusIntro.Text = olanguage.net_error2;
            }
            return baseUrl;
        }

        // 初始化UI
        private void InitUI(string language)
        {
            olanguage = (Language)Assembly.GetExecutingAssembly().CreateInstance("downLoader." + language);

            string tempLan = lan;
            lan = language;
            floderText.Text = floderText.Text.Replace(tempLan, lan);

            btnInstall.Text = olanguage.btnText;
            merchant.Text = merchantName.ToUpper().Replace("DEMO", "") + " Gaming";
            btnStartGame.Visible = false;
            pb_download_us.Visible = false;
            pb_download_cn.Visible = false;
            pb_install_us.Visible = false;
            pb_install_cn.Visible = false;
            statusIntro.Visible = false;
            percentData.Visible = false;
            percentSign.Visible = false;
        }

        // 切换UI
        private void ToggleUI()
        {
            cn_btn.Visible = false;
            en_btn.Visible = false;
            indenusia_btn.Visible = false;
            korean_btn.Visible = false;
            malaysia_btn.Visible = false;
            thailand_btn.Visible = false;
            vietnam_btn.Visible = false;
            backgroundPanel.Visible = false;
            floderText.Visible = false;
            btnFloderSelect.Visible = false;
            btnInstall.Visible = false;

            progressPanel.Visible = true;
            pictureBoxBar.Visible = true;
            percentData.Visible = true;
            percentSign.Visible = true;

            timeLeft.Text = olanguage.leftTime + "—";
            transferSpeed.Text = olanguage.transferSpeed + "—";

            switch (lan)
            {
                case "en_us":
                    pb_download_us.Visible = true;
                    break;
                case "zh_cn":
                    pb_download_cn.Visible = true;
                    break;
                default:
                    break;
            }
            Application.DoEvents();

        }

        // 开始下载
        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (isClick)
            {
                return;
            }
            isClick = !isClick;

            ToggleUI();
            baseUrl = HttpGet(cdnRouter, "");
            if (baseUrl == "")
            {
                return;
            }
            baseUrl += "/pc_version/20161101/";

            StartDownload(merchantName + "_" + "1_0_0.zip");
        }

        // 启动线程现在
        private void StartDownload(string strName)
        {
            th = new Thread(new ParameterizedThreadStart(DownloaderFunc));
            th.Start(strName);
        }

        // 重新下载
        private void RestartDownload(string strName)
        {
            if (FileTm != null)
            {
                FileTm.Dispose();
            }

            //3次重连，连不上提示网络问题
            if (count > 1)
            {
                new Thread(new ParameterizedThreadStart(DownloaderFunc)).Start(strName);
                count--;
            }
            else
            {
                statusIntro.Text = olanguage.net_error2;
            }
        }

        // 断点续传下载
        private void DownloaderFunc(object strName)
        {
            int bufferSize = 10240;
            double contentLength = 0;
            long currentFileLength = 0;
            string strFileName = tempPath + strName.ToString();
            string url = baseUrl + "package\\" + strName.ToString();
            FileMode fm = FileMode.Create;
            HttpWebRequest httpWebRequest;
            HttpWebResponse response;
            userSavePath = floderText.Text;
            statusIntro.Visible = false;
            transferSpeed.Visible = true;
            timeLeft.Visible = true;

            //打开网络
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                if (File.Exists(strFileName))
                {
                    FileInfo fn = new FileInfo(strFileName);
                    currentFileLength = fn.Length;
                    httpWebRequest.AddRange(fn.Length);
                    fm = FileMode.Append;
                }
                contentLength = GetContentLength(url);
                if (contentLength == currentFileLength)
                {
                    //new progressbar
                    picBarData.Maximum = (int)contentLength;
                    picBarData.Value = picBarData.Maximum;
                    pictureBoxBar.Width = 343;
                    percentData.Text = "100";

                    InstallProgram(strFileName);
                    return;
                }
                response = (HttpWebResponse)httpWebRequest.GetResponse();
                stream = response.GetResponseStream();
                fs = new FileStream(strFileName, fm);

                //new progressbar
                picBarData.Maximum = (int)contentLength;

                totalDownloadedByte = currentFileLength;
            }
            catch (Exception ex)
            {
                timeLeft.Visible = false;
                transferSpeed.Visible = false;
                statusIntro.Visible = true;
                statusIntro.Text = olanguage.net_error2;
                RestartDownload(strName.ToString());
                File.AppendAllText(logFile, ex.Message);
                return;
            }

            //下载流
            try
            {
                byte[] nbytes = new byte[bufferSize];
                int nReadSize = 0;
                FileTm = new System.Threading.Timer(SpeedTimer, null, 0, 1000);//使用回调函数，每1秒执行一次

                switch (lan)
                {
                    case "en_us":
                        pb_download_us.Visible = true;
                        break;
                    case "zh_cn":
                        pb_download_cn.Visible = true;
                        break;
                    default:
                        break;
                }

                nReadSize = stream.Read(nbytes, 0, bufferSize);
                while (nReadSize > 0 || totalDownloadedByte < contentLength)
                {
                    fileTemp += nReadSize;
                    totalDownloadedByte += nReadSize;

                    //修改当前进度和进度条宽度
                    picBarData.Value = (int)totalDownloadedByte;
                    pictureBoxBar.Width = (int)((double)(totalDownloadedByte) / (double)(picBarData.Maximum) * 343);
                    percentData.Text = ((int)((double)(totalDownloadedByte) / (double)(picBarData.Maximum) * 100)).ToString();
                    Application.DoEvents();

                    fs.Write(nbytes, 0, nReadSize);
                    nReadSize = stream.Read(nbytes, 0, bufferSize);
                    fs.Flush();

                    var log = Thread.CurrentThread.ManagedThreadId + "    totalByte:" + contentLength + "   " + "totalDownLoad:" + totalDownloadedByte + "     " + "nResize:" + nReadSize + "\r\n";
                    File.AppendAllText(logFile, log);
                }
                fs.Close();
                stream.Close();
                response.Close();
                InstallProgram(strFileName);
            }
            catch (Exception ex)
            {
                fs.Close();
                fs.Dispose();
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                    response.Close();
                }
                timeLeft.Visible = false;
                transferSpeed.Visible = false;
                statusIntro.Visible = true;
                statusIntro.Text = olanguage.net_error1;
                RestartDownload(strName.ToString());
                File.AppendAllText(logFile, ex.Message);
            }
        }

        //安装应用程序
        private void InstallProgram(string strFileName)
        {
            switch (lan)
            {
                case "en_us":
                    pb_download_us.Visible = false;
                    pb_install_us.Visible = true;
                    break;
                case "zh_cn":
                    pb_download_cn.Visible = false;
                    pb_install_cn.Visible = true;
                    break;
                default:
                    break;
            }

            timeLeft.Visible = false;
            transferSpeed.Visible = false;

            if (!Directory.Exists(userSavePath))
            {
                Directory.CreateDirectory(userSavePath);
            }
            
            //解压出错就删掉文件
            try
            {
                UnZip(strFileName, userSavePath, true);
            }
            catch (Exception)
            {
                File.Delete(strFileName);
                return;
            }
            WriteReg(userSavePath);
            ShotCut(userSavePath);
            CreateProgramsShortcut(userSavePath);
            CreateJsonFile(userSavePath);
            SucessInstall();
        }

        //获取文件流总长
        private long GetContentLength(string url)
        {
            long result = 0;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse res = (HttpWebResponse)httpWebRequest.GetResponse();

                if (res.Headers["Content-Length"] != null)
                {
                    string s = res.Headers["Content-Length"];
                    if (!long.TryParse(s, out result))
                    {
                        result = 0;
                    }
                }
                res.Close();
            }
            catch (Exception)
            {
                statusIntro.Text = olanguage.net_error2;
            }

            return result;
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
                    int seconds = Convert.ToInt32((picBarData.Maximum - totalDownloadedByte) / 1024 / fileRate);
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

        // 解压文件到指定目录
        public void UnZip(string zipedFile, string strDirectory, bool overWrite)
        {
            statusIntro.Visible = true;
            if (strDirectory == "")
                strDirectory = Directory.GetCurrentDirectory();
            if (!strDirectory.EndsWith("\\"))
                strDirectory = strDirectory + "\\";

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipedFile)))
            {
                ZipEntry theEntry;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = "";
                    string pathToZip = "";
                    pathToZip = theEntry.Name;

                    if (pathToZip != "")
                        directoryName = Path.GetDirectoryName(pathToZip) + "\\";

                    string fileName = Path.GetFileName(pathToZip);

                    Directory.CreateDirectory(strDirectory + directoryName);

                    if (fileName != "")
                    {
                        if ((File.Exists(strDirectory + directoryName + fileName) && overWrite) || (!File.Exists(strDirectory + directoryName + fileName)))
                        {
                            string name = strDirectory + directoryName + fileName;
                            name = name.Length > 65 ? name.Substring(0, 62) + "..." : name;
                            statusIntro.Text = (olanguage.install + name).Replace(@"\\", @"\");
                            using (FileStream streamWriter = File.Create(strDirectory + directoryName + fileName))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);

                                    if (size > 0)
                                        streamWriter.Write(data, 0, size);
                                    else
                                        break;
                                }
                                streamWriter.Close();
                            }
                        }
                    }
                }

                s.Close();
                s.Dispose();
                File.Delete(zipedFile);
            }
        }

        // 写注册表信息
        private void WriteReg(string installPath)
        {
            RegistryKey src = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
            RegistryKey read = src.CreateSubKey(merchantName + "_" + release + "_" + lan);

            read.SetValue("DisplayIcon", "\"" + installPath + "\\" + "mainProgram.exe" + "\"");
            read.SetValue("DisplayName", merchantName.ToUpper().Replace("DEMO", "") + " Gaming" + "(" + release + "_" + lan + ")");
            read.SetValue("DisplayVersion", "1.0.0");
            read.SetValue("Publisher", "SG Gaming,Inc");
            read.SetValue("UninstallString", "\"" + installPath + "uninstall.exe" + "\"");
            //记录安装路径，解决第三方软件调用卸载程序时，改变当前执行路径问题问题
            read.SetValue("UninstallPath", installPath);
        }

        // 写快捷方式
        private void ShotCut(string installPath)
        {

            //删除继续安装程序快捷方式
            string shotcutName = merchantName.ToUpper().Replace("DEMO", "") + " " + olanguage.continueSetup;
            string downloadlnkName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + shotcutName + ".lnk";
            if (File.Exists(downloadlnkName))
            {
                File.Delete(downloadlnkName);
            }

            //创建安装程序快捷方式
            shotCutName = lan == "en_us" ? shotCut_en : shotCut_cn;

            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + shotCutName + ".lnk");
            shortcut.TargetPath = installPath + "mainProgram.exe"; //目标文件
            shortcut.WorkingDirectory = installPath;  //起始位置
            shortcut.Save();
        }


        // 写开始菜单
        private void CreateProgramsShortcut(string installPath)
        {
            var startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + "\\" + shotCutName + "\\";
            if (!Directory.Exists(startupPath))
            {
                Directory.CreateDirectory(startupPath);
            }
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();

            IWshRuntimeLibrary.IWshShortcut shortcut1 = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(startupPath + shotCutName + ".lnk");
            shortcut1.TargetPath = installPath + "mainProgram.exe"; //目标文件
            shortcut1.WorkingDirectory = installPath;  //起始位置
            shortcut1.Save();

            IWshRuntimeLibrary.IWshShortcut shortcut2 = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(startupPath + "uninstall.lnk");
            shortcut2.TargetPath = installPath + "uninstall.exe"; //目标文件
            shortcut2.WorkingDirectory = installPath;  //起始位置
            shortcut2.Save();
        }

        // 写json文件
        private void CreateJsonFile(string installPath)
        {
            var str = "";
            str += "{";
            str += "\"name\":\"" + merchantName + " Gaming\",";
            str += "\"main\":\"main.js\",";
            str += "\"description\":\"" + merchantName + " Gaming\",";
            str += "\"author\":\"" + merchantName + " Gaming\",";
            str += "\"license\":\"ISC\",";
            str += "\"merchantCode\":\"" + merchantName + "\",";
            str += "\"language\":\"" + olanguage.getlanguage(lan) + "\",";
            str += "\"lan\":\"" + lan + "\",";
            str += "\"updateUrl\":\"" + baseUrl + "\",";
            str += "\"release\":\"" + release + "\",";
            str += "\"shotCut_cn\":\"" + shotCut_cn + "\",";
            str += "\"shotCut_en\":\"" + shotCut_en + "\",";
            str += "\"socket\":\"" + socket + "\",";
            str += "\"gameUrl\":\"" + gameUrl + "\"";
            str += "}";
            File.WriteAllText(installPath + "resources/app/package.json", str);
        }

        // 安装成功  
        private void SucessInstall()
        {
            pb_install_cn.Visible = false;
            pb_install_us.Visible = false;
            statusIntro.Visible = false;
            progressPanel.Visible = false;
            pictureBoxBar.Visible = false;
            percentData.Visible = false;
            percentSign.Visible = false;
            btnInstall.Visible = false;
            timeLeft.Visible = false;
            transferSpeed.Visible = false;
            btnStartGame.Visible = true;
            btnStartGame.Text = olanguage.startGame;
        }

        // 关闭程序
        private void closeBtn_Click(object sender, EventArgs e)
        {

            if (btnStartGame.Visible == false)
            {
                ComfirmForm comfirmForm = new ComfirmForm(lan, merchantName);
                comfirmForm.ShowDialog();
            }
            else
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
                if (FileTm != null) FileTm.Dispose();
                Process.GetCurrentProcess().Kill();
                this.Close();
                System.Environment.Exit(0);
            }
        }

        // 选择安装目录
        private void btnFloderSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();

            if (path.SelectedPath != "")
            {
                floderText.Text = path.SelectedPath + "\\" + merchantName + "_" + release + "(" + lan + ")\\";
            }
        }

        // 开始游戏
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            var execName = userSavePath + "mainProgram.exe";
            Process.Start(execName);
            this.Close();
            System.Environment.Exit(0);
        }

        // 英文
        private void en_btn_Click(object sender, EventArgs e)
        {
            RestAllLanguage();
            en_btn.BackgroundImage = downLoader.Properties.Resources.en;
            InitUI("en_us");
        }

        // 中文
        private void cn_btn_Click(object sender, EventArgs e)
        {
            RestAllLanguage();
            cn_btn.BackgroundImage = downLoader.Properties.Resources.cn;
            InitUI("zh_cn");
        }

        private void indenusia_btn_Click(object sender, EventArgs e)
        {
            RestAllLanguage();
            indenusia_btn.BackgroundImage = downLoader.Properties.Resources.Indonesia;

        }

        private void vietnam_btn_Click(object sender, EventArgs e)
        {
            RestAllLanguage();
            vietnam_btn.BackgroundImage = downLoader.Properties.Resources.Vietnam;
        }

        private void thailand_btn_Click(object sender, EventArgs e)
        {
            RestAllLanguage();
            thailand_btn.BackgroundImage = downLoader.Properties.Resources.Thailand;
        }

        private void malaysia_btn_Click(object sender, EventArgs e)
        {
            RestAllLanguage();
            malaysia_btn.BackgroundImage = downLoader.Properties.Resources.Malaysia;
        }

        private void korean_btn_Click(object sender, EventArgs e)
        {
            RestAllLanguage();
            korean_btn.BackgroundImage = downLoader.Properties.Resources.Korean;
        }

        // 重置所有按钮状态
        private void RestAllLanguage()
        {
            en_btn.BackgroundImage = downLoader.Properties.Resources.en_off;
            cn_btn.BackgroundImage = downLoader.Properties.Resources.cn_off;
            indenusia_btn.BackgroundImage = downLoader.Properties.Resources.Indonesia_off;
            vietnam_btn.BackgroundImage = downLoader.Properties.Resources.Vietnam_off;
            thailand_btn.BackgroundImage = downLoader.Properties.Resources.Thailand_off;
            malaysia_btn.BackgroundImage = downLoader.Properties.Resources.Malaysia_off;
            korean_btn.BackgroundImage = downLoader.Properties.Resources.Korean_off;
        }

        // 设置快捷方式传过来的默认语言
        private void setSelectLanIcon(string lan) 
        {
            switch (lan)
            {
                case "en_us":
                    en_btn.BackgroundImage = downLoader.Properties.Resources.en;
                    break;
                case "zh_cn":
                    cn_btn.BackgroundImage = downLoader.Properties.Resources.cn;
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
