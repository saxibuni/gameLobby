const app = require('app'), // 控制应用生命周期的模块
    BrowserWindow = require('browser-window'), // 创建原生浏览器窗口的模块
    ipcMain = require('electron').ipcMain, //通信模块
    dialog = require('electron').dialog, //对话框模块
    fs = require('fs'); //处理json的相关模块

var indexWindow = null, //主页面窗体
    iCashierWindow = null, //充值页面窗体
    gameWinArr = []; //打开的游戏窗体对象数组

var lanDicMap = {
    english: "en_US",
    chinese: "zh_CN"
}

//messageBox参数
var dialogOption = {
    type: "none",
    title: "SG Gaming",
    buttons: ["OK", "Cancel"],
    defaultId: 0,
    message: 'Confirm Exit Games?',
    cancelId: 1
};

//全局变量
global.sharedObject = {
    username: "guest",
    balance: 0,
    currency: "MYR",
    iCashierUrl: "",
    lan: "",
    lan2: "",
    token: "",
    sid: "",
    changePassword: "",
    merchantCode: "",
    merchantKey: "",
    socket: "",
    gameUrl: "",
    release: ""
};

//加载flash插件
app.commandLine.appendSwitch('ppapi-flash-path', __dirname + '/plugins/pepflashplayer.dll');

app.on('window-all-closed', () => {
    // 在 OS X 上，通常用户在明确地按下 Cmd + Q 之前
    // 应用会保持活动状态
    if (process.platform != 'darwin') {
        app.quit();
    }
});

// 当 Electron 完成了初始化并且准备创建浏览器窗口的时候 这个方法就被调用
app.on('ready', () => {
    //启动程序
    init();

    //打开登录窗体
    ipcMain.on('login-window-open', (event, data) => {
        openIndexWin();
        switch (global.sharedObject.lan) {
            case "english":
                dialogOption.message = "Confirm Exit Games?";
                break;
            case "chinese":
                dialogOption.message = "确认退出游戏？";
                break;
            default:
                dialogOption.message = "Confirm Exit Games?";
        }
    });

    //打开大厅
    ipcMain.on('index-window-open', (event, data) => {
        switch (global.sharedObject.lan) {
            case "english":
                dialogOption.message = "Confirm Exit Games?";
                break;
            case "chinese":
                dialogOption.message = "确认退出游戏？";
                break;
            default:
                dialogOption.message = "Confirm Exit Games?";
        }
    });

    //打开游戏窗体
    ipcMain.on('game-window-open', (event, data) => {
        openGameWin(data);
    });

    //打开充值窗体
    ipcMain.on('icrash-window-open', (event, url) => {
        openICashierWin(url);
    });

    //退出游戏
    ipcMain.on('app-quit', (event, arg) => {
        dialog.showMessageBox(dialogOption, (buttionId) => {
            quitApp(buttionId);
        });
    });

    //主界面全屏切换
    ipcMain.on('fullscreen-index', (event, flag) => {
        indexWindow.setFullScreen(flag);
    });

    //游戏界面全屏切换
    ipcMain.on('fullscreen-game', (event, flag, code) => {
        getGameWinByCode(code).setFullScreen(flag);
    });

});

//获取配置信息  启动应用程序
var init = () => {
    fs.readFile(__dirname + '/package.json', (err, data) => {
        var jsonObj = JSON.parse(data);
        global.sharedObject.merchantCode = jsonObj.merchantCode;
        global.sharedObject.lan = jsonObj.language;
        global.sharedObject.lan2 = jsonObj.lan;
        global.sharedObject.socket = jsonObj.socket;
        global.sharedObject.gameUrl = jsonObj.gameUrl;
        global.sharedObject.release = jsonObj.release;
        dialogOption.title = jsonObj.merchantCode.toUpperCase().replace('DEMO', '') + " Gaming";

        openIndexWin();
    });
}

