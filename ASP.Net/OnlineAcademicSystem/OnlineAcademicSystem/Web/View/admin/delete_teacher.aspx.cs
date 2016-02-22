using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class delete_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            if (e.Row.FindControl("btn_delete") != null)
            {
                Button CtlButton = (Button)e.Row.FindControl("btn_delete");
                CtlButton.Click += new EventHandler(btn_delete_Click);
            }
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].Text = e.Row.DataItemIndex.ToString();
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
        //删除按钮方法
        private void btn_delete_Click(object sender, EventArgs e)
        {
            bool Result;
            bool isSuccess;
            Button button = (Button)sender;
            GridViewRow gvr = (GridViewRow)button.Parent.Parent;
            string pk = GridView1.DataKeys[gvr.RowIndex].Value.ToString();
            OnlineAcademicSystem.BLL.teacher ub = new OnlineAcademicSystem.BLL.teacher();
            OnlineAcademicSystem.BLL.teacher_course nb = new OnlineAcademicSystem.BLL.teacher_course();
            isSuccess = nb.Exists(pk, out Result);
            if (isSuccess == true)
            {
                GridView1.DataBind();
                Response.Write("<script type=\"text/javascript\">alert('由于约束关系，删除失败！');window.location='delete_teacher.aspx';</script>");
            }
            else
            {
                ub.Delete(pk);
                GridView1.DataBind();
                Response.Write("<script type=\"text/javascript\">alert('删除成功！');window.location='delete_teacher.aspx';</script>");
            }
        }
    }
}