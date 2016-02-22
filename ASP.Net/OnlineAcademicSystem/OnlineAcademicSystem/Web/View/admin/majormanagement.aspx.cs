using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View.admin
{
    public partial class majormanagement : System.Web.UI.Page
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
             OnlineAcademicSystem.BLL.major ub = new OnlineAcademicSystem.BLL.major();
             bool result;
             bool issusses1;
             bool issusses2;
             bool issusses3;
             bool issusses4;
             issusses1 = ub.Query_major_classes(pk, out result);
             issusses2 = ub.Query_major_course(pk, out result);
             issusses3 = ub.Query_major_student(pk, out result);
             issusses4 = ub.Query_major_teacher(pk, out result);
             if(issusses1==true||issusses2==true||issusses3==true||issusses4==true)
             {
                 Response.Write("<script>alert('约束关系，删除失败！');</script>");
             }
             else
             {
                 ub.Delete(pk);
                 GridView1.DataBind();
                 Response.Write("<script type=\"text/javascript\">alert('删除成功！');window.location='majormanagement.aspx';</script>");
             }
         }
    }
}