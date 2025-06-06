using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Aventureo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoryController(ICategoriaService categoriaService)
        {
            _service = categoriaService ?? throw new ArgumentNullException(nameof(categoriaService));
        }

        [Authorize(Roles ="Admin,User")]
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetAllAsync()
        {

                var categorias = await _service.GetAllAsync();
                return Ok(categorias);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("{idCategoria}")]
        public async Task<ActionResult<Categoria>> GetByIdAsync(int idCategoria)
        {

            var categoria = await _service.GetByIdAsync(idCategoria);

            return Ok(categoria);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateCategoriaDTO>> AddAsync([FromBody] CreateCategoriaDTO categoria)
        {

            var newCategoria = await _service.AddAsync(categoria);
            return Ok(newCategoria);

        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<Categoria>> UpdateAsync([FromBody] UpdateCategoriaDTO categoria)
        {

            var updatedCategoria = await _service.UpdateAsync(categoria);
            return Ok(updatedCategoria);

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{idCategoria}")]
        public async Task<IActionResult> DeleteAsync(int idCategoria)
        {

            await _service.DeleteAsync(idCategoria);
            return NoContent();
        }
    }
}
