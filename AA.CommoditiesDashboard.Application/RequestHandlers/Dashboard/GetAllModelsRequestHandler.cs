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
    public class GetAllModelsRequestHandler : IRequestHandler<List<ModelsDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        public GetAllModelsRequestHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<ModelsDto>> Handle()
        {
            var result = await _modelRepository.GetAsync();
            return _mapper.Map<List<ModelsDto>>(result);
        }
    }
}
