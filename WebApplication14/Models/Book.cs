using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Year { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }


        public Book()
        {

        }

        public Book(int bId, int catId, string title, string isbn, string year, decimal price, string dec, int pos, string status, string Img)
        {
            this.BookId = bId;
            this.CategoryId = catId;
            this.Title = title;
            this.ISBN = isbn;
            this.Year = year;
            this.Price = price;
            this.Description = dec;
            this.Position = pos;
            this.Status = status;
            this.Image = Img;
        }

    }
}