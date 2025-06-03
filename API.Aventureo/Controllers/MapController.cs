using Core.Aventureo.DTO;
using Core.Aventureo.Interfaces.ExternalCommunication;
using Microsoft.AspNetCore.Mvc;

namespace API.Aventureo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController :ControllerBase
    {
        private readonly IMapService _service;

        public MapController (IMapService service)
        {
            _service = service;
        }

        [HttpGet("{query}")]
        public async Task <ActionResult<MapDTO>> GetInfoMapPlace(string query)
        {
            MapDTO result = await _service.GetInfoMapPlace(query);

            return Ok(result);
        }
    }
}
