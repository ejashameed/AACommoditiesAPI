using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using AA.CommoditiesDashboard.Application.DTOs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AA.CommoditiesDashboard.Application.Domain.Models;

namespace AA.CommoditiesDashboard.Application.Mappers
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
