!function(){
"object"!=typeof JSON&&(window.JSON={
stringify:function(){
return"";
},
parse:function(){
return{};
}
});
var e=function(){
!function(){
var e={},t={},o={};
e.COMBO_UNLOAD=0,e.COMBO_LOADING=1,e.COMBO_LOADED=2;
var n=function(e,o,n){
if(!t[e]){
t[e]=n;
for(var r=3;r--;)try{
moon.setItem(moon.prefix+e,n.toString()),moon.setItem(moon.prefix+e+"_ver",moon_map[e]);
break;
}catch(i){
moon.clear();
}
}
},r=window.alert;
window.__alertList=[],window.alert=function(e){
r(e),window.__alertList.push(e);
};
var i=function(e){
if(!e||!t[e])return null;
var n=t[e];
return"function"!=typeof n||o[e]||(n=t[e]=n(i,{},{},r),o[e]=!0),n;
};
e.combo_status=e.COMBO_UNLOAD,e.run=function(){
var t=e.run.info,o=t&&t[0],n=t&&t[1];
if(o&&e.combo_status==e.COMBO_LOADED){
var r=i(o);
n&&n(r);
}
},e.use=function(t,o){
e.run.info=[t,o],e.run();
},window.define=n,window.seajs=e;
}(),function(){
if(window.__nonce_str){
var e=document.createElement;
document.createElement=function(t){
var o=e.apply(this,arguments);
return"object"==typeof t&&(t=t.toString()),"string"==typeof t&&"script"==t.toLowerCase()&&o.setAttribute("nonce",window.__nonce_str),
o;
};
}
window.addEventListener&&window.__DEBUGINFO&&Math.random()<.01&&window.addEventListener("load",function(){
var e=document.createElement("script");
e.src=__DEBUGINFO.safe_js,e.type="text/javascript",e.async=!0;
var t=document.head||document.getElementsByTagName("head")[0];
t.appendChild(e);
});
}(),function(){
function e(e){
var t="; "+document.cookie,o=t.split("; "+e+"=");
return 2==o.length?o.pop().split(";").shift():void 0;
}
window.__consoleList=[];
for(var t=window.console,o=function(e){
return function(){
var o=arguments;
window.__consoleList.push({
type:e,
msg:o,
time:+new Date
});
try{
t&&t[e]&&(t[e].apply?t[e].apply(t,o):t[e](o[0]||""));
}catch(n){}
};
},n=["log","info","error","warn","debug"],r={},i=0,a=n.length;a>i;++i){
var s=n[i];
r[s]=o(s);
}
if(window.console=r,window._console=t,window.localStorage&&window.__DEBUGINFO){
var c=e("DEBUG_SWITCH"),u=window.__DEBUGINFO;
if(("1"==c||-1!=location.href.indexOf("moon_debug1=1"))&&u.debug_js){
window.__moondebug=!0;
var l=document.createElement("script");
l.src=u.debug_js,l.type="text/javascript",l.async=!0;
var d=document.head||document.getElementsByTagName("head")[0];
d.appendChild(l);
}
}
-1!=location.href.indexOf("moon_debug2=1")&&(window.onerror=function(e,t,o,n){
var r=window.console;
"undefined"!=typeof e&&r.error("error : "+e),"undefined"!=typeof t&&r.error("file : "+t);
var i=[];
"undefined"!=typeof o&&i.push("line : "+o),"undefined"!=typeof n&&i.push("col : "+n),
i.length>0&&r.error(i.join(", "));
});
}(),function(){
function e(e){
return"[object Array]"===Object.prototype.toString.call(e);
}
function t(e){
return"[object Object]"===Object.prototype.toString.call(e);
}
function n(e){
var t=e.stack||e.toString()||"";
try{
t=t.replace(/http(s)?:\/\/res\.wx\.qq\.com/g,"");
for(var n=/\/([^.]+)\/js\/(\S+?)\.js(\,|:)?/g;n.test(t);)t=t.replace(n,"$2$3");
}catch(e){
t=e.stack?e.stack:"";
}
var r=[];
for(o in f)f.hasOwnProperty(o)&&r.push(o+":"+f[o]);
return r.push("STK:"+t.replace(/\n/g,"")),r.join("|");
}
function r(e){
if(!e){
var t=window.onerror;
window.onerror=function(){},m=setTimeout(function(){
window.onerror=t,m=null;
},50);
}
}
function i(e){
var t;
if(window.ActiveXObject)try{
t=new ActiveXObject("Msxml2.XMLHTTP");
}catch(o){
try{
t=new ActiveXObject("Microsoft.XMLHTTP");
}catch(n){
t=!1;
}
}else window.XMLHttpRequest&&(t=new XMLHttpRequest);
t&&(t.open("POST",location.protocol+"//mp.weixin.qq.com/mp/jsmonitor?",!0),t.setRequestHeader("cache-control","no-cache"),
t.setRequestHeader("Content-Type","application/x-www-form-urlencoded; charset=UTF-8"),
t.setRequestHeader("X-Requested-With","XMLHttpRequest"),t.send(e));
}
function a(e){
return function(t,o){
if("string"==typeof t)try{
t=new Function(t);
}catch(n){
throw n;
}
var i=[].slice.call(arguments,2),a=t;
return t=function(){
try{
return a.apply(this,i.length&&i||arguments);
}catch(e){
throw e.stack&&console&&console.error&&console.error("[TryCatch]"+e.stack),u&&window.__moon_report&&(window.__moon_report([{
offset:y,
log:"timeout_error;host:"+top.location.host,
e:e
}]),r(m)),e;
}
},e(t,o);
};
}
function s(e){
return function(t,o,n){
if("undefined"==typeof n)var n=!1;
var i=this,a=o;
return o=function(){
try{
return a.apply(i,arguments);
}catch(e){
throw e.stack&&console&&console.error&&console.error("[TryCatch]"+e.stack),u&&window.__moon_report&&(window.__moon_report([{
offset:g,
log:"listener_error;type:"+t+";host:"+top.location.host,
e:e
}]),r(m)),e;
}
},a.moon_lid=j,E[j]=o,j++,e.call(i,t,o,n);
};
}
function c(e){
return function(t,o,n){
if("undefined"==typeof n)var n=!1;
var r=this;
return o=E[o.moon_lid],e.call(r,t,o,n);
};
}
var u,l,d,f,w,m,p=/MicroMessenger/i.test(navigator.userAgent),_=window.define,h=0,g=2,v=4,y=9,O=10;
if(window.__initCatch=function(e){
u=e.idkey,l=e.startKey||0,d=e.limit,f=e.reportOpt||"",w=e.extInfo||"";
},window.__moon_report=function(o){
if(/mp\.weixin\.qq\.com/.test(location.href)&&!(Math.random()>.5)&&p&&top==window&&(t(o)&&(o=[o]),
e(o)&&""!=u)){
var r="",a=[],s=[],c=[],f=[];
"number"!=typeof d&&(d=1/0);
for(var m=0;m<o.length;m++){
var _=o[m]||{};
if(!(_.offset>d||"number"!=typeof _.offset||_.offset==v&&w&&w.network_rate&&Math.random()>=w.network_rate)){
var h=1/0==d?l:l+_.offset;
a[m]="[moon]"+u+"_"+h+";"+_.log+";"+n(_.e||{})||"",s[m]=h,c[m]=1;
}
}
for(var g=0;g<s.length;g++)f[g]=u+"_"+s[g]+"_"+c[g],r=r+"&log"+g+"="+a[g];
f.length>0&&i("idkey="+f.join(";")+"&lc="+a.length+r);
}
},window.setTimeout=a(window.setTimeout),window.setInterval=a(window.setInterval),
Math.random()<.01&&window.Document&&window.HTMLElement){
var E={},j=0;
Document.prototype.addEventListener=s(Document.prototype.addEventListener),Document.prototype.removeEventListener=c(Document.prototype.removeEventListener),
HTMLElement.prototype.addEventListener=s(HTMLElement.prototype.addEventListener),
HTMLElement.prototype.removeEventListener=c(HTMLElement.prototype.removeEventListener);
}
var D=window.navigator.userAgent;
if((/ip(hone|ad|od)/i.test(D)||/android/i.test(D))&&!/windows phone/i.test(D)&&window.localStorage&&window.localStorage.setItem){
var b=window.localStorage.setItem,L=0;
window.localStorage.setItem=function(e,t){
if(!(L>=10))try{
b.call(window.localStorage,e,t);
}catch(o){
o.stack&&console&&console.error&&console.error("[TryCatch]"+o.stack),window.__moon_report([{
offset:O,
log:"localstorage_error;"+o.toString(),
e:o
}]),L++,L>=3&&window.moon&&window.moon.clear&&moon.clear();
}
};
}
window.seajs&&_&&(window.define=function(){
for(var e,t=[],o=arguments&&arguments[0],n=0,i=arguments.length;i>n;n++){
var a=e=arguments[n];
"function"==typeof e&&(e=function(){
try{
return a.apply(this,arguments);
}catch(e){
throw"string"==typeof o&&console.error("[TryCatch][DefineeErr]id:"+o),e.stack&&console&&console.error&&console.error("[TryCatch]"+e.stack),
u&&window.__moon_report&&(window.__moon_report([{
offset:h,
log:"define_error;id:"+o+";",
e:e
}]),r(m)),e;
}
},e.toString=function(e){
return function(){
return e.toString();
};
}(arguments[n])),t.push(e);
}
return _.apply(this,t);
});
}(),function(e){
function t(e,t,o){
return window.__DEBUGINFO?(window.__DEBUGINFO.res_list||(window.__DEBUGINFO.res_list=[]),
window.__DEBUGINFO.res_list[e]?(window.__DEBUGINFO.res_list[e][t]=o,!0):!1):!1;
}
function o(e){
var t=new TextEncoder("utf-8").encode(e),o=crypto.subtle||crypto.webkitSubtle;
return o.digest("SHA-256",t).then(function(e){
return n(e);
});
}
function n(e){
for(var t=[],o=new DataView(e),n=0;n<o.byteLength;n+=4){
var r=o.getUint32(n),i=r.toString(16),a="00000000",s=(a+i).slice(-a.length);
t.push(s);
}
return t.join("");
}
function r(e,t,o){
if("object"==typeof e){
var n=Object.prototype.toString.call(e).replace(/^\[object (.+)\]$/,"$1");
if(o=o||e,"Array"==n){
for(var r=0,a=e.length;a>r;++r)if(t.call(o,e[r],r,e)===!1)return;
}else{
if("Object"!==n&&i!=e)throw"unsupport type";
if(i==e){
for(var r=e.length-1;r>=0;r--){
var s=i.key(r),c=i.getItem(s);
if(t.call(o,c,s,e)===!1)return;
}
return;
}
for(var r in e)if(e.hasOwnProperty(r)&&t.call(o,e[r],r,e)===!1)return;
}
}
}
var i=e.localStorage,a=document.head||document.getElementsByTagName("head")[0],s=1,c=1,u={
prefix:"__MOON__",
loaded:[],
unload:[],
hit_num:0,
mod_num:0,
version:1003,
init:function(){
u.loaded=[],u.unload=[];
var t,n,a;
if(i){
var s="_moon_ver_key_",c=i.getItem(s);
c!=u.version&&(u.clear(),i.setItem(s,u.version));
}
if(-1!=location.search.indexOf("no_moon1=1")&&u.clear(),i){
var l=1*i.getItem(u.prefix+"clean_time"),d=+new Date;
if(d-l>=1296e6){
u.clear();
try{
!!i&&i.setItem(u.prefix+"clean_time",+new Date);
}catch(f){}
}
}
r(moon_map,function(r,s){
if(n=u.prefix+s,a=!!r&&r.replace(/^http(s)?:\/\/res.wx.qq.com/,""),t=!!i&&i.getItem(n),
version=!!i&&(i.getItem(n+"_ver")||"").replace(/^http(s)?:\/\/res.wx.qq.com/,""),
u.mod_num++,t&&a==version){
if("https:"==location.protocol&&window.moon_hash_map&&window.moon_hash_map[s]&&window.crypto)try{
o(t).then(function(e){
window.moon_hash_map[s]!=e&&console.log(s);
});
}catch(c){}
try{
var l="//# sourceURL="+s+"\n//@ sourceURL="+s;
e.eval.call(e,'define("'+s+'",[],'+t+")"+l),u.hit_num++;
}catch(c){
u.unload.push(a.replace(/^http(s)?:\/\/res.wx.qq.com/,""));
}
}else u.unload.push(a.replace(/^http(s)?:\/\/res.wx.qq.com/,""));
}),u.load(u.genUrl());
},
genUrl:function(){
var e=u.unload;
if(!e||e.length<=0)return[];
var t,o,n="",r=[],i={},a=-1!=location.search.indexOf("no_moon2=1"),s="//res.wx.qq.com";
-1!=location.href.indexOf("moon_debug2=1")&&(s="//mp.weixin.qq.com");
for(var c=0,l=e.length;l>c;++c)/^\/(.*?)\//.test(e[c]),RegExp.$1&&(o=RegExp.$1,n=i[o],
n?(t=n+","+e[c],t.length>1e3||a?(r.push(n+"?v="+u.version),n=location.protocol+s+e[c],
i[o]=n):(n=t,i[o]=n)):(n=location.protocol+s+e[c],i[o]=n));
for(var d in i)i.hasOwnProperty(d)&&r.push(i[d]);
return r;
},
load:function(e){
if(!e||e.length<=0)return seajs.combo_status=seajs.COMBO_LOADED,seajs.run(),void console.debug("[moon] load js complete, all in cache, cost time : 0ms, total count : "+u.mod_num+", hit num: "+u.hit_num);
seajs.combo_status=seajs.COMBO_LOADING;
var t=0,o=+new Date;
r(e,function(n){
u.request(n,c,function(){
if(t++,t==e.length){
var n=+new Date-o;
seajs.combo_status=seajs.COMBO_LOADED,seajs.run(),console.debug("[moon] load js complete, url num : "+e.length+", total mod count : "+u.mod_num+", hit num: "+u.hit_num+", use time : "+n+"ms");
}
});
});
},
request:function(e,o,n){
if(e){
o=o||0;
var r=-1;
window.__DEBUGINFO&&(__DEBUGINFO.res_list||(__DEBUGINFO.res_list=[]),__DEBUGINFO.res_list.push({
type:"js",
status:"pendding",
start:+new Date,
end:0,
url:e
}),r=__DEBUGINFO.res_list.length-1);
var i=document.createElement("script");
i.src=e,i.type="text/javascript",i.async=!0,i.onerror=function(i){
if(t(r,"status","error"),t(r,"end",+new Date),o>=0)u.request(e,o,n);else if(window.__moon_report){
var a=new Error(i);
window.__moon_report([{
offset:s,
log:"load_script_error: "+e,
e:a
}]);
}
},"undefined"!=typeof moon_crossorigin&&moon_crossorigin&&i.setAttribute("crossorigin",!0),
i.onload=i.onreadystatechange=function(){
t(r,"status","loaded"),t(r,"end",+new Date),!i||i.readyState&&!/loaded|complete/.test(i.readyState)||(t(r,"status","200"),
i.onload=i.onreadystatechange=null,"function"==typeof n&&n());
},o--,a.appendChild(i);
}
},
setItem:function(e,t){
!!i&&i.setItem(e,t);
},
clear:function(){
i&&(r(i,function(e,t){
~t.indexOf(u.prefix)&&i.removeItem(t);
}),console.debug("[moon] clear"));
}
};
seajs&&seajs.use&&"string"==typeof window.__moon_mainjs&&seajs.use(window.__moon_mainjs),
window.moon=u;
}(window),window.moon.init();
};
e();
}();