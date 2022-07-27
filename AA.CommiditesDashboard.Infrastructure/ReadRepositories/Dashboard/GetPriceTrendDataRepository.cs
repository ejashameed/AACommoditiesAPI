using AA.CommiditesDashboard.Infrastructure.Shared.Helpers;
using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommiditesDashboard.Infrastructure.ReadRepositories.Dashboard
{
    public class GetPriceTrendDataRepository : IGetPriceTrendDataRepository
    {
        private readonly SqlHelper _sqlHelper;
        public GetPriceTrendDataRepository(SqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public Task<List<YtdPriceTrendData>> GetPriceTrendDataAsync(int year)
        {            
            string sql = @"SELECT c.Name as Commodity, m.Name as Model,  Round(Avg(t.Price),0) as AveragePrice
                         FROM CommodityData t, Commodity c, Model m
                         where t.CommodityId = c.Id and c.Id = m.Id and Year(t.Date) = @Year 
                         group by c.Name, m.Name, Month(t.Date) 
                         order by c.Name, m.Name, Month(t.Date)";

            var dictionary = new Dictionary<string, object>
            {
                { "@Year", year }
            };
            var parameters = new DynamicParameters(dictionary);

            return _sqlHelper.RawSqlQuery<YtdPriceTrendData>(sql, parameters);
        }
    }
}
