using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Domain.ReadModels
{
    public class YearlyPnLData
    {
        public string Commodity { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public decimal CumulativeSum { get; set; }
    }
}
