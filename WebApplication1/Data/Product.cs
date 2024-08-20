using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public string IdSubCategory { get; set; }
        public virtual SubCategory SubCategory { get; set; }

        public virtual ICollection<Img> Imgs { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<ProductTopping> ProductToppings { get; set; }

    }

}
