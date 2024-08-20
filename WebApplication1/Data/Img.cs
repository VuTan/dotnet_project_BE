using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    public class Img
    {
        public int Id { get; set; }
        public string SourceImg { get; set; }

        public string IdProduct { get; set; }
        public virtual Product Product { get; set; }
    }

}
