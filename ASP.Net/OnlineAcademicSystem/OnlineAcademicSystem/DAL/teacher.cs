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
    public partial class teacher
    {
        public teacher()
        { }
        //是否存在该记录
        public void Exists(string teacher_id,out bool Result)
        {
            bool result;
            string sql = "select * from teacher where (teacher_id=@teacher_id)";
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
        //查询老师
        public DataTable Exists(string teacher_id)
        {
            string sql = "SELECT teacher_id, teacher_position_id, major_id, teacher_name, teacher_sex, teacher_tel, teacher_password FROM teacher WHERE (teacher_id = @teacher_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_id", teacher_id));
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            return a;
        }
        //教师登录
        public void Login(string teacher_id, string teacher_password, out bool Result)
        {
            bool result;
            string sql = "select * from teacher where teacher_id=@teacher_id and teacher_password=@teacher_password";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_id", teacher_id));
            cmd.Parameters.Add(new SqlParameter("@teacher_password", teacher_password));
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
        //添加老师
        public bool Add(OnlineAcademicSystem.Model.teacher model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into teacher(teacher_id,teacher_position_id,major_id,teacher_name,teacher_sex,teacher_tel,teacher_password) values(@teacher_id,@teacher_position_id,@major_id,@teacher_name,@teacher_sex,@teacher_tel,@teacher_password)", conn))
            {
                cmd.Parameters.AddWithValue("@teacher_id", model.teacher_id);
                cmd.Parameters.AddWithValue("@teacher_position_id", model.teacher_position_id);
                cmd.Parameters.AddWithValue("@major_id", model.major_id);
                cmd.Parameters.AddWithValue("@teacher_name", model.teacher_name);
                cmd.Parameters.AddWithValue("@teacher_sex", model.teacher_sex   );
                cmd.Parameters.AddWithValue("@teacher_tel", model.teacher_tel   );
                cmd.Parameters.AddWithValue("@teacher_password", model.teacher_password);
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
        //更新教师信息
        public void Update_teacher(OnlineAcademicSystem.Model.teacher model,string teacher_id)
        {
            string sql = "UPDATE  teacher SET  teacher_position_id = @teacher_position_id, major_id = @major_id, teacher_name = @teacher_name,  teacher_sex = @teacher_sex, teacher_tel = @teacher_tel, teacher_password = @teacher_password WHERE   (teacher_id = @teacher_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_id", teacher_id));
            cmd.Parameters.Add(new SqlParameter("@teacher_position_id", model.teacher_position_id));
            cmd.Parameters.Add(new SqlParameter("@major_id", model.major_id));
            cmd.Parameters.Add(new SqlParameter("@teacher_name", model.teacher_name));
            cmd.Parameters.Add(new SqlParameter("@teacher_sex", model.teacher_sex));
            cmd.Parameters.Add(new SqlParameter("@teacher_tel", model.teacher_tel));
            cmd.Parameters.Add(new SqlParameter("@teacher_password", model.teacher_password));
            cmd.ExecuteNonQuery();
        }

        //删除教师
        public void Delete(string teacher_id)
        {
            string sql = "delete from teacher where teacher_id=@teacher_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_id", teacher_id));
            cmd.ExecuteNonQuery();
        }
        //修改密码
        public void Modifypassword(string teacher_id, string newpassword)
        {
            string sql = "UPDATE teacher SET teacher_password = @newpassword WHERE (teacher_id = @teacher_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_id", teacher_id));
            cmd.Parameters.Add(new SqlParameter("@newpassword", newpassword));
            cmd.ExecuteNonQuery();
        }
    }
}
