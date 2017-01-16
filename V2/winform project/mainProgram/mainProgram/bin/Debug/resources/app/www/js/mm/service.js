var mm = mm || {};

//mock ws://lobby.egame.staging.spadegaming.biz:8090
//rng: ws://lobby.egame.staging.spadegaming.biz:8080
//dev ws://lobby.egame.staging.spadegaming.biz:18088
//ws://lobby.egame.staging.spgaming88.net:8080/websocket
//'SS88': "ws://lobbyss88.egame.staging.spadegaming.biz:8080",

mm.Commands = {
    LINK: 1,
    LOGIN: 14,
    JACKPOT: 47,
    GAMEINFO: 48,
    CHANGEPASSWORD:15
};

mm.Service = function(){
    var _url = null;
    var _socket = null;
    var _queue = [];
    var _register = [];
    var _session = [];
    var that = this;
    const remote = nodeRequire('remote');
	
	mm.Service.it = this;

    var _connect = function(){
		_url = remote.getGlobal('sharedObject').socket;
        console.log("connect:" + _url);
        _socket = new WebSocket(_url);
        _socket.onopen = _onOpen;
        _socket.onclose = _onClose;
        _socket.onerror = _onError;
        _socket.onmessage = _onMessage;
    };
    
	var _send = function(command, dat, callback, sender, isMask){
		isMask = isMask == undefined ? true : isMask;
        		
        if(_socket && _socket.readyState == 1){
            var serialNo = mm.getSerialNo();
            _register[serialNo] = {callback: callback, sender: sender, isMask : isMask};

			dat = dat || {};
            dat.serialNo = serialNo;
            if(command != mm.Commands.LOGIN){
                //dat.sessionId = $.cookie("sid");//_session.sessionId;
                //dat.token = $.cookie("token"); //_session.token;

                dat.sessionId = localStorage.getItem('sid');
                dat.token = localStorage.getItem('token');
            }

            var jsData = command + "." + JSON.stringify(dat);
            _socket.send(jsData);
            return console.log("Send:::::" + jsData);
        }

        _queue.push({
            command: command,
            dat : dat,
            callback: callback,
            sender: sender
        });
        if(!_socket || _socket.readyState == _socket.CLOSED) _connect();
    };
	
    /******* event ********/
    var _onOpen = function(){
        console.log("socket open");
        while(_queue.length > 0 ){
            var data = _queue.shift();
            _send(data.command, data.dat, data.callback, data.sender);
        }
    };
    var _onClose = function(){
        console.log("socket closed");
		that.onClose();
    };
    var _onError = function(){
        console.log("socket err");
		that.onError();
    };
    var _onMessage = function(e){
       	console.log("Receive:::::" + e.data);
        var service = mm.Service.it;
        var obj = _getObject(e.data);
        if(!obj) return ;

        var command = obj.command, dat = obj.dat;
        if(command == mm.Commands.LOGIN){

            //electron中不支持cookie
            //$.cookie("sid", dat.sessionId);
            //$.cookie("token", dat.token);

            localStorage.setItem("sid", dat.sessionId);
            localStorage.setItem("token", dat.token);

            _session["sessionId"] = dat.sessionId;
            _session["token"] = dat.token;
        }

        if(command > 0){
            var serialNo = dat.serialNo, fns = _register[serialNo];
            if(!fns) return ;
            delete _register[serialNo];
            that.deal(dat, fns);

        }else{
            // push message
            var fns = _register[command];
            if(fns && fns.callback && mm.isFunction(fns.callback)) fns.callback.call(fns.sender, dat);
        }
    };

    this.bindPushEvent = function(command, callback, sender){
        _register[command] = {callback: callback, sender: sender};
    };
	
    this.unBindPushEvent = function(command, callback, sender){
        delete _register[command];
    };	
	
    /***** util *****/
    var _getObject = function(str){
        try{
            var i = str.indexOf("{");
            return {command: parseInt(str.substr(0, i)), dat:JSON.parse(str.substr(i))};
        }catch (e){
            console.log("parse json err");
            return null;
        }
    };

    /*********** api ************/
	//14
	this.login = function(req, callback, sender){
		_send(mm.Commands.LOGIN, req, callback, sender);
	};

    //47
    this.jackpot = function(req, callback, sender){
        _send(mm.Commands.JACKPOT, req, callback, sender);
    };

    //1
    this.link = function(req, callback, sender){
        _send(mm.Commands.LINK, req, callback, sender);
    };
	
    //48
    this.gameinfo = function(req, callback, sender){
        _send(mm.Commands.GAMEINFO, req, callback, sender);
    }
    //15
    this.ChangePasswordRequest = function(req, callback, sender){
        _send(mm.Commands.CHANGEPASSWORD, req, callback, sender);
    }
	
};

mm.Service.prototype.deal = function(dat, fns){
	delete dat.sessionId;
	delete dat.token;
	delete dat.serialNo;
	var callback = fns.callback, sender = fns.sender;
	if(mm.isFunction(callback)) callback.call(sender, dat);
};

mm.Service.prototype.onClose = function(){};
mm.Service.prototype.onError = function(){};

mm.Service.create = function(){
	mm.Service.it = mm.Service.it || new mm.Service();
	return mm.Service.it;
};

var service=mm.Service.create();
