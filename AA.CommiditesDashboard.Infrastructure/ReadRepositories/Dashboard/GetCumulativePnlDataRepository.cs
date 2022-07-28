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
    public class GetCumulativePnlDataRepository : IGetCumulativePnlDataRepository
    {
        private readonly SqlHelper _sqlHelper;
        public GetCumulativePnlDataRepository(SqlHelper sqlHelper)
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
    }
}
