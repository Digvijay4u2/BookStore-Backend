using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public interface IBookRepository
    {
        List<Book> GetAllBook();
        Book GetBookById(int id);
        Book AddBook(Book book);
        void DeleteBook(int id);
        void UpdateBook(Book book);
    }
}