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
    public partial class course_type
    {
        public course_type()
        { }
        //是否存在该记录
        public void Exists(string course_type_id, out bool Result)
        {
            bool result;
            string sql = "select * from course_type where (course_type_id=@course_type_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@course_type_id", course_type_id));
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
        //添加课程类型
        public bool Add(OnlineAcademicSystem.Model.course_type model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into course_type(course_type_id,course_type_name) values(@course_type_id,@course_type_name)", conn))
            {
                cmd.Parameters.AddWithValue("@course_type_id", model.course_type_id);
                cmd.Parameters.AddWithValue("@course_type_name", model.course_type_name);
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
        //查询课程类型和课程是否有关联
        public void Query(string course_type_id,out bool Result)
        {
            bool result;
            string sql = "select *from course where course_type_id=@course_type_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@course_type_id", course_type_id));
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
        //删除课程类型
        public void Delete(string course_type_id)
        {
            string sql = "delete from course_type where course_type_id=@course_type_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@course_type_id", course_type_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //获取当前最大ID
        public string GetMaxID()
        {
            string sql = "SELECT TOP 1 [course_type_id],[course_type_name] FROM [OnlineAcademic].[dbo].[course_type] order by [course_type_id] desc";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            int ID = Convert.ToInt32(a.Rows[0]["course_type_id"]) + 1;
            return ID.ToString();
        }
    }
}
