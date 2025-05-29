using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Aventureo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly IGastoService _service;

        public GastoController(IGastoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gasto>>> GetAllAsync()
        {

            var gastos = await _service.GetAllAsync();
            return Ok(gastos);
        }


        [HttpGet("{idGasto}")]
        public async Task<ActionResult<Categoria>> GetByIdAsync(int idGasto)
        {

            var gasto = await _service.GetByIdAsync(idGasto);

            return Ok(gasto);

        }

        [HttpGet("Viaje/{idViaje}")]
        public async Task<ActionResult<List<Gasto>>> GetGastosByViaje(int idViaje)
        {
            List<Gasto> result = await _service.GetGastosByViaje(idViaje);

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<CreateGastoDTO>> AddAsync([FromBody] CreateGastoDTO gasto)
        {

            var newGasto = await _service.AddAsync(gasto);
            return Ok(newGasto);

        }


        [HttpPut]
        public async Task<ActionResult<Gasto>> UpdateAsync([FromBody] UpdateGastoDTO gastoDto)
        {

            var updatedGasto = await _service.UpdateAsync(gastoDto);
            return Ok(updatedGasto);

        }


        [HttpDelete("{idGasto}")]
        public async Task<IActionResult> DeleteAsync(int idGasto)
        {

            await _service.DeleteAsync(idGasto);
            return NoContent();
        }
    }
}
