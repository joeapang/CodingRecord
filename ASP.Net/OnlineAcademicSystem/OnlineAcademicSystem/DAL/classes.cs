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
    public partial class classes
    {
        public classes()
        { }
        //是否存在该记录
        public void Exists(string class_id, out bool Result)
        {
            bool result;
            string sql = "select * from classes where (class_id=@class_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@class_id", class_id));
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
        //添加班级
        public bool Add(OnlineAcademicSystem.Model.classes model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into classes(class_id,grade_id,major_id,class_name) values(@class_id,@grade_id,@major_id,@class_name)", conn))
            {
                cmd.Parameters.AddWithValue("@class_id", model.class_id);
                cmd.Parameters.AddWithValue("@grade_id", model.grade_id);
                cmd.Parameters.AddWithValue("@major_id", model.major_id);
                cmd.Parameters.AddWithValue("@class_name", model.class_name);
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
        //查询班级
        public DataTable Query_classes(string class_id)
        {
            string sql = "select * from classes where class_id=@class_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@class_id", class_id));
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            return a;
        }
        //更新班级
        public void Update_classes(OnlineAcademicSystem.Model.classes model,string class_id)
        {
            string sql = "Update classes set grade_id=@grade_id,major_id=@major_id,class_name=@class_name where class_id=@class_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@class_id", class_id));
            cmd.Parameters.Add(new SqlParameter("@grade_id", model.grade_id));
            cmd.Parameters.Add(new SqlParameter("@major_id", model.major_id));
            cmd.Parameters.Add(new SqlParameter("@class_name", model.class_name));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //删除班级
        public void Delete_classes(string class_id)
        {
            string sql = "delete from classes where class_id=@class_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@class_id", class_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //查询班级是否有学生
        public void Query_classes_student(string class_id,out bool Result)
        {
            bool result;
            string sql = "select * from student where class_id=@class_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@class_id", class_id));
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
