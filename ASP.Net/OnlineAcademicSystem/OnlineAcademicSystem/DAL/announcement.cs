using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OnlineAcademicSystem.DAL
{
    public partial class announcement
    {
        public announcement()
        { }
        //是否存在附件
        public DataTable Exsit(int announcement_id)
        {
            string sql = "select *from announcement where announcement_id=@announcement_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@announcement_id", announcement_id));
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            return a;
        }
        //添加公告
        public void Add(OnlineAcademicSystem.Model.announcement model)
        {
            string sql = "INSERT INTO announcement (announcement_id,announcement_content, announcement_title, announcement_attachment,announcement_time) VALUES (@announcement_id,@announcement_content,@announcement_title,@announcement_attachment,@announcement_time)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@announcement_id", model.announcement_id));
            cmd.Parameters.Add(new SqlParameter("@announcement_content", model.announcement_content));
            cmd.Parameters.Add(new SqlParameter("@announcement_title", model.announcement_title));
            cmd.Parameters.Add(new SqlParameter("@announcement_attachment", model.announcement_attachment));
            cmd.Parameters.Add(new SqlParameter("@announcement_time", model.announcement_time));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //查看公告
        public DataTable Query_announcement(string announcement_id)
        {
            string sql = "select *from announcement where announcement_id=@announcement_id ";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@announcement_id", announcement_id));
            DataSet ds=new DataSet();
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            dr.Fill(ds);
            DataTable dt=ds.Tables[0];
            return dt;
        }
        //获取当前最大ID
        public int GetMaxID()
        {
            string sql = "SELECT TOP 1 [announcement_id],[announcement_content],[announcement_title],[announcement_attachment],[announcement_time] FROM [OnlineAcademic].[dbo].[announcement] order by [announcement_id] desc";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            int ID = Convert.ToInt32(a.Rows[0]["announcement_id"]) + 1;
            return ID;
        }
    }
}
