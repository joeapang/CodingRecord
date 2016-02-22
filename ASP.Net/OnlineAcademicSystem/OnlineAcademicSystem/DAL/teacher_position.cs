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
    public partial class teacher_position
    {
        public teacher_position()
        { }
        //是否存在该记录
        public void Exists(string teacher_position_id, out bool Result)
        {
            bool result;
            string sql = "select * from teacher_position where (teacher_position_id=@teacher_position_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_position_id", teacher_position_id));
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
        //添加老师职称
        public bool Add(OnlineAcademicSystem.Model.teacher_position model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into teacher_position(teacher_position_id,teacher_position_name) values(@teacher_position_id,@teacher_position_name)", conn))
            {
                cmd.Parameters.AddWithValue("@teacher_position_id", model.teacher_position_id);
                cmd.Parameters.AddWithValue("@teacher_position_name", model.teacher_position_name);
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
        //查询教师职称和教师是否有关联
        public void Query(string teacher_position_id,out bool Result)
        {
            bool result;
            string sql = "select *from teacher where teacher_position_id=@teacher_position_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_position_id", teacher_position_id));
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
        //删除教师职称
        public void Delete(string teacher_position_id)
        {
            string sql = "delete from teacher_position where teacher_position_id=@teacher_position_id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@teacher_position_id", teacher_position_id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //获取当前最大ID
         public string GetMaxID()
        {
            string sql = "SELECT TOP 1 [teacher_position_id],[teacher_position_name] FROM [OnlineAcademic].[dbo].[teacher_position] order by [teacher_position_id] desc";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable a = ds.Tables[0];
            int ID = Convert.ToInt32(a.Rows[0]["teacher_position_id"]) + 1;
            return ID.ToString();
        }
    }
}
