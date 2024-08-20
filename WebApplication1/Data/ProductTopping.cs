namespace WebApplication1.Data
{
    public class ProductTopping
    {
        public string ProductId { get; set; }
        public int ToppingId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Topping Topping { get; set; }
    }

}
