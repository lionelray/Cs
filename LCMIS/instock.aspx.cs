using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class instock : System.Web.UI.Page
{
    libCls instkobj = new libCls();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == "" || Session["uid"] == null)
            //Session.Abandon();
            Response.Write("<script>window.location.href='log.aspx'</script>"); 
        instkobj.conn();
    }
    //确认出库
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text == "")
            TextBox2.Text = TextBox1.Text;
        instkobj.outstk(TextBox1.Text,TextBox2.Text);

        Response.Write("<script>alert('出库操作成功!')</script>");
        //Response.Redirect("instock.aspx");
        //Label1.Text = "出库操作成功!";
    }
    //取消返回
    protected void Button2_Click(object sender, EventArgs e)
    {
        int a = 1;
        a += 1;
    }
    //入库
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text == "")
            TextBox2.Text = TextBox1.Text;
        instkobj.instk(TextBox1.Text, TextBox2.Text);

        
        //Response.Redirect("instock.aspx");
        //Label1.Text = "出库操作成功!";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>window.location.href='log.aspx'</script>"); 
    }
}