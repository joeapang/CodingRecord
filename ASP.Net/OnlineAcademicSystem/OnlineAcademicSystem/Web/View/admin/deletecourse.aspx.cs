using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.admin
{
    public partial class deletecourse : System.Web.UI.Page
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
        //编辑按钮的方法
         private void btn_delete_Click(object sender, EventArgs e)
         {
             Button button = (Button)sender;
             GridViewRow gvr = (GridViewRow)button.Parent.Parent;
             string pk = GridView1.DataKeys[gvr.RowIndex].Value.ToString();
             OnlineAcademicSystem.BLL.course ub = new OnlineAcademicSystem.BLL.course();
             OnlineAcademicSystem.BLL.choose_course nb = new OnlineAcademicSystem.BLL.choose_course();
             OnlineAcademicSystem.BLL.teacher_course pb = new OnlineAcademicSystem.BLL.teacher_course();
             
             bool result;
             bool issusses;
             issusses = nb.Query_choose_course(pk, out result);
             if(issusses==true)
             {
                 GridView1.DataBind();
                 Response.Write("<script>alert('主键约束，删除失败');</script>");
             }
             else
             {
                 pb.Delete_teacher_course(pk);
                 ub.Delete_course(pk);
                 GridView1.DataBind();
                 Response.Write("<script>alert('删除成功');</script>");
             }
         }
    }
}