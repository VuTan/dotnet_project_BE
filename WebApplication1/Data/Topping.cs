namespace WebApplication1.Data
{
    public class Topping
    {
        public int Id { get; set; } 

        public string Name { get; set; } 
        public int Price { get; set; }

        public virtual ICollection<ProductTopping> ProductToppings { get; set; }
    }

}
