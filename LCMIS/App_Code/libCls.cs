using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// libCls 的摘要说明
/// </summary>
public class libCls
{
    //定义ADO.net对象    
    OleDbConnection libcon = new OleDbConnection();
    OleDbDataAdapter libadpt = new OleDbDataAdapter();
    DataSet libds = new DataSet();
    string[] cinfo = new string[7];//存储返回的单条记录

    //string type;//存储类别信息
    string selstr, updstr;   //存储SQL命令
    public object ds;
    public string df;
    public object dstype;
    public string dftype;
    //属性
    public string cid { get; set; }
    public string cname { get; set; }
    public string cbrand { get; set; }
    public string cmodel { get; set; }
    public string cstd { get; set; }
    public string crmk { get; set; }
    public string type { get; set; }
    public string uname { get; set; }

    public string adate { get; set; }

    public string anbr { get; set; }

    public string aid { get; set; }
    public string ukey { get; set; }

    public string urmk { get; set; }

    public string iname { get; set; }
    public string uid { get; set; }

    public string iid { get; set; }
    
    public List<string> tname = new List<string>();
    //tname[0] = "";
    //连接服务器、数据库
    //public void conn(string srvname, string idf, string pwd, string dbname)
    //{
    //    mycon.ConnectionString = "Provider=SQLNCLI.1;Data Source=" + srvname + ";User ID=" + idf + ";Password=" + pwd + ";Initial Catalog=" + dbname;
    //}
    //数据库连接
    public void conn()
    { libcon.ConnectionString = "Provider=SQLOLEDB;Data Source=localhost ;User ID=sa;Password=123;Initial Catalog=LCMIS";
    }
    //验证登录
    public int verifylogin(string uname, string pword)
    {
        string verystr = "select * from [dbo].[User] where U_id='" + uname + "' and U_key='" + pword + "'";
        libadpt.SelectCommand = new OleDbCommand(verystr, libcon);
        libadpt.Fill(libds);
        if (libds.Tables[0].Rows.Count != 0)
            return 1;   //登录成功
        else
            return 0;   //登录失败
    }

