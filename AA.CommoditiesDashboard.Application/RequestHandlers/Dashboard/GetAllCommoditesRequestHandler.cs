using AA.CommoditiesDashboard.Application.DTOs.Dashboard;
using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard
{
    public class GetAllCommoditesRequestHandler : IRequestHandler<List<CommodityDto>>
    {
        private readonly ICommodityRepository _commodityRepository;
        private readonly IMapper _mapper;

        public GetAllCommoditesRequestHandler(ICommodityRepository commodityRepository, IMapper mapper)
        {
            _commodityRepository = commodityRepository;
            _mapper = mapper;
        }

        public async Task<List<CommodityDto>> Handle()
        {
            var result = await _commodityRepository.GetAsync();
            return _mapper.Map<List<CommodityDto>>(result);
        }
    }
}
