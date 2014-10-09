<%@ Page Language="C#" AutoEventWireup="true" CodeFile="log.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <LINK rel=icon type=image/x-icon 
href="image/1.ico">
    <style type="text/css">
body {
	background-color: #FFF;
}
.auto-style2 {
	height: 23px;
}
.auto-style3 {
	height: 23px;
	width: 230px;
	text-align: center;
 bgcolor="#9ddfff";
	background-color: #3194D2;
}
#form1 {
}
.log {
	background-color: #3194D2;
	font-size: 36px;
	font-family: "微软雅黑"
}
.table {
	position: absolute;
	left: 100px;
}
.auto-style4 {
	width: 219px;
}
</style>
    <script type="text/javascript" src="js/jquery-1.5.1.js"></script>
    </head>
    <body class="auto-style2">
<div align="center">
      <h2 class="log" style="color: #FFFFFF" >用户登录</h2>
    </div>
<iframe allowtransparency="true" frameborder="0" width="640" height="360" scrolling="no" src="/video/video.html"></iframe>
<form id="form1" runat="server">
      <div>
    <table style="width: 31%; position:absolute; left:680px;top:134px" align="center">
          <tr>
        <td bgcolor="#CCCCCC"><iframe allowtransparency="true" frameborder="0" width="140" height="278" scrolling="no" src="http://tianqi.2345.com/plugin/widget/index.htm?s=2&z=3&t=1&v=1&d=3&k=&f=1&q=1&e=1&a=1&c=53614&w=140&h=278"></iframe></td>
        <td class="auto-style3" ><table>
            <tr>
              <td width="90" ><div align="right" style="width: 85px">用户ID：</div></td>
              <td class="auto-style4"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
              <td><div align="right">密码：</div></td>
              <td class="auto-style4"><asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
              <td colspan="2"><asp:Label ID="Label1" runat="server" Font-Size="Large"></asp:Label></td>
            </tr>
            <tr>
              <td align="right"><asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" /></td>
              <td align="center" class="auto-style4"><asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click"/>
                &nbsp;
                <asp:Button ID="Button3" runat="server" Text="注册" OnClick="Button3_Click" /></td>
            </tr>
          </table></td>
      </tr>
        </table>
  </div>
    </form>
</body>
</html>
