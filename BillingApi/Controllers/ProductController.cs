using BillingApi.Models;
using BillingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var products = productService.GetProducts();
            return products;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var product = productService.GetProduct(id);
            if (product is null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            try
            {
                productService.CreateProduct(product);
                return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [HttpPut]
        public IActionResult PutProduct([FromBody] Product product)
        {
            try
            {
                productService.UpdateProduct(product);
                return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleteProduct = productService.GetProduct(id);
            if (deleteProduct is null) return NotFound();
            productService.DeleteProduct(deleteProduct.Id);
            return NoContent();
        }
    }
}
