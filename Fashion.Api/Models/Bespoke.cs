using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fashion.Api.Models
{
    public class Bespoke
    {
        [Key]
        public int BespokeID { get; set; }

        public int CustomerID { get; set; }  // Foreign Key

        public string Description { get; set; }
        public string Measurements { get; set; }
        public DateTime DeliveryDate { get; set; }

       

        [JsonIgnore]
        public virtual Customer? Customer { get; set; }  // Navigation property
    }
}
