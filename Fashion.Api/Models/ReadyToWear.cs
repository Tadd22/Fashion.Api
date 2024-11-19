using System.ComponentModel.DataAnnotations;

namespace Fashion.Api.Models
{
    public class ReadyToWear
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}

