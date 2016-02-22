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
    public partial class teacher_course
    {
        public teacher_course()
        { }
        //添加老师课程
        public bool Add(OnlineAcademicSystem.Model.teacher_course model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into teacher_course(teacher_id,course_id) values(@teacher_id,@course_id)", conn))
            {
                cmd.Parameters.AddWithValue("@teacher_id", model.teacher_id);
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
        //老师查看授课
        public DataTable Query_course(string teacher_id)
        {
            string sql = "SELECT course.course_id, classroom.classroom_name, course_type.course_type_name, major.major_name, course.course_name, course.course_time FROM teacher_course INNER JOIN course ON teacher_course.course_id = course.course_id INNER JOIN classroom ON course.classroom_id = classroom.classroom_id INNER JOIN course_type ON course.course_type_id = course_type.course_type_id INNER JOIN grade ON course.grade_id = grade.grade_id INNER JOIN major ON course.major_id = major.major_id WHERE (teacher_course.teacher_id =@teacher_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_id", teacher_id));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable a = ds.Tables[0];
            return a;
        }

        //老师课程是否存在关联
        public void Exists(string teacher_id,out bool Result)
        {
            bool result;
            string sql = "select * from teacher_course where teacher_id=@teacher_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_id", teacher_id));
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
       //删除更新教师课程关联
        public void Delete(string teacher_id,string course_id)
        {
            string sql = "delete from teacher_course where(teacher_id=@teacher_id and course_id=@course_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_id", teacher_id));
            cmd.Parameters.Add(new SqlParameter("@course_id", course_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //删除某课程和老师的全部关联
        public void Delete_teacher_course(string course_id)
        {
            string sql = "delete from teacher_course where course_id=@course_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@course_id", course_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
