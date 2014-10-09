using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class apply : System.Web.UI.Page
{
    libCls appobj = new libCls();
    string[] cinfo = new string[7];
    public void opendb()
    {
        appobj.opendbini();
        DropDownList1.DataSource = appobj.ds;
        DropDownList1.DataTextField = appobj.df;
        DropDownList1.DataBind();
        GridView1.DataSource = appobj.ds;
        GridView1.DataBind();

        //以下代码将数据集(DataSet)中有关信息填入文本框
        Label1.Text = appobj.cname;
        Label2.Text = appobj.cbrand;
        Label3.Text = appobj.type;
        Label4.Text = appobj.cmodel;
        Label5.Text = appobj.cstd;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == "" || Session["uid"] == null)
            //Session.Abandon();
            Response.Write("<script>window.location.href='log.aspx'</script>"); 
        try
        {

            appobj.conn();
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
    //申请耗材
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
            Response.Write("<script>alert('请输入申请数量！')</script>");
        else
        {
            string cid;
            string uid = Session["uid"].ToString();
            int n;
            cid = DropDownList1.Text;
            n = Convert.ToInt32(TextBox1.Text);
            appobj.apply(cid, uid, n);
            Label6.Text = "申请成功！";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            cinfo = appobj.selc(DropDownList1.SelectedItem.Text);
            Label1.Text = cinfo[1];
            Label2.Text = cinfo[2];
            Label3.Text = cinfo[3];
            Label4.Text = cinfo[4];
            Label5.Text = cinfo[5];
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>window.location.href='log.aspx'</script>"); 
    }
}