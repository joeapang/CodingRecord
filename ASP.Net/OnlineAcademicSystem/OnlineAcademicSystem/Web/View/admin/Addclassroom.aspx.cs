using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class Addclassroom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                OnlineAcademicSystem.BLL.classroom ub = new OnlineAcademicSystem.BLL.classroom();
                txt_classroom_id.Text = ub.GetMaxID();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txt_classroom_id.Text==""||txt_classroom_name.Text=="")
            {
                Response.Write("<script>alert('有空项！')</script>");
            }
            else
            {
                OnlineAcademicSystem.BLL.classroom ub = new OnlineAcademicSystem.BLL.classroom();
                bool result;
                bool issusses;
                issusses = ub.Exists(txt_classroom_id.Text, out result);
                if(issusses==true)
                {
                    Response.Write("<script>alert('主键冲突！')</script>");
                }
                else
                {
                    OnlineAcademicSystem.Model.classroom us = new OnlineAcademicSystem.Model.classroom();
                    us.classroom_id = txt_classroom_id.Text;
                    us.classroom_name = txt_classroom_name.Text;
                    ub.Add(us);
                    Response.Write("<script type=\"text/javascript\">alert('添加教室成功！');window.location='classroommanagement.aspx';</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("classroommanagement.aspx");
        }
    }
}