using MediatR;
using Microsoft.AspNetCore.Mvc;
using UKRainfall.Application.Features.Readings;

namespace UKRainfall.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RainfallController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get rainfall readings by station Id
        /// </summary>
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>        
        /// <returns></returns>
        [HttpGet("id/{stationId}/readings/get-rainfall", Name = "get-rainfall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ReadingListVm>>> GetRainfallByStationId(string stationId, int count)
        {                        
            var getRainfallReadingQuery = new GetReadingsListQuery() { StationId = stationId, Count = count == 0 ? 10 : count };
            return Ok(await _mediator.Send(getRainfallReadingQuery));
        }
    }
}
