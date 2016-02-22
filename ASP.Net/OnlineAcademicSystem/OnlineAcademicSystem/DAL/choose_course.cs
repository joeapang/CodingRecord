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
    public partial class choose_course
    {
        public choose_course()
        { }
        //是否存在该记录
        public void Exists(string student_id, string course_id, out bool Result)
        {
            bool result;
            string sql = "select * from choose_course where student_id=@student_id and course_id=@course_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@student_id", student_id));
            cmd.Parameters.Add(new SqlParameter("@course_id", course_id));
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
        //添加选课
        public bool Add(OnlineAcademicSystem.Model.choose_course model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into choose_course(student_id,course_id) values(@student_id,@course_id)", conn))
            {
                cmd.Parameters.AddWithValue("@student_id", model.student_id);
                cmd.Parameters.AddWithValue("@course_id", model.course_id);
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
        //查询课程
        public DataTable Query(string major_id,string grade_id,string course_type_id)
        {
            string sql = "select * from course where major_id=@major_id and grade_id=@grade_id and course_type_id=@course_type_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@major_id", major_id));
            cmd.Parameters.Add(new SqlParameter("@grade_id", grade_id));
            cmd.Parameters.Add(new SqlParameter("@course_type_id", course_type_id));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable a= ds.Tables[0];
            return a;
        }
        //删除选课
        public void Delete(string student_id,string course_id)
        {
            string sql = "delete from choose_course where student_id=@student_id and course_id=@course_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@student_id", student_id));
            cmd.Parameters.Add(new SqlParameter("@course_id", course_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }		
        //查询已选课程
        public DataTable Query_Choose(string student_id)
        {
            string sql = "select * from course where course_id in(select course_id from choose_course where student_id=@student_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@student_id", student_id));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable a = ds.Tables[0];
            return a;
        }
        //学生课程是否存在关联
        public void Exists(string student_id, out bool Result)
        {
            bool result;
            string sql = "select * from choose_course where student_id=@student_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@student_id", student_id));
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
        //查询某课程是否被选
        public void Query_choose_course(string course_id,out bool Result)
        {
            bool result;
            string sql = "select * from choose_course where course_id=@course_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@course_id", course_id));
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
    }
}
