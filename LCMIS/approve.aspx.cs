using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class approve : System.Web.UI.Page
{
    libCls aprobj = new libCls();
    string[] ainfo = new string[6];
    public void opendb()
    {
        aprobj.opendbapp();
        DropDownList1.DataSource = aprobj.ds;
        DropDownList1.DataTextField = aprobj.df;
        DropDownList1.DataBind();
        GridView1.DataSource = aprobj.ds;
        GridView1.DataBind();

        //以下代码将数据集(DataSet)中有关信息填入文本框
        Label1.Text = aprobj.cid;
        Label2.Text = aprobj.cname;
        Label3.Text = aprobj.uname;
        Label4.Text = aprobj.adate;
        Label5.Text = aprobj.anbr;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == "" || Session["uid"] == null)
            //Session.Abandon();
            Response.Write("<script>window.location.href='log.aspx'</script>"); 
        try
        {

            aprobj.conn();
            if (Page.IsPostBack == false)  //页面初次加载
                opendb();
        }
        catch
        {
            //获取错误消息
            System.ExecutionEngineException ex = new System.ExecutionEngineException();
            Label6.Text = "出错:" + ex.Message.ToString();
        }
    }
    //批准采购
    protected void Button1_Click(object sender, EventArgs e)
    {
        //批准并生成采购单
        aprobj.apr(Convert.ToInt32(DropDownList1.SelectedItem.Text), Convert.ToInt32(Label5.Text),Label1.Text);
        Label6.Text = "该申请已批准！";
        opendb();//刷新
    }
    //拒绝
    protected void Button2_Click(object sender, EventArgs e)
    {
        //拒绝（reject）
        aprobj.rjt(Convert.ToInt32(DropDownList1.SelectedItem.Text));
        Label6.Text = "该申请已拒绝！";
        opendb();//刷新
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int i;
            i = Convert.ToInt32(DropDownList1.SelectedItem.Text);
            ainfo = aprobj.sela(Convert.ToInt16(DropDownList1.SelectedItem.Text));
            Label1.Text = ainfo[1];
            Label2.Text = ainfo[2];
            Label3.Text = ainfo[3];
            Label4.Text = ainfo[4];
            Label5.Text = ainfo[5];

            Label6.Text = "";
        }
        catch
        {
            //获取错误消息
            System.ExecutionEngineException ex = new System.ExecutionEngineException();
            Label6.Text = "出错:" + ex.Message.ToString();
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>window.location.href='log.aspx'</script>"); 
    }
}