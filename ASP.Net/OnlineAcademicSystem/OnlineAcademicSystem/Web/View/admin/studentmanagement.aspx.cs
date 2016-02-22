using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.admin
{
    public partial class studentmanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            div2.Style.Add("display", "none");
        }
        //性别给值
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text == "True")
                {
                    e.Row.Cells[5].Text = "男";
                }
                if (e.Row.Cells[5].Text.ToString() == "False")
                {
                    e.Row.Cells[5].Text = "女";
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
            OnlineAcademicSystem.BLL.student ub = new OnlineAcademicSystem.BLL.student();
            DataTable dt = new DataTable();
            dt = ub.Exists(pk);
            txt_student_id.Text = pk;
            drp_student_grade.Text = dt.Rows[0]["grade_id"].ToString();
            drp_student_classes.Text = dt.Rows[0]["class_id"].ToString();
            drp_student_major.Text = dt.Rows[0]["major_id"].ToString();
            txt_student_name.Text = dt.Rows[0]["student_name"].ToString();
            if (dt.Rows[0]["student_sex"].ToString() == "True")
            {
                drp_student_sex.Text = "男";
            }
            else
            {
                drp_student_sex.Text = "女";
            }
            txt_student_tel.Text = dt.Rows[0]["student_name"].ToString();
            txt_student_place.Text = dt.Rows[0]["student_places"].ToString();
            txt_student_password.Text = dt.Rows[0]["student_password"].ToString();
        }

        protected void btn_edit_Click1(object sender, EventArgs e)
        {
            OnlineAcademicSystem.Model.student us = new OnlineAcademicSystem.Model.student();
            string student_id = txt_student_id.Text;
            us.student_name = txt_student_name.Text;
            us.student_password = txt_student_password.Text;
            if (drp_student_sex.Text == "男")
            {
                us.student_sex = true;
            }
            else
            {
                us.student_sex = false;
            }
            us.student_tel = txt_student_tel.Text;
            us.student_places = txt_student_place.Text;
            us.major_id = drp_student_major.Text;
            us.grade_id = drp_student_grade.Text;
            us.class_id = drp_student_classes.Text;
            OnlineAcademicSystem.BLL.student ub = new OnlineAcademicSystem.BLL.student();
            ub.Update_student(us, student_id);
            Response.Write("<script type=\"text/javascript\">alert('修改成功！');window.location='studentmanagement.aspx';</script>");
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("studentmanagement.aspx");
        }
    }
}