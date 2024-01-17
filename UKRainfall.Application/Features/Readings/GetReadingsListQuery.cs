using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKRainfall.Application.Features.Readings
{
    public class GetReadingsListQuery : IRequest<List<ReadingListVm>>
    {
        public string StationId { get; set; }
    }
}
