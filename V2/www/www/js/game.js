$(function() {
    const ipcRenderer = nodeRequire('electron').ipcRenderer;
    const remote = nodeRequire('remote');
    var $toolbar = $(".toolbar");
    var dic = {};
    var code = "";
    var currentWin = remote.getCurrentWindow();  //当前游戏窗体

    var getParam = function(url, name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = url.substr(url.indexOf('?') + 1).match(reg);
        if (r != null) return unescape(r[2]);
        return "";
    }

    var setIframeScr = function() {
        var url = window.location.href.substr(window.location.href.indexOf("=") + 1);
        var iframe = document.getElementById('frame');
        document.getElementById('frame').src = "http://" + url;
        return url;
    }

    var init = function() {
        var url = setIframeScr();
        code = getParam(url, 'game'),
        language = getParam(url, 'language');
        
        $.getJSON("json/" + language + ".json", {}, function(data) {
            dic = data;
            var title = dic[code];
            $('title').html(title);
        });
    }

    init();


    $("#closeWin").on('click', function(event) {
        remote.getCurrentWindow().close();
    });

    $("#fullscreenToggle").on('click', function(event) {
        var flag = !currentWin.isFullScreen();
        ipcRenderer.send('fullscreen-game',flag, code);
    });

    currentWin.on('enter-full-screen',function (argument) {
        $("#fullscreenToggle").addClass('fullScreen').removeClass('normalScreen');
    });

    currentWin.on('leave-full-screen',function (argument) {
        $("#fullscreenToggle").addClass('normalScreen').removeClass('fullScreen');
    });

    //esc退出全屏
    window.addEventListener('keyup',function(e){
        var flag = currentWin.isFullScreen();
        if (e.keyCode === 27 && flag) {
            $("#fullscreenToggle").trigger('click');
        }
    });

    //iframe无法触发父级body的mouseover事件   所以在原来的body上加了一个eventLayer层
    $(document).on('mouseover',function(e){
        if(e.clientY > 34) $toolbar.css('top','-34px');
        else $toolbar.css('top','0px');
    });

    $toolbar.on('mouseleave',function(e){
        $toolbar.css('top','-35px');
    });

    window.close = function(){
        confirm(dic['MES_COMFIRM_QUIT']) && (remote.getCurrentWindow().destroy());
    }

    // var iframe = document.getElementById('frame');
    // iframe. onload = iframe. onreadystatechange = function(){
    //     if (!iframe.readyState || iframe.readyState == "complete") {     
    //         alert("Local iframe is now loaded.");
    //         iframe.contentWindow.showHistory = function(){
    //             alert(1);
    //         }        
    //     }  
    // }   

});