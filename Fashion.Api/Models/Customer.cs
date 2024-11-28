using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fashion.Api.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }  // Primary Key

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [JsonIgnore]
        public ICollection<Bespoke>? Bespokes { get; set; }

        [JsonIgnore]
        public ICollection<ReadyToWear>? ReadyToWearItems { get; set; }

        [JsonIgnore]
        public ICollection<Accessories>? Accessories { get; set; }
    }
}
