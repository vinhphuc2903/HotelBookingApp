using Microsoft.AspNetCore.Mvc;
using MiniShopBE.Areas.Products.Models;
using MiniShopBE.Areas.Products.Services;

namespace MiniShopBE.Areas.Products.Controllers
{
    [Area("Products")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductModel product)
        {
            var created = _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductModel product)
        {
            return Ok(_productService.UpdateProduct(id, product));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
