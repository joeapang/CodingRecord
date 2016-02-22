using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        DbLibraryManagements storeDB = new DbLibraryManagements();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ranking_list ranking_list = new ranking_list();
            var readers = from s in storeDB.Readers
                          where(s.borrownum>0)
                          orderby s.borrownum descending
                         select s ;
            var books = from m in storeDB.Books
                        where (m.borrownum > 0)
                        orderby m.borrownum descending
                        select m;
            ranking_list.Readers = readers.ToList();
            ranking_list.Books = books.ToList();
            return View(ranking_list);
        }
        public ActionResult LibraryDetails()
        {
            var libraryinformation = storeDB.LibraryInformations.Single(a => a.id == 1);
            return View(libraryinformation);
        }

    }
}
