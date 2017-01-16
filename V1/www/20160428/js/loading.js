$(function() {
    const ipcRenderer = nodeRequire('electron').ipcRenderer,
        remote = nodeRequire('remote');

    var language = remote.getGlobal('sharedObject').lan;
    var resource = [],
        counter = 0,
        $progress = $('.progress'),
        $bar = $('.progress__bar'),
        $text = $('.progress__text');


    var init = function() {
        if (remote.getGlobal('sharedObject').isNeedUpgrade) {
            $("#mask").show();
            $("#upgrade").show();
        } else {
            getPreLoadResource();
        }
    }

    //预加载资源
    var getPreLoadResource = function() {
        $.ajax({
            url: remote.getGlobal('sharedObject').website + "/resource.txt",
            type: "get",
            dataType: "jsonp",
            jsonpCallback: 'resourceCallback',
            success: function(data) {
                resource = eval(data.resource);
                peloadHandler();
            },
            cache: false
        });
    }

    var peloadHandler = function() {
        var per = counter / resource.length * 100;
        $bar.css({ "width": per + "%" });
        $text.find('em').html(parseInt(per) + "%");

        if (counter == resource.length) {
            setTimeout(function() {
                //通知主进程  创建新窗口
                ipcRenderer.send('login-window-open');
            }, 500);
            return;
        }

        var url = resource[counter];
        counter++;

        var o = null;
        if (/.mp3/.test(url)) {
            o = document.createElement("audio");
            o.addEventListener('canplaythrough', peloadHandler); //可以播放，歌曲全部加载完毕
            o.preload = "preload";
        } else {
            o = document.createElement("img");
            o.addEventListener('load', peloadHandler);
        }
        o.src = url;
        o.style.display = "none";
    }

    //下载升级二进制文件   使用node模块调用外部默认浏览器打开下载
    var upgrade = function() {
        ipcRenderer.send('download-binery-file');
        cancel();
    }

    //取消升级 加载资源
    var cancel = function() {
        $("#mask").hide();
        $("#upgrade").hide();
        getPreLoadResource();
    }


    //获取当前语言
    var getLanguage = function(lan) {
        $.ajaxSettings.async = false;
        locale.setLocale(lan,function(){});
        $.ajaxSettings.async = true;

        var merchant = remote.getGlobal('sharedObject').merchantCode.toUpperCase().replace('DEMO', '');
        $("[key=UPDATE_INTRO]").html($("[key=UPDATE_INTRO]").html().replace('MERCHANTNAME', merchant));
    }

    $("#ok").on('click', upgrade);
    $("#cancel").on('click', cancel);

    getLanguage(language);
    init();

});
