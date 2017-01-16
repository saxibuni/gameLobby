var mm = mm || {};

// is boolean
mm.isFunction = function(obj) {
    return typeof obj == 'function';
};

mm.isArray = function(obj) {
    return Object.prototype.toString.call(obj) == '[object Array]';
};

mm.isUndefined = function(obj) {
    return typeof obj == 'undefined';
};

mm.isNumber = function(value){
    return /^[\+\-]?\d+(\.\d+)?$/.test(value);
};

mm.isDebug = function(){
	return mm.config[mm.config.KEY_DEBUG_MOBE];
};

//convert

mm.parseInt = function(value){
    return this.isNumber(value) ? parseInt(value) : 0;
};

mm.parseFloat = function(value){
    return this.isNumber(value) ? parseFloat(value) : 0;
};

mm.parseFloatP = function(value, p){
    value = mm.parseFloat(value);
    return parseFloat(value.toFixed(p || 2));
};

mm.parseFloatStr = function(value, p){
	value = mm.parseFloat(value);
	return value.toFixed(p || 2);
}

mm.toFixedSpecial = function(value){
	value = mm.parseFloat(value);
	var v = Math.floor(value * 100)/100;
	
	if(v > Math.floor(v)) return v.toFixed(2);
	else return v.toString();
};

mm.parsePercentage = function(value){
	value = mm.parseFloat(value) * 100;
	return mm.parseFloatStr(value) + "%";
}

mm.toUpperFirstLetter = function(str){
	return str.substring(0,1).toUpperCase() + str.substring(1);   
};

mm.addDotToNumber=function(num,isCents){
	num = num.toString().replace(/\$|\,/g,'');  
    if(isNaN(num))  num = "0.00";  
    sign = (num == (num = Math.abs(num)));  
    num = Math.floor(num * 100 + 0.50000000001);  
    cents = num % 100;  
    num = Math.floor(num / 100).toString();  
    if(cents < 10) cents = "0" + cents;  
    for (var i = 0; i < Math.floor((num.length - ( 1 + i )) / 3); i++)  
    num = num.substring(0,num.length - (4 * i + 3)) +','+ num.substring(num.length - (4 * i + 3)); 
	if(isCents == false) return (((sign)? '' : '-') + num);
    return (((sign)? '' : '-') + num + '.' + cents); 
}

mm.getMoneySpans = function(value, pre){
	var val = value.replace(/,/g,"");
	pre = pre || "";
	var cs = val < 0 ? "nega" : "posi";
	return "<span class='" + cs + "'>" + pre + " " + value + "</span>"
};

mm.getThisWeek = function(){	
	var d1 = new Date();
	
	var day = d1.getDay();
	day = day == 0 ? 7 : day;

	d1.setDate(d1.getDate() - day + 1);
	//var d2 = new Date(d1);
	//d2.setDate(d1.getDate() + 6);
	
	//return [d1.format("yyyy-MM-dd"), d2.format("yyyy-MM-dd")];
	return [d1.format("yyyy-MM-dd"), (new Date()).format("yyyy-MM-dd")];
};

mm.getLastWeek = function(){
	var d1 = new Date();
	
	var day = d1.getDay();
	day = day == 0 ? 7 : day;

	d1.setDate(d1.getDate() - day - 6);

	var d2 = new Date(d1);
	d2.setDate(d1.getDate() + 6);
	
	return [d1.format("yyyy-MM-dd"), d2.format("yyyy-MM-dd")];
};

mm.getMoneySpan = function(value, pre, p ){
	value = mm.parseFloat(value);
	p = p || 2;
	pre = pre || "";
	var cs = value < 0 ? "nega" : "posi";
	return "<span class='" + cs + "'>" + pre + " " + value.toFixed(p) + "</span>"
};

mm.getSerialNo = function(){
	return new Date().format("yyyyMMddhhmmss") + Math.random();
};


// CONFIG

mm.config = {
	"KEY_DEBUG_MOBE": "debugMode",
	"KEY_TIMEOUT": "timeout",
	"KEY_SERVICE": "service",
	"KEY_SYSTEM" : "system"
};

mm.initConfig = function(obj){
	var config = mm.config;
	for(var k in obj){
		config[k] = obj[k];
	}
	
	config[config.KEY_DEBUG_MOBE] = config[config.KEY_DEBUG_MOBE] || false;
	config[config.KEY_TIMEOUT] = config[config.KEY_TIMEOUT] || 20;
	config[config.KEY_SERVICE] = config[config.KEY_SERVICE] || "";
	config[config.KEY_SYSTEM] = config[config.KEY_SYSTEM] || "";

};

mm.content = {};


//log

mm.log = function(log){
	var isDebug = mm.config[mm.config.KEY_DEBUG_MOBE];
	if(isDebug) console.info(log);
};

mm.error = function(log){
	console.warn(log);
};

//extend 

Date.prototype.format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "h+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "S": this.getMilliseconds()
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};

$.fn.getInstance = function(){
	return $(this).data("instance");
};
/////////////////////


mm.getParam=function (name){
     var reg = new RegExp("(^|&)"+ name +"=([^&]*)(&|$)");
     var r = window.location.search.substr(1).match(reg);
     if(r!=null)return  unescape(r[2]); return "web";
}


document.addEventListener('deviceready',function(){
	$.getJSON("config.json", function(data){
		mm.initConfig(data);
		mm.initPages();
		systemSetting();	
	});
},false);



//////hjj/////
mm.formatMoney = function(num){
	num = num.toString().replace(/\$|\,/g,'');  
    if(isNaN(num))  num = "0.00";  
    sign = (num == (num = Math.abs(num)));  
    num = Math.floor(num * 100 + 0.50000000001);  
    cents = num % 100;  
    num = Math.floor(num / 100).toString();  
    if(cents < 10) cents = "0" + cents;  
    for (var i = 0; i < Math.floor((num.length - ( 1 + i )) / 3); i++)  
    num = num.substring(0,num.length - (4 * i + 3)) +','+ num.substring(num.length - (4 * i + 3));  
    return (((sign)? '' : '-') + num + '.' + cents); 
}

mm.getMoneySpans = function(value, pre){
	var val = value.replace(/,/g,"");
	val = mm.parseFloat(val);
	pre = pre || "";
	var cs = val < 0 ? "nega" : "posi";
	return "<span class='" + cs + "'>" + pre + " " + value + "</span>"
};

mm.formatStr = function(str){
	return str.substring(0,1).toUpperCase() + str.substring(1).toLowerCase();   
};
