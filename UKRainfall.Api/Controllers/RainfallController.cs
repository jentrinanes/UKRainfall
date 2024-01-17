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

        [HttpGet("id/{stationId}/readings", Name = "GetRainfall")]
        public async Task<ActionResult<List<ReadingListVm>>> GetEventById(string stationId)
        {
            var getRainfallReadingQuery = new GetReadingsListQuery() { StationId = stationId };
            return Ok(await _mediator.Send(getRainfallReadingQuery));
        }
    }
}
