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
    public partial class course
    {
        public course()
        { }
        //是否存在该记录
        public void Exists(string course_id, out bool Result)
        {
            bool result;
            string sql = "select * from course where (course_id=@course_id)";
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
        //添加课程
        public bool Add(OnlineAcademicSystem.Model.course model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into course(course_id,classroom_id,course_type_id,major_id,course_name,course_time,grade_id) values(@course_id,@classroom_id,@course_type_id,@major_id,@course_name,@course_time,@grade_id)", conn))
            {
                cmd.Parameters.AddWithValue("@course_id", model.course_id);
                cmd.Parameters.AddWithValue("@classroom_id", model.classroom_id);
                cmd.Parameters.AddWithValue("@course_type_id", model.course_type_id);
                cmd.Parameters.AddWithValue("@major_id", model.major_id);
                cmd.Parameters.AddWithValue("@course_name", model.course_name);
                cmd.Parameters.AddWithValue("@course_time", model.course_time);
                cmd.Parameters.AddWithValue("@grade_id", model.grade_id);
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
        //学生查看课表
        public DataTable Query_courselist(string student_id)
        {
            string sql = "SELECT course.course_id, course.course_name, course.course_time, classroom.classroom_name, major.major_name, teacher.teacher_name FROM choose_course INNER JOIN course ON choose_course.course_id = course.course_id INNER JOIN classroom ON course.classroom_id = classroom.classroom_id INNER JOIN major ON course.major_id = major.major_id INNER JOIN teacher_course ON course.course_id = teacher_course.course_id INNER JOIN teacher ON teacher_course.teacher_id = teacher.teacher_id WHERE (choose_course.student_id =@student_id)";
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
        //查询课程
        public DataTable Query_course(string course_id)
        {
            string sql = "SELECT   course.classroom_id, course.course_type_id, course.major_id, course.course_name, course.course_time,  course.grade_id, teacher_course.teacher_id FROM course INNER JOIN teacher_course ON course.course_id = teacher_course.course_id WHERE   (course.course_id = @course_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@course_id", course_id));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable a = ds.Tables[0];
            return a;       
        }
        //更新课程信息
        public void Update_course(OnlineAcademicSystem.Model.course model,string course_id)
        {
            string sql = "UPDATE  course SET   classroom_id = @classroom_id, course_type_id = @course_type_id, major_id = @major_id,  course_name = @course_name, course_time = @course_time, grade_id = @grade_id WHERE   (course_id = @course_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@course_id", course_id));
            cmd.Parameters.Add(new SqlParameter("@classroom_id", model.classroom_id));
            cmd.Parameters.Add(new SqlParameter("@course_type_id", model.course_type_id));
            cmd.Parameters.Add(new SqlParameter("@major_id", model.major_id));
            cmd.Parameters.Add(new SqlParameter("@course_name", model.course_name));
            cmd.Parameters.Add(new SqlParameter("@course_time", model.course_time));
            cmd.Parameters.Add(new SqlParameter("@grade_id", model.grade_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //删除课程
        public void Delete_course(string course_id)
        {
            string sql = "delete from course where course_id=@course_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@course_id", course_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //获取当前最大ID
        public string GetMaxID()
        {
            string sql = "SELECT TOP 1 [course_id],[classroom_id],[course_type_id],[major_id],[course_name],[course_time],[grade_id] FROM [OnlineAcademic].[dbo].[course] order by course_id desc";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            int ID = Convert.ToInt32(a.Rows[0]["course_id"]) + 1;
            return ID.ToString();
        }
    }
}
