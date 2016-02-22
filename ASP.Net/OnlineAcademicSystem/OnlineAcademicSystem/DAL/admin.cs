using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineAcademicSystem.DAL
{
    public partial class admin
    {
        public admin()
        { }
        //管理员登录
        public void Login(string admin_id ,string admin_password,out bool Result)
        {
            bool result;
            string sql = "select * from admin where admin_id=@admin_id and admin_password=@admin_password";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.Parameters.Add(new SqlParameter("@admin_id", admin_id));
            cmd.Parameters.Add(new SqlParameter("@admin_password", admin_password));
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
            
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select count(1) from admin");
            //strSql.Append(" where admin_id='" + admin_id + "' ");
            //return StringBuilder.Equals(strSql.ToString());
        }
        public bool Add(OnlineAcademicSystem.Model.admin model)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into admin(admin_id,admin_password) values(@admin_id,@admin_password)", conn))
            {
                cmd.Parameters.AddWithValue("@admin_id", model.admin_id);
                cmd.Parameters.AddWithValue("@admin_password", model.admin_password);
                if(cmd.ExecuteNonQuery()>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //修改密码
        public void Modifypassword(string admin_id,string newpassword)
        {
            string sql = "UPDATE admin SET admin_password = @newpassword WHERE (admin_id = @admin_id)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineAcademic"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
             cmd.Parameters.Add(new SqlParameter("@admin_id", admin_id));
             cmd.Parameters.Add(new SqlParameter("@newpassword", newpassword));
             cmd.ExecuteNonQuery();
             conn.Close();
        }
    }
}
