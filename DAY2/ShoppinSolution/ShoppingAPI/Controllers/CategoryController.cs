using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Models.DTO;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;


        }
        [HttpGet]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<ICollection<Category>> Get()
        {
            try
            {
                var categoryList = _categoryService.GetCategories();
                return Ok(categoryList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
