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
    public partial class major
    {
        public major()
        { }
        //是否存在该记录
        public void Exists(string major_id, out bool Result)
        {
            bool result;
            string sql = "select * from major where (major_id=@major_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@major_id", major_id));
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
        //添加专业
        public bool Add(OnlineAcademicSystem.Model.major model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into major(major_id,major_name) values(@major_id,@major_name)", conn))
            {
                cmd.Parameters.AddWithValue("@major_id", model.major_id);
                cmd.Parameters.AddWithValue("@major_name", model.major_name);
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
        //查询专业和班级是否有关联
        public void Query_major_classes(string major_id,out bool Result)
        {
            bool result;
            string sql = "select *from classes where major_id=@major_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@major_id", major_id));
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
        //查询专业和课程是否有关联
        public void Query_major_course(string major_id, out bool Result)
        {
            bool result;
            string sql = "select *from course where major_id=@major_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@major_id", major_id));
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
        //查询专业和老师是否有关联
        public void Query_major_teacher(string major_id, out bool Result)
        {
            bool result;
            string sql = "select *from teacher where major_id=@major_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@major_id", major_id));
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
        //查询专业和学生是否有关联
        public void Query_major_student(string major_id, out bool Result)
        {
            bool result;
            string sql = "select *from student where major_id=@major_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@major_id", major_id));
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
        //删除专业
        public void Delete(string major_id)
        {
            string sql = "delete from major where major_id=@major_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@major_id", major_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //获取当前最大ID
        public string GetMaxID()
        {
            string sql = "SELECT TOP 1 [major_id],[major_name] FROM [OnlineAcademic].[dbo].[major] order by major_id desc";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            int ID = Convert.ToInt32(a.Rows[0]["major_id"]) + 1;
            return ID.ToString();
        }
    }
}
