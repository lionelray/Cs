using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class C_info : System.Web.UI.Page
{
    libCls cobj = new libCls();
    string[] cinfo = new string[7];  //接收返回的单条记录
    //数据库初始化 
    public void opendb()
    {
        cobj.opendbini();
        DropDownList1.DataSource = cobj.ds;
        DropDownList1.DataTextField = cobj.df;
        DropDownList1.DataBind();
        GridView1.DataSource = cobj.ds;
        GridView1.DataBind();
        
        //以下代码将数据集(DataSet)中有关信息填入文本框
        TextBox1.Text = cobj.cname;
        TextBox2.Text = cobj.cbrand;
        cobj.opendbint();
        DropDownList3.DataSource = cobj.dstype;
        DropDownList3.DataTextField = cobj.dftype;
        DropDownList3.DataBind();
        DropDownList3.Text = cobj.type;
        TextBox4.Text = cobj.cmodel;
        TextBox5.Text = cobj.cstd;
        TextBox6.Text = cobj.crmk;
        
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == "" || Session["uid"] == null)
            //Session.Abandon();
            Response.Write("<script>window.location.href='log.aspx'</script>"); 
        try
        {

            cobj.conn();
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
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }
    }
    //修改耗材信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            cobj.cname = TextBox1.Text;
            cobj.cbrand = TextBox2.Text;
            cobj.type =  DropDownList3.Text;
            cobj.cmodel = TextBox4.Text;
            cobj.cstd = TextBox5.Text;
            cobj.crmk = TextBox6.Text;
            cobj.updc(DropDownList1.Text);
            Label5.Text = "耗材信息更新成功！";
            // GridView1刷新显示
            cobj.opendbini();
            GridView1.DataSource = cobj.ds;
            GridView1.DataBind();
        }
        catch
        {
            Label5.Text = "录入信息有误！";
        }
    }
    
    //删除耗材信息
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            cobj.delc(DropDownList1.Text);
            Label5.Text = "耗材信息删除成功！";
            //刷新显示
            opendb();
        }
        catch
        {
            Label5.Text = "该耗材信息不能被删除！";
        }
    }
    //跳转至添加页面
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("instc.aspx");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            cinfo = cobj.selc(DropDownList1.SelectedItem.Text);
            TextBox1.Text = cinfo[1];
            TextBox2.Text = cinfo[2];
            DropDownList3.Text=cinfo[3];
            TextBox4.Text = cinfo[4];
            TextBox5.Text = cinfo[5];
            TextBox6.Text = cinfo[6];
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
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }
    }
    //添加类别
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox3.Text == "")
            {
                Label5.Text = "类别信息不能为空！";
            }
            else
            {
                cobj.type = TextBox3.Text;
                cobj.instt();
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