using CrudUsingWebAPI.Models;
using CrudUsingWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IRepository<Product> productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get the list of products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving products.");
                return StatusCode(500, "An error occurred while retrieving products.");
            }
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the product with id {id}.");
                return StatusCode(500, $"An error occurred while retrieving the product with id {id}.");
            }
        }

        /// <summary>
        /// Post method for create the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdProduct = await _productRepository.AddAsync(product);
                return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.ProductId }, createdProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the product.");
                return StatusCode(500, "An error occurred while creating the product.");
            }
        }

        /// <summary>
        /// Update the product by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            try
            {
                if (id != product.ProductId)
                {
                    return BadRequest();
                }

                await _productRepository.UpdateAsync(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the product with id {id}.");
                return StatusCode(500, $"An error occurred while updating the product with id {id}.");
            }
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the product with id {id}.");
                return StatusCode(500, $"An error occurred while deleting the product with id {id}.");
            }
        }
    }
}