    //数据初始化
    public string[] init()
    {
        selstr = "select top 1 * from stu";
        libadpt.SelectCommand = new OleDbCommand(selstr, libcon);
        libadpt.Fill(libds);
        for (int i = 0; i < 4; i++)
        {
            cinfo[i] = libds.Tables[0].Rows[0].ItemArray.GetValue(i).ToString();
        }
        return cinfo;
    }
    public libCls()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    //查询申请信息
    public void opendbapp()
    {
        libadpt.SelectCommand = new OleDbCommand();
        libadpt.SelectCommand.Connection = libcon;
        libadpt.SelectCommand.CommandText = "SELECT dbo.ConsumableApply.A_id,dbo.ConsumableApply.C_id,dbo.Consumable.C_name,dbo.[User].U_name,dbo.ConsumableApply.A_date,dbo.ConsumableApply.A_number FROM dbo.ConsumableApply INNER JOIN dbo.Consumable ON dbo.ConsumableApply.C_id = dbo.Consumable.C_id INNER JOIN dbo.[User] ON dbo.ConsumableApply.U_id = dbo.[User].U_id WHERE dbo.ConsumableApply.A_mark = 0";
        libadpt.Fill(libds);
        ds = libds.Tables[0];
        df = "A_id";

        //以下代码将数据集(DataSet)中有关信息填入文本框
        //aid = libds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
        cid = libds.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
        cname = libds.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
        uname = libds.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();
        adate = libds.Tables[0].Rows[0].ItemArray.GetValue(4).ToString();
        anbr = libds.Tables[0].Rows[0].ItemArray.GetValue(5).ToString();
    }
    //查询耗材信息ALL
    public void opendbini()
    {
        libadpt.SelectCommand = new OleDbCommand();
        libadpt.SelectCommand.Connection = libcon;
        libadpt.SelectCommand.CommandText = "select * from [dbo].[Consumable]";
        libadpt.Fill(libds);
        ds = libds.Tables[0];
        df = "C_id";
        
        //以下代码将数据集(DataSet)中有关信息填入文本框
        cname = libds.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
        cbrand = libds.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
        type = libds.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();
        cmodel = libds.Tables[0].Rows[0].ItemArray.GetValue(4).ToString();
        cstd = libds.Tables[0].Rows[0].ItemArray.GetValue(5).ToString();
        crmk = libds.Tables[0].Rows[0].ItemArray.GetValue(6).ToString();
    }
    //查询耗材信息top1
    public string[] selc(string cid)
    {
        selstr = "select top 1 * from Consumable where C_id='" + cid + "'";
        libadpt.SelectCommand = new OleDbCommand(selstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
        for (int i = 0; i < 7; i++)
        {
            cinfo[i] = libds.Tables[0].Rows[0].ItemArray.GetValue(i).ToString();
        }
        return cinfo;
    }
    //更新耗材信息
    public void updc(string cid)
    {
        updstr = "update Consumable set C_name='" + cname + "',C_brand='" + cbrand + "',T_name='" + type + "',C_model='" + cmodel + "',C_standard='" + cstd + "',C_remarks='" + crmk + "' where C_id='" + cid + "'";
        libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
    }
    //删除耗材信息
    public void delc(string cid)
    {
        updstr = "delete from Consumable where C_id='" + cid + "'";
        libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
    }
    //添加耗材信息
    public void instc()
    {
        updstr = "insert into Consumable(C_id,C_name,C_brand,T_name,C_model,C_standard,C_remarks) values('" + cid + "','" + cname + "','" + cbrand + "','" + type + "','" + cmodel + "','" + cstd + "','" + crmk + "')";
        libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
    }
    //添加类别信息
    public void instt()
    {
        updstr = "insert into Type(T_name,unit,limit) values('" + type + "','件',500)";
        libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
    }
    //查询类别名称
    public void opendbint()
    {
        libadpt.SelectCommand = new OleDbCommand();
        libadpt.SelectCommand.Connection = libcon;
        libadpt.SelectCommand.CommandText = "select * from [dbo].[Type]";
        libadpt.Fill(libds);
        dstype = libds.Tables[0];
        dftype = "T_name";
    }
    //注册用户
    public void sign(string id, string name, string pwd)
    {
        libadpt.SelectCommand = new OleDbCommand();
        libadpt.SelectCommand.Connection = libcon;
        libadpt.SelectCommand.CommandText = "insert into [User](U_id,U_name,U_key) VALUES('"+id+"','"+name+"','"+pwd+"')";
        libadpt.Fill(libds);
    }
    //查询低于库存下限的耗材（类别）
    public List<string> limit()
    {

        selstr = "SELECT T_name FROM limm where count < limit";
        libadpt.SelectCommand = new OleDbCommand(selstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
        int n = libds.Tables[0].Rows.Count;
        for (int i = 0; i < n; i++)
        {
            tname.Add(libds.Tables[0].Rows[i][0].ToString());
        }
        return tname;
    }
    //申请耗材
    public void apply(string cid, string uid, int n)
    {
        libadpt.SelectCommand = new OleDbCommand();
        libadpt.SelectCommand.Connection = libcon;
        libadpt.SelectCommand.CommandText = "SELECT count(A_id) FROM ConsumableApply";
        libadpt.Fill(libds);
        int i;
        i = Convert.ToInt16(libds.Tables[0].Rows[0].ItemArray.GetValue(0)) + 1;

        selstr = "insert into ConsumableApply(A_id,A_date,U_id,C_id,A_number) values(" + i + ",'" + DateTime.Now.ToString() + "','" + uid + "','" + cid + "'," + n + ")";
        libadpt.SelectCommand = new OleDbCommand(selstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
    }

    //查询申请信息
    public string[] sela(int aid)
    {
        selstr = "SELECT dbo.ConsumableApply.A_id,dbo.ConsumableApply.C_id,dbo.Consumable.C_name,dbo.[User].U_name,dbo.ConsumableApply.A_date,dbo.ConsumableApply.A_number FROM dbo.ConsumableApply INNER JOIN dbo.Consumable ON dbo.ConsumableApply.C_id = dbo.Consumable.C_id INNER JOIN dbo.[User] ON dbo.ConsumableApply.U_id = dbo.[User].U_id WHERE dbo.ConsumableApply.A_id = "+ aid +" and dbo.ConsumableApply.A_mark = 0";
        libadpt.SelectCommand = new OleDbCommand(selstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
        for (int i = 0; i < 6; i++)
        {
            cinfo[i] = libds.Tables[0].Rows[0].ItemArray.GetValue(i).ToString();
        }
        return cinfo;
    }

    public void opendbapr()
    {
        throw new NotImplementedException();
    }
    //批准申请
    public void apr(int aid,int n,string cid)
    {
        updstr = "update ConsumableApply set A_mark = 1 where A_id=" + aid + "";//标记为已批准
        libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
        libadpt.SelectCommand.CommandText = "SELECT top 1 S_sn FROM Stock ORDER BY S_sn DESC";
        libds.Clear();
        libadpt.Fill(libds);
        //生成库存
        string sn = libds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
        for(int i = 1; i<= n; i++)
        {
            int num = Convert.ToInt32(sn.Substring(0));
            num ++ ;
            sn = num.ToString().PadLeft(4, '0');
            libadpt.SelectCommand.CommandText = "insert into Stock(S_sn,C_id) values('" + sn + "','" + cid + "')";
            libds.Clear();
            libadpt.Fill(libds);
        }
    }
    //拒绝申请
    public void rjt(int aid)
    {
        updstr = "update ConsumableApply set A_mark = null where A_id=" + aid + "";
        libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
    }
    //查询用户信息
    public void opendbusr()
    {
        libadpt.SelectCommand = new OleDbCommand();
        libadpt.SelectCommand.Connection = libcon;
        libadpt.SelectCommand.CommandText = "SELECT dbo.[User].U_id,dbo.[User].U_name,dbo.[IDentity].I_name,dbo.[User].U_remarks,dbo.[User].U_key FROM dbo.[User] INNER JOIN dbo.[IDentity] ON dbo.[User].I_id = dbo.[IDentity].I_id";
        libadpt.Fill(libds);
        ds = libds.Tables[0];
        df = "U_id";

        //以下代码将数据集(DataSet)中有关信息填入文本框
        uname = libds.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
        iname = libds.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
        urmk = libds.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();
        ukey = libds.Tables[0].Rows[0].ItemArray.GetValue(4).ToString();
    }

    //查询用户信息top1
    public string[] selu(string uid)
    {
        selstr = "select top 1 dbo.[User].U_id,dbo.[User].U_name,dbo.[User].U_key,dbo.[IDentity].I_name,dbo.[User].U_remarks FROM dbo.[User] INNER JOIN dbo.[IDentity] ON dbo.[User].I_id = dbo.[IDentity].I_id where dbo.[User].U_id = '" + uid + "'";
        libadpt.SelectCommand = new OleDbCommand(selstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
        for (int i = 0; i < 5; i++)
        {
            cinfo[i] = libds.Tables[0].Rows[0].ItemArray.GetValue(i).ToString();
        }
        return cinfo;
    }
    //更新用户信息
    public void updu(string uid, int iid)
    {
        updstr = "update dbo.[User] set U_name='" + uname + "',U_key='" + ukey + "',I_id=" + iid + ",U_remarks='" + urmk + "' where U_id = '" + uid + "'";
        libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
    }
    //删除用户信息
    public void delu(string uid)
    {
        updstr = "delete from dbo.[User] where U_id='" + uid + "'";
        libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
    }
    //新增用户
    public void instu()
    {
        updstr = "insert into dbo.[User](U_id,U_name,U_key,I_id,U_remarks) values('" + uid + "','" + uname + "','" + ukey + "','" + iid + "','" + urmk + "')";
        libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
    }
    //查询耗材页面
    public Boolean search(string p)
    {
        Boolean a = true;
        selstr = "SELECT * FROM Consumable WHERE C_id LIKE '%" + p + "%' OR C_name LIKE '%" + p + "%' OR C_brand LIKE '%" + p + "%' OR T_name LIKE '%" + p + "%' OR C_model LIKE '%" + p + "%' OR C_standard LIKE '%" + p + "%' OR C_remarks LIKE '%" + p + "%'";
        libadpt.SelectCommand = new OleDbCommand(selstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);
        
        ds = libds.Tables[0];
        df = "C_id";
       //判断查询结果是否为空 
        if (libds.Tables[0].Rows.Count==0)
        {
            a = false;
        }
        return a;
    }
    //出库
    public void outstk(string ssn1, string ssn2)
    {
        string sn = ssn1;
        int num = Convert.ToInt32(sn.Substring(0));
        int i = Convert.ToInt32(ssn2.Substring(0));
        while (num<=i)
        {
            sn = num.ToString().PadLeft(4, '0');

            updstr = "update Stock set S_mark = 1,S_outtime = GetDate() where S_sn = '" + sn + "'";//标记为已出库
            libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
            libds.Clear();
            libadpt.Fill(libds);
            num++;
        }
    }
    //查看当前用户信息
    public void presusr(string uid)
    {
        libadpt.SelectCommand = new OleDbCommand();
        libadpt.SelectCommand.Connection = libcon;
        libadpt.SelectCommand.CommandText = "SELECT dbo.[User].U_id,dbo.[User].U_name,dbo.[User].U_key,dbo.[IDentity].I_name,dbo.[User].U_remarks FROM dbo.[User] INNER JOIN dbo.[IDentity] ON dbo.[User].I_id = dbo.[IDentity].I_id WHERE dbo.[User].U_id = '" + uid + "'";
        libadpt.Fill(libds);
        ds = libds.Tables[0];
        df = "U_id";

        //以下代码将数据集(DataSet)中有关信息填入文本框
        uname = libds.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
        ukey = libds.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
        iname = libds.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();
        urmk = libds.Tables[0].Rows[0].ItemArray.GetValue(4).ToString();
    }
    //入库
    public void instk(string ssn1, string ssn2)
    {
        string sn = ssn1;
        int num = Convert.ToInt32(sn.Substring(0));
        int i = Convert.ToInt32(ssn2.Substring(0));
        while (num <= i)
        {
            sn = num.ToString().PadLeft(4, '0');

            updstr = "update Stock set S_mark = 0,S_intime = GetDate() where S_sn = '" + sn + "'";//标记为已入库
            libadpt.SelectCommand = new OleDbCommand(updstr, libcon);
            libds.Clear();
            libadpt.Fill(libds);
            num++;
        }
    }

    public bool ssearch(string p)
    {
        Boolean a = true;
        selstr = "SELECT * FROM allstk WHERE S_sn LIKE '%" + p + "%' OR C_id LIKE '%" + p + "%' OR C_name LIKE '%" + p + "%' OR T_name LIKE '%" + p + "%' OR C_model LIKE '%" + p + "%' OR S_mark LIKE '%" + p + "%' OR S_intime LIKE '%" + p + "%' OR S_outtime LIKE '%" + p + "%'";
        libadpt.SelectCommand = new OleDbCommand(selstr, libcon);
        libds.Clear();
        libadpt.Fill(libds);

        ds = libds.Tables[0];
        df = "S_mark";
        if(df =="True" )
        {
            df = "chuku";
        }
        //判断查询结果是否为空 
        if (libds.Tables[0].Rows.Count == 0)
        {
            a = false;
        }
        
        return a;
    }

    public string s_sn { get; set; }
    //验证uid是否存在
    public bool checkuid(string uid)
    {
        string verystr = "select * from [dbo].[User] where U_id='" + uid + "'";
        libadpt.SelectCommand = new OleDbCommand(verystr, libcon);
        libadpt.Fill(libds);
        if (libds.Tables[0].Rows.Count != 0)
            return true;   //登录成功
        else
            return false;   //登录失败
    }
}