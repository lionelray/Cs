using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class main : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //string uid = Session["uid"].ToString();
        if (Session["uid"] == "" || Session["uid"] == null)
            //Session.Abandon();
        Response.Write("<script>window.location.href='log.aspx'</script>"); 
        //libCls hpobj = new libCls();
        //hpobj.conn();
        //hpobj.limit();
        //int n = hpobj.tname.Count;
        //Response.Write("<p>欢迎进入北方民族大学实验室耗材管理系统！</p><p></p>");
        //Response.Write("<p>系统提醒 ：</p>");
        //for (int i = 1; i <= n; i++)
        //{ 
        //    Response.Write("<p>"+i+"."+hpobj.tname[i-1]+" 库存不足，请及时补充！</p>");
        //}
           
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>window.location.href='log.aspx'</script>");

    }
}