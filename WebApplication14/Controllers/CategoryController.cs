using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;


namespace WebApplication14.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepository repository;

        public CategoryController()
        {
            repository = new CategorySqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategory();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetCategoryById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpDelete]
        /*   public IHttpActionResult Delete(int id)
           {
               if (id <= 0)
                   return BadRequest("Not a valid student id");

               repository.DeleteCategory(id);
           }


           [HttpPut]

           public IHttpActionResult Put(Category category)
           {
               repository.UpdateCategory(category);
           }
      */

        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            var data = repository.AddCategory(category);
            return Ok(data);
        }

    }
}
