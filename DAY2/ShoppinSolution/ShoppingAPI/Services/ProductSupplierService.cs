using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Models.DTO;
namespace ShoppingAPI.Services
{
    //supplier implements supplier service as well as general service 
    //implements allthe 4 methods 
    public class ProductSupplierService : IProductSupplierService
    {
        private readonly IRepository<Product, int> _productRepository;
        private readonly IAuditLogService _auditLogService;
        //take the injection of repository in service
        //here we are taking repository as well as service as injection , it indicates that one service can take another service as injection 
        public ProductSupplierService(IRepository<Product, int> productRepository,IAuditLogService auditLogService)
        {
            _productRepository = productRepository;
            _auditLogService=auditLogService;

        }
        public Product AddProduct(Product product)
        {
            if (product == null) throw new Exception("Unable to add product, product is null");
            if (product.PricePerUnit <= 0) throw new Exception("Unable to add product,price is less than or equal to zero ");
            if(product.StockAvailable<0) throw new Exception("Unable to add product,stock is less than zero ");
            var newProduct= _productRepository.Add(product);
            return newProduct;
        }

        public List<Product> GetProducts()
        {
            var products = _productRepository.Get().OrderBy(p => p.Id); //sorting based on id
            return products.ToList();
        }

        public Product UpdatePrice(ProductPriceUpdateRequestDTO productDto)
        {
            if (productDto == null) throw new Exception("Unable to update price, product is null");
            if (productDto.UpdatedPrice <= 0) throw new Exception("Unable to update price, price is less than or equal to zero");
            var product = _productRepository.Get(productDto.Id);
            var auditLog = CreateAuditLog("Unit Price", product.PricePerUnit.ToString(), productDto.UpdatedPrice.ToString());
            if (product == null) throw new Exception("Unable to update price, product not found");
            product.PricePerUnit = productDto.UpdatedPrice;
            product = _productRepository.Update(productDto.Id, product);
            //make a call to auditlog once we update the price 
            _auditLogService.AddAuditLog(auditLog);
            return product;
        }


        public Product UpdateStock(ProductStockUpdateRequestDTO productDto)
        {
            if (productDto == null) throw new Exception("Unable to update stock, product is null");
            if (productDto.ChangeInStock <= 0) throw new Exception("Unable to update stock, stock is less than or equal to zero");
            var product = _productRepository.Get(productDto.Id);
            var auditLog = CreateAuditLog("Stock Available", product.StockAvailable.ToString(), (product.StockAvailable + productDto.ChangeInStock).ToString());
            if (product == null) throw new Exception("Unable to update stock, product not found");
            product.StockAvailable += productDto.ChangeInStock;
            product = _productRepository.Update(productDto.Id, product);
            _auditLogService.AddAuditLog(auditLog);
            return product;
        }

        //returns a audit log 
        private AuditLog CreateAuditLog(string columnName, string oldValue, string newValue)
        {
            return new AuditLog
            {
                ModifiedAt = DateTime.Now,
                ModifiedBy = "--",
                TableName = "Product",
                ColumnName = columnName,
                OldValue = oldValue,
                NewValue = newValue
            };
        }
    }
}

