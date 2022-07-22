using AA.CommoditiesDashboard.Application.DTOs.Dashboard;
using AA.CommoditiesDashboard.Application.Interfaces.ReadRepositories;
using AutoMapper;

namespace AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard
{
    public class GetYearlyPnLRequestHandler : IRequestHandler<List<YearlyPnLDataDto>>
    {
        private readonly IReadDataRepository _readDataRepository;
        private readonly IMapper _mapper;

        public GetYearlyPnLRequestHandler(IReadDataRepository readDataRepository, IMapper mapper)
        {
            _readDataRepository = readDataRepository;
            _mapper = mapper;
        }

        public async Task<List<YearlyPnLDataDto>> Handle()
        {
            var result = await _readDataRepository.GetYearlyPnLAsync();
            return _mapper.Map<List<YearlyPnLDataDto>>(result);
        }
    }
}
