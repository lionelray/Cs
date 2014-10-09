//二维码右下角弹窗
 document.write('<div id="china_ads_div405" style="width:126px">');
document.write('<div style="text-align:right;padding-right:5px;font-weight:700;cursor: pointer;font-size:12px;color:#000067;background:#CAEBFE;border:1px #245286 solid;border-bottom:0" onclick="document.getElementById(\'china_ads_div405\').style.display=\'none\'">关闭</div>');
document.write('<div><a href="tencent://message/?uin=269505494&Site=http://www.zzjs.net/&Menu=yes" target="_blank"><img src="qrcode.png" width="126" height="126" border="0"></a><div style="background:#CAEBFE;text-align:center">扫一扫<br>点击二维码请求帮助</div></div>');
document.write('</div>');
 var Class = {
   create: function() {
     return function() {
       this.initialize.apply(this, arguments);
     }
   }
 }//欢迎来到站长特效网，我们的网址是www.zzjs.net，很好记，zz站长，js就是js特效，本站收集大量高质量js代码，还有许多广告代码下载。
 Function.prototype.bind = function() {
   var __method = this, args = $A(arguments), object = args.shift();
   return function() {
     return __method.apply(object, args.concat($A(arguments)));
   }
 }
 var $A = Array.from = function(iterable) {
   if (!iterable) return [];
   if (iterable.toArray) {
     return iterable.toArray();
   } else {
     var results = [];
     for (var i = 0; i < iterable.length; i++)
       results.push(iterable[i]);
     return results;
   }
 }//欢迎来到站长特q效网，我们的网址是www.zzjs.net，很好记，zz站长，js就是js特效，本站收集大量高质量js代码，还有许多广告代码下载。
 var Float = Class.create();
 Float.prototype = {
  initialize: function(elem, options) {
   this.toDo = options.toDo || function(){},
   this.bodyScrollTop = document.documentElement.scrollTop || document.body.scrollTop,
   this.bodyScrollLeft = document.documentElement.scrollLeft || document.body.scrollLeft,
   this.element = document.getElementById(elem);
   this.dely = options.dely || 500;
   this.top = options.top || 0;
   this.left = options.left || 0;
  },
  start:function(){
   if(!this.element){
    alert('please set a element first!');
    return false;
   }
   this.element.style.position = 'absolute';
   this.toDo();
   setInterval(this.toDo.bind(this),this.dely)
  }
 }
var f = new Float('china_ads_div405',{dely:100,
 toDo:function(){
  var isIE = document.all && window.external;
  this.bodyScrollTop = document.documentElement.scrollTop || document.body.scrollTop;
  this.bodyScrollLeft = document.documentElement.scrollLeft || document.body.scrollLeft;
  if(isIE){
   this.docWidth = document.documentElement.clientWidth || document.body.clientWidth;
   this.docHeight = document.documentElement.clientHeight || document.body.clientHeight;
  }else{
   this.docWidth = (document.body.clientWidth > document.documentElement.clientWidth)?document.documentElement.clientWidth:document.body.clientWidth;
   this.docHeight = (document.body.clientHeight > document.documentElement.clientHeight)?document.documentElement.clientHeight:document.body.clientHeight;
  }
  this.element.style.top = (this.docHeight - parseInt(this.element.offsetHeight,10)) + parseInt(this.bodyScrollTop, 10)+ 'px';
  this.element.style.left = (this.docWidth - parseInt(this.element.offsetWidth,10)) + parseInt(this.bodyScrollLeft, 10) + 'px';
 }
});//欢迎来到站长特效网，d我们的网址是www.zzjs.net，很好记，zz站长，js就是js特效，本站收集大量高质量js代码，还有许多广告代码下载。
f.start();
//二维码结束