using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fashion.Api.Models
{
    public class Accessories
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }




    }
}
