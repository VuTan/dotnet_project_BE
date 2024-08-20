using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    public class SubCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string IdCategory { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

}
