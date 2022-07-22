using AA.CommoditiesDashboard.Application.DTOs;
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
    public class GetKeyActionsRequestHandler : IRequestHandler<IEnumerable<HistoricalKeyActionsDataDto>>
    {
        private readonly IReadDataRepository _readDataRepository;
        private readonly IMapper _mapper;

        public GetKeyActionsRequestHandler(IReadDataRepository readDataRepository, IMapper mapper)
        {
            _readDataRepository = readDataRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HistoricalKeyActionsDataDto>> Handle()
        {
            var result = await _readDataRepository.GetHistoricalActionsAsync();
            return _mapper.Map<List<HistoricalKeyActionsDataDto>>(result);            
        }
    }
}
