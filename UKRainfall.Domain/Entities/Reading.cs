using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKRainfall.Domain.Entities
{
    public class Reading
    {
        public string Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Measure { get; set; }
        public decimal Value { get; set; }
    }
}
