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
    public partial class student
    {
        public student()
        { }
        //是否存在该记录
        public void Exists(string student_id, out bool Result)
        {
            bool result;
            string sql = "select * from student where (student_id=@student_id)";
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
        //查询学生
        public DataTable Exists(string student_id)
        {
            string sql = "SELECT grade_id, class_id, major_id, student_name, student_sex, student_tel, student_places, student_password FROM student WHERE   (student_id = @student_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@student_id", student_id));
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            return a;
        }

        //学生登录
        public void Login(string student_id, string student_password, out bool Result)
        {
            bool result;
            string sql = "select * from student where student_id=@student_id and student_password=@student_password";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@student_id", student_id));
            cmd.Parameters.Add(new SqlParameter("@student_password", student_password));
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
        }
        //添加学生
        public bool Add(OnlineAcademicSystem.Model.student model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into student(student_id,grade_id,class_id,major_id,student_name,student_sex,student_tel,student_places,student_password) values(@student_id,@grade_id,@class_id,@major_id,@student_name,@student_sex,@student_tel,@student_places,@student_password)", conn))
            {
                cmd.Parameters.AddWithValue("@student_id", model.student_id);
                cmd.Parameters.AddWithValue("@grade_id", model.grade_id);
                cmd.Parameters.AddWithValue("@class_id", model.class_id);
                cmd.Parameters.AddWithValue("@major_id", model.major_id);
                cmd.Parameters.AddWithValue("@student_name", model.student_name);
                cmd.Parameters.AddWithValue("@student_sex", model.student_sex);
                cmd.Parameters.AddWithValue("@student_tel", model.student_tel);
                cmd.Parameters.AddWithValue("@student_places", model.student_places);
                cmd.Parameters.AddWithValue("@student_password", model.student_password);
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
        //学生信息粗略查询
        public DataTable Query_student_skim(string major_id,string class_id)
        {
            string sql = "SELECT student.student_id, grade.grade_name, classes.class_name, major.major_name, student.student_name, student.student_sex, student.student_tel, student.student_places FROM student INNER JOIN major ON student.major_id = major.major_id INNER JOIN grade ON student.grade_id = grade.grade_id INNER JOIN classes ON student.class_id = classes.class_id where student.major_id=@major_id and student.class_id=@class_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@major_id", major_id));
            cmd.Parameters.Add(new SqlParameter("@class_id", class_id));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable a = ds.Tables[0];
            return a;        
        }
        //按学号查询学生
        public DataTable Query_student_id(string student_id)
        {
            string sql = "SELECT student.student_id, grade.grade_name, classes.class_name, major.major_name, student.student_name, student.student_sex, student.student_tel, student.student_places FROM student INNER JOIN major ON student.major_id = major.major_id INNER JOIN grade ON student.grade_id = grade.grade_id INNER JOIN classes ON student.class_id = classes.class_id where student.student_id=@student_id";
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
        //更新学生信息
        public void Update_student(OnlineAcademicSystem.Model.student model,string student_id)
        {
            string sql = "UPDATE  student SET grade_id = @grade_id, class_id = @class_id, major_id = @major_id, student_name = @student_name, student_sex = @student_sex, student_tel = @student_tel, student_places = @student_places, student_password = @student_password WHERE   (student_id = @student_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@student_id", student_id));
            cmd.Parameters.Add(new SqlParameter("@grade_id", model.grade_id));
            cmd.Parameters.Add(new SqlParameter("@class_id", model.class_id));
            cmd.Parameters.Add(new SqlParameter("@major_id", model.major_id));
            cmd.Parameters.Add(new SqlParameter("@student_name", model.student_name));
            cmd.Parameters.Add(new SqlParameter("@student_sex", model.student_sex));
            cmd.Parameters.Add(new SqlParameter("@student_tel", model.student_tel));
            cmd.Parameters.Add(new SqlParameter("@student_places", model.student_places));
            cmd.Parameters.Add(new SqlParameter("@student_password", model.student_password));
            cmd.ExecuteNonQuery();
        }
        //删除学生
        public void Delete(string student_id)
        {
            string sql = "delete from student where student_id=@student_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@student_id", student_id));
            cmd.ExecuteNonQuery();
        }
        //修改密码
        public void Modifypassword(string student_id, string newpassword)
        {
            string sql = "UPDATE student SET student_password = @newpassword WHERE (student_id = @student_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@student_id", student_id));
            cmd.Parameters.Add(new SqlParameter("@newpassword", newpassword));
            cmd.ExecuteNonQuery();
        }
    }
}
