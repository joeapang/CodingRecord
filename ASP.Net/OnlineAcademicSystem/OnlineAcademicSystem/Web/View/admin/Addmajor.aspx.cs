using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class Addmajor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                OnlineAcademicSystem.BLL.major ub = new OnlineAcademicSystem.BLL.major();
                txt_major_id.Text = ub.GetMaxID();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("majormanagement.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txt_major_id.Text == "" || txt_major_name.Text == "")
            {
                Response.Write("<script>alert('有空项！')</script>");
            }
            else
            {
                OnlineAcademicSystem.BLL.major ub = new OnlineAcademicSystem.BLL.major();
                bool result;
                bool issusses;
                issusses = ub.Exists(txt_major_id.Text, out result);
                if(issusses==true)
                {
                    Response.Write("<script>alert('主键冲突！')</script>");
                }
                else
                {
                    OnlineAcademicSystem.Model.major us = new OnlineAcademicSystem.Model.major();
                    us.major_id = txt_major_id.Text;
                    us.major_name = txt_major_name.Text;
                    ub.Add(us);
                    Response.Write("<script type=\"text/javascript\">alert('添加专业成功！');window.location='majormanagement.aspx';</script>");
                }
            }
        }
    }
}