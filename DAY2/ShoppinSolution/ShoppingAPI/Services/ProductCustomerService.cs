

using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;

namespace ShoppingAPI.Services
{

    //customer will only implement general service 
    public class ProductCustomerService:IProductGeneralService
    {
        private readonly IRepository<Product, int> _productRepository;
        public ProductCustomerService(IRepository<Product,int>productRepository) //Taking the injection of repository
        {
            _productRepository = productRepository;
        }
        public List<Product> GetProducts()
        {
            var products=_productRepository.Get().OrderBy(p => p.PricePerUnit);//sorting the products based on price in ascending order
            return products.ToList();
        }
       
    }
}
