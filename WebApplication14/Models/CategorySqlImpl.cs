using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication14.Models
{
    public class CategorySqlImpl : ICategoryRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CategorySqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }


        public Category AddCategory(Category category)
        {
            comm.CommandText = "insert into Category (CategoryName,Description,Image,Position,CreatedAt) values ('" + category.CategoryName + "', '" + category.Description + "', '" + category.Image + "', '" + category.Position + "' , '" + category.CreatedAt + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public void DeleteCategory(int id)
        {
            comm.CommandText = "delete from Category where CategoryId = "+id;
            comm.Connection = conn;
            conn.Open();
            
            conn.Close();
        }

        public List<Category> GetAllCategory()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from Category";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["CategoryId"]);
                string catName = reader["CategoryName"].ToString();
                string des = reader["Description"].ToString();
                string Img = reader["Image"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string CreatedAt = reader["CreatedAt"].ToString();
                list.Add(new Category(id, catName, des,Img,pos,CreatedAt));
            }
            conn.Close();
            return list;
        }

        public Category GetCategoryById(int id)
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from Category where CategoryId = "+id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int Id = Convert.ToInt32(reader["CategoryId"]);
                string catName = reader["CategoryName"].ToString();
                string des = reader["Description"].ToString();
                string Img = reader["Image"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string CreatedAt = reader["CreatedAt"].ToString();
                list.Add(new Category(Id, catName, des, Img, pos, CreatedAt));
            }
            conn.Close();
            return null;
        }

        public void UpdateCategory(Category category)
        {
            comm.CommandText = "update Category set "+category.CategoryName+"='history' where"+ category.CategoryId+" = 2";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
           
        }
    }
}