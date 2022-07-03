using KP.Infrastructure.Dtos;
using KP.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace KP.API.Controllers
{
    public class DirectionsOfTravelController : BaseController
    {
        private readonly IDirectionsOfTravelService _directionsOfTravelService;

        public DirectionsOfTravelController(IDirectionsOfTravelService directionsOfTravelService)
        {
            _directionsOfTravelService = directionsOfTravelService;
        }


        // GET
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DirectionsOfTravelDto>))]
        public async Task<ActionResult<IEnumerable<DirectionsOfTravelDto>>> GetAllTravelDirections()
        {
            var result = await _directionsOfTravelService.GetList();
            if (result.Any())
                return Ok(result);
            return NotFound();
        }

        // GETBYID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DirectionsOfTravelDto))]
        public async Task<ActionResult<DirectionsOfTravelDto>> GetById(int id)
        {
            var result = await _directionsOfTravelService.GetById(id);
            if (result == null)
                return NotFound("Id not found");
            return Ok(result);
        }
    }
}