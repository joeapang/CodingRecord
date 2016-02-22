using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class Addannouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                OnlineAcademicSystem.BLL.announcement ub = new OnlineAcademicSystem.BLL.announcement();
                txt_announcement_id.Text = ub.GetMaxID().ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txt_announcement_title.Text=="")
            {
                Response.Write("<script>alert('公告标题不能为空')</script>");
            }
            else
            {
                OnlineAcademicSystem.Model.announcement us = new OnlineAcademicSystem.Model.announcement();
                string saveDir = @"announcement\";
                string appPath = this.Request.PhysicalApplicationPath;
                string savePath = appPath + saveDir + txt_announcement_attachment.FileName;
                if (txt_announcement_attachment.HasFile)
                {
                    txt_announcement_attachment.SaveAs(savePath);
                    us.announcement_attachment = txt_announcement_attachment.FileName;
                }
                else
                {
                    us.announcement_attachment = "";
                }
                us.announcement_id = Convert.ToInt32(txt_announcement_id.Text);
                us.announcement_title = txt_announcement_title.Text;
                us.announcement_content = txt_announcement_content.Text;
                us.announcement_time = DateTime.Now.ToString("yyyy-MM-dd");
                OnlineAcademicSystem.BLL.announcement ub = new OnlineAcademicSystem.BLL.announcement();
                ub.Add(us);
                Response.Write("<script type=\"text/javascript\">alert('发布公告成功！');window.location='Index.aspx';</script>");
            }
        }
    }
}