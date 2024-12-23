using ShoppingAPI.Models.DTO;

namespace ShoppingAPI.Interfaces
{
    public interface ISupplierProductService
    {
        public ICollection<SupplierBasicDTO> GetSupplierList();
    }
}
