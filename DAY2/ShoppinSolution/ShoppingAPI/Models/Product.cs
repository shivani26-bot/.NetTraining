using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShoppingAPI.Models
{

    public enum Status
    {
        Active,
        Inactive,
        OutOfStock
    }
    public class Product:IEquatable<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public float PricePerUnit { get; set; }
        public string Description { get; set; } = string.Empty;
        public int StockAvailable { get; set; }

        //public Product()
        //{
        //    Title = string.Empty;
        //    Description = string.Empty;
        //}

        public Status Status
        {
            get
            {
                if(StockAvailable == 0)
                {
                    return Status.OutOfStock;
                }
                else
                {
                    return Status.Active;
                }
            }
        }
        public bool Equals(Product? other) //parameter is nullable product object
        {
            if (other == null) return false;
            Product p1 = this;
            Product p2 = other;
            return p1.Title == p2.Title;

        }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [JsonIgnore]
        public Category? Category { get; set; }

        public string? SupplierId { get; set; }

        //not added as column in table , only primitive types are added as column in table
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }//Navigation property
        //internal void Remove(int key)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
