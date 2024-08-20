using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SubCategoryController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("{subCategory}")]
        public IActionResult GetProductBySubCategory(string subCategory)
        {
            var producst = _context.SubCategories
                .Where(c => c.Id == subCategory)
                .SelectMany(c => c.Products)
                .Select(p => new ProductVM
                {
                    Name = p.Name,
                    Price = p.Price,
                });
            return Ok(producst);

        }
    }
}
