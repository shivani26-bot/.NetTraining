using AutoMapper;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Models.DTO;

namespace ShoppingAPI.Services
{
    public class SupplierWiseProduct : ISupplierWiseProductService
    {

        private readonly IRepository<Supplier, string> _supplierRepository;
        private readonly IMapper _mapper;

        //injecting mapper
        public SupplierWiseProduct(IRepository<Supplier, string> supplierRepository,
                                        IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }
        public ICollection<SupplierProductDTO> GetSupplierWiseProductList()
        {
            var suppliers= _supplierRepository.Get().ToList();

            IList<SupplierProductDTO> supplierProductDTOs = _mapper.Map<IList<SupplierProductDTO>>(suppliers);
           
            return supplierProductDTOs;
       
        }
    }
}