//打开主界面窗体
var openIndexWin = () => {
    var resizable = process.platform == 'darwin' ? true : false;
    indexWindow = new BrowserWindow({
        width: 1250,
        height: 840,
        resizable: resizable,
        title: "SG Gaming"
    });

    indexWindow.loadURL(__dirname + "/www/login.html");

    indexWindow.on('close', (e) => {
        e.preventDefault();
        dialog.showMessageBox(dialogOption, (buttionId) => {
            /* debug
            var msg = JSON.stringify(e);
            indexWindow.webContents.send('send-console',msg);
            */
            quitApp(buttionId);
        });
    });

    //失去焦点时 关闭声音
    indexWindow.on('blur', () => {
        indexWindow.webContents.send('sound-on-off', 'off');
    });

    //获取焦点时 打开声音
    indexWindow.on('focus', () => {
        indexWindow.webContents.send('sound-on-off', 'on');
    });

    //进入全屏
    indexWindow.on('enter-full-screen', () => {
        indexWindow.webContents.send('toggleIcon', 'fullScreen', 'normalScreen');
    });

    //退出全屏
    indexWindow.on('leave-full-screen', () => {
        indexWindow.webContents.send('toggleIcon', 'normalScreen', 'fullScreen');
    });
}

//打开充值窗体
var openICashierWin = (url) => {
    if (iCashierWindow) {
        iCashierWindow.show();
        iCashierWindow.focus();
        return;
    }
    iCashierWindow = new BrowserWindow({
        width: 1000,
        height: 800,
        title: "SG Gaming"
    });

    iCashierWindow.loadURL(url);

    iCashierWindow.on('closed', () => {
        iCashierWindow = null;
    });
}

//打开游戏窗口
var openGameWin = (data) => {
    var resizable = process.platform == 'darwin' ? true : false;
    var arr = data.split('|');
    var code = arr[0],
        type = arr[1];
    var sid = global.sharedObject.sid,
        token = global.sharedObject.token;
    var lan = lanDicMap[global.sharedObject.lan];

    var gameUrl = global.sharedObject.gameUrl + "?game=" + code + "&sid=" + sid + "&token=" + token + "&language=" + lan + '&channel=pc&type=web';
    // type == "web" && (gameUrl = gameUrl + "&type=web");

    var gameWin = getGameWinByCode(code);
    if (gameWin) {
        gameWin.show();
        gameWin.focus();
        return;
    }

    gameWin = new BrowserWindow({
        width: 1058,
        height: 625,
        resizable: resizable,
        webPreferences: {
            'plugins': true
        }
    });

    gameWin.code = code;
    gameWin.loadURL(__dirname + "/www/game.html?gameUrl=" + gameUrl);
    gameWinArr.push(gameWin);

    gameWin.on('close', (e) => {
        e.preventDefault();
        dialog.showMessageBox(dialogOption, (buttionId) => {
            if (buttionId == 0) {
                gameWin.destroy();
                removeGameWinFromArr(gameWin.code);
            }
        });
    });

    gameWin.on('closed', (e) => {
        removeGameWinFromArr(gameWin.code);
    });

}

//删除关闭的游戏窗口对象
var removeGameWinFromArr = (code) => {
    gameWinArr = gameWinArr.filter((item, index, array) => {
        return item.code != code;
    });
}

//获取要打开的游戏是否已存在游戏窗口对象
var getGameWinByCode = (code) => {
    var win = gameWinArr.filter((item, index, array) => {
        return item.code == code;
    })[0];
    return win;
}

//退出app
var quitApp = (buttionId) => {
    //destroy方法强制退出 不会触发close事件
    if (buttionId == 0) {
        if (indexWindow) indexWindow.destroy();
        if (iCashierWindow) iCashierWindow.destroy();
        if (gameWinArr.length > 0) {
            gameWinArr.forEach((win, index) => {
                win.destroy();
            });
        }
        app.quit();
    }

}
