using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace Web.View.student
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            div2.Style.Add("display", "none");
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
            div1.Style.Add("display", "none");
            div2.Style.Add("display", "block");
            OnlineAcademicSystem.BLL.announcement ub = new OnlineAcademicSystem.BLL.announcement();
            DataTable dt = new DataTable();
            dt = ub.Query_announcement(pk);
            announcement_id.Text = dt.Rows[0]["announcement_id"].ToString();
            txt_announcement_title.Text = dt.Rows[0]["announcement_title"].ToString();
            txt_announcement_coent.Text = dt.Rows[0]["announcement_content"].ToString();
            txt_announcement_attachment.Text = dt.Rows[0]["announcement_attachment"].ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            OnlineAcademicSystem.BLL.announcement ub = new OnlineAcademicSystem.BLL.announcement();
            DataTable dt = new DataTable();
            dt = ub.Exsit(Convert.ToInt32(announcement_id.Text));
            if((dt.Rows[0]["announcement_attachment"].ToString())=="")
            {
                Response.Write("<script type=\"text/javascript\">alert('附件不存在，下载失败！');window.location='Index.aspx';</script>");
            }
            else
            {
                string savefilename = txt_announcement_attachment.Text;
                string downloadPath = this.Request.PhysicalApplicationPath+"announcement\\" + savefilename;
                string filename = urlconvertor(downloadPath);
                FileStream fs = new FileStream(filename, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                Response.ContentType = "application/octet-stream";
                //通知浏览器下载文件而不是打开 
                Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(savefilename, System.Text.Encoding.UTF8));
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
        private string urlconvertor(string imagesurl1)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl2 = imagesurl2.Replace(@"\", @"/");
            string filename = tmpRootDir + imagesurl2;
            return filename;
        }
    }
}