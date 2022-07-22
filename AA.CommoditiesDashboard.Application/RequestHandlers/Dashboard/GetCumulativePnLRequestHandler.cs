using AA.CommoditiesDashboard.Application.DTOs.Dashboard;
using AA.CommoditiesDashboard.Application.Interfaces.ReadRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard
{
    public class GetCumulativePnLRequestHandler : IRequestHandler<List<CumulativePnLDataDto>>
    {
        private readonly IReadDataRepository _readDataRepository;
        private readonly IMapper _mapper;

        public GetCumulativePnLRequestHandler(IReadDataRepository readDataRepository, IMapper mapper)
        {
            _readDataRepository = readDataRepository;
            _mapper = mapper;
        }

        public async Task<List<CumulativePnLDataDto>> Handle()
        {
            var result = await _readDataRepository.GetCumulativePnLAsync();
            return _mapper.Map<List<CumulativePnLDataDto>>(result);                                  
        }
    }
}
