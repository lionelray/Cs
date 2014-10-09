using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sys : System.Web.UI.Page
{
    libCls sysobj = new libCls();
    string[] uinfo = new string[5];  //接收返回的单条记录
    //数据库初始化 
    public void opendb()
    {
        sysobj.opendbusr();
        DropDownList1.DataSource = sysobj.ds;
        DropDownList1.DataTextField = sysobj.df;
        DropDownList1.DataBind();
        GridView1.DataSource = sysobj.ds;
        GridView1.DataBind();

        //以下代码将数据集(DataSet)中有关信息填入文本框
        TextBox1.Text = sysobj.uname;
        TextBox2.Text = sysobj.ukey;
        TextBox3.Text = sysobj.urmk;
        DropDownList3.Text = sysobj.iname;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == "" || Session["uid"] == null)
            //Session.Abandon();
            Response.Write("<script>window.location.href='log.aspx'</script>"); 
        try
        {

            sysobj.conn();
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
    //修改用户信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            sysobj.uname = TextBox1.Text;
            sysobj.ukey = TextBox2.Text;
            sysobj.iname = DropDownList3.Text;
            sysobj.urmk = TextBox3.Text;
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
            sysobj.updu(DropDownList1.Text,iid);
            Label5.Text = "用户信息更新成功！";
            // GridView1刷新显示
            sysobj.opendbusr();
            GridView1.DataSource = sysobj.ds;
            GridView1.DataBind();
        }
        catch
        {
            Label5.Text = "录入信息有误！";
        }
    }
    //删除用户
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            sysobj.delu(DropDownList1.Text);
            Label5.Text = "用户信息删除成功！";
            //刷新显示
            opendb();
        }
        catch
        {
            Label5.Text = "该用户信息不能被删除！";
        }
    }
    //添加用户
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("instu.aspx");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            uinfo = sysobj.selu(DropDownList1.SelectedItem.Text);
            TextBox1.Text = uinfo[1];
            TextBox2.Text = uinfo[2];
            DropDownList3.Text = uinfo[3];
            TextBox3.Text = uinfo[4];
            Label5.Text = "";
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
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>window.location.href='log.aspx'</script>"); 
    }

    public string[] cinfo { get; set; }
}