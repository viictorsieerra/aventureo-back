using Core.Aventureo.Dto;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Service;
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


        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetAllAsync()
        {

                var categorias = await _service.GetAllAsync();
                return Ok(categorias);
        }


        [HttpGet("{idCategoria}")]
        public async Task<ActionResult<Categoria>> GetByIdAsync(int idCategoria)
        {

            var categoria = await _service.GetByIdAsync(idCategoria);

            return Ok(categoria);

        }


        [HttpPost]
        public async Task<ActionResult<CreateCategoriaDTO>> AddAsync([FromBody] CreateCategoriaDTO categoria)
        {

            var newCategoria = await _service.AddAsync(categoria);
            return Ok(newCategoria);

        }


        [HttpPut]
        public async Task<ActionResult<Categoria>> UpdateAsync([FromBody] UpdateCategoriaDTO categoria)
        {

            var updatedCategoria = await _service.UpdateAsync(categoria);
            return Ok(updatedCategoria);

        }


        [HttpDelete("{idCategoria}")]
        public async Task<IActionResult> DeleteAsync(int idCategoria)
        {

            await _service.DeleteAsync(idCategoria);
            return NoContent();
        }
    }
}
