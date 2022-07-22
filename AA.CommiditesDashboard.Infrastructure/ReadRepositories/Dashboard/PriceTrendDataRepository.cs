using AA.CommiditesDashboard.Infrastructure.ReadRepositories.Helpers;
using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using AA.CommoditiesDashboard.Application.Interfaces.ReadRepositories.Dashboard;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommiditesDashboard.Infrastructure.ReadRepositories.Dashboard
{
    public class PriceTrendDataRepository : IPriceTrendDataRepository
    {
        private readonly SqlHelper _sqlHelper;
        public PriceTrendDataRepository(SqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public Task<List<YtdPriceTrendData>> GetPriceTrendDataAsync()
        {
            string sql = @"SELECT c.Name as Commodity, m.Name as Model,  Round(Avg(t.Price),0) as AveragePrice
                         FROM CommodityData t, Commodity c, Model m
                         where t.CommodityId = c.Id and c.Id = m.Id and Year(t.Date) = 2020 
                         group by c.Name, m.Name, Month(t.Date) 
                         order by c.Name, m.Name, Month(t.Date)";

            return _sqlHelper.RawSqlQuery<YtdPriceTrendData>(sql);
        }
    }
}
