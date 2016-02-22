using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;


namespace LibraryManagement.Controllers
{
    public class BorrowBookController : Controller
    {
        //
        // GET: /BrrowBook/
        DbLibraryManagements storeDB = new DbLibraryManagements();

        //借书管理
        public ActionResult Borrow()
        {
            var adminname = (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname == adminname);
            if (power.borrowback == false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var borrowbook = new BorrowBackBook();
                var borrowbooks = (from s in storeDB.BorrowBooks
                                  where (s.isback ==false)
                                  select s)as IEnumerable<BorrowBook>;
                borrowbook.IEBorrowBook = borrowbooks.ToList();
                borrowbook.Readers = new Reader();
                borrowbook.Readers.ReaderTypes = new ReaderType();
                borrowbook.Books = storeDB.Books.ToList();
                return View(borrowbook);
            }
        }
        [HttpPost]
        public ActionResult Borrow(BorrowBackBook borrowbook)
        {
            if (borrowbook.Readers.readerid != null)
            {
                var reader = storeDB.Readers.SingleOrDefault<Reader>(a => a.readerid == borrowbook.Readers.readerid);
                if (reader != null)
                {
                    var borrow = from s in storeDB.BorrowBooks
                                 where (s.readerid == borrowbook.Readers.readerid&&s.isback==false)
                                 select s;
                    var readertype = storeDB.ReaderTypes.SingleOrDefault<ReaderType>(a => a.readertypeid == reader.readertypeid);
                    var borrows = borrow.ToList();
                    borrowbook.Readers = reader;
                    borrowbook.IEBorrowBook = borrows;
                    borrowbook.Books = storeDB.Books.ToList();
                    borrowbook.Readers.ReaderTypes.readertype = readertype.readertype;
                    return View(borrowbook);
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('不存在该读者！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            else
            {
                return Content("<script type=\"text/javascript\">alert('请输入读者ID！');window.location='javascript:history.back()';</script>", "text/html");

            }
        }
        //借阅图书
        public ActionResult borrows(string code, string id)
        {
            var borrowbook = new BorrowBook();
            borrowbook.bookcode = code;
            borrowbook.readerid = id;
            return View(borrowbook);
        }
        [HttpPost]
        public ActionResult borrows(string code, string id, BorrowBook borrowbook)
        {
            if (borrowbook.readerid != null)
            {
                borrowbook.Books = storeDB.Books.Single(a => a.bookcode == code);
                borrowbook.Readers = storeDB.Readers.Single(a => a.readerid == id);
                var days = storeDB.Books.SingleOrDefault(a => a.bookcode == code).days;
                if (borrowbook.Readers.yjnumber < borrowbook.Readers.number)
                {
                    if(borrowbook.Books.storage>0)
                    {
                        borrowbook.bookcode = code;
                        borrowbook.readerid = id;
                        borrowbook.borrowTime = DateTime.Now.ToString("yyyy-MM-dd");
                        borrowbook.ygbackTime = DateTime.Now.AddDays(days).ToString("yyyy-MM-dd");
                        borrowbook.borrowoper = Session["name"].ToString();
                        borrowbook.isback = false;
                        borrowbook.backoper = "";
                        storeDB.BorrowBooks.Add(borrowbook);
                        borrowbook.Books.storage = borrowbook.Books.storage - 1;
                        borrowbook.Readers.yjnumber = borrowbook.Readers.yjnumber + 1;
                        borrowbook.Books.borrownum += 1;
                        borrowbook.Readers.borrownum += 1;
                        TryUpdateModel(borrowbook.Readers);
                        TryUpdateModel(borrowbook.Books);
                        storeDB.SaveChanges();
                        return Content("<script type=\"text/javascript\">alert('借阅成功！');window.location='Borrow';</script>", "text/html");
                    }
                    else
                    {
                        return Content("<script type=\"text/javascript\">alert('库存不足！');window.location='Borrow';</script>", "text/html");
                    }  
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('超过可借数量！');window.location='Borrow';</script>", "text/html");
                }

            }
            else
            {
                return Content("<script type=\"text/javascript\">alert('请确认读者信息！');window.location='javascript:history.back()';</script>", "text/html");
            }

        }

        //还书管理
        public ActionResult Back()
        {
            var adminname = (Session["name"]).ToString().Trim();
            var power = storeDB.Admins.Single(a => a.adminname == adminname);
            if (power.borrowback == false)
            {
                return Content("<script type=\"text/javascript\">alert('权限不足！');window.location='javascript:history.back()';</script>", "text/html");
            }
            else
            {
                var backbook = new BorrowBackBook();
                var backbooks = (from s in storeDB.BorrowBooks
                                 where (s.isback == false)
                                 select s) as IEnumerable<BorrowBook>;
                backbook.IEBorrowBook = backbooks.ToList();
                backbook.Readers = new Reader();
                backbook.Readers.ReaderTypes = new ReaderType();
                backbook.Books = storeDB.Books.ToList();
                return View(backbook);
            }
        }
        [HttpPost]
        public ActionResult Back(BorrowBackBook backbook)
        {
            if (backbook.Readers.readerid != null)
            {
                var reader = storeDB.Readers.SingleOrDefault<Reader>(a => a.readerid == backbook.Readers.readerid);
                if (reader != null)
                {
                    var back = from s in storeDB.BorrowBooks
                               where (s.readerid == backbook.Readers.readerid&&s.isback==false)
                               select s;
                    var readertype = storeDB.ReaderTypes.SingleOrDefault<ReaderType>(a => a.readertypeid == reader.readertypeid);
                    var backs = back.ToList();
                    backbook.Readers = reader;
                    backbook.IEBorrowBook = backs;
                    backbook.Books = storeDB.Books.ToList();
                    backbook.Readers.ReaderTypes.readertype = readertype.readertype;
                    return View(backbook);
                }
                else
                {
                    return Content("<script type=\"text/javascript\">alert('不存在该读者！');window.location='javascript:history.back()';</script>", "text/html");
                }
            }
            else
            {
                return Content("<script type=\"text/javascript\">alert('请输入读者ID！');window.location='javascript:history.back()';</script>", "text/html");

            }
        }
        //归还图书
        public ActionResult backs(int id)
        {
            var back = storeDB.BorrowBooks.Single(a => a.id == id);
            return View(back);
        }
        [HttpPost]
        public ActionResult backs(int id, BorrowBook back)
        {
            back.Books = new Book();
            back.Readers = new Reader();
            var backs = storeDB.BorrowBooks.Find(id);
            var book = storeDB.Books.SingleOrDefault<Book>(a => a.bookcode == backs.bookcode);
            var reader = storeDB.Readers.SingleOrDefault<Reader>(a => a.readerid == back.readerid);
            backs.isback = true;
            book.storage = book.storage + 1;
            reader.yjnumber = reader.yjnumber - 1;
            TryUpdateModel(backs);
            TryUpdateModel(book);
            storeDB.SaveChanges();
            return Content("<script type=\"text/javascript\">alert('归还成功！');window.location='Back';</script>", "text/html");
        }
    }
}
