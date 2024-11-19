using System.ComponentModel.DataAnnotations;

namespace Fashion.Api.Models
{
    public class Bespoke
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
    }
}