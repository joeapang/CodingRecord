using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class BookManagementController : Controller
    {
        DbLibraryManagements storeDB = new DbLibraryManagements();
        //
        // GET: /BookManagement/
        //图书信息管理
        public ActionResult BookInformationManagement()
        {
            var adminname = (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname == adminname);
            if (power.bookset == false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var book = storeDB.Books.ToList();
                return View(book);
            }
            
        }
        //添加图书信息
        public ActionResult AddBookInformation()
        {
            ViewBag.BookTypes = storeDB.BookTypes.OrderBy(a => a.typename).ToList();
            ViewBag.BookCases = storeDB.BookCases.OrderBy(a => a.bookcasename).ToList();
            var book = new Book();
            return View(book);
        }
        [HttpPost]
        public ActionResult AddBookInformation(Book book)
        {
            var books = storeDB.Books.SingleOrDefault<Book>(a =>a.bookcode==book.bookcode);
            if(ModelState.IsValid)
            {
                if(books==null)
                {
                    var m = (from search in storeDB.BookTypes
                             where book.booktypeid == search.booktypeid
                             select search).First().days;
                    book.days = m;
                    storeDB.Books.Add(book);
                    storeDB.SaveChanges();
                    ViewBag.BookTypes = storeDB.BookTypes.OrderBy(a => a.typename).ToList();
                    ViewBag.BookCases = storeDB.BookCases.OrderBy(a => a.bookcasename).ToList();
                    return Content("<script type=\"text/javascript\">alert('图书添加成功！');window.location='BookInformationManagement';</script>", "text/html");
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('条形码重复！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            ViewBag.BookTypes = storeDB.BookTypes.OrderBy(a => a.typename).ToList();
            ViewBag.BookCases = storeDB.BookCases.OrderBy(a => a.bookcasename).ToList();
            return View(book);
            
        }
        //图书信息详情
        public ActionResult BookInformationDetails(string Id)
        {
            ViewBag.BookTypes = storeDB.BookTypes.OrderBy(a => a.typename).ToList();
            ViewBag.BookCases = storeDB.BookCases.OrderBy(a => a.bookcasename).ToList();
            var book = storeDB.Books.Single(a => a.bookcode == Id);
            return View(book);
        }
        [HttpPost]
        public ActionResult BookInformationDetails(string Id,FormCollection collection)
        {
            var book = storeDB.Books.Find(Id);
            if(TryUpdateModel(book))
            {
                var m = (from search in storeDB.BookTypes
                         where book.booktypeid == search.booktypeid
                         select search).First().days;
                book.days = m;
                storeDB.SaveChanges();
                return Content("<script type=\"text/javascript\">alert('图书修改成功！');window.location='BookInformationManagement';</script>", "text/html");
            }
            else
            {
                ViewBag.BookTypes = storeDB.BookTypes.OrderBy(a => a.typename).ToList();
                ViewBag.BookCases = storeDB.BookCases.OrderBy(a => a.bookcasename).ToList();
                return View(book);
            }
        }
        //删除图书
        public ActionResult DeleteBook(string Id)
        {
            var book = storeDB.Books.Single(a => a.bookcode == Id);
            return View(book);
        }
        [HttpPost]
        public ActionResult DeleteBook(string Id, FormCollection collection)
        {
            var book = storeDB.Books.Find(Id);
            storeDB.Books.Remove(book);
            storeDB.SaveChanges();
            return Content("<script type=\"text/javascript\">alert('图书删除成功！');window.location='BookInformationManagement';</script>", "text/html");
        }
        //图书类型管理
        public ActionResult BookTypeManagement()
        {
            var adminname = (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname == adminname);
            if (power.bookset == false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var booktype = storeDB.BookTypes.ToList();
                return View(booktype);
            }
        }
        //添加图书类型
        public ActionResult AddBookType()
        {
            var booktype = new BookType();
            return View(booktype);
        }
        [HttpPost]
        public ActionResult AddBookType(BookType booktype)
        {
            if(ModelState.IsValid)
            {
                storeDB.BookTypes.Add(booktype);
                storeDB.SaveChanges();
                return Content("<script type=\"text/javascript\">alert('图书类型添加成功！');window.location='BookTypeManagement';</script>", "text/html");

            }
            return View(booktype);
        }
        //修改图书类型信息
        public ActionResult EditBookType(int Id)
        {
            var booktype = storeDB.BookTypes.Single(a => a.booktypeid == Id);
            return View(booktype);
        }
        [HttpPost]
        public ActionResult EditBookType(int Id,FormCollection collection)
        {
            var booktype = storeDB.BookTypes.Find(Id);
            var book = storeDB.Books.SingleOrDefault<Book>(a => a.booktypeid == Id);
            var borrowbook=new BorrowBook();
            
            if(TryUpdateModel(booktype))
            {
                borrowbook.Books = (from m in storeDB.Books
                                    where (m.booktypeid == Id)
                                    select m) as Book;
                var x = ((from s in storeDB.BorrowBooks
                          where (s.Books.booktypeid == Id)
                          select s).ToList()) as IEnumerable<BorrowBook>;
                if (book != null)
                {
                    if(x!=null&&borrowbook.Books!=null)
                    {
                        foreach(var i in x)
                        {
                            var time = DateTime.ParseExact(i.ygbackTime, "yyyy-MM-dd", null);
                            time = time.AddDays(booktype.days - i.Books.days);
                            i.ygbackTime = time.ToString("yyyy-MM-dd");
                        }
                        book.days = booktype.days;
                        TryUpdateModel(book);
                        TryUpdateModel(x);
                        storeDB.SaveChanges();
                    }
                    else
                    {
                        book.days = booktype.days;
                        TryUpdateModel(book);
                        storeDB.SaveChanges();
                    }
                    
                }
                else
                {
                    storeDB.SaveChanges();
                }
                
                return Content("<script type=\"text/javascript\">alert('图书类型修改成功！');window.location='BookTypeManagement';</script>", "text/html");
            }
            else
            {
                return View(booktype);
            }
        }
        //删除图书类型
        public ActionResult DeleteBookType(int Id)
        {
            var booktype = storeDB.BookTypes.Single(a => a.booktypeid == Id);
            return View(booktype);
        }
        [HttpPost]
        public ActionResult DeleteBookType(int Id,FormCollection collection)
        {
            var booktype = storeDB.BookTypes.Find(Id);
            storeDB.BookTypes.Remove(booktype);
            storeDB.SaveChanges();
            return Content("<script type=\"text/javascript\">alert('图书类型删除成功！');window.location='BookTypeManagement';</script>", "text/html");

        }

    }
}
