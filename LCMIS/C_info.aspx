<%@ Page Language="C#" AutoEventWireup="true" CodeFile="C_info.aspx.cs" Inherits="C_info" %>

<!DOCTYPE html>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%if (Session["uid"] == null)Response.Redirect("log.aspx"); %>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>实验室耗材管理系统</title>
<style type="text/css">
/* 全局CSS*/

* {
	margin: 0px;
	padding: 0px;
}
a {
	text-decoration: none;
	outline: none;
	background-color: #FFF;
}
a:hover {
}
/* 实例CSS */
html {
	_background: url(about:blank);
} /*阻止闪动 in IE6 , 把空文件换成about:blank , 减少请求*/
body {
	font-size: 18px;
	font-family: Arial, Tahoma, sans-serif;
	color: #EEEEEE;
	text-align: center;
	background: #E2E2E2;
	background-color: #FFFFFF;
	background-image: url(image/bg.jpg);
}
#topToolbar {
	_display: none;
	width: 100%;
	height: 40px;
	line-height: 40px;
	border-bottom: 2px solid #409F89;
	position: fixed;
	top: -40px;
	left: 0;
	_top: 0;
	_position: absolute;
_top:expression(documentElement.scrollTop);
	background-color: #3EBAFD;
}
#bottomToolbar {
	width: 100%;
	height: 40px;
	line-height: 40px;
	border-top: 2px solid #409F89;
	position: fixed;
	bottom: 0;
	left: 0;
	_position: absolute;
_top:expression(documentElement.scrollTop+documentElement.clientHeight-this.offsetHeight);
	background-color: #3EBAFD;	/*
		document.body.scrollTop 网页滚动的距离
		document.body.clientHeight 网页可见区域高
		this.offsetHeight 当前元素的高度
	*/
}
#bottomToolbar a {
	color: #FFF;
	background-color: #3EBAFD;
}
#header {
	width: 100%;
	height: 80px;
	line-height: 80px;
	border-top: 2px solid #409F89;
	background-color: #3EBAFD;
}
#content h1 {
	font-size: 18px;
	color: #000;
	margin-bottom: 30px;
	background-color: #FFF;
}
#content p {
	margin-bottom: 18px;
	color: #000000;
	background-color: #FFF;
}
#content a {
	color: #000000;
	background-color: #FFF;
}
.top {
	background-image: url(images/bg-middle.png);
	background-repeat: repeat-x;
	background-color: #FFF;
	z-index: 100;
}
.top1 {
	background-color: #3EBAFD;
	color: #FFF;
	font-size: 16px;
	cursor: pointer;
	z-index: 100;
}
body, td, th {
	color: #D6D6D6;
}
.words {
	right: auto;
	background-color: #3EBAFD;
	z-index: 88;
}
ul, li, dt {
	list-style: none;
}
A {
	color: #000000;
	text-decoration: none
}
IMG {
	display: inline-block;
	font-size: 12px;
	border-top-style: none;
	border-right-style: none;
	border-left-style: none;
	border-bottom-style: none
}
A:hover {
color:# c51007
}
#dangqian A {
	color: #c51007
}
.clear {
	clear: both
}
.warper {
	margin: 0px auto;
	width: 1451px;
	background-color: #3EBAFD;
}
.content {
	width: 180px;
	height: 260px;
	margin: 0px auto;
	padding: 30px 30px;
	background: rgba(255, 255, 255, 0.6)!important;
	filter: Alpha(Opacity=35);
	background: #fff; /*　使用IE专属滤镜实现IE背景透明*/
}
.content p {
	position: relative;
} /*实现IE文字不透明*/
.menu {
margin - top:3px;
line - height:28px;
	height: 37px;
	background-color: #3EBAFD;
	top: 1px;
	left: 2px;
}
.menu_01 {
	float: left
}
.menu_02 {
	float: right
}
.menu A {
font - weight:bold;
	color: #fff
}
.menu A:hover {
	color: #000000
}
.menu DL {
	float: left
}
.menu DD {
	float: left;
	width: 132px;
text - align:center
}
.menu DT {
padding - left:1px;
background:url(.. / images / menu_04.gif) no - repeat left top;
	float: left;
	width: 122px;
	position: relative;
	height: 28px;
text - align:center;
	top: 12px;
}
.menuli_div {
	left: 1px;
	padding-bottom: 8px;
	width: 122px;
	position: absolute;
	top: 28px;
	background-color: #3EBAFD;
	color: #F00;
}
.menuli_div LI {
	padding-bottom: 1px;
	line-height: 24px;
	height: 24px;
	background-color: #3EBAFD;
	background-image: url(images/menu_05.gif);
	background-repeat: no-repeat;
	background-position: center bottom;
}
.menu DT UL LI A {
	font-weight: normal;
	background-color: #3EBAFD;
}
.menuli .menuli_div {
	display: none
}
.menuli_hover .menuli_div {
	display: block;
	background-color: #3EBAFD;
}
.div-a {
	width: 1175px;
	height: 1390px;
	background-image: none;
	background-repeat: no-repeat;
	padding: 30px;
	margin-top: 0px;
	left: 50px;
	right: 50px;
	margin-right: auto;
	margin-left: auto;
	filter: alpha(Opacity=35);
	position: absolute;
	z-index: 80;
}/*透明控制*/
.div-b {
	width: 1160px;
	height: 1390px;
	color: #FFF;
	filter: alpha(Opacity=35);
	-moz-opacity: 0.8;
	opacity: 0.8;
	border-top-style: none;
	border-right-style: none;
	border-bottom-style: none;
	border-left-style: none;
	background-color: #000000;
	padding: 30px;
	left: 18px;
	right: 50px;
	margin-right: auto;
	margin-left: auto;
	z-index: 80;
	position: absolute;
	text-align: left;
	top: 28px;
}
/* CSS注释说明：这里对CSS代码换行是为了让代码在此我要中显示完整，换行后CSS效果不受影响 */

