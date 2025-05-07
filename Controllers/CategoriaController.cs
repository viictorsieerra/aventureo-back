using AventureoBack.Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace AventureoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService ?? throw new ArgumentNullException(nameof(categoriaService));
        }

       
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetAllAsync()
        {
            try
            {
                var categorias = await _categoriaService.GetAllAsync();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }


        [HttpGet("{idCategoria}")]
        public async Task<ActionResult<Categoria>> GetByIdAsync(int idCategoria)
        {
            try
            {
                var categoria = await _categoriaService.GetByIdAsync(idCategoria);
                if (categoria == null)
                {
                    return NotFound(new { Message = "Categoría no encontrada" });
                }
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

      
        [HttpPost]
        public async Task<ActionResult<Categoria>> AddAsync([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest(new { Message = "El objeto Categoria no puede ser nulo" });
            }

            try
            {
                var newCategoria = await _categoriaService.AddAsync(categoria);
                return CreatedAtAction(nameof(GetByIdAsync), new { idCategoria = newCategoria.IdCategoria }, newCategoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

     
        [HttpPut("{idCategoria}")]
        public async Task<ActionResult<Categoria>> UpdateAsync(int idCategoria, [FromBody] Categoria categoria)
        {
            if (categoria == null || categoria.IdCategoria != idCategoria)
            {
                return BadRequest(new { Message = "El objeto Categoria es inválido o el ID no coincide." });
            }

            try
            {
                var updatedCategoria = await _categoriaService.UpdateAsync(categoria);
                return Ok(updatedCategoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        
        [HttpDelete("{idCategoria}")]
        public async Task<IActionResult> DeleteAsync(int idCategoria)
        {
            try
            {
                await _categoriaService.DeleteAsync(idCategoria);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
