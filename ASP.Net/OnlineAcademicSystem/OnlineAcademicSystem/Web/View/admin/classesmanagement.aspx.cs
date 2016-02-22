using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.admin
{
    public partial class classesmanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            div2.Style.Add("display", "none");
        }
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
            OnlineAcademicSystem.BLL.classes ub = new OnlineAcademicSystem.BLL.classes();
            DataTable dt = new DataTable();
            dt = ub.Query_classes(pk);
            txt_class_id.Text = dt.Rows[0]["class_id"].ToString();
            txt_class_name.Text = dt.Rows[0]["class_name"].ToString();
            drp_class_grade.Text = dt.Rows[0]["grade_id"].ToString();
            drp_class_major.Text = dt.Rows[0]["major_id"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OnlineAcademicSystem.Model.classes us = new OnlineAcademicSystem.Model.classes();
            us.grade_id = drp_class_grade.Text;
            us.major_id = drp_class_major.Text;
            us.class_name = txt_class_name.Text;
            OnlineAcademicSystem.BLL.classes ub = new OnlineAcademicSystem.BLL.classes();
            ub.Update_classes(us, txt_class_id.Text);
            Response.Write("<script type=\"text/javascript\">alert('修改成功！');window.location='classesmanagement.aspx';</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("classesmanagement.aspx");
        }
    }
}