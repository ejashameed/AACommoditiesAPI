using AA.CommoditiesDashboard.Application.DTOs.Dashboard;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard
{
    public class GetCumulativePnLRequestHandler : IRequestHandler<RequestCommand, List<CumulativePnLDataDto>>
    {
        private readonly IGetCumulativePnlDataRepository _cumulativePnlDataRepository;
        private readonly IMapper _mapper;

        public GetCumulativePnLRequestHandler(IGetCumulativePnlDataRepository cumulativePnlDataRepository, IMapper mapper)
        {
            _cumulativePnlDataRepository = cumulativePnlDataRepository;
            _mapper = mapper;
        }

        public async Task<List<CumulativePnLDataDto>> Handle(RequestCommand command)
        {
            var result = await _cumulativePnlDataRepository.GetCumulativePnLAsync();
            return _mapper.Map<List<CumulativePnLDataDto>>(result);                                  
        }
    }
}
