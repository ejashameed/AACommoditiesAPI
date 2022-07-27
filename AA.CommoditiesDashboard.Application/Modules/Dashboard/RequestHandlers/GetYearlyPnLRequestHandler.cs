using AA.CommoditiesDashboard.Application.DTOs.Dashboard;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers;
using AutoMapper;

namespace AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard
{
    public class GetYearlyPnLRequestHandler : IRequestHandler<RequestCommand, List<YearlyPnLDataDto>>
    {
        private readonly IGetYearlyPnlDataRepository _yearlyPnlDataRepository;
        private readonly IMapper _mapper;

        public GetYearlyPnLRequestHandler(IGetYearlyPnlDataRepository yearlyPnlDataRepository, IMapper mapper)
        {
            _yearlyPnlDataRepository = yearlyPnlDataRepository;
            _mapper = mapper;
        }

        public async Task<List<YearlyPnLDataDto>> Handle(RequestCommand command)
        {
            var result = await _yearlyPnlDataRepository.GetYearlyPnLAsync();
            return _mapper.Map<List<YearlyPnLDataDto>>(result);
        }
    }
}
