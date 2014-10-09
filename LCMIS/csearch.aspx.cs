using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class csearch : System.Web.UI.Page
{
    libCls csrh = new libCls();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == "" || Session["uid"] == null)
            //Session.Abandon();
            Response.Write("<script>window.location.href='log.aspx'</script>"); 
        csrh.conn();
        TextBox1.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + Button1.UniqueID + "').click();return false;}} else {return true}; ");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "请输入你要检索的关键词")
        {
            Response.Write("<script>alert('请输入关键字!')</script>");
        }
        else
        {
            Boolean a;
            string kwd = TextBox1.Text;
            Label1.Text = "“" + kwd + "” 的查询结果是：";
            a=csrh.search(TextBox1.Text);
            if(a==true)
            {
                GridView1.DataSource = csrh.ds;
                GridView1.DataBind();
                Label2.Text = "";
            }
            
            else 
            {
                Label2.Text = "啥也没查到，呵呵。。。";
                GridView1.DataSource = csrh.ds;
                GridView1.DataBind();
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>window.location.href='log.aspx'</script>"); 
    }
}