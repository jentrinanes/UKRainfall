using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKRainfall.Application.Models.Reading;

namespace UKRainfall.Application.Contracts.Infrastructure
{
    public interface IReadingService
    {
        Task<IEnumerable<Reading>> GetStationReadingsAsync(string stationId, int count);
    }
}
