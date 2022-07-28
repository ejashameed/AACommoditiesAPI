using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.DTOs;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Mappers;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers;
using AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard;
using AA.CommoditiesDashboard.Application.Shared.Domain.Models;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Test.Application
{
    
    public class GetCommodities_Test
    {
        [Fact]
        public async Task GetCommodities()
        {            
            var mockCommodityRepo = new Mock<ICommodityRepository>();
            var data = new List<Commodity>();
            data.Add(new Commodity()
            {
                Id = 1,
                ModelId = 1,
                Name = "Gold"        
            });
            mockCommodityRepo.Setup(repo => repo.GetAsync()).ReturnsAsync(data);
            var myProfile = new DomainToDto();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            var handler = new GetAllCommoditesRequestHandler(mockCommodityRepo.Object, mapper);
            var result = await handler.Handle(new RequestCommand());            
            Assert.NotNull(result);
        }   
    }
}
