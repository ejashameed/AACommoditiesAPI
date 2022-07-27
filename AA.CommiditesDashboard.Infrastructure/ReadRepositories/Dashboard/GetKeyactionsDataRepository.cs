using AA.CommiditesDashboard.Infrastructure.Shared.Helpers;
using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommiditesDashboard.Infrastructure.ReadRepositories.Dashboard
{
    public class GetKeyactionsDataRepository : IGetKeyactionsDataRepository
    {
        private readonly SqlHelper _sqlHelper;
        public GetKeyactionsDataRepository(SqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public Task<List<HistoricalKeyActionsData>> GetHistoricalActionsAsync()
        {
            string sql = @"SELECT top(5) t.Date as Date, c.Name as Commodity, m.Name as Model, t.Contract, t.Price, t.Position, t.NewTradeAction, t.PnlDaily
                        FROM CommodityData t, Commodity c, Model m
                        where t.CommodityId = c.Id and c.Id = m.Id
                        order by Date desc";

            return _sqlHelper.RawSqlQuery<HistoricalKeyActionsData>(sql);
        }
    }
}
