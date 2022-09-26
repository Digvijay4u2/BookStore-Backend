using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository repository;

        public BookController()
        {
            repository = new BookSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllBook();
            return Ok(data);
        }





        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            var data = repository.AddBook(book);
            return Ok(data);
        }

    }
}
