using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Modules.Dashboard.DTOs
{
    public class YtdPriceTrendDataDto
    {
        public string Commodity { get; set; }
        public string Model { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
