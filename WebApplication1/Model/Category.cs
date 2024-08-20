using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Model
{
    public class CategoryVM
    {
        public string Name { get; set; }
    }

    public class Category : CategoryVM
    {
        public List<SubCategory> SubCategories { get; set; }
    }
}
