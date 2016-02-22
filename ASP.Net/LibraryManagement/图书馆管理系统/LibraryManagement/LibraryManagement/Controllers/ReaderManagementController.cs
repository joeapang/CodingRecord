using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;
using System.Text.RegularExpressions;
namespace LibraryManagement.Controllers
{
    public class ReaderManagementController : Controller
    {
        DbLibraryManagements storeDB = new DbLibraryManagements();
        //
        // GET: /ReaderManagement/
        //读者档案管理
        public ActionResult ReaderInformationManagement()
        {
            var adminname = (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname == adminname);
            if (power.readset == false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var reader = storeDB.Readers.ToList();
                return View(reader);
            }
        }
        //添加读者信息
        public ActionResult AddReaderInformation()
        {
            ViewBag.ReaderTypes = storeDB.ReaderTypes.OrderBy(a => a.readertype).ToList();
            var reader = new Reader();
            return View(reader);
        }
        [HttpPost]
        public ActionResult AddReaderInformation(Reader reader)
        {
            Reader read = storeDB.Readers.SingleOrDefault<Reader>(a => a.readerid == reader.readerid);
            if (ModelState.IsValid)
            {
                if(read==null)
                {
                    var m = (from search in storeDB.ReaderTypes
                             where reader.readertypeid == search.readertypeid
                             select search).First().number;
                    reader.number = m;
                    storeDB.Readers.Add(reader);
                    storeDB.SaveChanges();
                    ViewBag.ReaderTypes = storeDB.ReaderTypes.OrderBy(a => a.readertype).ToList();
                    return Content("<script type=\"text/javascript\">alert('读者信息添加成功！');window.location='ReaderInformationManagement';</script>", "text/html");
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('该用户名已存在！');window.location='javascript:history.back()';</script>", "text/html");
                } 
            }
            ViewBag.ReaderTypes = storeDB.ReaderTypes.OrderBy(a => a.readertype).ToList();
            return View(reader);
            
        }
        //读者档案详情
        public ActionResult ReaderInformationDetails(string Id)
        {
            ViewBag.ReaderTypes = storeDB.ReaderTypes.OrderBy(a => a.readertype).ToList();
            var reader = storeDB.Readers.Single(a=>a.readerid==Id);
            return View(reader);
        }
        [HttpPost]
        public ActionResult ReaderInformationDetails(string Id, FormatException collection)
        {
            var reader = storeDB.Readers.Find(Id);
            if(TryUpdateModel(reader))
            {
                var m = (from search in storeDB.ReaderTypes
                         where reader.readertypeid == search.readertypeid
                         select search).First().number;
                reader.number = m;
                storeDB.SaveChanges();
                return Content("<script type=\"text/javascript\">alert('读者信息修改成功！');window.location='ReaderInformationManagement';</script>", "text/html");

            }
            else
            {
                ViewBag.ReaderTypes = storeDB.ReaderTypes.OrderBy(a => a.readertype).ToList();

                return View(reader);
            }
            
        }
        //删除读者
        public ActionResult DeleteReader(string Id)
        {
            var reader = storeDB.Readers.Single(a => a.readerid == Id);
            return View(reader);
        }
        [HttpPost]
        public ActionResult DeleteReader(string Id, FormatException collection)
        {
            var reader = storeDB.Readers.Find(Id);
            storeDB.Readers.Remove(reader);
            storeDB.SaveChanges();
            return Content("<script type=\"text/javascript\">alert('读者删除成功！');window.location='ReaderInformationManagement';</script>", "text/html");

        }
        //读者类型管理
        public ActionResult ReaderTypeManagement()
        {
            var adminname = (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname == adminname);
            if (power.readset == false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var readertype = storeDB.ReaderTypes.ToList();
                return View(readertype);
            }
        }
        //添加读者类型
        public ActionResult AddReaderType()
        {
            var readertype = new ReaderType();
            return View(readertype);
        }
        [HttpPost]
        public ActionResult AddReaderType(FormCollection fc)
        {
            ReaderType readertype = new ReaderType();
            readertype.readertype = fc["readertype"];
            readertype.number = Convert.ToInt32(fc["number"]);
            //var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (Regex.IsMatch(readertype.readertype, @"^[a-zA-Z0-9\u4e00-\u9fa5]{1,25}$") && Regex.IsMatch(readertype.number.ToString(), @"^\d*$"))
            {
                if (ModelState.IsValid)
                {
                    storeDB.ReaderTypes.Add(readertype);
                    storeDB.SaveChanges();
                    return Content("<script type=\"text/javascript\">alert('读者类型添加成功！');window.location='ReaderTypeManagement';</script>", "text/html");
                }

            }
            else
            {
                return Content("<script type=\"text/javascript\">alert('读者类型不能为空(为汉字或大小写字母)，数量必须大于等于0');window.location='javascript:history.back()';</script>", "text/html");
            }
            return View(readertype);
        }
       
        //修改读者类型
        public ActionResult EditReaderType(int Id)
        {
            var readertype=storeDB.ReaderTypes.Single(a => a.readertypeid == Id);
            return View(readertype);
        }
        [HttpPost]
        public ActionResult EditReaderType(int Id, FormCollection fc)
        {
            var readertype=storeDB.ReaderTypes.Find(Id);
            var reader =(from s in storeDB.Readers
                        where(s.readertypeid==Id)
                        select s )as Reader;
            readertype.readertype = fc["readertype"];
            readertype.number = Convert.ToInt32(fc["number"]);
            if(Regex.IsMatch(readertype.readertype, @"^[a-zA-Z0-9\u4e00-\u9fa5]{1,25}$") && Regex.IsMatch(readertype.number.ToString(), @"^\d*$"))
            {
                if(TryUpdateModel(readertype))
                {
                    if (reader != null)
                    {
                        reader.number = readertype.number;
                        TryUpdateModel(reader);
                        storeDB.SaveChanges();
                        return Content("<script type=\"text/javascript\">alert('读者类型修改成功！');window.location='ReaderTypeManagement';</script>", "text/html");
                    }
                    else
                    {
                        storeDB.SaveChanges();
                        return Content("<script type=\"text/javascript\">alert('读者类型修改成功！');window.location='ReaderTypeManagement';</script>", "text/html");
                    }
                }  
            }
            else
            {
                return Content("<script type=\"text/javascript\">alert('读者类型不能为空(为汉字或大小写字母)，数量必须大于等于0');window.location='javascript:history.back()';</script>", "text/html");
            }
            return View(readertype);
                
        }
       
        //删除读者类型
       public ActionResult DeleteReaderType(int Id)
        {
           var readertype = storeDB.ReaderTypes.Single(a => a.readertypeid == Id);
           return View(readertype); 
        }
        [HttpPost]
        public ActionResult DeleteReaderType(int Id,FormatException collection)
       {
           var readertype = storeDB.ReaderTypes.Find(Id);
           storeDB.ReaderTypes.Remove(readertype);
           storeDB.SaveChanges();
           return Content("<script type=\"text/javascript\">alert('读者类型删除成功！');window.location='ReaderTypeManagement';</script>", "text/html");
       }
    }
}
