namespace WebApplication1.Model
{
    public class SubCategoryVM
    {
        public string Name { get; set; }
    }

    public class SubCategory : SubCategoryVM
    {
        public List<Product> products { get; set; }
    }
}
