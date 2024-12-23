using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Filters;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;
using ProductMicroservice.Models.DTOs;
using ProductMicroservice.Services;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [CustomExceptionFilter]
    public class ProductsController : ControllerBase
    {
        //private readonly IProductCommonService _productService;
        private readonly IProductSupplierService _productService;

        public ProductsController(IProductSupplierService productService)
        {
            _productService = productService;
        }
        //public ProductsController(IProductCommonService productService)
        //{
        //    _productService = productService;
        //}
        //if we try to make a get request without having any product it can cause error
        [HttpPost]
        public async Task<IActionResult> GetProducts(ProductRequestDTO productRequestDTO)
        {
            var products = await _productService.GetAllProducts(productRequestDTO);
            return Ok(products);
        }

        [HttpPost("NewProduct")]
        [Authorize(Roles ="Admin")] //now only admin can addProduct
        [Authorize]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var newProduct = await _productService.AddProduct(product);
            return Ok(newProduct);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequestDTO product)
        {
            if (product.StockUpdate != null)
            {
                var updatedProduct = await _productService.UpdateProductStock(product.StockUpdate);
                return Ok(updatedProduct);
            }
            if (product.PriceUpdate != null)
            {
                var updatedProduct = await _productService.UpdateProductPrice(product.PriceUpdate);
                return Ok(updatedProduct);
            }
            return BadRequest("Invalid request");
        }
    }
}
