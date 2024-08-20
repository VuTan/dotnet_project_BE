using WebApplication1.Data;

namespace WebApplication1.Model
{
    public class ProductVM
    {
        public string Name { get; set; }
        public int Price { get; set; }

    }

    public class Product : ProductVM
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public List<Img> Imgs { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Topping> Toppings { get; set; }
    }

    public class Size
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class Img
    {
        public string source { get; set; }
    }

    public class Topping
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