#n {
	margin: 10px auto;
	width: 920px;
	border: 1px solid #CCC;
	font-size: 12px;
	line-height: 30px;
}
#n a {
	padding: 0 4px;
	color: #333
}
.words2 {
	font-size: 18px;
	color: #FFF;
	font-weight: bold;
	position: absolute;
	z-index: 99;
	width: 202px;
	height: 197px;
	left: 196px;
	background-color: #3EBAFD;
}
.div-a .div-b div {
	font-size: 18px;
	font-weight: bold;
	color: #000;
}
.test {
	color: #FFF;
	font-weight: bold;
	font-size: 18px;
	z-index: 1000;
	position: relative;
}
#form1 {
	color: #CCCCCC;
}
</style>
<script type="text/javascript" src="js/jquery-1.5.1.js"></script>
<script type="text/javascript">
    $(function () {
        $(window).scroll(function () {
            var topToolbar = $("#topToolbar");
            var headerH = $("#header").outerHeight();
            var scrollTop = $(document).scrollTop();
            if ($.browser.msie && ($.browser.version == "6.0") && !$.support.style) {
                if (scrollTop >= headerH) {
                    topToolbar.show();
                } else if (scrollTop < headerH) {
                    topToolbar.hide();
                }
            } else {
                if (scrollTop >= headerH) {
                    topToolbar.stop(false, true).animate({ 'top': 0 });
                } else if (scrollTop < headerH) {
                    topToolbar.stop(false, true).animate({ 'top': -40 });
                }
            };
        });
    });
