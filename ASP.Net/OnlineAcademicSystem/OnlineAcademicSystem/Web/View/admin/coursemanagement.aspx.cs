using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.admin
{
    public partial class coursemanagement : System.Web.UI.Page
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
            OnlineAcademicSystem.BLL.course ub = new OnlineAcademicSystem.BLL.course();
            DataTable dt = new DataTable();
            dt = ub.Query_course(pk);
            lab_course_id.Text = pk;
            drp_course_type.Text = dt.Rows[0]["course_type_id"].ToString();
            drp_course_major.Text = dt.Rows[0]["major_id"].ToString();
            drp_course_grade.Text = dt.Rows[0]["grade_id"].ToString();
            drp_course_teacher.Text = dt.Rows[0]["teacher_id"].ToString();
            drp_course_classroom.Text = dt.Rows[0]["classroom_id"].ToString();
            txt_course_name.Text = dt.Rows[0]["course_name"].ToString();
            txt_course_time.Text = dt.Rows[0]["course_time"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OnlineAcademicSystem.Model.course course = new OnlineAcademicSystem.Model.course();
            OnlineAcademicSystem.Model.teacher_course teacher_course = new OnlineAcademicSystem.Model.teacher_course();
            course.classroom_id = drp_course_classroom.Text;
            course.course_type_id = drp_course_type.Text;
            course.major_id = drp_course_major.Text;
            course.grade_id = drp_course_grade.Text;
            course.course_name = txt_course_name.Text;
            course.course_time = txt_course_time.Text;

            teacher_course.teacher_id = drp_course_teacher.Text;
            teacher_course.course_id = lab_course_id.Text;

            OnlineAcademicSystem.BLL.course ub = new OnlineAcademicSystem.BLL.course();
            OnlineAcademicSystem.BLL.teacher_course ub1 = new OnlineAcademicSystem.BLL.teacher_course();
            ub.Update_course(course, lab_course_id.Text);
            ub1.Delete(drp_course_teacher.Text, lab_course_id.Text);
            ub1.Add(teacher_course);
            Response.Write("<script type=\"text/javascript\">alert('修改成功！');window.location='coursemanagement.aspx';</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("coursemanagement.aspx");
        }
    }
}