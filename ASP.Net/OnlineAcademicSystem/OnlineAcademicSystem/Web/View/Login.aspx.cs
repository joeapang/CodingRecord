using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (DropDownList1.Text == "管理员")
            {
                bool Result;
                bool isSuccess;
                string user = this.txtuser.Text;
                string psw = this.txtpsw.Text;
                OnlineAcademicSystem.BLL.admin ub = new OnlineAcademicSystem.BLL.admin();
                isSuccess = ub.Login(user, psw, out Result);
                if (isSuccess == true)
                {
                    Session["name"] = user;
                    Session.Timeout = 4000;
                    Response.Redirect("admin/Index.aspx");
                }
                else
                {
                    Response.Write(" <script> alert( '登录失败'); </script> ");
                }

            }
            else if (DropDownList1.Text == "学生")
            {
                bool Result;
                bool isSuccess;
                string user = this.txtuser.Text;
                string psw = this.txtpsw.Text;
                OnlineAcademicSystem.BLL.student ub = new OnlineAcademicSystem.BLL.student();
                isSuccess = ub.Login(user, psw, out Result);
                if (isSuccess == true)
                {
                    Session["name"] = user;
                    Response.Redirect("student/Index.aspx");
                }
                else
                {
                    Response.Write(" <script> alert( '登录失败'); </script> ");
                }
                Session["type"] = "学生";
            }
            else if (DropDownList1.Text == "老师")
            {
                bool Result;
                bool isSuccess;
                string user = this.txtuser.Text;
                string psw = this.txtpsw.Text;
                OnlineAcademicSystem.BLL.teacher ub = new OnlineAcademicSystem.BLL.teacher();
                isSuccess = ub.Login(user, psw, out Result);
                if (isSuccess == true)
                {
                    Session["name"] = user;
                    Response.Redirect("teacher/Index.aspx");
                }
                else
                {
                    Response.Write(" <script> alert( '登录失败'); </script> ");
                }
                Session["type"] = "老师";
            }
            
        }
    }
}