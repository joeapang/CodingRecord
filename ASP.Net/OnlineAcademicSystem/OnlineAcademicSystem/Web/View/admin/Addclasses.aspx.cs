using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class Addclasses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("classesmanagement.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txt_class_id.Text==""||txt_class_name.Text=="")
            {
                Response.Write("<script>alert('有空项');</script>");
            }
            else
            {
                OnlineAcademicSystem.BLL.classes ub = new OnlineAcademicSystem.BLL.classes();
                bool result;
                bool issusses;
                issusses = ub.Exists(txt_class_id.Text, out result);
                if(issusses==true)
                {
                    Response.Write("<script>alert('主键冲突');</script>");
                }
                else
                {
                    OnlineAcademicSystem.Model.classes us = new OnlineAcademicSystem.Model.classes();
                    us.class_id = txt_class_id.Text;
                    us.grade_id = drp_grade_id.Text;
                    us.major_id = drp_major_id.Text;
                    us.class_name = txt_class_name.Text;
                    ub.Add(us);
                    Response.Write("<script type=\"text/javascript\">alert('添加班级信息成功！');window.location='classesmanagement.aspx';</script>");
                }
            }
        }
    }
}