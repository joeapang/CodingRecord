using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class Addgrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                OnlineAcademicSystem.BLL.grade ub = new OnlineAcademicSystem.BLL.grade();
                txt_grade_id.Text = ub.GetMaxID();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txt_grade_id.Text==""||txt_grade_name.Text=="")
            {
                Response.Write("<script>alert('有空项！')</script>");
            }
            else
            {
                OnlineAcademicSystem.BLL.grade ub = new OnlineAcademicSystem.BLL.grade();
                bool result;
                bool issusses;
                issusses = ub.Exists(txt_grade_id.Text, out result);
                if(issusses==true)
                {
                    Response.Write("<script>alert('主键冲突！')</script>");
                }
                else
                {
                    OnlineAcademicSystem.Model.grade us = new OnlineAcademicSystem.Model.grade();
                    us.grade_id = txt_grade_id.Text;
                    us.grade_name = txt_grade_name.Text;
                    ub.Add(us);
                    Response.Write("<script type=\"text/javascript\">alert('添加年级信息成功！');window.location='grademanagement.aspx';</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("grademanagement.aspx");
        }
    }
}