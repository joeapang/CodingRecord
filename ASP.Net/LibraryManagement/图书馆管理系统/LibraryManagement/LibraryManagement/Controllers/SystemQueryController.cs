using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class SystemQueryController : Controller
    {
        DbLibraryManagements storeDB = new DbLibraryManagements();
        //
        // GET: /SystemQuery/
        //图书借阅查询
        public ActionResult BookBorrowQuery()
        {
            var adminname = (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname == adminname);
            if (power.sysquery == false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var borrowinformation = new BorrowQuery();
                borrowinformation.BorrowBooks = storeDB.BorrowBooks.ToList();
                return View(borrowinformation);
            }
        }
        [HttpPost]
        public ActionResult BookBorrowQuery(BorrowQuery borrowinformation)
        {
            if (borrowinformation.queryconditions == ("条形码").ToString().Trim())
            {
                if (borrowinformation.importqueryconditions != null)
                {
                    var importquerycondition = (borrowinformation.importqueryconditions).ToString().Trim();
                    var book = from s in storeDB.BorrowBooks
                               where (s.bookcode == importquerycondition)
                               select s;
                    var books = book.ToList();
                    borrowinformation.BorrowBooks = books;
                    return View(borrowinformation);
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('请输入图书条形码查询！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            else if(borrowinformation.queryconditions == ("图书名称").ToString().Trim())
            {
                if (borrowinformation.importqueryconditions != null)
                {
                    var importquerycondition = (borrowinformation.importqueryconditions).ToString().Trim();
                    var book = from s in storeDB.BorrowBooks
                               where (s.Books.bookname== importquerycondition)
                               select s;
                    var books = book.ToList();
                    borrowinformation.BorrowBooks = books;
                    return View(borrowinformation);
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('请输入图书名称查询！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            else if (borrowinformation.queryconditions == ("读者编号").ToString().Trim())
            {
                if (borrowinformation.importqueryconditions != null)
                {
                    var importquerycondition = (borrowinformation.importqueryconditions).ToString().Trim();
                    var book = from s in storeDB.BorrowBooks
                               where (s.Readers.readerid == importquerycondition)
                               select s;
                    var books = book.ToList();
                    borrowinformation.BorrowBooks = books;
                    return View(borrowinformation);
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('请输入读者编号查询！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            else if (borrowinformation.queryconditions == ("读者名称").ToString().Trim())
            {
                if (borrowinformation.importqueryconditions != null)
                {
                    var importquerycondition = (borrowinformation.importqueryconditions).ToString().Trim();
                    var book = from s in storeDB.BorrowBooks
                               where (s.Readers.readername == importquerycondition)
                               select s;
                    var books = book.ToList();
                    borrowinformation.BorrowBooks = books;
                    return View(borrowinformation);
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('请输入读者姓名查询！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            else if (borrowinformation.queryconditions == ("借阅时间").ToString().Trim())
            {
                if (borrowinformation.importqueryconditions != null)
                {
                    var importquerycondition = (borrowinformation.importqueryconditions).ToString().Trim();
                    var book = from s in storeDB.BorrowBooks
                               where (s.borrowTime == importquerycondition)
                               select s;
                    var books = book.ToList();
                    borrowinformation.BorrowBooks = books;
                    return View(borrowinformation);
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('请输入借阅时间查询！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            else if(borrowinformation.queryconditions == ("全部借阅").ToString().Trim())
            {
                borrowinformation.BorrowBooks = storeDB.BorrowBooks.ToList();
                return View(borrowinformation);
            }
            return View(borrowinformation);
        }
        //图书信息查询
        public ActionResult BookInformationQuery()
        {
            var adminname = (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname == adminname);
            if (power.sysquery == false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var bookinformation = new BookQuery();
                bookinformation.Books = storeDB.Books.ToList();
                return View(bookinformation);
            }
        }
        [HttpPost]
        public ActionResult BookInformationQuery(BookQuery bookinformation)
        {
            if (bookinformation.queryconditions ==("条形码").ToString().Trim())
           {
               if(bookinformation.importqueryconditions!=null)
               {
                   var importquerycondition=(bookinformation.importqueryconditions).ToString().Trim();
                   var book = from s in storeDB.Books
                              where (s.bookcode == importquerycondition)
                              select s;
                   var books = book.ToList();
                   bookinformation.Books = books;
                   return View(bookinformation);
               }
               else
               {
                   return Content("<script type=\"text/javascript\">alert('请输入图书条形码查询！');window.location='javascript:history.back()';</script>", "text/html");
               }
           }
           else if(bookinformation.queryconditions ==("图书类型").ToString().Trim())
           {
                if (bookinformation.importqueryconditions != null)
                {
                    var importquerycondition = (bookinformation.importqueryconditions).ToString().Trim();
                    var book = from s in storeDB.Books
                               where (s.BookTypes.typename == importquerycondition)
                               select s;
                    var books = book.ToList();
                    bookinformation.Books = books;
                    return View(bookinformation);
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('请输入图书类型查询！');window.location='javascript:history.back()';</script>", "text/html");
                }
           }
            else if(bookinformation.queryconditions ==("书架").ToString().Trim())
            {
                if (bookinformation.importqueryconditions != null)
                {
                    var importquerycondition = (bookinformation.importqueryconditions).ToString().Trim();
                    var book = from s in storeDB.Books
                               where (s.BookCases.bookcasename == importquerycondition)
                               select s;
                    var books = book.ToList();
                    bookinformation.Books = books;
                    return View(bookinformation);
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('请输入书架名称查询！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            else if(bookinformation.queryconditions ==("出版社").ToString().Trim())
            {
                if (bookinformation.importqueryconditions != null)
                {
                    var importquerycondition = (bookinformation.importqueryconditions).ToString().Trim();
                    var book = from s in storeDB.Books
                               where (s.pubname == importquerycondition)
                               select s;
                    var books = book.ToList();
                    bookinformation.Books = books;
                    return View(bookinformation);
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('请输入出版社查询！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            else if (bookinformation.queryconditions == ("全部图书").ToString().Trim())
            {
                bookinformation.Books = storeDB.Books.ToList();
                return View(bookinformation);
            }
            return View(bookinformation);
        }
    }
}
