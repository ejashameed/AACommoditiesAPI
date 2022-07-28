using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.DTOs;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard
{
    public class GetAllCommoditesRequestHandler : IRequestHandler<RequestCommand, List<CommodityDto>>
    {
        private readonly ICommodityRepository _commodityRepository;
        private readonly IMapper _mapper;

        public GetAllCommoditesRequestHandler(ICommodityRepository commodityRepository, IMapper mapper)
        {
            _commodityRepository = commodityRepository;
            _mapper = mapper;
        }

        public async Task<List<CommodityDto>> Handle(RequestCommand command)
        {
            var result = await _commodityRepository.GetAsync();
            return _mapper.Map<List<CommodityDto>>(result);
        }
    }
}
