//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ShoppingAPI.Interfaces;
//using ShoppingAPI.Models.DTO;
//using ShoppingAPI.Models;

//namespace ShoppingAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//public class ProductController : ControllerBase
//{
//private readonly IProductGeneralService _productService;
//public ProductController(IProductGeneralService productService)
//{
//    _productService= productService;
//}
//[HttpGet]
//public IActionResult GetProducts()
//{
//    var products=_productService.GetProducts();
//    return Ok(products);
//}

//private readonly IProductSupplierService _productService;

//public ProductController(IProductSupplierService productService)
//{
//    _productService = productService;
//}

//[HttpGet]

//Status returned by webapi action method can be given by ActionResult status code
//instead of using IActionResult we can use ActionResult
//public ActionResult<ICollection<Product>> GetProducts()
//{
//    try
//    {
//        var products = _productService.GetProducts();
//        return Ok(products);
//    }
//    catch (Exception e)
//    {

//        return BadRequest(e.Message);
//    }
//}

//AddProduct is present in IProductSupplierService
//[HttpPost]
//public ActionResult<Product> AddProduct(Product product)
//{
//    try
//    {
//        var newProduct = _productService.AddProduct(product);
//        return Created("", newProduct);
//    }
//    catch (Exception e)
//    {
//        return BadRequest(e.Message);
//    }
//}

// //bad practice never use two put methods instead use Dto
//[HttpPut("UpdatedPrice")]
//public ActionResult<Product> UpdateProduct(ProductPriceUpdateRequestDTO productDto)
//{
//    try
//    {
//        var updatedProduct = _productService.UpdatePrice(productDto);
//        return Ok(updatedProduct);
//    }
//    catch (Exception e)
//    {
//        return BadRequest(e.Message);
//    }
//}

//[HttpPut("UpdatedStock")]
//public ActionResult<Product> UpdateStock(ProductStockUpdateRequestDTO productDto)
//{
//    try
//    {
//        var updatedStock = _productService.UpdateStock(productDto);
//        return Ok(updatedStock);
//    }
//    catch (Exception e)
//    {
//        return BadRequest(e.Message);
//    }
//}


//        [HttpPut]
//        public ActionResult<Product> UpdateProduct(ProductUpdateDTO productDto)
//        {

// // based on object input productDto we are calling respective methods of a service 
//            string message = "";
//            try
//            {
//                if (productDto.PriceChange != null)
//                {
//                    var updatedProduct = _productService.UpdatePrice(productDto.PriceChange);
//                    return Ok(updatedProduct);
//                }
//                else if (productDto.StockChange != null)
//                {
//                    var updatedProduct = _productService.UpdateStock(productDto.StockChange);
//                    return Ok(updatedProduct);
//                }
//            }
//            catch (Exception e)
//            {
//                message = e.Message;
//            }
//            return BadRequest(message);
//        }

//    }
//}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Models.DTO;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]//attribute routing
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductSupplierService _productService;

        public ProductController(IProductSupplierService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<ICollection<Product>> GetProducts()
        {
            try
            {
                var products = _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
            }
        }
        [HttpPost]
[ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
[ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
public ActionResult<Product> AddProduct(Product product)
{
    try
    {
        var newProduct = _productService.AddProduct(product);
        return Created("", newProduct);
    }
    catch (Exception e)
    {

        return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
    }
}
[HttpPut]
//annotation to update swagger document in order to show success and failure messages
//indexer order to customize bad request we can use error object as ErrorDTO 
[ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
public ActionResult<Product> UpdateProduct(ProductUpdateDTO productDto)
{
    string message = "";
    try
    {
        if (productDto.PriceChange != null)
        {
            var updatedProduct = _productService.UpdatePrice(productDto.PriceChange);
            return Ok(updatedProduct);
        }
        else if (productDto.StockChange != null)
        {
            var updatedProduct = _productService.UpdateStock(productDto.StockChange);
            return Ok(updatedProduct);
        }
    }
    catch (Exception e)
    {
        message = e.Message;
    }
    return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = message });
}

    }
}