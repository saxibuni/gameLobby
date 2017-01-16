$(function() {
    const ipcRenderer = nodeRequire('electron').ipcRenderer;
    const remote = nodeRequire('remote');
    var elementTimeIneterIdArr = [];
    //全局变量
    var globalObj = remote.getGlobal('sharedObject');
    var indexWin = remote.getCurrentWindow();

    //断网检测
    var lineTimer = setInterval(function(){
        if(!navigator.onLine){
            clearInterval(lineTimer);
            alert(locale.getString('MSG_ONLINE'));
            window.location.href = "login.html";
        }
    },1000);

    //获取当前语言
    var getLanguage = function(lan) {
        $.ajaxSettings.async = false;
        locale.setLocale(lan, function() {
            $("#pwd_current").attr('placeholder', locale.getString('CURRPWD'));
            $("#pwd_new").attr('placeholder', locale.getString('NEWPWD'));
            $("#pwd_confirm").attr('placeholder', locale.getString('CONFIRMPWD'));
        });
        $.ajaxSettings.async = true;
    }

    getLanguage(globalObj.lan);
    var Timer = {
        getCurrentTime: function(datetime) {
            var year = datetime.getFullYear();
            var month = datetime.getMonth() + 1;
            var date = datetime.getDate();
            var hour = datetime.getHours();
            var minutes = datetime.getMinutes();
            var seconds = datetime.getSeconds();

            if (month < 10) month = "0" + month;
            if (date < 10) date = "0" + date;
            if (hour < 10) hour = "0" + hour;
            if (minutes < 10) minutes = "0" + minutes;
            if (seconds < 10) seconds = "0" + seconds;

            return year + "-" + month + "-" + date + " " + hour + ":" + minutes + ":" + seconds;
        },
        startClock: function() {
            var that = this;
            setInterval(function() {
                var datetime = new Date();
                var dtStr = that.getCurrentTime(datetime);
                $("#currentTime").html(dtStr);
            }, 300);
        }
    }

    Timer.startClock();

    var Animation = {
        options: {
            isCollapse: false, //滚动数据是否展开
            startTimeoutId: null, //启动延时
            intervalId: null, //动画缓动
            timeoutId: null, //一次滚动后停顿时间
            height: null
        },
        data: [],
        createliElement: function() {
            var html = "",
                color = "rgb(98,98,98)";
            for (var i = 0; i < this.data.length; i++) {
                if (this.data[i].name == "Progressive Jackpot" || this.data[i].name == "华丽积宝")
                    html += "<li><span>" + this.data[i].name + "&nbsp;&nbsp;</span><span style='color:red;' >" + this.data[i].value + "</span></li>";
                else
                    html += "<li><span style='color:" + color + "'>" + this.data[i].name + "&nbsp;&nbsp;</span><span style='color:red;' >" + this.data[i].value + "</span></li>";
            }
            $(".rollItemDiv > ul").html(html);
        },
        startAnimation: function(target, isreload) {
            if (this.data.length == 0 || this.data.length == 1) {
                $(".rollItemDiv").css('height', '40px');
                return;
            }
            $(".rollItemDiv").css({ 'height': '40px', 'overflow': 'hidden' });
            $('.rollItemDiv > ul:last').show();

            if (isreload) this.createliElement(this.data);
            $(target).find("img").attr('src', 'css/images/down.png');
            this.options.isCollapse = true;

            this.options.height = 0;
            this.options.startTimeoutId = setTimeout(function() {
                Animation.launch();
            }, 2000);
        },
        pauseAnimation: function(target) {
            //remove animate
            clearInterval(Animation.options.intervalId);
            clearTimeout(Animation.options.timeoutId);
            clearTimeout(Animation.options.startTimeoutId);

            //hide helpElement
            $('.rollItemDiv > ul:last').hide();

            //得先停掉动画 然后再定位比较准确
            $(".rollItemDiv").css('height', (Math.round(this.data.length / 2) || 1) * 40 + "px");
            $(".rollItemDiv > ul:first").css('marginTop', '0');
            $(target).find("img").attr('src', 'css/images/up.png');
            this.options.isCollapse = false;
        },
        returnStartPosion: function() {
            var ul = $('.rollItemDiv > ul:first');
            var marginTop = ul.css('marginTop').replace("px", '');
            var height = ul.height();
            if (height == Math.abs(marginTop)) {
                this.options.height = 0;
            } else {
                this.options.height -= 1;
            };
        },
        launch: function() {
            var that = this;
            this.options.intervalId = setInterval(function() {
                var marginTop = Math.abs(that.options.height);

                if (marginTop % 40 == 0 && marginTop != 0) {
                    clearInterval(that.options.intervalId);

                    that.options.timeoutId = setTimeout(function() {
                        //是否返回原处
                        that.returnStartPosion();
                        that.launch();
                    }, 2000);

                } else {
                    that.options.height = that.options.height - 1;
                    $('.rollItemDiv > ul:first').css('marginTop', that.options.height + "px");
                }

            }, 10);

        },
        reloadHTML: function() { // refresh jackpot
            if (this.options.isCollapse) { //收缩状态时更新
                var target = $("#expand");
                this.pauseAnimation(target);
                $(".rollItemDiv").css({ 'height': '40px', 'overflow': 'hidden' });
                this.startAnimation(target, true);
            } else { //展开状态时更新
                this.createliElement(this.data);
            }
        }
    }

    //webAudio操作集合
    var WebAudioObject = {
        context: new AudioContext(),
        source: null,
        audioBuffer: null,
        isPlay: true,

        loadMusic: function() {
            var that = this;
            var url = "sound/bg.mp3";
            var xhr = new XMLHttpRequest(); //通过XHR下载音频文件
            xhr.open('GET', url, true);
            xhr.responseType = 'arraybuffer';

            xhr.onload = function(e) { //下载完成
                that.context.decodeAudioData(this.response, function(buffer) { //解码成功时的回调函数
                    that.audioBuffer = buffer;
                    that.playMusic();
                }, function(e) { //解码出错时的回调函数
                    console.log('Error decoding file', e);
                });
            };
            xhr.send();
        },
        playMusic: function() {
            this.source = this.context.createBufferSource();
            this.source.buffer = this.audioBuffer;
            this.source.loop = true;
            this.source.connect(this.context.destination);
            this.source.start(0); //播放 
        },
        pauseMusic: function() {
            this.source.stop(0); //停止 
        }
    }

    //充值
    $(".recharge,.moneyInfo").on('click', function(argument) {
        var url = globalObj.iCashierUrl;
        ipcRenderer.send('icrash-window-open', url);
    });

    //打开或关闭背景音乐
    $('#soundToggle').on('click', function(event) {
        var obj = WebAudioObject;
        obj.isPlay ? obj.pauseMusic() : obj.playMusic();
        obj.isPlay = !obj.isPlay;
        $(this).toggleClass('btn_on btn_off');
    });
    //修改密码显示判断
    if (globalObj.changePassword == true) {
        $("#isChangePwd").css("display", "block");
    } else {
        $("#isChangePwd").css("display", "none");
    }
    //充值显示判断
    if (globalObj.iCashierUrl != "") {
        $(".moneyInfo").css("display", "block");
    }
    //退出登录
    $("#logout").on('click', function() {
        if (confirm(locale.getString('CONFIRM_LOGOUT'))) {
            indexWin.isFullScreen() && $("#fullscreenToggle").trigger('click');
            window.location.href = "login.html";
        }
    });
    //操作列表
    $("#oper_pick").on('click', function() {
        openCover("setOperCover");
    });
    $(".optionClose").on('click', function() {
        closeCover("setOperCover");
    });
    var openCover = function(className) {
        $("." + className).css({
            display: "block",
            zIndex: "999"
        });
    }
    var closeCover = function(className) {
        $("." + className).css({
            display: "none",
            zIndex: "0"
        });
    }

    //打开修改密码窗口
    $('.btn_chang').on('click', function(event) {
        openCover("changePwdCover"); //打开修改密码
        closeCover("setOperCover"); //关闭设置
    });

    //修改密码取消
    $("#changepwd_btnDiv .btnCancel").on("click", function() {
        closeCover("changePwdCover");
        $(".changePwdForm")[0].reset();
    });
    //修改密码
    $("#changepwd_btnDiv .btnOk").on("click", function() {

        var pwd_current = $("#pwd_current").val();
        var pwd_new = $("#pwd_new").val();
        var pwd_confirm = $("#pwd_confirm").val();
        var req = {};

        if (pwd_current.length < 3 || pwd_new.length < 3 || pwd_confirm.length < 3) {
            alert(locale.getString('NOEMPTY'));
            $(".changePwdForm")[0].reset();
        } else if (pwd_new != pwd_confirm) {
            alert(locale.getString('NOTEQUAL'));
            $(".changePwdForm")[0].reset();
        } else {
            var mKey = globalObj.merchantKey;
            setMaxDigits(262);
            var publicKey = new RSAKeyPair("10001", '', mKey); ////第一个参数为加密指数、第二个参数为解密参数、第三个参数为加密系数
            req.oldPasswd = encryptedString(publicKey, pwd_current)
            req.newPasswd = encryptedString(publicKey, pwd_new);
            req.acctId = globalObj.username;
            req.merchantCode = globalObj.merchantCode;
            service.ChangePasswordRequest(req, function(res) {
                if (res.code == 0) {
                    alert(locale.getString('CHANGESUCCESS'));
                    $(".changePwdForm")[0].reset();
                    closeCover("changePwdCover");
                    mm.Storage.setItem("user", { acctId: req.acctId, passwd: "" });
                } else if (res.code == 10104) {
                    alert(locale.getString('OLDWRONG'));
                    $(".changePwdForm")[0].reset();
                }
            });
        }
    });
    /* "NOEMPTY":"表单不允许有空项",
         "NOTEQUAL":"两次密码不一致",
         "CHANGESUCCESS":"密码修改成功"*/

    //查询游戏
    $("#gameName").on('input', function(event) {
        var type = $('.currentSelect').attr('key');
        var key = $("#gameName").val();
        var curentGameArr = gameInfo[type] || [];
        var result = [];
        if (!key || $.trim(key) == "") result = curentGameArr;
        else result = curentGameArr.filter(function(item, index, array) {
            return locale.getString(item.code).toUpperCase().indexOf(key.toUpperCase()) > -1;
        });
        createGameLayout(result, type);
    });

    //展开搜索jackpot
    $("#expand").on('click', function(event) {
        Animation.options.isCollapse ? Animation.pauseAnimation(this) : Animation.startAnimation(this, false);
    });

    //打开新游戏
    $(".gameContainer").on('click', '.gamePic', function(event) {
        var code = $(this).attr('data-code');
        var type = gameInfo.ALL.filter(function(item, index, array) {
            return item.code == code;
        })[0].gameType || "flash";
        ipcRenderer.send('game-window-open', code + "|" + type);
    });

    //收藏游戏
    $(".gameContainer").on('click', '.favorites', function(event) {
        var $this = $(this);
        var key = $this.attr('id');
        var imgIcon = $this.find('img').attr('src');
        var currentGameType = $(".currentSelect").attr('key');

        if (imgIcon == "css/images/bttn_fav_on.png") { //取消收藏
            $this.find('img').attr('src', 'css/images/bttn_fav_off.png');
            localStorage.removeItem(key);
            if (currentGameType == "FAVORITE") $this.parent().parent().remove();
        } else { //收藏
            $this.find('img').attr('src', 'css/images/bttn_fav_on.png');
            var value = $this.closest('li').html();
            localStorage.setItem(key, value);
        }
    });

    //导航菜单切换
    $("#nav").on('click', 'a', function(e) {
        var key = $(this).attr('key');
        var currentGame = null;
        var name = $("#gameName").val();
        if (key != "FAVORITE") {
            currentGame = gameInfo[key];
            currentGame = currentGame.filter(function(item, index, array) {
                return locale.getString(item.code).toUpperCase().indexOf(name.toUpperCase()) > -1;
            });
            createGameLayout(currentGame, key);
        } else {
            createGameLayout([], key);
        }
    });

    //全屏切换
    $("#fullscreenToggle").on('click', function() {
        var flag = !indexWin.isFullScreen();
        ipcRenderer.send('fullscreen-index', flag);
    });

    ipcRenderer.on('toggleIcon', function(event, class1, class2) {
        $("#fullscreenToggle").addClass(class1).removeClass(class2);
    });

    //esc退出全屏
    window.addEventListener('keyup', function(e) {
        var flag = indexWin.isFullScreen();
        if (e.keyCode === 27 && flag) {
            $("#fullscreenToggle").trigger('click');
        }
    });

    //关闭窗体  退出游戏
    $("#closeWin").on('click', function() {
        ipcRenderer.send('app-quit');
    });

    //在界面显示版本号
    var setVersionOnUI = function() {
        var Registry = nodeRequire('winreg');
        var regKey = new Registry({
            hive: Registry.HKLM,
            key: "\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + globalObj.merchantCode + "_" + globalObj.release + "_" + globalObj.lan2
        });

        regKey.values(function(err, items) {
            for (var i = 0; i < items.length; i++) {
                if (items[i].name == 'DisplayVersion') {
                    $("#version").text(items[i].value);
                }
            }
        });
    }

    //获取当前语言
    var getLanguage = function(lan) {
        $.ajaxSettings.async = false;
        locale.setLocale(lan);
        $("#gameName").attr('placeholder', locale.getString('RISING'));
        $.ajaxSettings.async = true;

        var titleName = globalObj.merchantCode.toUpperCase().replace('DEMO', '') + " Gaming";
        $('title').html(titleName);
    }

    //登录信息
    var setLoginInfo = function() {
        var username = globalObj.username;
        var balance = globalObj.balance;
        var currency = globalObj.currency;

        $("#memberName").text(username);
        $("#balance").text(currency + mm.addDotToNumber(balance));
        if($(".loadMess").text().length>0)$(".loadMess").css("border","1px solid #e4e4e4");
    }

    var gameInfo = {
        "NEW": [],
        "FEATURED": [],
        "PROGRESSIVE": [],
        "ALL": [],
        "SLOT": [],
        "TABLE": [],
        "ARCADE": [],
        "TOP": []
    }

    //获取游戏信息
    var getGameInfo = function() {
        var req = {};
        req.merchantCode = globalObj.merchantCode;
        req.currency = globalObj.currency;
        req.channel = 'pc';
        service.gameinfo(req, function(res) {
            if (res.code == 0) {
                $.each(res.merchantGames, function(index, row) {
                    var catagoryArr = row.tags || [];
                    if ($.inArray('NEW', catagoryArr) > -1) gameInfo.NEW.push({ code: row.gameCode });
                    if ($.inArray('SM', catagoryArr) > -1) gameInfo.SLOT.push({ code: row.gameCode });
                    if ($.inArray('TB', catagoryArr) > -1) gameInfo.TABLE.push({ code: row.gameCode });
                    if ($.inArray('AD', catagoryArr) > -1) gameInfo.ARCADE.push({ code: row.gameCode });
                    if ($.inArray('TOP', catagoryArr) > -1) gameInfo.TOP.push({ code: row.gameCode });
                    if ($.inArray('PROG', catagoryArr) > -1) gameInfo.PROGRESSIVE.push({ code: row.gameCode });
                    if ($.inArray('FEAT', catagoryArr) > -1) gameInfo.FEATURED.push({ code: row.gameCode });
                    gameInfo.ALL.push({ code: row.gameCode });
                });
                createGameLayout(gameInfo.NEW, "NEW");
                $(".loadCover").remove();

            } else {
                alert(locale.getString("RES_" + res.code));
            }
        });
    }

    //创建游戏dom结构
    var createGameLayout = function(data, type) {
        clearTimeoutId(); //清除加载dom的定时器 避免菜单切换时 上一菜单的dom数据还未加载完成
        var container = $(".gameContainer > ul").html("");
        var defaultImgUrl = "css/images/game/error.jpg";
        $.each(data, function(index, row) {

            var container = $(".gameContainer > ul").html("");
            var defaultImgUrl = "css/images/game/error.jpg";
            var id = setTimeout(function() {
                var html = "",
                    imgIcon = "";
                var imgUrl = "css/images/game/" + globalObj.lan + "/" + row.code + ".jpg";
                localStorage.getItem(row.code) ? imgIcon = "css/images/bttn_fav_on.png" : imgIcon = "css/images/bttn_fav_off.png";
                html += "<div>";
                html += "<img src='" + imgUrl + "' data-code='" + row.code + "' class='gamePic' onerror=\"this.src='" + defaultImgUrl + "'\" >";
                html += "<a class='favorites' id='" + row.code + "'>";
                html += "<img src='" + imgIcon + "'>";
                html += "</a>";
                html += "<div title='" + locale.getString(row.code) + "'>" + locale.getString(row.code) + "</div>";
                html += "</div>";
                $("<li />").html(html).appendTo(container);
            }, 20 * index);
            elementTimeIneterIdArr.push(id); //数组管理定时器
        });

        if (type == "FAVORITE") {
            var favoriteArr = [],
                html = "",
                searchName = $("#gameName").val();
            for (var i = 0; i < localStorage.length; i++) {
                html = localStorage.getItem(localStorage.key(i));
                if (html.indexOf("<div>") > -1) { //简单验证 确保缓存对象是dom结构
                    var gameName = html.substring(html.lastIndexOf('">') + 2, html.lastIndexOf('</div></div>'));
                    var currentGameName = locale.getString(localStorage.key(i));
                    html = html.replace(new RegExp(gameName, "gm"), currentGameName);
                    currentGameName.toUpperCase().indexOf(searchName.toUpperCase()) > -1 && favoriteArr.push(html);
                }
            }
            favoriteArr.forEach(function(item, index, array) {
                var id = setTimeout(function() {
                    $("<li />").html(item).appendTo(container);
                }, 20 * index);
                elementTimeIneterIdArr.push(id); //数组管理定时器            
            });
        }

        $(".currentSelect").text(locale.getString(type)).attr('key', type);
        $("#nav > li > a").css('color', 'white');
        $("a[key=" + type + "]").css('color', 'red');
    }

    var clearTimeoutId = function() {
        elementTimeIneterIdArr.forEach(function(item, index, arrar) {
            clearTimeout(item);
        });
    }

    //获取jackPot信息
    var getjackPot = function(isfirst) {
        var config = mm.config;
        var req = {};
        req.merchantCode = globalObj.merchantCode;
        req.currency = globalObj.currency;

        service.jackpot(req, function(res) {
            if (res.code == 0) {
                var jackpotArr = res.list;
                Animation.data.length = 0; //清空数据
                $.each(jackpotArr, function(index, row) {
                    Animation.data.push({
                        name: locale.getString(row.code),
                        value: row.currency + "&nbsp;" + mm.addDotToNumber(row.amount)
                    });
                });
                if (isfirst) Animation.startAnimation($("#expand"), true);
                else {
                    Animation.reloadHTML();
                }
            } else {
                alert(locale.getString("RES_" + res.code));
            }
        });
    }

    var login = function() {
        var req = {
            passwd: "",
            channel: "pc",
            acctId: ""
        };
        service.link(req, function(res) {
            if (res.code == 0) {
                getjackPot(true);
                getBalance();
                getKickOut();
            } else {
                alert(locale.getString("RES_" + res.code));
            }
        });
    }

    //推送
    var getBalance = function() {
        service.bindPushEvent(-3, function(res) {
            var balance = globalObj.balance + res.acct.balance,
                currency = globalObj.currency;
            $("#balance").text(currency + mm.addDotToNumber(balance));
            globalObj.balance = balance;
        });
    }

    var getKickOut = function() {
        service.bindPushEvent(-1, function(res) {
            alert(locale.getString("KICKOUT"));
            remote.app.exit(0)
        });
    }

    //加载声音资源
    WebAudioObject.loadMusic();

    getLanguage(globalObj.lan);
    setVersionOnUI();
    setLoginInfo();
    getGameInfo();
    login();

    //一分钟更新一次jackpot数据
    setInterval(getjackPot, 60000);


    //打开或关闭声音
    ipcRenderer.on('sound-on-off', function(event, msg) {
        var obj = WebAudioObject;
        if (!obj.isPlay) return;

        msg == 'off' ? obj.pauseMusic() : obj.playMusic();
    });

    //debug
    ipcRenderer.on('send-console', function(event, msg) {
        console.log(msg);
    })

});
