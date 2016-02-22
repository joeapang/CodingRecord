using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace LibraryManagement.Models
{
    public class DbLibraryManagements:DbContext
    {
        public DbLibraryManagements():base("Library")
        { 
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<BorrowBook> BorrowBooks { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BookCase> BookCases { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<LibraryInformation> LibraryInformations { get; set; }
        public DbSet<ReaderType> ReaderTypes { get; set; }
    }
}