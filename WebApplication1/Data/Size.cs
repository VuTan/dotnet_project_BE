namespace WebApplication1.Data
{
    public class Size
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

}
