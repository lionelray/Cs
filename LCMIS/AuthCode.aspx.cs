using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AuthCode : System.Web.UI.Page
{
    public string checkCode = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ServiceReference1.WebServiceSoapClient c = new ServiceReference1.WebServiceSoapClient();
            byte[] data = c.AuthCode(6, genCode(6));
            Response.ContentType = "image/gif";
            Response.OutputStream.Write(data, 0, data.Length);
        }
        catch { }
    }
    public string genCode(int length)
    {
        char code;
        int number;
        string checkCode = String.Empty;
        Random rd = new Random(DateTime.Now.GetHashCode());
        for (int i = 0; i < length; i++)
        {
            number = rd.Next();
            if (number % 2 == 0)
                code = (char)('0' + (char)(number % 10));
            else
                code = (char)('A' + (char)(number % 26));
            checkCode += code;
        }
        Session["AuthCode"] = checkCode;
        return checkCode;
    }
}