using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FuelRoute.Core.Models;
using FuelRoute.Core.Interfaces;

namespace FuelRoute.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IGasStationService _gasStationService;

        public RouteController(IGasStationService gasStationService)
        {
            _gasStationService = gasStationService;
        }

        // -----------------------------
        // 1️⃣ Existing Lat/Lng Endpoint
        // -----------------------------
        [HttpPost("suggest")]
        public async Task<IActionResult> Suggest([FromBody] RouteRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _gasStationService.GetBestStationAsync(request);

            if (result == null)
                return NotFound("No gas stations available.");

            return Ok(result);
        }

        // ---------------------------------------
        // 2️⃣ New Address-Based Suggestion Endpoint
        // ---------------------------------------
        [HttpPost("suggest/address")]
        public async Task<IActionResult> SuggestAddress([FromBody] AddressRouteRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.StartAddress) || string.IsNullOrWhiteSpace(req.EndAddress))
                return BadRequest("Both start and end addresses are required.");

            // Geocode both addresses
            var start = await _gasStationService.GeocodeAsync(req.StartAddress);
            var end = await _gasStationService.GeocodeAsync(req.EndAddress);

            if (start == null || end == null)
                return BadRequest("Could not geocode one or both addresses.");

            // Convert into a RouteRequest
            var routeReq = new RouteRequest
            {
                StartLat = start.Value.lat,
                StartLng = start.Value.lng,
                EndLat = end.Value.lat,
                EndLng = end.Value.lng
            };

            var result = await _gasStationService.GetBestStationAsync(routeReq);

            if (result == null)
                return NotFound("No gas stations available.");

            return Ok(result);
        }
    }
}
