using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }

}
