using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user : System.Web.UI.Page
{
    libCls usrobj = new libCls();
    string[] uinfo = new string[5];  //接收返回的单条记录
    public void opendb()
    {
        usrobj.presusr(Session["uid"].ToString());
        //以下代码将数据集(DataSet)中有关信息填入文本框
        Label6.Text = Session["uid"].ToString();
        TextBox1.Text = usrobj.uname;
        TextBox2.Text = usrobj.ukey;
        TextBox3.Text = usrobj.urmk;
        DropDownList3.Text = usrobj.iname;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {

            usrobj.conn();
            if (Page.IsPostBack == false)  //页面初次加载
                opendb();
        }
        catch
        {
            //获取错误消息
            System.ExecutionEngineException ex = new System.ExecutionEngineException();
            Label5.Text = "出错:" + ex.Message.ToString();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

    }
    //取消返回
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    Request.UrlReferrer.ToString();
    //    Response.Redirect("Request.UrlReferrer.ToString()");
    //}
    //修改用户信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            usrobj.uname = TextBox1.Text;
            usrobj.ukey = TextBox2.Text;
            usrobj.iname = DropDownList3.Text;
            usrobj.urmk = TextBox3.Text;
            int iid;
            if (DropDownList3.Text == "管理员")
            {
                iid = 1;
            }
            else if (DropDownList3.Text == "审批用户")
            {
                iid = 2;
            }
            else iid = 3;
            usrobj.updu(Label6.Text, iid);
            Label5.Text = "用户信息更新成功！";
        }
        catch
        {
            Label5.Text = "录入信息有误！";
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>window.location.href='log.aspx'</script>"); 
    }
}