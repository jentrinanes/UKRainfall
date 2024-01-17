using AutoMapper;
using UKRainfall.Application.Contracts.Infrastructure;
using UKRainfall.Application.Features.Readings;
using UKRainfall.Application.Profiles;
using UKRainfall.Infrastructure.Reading;

namespace UKRainfall.Application.UnitTests.Readings.Queries
{
    public class GetReadingsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IReadingService _readingService;

        public GetReadingsListQueryHandlerTests()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _readingService = new ReadingService();
        }

        [Fact]
        public async Task GetReadingsListWithoutParamTest()
        {
            var handler = new GetReadingsListQueryHandler(_mapper, _readingService);
            var result = await handler.Handle(new GetReadingsListQuery() { StationId = "289102TP" }, CancellationToken.None);

            Assert.IsType<List<ReadingListVm>>(result);           
        }

        [Fact]
        public async Task GetReadingsListWithParamTest()
        {
            var handler = new GetReadingsListQueryHandler(_mapper, _readingService);
            var result = await handler.Handle(new GetReadingsListQuery() { StationId = "289102TP", Count = 20 }, CancellationToken.None);

            Assert.IsType<List<ReadingListVm>>(result);
        }

        [Fact]
        public async Task GetReadingsListInvalidStationIdWithoutParamTest()
        {
            var handler = new GetReadingsListQueryHandler(_mapper, _readingService);
            var result = await handler.Handle(new GetReadingsListQuery() { StationId = "289102T" }, CancellationToken.None);

            Assert.IsType<List<ReadingListVm>>(result);
        }
    }
}
