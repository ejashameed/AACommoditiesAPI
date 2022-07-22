using AA.CommiditesDashboard.Infrastructure.ReadRepositories.Helpers;
using AA.CommoditiesDashboard.Application.Domain.Models;
using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using AA.CommoditiesDashboard.Application.Interfaces.ReadRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommiditesDashboard.Infrastructure.ReadRepositories
{
    public class ReadDataRepository : IReadDataRepository
    {
        private readonly SqlHelper _sqlHelper;
        public ReadDataRepository(SqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        public Task<List<CumulativePnLData>> GetCumulativePnLAsync()
        {
            string sql = @"SELECT c.Name as Commodity, m.Name as Model, sum(t.PnlDaily) as CumulativeSum
                         FROM CommodityData t, Commodity c, Model m
                         where t.CommodityId = c.Id and c.Id = m.Id Group by c.Name, m.Name order by c.Name, m.Name";

            return _sqlHelper.RawSqlQuery<CumulativePnLData>(sql);
        }

        public Task<List<HistoricalKeyActionsData>> GetHistoricalActionsAsync()
        {
            string sql = @"SELECT top(5) t.Date as Date, c.Name as Commodity, m.Name as Model, t.Contract, t.Price, t.Position, t.NewTradeAction, t.PnlDaily
                        FROM CommodityData t, Commodity c, Model m
                        where t.CommodityId = c.Id and c.Id = m.Id
                        order by Date desc";

            return _sqlHelper.RawSqlQuery<HistoricalKeyActionsData>(sql);
        }

        public Task<List<YearlyPnLData>> GetYearlyPnLAsync()
        {
            string sql = "SELECT c.Name as Commodity, m.Name as Model, Year(t.Date) as Year, sum(t.PnlDaily) as CumulativeSum " +
                        "FROM CommodityData t, Commodity c, Model m " +
                        "where t.CommodityId = c.Id and c.Id = m.Id and Year(t.Date) >= 2019 Group by Year(t.Date), c.Name, m.Name order by Year(t.Date), c.Name, m.Name";

            return _sqlHelper.RawSqlQuery<YearlyPnLData>(sql);
        }

       
        public Task<List<Commodity>> GetAllCommodities()
        {
            string sql = "SELECT c.Id as Id, c.ModelId as ModelId, c.Name as Commodity from Commodity c";                                                
            return _sqlHelper.RawSqlQuery<Commodity>(sql);
        }

        public Task<List<Model>> GetAllModels()
        {
            string sql = "SELECT m.Id as Id, m.Name as Model from Model m";
            return _sqlHelper.RawSqlQuery<Model>(sql);
        }

    }
}
