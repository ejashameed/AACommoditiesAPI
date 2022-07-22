using AA.CommoditiesDashboard.Application.DTOs;
using AA.CommoditiesDashboard.Application.DTOs.Dashboard;
using AA.CommoditiesDashboard.Application.Interfaces.ReadRepositories.Dashboard;
using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard
{
    public class GetYtdPriceTrendsRequestHandler : IRequestHandler<List<YtdPriceTrendDataDto>>
    {
        private readonly IPriceTrendDataRepository _trendDataRepository;
        private readonly ICommodityRepository _commodityRepository;

        private readonly IMapper _mapper;

        public GetYtdPriceTrendsRequestHandler(IPriceTrendDataRepository trendDataRepository, IMapper mapper, ICommodityRepository commodityRepository)
        {
            _trendDataRepository = trendDataRepository;
            _commodityRepository = commodityRepository;
            _mapper = mapper;
        }

        public async Task<List<YtdPriceTrendDataDto>> Handle()
        {
            var commodities = await _commodityRepository.GetAsync();
            var trends = await _trendDataRepository.GetPriceTrendDataAsync();
            var series = new List<TrendSeriesDto>();
            foreach (var commodity in commodities)
            {
                var data = trends.Where(item => item.Commodity == commodity.Name).ToList();
                series.Add(new TrendSeriesDto
                {
                    Name = commodity.Name,
                    Type = "line",                    

                }) ;     
               
            }
            
            //return _mapper.Map<List<ModelsDto>>(result);
        }
    }
}
