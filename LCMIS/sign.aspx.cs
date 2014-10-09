using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sign : System.Web.UI.Page
{
    libCls logobj = new libCls();
    protected void Page_Load(object sender, EventArgs e)
    {
        logobj.conn();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox1.Text == null)
        {
            Label1.Text = "用户ID不能为空!";
        }
        else if (TextBox2.Text == "" || TextBox2.Text == null)
        {
            Label1.Text = "用户名不能为空！";
        }
        else if (TextBox3.Text == "" || TextBox3.Text == null)
        {
            Label1.Text = "密码不能为空！";
        }
        else if (TextBox3.Text != TextBox4.Text)
        {
            Label1.Text = "密码不一致！";
        }
        else if (logobj.checkuid(TextBox1.Text) == true)
        {
            Label1.Text = "该用户ID已经存在！";
        }
        else if (Session["AuthCode"].ToString() == TextBox5.Text.Trim().ToUpper())
        {
            logobj.sign(TextBox1.Text, TextBox2.Text, TextBox3.Text);
            Label1.Text = "注册成功！3秒后自动登陆。";
            Session["uid"] = TextBox1.Text;
            Response.Write("<meta http-equiv=refresh content='3;URL=homepage.aspx'>");
            //Response.Write("<script>alert('验证码输入正确！');</script>");
        }
        else
        {
            Response.Write("<script>alert('验证码输入有误！');</script>");
        }
            
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("log.aspx");
    }
}