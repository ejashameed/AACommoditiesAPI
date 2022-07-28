using AA.CommoditiesDashboard.Application.Shared.Domain.Models;
using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AA.CommiditesDashboard.Infrastructure.Repositories
{
    public class CommodityRepository : ICommodityRepository
    {
        private readonly DashboardDbContext _dbContext;
        public CommodityRepository(DashboardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Commodity>> GetAsync()
        {
            return await _dbContext.Commodity.ToListAsync();
        }
    }
}
