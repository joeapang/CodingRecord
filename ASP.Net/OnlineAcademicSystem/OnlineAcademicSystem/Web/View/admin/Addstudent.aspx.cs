using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class Addstudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txt_student_id.Text==""||txt_student_password.Text==""||txt_student_name.Text=="")
            {
                Response.Write("<script>alert('有空项！')</script>");
            }
            else
            {
                OnlineAcademicSystem.BLL.student ub = new OnlineAcademicSystem.BLL.student();
                bool result;
                bool issusses;
                issusses = ub.Exists(txt_student_id.Text, out result);
                if(issusses==true)
                {
                    Response.Write("<script>alert('该学号已存在！')</script>");
                }
                else
                {
                    bool sex;
                    OnlineAcademicSystem.Model.student us = new OnlineAcademicSystem.Model.student();
                    us.class_id = drp_classes_id.Text;
                    us.grade_id = drp_grade_id.Text;
                    us.major_id = drp_major_id.Text;
                    us.student_id = txt_student_id.Text;
                    us.student_name = txt_student_name.Text;
                    us.student_password = txt_student_password.Text;
                    us.student_places = txt_student_palaces.Text;
                    if (drp_student_sex.Text == "男")
                    {
                        sex = true;
                    }
                    else
                    {
                        sex = false;
                    }
                    us.student_sex = sex;
                    us.student_tel = txt_student_tel.Text;
                    ub.Add(us);
                    Response.Write("<script type=\"text/javascript\">alert('添加学生信息成功！');window.location='studentmanagement.aspx';</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("studentmanagement.aspx");
        }
    }
}