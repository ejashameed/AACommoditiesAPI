using AA.CommoditiesDashboard.Application.Domain.Models;
using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
