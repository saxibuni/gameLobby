using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace downLoader
{

    public class zh_cn : Language
    {

        public zh_cn()
        {
            btnText = "开始安装";
            download = "正在下载";
            install = "正在安装";
            net_error1 = "当前网路不佳，正在尝试重连";
            net_error2 = "当前网络状况不佳，下载失败";
            leftTime = "剩余时间：";
            transferSpeed = "传输速度：";
            hour = "小时";
            minute = "分";
            second = "秒";

            chinese = "中文";
            english = "English";
            browse = "浏览";
            installPath = "安装路径";
            selectLanguage = "首选语言";
            startGame = "启动游戏";
            sucessInfo = "准备玩 {0} GAMING";

            comfirmExit = "确定退出安装？";
            comfirm = "确 定";
            cancel = "取 消";

            continueSetup = "继续安装程序";
        }
    }

    public class en_us : Language
    {

        public en_us()
        {
            btnText = "Install Now";
            download = "Downloading";
            install = "Installing ";
            net_error1 = "Network Failure, trying reconnect now.";
            net_error2 = "Network Failure, download failed.";
            leftTime = "Time remain : ";
            transferSpeed = "Transfer rate : ";
            hour = "h ";
            minute = "min ";
            second = "s";

            chinese = "中文";
            english = "English";
            browse = ". . .";
            installPath = "Install Path : ";
            selectLanguage = "Select Language : ";
            startGame = "Start Game";
            sucessInfo = "Ready to play {0} Gaming";

            comfirmExit = "Confirm exit the installation ?";
            comfirm = "comfirm";
            cancel = "cancel";

            continueSetup = "continue setup";
        }

    }

    public class Language
    {
        public string btnText;
        public string download;
        public string install;
        public string net_error1;
        public string net_error2;
        public string leftTime;
        public string transferSpeed;
        public string hour;
        public string minute;
        public string second;

        public string chinese;
        public string english;
        public string browse;
        public string installPath;
        public string selectLanguage;
        public string startGame;
        public string sucessInfo;

        public string comfirmExit;
        public string comfirm;
        public string cancel;

        public string continueSetup;

        public string getlanguage(string lan)
        {
            switch (lan)
            {
                case "en_us":
                    return "english";
                case "zh_cn":
                    return "chinese";
                default:
                    return "chinese";
            }
        }

    }
}
