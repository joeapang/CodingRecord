using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class course_typemanagement : System.Web.UI.Page
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
        //删除按钮的方法
         private void btn_delete_Click(object sender, EventArgs e)
         {
             Button button = (Button)sender;
             GridViewRow gvr = (GridViewRow)button.Parent.Parent;
             string pk = GridView1.DataKeys[gvr.RowIndex].Value.ToString();
             OnlineAcademicSystem.BLL.course_type ub = new OnlineAcademicSystem.BLL.course_type();
             bool result;
             bool issusses;
             issusses = ub.Query(pk, out result);
             if(issusses==true)
             {
                 Response.Write("<script>alert('约束关系，删除失败！');</script>");
             }
             else
             {
                 ub.Delete(pk);
                 GridView1.DataBind();
                 Response.Write("<script type=\"text/javascript\">alert('删除成功！');window.location='course_typemanagement.aspx';</script>");
             }
         }
    }
}