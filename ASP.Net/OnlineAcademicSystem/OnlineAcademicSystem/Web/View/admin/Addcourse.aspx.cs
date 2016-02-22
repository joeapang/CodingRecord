using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class Addcourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                OnlineAcademicSystem.BLL.course ub = new OnlineAcademicSystem.BLL.course();
                txt_course_id.Text = ub.GetMaxID();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txt_course_id.Text==""||txt_course_name.Text=="")
            {
                Response.Write("<script>alert('有空项！')</script>");
            }
            else
            {
                OnlineAcademicSystem.BLL.teacher_course nb = new OnlineAcademicSystem.BLL.teacher_course();
                OnlineAcademicSystem.BLL.course ub = new OnlineAcademicSystem.BLL.course();
                bool result;
                bool issusses;
                issusses = ub.Exists(txt_course_id.Text, out result);
                if(issusses==true)
                {
                    Response.Write("<script>alert('主键冲突！')</script>");
                }
                else
                {
                    OnlineAcademicSystem.Model.course us = new OnlineAcademicSystem.Model.course();
                    OnlineAcademicSystem.Model.teacher_course ns = new OnlineAcademicSystem.Model.teacher_course();
                    us.course_id = txt_course_id.Text;
                    us.course_name = txt_course_name.Text;
                    us.course_time = drp_course_time1.Text + drp_course_time2.Text;
                    us.course_type_id = drp_course_type_id.Text;
                    us.major_id = drp_major_id.Text;
                    us.classroom_id = drp_classroom_id.Text;
                    us.grade_id = drp_grade_id.Text;

                    ns.course_id = txt_course_id.Text;
                    ns.teacher_id = drp_teacher_id.Text;
                    ub.Add(us);
                    nb.Add(ns);
                    Response.Write("<script type=\"text/javascript\">alert('添加课程信息成功！');window.location='coursemanagement.aspx';</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("coursemanagement.aspx");
        }
    }
}