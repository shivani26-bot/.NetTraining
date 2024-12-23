namespace ShoppingAPI.Models
{
    public class Supplier : IEquatable<Supplier>
    {
        public string SupplierId { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public double Phone { get; set; }

        public bool Equals(Supplier? other)
        {
            if (other == null) return false;
            return SupplierId == other.SupplierId;
        }
        //this will not be added as column to table, only primitive types are added as column to table , ? ->nullable
        public ICollection<Product>? Products { get; set; }//Navigation property- property used to load child data
    }
}
