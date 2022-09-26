using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication14.Models
{
    public class BookSqlImpl : IBookRepository
    {

        SqlConnection conn;
        SqlCommand comm;

        public BookSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Book AddBook(Book book)
        {
            comm.CommandText = "insert into Books (CategoryId,Title,ISBN,Year,Price,Description,Position,Status,Image) values ('" + book.CategoryId + "', '" + book.Title + "', '" + book.ISBN + "', '" + book.Year + "' , '" + book.Price + "','" + book.Description + "','" + book.Position + "','" + book.Status + "','" + book.Image + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBook()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Books";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int Bid = Convert.ToInt32(reader["BookId"]);
                int Cid = Convert.ToInt32(reader["CategoryId"]);
                string Title = reader["Title"].ToString();
                string isbn = reader["ISBN"].ToString();
                string year = reader["Year"].ToString();
                decimal price = Convert.ToDecimal(reader["Price"]);
                string des = reader["Description"].ToString();

                int pos = Convert.ToInt32(reader["Position"]);
                string status = reader["Status"].ToString();

                string Img = reader["Image"].ToString();
                list.Add(new Book(Bid, Cid, Title, isbn, year, price, des, pos, status, Img));
            }
            conn.Close();
            return list;
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}