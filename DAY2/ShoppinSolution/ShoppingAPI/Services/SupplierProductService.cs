using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Models.DTO;

namespace ShoppingAPI.Services
{
    public class SupplierProductService : ISupplierProductService
    {
        //private readonly IRepository<Supplier, string> _supplierRepository;

        //public SupplierProductService(IRepository<Supplier,string> supplierRepository)
        //{
        //    _supplierRepository =supplierRepository;
        //}
        //public ICollection<SupplierBasicDTO> GetSupplierList()
        //{
        //    var suppliers = _supplierRepository.Get();
        //    var supplierBasicDTOs = MapSupplierToDTO(suppliers);
        //    return supplierBasicDTOs;
        //}


        //    private IList<SupplierBasicDTO> MapSupplierToDTO(ICollection<Supplier> suppliers)
        //    {
        //    List<SupplierBasicDTO> supplierBasicDTOs=new List<SupplierBasicDTO>();
        //    foreach (var supplier in suppliers)
        //    {
        //        supplierBasicDTOs.Add(new SupplierBasicDTO
        //        {
        //            SupplierId = supplier.SupplierId,
        //            Name = supplier.ContactPerson,
        //        });

        //    }
        //    return supplierBasicDTOs;

        //}




        private readonly IRepository<Supplier, string> _supplierRepository;
        private readonly IMapper _mapper;

        //injecting mapper
        public SupplierProductService(IRepository<Supplier, string> supplierRepository,
                                        IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }
        public ICollection<SupplierBasicDTO> GetSupplierList()
        {
            var suppliers = _supplierRepository.Get();
            IList<SupplierBasicDTO> supplierBasicDTOs = _mapper.Map<IList<SupplierBasicDTO>>(suppliers);
            //var supplierBasicDTOs = MapSupplierToDTO(suppliers);
            return supplierBasicDTOs;
        }
    }
}
