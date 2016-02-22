using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.View.teacher
{
    public partial class check_student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "checkstudent";
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {        
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {            
                //e.Row.Cells[0].Text = e.Row.DataItemIndex.ToString();
                if (e.Row.Cells[5].Text == "True")
                {                
                    e.Row.Cells[5].Text = "男";            
                }            
                if (e.Row.Cells[5].Text.ToString() == "False")  
                {               
                    e.Row.Cells[5].Text = "女";   
                }       
            }    
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.drp_tiaojian.Text=="查询全部")
            {
                lab_stu_id.Visible = false;
                txt_stu_id.Visible = false;
                drp_major.Visible = false;
                drp_classes.Visible = false;
            }
            else if(drp_tiaojian.Text=="粗略查询")
            {
                lab_stu_id.Visible = false;
                txt_stu_id.Visible = false;
                drp_major.Visible = true;
                drp_classes.Visible = true;
            }
            else if(drp_tiaojian.Text=="按学号查询")
            {
                lab_stu_id.Visible = true;
                txt_stu_id.Visible = true;
                drp_major.Visible = false;
                drp_classes.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(drp_tiaojian.Text=="查询全部")
            {
                GridView1.DataSourceID = "checkstudent";
            }
            else if(drp_tiaojian.Text=="粗略查询")
            {
                OnlineAcademicSystem.Model.student us = new OnlineAcademicSystem.Model.student();
                us.major_id = drp_major.Text;
                us.class_id = drp_classes.Text;
                OnlineAcademicSystem.BLL.student ub = new OnlineAcademicSystem.BLL.student();
                GridView1.DataSourceID = "";
                DataTable dt = new DataTable();
                dt=ub.Query_student_skim(us.major_id, us.class_id);
                GridView1.DataSource = dt.DefaultView;
                GridView1.DataBind();
            }
            else if(drp_tiaojian.Text=="按学号查询")
            {
                OnlineAcademicSystem.BLL.student ub = new OnlineAcademicSystem.BLL.student();
                GridView1.DataSourceID = "";
                DataTable dt = new DataTable();
                dt = ub.Query_student_id(txt_stu_id.Text);
                GridView1.DataSource = dt.DefaultView;
                GridView1.DataBind();
            }
        }
    }
}