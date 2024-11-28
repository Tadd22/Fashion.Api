using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fashion.Api.Models
{
    public class Accessories
    {
        [Key]
        public int AccessoriesID { get; set; }

        public int CustomerID { get; set; }  // Foreign Key

        public string AccessoriesType { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [JsonIgnore]
        public virtual Customer? Customer { get; set; }  // Navigation property
    }
}
