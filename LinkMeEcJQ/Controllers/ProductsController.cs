using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LinkMeEcJQ.Domain;
using LinkMeEcJQ.Infrastructure.Persistence;

namespace LinkMeEcJQ.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repository;

        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _repository.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener los productos.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener el producto por ID.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                await _repository.CreateAsync(product);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al crear el producto.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Product product)
        {
            try
            {
                var existingProduct = await _repository.GetByIdAsync(id);
                if (existingProduct == null)
                    return NotFound();

                await _repository.UpdateAsync(id, product);

                // Mensaje de éxito
                return Ok(new { message = "Producto actualizado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al actualizar el producto.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var existingProduct = await _repository.GetByIdAsync(id);
                if (existingProduct == null)
                    return NotFound();

                await _repository.DeleteAsync(id);

                // Mensaje de éxito
                return Ok(new { message = "Producto Eliminado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al eliminar el producto.");
            }
        }
    }
}
