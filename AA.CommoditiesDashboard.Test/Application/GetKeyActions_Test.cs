using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Mappers;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers;
using AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Test.Application
{
    public class GetKeyActions_Test
    {
        public async Task GetKeyActions()
        {
            var mockKeyActionsRepo = new Mock<IGetKeyactionsDataRepository>();
            var data = new List<HistoricalKeyActionsData>();
            data.Add(new HistoricalKeyActionsData()
            {
                Date =  DateTime.Now,
                Commodity = "Gold",
                Model = "S&P",
                Contract = "MAR 2020",
                Price = 3244,
                Position = 1,
                NewTradeAction = -1,
                PnlDaily = 34544
            });

            mockKeyActionsRepo.Setup(repo => repo.GetHistoricalActionsAsync()).ReturnsAsync(data);
            var myProfile = new DomainToDto();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            var handler = new GetKeyActionsRequestHandler(mockKeyActionsRepo.Object, mapper);
            var result = await handler.Handle(new RequestCommand());
            Assert.NotNull(result);
        }
    }
}
