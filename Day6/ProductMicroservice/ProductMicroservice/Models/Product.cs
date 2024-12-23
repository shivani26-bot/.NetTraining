using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductMicroservice.Models
{
   
    public enum Status
    {
        Available,
        Unavailable,
        OutOfStock,
        Discontinued
    }
    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public float PricePerUnit { get; set; }
        public int StockAvailable { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Status Availability { get; set; } = Status.Unavailable;

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public bool Equals(Product? other)
        {
            if (other == null) return false;
            return Id == other.Id;
        }
    }
}


