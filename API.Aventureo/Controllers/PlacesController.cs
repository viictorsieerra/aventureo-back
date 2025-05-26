using Application.Aventureo.Services;
using Core.Aventureo.DTO;
using Core.Aventureo.Interfaces.ExternalCommunication;
using Microsoft.AspNetCore.Mvc;

namespace API.Aventureo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesService _service;

        public PlacesController(IPlacesService service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<ActionResult<ResultPlaces>> GetPlacesAsync([FromBody] QueryPlaces query)
        {

            var result = await _service.GetPlaces(query);
            return Ok(result);

        }

        [HttpGet]
        public async Task<ActionResult<InfoPlace>> GetInfoPlaceAsync([FromQuery] string placeId)
        {
            var result = await _service.GetInfoPlace(placeId);

            return Ok(result);
        }
    }
}
