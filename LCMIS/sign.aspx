<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sign.aspx.cs" Inherits="sign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
     <head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title></title>
     <LINK rel=icon type=image/x-icon 
href="image/1.ico">
     <style type="text/css">
body {
	background-color: #FFFFFF;
}
.auto-style1 {
	height: 23px;
}
.log {
	text-align: center;
	background-color: #3194D2;
	font-size: 36px;
	font-family: "微软雅黑"
}
.sign {
	background-color: #09F;
}
</style>
     <script type="text/javascript" src="js/jquery-1.5.1.js"></script>
     </head>
     <body>
<h2 class="log" style="color: #FFFFFF" >用户注册</h2>
<form id="form1" runat="server">
       <table align="center" frame="void" bgcolor="#3194D2">
    <tr>
           <td bgcolor="#cccccc" width="132" rowspan="7" align="right"><iframe allowtransparency="true" frameborder="0" width="140" height="278" scrolling="no" src="http://tianqi.2345.com/plugin/widget/index.htm?s=2&z=3&t=1&v=1&d=3&k=&f=1&q=1&e=1&a=1&c=53614&w=140&h=278"></iframe></td>
           <td width="132" align="right">用户ID：</td>
           <td width="230"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
         </tr>
    <tr>
           <td align="right">用户名：</td>
           <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
         </tr>
    <tr>
           <td align="right">密码：</td>
           <td><asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox></td>
         </tr>
    <tr>
           <td align="right">确认密码：</td>
           <td><asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox></td>
         </tr>
    <tr>
           <td align="right">验证码：</td>
           <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
         </tr>
    <tr>
           <td colspan="2" align="center"><img alt="验证码,看不清楚?请点击刷新验证码" onClick="this.src='AuthCode.aspx?t='+(new Date().getTime());" src="AuthCode.aspx" style="cursor : pointer;" />
        <asp:Label ID="Label1" runat="server" Text="看不清,点击验证码"></asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Size="Large"></asp:Label></td>
         </tr>
    <tr>
           <td colspan="2" align="center"><asp:Button ID="Button1" runat="server" Text="确认注册" OnClick="Button1_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="取消" Width="72px" OnClick="Button2_Click" /></td>
         </tr>
  </table>
     </form>
</body>
</html>
