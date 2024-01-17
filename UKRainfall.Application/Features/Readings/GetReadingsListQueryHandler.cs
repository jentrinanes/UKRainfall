using AutoMapper;
using MediatR;
using UKRainfall.Application.Contracts.Infrastructure;

namespace UKRainfall.Application.Features.Readings
{
    public class GetReadingsListQueryHandler : IRequestHandler<GetReadingsListQuery, List<ReadingListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IReadingService _readingService;
        
        public GetReadingsListQueryHandler(IMapper mapper, IReadingService readingService)
        {
            _mapper = mapper;
            _readingService = readingService;
        }
        
        public async Task<List<ReadingListVm>> Handle(GetReadingsListQuery request, CancellationToken cancellationToken)
        {
            // get readings from the Rainfall API

            var allReadings = await _readingService.GetStationReadingsAsync(request.StationId);            
            return _mapper.Map<List<ReadingListVm>>(allReadings);                        
        }
    }
}
