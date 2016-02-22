using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class Addteacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txt_teacher_id.Text==""||txt_teacher_name.Text==""||txt_teacher_password.Text=="")
            {
                Response.Write("<script>alert('有空项！')</script>");
            }
            else
            {
                bool result;
                bool issusses;
                OnlineAcademicSystem.BLL.teacher ub = new OnlineAcademicSystem.BLL.teacher();
                issusses=ub.Exists(txt_teacher_id.Text, out result);
                if(issusses==true)
                {
                    Response.Write("<script>alert('该教师编号已存在！')</script>");
                }
                else if(issusses==false)
                {
                    bool sex;
                    OnlineAcademicSystem.Model.teacher us = new OnlineAcademicSystem.Model.teacher();
                    us.major_id = drp_major_id.Text;
                    us.teacher_id = txt_teacher_id.Text;
                    us.teacher_password = txt_teacher_password.Text;
                    us.teacher_position_id = drp_teacher_position_id.Text;
                    if (drp_teacher_sex.Text == "男")
                    {
                        sex = true;
                    }
                    else
                    {
                        sex = false;
                    }
                    us.teacher_sex = sex;
                    us.teacher_tel = txt_teacher_tel.Text;
                    us.teacher_name = txt_teacher_name.Text;
                    ub.Add(us);
                    Response.Write("<script type=\"text/javascript\">alert('添加教师信息成功！');window.location='teachermanagement.aspx';</script>");
                }
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("teachermanagement.aspx");
        }
    }
}