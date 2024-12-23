using ShoppingAPI.Models.DTO;

namespace ShoppingAPI.Interfaces
{
    public interface ISupplierWiseProductService
    {
        public ICollection<SupplierProductDTO> GetSupplierWiseProductList();
    }
}
