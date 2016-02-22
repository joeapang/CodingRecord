using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.student
{
    public partial class query_course_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string student_id = Session["name"].ToString();
            GridView1.DataSourceID = "";
            OnlineAcademicSystem.BLL.course ub = new OnlineAcademicSystem.BLL.course();
            DataTable dt = new DataTable();
            dt=ub.Query_courselist(student_id);
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            
        }
    }
}