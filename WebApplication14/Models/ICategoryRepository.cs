using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        Category GetCategoryById(int id);
        Category AddCategory(Category category);
        void DeleteCategory(int id);
        void UpdateCategory(Category category);


    }
}