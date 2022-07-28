using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Mappers;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers;
using AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard;
using AutoMapper;
using Moq;

namespace AA.CommoditiesDashboard.Test.Application
{
    public class GetCumulativePnl_Test
    {
        [Fact]
        public async Task GetCumulativePnl()
        {
            var mockCommodityRepo = new Mock<IGetCumulativePnlDataRepository>();
            var data = new List<CumulativePnLData>();
            data.Add(new CumulativePnLData()
            {
                Commodity = "Gold",
                Model = "S&P",
                CumulativeSum = 12455
            });
            mockCommodityRepo.Setup(repo => repo.GetCumulativePnLAsync()).ReturnsAsync(data);
            var myProfile = new DomainToDto();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            var handler = new GetCumulativePnLRequestHandler(mockCommodityRepo.Object, mapper);
            var result = await handler.Handle(new RequestCommand());
            Assert.NotNull(result);
        }
    }
}
