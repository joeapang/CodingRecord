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
    public partial class classroom
    {
        public classroom()
        { }
        //是否存在该记录
        public void Exists(string classroom_id, out bool Result)
        {
            bool result;
            string sql = "select * from classroom where (classroom_id=@classroom_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@classroom_id", classroom_id));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Result = result;
            conn.Close();
        }
        //添加教室
        public bool Add(OnlineAcademicSystem.Model.classroom model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into classroom(classroom_id,classroom_name) values(@classroom_id,@classroom_name)", conn))
            {
                cmd.Parameters.AddWithValue("@classroom_id", model.classroom_id);
                cmd.Parameters.AddWithValue("@classroom_name", model.classroom_name);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //删除教室
        public void Delete(string classroom_id)
        {
            string sql = "delete from classroom where classroom_id=@classroom_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@classroom_id", classroom_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //查询该教室是否被关联
        public void Query_classroom(string classroom_id,out bool Result)
        {
            bool result;
            string sql = "select *from course where classroom_id=@classroom_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@classroom_id", classroom_id));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Result = result;
            conn.Close();
        }
        //获取当前最大ID
        public string GetMaxID()
        {
            string sql = "SELECT TOP 1 [classroom_id],[classroom_name] FROM [OnlineAcademic].[dbo].[classroom] order by classroom_id desc";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            int ID = Convert.ToInt32(a.Rows[0]["classroom_id"])+1;
            return ID.ToString();
        }
    }
}
