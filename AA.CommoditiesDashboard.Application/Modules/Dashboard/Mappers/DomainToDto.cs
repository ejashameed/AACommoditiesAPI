using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using AA.CommoditiesDashboard.Application.DTOs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AA.CommoditiesDashboard.Application.Shared.Domain.Models;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.DTOs;

namespace AA.CommoditiesDashboard.Application.Modules.Dashboard.Mappers
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<CumulativePnLData, CumulativePnLDataDto>();
            CreateMap<HistoricalKeyActionsData, HistoricalKeyActionsDataDto>();
            CreateMap<YearlyPnLData, YearlyPnLDataDto>();           
            CreateMap<Commodity, CommodityDto>();
            CreateMap<Model, ModelsDto>();
        }
        
        
    }
}
