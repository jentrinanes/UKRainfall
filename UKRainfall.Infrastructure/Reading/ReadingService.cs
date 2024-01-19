using Microsoft.Extensions.Logging;
using RestSharp;
using UKRainfall.Application.Contracts.Infrastructure;

namespace UKRainfall.Infrastructure.Reading
{
    // This class is used to deserialize the JSON response from the Rainfall API
    
    public class ReadingService : IReadingService
    {       
        public async Task<IEnumerable<Application.Models.Reading.Reading>> GetStationReadingsAsync(string stationId, int count)
        {
            try
            {
                var options = new RestClientOptions("https://environment.data.gov.uk/flood-monitoring/id/stations/" + stationId + "/readings?latest&_limit=" + count.ToString());
                var client = new RestClient(options);

                var request = new RestRequest();
                var response = await client.GetAsync<ReadingResponse>(request);

                var readings = new List<Application.Models.Reading.Reading>();

                foreach (var reading in response.Items)
                {
                    readings.Add(new Application.Models.Reading.Reading()
                    {
                        DateMeasured = reading.DateTime,
                        AmountMeasured = reading.Value
                    });
                }

                return readings;
            }
            catch (Exception ex)
            {                
                throw;
            }                        
        }
    }
}
