using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Modules.Dashboard.DTOs
{
    public class TrendSeriesDto
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public List<TrendValueDto> Data { get; set; } = new List<TrendValueDto>();
    }
}
