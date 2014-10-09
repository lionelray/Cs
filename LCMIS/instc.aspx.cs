using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class instc : System.Web.UI.Page
{
    libCls cInsobj = new libCls();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == "" || Session["uid"] == null)
            //Session.Abandon();
            Response.Write("<script>window.location.href='log.aspx'</script>"); 
        try
        {
            cInsobj.conn();
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

        }
    }
    public void opendb()
    {
        cInsobj.opendbint();
        DropDownList1.DataSource = cInsobj.dstype;
        DropDownList1.DataTextField = cInsobj.dftype;
        DropDownList1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            cInsobj.cid = TextBox1.Text;
            cInsobj.cname = TextBox2.Text;
            cInsobj.cbrand = TextBox3.Text;

            cInsobj.type = DropDownList1.Text;
            cInsobj.cmodel = TextBox5.Text;
            cInsobj.cstd = TextBox6.Text;
            cInsobj.crmk = TextBox7.Text;
            cInsobj.instc();
            TextBox1.Text = "";
            TextBox2.Text = "";
            //DropDownList1.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            Label5.Text = "耗材信息添加成功！";
        }
        catch
        {
            Label5.Text = "录入信息有误！";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("C_info.aspx");
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox4.Text == "")
            {
                Label5.Text = "类别信息不能为空！";
            }
            else
            {
                cInsobj.type = TextBox4.Text;
                cInsobj.instt();
                Label5.Text = "类别信息添加成功！";
                opendb();
            }
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