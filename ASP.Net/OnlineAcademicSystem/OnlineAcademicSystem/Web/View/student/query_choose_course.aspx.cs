using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.student
{
    public partial class query_choose_course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            OnlineAcademicSystem.BLL.choose_course ub = new OnlineAcademicSystem.BLL.choose_course();
            DataTable dt = new DataTable();
            dt = ub.Query_Choose(Session["name"].ToString());
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            if (e.Row.FindControl("Button1") != null)
            {
                Button CtlButton = (Button)e.Row.FindControl("Button1");
                CtlButton.Click += new EventHandler(CtlButton_Click);
            }
        }

        private void CtlButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow gvr = (GridViewRow)button.Parent.Parent;
            string pk = GridView1.DataKeys[gvr.RowIndex].Value.ToString();
            OnlineAcademicSystem.BLL.choose_course ub = new OnlineAcademicSystem.BLL.choose_course();
            ub.Delete(Session["name"].ToString(), pk);
            Response.Write("<script type=\"text/javascript\">alert('删除成功！');window.location='query_choose_course.aspx';</script>");
        }
    }
}