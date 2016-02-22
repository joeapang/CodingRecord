using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.student
{
    public partial class choose_course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "choosecourse";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(drp_tiaojian.Text=="全部")
            {
                GridView1.DataSourceID = "choosecourse";
            }
            else if (drp_tiaojian.Text == "符合右边条件")
            {
                OnlineAcademicSystem.Model.course us = new OnlineAcademicSystem.Model.course();
                us.major_id = drp_major.Text;
                us.grade_id = drp_grade.Text;
                us.course_type_id = drp_type.Text;
                OnlineAcademicSystem.BLL.choose_course ub = new OnlineAcademicSystem.BLL.choose_course();
                DataTable dt = new DataTable();
                GridView1.DataSourceID = "";
                dt=ub.Query(us.major_id, us.grade_id, us.course_type_id);
                GridView1.DataSource =dt.DefaultView;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            if (e.Row.FindControl("Button2") != null)
            {
                Button CtlButton = (Button)e.Row.FindControl("Button2");
                CtlButton.Click += new EventHandler(CtlButton_Click);
            }
        }

        private void CtlButton_Click(object sender, EventArgs e)
        {
            bool Result;
            bool isSuccess;
            Button button = (Button)sender;
            GridViewRow gvr = (GridViewRow)button.Parent.Parent;
            string pk = GridView1.DataKeys[gvr.RowIndex].Value.ToString();
            string stu_id = Session["name"].ToString();
            string cou_id = pk;
            OnlineAcademicSystem.Model.choose_course us = new OnlineAcademicSystem.Model.choose_course();
            OnlineAcademicSystem.BLL.choose_course ub = new OnlineAcademicSystem.BLL.choose_course();
            isSuccess = ub.Exists(stu_id, cou_id, out Result);
            if(isSuccess==false)
            {
                us.student_id = Session["name"].ToString();
                us.course_id = pk;
                ub.Add(us);
                Response.Write("<script type=\"text/javascript\">alert('选课成功！');window.location='choose_course.aspx';</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('你已经选了该课程，不能重复选择！');window.location='choose_course.aspx';</script>");
            }
            
        }
    }
}