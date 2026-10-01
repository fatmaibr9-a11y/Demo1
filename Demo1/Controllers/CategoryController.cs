using Demo1.Data;
using Demo1.Model;
using Demo1.Repo.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _Context;
        private readonly IGenaric<Category> _categoryRepo;
        public CategoryController(AppDbContext context, IGenaric<Category> categoryRepo)
        {
            _Context = context;
            _categoryRepo = categoryRepo;
        }
        [HttpGet("get all categories")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepo.GetAll().ToList();
            return Ok(categories);
        }
        [HttpPost("add category")]
        public IActionResult AddCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest("Category is null");
            }
            var c = new Category
            {
                Name = category.Name,
                Description = category.Description
            };
            _categoryRepo.Add(c);
            _categoryRepo.save();
            return Ok(c);
        }

        [HttpPut("update category {id}")]
        public IActionResult EditCategory(Category category , int id )
        {
            var existingCategory = _categoryRepo.GetById(id);
            if (category == null)
            {
                return BadRequest("Category is null");
            }
             _categoryRepo.Update(category);
            _categoryRepo.save();
            return Ok(category);


        }
        [HttpDelete("delete category {id}")]
        public IActionResult DeleteCategory(int id)
        {
            var Category = _categoryRepo.GetById(id);
            if (Category == null)
            {
                return NotFound("Category not found");
            }
            _categoryRepo.Delete(Category);
            _categoryRepo.save();
            return Ok(Category);
        }
    }
}
