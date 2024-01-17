using System.Text.Json;
using UKRainfall.API.IntegrationTests.Base;
using UKRainfall.Application.Features.Readings;

namespace UKRainfall.API.IntegrationTests.Controllers
{
    public class RainfallControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public RainfallControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/rainfall/id/289102TP/readings");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<ReadingListVm>>(responseString);

            Assert.IsType<List<ReadingListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
