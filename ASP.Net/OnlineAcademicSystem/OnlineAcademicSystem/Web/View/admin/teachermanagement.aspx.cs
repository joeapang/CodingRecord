using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.admin
{
    public partial class teachermanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            div2.Style.Add("display", "none");
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "True")
                {
                    e.Row.Cells[4].Text = "男";
                }
                if (e.Row.Cells[4].Text.ToString() == "False")
                {
                    e.Row.Cells[4].Text = "女";
                }
            }
        }
        //按钮绑定gridview
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            if (e.Row.FindControl("btn_edit") != null)
            {
                Button CtlButton = (Button)e.Row.FindControl("btn_edit");
                CtlButton.Click += new EventHandler(btn_edit_Click);
            }
        }
        //编辑按钮的方法
        private void btn_edit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow gvr = (GridViewRow)button.Parent.Parent;
            string pk = GridView1.DataKeys[gvr.RowIndex].Value.ToString();
            div1.Style.Add("display", "none");
            div2.Style.Add("display", "block");
            OnlineAcademicSystem.BLL.teacher ub = new OnlineAcademicSystem.BLL.teacher();
            DataTable dt = new DataTable();
            dt=ub.Exists(pk);
            txt_teacher_id.Text = pk;
            drp_teacher_position.Text = dt.Rows[0]["teacher_position_id"].ToString();
            drp_teacher_major.Text = dt.Rows[0]["major_id"].ToString();
            txt_teacher_name.Text = dt.Rows[0]["teacher_name"].ToString();
            if (dt.Rows[0]["teacher_sex"].ToString() == "True")
            {
                drp_teacher_sex.Text = "男";
            }
            else
            {
                drp_teacher_sex.Text = "女";
            }
            txt_teacher_tel.Text = dt.Rows[0]["teacher_tel"].ToString();
            txt_teacher_password.Text = dt.Rows[0]["teacher_password"].ToString();
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("teachermanagement.aspx");
        }

        protected void btn_edit_Click1(object sender, EventArgs e)
        {
            OnlineAcademicSystem.Model.teacher us = new OnlineAcademicSystem.Model.teacher();
            string teacher_id = txt_teacher_id.Text;
            us.teacher_name = txt_teacher_name.Text;
            us.teacher_password = txt_teacher_password.Text;
            if(drp_teacher_sex.Text=="男")
            {
                us.teacher_sex = true;
            }
            else
            {
                us.teacher_sex = false;
            }
            us.teacher_tel = txt_teacher_tel.Text;
            us.teacher_position_id = drp_teacher_position.Text;
            us.major_id = drp_teacher_major.Text;
            OnlineAcademicSystem.BLL.teacher ub = new OnlineAcademicSystem.BLL.teacher();
            ub.Update_teacher(us, teacher_id);
            Response.Write("<script type=\"text/javascript\">alert('修改成功！');window.location='teachermanagement.aspx';</script>");
        }

    }
}