using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UKRainfall.Application.Features.Readings
{
    public class GetReadingsListQuery : IRequest<List<ReadingListVm>>
    {
        public string StationId { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 10;
    }
}