</script>
</head>
<body bgcolor="#3EBAFD">
<form id="form1" runat="server">
  <div class="top1 menuli warper menu" align="center" 
        style="position: absolute; z-index: 101; width: 1346px;" >
    <DT class=menuli onMouseOver="this.className='menuli_hover'" 
  onmouseout="this.className='menuli'">
      <div align="center"> <a href="homepage.aspx" class="words">首页</a> </div>
    </DT>
    <DT class=menuli onMouseOver="this.className='menuli_hover'" 
  onmouseout="this.className='menuli'">
      <div align="center">
        <UL class=menuli_div>
          <LI> </LI>
          <LI class="words"><A href="C_info.aspx">耗材编辑</A></LI>
          <LI class="words"><A href="csearch.aspx">耗材查询</A></LI>
        </UL>
        耗材管理</div>
    </DT>
    <DT class=menuli onMouseOver="this.className='menuli_hover'" 
  onmouseout="this.className='menuli'">
      <div align="center">
        <UL class=menuli_div>
          <LI> </LI>
          <LI class="words"><A href="instock.aspx">入库</A></LI>
          <LI class="words"><A href="outstock.aspx">出库</A></LI>
          <li class="words"><A href="ssearch.aspx">库存查询</A></li>
        </UL>
        库存管理</div>
    </DT>
    <DT class=menuli onMouseOver="this.className='menuli_hover'" 
  onmouseout="this.className='menuli'">
      <div align="center">
        <UL class=menuli_div>
          <LI> </LI>
          <LI class="words"><A href="apply.aspx">耗材申请</A></LI>
          <LI class="words"><A href="approve.aspx">耗材审批</A></LI>
        </UL>
        审批管理</div>
    </DT>
    <DT class=menuli onMouseOver="this.className='menuli_hover'" 
  onmouseout="this.className='menuli'">
      <div align="center">
        <UL class=menuli_div>
          <LI> </LI>
          <LI><A href="sys.aspx">用户管理</A></LI>
          <LI><A href="user.aspx">个人信息</A></LI>
        </UL>
        系统管理</div>
    </DT>
    <dl>
      <dt class="menuli" onMouseOver="this.className='menuli_hover'" 
  onmouseout="this.className='center'"><span style="CURSOR: hand" onClick="javascript:window.external.AddFavorite('http://172.18.55.106:80','实验室耗材管理系统')" title="网址">收藏本站</span>
    </dl>
    <div align="center" class="words"> 当前用户：
      <%Response.Write(Session["uid"].ToString()); %>
      --你好！
      <asp:Button ID="Button4" runat="server" Height="24px" onclick="Button4_Click" 
            Text="退出" Width="66px" />
    </div>
  </div>
  <div id="content">
  <div class="div-a">
  <div class="div-b">
  <span class="test">
  <div>
    <fieldset style="width:500px">
      <legend style="color:#FFF">耗材信息编辑</legend>
      <table style="WIDTH: 395px">
        <tr>
          <td style="WIDTH: 85px; HEIGHT: 40px">耗材编号</td>
          <td style="WIDTH: 248px; HEIGHT: 40px"><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="34px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="123px"> </asp:DropDownList></td>
        </tr>
        <tr>
          <td style="WIDTH: 85px; HEIGHT: 40px">耗材名称</td>
          <td style="WIDTH: 248px; HEIGHT: 40px"><asp:TextBox ID="TextBox1" runat="server" Height="18px" Width="122px"></asp:TextBox></td>
        </tr>
        <tr>
          <td style="WIDTH: 85px; HEIGHT: 40px">品牌</td>
          <td style="WIDTH: 248px; HEIGHT: 40px"><asp:TextBox ID="TextBox2" runat="server" Height="18px" Width="122px"></asp:TextBox></td>
        </tr>
        <tr>
          <td style="WIDTH: 85px; HEIGHT: 40px">所属类别</td>
          <td class="auto-style1"><asp:DropDownList ID="DropDownList3" runat="server"> </asp:DropDownList>
            <asp:TextBox ID="TextBox3" runat="server" Width="62px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="添加" /></td>
        </tr>
        <tr>
          <td style="WIDTH: 85px; HEIGHT: 40px">型号</td>
          <td style="WIDTH: 248px; HEIGHT: 40px"><asp:TextBox ID="TextBox4" runat="server" Height="18px" Width="122px"></asp:TextBox></td>
        </tr>
        <tr>
          <td style="WIDTH: 85px; HEIGHT: 40px">规格</td>
          <td style="WIDTH: 248px; HEIGHT: 40px"><asp:TextBox ID="TextBox5" runat="server" Height="18px" Width="122px"></asp:TextBox></td>
        </tr>
        <tr>
          <td style="WIDTH: 85px; HEIGHT: 40px">备注</td>
          <td style="WIDTH: 248px; HEIGHT: 40px"><asp:TextBox ID="TextBox6" runat="server" Height="18px" Width="122px"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="auto-style1" colspan="2"><asp:Label ID="Label5" runat="server" ForeColor="Green" Width="379px"></asp:Label></td>
        </tr>
      </table>
      <asp:Button ID="Button1" runat="server" Height="24px" onclick="Button1_Click" Text="修改" Width="66px" />
      <asp:Button ID="Button2" runat="server" Height="24px" onclick="Button2_Click" Text="删除" Width="66px" />
      <asp:Button ID="Button3" runat="server" Height="24px" onclick="Button3_Click" Text="添加" Width="66px" />
      &nbsp;
    </fieldset>
    <br />
    <hr color="#cc0066" align="center" width="75%" size ="20">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="C_id">
      <Columns>
      <asp:BoundField DataField="C_id" HeaderText="耗材编号" ReadOnly="True" SortExpression="C_id" />
      <asp:BoundField DataField="C_name" HeaderText="耗材名称" SortExpression="C_name" />
      <asp:BoundField DataField="C_brand" HeaderText="品牌" SortExpression="C_brand" />
      <asp:BoundField DataField="T_name" HeaderText="所属类别" SortExpression="T_name" />
      <asp:BoundField DataField="C_model" HeaderText="型号" SortExpression="C_model" />
      <asp:BoundField DataField="C_standard" HeaderText="规格" SortExpression="C_standard" />
      <asp:BoundField DataField="C_remarks" HeaderText="备注" SortExpression="C_remarks" />
      </Columns>
    </asp:GridView>
  </div>
</form>
</form>
</span>
</div>
</div>
</body>
</html>
