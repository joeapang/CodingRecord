using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.teacher
{
    public partial class Modifypassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_canxel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btn_ensure_Click(object sender, EventArgs e)
        {
            OnlineAcademicSystem.BLL.teacher ub = new OnlineAcademicSystem.BLL.teacher();
            string teacher_id = Session["name"].ToString();
            string oldpassword = txt_oldpassword.Text;
            bool Result;
            bool isSusses;
            if (txt_oldpassword.Text == "")
            {
                Response.Write("<script>alert('旧密码不能为空');</script>");
            }
            else
            {
                isSusses = ub.Login(teacher_id, oldpassword, out Result);
                if (isSusses == false)
                {
                    Response.Write("<script>alert('旧密码错误');</script>");
                }
                else
                {
                    if (txt_newpassword.Text == "" || txt_confirm_newpassword.Text == "")
                    {
                        Response.Write("<script>alert('新密码或确认密码不能为空');</script>");
                    }
                    else
                    {
                        if (txt_newpassword.Text.Length < 6 && txt_newpassword.Text.Length > 0)
                        {
                            Response.Write("<script>alert('新密码长度不够');</script>");
                        }
                        else
                        {
                            if (txt_newpassword.Text != txt_confirm_newpassword.Text)
                            {
                                Response.Write("<script>alert('新密码和确认新密码不一致');</script>");
                            }
                            else
                            {
                                ub.Modifypassword(teacher_id, txt_newpassword.Text);
                                Response.Write("<script type=\"text/javascript\">alert('密码修改成功！');window.location='Index.aspx';</script>");
                            }
                        }
                    }
                }
            }
        }

    }
}