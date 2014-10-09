using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public byte[] AuthCode(int length, string checkCode)
    {
        int bmpHeight = 25, bmpWidth = length * 14 + 10;
        Bitmap bmp = new Bitmap(bmpWidth, bmpHeight);
        int red, blue, green;
        Random rd = new Random(DateTime.Now.GetHashCode());
        red = rd.Next(255) % 128 + 128;
        blue = rd.Next(255) % 128 + 128;
        green = rd.Next(255) % 128 + 128;
        Graphics g = Graphics.FromImage(bmp);
        Brush brush = new SolidBrush(Color.Beige);
        g.FillRectangle(brush, 0, 0, bmpWidth, bmpHeight);
        //画图片的前景噪音点
        for (int i = 0; i < 30; i++)
        {
            int x = rd.Next(bmpWidth);
            int y = rd.Next(bmpHeight);
            bmp.SetPixel(x, y, Color.FromArgb(rd.Next()));
        }
        //画图片的边框线
        g.DrawRectangle(new Pen(Color.Silver), 0, 0, bmpWidth - 1, bmpHeight - 1);
        //添加背景噪音线
        for (int i = 0; i < 25; i++)
        {
            int x1 = rd.Next(bmpWidth);
            int x2 = rd.Next(bmpWidth);
            int y1 = rd.Next(bmpHeight);
            int y2 = rd.Next(bmpHeight);
            g.DrawLine(new Pen(Color.FromArgb(rd.Next())), x1, y1, x2, y2);
        }
        Rectangle rect = new Rectangle(0, 0, bmpWidth, bmpHeight);
        LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.Crimson, Color.DarkRed, 1.2f, true);
        for (int i = 0; i < length; i++)
        {//绘制每个字符
            Font font = new Font("Courier New", 14 + rd.Next() % 4, (FontStyle.Bold | FontStyle.Italic));
            g.DrawString(checkCode.Substring(i, 1), font, lgb, 2 + i * 14, 2 + rd.Next(2));
        }
        MemoryStream stream = new MemoryStream();
        bmp.Save(stream, ImageFormat.Gif);
        bmp.Dispose();
        g.Dispose();
        byte[] ret = stream.ToArray();//输出字节流
        stream.Close();
        return ret;
    }

}
