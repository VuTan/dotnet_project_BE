using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            // Truy vấn sản phẩm và các thuộc tính điều hướng
            var product = _context.Products
                .Include(p => p.Imgs)               // Bao gồm ảnh sản phẩm
                .Include(p => p.Sizes)              // Bao gồm kích cỡ sản phẩm
                .Include(p => p.ProductToppings)    // Bao gồm topping của sản phẩm
                .ThenInclude(pt => pt.Topping)      // Bao gồm topping details
                .SingleOrDefault(p => p.Id == id);  // Tìm sản phẩm theo Id

            if (product == null)
            {
                return NotFound();  // Trả về 404 nếu sản phẩm không tìm thấy
            }

            // Chuyển đổi thành Model và trả về kết quả
            var productViewModel = new Model.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Imgs = product.Imgs.Select(i => new Model.Img
                {
                    source = i.SourceImg  // Đảm bảo thuộc tính khớp với model
                }).ToList(),
                Sizes = product.Sizes.Select(s => new Model.Size
                {
                    Name = s.Name,
                    Price = s.Price
                }).ToList(),
                Toppings = product.ProductToppings.Select(pt => new Model.Topping
                {
                    Name = pt.Topping.Name,
                    Price = pt.Topping.Price
                }).ToList()
            };

            return Ok(productViewModel);  // Trả về dữ liệu sản phẩm dưới dạng JSON
        }

    }
}
