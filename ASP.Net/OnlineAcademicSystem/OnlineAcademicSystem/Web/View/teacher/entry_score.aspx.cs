using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.teacher
{
    public partial class entry_score : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].Text = e.Row.DataItemIndex.ToString();
                if (e.Row.Cells[3].Text == "True")
                {
                    e.Row.Cells[3].Text = "男";
                }
                if (e.Row.Cells[3].Text.ToString() == "False")
                {
                    e.Row.Cells[3].Text = "女";
                }
            }
        }
       
    }
}