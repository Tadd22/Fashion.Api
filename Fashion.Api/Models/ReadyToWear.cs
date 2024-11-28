using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fashion.Api.Models
{
    public class ReadyToWear
    {
        [Key]
        public int ReadyToWearID { get; set; }

        public int CustomerID { get; set; }  // Foreign Key

        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }

        [JsonIgnore]
        public virtual Customer? Customer { get; set; }  // Navigation property
    }
}
