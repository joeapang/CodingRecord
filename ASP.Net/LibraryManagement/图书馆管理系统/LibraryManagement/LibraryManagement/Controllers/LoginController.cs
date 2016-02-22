using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;
using System.Data;
using System.Data.SqlClient;
using WebMatrix.WebData;

namespace LibraryManagement.Controllers
{
    public class LoginController : Controller
    {
        DbLibraryManagements storeDB = new DbLibraryManagements();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            ranking_list ranking_list = new ranking_list();
            ranking_list.Books = storeDB.Books.ToList();
            var readers = from s in storeDB.Readers
                          orderby s.borrownum descending
                          select s;
            ranking_list.Readers = readers.ToList();
            return View(ranking_list);
        }

        public ActionResult Login()
        {
            Session["name"] = "";
            var login = new Login();
            return View(login);
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if(ModelState.IsValid)
            {
                var admin = storeDB.Admins.SingleOrDefault<Admin>(a => a.adminname == login.username);
                if(admin!=null)
                {
                    if(login.password==admin.passward)
                    {
                        if(login.sryzm==login.yzm)
                        {

                            Session["name"] = admin.adminname;
                            Session.Timeout=525600;
                            return Redirect("~/Home/Index");
                        }
                    }
                    else
                    {
                        return Content("<script type=\"text/javascript\">alert('密码错误！');window.location='javascript:history.back()';</script>", "text/html");

                    }
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('用户名不存在！');window.location='javascript:history.back()';</script>", "text/html");

                }
            }
            return View(login);
            
        }
        //修改密码
        public ActionResult ModifyPassword()
        {
            var modifypassword = new ModifyPassword();
            modifypassword.username=Session["name"].ToString();
            return View(modifypassword);
        }
        [HttpPost]
        public ActionResult ModifyPassword(ModifyPassword modifypassword)
        {
            var admin = storeDB.Admins.SingleOrDefault<Admin>(a => a.adminname == modifypassword.username);
            if(modifypassword.oldpsw!=null&&modifypassword.newpsw!=null)
            {
                if (admin.passward == modifypassword.oldpsw)
                {
                    if (modifypassword.newpsw == modifypassword.connewpsw)
                    {
                        admin.passward = modifypassword.newpsw;
                        TryUpdateModel(admin);
                        storeDB.SaveChanges();
                        return Content("<script type=\"text/javascript\">alert('密码修改成功！');window.location='Index';</script>", "text/html");
                    }
                    else
                    {
                        return Content("<script type=\"text/javascript\">alert('新密码和确认密码不匹配！');window.location='javascript:history.back()';</script>", "text/html");
                    }
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('旧密码错误！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            else
            {
                return Content("<script type=\"text/javascript\">alert('密码不能为空！');window.location='javascript:history.back()';</script>", "text/html");
            }
            
        }

    }
}
