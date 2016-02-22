using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class Addcourse_type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                OnlineAcademicSystem.BLL.course_type ub = new OnlineAcademicSystem.BLL.course_type();
                txt_course_type_id.Text = ub.GetMaxID();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txt_course_type_id.Text==""||txt_course_type_name.Text=="")
            {
                Response.Write("<script>alert('有空项！')</script>");
            }
            else
            {
                OnlineAcademicSystem.BLL.course_type ub = new OnlineAcademicSystem.BLL.course_type();
                bool result;
                bool issusses;
                issusses = ub.Exists(txt_course_type_id.Text, out result);
                if(issusses==true)
                {
                    Response.Write("<script>alert('主键冲突！')</script>");
                }
                else
                {
                    OnlineAcademicSystem.Model.course_type us = new OnlineAcademicSystem.Model.course_type();
                    us.course_type_id = txt_course_type_id.Text;
                    us.course_type_name = txt_course_type_name.Text;
                    ub.Add(us);
                    Response.Write("<script type=\"text/javascript\">alert('添加课程类型成功！');window.location='course_typemanagement.aspx';</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("course_typemanagement.aspx");
        }
    }
}