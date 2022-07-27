using AA.CommoditiesDashboard.Application.DTOs;
using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.DTOs;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using AA.CommoditiesDashboard.Application.RequestHandlers;
using AA.CommoditiesDashboard.Application.Shared.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers
{
    public class GetYtdPriceTrendsRequestHandler : IRequestHandler<TrendRequestCommand, List<TrendSeriesDto>>
    {
        private readonly IGetPriceTrendDataRepository _trendDataRepository;
        private readonly IGetCommodityWithModelRepository _getCommodityWithModelRepository;

        private readonly IMapper _mapper;

        public GetYtdPriceTrendsRequestHandler(IGetPriceTrendDataRepository trendDataRepository, IMapper mapper, IGetCommodityWithModelRepository getCommodityWithModelRepository)
        {
            _trendDataRepository = trendDataRepository;
            _getCommodityWithModelRepository = getCommodityWithModelRepository;
            _mapper = mapper;
        }

        public async Task<List<TrendSeriesDto>> Handle(TrendRequestCommand command)
        {
            var commodities = await _getCommodityWithModelRepository.GetAsync();
            var trends = await _trendDataRepository.GetPriceTrendDataAsync(command.Year);
            var series = new List<TrendSeriesDto>();
            foreach (var commodity in commodities)
            {
                series.Add(new TrendSeriesDto   
                {
                    Name = commodity.Name + '-' + commodity.Model,
                    Type = "line",
                    Data = trends.Where(item => item.Commodity == commodity.Name && item.Model == commodity.Model)
                            .Select(d => new TrendValueDto
                            {
                                AveragePrice = d.AveragePrice,
                            }).ToList()
                });

            }

            return series;
        }
    }
}
