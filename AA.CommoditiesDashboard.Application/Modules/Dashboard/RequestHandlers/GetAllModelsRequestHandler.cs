using AA.CommoditiesDashboard.Application.DTOs.Dashboard;
using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using AA.CommoditiesDashboard.Application.RequestHandlers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers
{
    public class GetAllModelsRequestHandler : IRequestHandler<RequestCommand,List<ModelsDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        public GetAllModelsRequestHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<ModelsDto>> Handle(RequestCommand command)
        {
            var result = await _modelRepository.GetAsync();
            return _mapper.Map<List<ModelsDto>>(result);
        }
    }
}
