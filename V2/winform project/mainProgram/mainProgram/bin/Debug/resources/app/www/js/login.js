$(function() {
    //通信模块
    const remote = nodeRequire('remote');
    const ipcRenderer = nodeRequire('electron').ipcRenderer;

    var txtUser = $("#userName"),
        txtPwd = $("#passWord");

    //全局变量
    var globalObj = remote.getGlobal('sharedObject');

    $("#login").on('click', function(event) {
        //当前选中的语言   
        lan = $(".languageSelect").val();
        globalObj.lan = lan;
        login();
    });

    var login = function() {
        if (!isOnline()) return; //网络状态不可用 取消请求
        var publicKey = "";
        var mCode = globalObj.merchantCode,
            mKey = globalObj.merchantKey || "",
            channel = "pc";
        setMaxDigits(262);
        if (mKey) publicKey = new RSAKeyPair("10001", '', mKey); ////第一个参数为加密指数、第二个参数为解密参数、第三个参数为加密系数

        var username = txtUser.val(),
            password = txtPwd.val();
        if (username == "" || password == "") {
            alert(locale.getString('MSG_USENAME_PSW_INVALID'));
            return;
        };
        var req = {};
        req.acctId = username;
        req.passwd = mKey ? encryptedString(publicKey, password) : password; // 使用mkey加密 DES加密
        req.merchantCode = mCode;
        req.channel = channel;

        $("#mask").show(); //请求开始 显示遮罩
        service.login(req, function(res) {
            if (res.code == 0) { //登录成功
                ($("#remember")[0].checked == true) ? mm.Storage.setItem("user", { acctId: req.acctId, passwd: password }): mm.Storage.setItem("user", { acctId: req.acctId, passwd: "" });

                globalObj.username = username;
                globalObj.balance = res.acct.balance;
                globalObj.currency = res.acct.currency;
                globalObj.iCashierUrl = res.iCashierUrl;
                globalObj.sid = localStorage.getItem('sid');
                globalObj.token = localStorage.getItem('token');
                globalObj.changePassword = res.changePassword;

                //通知主进程  创建新窗口
                ipcRenderer.send('index-window-open');
                window.location.href = "index.html";

            } else {
                alert(locale.getString("RES_" + res.code));
            }
            $("#mask").hide();

        });
    }

    var getUserInfo = function() {
        user = mm.Storage.getItem('user', true);
        if (user != null) {
            txtUser.val(user.acctId);
            txtPwd.val(user.passwd);
            if (user.passwd) $("#remember")[0].checked = true;
        }
    }


    var getMerchantKey = function() {
        $.ajax({
            url: "config.xml",
            dataType: "xml",
            success: function(xml) {
                $(xml).find("root > mechantMap > merchantObj").each(function() {
                    var merchantCode = $(this).find('merchantCode').text();
                    var merchantKey = $(this).find('merchantKey').text();

                    if (merchantCode == globalObj.merchantCode)
                        globalObj.merchantKey = merchantKey;
                });
            },
            cache: false
        });
    }

    //断网检测
    var isOnline = function() {
        if (!navigator.onLine) alert(locale.getString('MSG_ONLINE'));
        return navigator.onLine;
    }

    //在界面显示版本号
    var setVersionOnUI = function() {
        var titleName = globalObj.merchantCode.toUpperCase().replace('DEMO', '') + " Gaming";
        $('title').html(titleName);

        var Registry = nodeRequire('winreg');
        var regKey = new Registry({
            hive: Registry.HKLM, 
            key: "\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + globalObj.merchantCode + "_" + globalObj.release + "_" + globalObj.lan2
        });

        regKey.values(function(err, items) {
            for(var i = 0 ; i < items.length; i++){
                if (items[i].name == 'DisplayVersion') {
                    $("#version").text(items[i].value);
                }
            }
        });

    }

    //获取当前语言
    var getLanguage = function(lan) {
        $("#" + lan)[0].selected = true;
        $.ajaxSettings.async = false;
        locale.setLocale(lan, function() {
            txtUser.attr('placeholder', locale.getString('USERNAME'));
            txtPwd.attr('placeholder', locale.getString('PASSWORD'));
        });
        $.ajaxSettings.async = true;
    }

    getLanguage(globalObj.lan);
    getUserInfo();
    getMerchantKey();
    setVersionOnUI();

});
