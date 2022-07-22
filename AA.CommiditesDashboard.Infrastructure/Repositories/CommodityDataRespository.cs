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
    public class CommodityDataRespository : ICommodityDataRepository
    {
        private readonly DashboardDbContext _dbContext;
        public CommodityDataRespository(DashboardDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public async Task<List<CommodityData>> GetAsync()
        {
           return await _dbContext.CommodityData.ToListAsync();
        }
    }
}
