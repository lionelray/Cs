using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class instu : System.Web.UI.Page
{
    libCls uInsobj = new libCls();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == "" || Session["uid"] == null)
            //Session.Abandon();
            Response.Write("<script>window.location.href='log.aspx'</script>"); 
    }
    //添加用户
    protected void Button1_Click(object sender, EventArgs e)
    {
        uInsobj.conn();
        try
        {
            uInsobj.uid = TextBox1.Text;
            uInsobj.uname = TextBox2.Text;
            uInsobj.ukey = TextBox3.Text;
            string iid;
            if (DropDownList3.Text == "管理员")
            {
                iid = "1";
            }
            else if (DropDownList3.Text == "审批用户")
            {
                iid = "2";
            }
            else iid = "3";
            uInsobj.iid = iid;
            uInsobj.urmk = TextBox4.Text;
            uInsobj.instu();
            TextBox1.Text = "";
            TextBox2.Text = "";
            //DropDownList1.Text = "";
            TextBox4.Text = "";
            Label5.Text = "用户信息添加成功！";
        }
        catch
        {
            Label5.Text = "录入信息有误！";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("sys.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>window.location.href='log.aspx'</script>"); 
    }
}