using Microsoft.AspNetCore.Mvc;
using Zadanie5.Interfaces;

namespace Zadanie5.Controllers
{
    [Route("api/trips")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripsRepository _tripsRepository;
        public TripController(ITripsRepository tripsRepository) 
        {
            _tripsRepository = tripsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var result = await _tripsRepository.GetTripsAsync();
            return Ok(result);
        }
    }
}
