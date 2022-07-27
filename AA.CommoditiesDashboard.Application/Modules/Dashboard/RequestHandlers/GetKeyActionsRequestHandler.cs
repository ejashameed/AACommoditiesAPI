using AA.CommoditiesDashboard.Application.DTOs;
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
    public class GetKeyActionsRequestHandler : IRequestHandler<RequestCommand,IEnumerable<HistoricalKeyActionsDataDto>>
    {
        private readonly IGetKeyactionsDataRepository _keyactionsDataRepository;
        private readonly IMapper _mapper;

        public GetKeyActionsRequestHandler(IGetKeyactionsDataRepository keyactionsDataRepository, IMapper mapper)
        {
            _keyactionsDataRepository = keyactionsDataRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HistoricalKeyActionsDataDto>> Handle(RequestCommand command)
        {
            var result = await _keyactionsDataRepository.GetHistoricalActionsAsync();
            return _mapper.Map<List<HistoricalKeyActionsDataDto>>(result);            
        }
    }
}
