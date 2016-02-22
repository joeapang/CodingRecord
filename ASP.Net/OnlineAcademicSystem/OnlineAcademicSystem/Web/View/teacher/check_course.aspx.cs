using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.teacher
{
    public partial class check_course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string teacher_id = Session["name"].ToString();
            GridView1.DataSourceID = "";
            OnlineAcademicSystem.BLL.teacher_course ub = new OnlineAcademicSystem.BLL.teacher_course();
            DataTable dt = new DataTable();
            dt = ub.Query_course(teacher_id);
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }
    }
}