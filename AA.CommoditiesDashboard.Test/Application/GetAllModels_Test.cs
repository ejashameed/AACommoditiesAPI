using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Mappers;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers;
using AA.CommoditiesDashboard.Application.Shared.Domain.Models;
using AutoMapper;
using Moq;


namespace AA.CommoditiesDashboard.Test.Application
{
    public class GetAllModels_Test
    {
        [Fact]
        public async Task GetModels()
        {
            var mockModelRepo = new Mock<IModelRepository>();
            var data = new List<Model>();
            data.Add(new Model()
            {
                Id = 1,
                Name = "FTSE"
            });
            mockModelRepo.Setup(repo => repo.GetAsync()).ReturnsAsync(data);
            var myProfile = new DomainToDto();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            var handler = new GetAllModelsRequestHandler(mockModelRepo.Object, mapper);
            var result = await handler.Handle(new RequestCommand());
            Assert.NotNull(result);
        }
    }
}
