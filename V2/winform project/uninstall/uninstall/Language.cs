using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uninstall
{

    public class zh_cn : Language
    {
        public zh_cn()
        {
            btnStartGame = "继 续 游 戏";
            btnRemove = "卸 载 游 戏";
            confirmTxt = "是 否 卸 载 {0} Gaming？";
            removeFile = "正在删除：";
            completeDelete = "卸 载 完 成";
            btnComplete = "卸 载 完 成";
            isUsed = "程序被占用，请关闭后重试";
        }
    }

    public class en_us : Language
    {
        public en_us()
        {
            btnStartGame = "Continue";
            btnRemove = "Uninstall";
            confirmTxt = "Whether to uninstall {0} Gaming？";
            removeFile = "Remove files：";
            completeDelete = "Uninstall is completed";
            btnComplete = "Completed";
            isUsed = "Program is occupied, please close and try again";
        }
    }

    public class Language
    {
        public string btnStartGame;
        public string btnRemove;
        public string confirmTxt;
        public string removeFile;
        public string completeDelete;
        public string btnComplete;
        public string isUsed;
    }
}
