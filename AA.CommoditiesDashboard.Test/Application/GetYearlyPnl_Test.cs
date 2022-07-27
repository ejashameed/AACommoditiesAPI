using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using AA.CommoditiesDashboard.Application.DTOs.Dashboard;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Mappers;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers;
using AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard;
using AutoMapper;
using Moq;


namespace AA.CommoditiesDashboard.Test.Application
{
    public class GetYearlyPnl_Test
    {
        public class GetKeyActions_Test
        {
            public async Task GetYearlyPnl()
            {
                var mockYearlyPnlRepo = new Mock<IGetYearlyPnlDataRepository>();
                var data = new List<YearlyPnLData>();
                data.Add(new YearlyPnLData()
                {
                    Commodity = "Gold",
                    Model = "S&P",
                    Year = "2020",
                    CumulativeSum = 32455            
                });

                mockYearlyPnlRepo.Setup(repo => repo.GetYearlyPnLAsync()).ReturnsAsync(data);
                var myProfile = new DomainToDto();
                var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
                IMapper mapper = new Mapper(configuration);

                var handler = new GetYearlyPnLRequestHandler(mockYearlyPnlRepo.Object, mapper);
                var result = await handler.Handle(new RequestCommand());
                Assert.NotNull(result);
            }
        }
    }
}
