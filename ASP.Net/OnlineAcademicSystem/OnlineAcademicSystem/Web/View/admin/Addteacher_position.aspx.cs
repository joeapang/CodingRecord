using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class Addteacher_position : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                OnlineAcademicSystem.BLL.teacher_position ub = new OnlineAcademicSystem.BLL.teacher_position();
                txt_teacher_position_id.Text = ub.GetMaxID();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txt_teacher_position_id.Text==""||txt_teacher_position_name.Text=="")
            {
                Response.Write("<script>alert('有空项！')</script>");
            }
            else
            {
                OnlineAcademicSystem.BLL.teacher_position ub = new OnlineAcademicSystem.BLL.teacher_position();
                bool result;
                bool issusses;
                issusses = ub.Exists(txt_teacher_position_id.Text, out result);
                if(issusses==true)
                {
                    Response.Write("<script>alert('主键冲突！')</script>");
                }
                else
                {
                    OnlineAcademicSystem.Model.teacher_position us = new OnlineAcademicSystem.Model.teacher_position();
                    us.teacher_position_id = txt_teacher_position_id.Text;
                    us.teacher_position_name = txt_teacher_position_name.Text;
                    ub.Add(us);
                    Response.Write("<script type=\"text/javascript\">alert('添加教师职称成功！');window.location='teacher_positionmanagement.aspx';</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("teacher_positionmanagement.aspx");
        }
    }
}