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
    public partial class grade
    {
        public grade()
        { }
        //是否存在该记录
        public void Exists(string grade_id, out bool Result)
        {
            bool result;
            string sql = "select * from grade where (grade_id=@grade_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@grade_id", grade_id));
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
        //添加年级
        public bool Add(OnlineAcademicSystem.Model.grade model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into grade(grade_id,grade_name) values(@grade_id,@grade_name)", conn))
            {
                cmd.Parameters.AddWithValue("@grade_id", model.grade_id);
                cmd.Parameters.AddWithValue("@grade_name", model.grade_name);
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
        //删除年级
        public void Delete(string grade_id)
        {
            string sql = "delete from grade where grade_id=@grade_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@grade_id", grade_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //查询年级和学生是否关联
        public void Query_grade_student(string grade_id, out bool Result)
        {
            bool result;
            string sql = "select *from student where(grade_id=@grade_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@grade_id", grade_id));
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
        //查询年级和课程是否关联
        public void Query_grade_course(string grade_id, out bool Result)
        {
            bool result;
            string sql = "select *from course where(grade_id=@grade_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@grade_id", grade_id));
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
        //查询年级和班级是否关联
        public void Query_grade_classes(string grade_id, out bool Result)
        {
            bool result;
            string sql = "select *from classes where(grade_id=@grade_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@grade_id", grade_id));
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
            string sql = "SELECT TOP 1 [grade_id],[grade_name] FROM [OnlineAcademic].[dbo].[grade] order by grade_id desc";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            int ID = Convert.ToInt32(a.Rows[0]["grade_id"]) + 1;
            return ID.ToString();
        }
    }
}
