using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    libCls logobj = new libCls(); 
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //登录
    protected void Button1_Click(object sender, EventArgs e)
    {
        logobj.conn();
        int flag = logobj.verifylogin(TextBox1.Text, TextBox2.Text);
        if (flag == 1)
        {
            Session["uid"] = TextBox1.Text;
            Response.Redirect("homepage.aspx");
        }
        else
        {
            Label1.Text = "登录信息不正确!";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox1.Focus();
        }
    }
    //重置
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
    //注册
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("sign.aspx");
    }
}