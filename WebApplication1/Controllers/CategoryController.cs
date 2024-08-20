using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoryController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var list = _context.Categories.Select(c => new CategoryVM
            {
                Name = c.Name,
            }).ToList();
            return Ok(list);
        }

        [HttpGet("{category}")]
        public IActionResult GetSubCategory(string? category )
        {
            var list = _context.Categories
                .Where(c => c.Id == category)
                .SelectMany(c => c.SubCategories)
                .Select(sc => new SubCategoryVM
                {
                    Name = sc.Name
                })
                .ToList();

            if (list.Any())
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}
