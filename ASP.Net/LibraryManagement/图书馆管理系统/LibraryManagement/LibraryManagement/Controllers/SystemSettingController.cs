using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class SystemSettingController : Controller
    {
            DbLibraryManagements storeDB = new DbLibraryManagements();
        //
        // GET: /SystemSetting/
        //管理员设置
        public ActionResult AdminSetting()
        {
            var adminname= (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname ==adminname);
            if(power.sysset==false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var admin = storeDB.Admins.ToList();
                return View(admin);
            }
        }
        //添加管理员
        public ActionResult AddAdmin()
        {
            var admin = new Admin();
            return View(admin);
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Admin admins = storeDB.Admins.SingleOrDefault<Admin>(a => a.adminname == admin.adminname);
                if(admins==null)
                {
                    if(admin.passward==admin.ConfirmPassword)
                    {
                        storeDB.Admins.Add(admin);
                        storeDB.SaveChanges();
                        return Content("<script type=\"text/javascript\">alert('管理员信息保存成功！');window.location='AdminSetting';</script>", "text/html");
                    }
                    else
                    {
                        ModelState.AddModelError("ConfirmPassword", "两次密码不一致");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("adminname", "用户名已存在");
                }
            }
            return View(admin);
            
            
        }
        //管理员权限设置
        public ActionResult EditAdmin(int Id)
        {
            var admin = storeDB.Admins.Single(a => a.id == Id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult EditAdmin(int Id, FormCollection collection)
        {
            var admin = storeDB.Admins.Find(Id);
            if(Id!=1)
            {
                if (TryUpdateModel(admin))
                {
                    storeDB.SaveChanges();
                    return Content("<script type=\"text/javascript\">alert('管理员权限修改成功！');window.location='AdminSetting';</script>", "text/html");
                }
                else
                {
                    return View(admin);
                }
            }
            else
            {
                return Content("<script type=\"text/javascript\">alert('该管理员为超级管理员权限不可更改！');window.location='AdminSetting';</script>", "text/html");

            }
           
        }
        //删除管理员
        public ActionResult DeleteAdmin(int Id)
        {
            var admin = storeDB.Admins.Single(a => a.id == Id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult DeleteAdmin(int Id, FormCollection collection)
        {
            var admin = storeDB.Admins.Find(Id);
            if (Id != 1)
            {
                storeDB.Admins.Remove(admin);
                storeDB.SaveChanges();
                return Content("<script type=\"text/javascript\">alert('管理员删除成功！');window.location='AdminSetting';</script>", "text/html");
            }
            else
            {
                return Content("<script type=\"text/javascript\">alert('该管理员为超级管理员不能删除！');window.location='AdminSetting';</script>", "text/html");

            }
            
        }

        //添加书架
        public ActionResult AddBookcase()
        {
            var bookcase = new BookCase();
            return View(bookcase);
        }
        [HttpPost]
        public ActionResult AddBookcase(BookCase bookcase)
        {
            if (ModelState.IsValid)
            {
                storeDB.BookCases.Add(bookcase);
                storeDB.SaveChanges();
                return Content("<script type=\"text/javascript\">alert('书架信息保存成功！');window.location='BookCaseManagement';</script>", "text/html");
            }
            return View(bookcase);
        }
        //修改书架
        public ActionResult EditBookCase(int Id)
        {
            var bookcase = storeDB.BookCases.Single(a => a.bookcaseid == Id);
            return View(bookcase);
        }
        [HttpPost]
        public ActionResult EditBookCase(int Id, FormCollection collection)
        {
            var bookcase=storeDB.BookCases.Find(Id);
            if (TryUpdateModel(bookcase))
            {
                storeDB.SaveChanges();
                return Content("<script type=\"text/javascript\">alert('书架信息修改成功！');window.location='BookCaseManagement';</script>", "text/html");
            }
            else
            {
                return View(bookcase);
            }
        }
        //删除书架
        public ActionResult DeleteBookCase(int Id)
        {
            var bookcase = storeDB.BookCases.Single(a => a.bookcaseid == Id);
            return View(bookcase);
        }
        [HttpPost]
        public ActionResult DeleteBookCase(int Id, FormCollection collection)
        {
            var bookcase = storeDB.BookCases.Find(Id);
            storeDB.BookCases.Remove(bookcase);
            storeDB.SaveChanges();
            return Content("<script type=\"text/javascript\">alert('书架删除成功！');window.location='BookCaseManagement';</script>", "text/html");

        }
        //书架管理
        public ActionResult BookCaseManagement()
        {
            var adminname = (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname == adminname);
            if (power.sysset == false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var bookcase = storeDB.BookCases.ToList();
                return View(bookcase);
            }
        }
        //图书馆信息相关
        public ActionResult LibraryInformation()
        {
            var adminname = (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname == adminname);
            if (power.sysset == false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var libraryinformation = storeDB.LibraryInformations.Single(a => a.id == 1);
                return View(libraryinformation);
            }
        }
        [HttpPost]
        public ActionResult LibraryInformation(LibraryInformation libraryinformation)
        {
            var libraryinformations = storeDB.LibraryInformations.Find(1);
            if (TryUpdateModel(libraryinformations))
            {
                storeDB.SaveChanges();
                return Content("<script type=\"text/javascript\">alert('图书馆信息保存成功！');window.location='javascript:history.back()';</script>", "text/html");
                
            }
            return View(libraryinformation);
        }
        

    }
}
