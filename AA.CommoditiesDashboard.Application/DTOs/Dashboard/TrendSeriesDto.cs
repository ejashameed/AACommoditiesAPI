using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.DTOs.Dashboard
{
    public class TrendSeriesDto
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public List<TrendValueDto> Data = new();
    }
}
