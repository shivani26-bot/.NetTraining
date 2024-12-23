using ProductMicroservice.Models.DTOs;
using ProductMicroservice.Models;
using ProductMicroservice.Interfaces;

namespace ProductMicroservice.Services
{
    public class ProductService : IProductCommonService
    {
        //in order to inherit this class in other class make the repository as protected
        protected readonly IRepository<int, Product> _repository;

        public ProductService(IRepository<int, Product> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> GetAllProducts(ProductRequestDTO productRequestDTO)
        {
            List<Product> products = new List<Product>();
            products = (await _repository.GetAll()).ToList();
            products = FilterByPrice(products, productRequestDTO.PriceFilter);
            products = FilterByStock(products, productRequestDTO.StockFilter);
            products = FilterByAvailability(products, productRequestDTO.AvailabilityFilter);
            products = FilterByImage(products, productRequestDTO.ImageFilter);
            products = SortProducts(products, productRequestDTO.SortOrder);
            products = PaginateProducts(products, productRequestDTO.Pagination);
            return products;
        }
        private List<Product> SortProducts(List<Product> products, int? sortOrder)
        {
            if (sortOrder == null)
            {
                return products;
            }
            switch (sortOrder)
            {
                case 1:
                    products = products.OrderBy(p => p.PricePerUnit).ToList();
                    break;
                case -1:
                    products = products.OrderByDescending(p => p.PricePerUnit).ToList();
                    break;
                case 2:
                    products = products.OrderBy(p => p.StockAvailable).ToList();
                    break;
                case -2:
                    products = products.OrderByDescending(p => p.StockAvailable).ToList();
                    break;
                case 3:
                    products = products.OrderBy(p => p.Availability).ToList();
                    break;
                default:
                    break;
            }
            return products;
        }

        private List<Product> PaginateProducts(List<Product> products, Pagination? pagination)
        {
            if (pagination == null)
            {
                return products;
            }
            products = products.Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
            return products;
        }

        private List<Product> FilterByImage(List<Product> products, ProductImageFilter? imageFilter)
        {
            if (imageFilter == null)
            {
                return products;
            }
            if (imageFilter.IsImageAvailable)
            {
                products = products.Where(p => p.ImageUrl != null).ToList();
            }
            return products;
        }


        private List<Product> FilterByAvailability(List<Product> products, ProductAvailabilityFilter? availabilityFilter)
        {
            if (availabilityFilter == null)
            {
                return products;
            }
            products = products.Where(p => p.Availability == availabilityFilter.Availability).ToList();
            return products;
        }

        private List<Product> FilterByStock(List<Product> products, ProductStockFilter? stockFilter)
        {
            if (stockFilter == null)
            {
                return products;
            }
            if (stockFilter.MinStock > 0)
            {
                products = products.Where(p => p.StockAvailable >= stockFilter.MinStock).ToList();
            }
            if (stockFilter.MaxStock > 0)
            {
                products = products.Where(p => p.StockAvailable <= stockFilter.MaxStock).ToList();
            }
            return products;
        }

        private List<Product> FilterByPrice(List<Product> products, ProductPriceFilter? priceFilter)
        {
            if (priceFilter == null)
            {
                return products;
            }
            if (priceFilter.MaxPrice > 0)
            {
                products = products.Where(p => p.PricePerUnit <= priceFilter.MaxPrice).ToList();
            }
            if (priceFilter.MinPrice > 0)
            {
                products = products.Where(p => p.PricePerUnit >= priceFilter.MinPrice).ToList();
            }
            return products;
        }

        //Task IProductCommonService.GetAllProducts(ProductRequestDTO productsRequestDTO)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
