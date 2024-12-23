using SagaOrchestratorAPI.Interfaces;
using SagaOrchestratorAPI.Models;

namespace SagaOrchestratorAPI.Services
{
    public class SagaOrchestrator : ISagaOrchestrator
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public SagaOrchestrator(IProductService productService,
                                IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;

        }
        public async Task<bool> ProcessOrderSagaAsync(OrderDetailsDTO orderRequest)
        {
            bool result = false;
            try
            {
                await _orderService.AddOrder(orderRequest);
                foreach (var product in orderRequest.Products)
                {
                    await _productService.UpdateProduct(new UpdateProductRequestDTO
                    {
                        StockUpdate = new ProductStockUpdateRequestDTO
                        {
                            ProductId = product.ProductId,
                            StockToBeAdded = -product.Quantity
                        }
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await _orderService.DeleteOrder(orderRequest.OrderId);
                foreach (var product in orderRequest.Products)
                {
                    await _productService.UpdateProduct(new UpdateProductRequestDTO
                    {
                        StockUpdate = new ProductStockUpdateRequestDTO
                        {
                            ProductId = product.ProductId,
                            StockToBeAdded = product.Quantity
                        }
                    });
                }
                return false;
            }
        }
    }
}
