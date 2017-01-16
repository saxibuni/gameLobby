using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainProgram
{

    public class zh_cn : Language
    {
        public zh_cn()
        {
            net_error1 = "当前网路不佳，正在尝试重连";
            net_error2 = "当前网络状况不佳，下载失败";
            leftTime = "剩余时间：";
            transferSpeed = "传输速度：";
            hour = "小时";    
            minute = "分";
            second = "秒";
        }
    }

    public class en_us : Language
    {
        public en_us()
        {
            net_error1 = "Network Failure, trying reconnect now.";
            net_error2 = "Network Failure, download failed.";
            leftTime = "Time remain : ";
            transferSpeed = "Transfer rate : ";
            hour = "h ";
            minute = "min ";
            second = "s";
        }
    }

    public class Language
    {
        public string net_error1;
        public string net_error2;
        public string leftTime;
        public string transferSpeed;
        public string hour;
        public string minute;
        public string second;
    }
}
