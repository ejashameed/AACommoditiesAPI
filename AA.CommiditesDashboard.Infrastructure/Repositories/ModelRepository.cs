using AA.CommoditiesDashboard.Application.Shared.Domain.Models;
using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AA.CommiditesDashboard.Infrastructure.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly DashboardDbContext _dbContext;
        public ModelRepository(DashboardDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Model>> GetAsync()
        {
            return await _dbContext.Model.ToListAsync();
        }
    }
}
